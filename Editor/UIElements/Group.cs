using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.UIElements.Compose;
using System;
using System.Linq;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.UIElements
{
    public class Group : VisualElement
    {
        public Group(string text)
        {
            var divider = new Divider(text);
            var contentContainer = new VisualElement();
            var verticalLine = new Box();
            var endElementTail = new Box();

            OnExpendChanged += expend =>
            {
                contentContainer.SetDisplay(expend);
                verticalLine.SetDisplay(expend);
                endElementTail.SetDisplay(expend);
            };

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
                            Callback.BubbleUp<GeometryChangedEvent>(evt =>
                            {
                                var height = evt.newRect.height;
                                var marginBottom = divider.style.marginBottom.value.value;
                                verticalLine.style.marginTop = -(height / 2 + marginBottom);
                            }),
                        }
                    },
                    new ComposerOf(new Row())
                    {
                        children = new VisualElement[]
                        {
                            new ComposerOf(verticalLine)
                            {
                                backgroundColor = Divider.DefaultColor,
                                flexDirection = FlexDirection.Column,
                                display = DisplayStyle.None,
                            },
                            new ComposerOf(endElementTail)
                            {
                                position = Position.Absolute,
                                backgroundColor = Divider.DefaultColor,
                                flexDirection = FlexDirection.Row,
                                width = 10F,
                                display = DisplayStyle.None,
                            },
                            new ComposerOf(contentContainer)
                            {
                                callbacks = new[]
                                {
                                    Callback.BubbleUp<GeometryChangedEvent>(evt =>
                                    {
                                        var lastElement = contentContainer.Children().Last();
                                        var height = lastElement.worldBound.height;
                                        var marginBottom = lastElement.style.marginBottom.value.value;
                                        var endElementTailBottom = height / 2 + marginBottom;
                                        endElementTail.style.bottom = endElementTailBottom;
                                        endElementTail.style.height = 2;
                                        verticalLine.style.marginBottom = endElementTailBottom;
                                    })
                                },
                                margin = EdgeInsets.Only(left: 18F),
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
                expend = value;
                OnExpendChanged?.Invoke(value);
            }
        }

        public event Action<bool> OnExpendChanged;
    }
}
