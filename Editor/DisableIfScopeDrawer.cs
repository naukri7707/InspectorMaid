using Naukri.InspectorMaid.Editor.Core;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    public class DisableIfScopeDrawer : CustomDrawerOf<DisableIfScopeAttribute>
    {
        public HelpBox HelpBox { get; set; }

        public override void OnSceneGUI()
        {
            var disable = GetBindingValue<bool>();
            decorator.SetEnabled(!disable);
        }
    }
}
