using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Helpers;
using Naukri.InspectorMaid.Editor.UIElements;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using UnityEditor;
using IBindable = Naukri.InspectorMaid.Core.IBindable;
using UObject = UnityEngine.Object;

namespace Naukri.InspectorMaid.Editor.Core
{
    public abstract class WidgetDrawer : IWidgetBuilder
    {
        internal WidgetLifePhase lifePhase = WidgetLifePhase.Created;

        private Widget _widget;

        private WidgetTreeDrawer _widgetTreeDrawer;

        [SuppressMessage("Style", "IDE1006")]
        public abstract UObject target { get; }

        [SuppressMessage("Style", "IDE1006")]
        public abstract SerializedProperty serializedProperty { get; }

        [SuppressMessage("Style", "IDE1006")]
        public abstract MemberInfo memberInfo { get; }

        [SuppressMessage("Style", "IDE1006")]
        public FieldInfo fieldInfo
        {
            get
            {
                // try to return member info and cast to field info otherwise throw exception
                if (memberInfo is FieldInfo fieldInfo)
                {
                    return fieldInfo;
                }
                else
                {
                    throw new Exception($"Can not get fieldInfo, because the member '{memberInfo.Name}' is not a field.");
                }
            }
        }

        [SuppressMessage("Style", "IDE1006")]
        public PropertyInfo propertyInfo
        {
            get
            {
                // try to return member info and cast to field info otherwise throw exception
                if (memberInfo is PropertyInfo propertyInfo)
                {
                    return propertyInfo;
                }
                else
                {
                    throw new Exception($"Can not get propertyInfo, because the member '{memberInfo.Name}' is not a property.");
                }
            }
        }

        [SuppressMessage("Style", "IDE1006")]
        public MethodInfo methodInfo
        {
            get
            {
                // try to return member info and cast to field info otherwise throw exception
                if (memberInfo is MethodInfo methodInfo)
                {
                    return methodInfo;
                }
                else
                {
                    throw new Exception($"Can not get methodInfo, because the member '{memberInfo.Name}' is not a method.");
                }
            }
        }

        public bool IsBinding => attributeRef is IBindable bindable && bindable.binding != null;

        internal abstract Type AttributeType { get; }

        [SuppressMessage("Style", "IDE1006")]
        internal abstract DrawerAttribute attributeRef { get; set; }

        internal Widget Widget => _widget;

        internal WidgetTreeDrawer WidgetTreeDrawer => _widgetTreeDrawer;

        public virtual void OnStart(IWidget widget) { }

        public virtual void OnSceneGUI(IWidget widget) { }

        public virtual void OnDestroy(IWidget widget) { }

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
                var bindingPath = bindable.binding;

                if (bindingPath == "this")
                {
                    return target;
                }
                else if (type.GetField(bindingPath, Utility.AllAccessFlags) is FieldInfo field)
                {
                    return field.GetValue(target);
                }
                else if (type.GetProperty(bindingPath, Utility.AllAccessFlags) is PropertyInfo property)
                {
                    return property.GetValue(target);
                }
                else if (type.GetMethod(bindingPath, Utility.AllAccessFlags) is MethodInfo method)
                {
                    var args = bindable.args;
                    return method.Invoke(target, args);
                }
                else
                {
                    throw new Exception($"Can't find binding path: {bindingPath}");
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

        internal void SetWidget(Widget widget, WidgetTreeDrawer widgetTreeDrawer)
        {
            _widget = widget;
            this._widgetTreeDrawer = widgetTreeDrawer;
        }

        internal void OnScenceGUIImpl()
        {
            if (lifePhase == WidgetLifePhase.Attached)
            {
                OnStart(Widget);
                lifePhase = WidgetLifePhase.Actived;
            }
            OnSceneGUI(Widget);
        }

        internal void OnDestroyImpl()
        {
            OnDestroy(Widget);
            lifePhase = WidgetLifePhase.Destroyed;
        }

        internal abstract Widget CreateWidget();

        private WidgetDrawer CloneWith(DrawerAttribute attribute, WidgetTreeDrawer widgetTreeDrawer)
        {
            var cloned = (WidgetDrawer)MemberwiseClone();
            cloned.attributeRef = attribute;
            cloned._widgetTreeDrawer = widgetTreeDrawer;
            cloned._widget = cloned.CreateWidget();
            cloned.lifePhase = WidgetLifePhase.Created;
            return cloned;
        }

        internal static class Templates
        {
            private static Dictionary<Type, WidgetDrawer> _templates;

            internal static WidgetDrawer Create(DrawerAttribute attribute, WidgetTreeDrawer widgetTreeDrawer)
            {
                var template = GetTemplate(attribute);
                var instance = template.CloneWith(attribute, widgetTreeDrawer);
                return instance;
            }

            private static WidgetDrawer GetTemplate(DrawerAttribute attribute)
            {
                if (_templates == null)
                {
                    _templates = new Dictionary<Type, WidgetDrawer>();
                    var drawerTypes = TypeCache
                        .GetTypesDerivedFrom(typeof(WidgetDrawerOf<>))
                        .Where(it => !it.IsAbstract).ToList();
                    foreach (var type in drawerTypes)
                    {
                        var inst = (WidgetDrawer)Activator.CreateInstance(type);
                        _templates[inst.AttributeType] = inst;
                    }
                }
                var attributeType = attribute.GetType();
                return _templates[attributeType];
            }
        }
    }
}
