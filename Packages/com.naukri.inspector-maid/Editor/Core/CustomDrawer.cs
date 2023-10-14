using System;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Core
{
    public abstract class CustomDrawer
    {
        internal abstract Type AttributeType { get; }

        internal virtual VisualElement OnDrawDecorator(VisualElement child, object attribute, DrawerArgs args) => null;

        internal protected abstract void OnDrawField(PropertyField field, object attribute, FieldDrawerArgs args);

        internal protected abstract void OnDrawMethod(MethodBuilder field, object attribute, MethodDrawerArgs args);

        internal protected abstract void OnDrawProperty(PropertyBuilder builder, object attribute, PropertyDrawerArgs args);
    }
}
