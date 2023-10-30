using Naukri.InspectorMaid.Editor.Core;
using Naukri.InspectorMaid.Editor.UIElements;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    public class CardScopeDrawer : CustomDrawerOf<CardScopeAttribute>
    {
        public override void OnStart()
        {
            var card = attribute.color.HasValue switch
            {
                true => new Card(attribute.color.Value.value),
                false => new Card(),
            };

            // We need to cache the children before we add the foldout to the decorator,
            // otherwise the loop will never end.
            var children = decorator.Children().ToList();
            foreach (var child in children)
            {
                card.hierarchy.Add(child);
            }

            decorator.Add(card);
        }
    }
}
