using Naukri.InspectorMaid.Core;
using Naukri.InspectorMaid.Editor.UIElements;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Naukri.InspectorMaid.Editor.Core
{
    public abstract class CustomDrawerWithDecoratorOf<TAttribute, TDecorator> : CustomDrawer
           where TAttribute : DrawerAttribute
           where TDecorator : DecoratorElement
    {
        private TAttribute _attribute;

        private TDecorator _decorator;

        [SuppressMessage("Style", "IDE1006")]
        public TAttribute attribute => _attribute;

        [SuppressMessage("Style", "IDE1006")]
        public TDecorator decorator => _decorator;

        internal override Type AttributeType => typeof(TAttribute);

        protected internal override sealed DrawerAttribute attributeRef
        {
            get => _attribute;
            set
            {
                if (value is TAttribute tValue)
                {
                    _attribute = tValue;
                }
            }
        }

        protected internal override sealed DecoratorElement decoratorRef
        {
            get => _decorator;
            set
            {
                if (value is TDecorator tValue)
                {
                    _decorator = tValue;
                }
            }
        }

        public override void OnDrawDecorator(DecoratorElement child)
        {
            decorator.Add(child);
        }

        protected internal override sealed DecoratorElement CreateDecoratorImpl()
        {
            return CreateDecorator();
        }

        protected abstract TDecorator CreateDecorator();
    }
}
