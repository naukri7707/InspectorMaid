using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor
{
    public abstract class WidgetOf<TModel> : Widget, IModelProvider, IWidgetProvider
    {
        private TModel _model;

        [SuppressMessage("Style", "IDE1006")]
        public TModel model => _model;

        object IModelProvider.Model => _model;

        Type IWidgetProvider.RegisterType => typeof(TModel);

        Widget IWidgetProvider.CloneWith(object model)
        {
            var cloned = (WidgetOf<TModel>)MemberwiseClone();

            cloned._model = model switch
            {
                TModel tModel => tModel,
                _ => throw new Exception($"model type mismatch."),
            };

            return cloned;
        }
    }
}
