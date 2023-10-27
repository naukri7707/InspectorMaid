using Naukri.InspectorMaid.Editor.Core;
using System.Linq;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    public class FoldoutScopeDrawer : CustomDrawerOf<FoldoutScopeAttribute>
    {
        public override void OnStart()
        {
            var foldout = new Foldout()
            {
                text = attribute.text,
            };

            // We need to cache the children before we add the foldout to the decorator,
            // otherwise the loop will never end.
            var children = decorator.Children().ToList();
            foreach (var child in children)
            {
                foldout.Add(child);
            }

            decorator.Add(foldout);
        }
    }
}
