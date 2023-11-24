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
            var column = new Column().Compose(ve =>
            {
                ve.padding = EdgeInsets.Only(left: 5, right: 8);
                ve.children = new[]
                {
                    // title container
                    new Row() { name = "titleContainer" }.Compose(ve =>
                    {
                        ve.children = new[]
                        {
                            // title
                            new Label(titleText).Compose(ve =>
                            {
                                ve.margin = EdgeInsets.Symmetric(vertical: 2, horizontal: 4);
                                ve.padding = EdgeInsets.Only(top: 0, right: 2, bottom: 2, left: 2);
                                ve.fontSize = 19;
                                ve.unityFontStyleAndWeight = FontStyle.Bold;
                            })
                        };
                    }),
                    context,
                };
            });

            Add(column);
        }
    }
}
