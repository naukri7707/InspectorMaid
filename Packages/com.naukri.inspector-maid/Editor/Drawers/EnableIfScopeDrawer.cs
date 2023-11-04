namespace Naukri.InspectorMaid.Editor.Drawers
{
    public class EnableIfScopeDrawer : WidgetDrawerOf<EnableIfScopeAttribute>
    {
        public override void OnSceneGUI(IWidget widget)
        {
            var enable = widget.GetBindingValue<bool>();

            widget.SetEnabled(enable);
        }
    }
}
