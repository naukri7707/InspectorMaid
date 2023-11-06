using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.Core;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Naukri.InspectorMaid.Editor
{
    public abstract class StylerOf<TModel> : Styler, IModelProvider, IStylerProvider
        where TModel : StylerAttribute
    {
        private TModel _model;

        [SuppressMessage("Style", "IDE1006")]
        public TModel model => _model;

        object IModelProvider.Model => model;

        Type IStylerProvider.RegisterType => typeof(TModel);

        Styler IStylerProvider.CloneWith(object model)
        {
            var cloned = (StylerOf<TModel>)MemberwiseClone();

            cloned._model = model switch
            {
                TModel tModel => tModel,
                _ => throw new Exception($"{nameof(StylerOf<TModel>.model)} type mismatch."),
            };

            return cloned;
        }
    }
}
