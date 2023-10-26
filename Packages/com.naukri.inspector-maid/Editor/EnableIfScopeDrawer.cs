using Naukri.InspectorMaid.Editor.Core;

namespace Naukri.InspectorMaid.Editor
{
    public class EnableIfScopeDrawer : CustomDrawerOf<EnableIfScopeAttribute>
    {
        public override void OnSceneGUI()
        {
            var enable = GetBindingValue<bool>();

            decorator.SetEnabled(enable);
        }
    }
}
