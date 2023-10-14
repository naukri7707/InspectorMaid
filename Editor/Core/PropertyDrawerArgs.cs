using System.Reflection;
using UObject = UnityEngine.Object;

namespace Naukri.InspectorMaid.Editor.Core
{
    public class PropertyDrawerArgs : DrawerArgs
    {
        public PropertyDrawerArgs(UObject target, PropertyInfo propertyInfo)
        {
            this.target = target;
            this.propertyInfo = propertyInfo;
        }

        public readonly PropertyInfo propertyInfo;

        public readonly UObject target;
    }
}
