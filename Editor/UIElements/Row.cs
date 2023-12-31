﻿using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.UIElements
{
    public sealed class Row : VisualElement
    {
        public Row() : this(false)
        {
        }

        public Row(bool reverse)
        {
            style.flexDirection = reverse switch
            {
                true => FlexDirection.RowReverse,
                false => FlexDirection.Row
            };
        }
    }
}
