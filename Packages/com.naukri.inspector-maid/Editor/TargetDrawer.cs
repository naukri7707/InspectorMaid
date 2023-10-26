using Naukri.InspectorMaid.Editor.Core;
using Naukri.InspectorMaid.Editor.UIElements;
using UnityEditor.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    public class TargetDrawer : CustomDrawerOf<TargetAttribute>
    {
        public override void OnDrawField(PropertyField fieldElement)
        {
            decorator.Add(fieldElement);
        }

        public override void OnDrawProperty(PropertyElement propertyElement)
        {
            decorator.Add(propertyElement);
        }

        public override void OnDrawMethod(MethodElement methodElement)
        {
            decorator.Add(methodElement);
        }
    }
}
