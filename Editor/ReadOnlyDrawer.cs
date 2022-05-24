using Naukri.InspectorMaid.Editor.Core;
using Naukri.InspectorMaid.Editor.UIElements;
using UnityEditor.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    public class ReadOnlyDrawer : CustomDrawerOf<ReadOnlyAttribute>
    {
        public override void OnDrawField(PropertyField fieldElement)
        {
            fieldElement.SetEnabled(false);
        }

        public override void OnDrawProperty(PropertyElement propertyElement)
        {
            propertyElement.SetEnabled(false);
        }

        public override void OnDrawMethod(MethodElement methodElement)
        {
            methodElement.SetEnabled(false);
        }
    }
}
