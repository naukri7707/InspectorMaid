using Naukri.InspectorMaid.Editor.Extensions;
using Naukri.InspectorMaid.Editor.UIElements.Compose;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.UIElements
{
    public class Group : VisualElement
    {
        public Group(string text)
        {
            var contentContainer = new VisualElement();

            this.Compose(group =>
            {
                group.children = new VisualElement[]
                {
                    new Divider(text).Compose(ve =>
                    {
                        ve.On<ClickEvent>(evt =>
                        {
                            group.element.Expend = !group.element.Expend;
                        });
                    }),
                    new Row().Compose(row =>
                    {
                        row.margin = EdgeInsets.Only(bottom: 5F);
                        row.children = new[]
                        {
                            new Divider().Compose(vDiv =>
                            {
                                vDiv.position = Position.Absolute;
                                vDiv.flexDirection = FlexDirection.Column;
                                vDiv.height = vDiv.height.value.value + 9F;
                                vDiv.distanceFromBox = EdgeInsets.Only(top: -18F);
                                row.On<GeometryChangedEvent>(evt =>
                                {
                                    vDiv.height = evt.newRect.height + 5F;
                                });
                            }),
                            new Divider().Compose(hDiv =>
                            {
                                hDiv.position = Position.Absolute;
                                hDiv.flexDirection = FlexDirection.Row;
                                hDiv.width = 10F;
                                hDiv.distanceFromBox = EdgeInsets.Only(bottom: -5);
                            }),
                            contentContainer.Compose(ve =>
                            {
                                ve.margin = EdgeInsets.Only(left: 15F);
                                ve.flexGrow = 1F;
                            }),
                        };
                    }),
                };
            });

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
