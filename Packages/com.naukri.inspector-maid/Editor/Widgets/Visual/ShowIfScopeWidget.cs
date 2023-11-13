﻿using Naukri.InspectorMaid.Editor.Widgets.Core;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public class ShowIfScopeWidget : IfScopeWidgetOf<ShowIfScopeAttribute>
    {
        protected override void OnUpdateElement(VisualElement visualElement, bool condition)
        {
            if (condition)
            {
                visualElement.style.display = DisplayStyle.Flex;
                visualElement.style.visibility = Visibility.Visible;
            }
            else
            {
                visualElement.style.display = DisplayStyle.None;
                visualElement.style.visibility = Visibility.Hidden;
            }
        }
    }
}
