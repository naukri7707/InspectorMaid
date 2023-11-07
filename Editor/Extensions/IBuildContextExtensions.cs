using Naukri.InspectorMaid.Editor.Contexts.Core;
using Naukri.InspectorMaid.Editor.Widgets;
using System.Collections.Generic;

namespace Naukri.InspectorMaid.Editor.Extensions
{
    public static class IBuildContextExtensions
    {
        // Get all contexts that belong to the the target.
        // if target is the closest ancestor MemberWidget of the context, the context is belong to the target.
        internal static Context[] GetFamilyContexts(this IBuildContext context)
        {
            var memberContext = context.GetContextOfAncestorWidget<MemberWidget>();

            var contexts = new List<Context>();

            void GetFamily(IBuildContext ctx)
            {
                ctx.VisitChildVisualContexts(child =>
                {
                    if (child.Widget is not MemberWidget)
                    {
                        contexts.Add(child);
                        GetFamily(child);
                    }
                });
            }

            GetFamily(memberContext);

            return contexts.ToArray();
        }
    }
}
