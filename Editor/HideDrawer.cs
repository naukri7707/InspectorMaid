using Naukri.InspectorMaid.Editor.Core;

namespace Naukri.InspectorMaid.Editor
{
    public class HideDrawer : CustomDrawerOf<HideAttribute>
    {
        public override DecoratorElement OnDrawDecorator(DecoratorElement child)
        {
            var decorator = new DecoratorElement("Hide Decorator")
            {
                visible = false
            };

            decorator.style.height = 0;
            decorator.style.width = 0;

            decorator.Add(child);

            return decorator;
        }
    }
}
