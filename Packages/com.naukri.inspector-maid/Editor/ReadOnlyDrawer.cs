using Naukri.InspectorMaid.Editor.Core;
using UnityEditor.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    public class ReadOnlyDrawer : CustomDrawerOf<ReadOnlyAttribute>
    {
        public override void OnDrawField(PropertyField field, ReadOnlyAttribute attribute, FieldDrawerArgs args)
        {
            field.SetEnabled(false);
        }

        public override void OnDrawMethod(MethodBuilder builder, ReadOnlyAttribute attribute, MethodDrawerArgs args)
        {
            builder.args.Enable = false;
        }

        public override void OnDrawProperty(PropertyBuilder builder, ReadOnlyAttribute attribute, PropertyDrawerArgs args)
        {
            builder.args.Enable = false;
        }
    }
}
