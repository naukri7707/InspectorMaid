using Naukri.InspectorMaid.Editor.UIElements.Compose;
using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.UIElements
{
    public sealed class ProjectSettingPage : VisualElement
    {
        public ProjectSettingPage(string titleText, VisualElement context)
        {
            new ComposerOf(this)
            {
                children = new VisualElement[]
                {
                    new ComposerOf(new Column())
                    {
                        padding = EdgeInsets.Only(left: 5, right: 8),
                        children = new VisualElement[]
                        {
                            // title container
                            new ComposerOf(new Row())
                            {
                                name = "titleContainer",
                                children = new VisualElement[]
                                {
                                    // title
                                    new ComposerOf(new Label(titleText))
                                    {
                                        margin = EdgeInsets.Symmetric(vertical: 2, horizontal: 4),
                                        padding = EdgeInsets.Only(top: 0, right: 2, bottom: 2, left: 2),
                                        fontSize = 19,
                                        unityFontStyleAndWeight = FontStyle.Bold,
                                    }
                                }
                            },
                            new ComposerOf(context),
                        },
                    }
                }
            };
        }
    }
}
