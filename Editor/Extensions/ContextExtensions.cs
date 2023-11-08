using Naukri.InspectorMaid.Editor.Contexts.Core;
using Naukri.InspectorMaid.Editor.Widgets.Receivers;
using System;

namespace Naukri.InspectorMaid.Editor.Extensions
{
    public static class ContextExtensions
    {
        public static void VisitAncestorReceivers<T>(this Context context, Func<Context, T, bool> visitor) where T : IReceiver
        {
            context.VisitAncestorContexts(ctx =>
            {
                if (ctx.Widget is T tReceiver)
                {
                    return visitor(ctx, tReceiver);
                }
                return false;
            });
        }

        public static void VisitReceiver<T>(this Context context, Action<Context, T> visitor) where T : IReceiver
        {
            if (context.Widget is T tReceiver)
            {
                visitor(context, tReceiver);
            }
        }

        public static void VisitChildReceivers<T>(this Context context, Action<Context, T> visitor) where T : IReceiver
        {
            context.VisitChildContexts(ctx =>
            {
                ctx.VisitReceiver(visitor);
            });
        }
    }
}
