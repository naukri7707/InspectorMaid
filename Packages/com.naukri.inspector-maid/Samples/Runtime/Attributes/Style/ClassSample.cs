using Naukri.InspectorMaid.Style;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples
{
    public class ClassSample : MonoBehaviour
    {
        [FlexDirection(FlexDirection.Column), HelpBox("You must create stylesheet (.uss file) and add it to inject list first.", HelpBoxMessageType.Warning)]
        [FlexDirection(FlexDirection.Column), HelpBox("You can create stylesheet by right click at Project inspector and fllow below path : \r\n'Create/UI Toolkit/Style Sheet'", HelpBoxMessageType.Info)]
        [FlexDirection(FlexDirection.Column), HelpBox("You can inject stylesheet at below path: \r\n'Project Setting/Inspector Maid/Inject List'", HelpBoxMessageType.Info)]
        [FlexDirection(FlexDirection.Column), HelpBox("For this example, you can inject the 'SampleStyleSheet.uss' which provided by Sample;\r\n the field will be hidden if it work correctly.", HelpBoxMessageType.Info)]
        [Class("hide")]
        public int myField;
    }
}
