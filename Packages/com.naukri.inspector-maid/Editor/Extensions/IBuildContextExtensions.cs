using Naukri.InspectorMaid.Editor.Contexts.Core;
using Naukri.InspectorMaid.Editor.Widgets.Visual;
using System.Collections.Generic;

namespace Naukri.InspectorMaid.Editor.Extensions
{
    public static class IBuildContextExtensions
    {
        // If context and target context have the same ancestor MemberWidget, they are considered family.
        internal static Context[] GetFamilyContexts(this IBuildContext context)
        {
            var memberContext = context.GetContextOfAncestorWidget<MemberWidget>();

            var contexts = new List<Context>();

            void GetFamily(IBuildContext ctx)
            {
                ctx.VisitChildContexts(child =>
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
