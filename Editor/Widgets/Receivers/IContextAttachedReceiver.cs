﻿namespace Naukri.InspectorMaid.Editor.Widgets.Receivers
{
    public interface IContextAttachedReceiver : IReceiver
    {
        public void OnContextAttached(Context context);
    }
}
