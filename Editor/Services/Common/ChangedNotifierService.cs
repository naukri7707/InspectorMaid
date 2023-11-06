using System;
using System.Collections.Generic;

namespace Naukri.InspectorMaid.Editor.Services.Common
{
    internal sealed class ChangedNotifierService : IChangedNotifierService
    {
        public ChangedNotifierService(IEditorEventService editorEventService, IFastReflectionService fastReflectionService)
        {
            this.editorEventService = editorEventService;
            this.fastReflectionService = fastReflectionService;
            this.editorEventService.OnUpdate += EditorEventService_OnUpdate;
        }

        public Dictionary<string, IListener> listeners = new();

        private readonly IEditorEventService editorEventService;

        private readonly IFastReflectionService fastReflectionService;

        public void ListenValue<T>(string bindingPath, Action<T> callback)
        {
            if (listeners.TryGetValue(bindingPath, out var listener))
            {
                ((ValueListener<T>)listener).callback += callback;
            }
            else
            {
                listener = new ValueListener<T>(bindingPath, callback);
                listeners.Add(bindingPath, listener);
            }
        }

        public void ListenFunc<T>(string bindingPath, object[] args, Action<T> callback)
        {
            if (listeners.TryGetValue(bindingPath, out var listener))
            {
                ((FuncListener<T>)listener).callback += callback;
            }
            else
            {
                listener = new FuncListener<T>(bindingPath, args, callback);
                listeners.Add(bindingPath, listener);
            }
        }

        private void EditorEventService_OnUpdate()
        {
            foreach (var listener in listeners.Values)
            {
                listener.CheckValueChanged(fastReflectionService);
            }
        }

        public interface IListener
        {
            public void CheckValueChanged(IFastReflectionService fastReflectionService);
        }

        public class FuncListener<T> : ValueListener<T>
        {
            public FuncListener(string bindingPath, object[] args, Action<T> callback) : base(bindingPath, callback)
            {
                this.args = args;
            }

            private readonly object[] args;

            public override void CheckValueChanged(IFastReflectionService fastReflectionService)
            {
                var newValue = fastReflectionService.InvokeFunc<T>(bindingPath, args);

                if (newValue == null)
                {
                    if (previousValue != null)
                    {
                        previousValue = newValue;
                        callback?.Invoke(newValue);
                    }
                }
                else
                {
                    if (!newValue.Equals(previousValue))
                    {
                        previousValue = newValue;
                        callback?.Invoke(newValue);
                    }
                }
            }
        }

        public class ValueListener<T> : IListener
        {
            public ValueListener(string bindingPath, Action<T> callback)
            {
                this.bindingPath = bindingPath;
                this.callback = callback;
            }

            public string bindingPath;

            public Action<T> callback;

            protected T previousValue;

            public virtual void CheckValueChanged(IFastReflectionService fastReflectionService)
            {
                var newValue = fastReflectionService.GetValue<T>(bindingPath);

                if (newValue == null)
                {
                    if (previousValue != null)
                    {
                        previousValue = newValue;
                        callback?.Invoke(newValue);
                    }
                }
                else
                {
                    if (!newValue.Equals(previousValue))
                    {
                        previousValue = newValue;
                        callback?.Invoke(newValue);
                    }
                }
            }
        }
    }
}
