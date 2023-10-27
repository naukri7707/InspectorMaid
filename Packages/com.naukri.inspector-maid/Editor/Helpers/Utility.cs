using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Core;
using Naukri.InspectorMaid.Editor.UIElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UObject = UnityEngine.Object;

namespace Naukri.InspectorMaid.Editor.Helpers
{
    internal static class Utility
    {
        public static BindingFlags AllAccessFlags => BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

        public static bool HasAttribute<T>(this MemberInfo self) where T : Attribute
        {
            return Attribute.IsDefined(self, typeof(T));
        }

        public static Decorator DrawDecoratorTree(UObject target, MemberInfo info, Action<CustomDrawer> onDrawTarget)
        {
            var root = new Decorator("Field Decorator");
            var attrs = info.GetCustomAttributes<InspectorMaidAttribute>(true).ToList();

            var targetAttributeCount = attrs.Count(attr => attr is TargetAttribute);

            if (targetAttributeCount == 0)
            {
                // Add default target attribute
                attrs.Add(new TargetAttribute());
            }
            else if (targetAttributeCount > 1)
            {
                throw new InvalidOperationException("Multiple TargetAttribute found in attributes.");
            }

            var iteractor = attrs.GetEnumerator();

            Decorator lastDecorator = null;

            List<Decorator> DrawDecorators()
            {
                var items = new List<Decorator>();
                while (iteractor.MoveNext())
                {
                    var current = iteractor.Current;

                    // Draw decorator
                    if (current is DrawerAttribute drawerAttr)
                    {
                        if (current is EndScopeAttribute)
                        {
                            break;
                        }

                        var drawer = DrawerTemplates.Create(drawerAttr, DrawerTarget.Field, target, info);
                        var currentDecorator = drawer.decorator;
                        lastDecorator = currentDecorator;
                        items.Add(lastDecorator);

                        if (drawerAttr is ItemAttribute itemAttribute)
                        {
                            // do nothing
                        }
                        else if (drawerAttr is ScopeAttribute scopeAttr)
                        {
                            var children = DrawDecorators();
                            foreach (var child in children)
                            {
                                currentDecorator.Add(child);
                            }
                        }
                        onDrawTarget.Invoke(drawer);
                    }
                    // Style decorator
                    else if (current is StylerAttribute styleAttr)
                    {
                        if (lastDecorator == null)
                        {
                            continue;
                        }

                        if (styleAttr is IUseClassable useClassable)
                        {
                            foreach (var className in useClassable.classList)
                            {
                                lastDecorator.AddToClassList(className);
                            }
                        }

                        var styler = StylerTemplates.Create(styleAttr);
                        styler.OnStyling(lastDecorator.style);
                    }
                }
                return items;
            }

            var decorators = DrawDecorators();

            foreach (var decorator in decorators)
            {
                root.Add(decorator);
            }

            return root;
        }
    }
}
