namespace Naukri.InspectorMaid.Core
{
    public abstract class BindableDrawerAttribute : DrawerAttribute, IBindable
    {
        public BindableDrawerAttribute(string binding = null, params object[] args)
        {
            this.binding = binding;
            this.args = args;
        }

        public string binding { get; }

        public object[] args { get; }
    }
}
