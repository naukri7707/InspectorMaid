using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.UIElements.Compose;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.UIElements
{
    public class Group : VisualElement
    {
        public Group(string text)
        {
            var divider = new Divider(text);
            var contentContainer = new VisualElement();

            new ComposerOf(this)
            {
                children = new VisualElement[]
                {
                    new ComposerOf(divider)
                    {
                        callbacks = new[]
                        {
                            Callback.BubbleUp<ClickEvent>(evt =>
                            {
                                Expend = !Expend;
                            }),
                        }
                    },
                    new ComposerOf(new Row())
                    {
                        margin = EdgeInsets.Only(bottom: 5F),
                        children = new VisualElement[]
                        {
                            new ComposerOf(new Box())
                            {
                                backgroundColor = Divider.LineDefaultColor,
                                flexDirection = FlexDirection.Column,
                                distanceFromBox = EdgeInsets.Only(top: -18F),
                                margin = EdgeInsets.Only(top: 4),
                            },
                            new ComposerOf(new Box())
                            {
                                position = Position.Absolute,
                                backgroundColor = Divider.LineDefaultColor,
                                flexDirection = FlexDirection.Row,
                                width = 10F,
                                distanceFromBox = EdgeInsets.Only(bottom: 18),
                            },
                            new ComposerOf(contentContainer)
                            {
                                margin = EdgeInsets.Only(left: 15F),
                                flexGrow = 1F,
                            },
                        }
                    },
                }
            };

            // set contentContainer after adding decorator element,
            // otherwise it will throw an exception.
            _contentContainer = contentContainer;
        }

        private readonly VisualElement _contentContainer;

        private bool expend;

        public override VisualElement contentContainer => _contentContainer ?? this;

        public bool Expend
        {
            get => expend;
            set
            {
                _contentContainer.SetDisplay(value);
                expend = value;
            }
        }
    }
}
