using System.Reflection;
using UObject = UnityEngine.Object;

namespace Naukri.InspectorMaid.Editor.Core
{
    public class MethodDrawerArgs : DrawerArgs
    {
        public MethodDrawerArgs(UObject target, MethodInfo methodInfo)
        {
            this.target = target;
            this.methodInfo = methodInfo;
        }

        public readonly MethodInfo methodInfo;

        public readonly UObject target;
    }
}
