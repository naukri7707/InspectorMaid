﻿using Naukri.InspectorMaid.Editor.UIElements.Compose;
using UnityEngine.UIElements;
using Column = Naukri.InspectorMaid.Editor.UIElements.Column;

namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{
    public class ColumnScopeWidget : VisualWidgetOf<ColumnScopeAttribute>
    {
        public override VisualElement Build(IBuildContext context)
        {
            var column = new ComposerOf(new Column())
            {
                children = context.BuildChildren(),
            };

            return column;
        }
    }
}
