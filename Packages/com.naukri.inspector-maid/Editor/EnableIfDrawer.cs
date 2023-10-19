using Naukri.InspectorMaid.Editor.Core;

namespace Naukri.InspectorMaid.Editor
{
    public class EnableIfDrawer : CustomDrawerOf<EnableIfAttribute>
    {
        public override void OnSceneGUI()
        {
            var enable = GetBindingValue<bool>();

            decorator.SetEnabled(enable);
        }
    }
}
