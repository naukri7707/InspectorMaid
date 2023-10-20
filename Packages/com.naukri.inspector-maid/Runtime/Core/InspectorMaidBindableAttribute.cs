namespace Naukri.InspectorMaid.Core
{
    public class InspectorMaidBindableAttribute : InspectorMaidAttribute, IBindable
    {
        public object[] args { get; set; }

        public string binding { get; set; }
    }
}
