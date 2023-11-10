﻿using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.WidgetAttributes
{
    public class TargetSample : AttributeSampleBehaviour
    {
        [HelpBox(@"
[Target] is a special attribute used to mark the location where the field, property or method widget should be drawn.
This is particularly useful when defining the target location or setting the target style.
", HelpBoxMessageType.Info)]
        [CardScope(color: kSectionBGColor)]
        // Sample 1
        [HelpBox("'Helpbox' is currently positioned above 'Target'.")]
        public int withoutTarget = 0;

        [CardScope(color: kSectionBGColor)]
        // Sample 2
        [Target]
        [HelpBox("Due to the declaration of [Target] before [Helpbox], now the 'Helpbox' is positioned below 'Target'")]
        public int withTarget = 0;
    }
}