using Naukri.InspectorMaid.Core;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UObject = UnityEngine.Object;

namespace Naukri.InspectorMaid.Editor.Core
{
    public abstract class CustomDrawer
    {
        private MemberInfo _info;

        private SerializedProperty _serializedProperty;

        private UObject _target;

        [SuppressMessage("Style", "IDE1006")]
        public FieldInfo fieldInfo
        {
            get
            {
                // try to return member info and cast to field info otherwise throw exception
                if (_info is FieldInfo fieldInfo)
                {
                    return fieldInfo;
                }
                else
                {
                    throw new Exception($"Can not get fieldInfo, because the member '{_info.Name}' is not a field.");
                }
            }
        }

        public bool IsBinding => attributeRef.binding != null;

        [SuppressMessage("Style", "IDE1006")]
        public MethodInfo methodInfo
        {
            get
            {
                // try to return member info and cast to field info otherwise throw exception
                if (_info is MethodInfo methodInfo)
                {
                    return methodInfo;
                }
                else
                {
                    throw new Exception($"Can not get methodInfo, because the member '{_info.Name}' is not a method.");
                }
            }
        }

        [SuppressMessage("Style", "IDE1006")]
        public PropertyInfo propertyInfo
        {
            get
            {
                // try to return member info and cast to field info otherwise throw exception
                if (_info is PropertyInfo propertyInfo)
                {
                    return propertyInfo;
                }
                else
                {
                    throw new Exception($"Can not get propertyInfo, because the member '{_info.Name}' is not a property.");
                }
            }
        }

        [SuppressMessage("Style", "IDE1006")]
        public SerializedProperty serializedProperty => _serializedProperty;

        [SuppressMessage("Style", "IDE1006")]
        public UObject target => _target;

        internal abstract Type AttributeType { get; }

        [SuppressMessage("Style", "IDE1006")]
        protected internal abstract InspectorMaidAttribute attributeRef { get; set; }

        [SuppressMessage("Style", "IDE1006")]
        protected internal abstract DecoratorElement decoratorRef { get; set; }

        public object GetBindingValue()
        {
            var type = target.GetType();
            var bindingPath = attributeRef.binding;

            if (type.GetField(bindingPath, Utility.AllAccessFlags) is FieldInfo field)
            {
                return field.GetValue(target);
            }
            else if (type.GetProperty(bindingPath, Utility.AllAccessFlags) is PropertyInfo property)
            {
                return property.GetValue(target);
            }
            else if (type.GetMethod(bindingPath, Utility.AllAccessFlags) is MethodInfo method)
            {
                var args = attributeRef.args;
                return method.Invoke(target, args);
            }
            else
            {
                throw new Exception($"Can't find binding path: {bindingPath}");
            }
        }

        public TBinding GetBindingValue<TBinding>()
        {
            var value = GetBindingValue();
            try
            {
                return (TBinding)Convert.ChangeType(value, typeof(TBinding));
            }
            catch
            {
                throw new Exception($"Can't convert binding value '{attributeRef.binding}' to {typeof(TBinding).Name}");
            }
        }

        public abstract void OnDrawDecorator(DecoratorElement child);

        public virtual void OnDrawField(PropertyField field)
        { }

        public virtual void OnDrawMethod(MethodElement builder)
        { }

        public virtual void OnDrawProperty(BindableElement property)
        { }

        internal CustomDrawer CloneWith(InspectorMaidAttribute attribute, UObject target, MemberInfo info, SerializedProperty serializedProperty)
        {
            var cloned = (CustomDrawer)MemberwiseClone();
            cloned.attributeRef = attribute;
            cloned._target = target;
            cloned._info = info;
            cloned._serializedProperty = serializedProperty;
            cloned.decoratorRef = cloned.CreateDecoratorImpl();
            return cloned;
        }

        protected internal abstract DecoratorElement CreateDecoratorImpl();
    }
}
