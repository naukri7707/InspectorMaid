﻿using Naukri.InspectorMaid.Editor.Core;

namespace Naukri.InspectorMaid.Editor
{
    public class DisableIfDrawer : CustomDrawerOf<DisableIfAttribute>
    {
        public override void OnSceneGUI()
        {
            var disable = GetBindingValue<bool>();

            decorator.SetEnabled(!disable);
        }
    }
}