using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Widgets.Receivers
{
    internal interface IParentBuiltReceiver : IReceiver
    {
        void OnParentBuilt(IBuildContext context, VisualElement parentElement);
    }
}
