using Naukri.InspectorMaid.Core;
using System;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Core
{
    public abstract class CustomDrawerOf<T> : CustomDrawer where T : InspectorMaidAttribute
    {
        internal override Type AttributeType => typeof(T);

        public virtual VisualElement OnDrawDecorator(VisualElement child, T attribute, DrawerArgs args) => null;

        public virtual void OnDrawField(PropertyField field, T attribute, FieldDrawerArgs args) { }

        public virtual void OnDrawMethod(MethodBuilder builder, T attribute, MethodDrawerArgs args) { }

        public virtual void OnDrawProperty(PropertyBuilder builder, T attribute, PropertyDrawerArgs args) { }

        internal override VisualElement OnDrawDecorator(VisualElement child, object attribute, DrawerArgs args)
        {
            return OnDrawDecorator(child, (T)attribute, args);
        }

        internal protected sealed override void OnDrawField(PropertyField field, object attribute, FieldDrawerArgs args)
        {
            OnDrawField(field, (T)attribute, args);
        }

        internal protected sealed override void OnDrawMethod(MethodBuilder builder, object attribute, MethodDrawerArgs args)
        {
            OnDrawMethod(builder, (T)attribute, args);
        }

        internal protected sealed override void OnDrawProperty(PropertyBuilder builder, object attribute, PropertyDrawerArgs args)
        {
            OnDrawProperty(builder, (T)attribute, args);
        }
    }
}
