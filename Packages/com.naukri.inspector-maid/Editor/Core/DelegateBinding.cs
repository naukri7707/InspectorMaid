using System;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Core
{
    public class DelegateBinding
    {
        protected DelegateBinding() { }

        public static void Bind<T>(BaseField<T> field, Func<object> getter, Action<object> setter)
        {
            Func<T> typeGetter = getter != null ? () => (T)getter() : null;
            Action<T> typeSetter = setter != null ? v => setter(v) : null;
            Bind(field, typeGetter, typeSetter);
        }

        public static void Bind<T>(BaseField<T> field, Func<T> getter, Action<T> setter)
        {
            var binding = new DelegateBinding<T>(field, getter, setter);

            field.binding = binding;
        }
    }

    internal class DelegateBinding<T> : DelegateBinding, IBinding
    {
        internal DelegateBinding(BaseField<T> field, Func<T> getter, Action<T> setter)
        {
            this.field = field;
            this.getter = getter;
            this.setter = setter;

            if (setter == null)
            {
                field.SetEnabled(false);
            }
            else
            {
                field.RegisterValueChangedCallback(OnChanged);
            }
        }

        public readonly BaseField<T> field;

        public readonly Func<T> getter;

        private readonly Action<T> setter;

        public void OnChanged(ChangeEvent<T> changeEvent)
        {
            setter.Invoke(changeEvent.newValue);
        }

        public void PreUpdate()
        { }

        public void Release()
        {
            if (setter != null)
            {
                field.UnregisterValueChangedCallback(OnChanged);
            }
        }

        public void Update()
        {
            if (getter != null)
            {
                field.value = getter();
            }
        }
    }
}
