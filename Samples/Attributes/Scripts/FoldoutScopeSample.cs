using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Samples.Attributes
{
    public class FoldoutScopeSample : MonoBehaviour
    {
        [HelpBox("[FoldoutScope] allows you to create a scope that can be toggled visible by clicking the header.", HelpBoxMessageType.Info)]
        [ContainerScope, Style(margin: "10 0", padding: "5", backgroundColor: "#202020")]
        // Sample 1
        [Target]
        [FoldoutScope("Fold out")]
        [HelpBox("Fold Item 1", HelpBoxMessageType.Info)]
        [HelpBox("Fold Item 2", HelpBoxMessageType.Warning)]
        [EndScope]
        [HelpBox("Unfold Item 1", HelpBoxMessageType.Error)]
        public int Sample1;
    }
}
