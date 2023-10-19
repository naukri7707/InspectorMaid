using Naukri.InspectorMaid.Editor.Core;

namespace Naukri.InspectorMaid.Editor
{
    public class ReadOnlyDrawer : CustomDrawerOf<ReadOnlyAttribute>
    {
        public override void OnStart()
        {
            decorator.SetEnabled(false);
        }
    }
}
