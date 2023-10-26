using Naukri.InspectorMaid.Editor.Core;
using Naukri.InspectorMaid.Editor.UIElements;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    public class HideDrawer : CustomDrawerOf<HideAttribute>
    {
        public override void OnDrawField(PropertyField fieldElement)
        {
            fieldElement.style.display = DisplayStyle.None;
            fieldElement.style.visibility = Visibility.Hidden;
        }

        public override void OnDrawProperty(PropertyElement propertyElement)
        {
            propertyElement.style.display = DisplayStyle.None;
            propertyElement.style.visibility = Visibility.Hidden;
        }

        public override void OnDrawMethod(MethodElement methodElement)
        {
            methodElement.style.display = DisplayStyle.None;
            methodElement.style.visibility = Visibility.Hidden;
        }
    }
}
