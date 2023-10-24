using Naukri.InspectorMaid.Style;
using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples
{
    public class FlexDirectionSample : MonoBehaviour
    {
        [FlexDirection(FlexDirection.Column), HelpBox("column", HelpBoxMessageType.Info)]
        public string column;

        [FlexDirection(FlexDirection.ColumnReverse), HelpBox("column reverse", HelpBoxMessageType.Info)]
        public string columnReverse;

        [FlexDirection(FlexDirection.Row), HelpBox("row", HelpBoxMessageType.Info)]
        public string row;

        [FlexDirection(FlexDirection.RowReverse), HelpBox("row reverse", HelpBoxMessageType.Info)]
        public string rowReverse;
    }
}
