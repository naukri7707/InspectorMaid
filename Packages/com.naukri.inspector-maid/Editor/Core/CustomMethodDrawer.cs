using Naukri.InspectorMaid.Core;
using System.Linq;
using System.Reflection;
using UnityEngine.UIElements;
using UObject = UnityEngine.Object;

namespace Naukri.InspectorMaid.Editor.Core
{
    internal class CustomMethodDrawer
    {
        internal CustomMethodDrawer(UObject target, MethodInfo info)
        {
            this.target = target;
            this.info = info;
        }

        public readonly MethodInfo info;

        public readonly UObject target;

        public VisualElement CreatePropertyGUI()
        {
            var sortedAttrs = info.GetCustomAttributes<InspectorMaidAttribute>(true).OrderByDescending(it => it.order);

            var builder = new MethodBuilder(target, info, info.Name);

            var args = new MethodDrawerArgs(target, info);

            foreach (var attr in sortedAttrs)
            {
                var drawer = DrawerMapper.Get(attr.GetType());
                drawer.OnDrawMethod(builder, attr, args);
            }

            VisualElement ve = builder.Build();

            foreach (var attr in sortedAttrs)
            {
                var drawer = DrawerMapper.Get(attr.GetType());
                var decorator = drawer.OnDrawDecorator(ve, attr, args);
                if (decorator != null)
                {
                    ve = decorator;
                }
            }
            return ve;
        }
    }
}
