namespace Naukri.InspectorMaid.Editor.UIElements.Compose
{
    public readonly struct ClassList
    {
        private ClassList(params string[] classNames)
        {
            this.classNames = classNames;
        }

        public readonly string[] classNames;

        public static ClassList Add(params string[] classNames)
        {
            return new ClassList(classNames);
        }
    }
}
