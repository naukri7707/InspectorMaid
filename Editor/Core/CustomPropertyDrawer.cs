using Naukri.InspectorMaid.Core;
using System.Linq;
using System.Reflection;
using UnityEngine.UIElements;
using UObject = UnityEngine.Object;

namespace Naukri.InspectorMaid.Editor.Core
{
    internal class CustomPropertyDrawer
    {
        internal CustomPropertyDrawer(UObject target, PropertyInfo info)
        {
            this.target = target;
            this.info = info;
        }

        public readonly PropertyInfo info;

        public readonly UObject target;

        public VisualElement CreatePropertyGUI()
        {
            var sortedAttrs = info.GetCustomAttributes<InspectorMaidAttribute>(true).OrderByDescending(it => it.order);

            var builder = new PropertyBuilder(target, info)
            {
                Label = info.Name
            };

            var args = new PropertyDrawerArgs(target, info);

            foreach (var attr in sortedAttrs)
            {
                var drawer = DrawerMapper.Get(attr.GetType());
                drawer.OnDrawProperty(builder, attr, args);
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
