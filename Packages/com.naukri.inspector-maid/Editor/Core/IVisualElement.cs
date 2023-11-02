using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Core
{
    public interface IVisualElement : IEventHandler
    {
        [SuppressMessage("Style", "IDE1006")]
        public IStyle style { get; }

        [SuppressMessage("Style", "IDE1006")]
        public VisualElement parent { get; }

        public void SetEnabled(bool value);

        public void Add(VisualElement child);

        public void Insert(int index, VisualElement child);

        public void Remove(VisualElement child);

        public void RemoveAt(int index);

        public void Clear();

        public VisualElement ElementAt(int index);

        public int IndexOf(VisualElement element);

        public IEnumerable<VisualElement> Children();

        public void Sort(Comparison<VisualElement> comp);

        public void BringToFront();

        public void SendToBack();

        public void PlaceBehind(VisualElement sibling);

        public void PlaceInFront(VisualElement sibling);

        public T GetFirstOfType<T>() where T : class;

        public T GetFirstAncestorOfType<T>() where T : class;

        public bool Contains(VisualElement child);
    }
}
