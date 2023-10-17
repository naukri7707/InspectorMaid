using Naukri.InspectorMaid.Editor.Core;
using UnityEditor.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    public class ReadOnlyDrawer : CustomDrawerOf<ReadOnlyAttribute>
    {
        public override void OnDrawField(PropertyField field)
        {
            field.SetEnabled(false);
        }

        public override void OnDrawMethod(MethodBuilder builder)
        {
            builder.args.Enable = false;
        }

        public override void OnDrawProperty(PropertyBuilder builder)
        {
            builder.args.Enable = false;
        }
    }
}
