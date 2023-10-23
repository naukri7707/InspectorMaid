namespace Naukri.InspectorMaid.Core
{
    public abstract class BindableDrawerAttribute : DrawerAttribute, IBindable
    {
        public BindableDrawerAttribute(string binding = null, params object[] args)
        {
            this.binding = binding;
            this.args = args;
        }

        public readonly string binding;

        public readonly object[] args;

        string IBindable.binding => binding;

        object[] IBindable.args => args;
    }
}
