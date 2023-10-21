namespace Naukri.InspectorMaid.Core
{
    public class InspectorMaidBindableAttribute : InspectorMaidAttribute, IBindable
    {
        public object[] bindingArgs { get; set; }

        public string bindingPath { get; set; }
    }
}
