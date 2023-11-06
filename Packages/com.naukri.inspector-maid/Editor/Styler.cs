using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.Core
{
    public abstract class Styler : IModelProvider
    {
        object IModelProvider.Model { get; }

        public abstract void OnStyling(IStyle style);
    }
}
