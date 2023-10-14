using Naukri.InspectorMaid.Core;
using System;
using UnityEditor.UIElements;

namespace Naukri.InspectorMaid.Editor.Core
{
    public abstract class CustomDrawerOf<T> : CustomDrawer where T : InspectorMaidAttribute
    {
        internal override Type AttributeType => typeof(T);

        public virtual void OnDrawField(PropertyField field, T attribute, FieldDrawerArgs args) { }

        public virtual void OnDrawMethod(MethodBuilder field, T attribute, MethodDrawerArgs args) { }

        public virtual void OnDrawProperty(PropertyBuilder builder, T attribute, PropertyDrawerArgs args) { }

        internal protected sealed override void OnDrawField(PropertyField field, object attribute, FieldDrawerArgs args)
        {
            OnDrawField(field, (T)attribute, args);
        }

        internal protected sealed override void OnDrawMethod(MethodBuilder field, object attribute, MethodDrawerArgs args)
        {
            OnDrawMethod(field, (T)attribute, args);
        }

        internal protected sealed override void OnDrawProperty(PropertyBuilder builder, object attribute, PropertyDrawerArgs args)
        {
            OnDrawProperty(builder, (T)attribute, args);
        }
    }
}
