using System;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Core
{
    public static class PropertyBindingExtension
    {
        public static BaseField<T> WithBind<T>(this BaseField<T> field, Func<object> getter, Action<object> setter)
        {
            Func<T> typeGetter = getter != null ? () => (T)getter() : null;
            Action<T> typeSetter = setter != null ? v => setter(v) : null;

            return field.WithBind(typeGetter, typeSetter);
        }

        public static BaseField<T> WithBind<T>(this BaseField<T> field, Func<T> getter, Action<T> setter)
        {
            field.binding = new PropertyBinding<T>(field, getter, setter);
            return field;
        }
    }

    internal class PropertyBinding<T> : IBinding
    {
        public PropertyBinding(BaseField<T> field, Func<T> getter, Action<T> setter)
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
