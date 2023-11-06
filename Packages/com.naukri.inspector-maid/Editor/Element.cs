using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Core;
using Naukri.InspectorMaid.Editor.Receivers;
using System;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    public sealed class Element : IBuildContext
    {
        internal Element(Widget widget, Element parent = null)
        {
            this.widget = widget;
            Parent = parent;
        }

        public Widget widget;

        private readonly List<Styler> _stylers = new();

        private readonly List<Element> _children = new();

        private Element _parent;

        private VisualElement renderedElement;

        public Element Parent
        {
            get => _parent;
            set
            {
                if (value != _parent)
                {
                    var previousParent = _parent;
                    _parent = value;

                    previousParent?._children.Remove(this);
                    _parent?._children.Add(this);
                }
            }
        }

        public Widget Widget => widget;

        public void SendEvent<TReceiver>(Action<TReceiver> callback) where TReceiver : IEventReceiver
        {
            if (Widget is TReceiver eventReceiver)
            {
                callback(eventReceiver);
            }
        }

        public VisualElement Build()
        {
            renderedElement = widget.Build(this);

            foreach (var styler in _stylers)
            {
                if (styler is IModelProvider modelProvider)
                {
                    if (modelProvider.Model is IClassableProvider useClassable)
                    {
                        foreach (var className in useClassable.classList)
                        {
                            renderedElement.AddToClassList(className);
                        }
                    }
                }

                styler.OnStyling(renderedElement.style);
            }

            return renderedElement;
        }

        public T GetAncestorWidget<T>() where T : Widget
        {
            T res = null;

            VisitAncestorElements(e =>
            {
                if (e.Widget is T tWidget)
                {
                    res = tWidget;
                    return true;
                }

                return false;
            });

            return res;
        }

        public Element GetElementOfAncestorWidget<T>() where T : Widget
        {
            Element res = null;

            VisitAncestorElements(e =>
            {
                if (e.Widget is T)
                {
                    res = e;
                    return true;
                }

                return false;
            });

            return res;
        }

        public void VisitAncestorElements(Predicate<Element> visitor)
        {
            var current = this;
            while (current != null)
            {
                if (visitor.Invoke(current))
                {
                    break;
                }
                current = current.Parent;
            }
        }

        public void VisitChildElements(Action<Element> visitor)
        {
            // copy children to avoid concurrent modification
            var copiedChildren = _children.ToArray();
            foreach (var child in copiedChildren)
            {
                visitor(child);
            }
        }

        internal void AddStyler(Styler styler)
        {
            if (!_stylers.Contains(styler))
            {
                _stylers.Add(styler);
            }
        }
    }
}
