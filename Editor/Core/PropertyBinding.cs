using System;
using System.Reflection;
using UnityEditor;
using UnityEngine.UIElements;
using UObject = UnityEngine.Object;

namespace Naukri.InspectorMaid.Editor.Core
{
    public static class PropertyBindingExtension
    {
        public static BaseField<T> WithBind<T>(this BaseField<T> field, UObject target, PropertyInfo info)
        {
            field.binding = new PropertyBinding<T>(field, target, info);
            return field;
        }
    }

    internal class PropertyBinding<T> : IBinding
    {
        public PropertyBinding(BaseField<T> field, UObject target, PropertyInfo info)
        {
            this.target = target;
            this.field = field;
            this.info = info;

            if (info.CanWrite)
            {
                field.RegisterValueChangedCallback(OnChanged);
            }
            else
            {
                field.SetEnabled(false);
            }
        }

        public readonly BaseField<T> field;

        public readonly UObject target;

        private readonly PropertyInfo info;

        public void OnChanged(ChangeEvent<T> changeEvent)
        {
            var v = Convert.ChangeType(changeEvent.newValue, info.PropertyType);
            info.SetValue(target, v);
            EditorUtility.SetDirty(target);
        }

        public void PreUpdate() { }

        public void Release()
        {
            if (info.CanWrite)
            {
                field.UnregisterValueChangedCallback(OnChanged);
            }
        }

        public void Update()
        {
            if (info.CanRead)
            {
                var v = info.GetValue(target);
                field.value = (T)Convert.ChangeType(v, typeof(T));
            }
        }
    }
}
