using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Drawers
{
    public class ButtonDrawer : WidgetDrawerOf<ButtonAttribute>
    {
        public override void OnStart(IWidget widget)
        {
            // set button
            var action = CreateBindingMethodAction();
            var button = new Button(action)
            {
                text = attribute.text
            };

            button.clicked += widget.Repaint;

            widget.Add(button);
        }
    }
}
