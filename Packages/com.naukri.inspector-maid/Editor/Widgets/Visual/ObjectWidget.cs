namespace Naukri.InspectorMaid.Editor.Widgets.Visual
{

    partial class ClassWidget
    {
        public static ClassWidget Of(IBuildContext context)
        {
            return context.GetAncestorWidget<ClassWidget>();
        }
    }
}
