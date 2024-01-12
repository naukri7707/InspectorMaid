using Naukri.InspectorMaid.Editor.UIElements.Compose;
using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.UIElements
{
    public partial class Divider : VisualElement
    {
        public Divider() : this(null)
        {
        }

        public Divider(string text)
        {
            this.text = text;
            var textElement = new Label(text);

            new ComposerOf(this)
            {
                margin = EdgeInsets.Symmetric(vertical: 5),
                flexDirection = FlexDirection.Row,
                children = string.IsNullOrEmpty(text) switch
                {
                    true => new VisualElement[]
                    {
                        new ComposerOf(new Box())
                        {
                            alignSelf = Align.Center,
                            flexGrow = 0.99F,
                            backgroundColor = DefaultColor,
                            height = 2,
                        }
                    },
                    false => new VisualElement[]
                    {
                        new ComposerOf(new Box())
                        {
                            alignSelf = Align.Center,
                            width = 50,
                            backgroundColor = DefaultColor,
                            height = 2,
                        },
                        new ComposerOf(textElement)
                        {
                            color = DefaultColor,
                            flexGrow = 0.01F,
                            fontSize = 14,
                            unityTextAlign = TextAnchor.MiddleCenter,
                            unityFontStyleAndWeight = FontStyle.Bold,
                        },
                        new ComposerOf(new Box())
                        {
                            alignSelf = Align.Center,
                            flexGrow = 0.99F,
                            backgroundColor = DefaultColor,
                            height = 2,
                        },
                    }
                }
            };
        }

        public string text;
    }

    partial class Divider
    {
        public static StyleColor DefaultColor => new(new Color32(128, 128, 128, 255));
    }
}
