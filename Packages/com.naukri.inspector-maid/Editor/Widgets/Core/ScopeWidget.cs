﻿using Naukri.InspectorMaid.Editor.Contexts;
using Naukri.InspectorMaid.Editor.Contexts.Core;

namespace Naukri.InspectorMaid.Editor.Widgets.Core
{
    public abstract class ScopeWidget : VisualWidget
    {
        public sealed override VisualContext CreateContext() => new MultiChildVisualContext(this);
    }
}