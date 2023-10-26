using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.UIElements;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using IBindable = Naukri.InspectorMaid.Core.IBindable;
using UObject = UnityEngine.Object;

namespace Naukri.InspectorMaid.Editor.Core
{
    public abstract class CustomDrawer
    {
        private DrawerTarget _drawerTarget;

        private MemberInfo _info;

        private SerializedProperty _serializedProperty;

        private UObject _target;

        [SuppressMessage("Style", "IDE1006")]
        public DrawerTarget drawerTarget => _drawerTarget;

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

        public bool IsBinding => attributeRef is IBindable bindable && bindable.binding != null;

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
        protected internal abstract DrawerAttribute attributeRef { get; set; }

        [SuppressMessage("Style", "IDE1006")]
        protected internal abstract DecoratorElement decoratorRef { get; set; }

        public Action CreateBindingMethodAction()
        {
            var type = target.GetType();

            if (attributeRef is IBindable bindable)
            {
                var binding = bindable.binding;

                if (type.GetMethod(binding, Utility.AllAccessFlags) is MethodInfo method)
                {
                    var args = bindable.args;
                    return () => method.Invoke(target, args);
                }
                else
                {
                    throw new Exception($"Can't find binding path: {binding}");
                }
            }
            else
            {
                throw new Exception($"{attributeRef.GetType()} is not bindable.");
            }
        }

        public object GetBindingValue()
        {
            var type = target.GetType();

            if (attributeRef is IBindable bindable)
            {
                var binding = bindable.binding;

                if (type.GetField(binding, Utility.AllAccessFlags) is FieldInfo field)
                {
                    return field.GetValue(target);
                }
                else if (type.GetProperty(binding, Utility.AllAccessFlags) is PropertyInfo property)
                {
                    return property.GetValue(target);
                }
                else if (type.GetMethod(binding, Utility.AllAccessFlags) is MethodInfo method)
                {
                    var args = bindable.args;
                    return method.Invoke(target, args);
                }
                else
                {
                    throw new Exception($"Can't find binding path: {binding}");
                }
            }
            else
            {
                throw new Exception($"{attributeRef.GetType()} is not bindable.");
            }
        }

        public T GetBindingValue<T>()
        {
            var value = GetBindingValue();
            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch
            {
                throw new Exception($"Can't convert {attributeRef.GetType()}'s binding value to {typeof(T).Name}");
            }
        }

        public virtual void OnDrawField(PropertyField fieldElement)
        { }

        public virtual void OnDrawMethod(MethodElement methodElement)
        { }

        public virtual void OnDrawProperty(PropertyElement propertyElement)
        { }

        internal CustomDrawer CloneWith(DrawerTarget drawerTarget, DrawerAttribute attribute, UObject target, MemberInfo info, SerializedProperty serializedProperty)
        {
            var cloned = (CustomDrawer)MemberwiseClone();
            cloned._drawerTarget = drawerTarget;
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
