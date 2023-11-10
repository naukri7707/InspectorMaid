using Naukri.InspectorMaid.Editor.UIElements.Compose;
using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.UIElements
{
    public sealed class ProjectSettingPage : VisualElement
    {
        public ProjectSettingPage(string titleText, VisualElement context)
        {
            // page container
            var column = new Column().Compose(c =>
            {
                c.padding = EdgeInsets.Only(left: 5, right: 8);
                c.children = new[]
                {
                    // title container
                    new VisualElement() { name = "titleContainer" }.Compose(c =>
                    {
                        c.children = new[]
                        {
                            // title
                            new Label(titleText).Compose(c =>
                            {
                                c.margin = EdgeInsets.Symmetric(vertical: 2, horizontal: 4);
                                c.padding = EdgeInsets.Only(top: 0, right: 2, bottom: 2, left: 2);
                                c.fontSize = 19;
                                c.unityFontStyleAndWeight = FontStyle.Bold;
                            }),
                            context
                        };
                    }),
                };
            });

            Add(column);
        }
    }
}
