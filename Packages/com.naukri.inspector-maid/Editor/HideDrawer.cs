﻿using Naukri.InspectorMaid.Editor.Core;

namespace Naukri.InspectorMaid.Editor
{
    public class HideDrawer : CustomDrawerOf<HideAttribute>
    {
        public override void OnStart()
        {
            decorator.visible = false;
            decorator.style.height = 0;
            decorator.style.width = 0;
        }
    }
}
