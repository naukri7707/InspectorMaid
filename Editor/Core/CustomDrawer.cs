using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Naukri.InspectorMaid.Core;
using UnityEditor.UIElements;
using UObject = UnityEngine.Object;

namespace Naukri.InspectorMaid.Editor.Core
{
    public abstract class CustomDrawer
    {
        private MemberInfo _info;

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
        public UObject target => _target;

        internal abstract Type AttributeType { get; }

        protected internal abstract InspectorMaidAttribute attributeRef { get; set; }

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

        public virtual DecoratorElement OnDrawDecorator(DecoratorElement child)
        {
            var name = GetType().Name;
            // if the name end with "Drawer" suffix, remove it.
            if (name.EndsWith("Drawer"))
            {
                name = name[..^6];
            }

            var decorator = new DecoratorElement($"{name} Decorator");
            decorator.Add(child);

            return decorator;
        }

        public virtual void OnDrawField(PropertyField field)
        { }

        public virtual void OnDrawMethod(MethodBuilder builder)
        { }

        public virtual void OnDrawProperty(PropertyBuilder builder)
        { }

        internal CustomDrawer CloneWith(InspectorMaidAttribute attribute, UObject target, MemberInfo info)
        {
            var cloned = (CustomDrawer)MemberwiseClone();
            cloned.attributeRef = attribute;
            cloned._target = target;
            cloned._info = info;
            return cloned;
        }
    }
}
