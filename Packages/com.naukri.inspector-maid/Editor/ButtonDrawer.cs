using Naukri.InspectorMaid.Editor.Core;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    public class ButtonDrawer : CustomDrawerOf<ButtonAttribute>
    {
        public override void OnStart()
        {
            // set button
            var action = CreateBindingMethodAction();
            var button = new Button(action)
            {
                text = attribute.text
            };

            button.clicked += decorator.Repaint;

            decorator.Add(button);
        }
    }
}
