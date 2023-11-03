namespace Naukri.InspectorMaid.Editor.Drawers
{
    public class DisableIfScopeDrawer : WidgetDrawerOf<DisableIfScopeAttribute>
    {
        public override void OnSceneGUI(IWidget widget)
        {
            var disable = GetBindingValue<bool>();
            widget.SetEnabled(!disable);
        }
    }
}
