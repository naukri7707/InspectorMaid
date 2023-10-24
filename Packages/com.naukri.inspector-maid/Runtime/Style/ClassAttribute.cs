using Naukri.InspectorMaid.Core;

namespace Naukri.InspectorMaid.Style
{
    public sealed class ClassAttribute : StylerAttribute
    {
        public ClassAttribute(params string[] classNames)
        {
            this.classNames = classNames;
        }

        public readonly string[] classNames;
    }
}
