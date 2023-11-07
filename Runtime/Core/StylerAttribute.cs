namespace Naukri.InspectorMaid.Core
{
    public abstract class StylerAttribute : InspectorMaidAttribute
    {
        protected StylerAttribute(string classList)
        {
            this.classList = classList is null ? new string[0] : classList.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
        }

        public readonly string[] classList;
    }
}
