using Naukri.InspectorMaid.Editor.Core;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UObject = UnityEngine.Object;

namespace Naukri.InspectorMaid.Editor.UIElements
{
    public partial class MethodElement : VisualElement, IBuildable
    {
        public MethodElement(UObject target, MethodInfo info)
        {
            this.target = target;
            this.info = info;
            label = ObjectNames.NicifyVariableName(info.Name);
        }

        private readonly MethodInfo info;

        private readonly UObject target;

        private string _label;

        private object[] args;

        [SuppressMessage("Style", "IDE1006")]
        public string label { get => _label; set => _label = value; }

        public event Action OnInvoke = () => { };

        void IBuildable.Build()
        {
            style.flexDirection = FlexDirection.Column;

            var foldout = new Foldout
            {
                text = label,
                value = false
            };

            // style toggle
            var toggle = foldout.Q<Toggle>();
            toggle.style.height = 24;
            toggle.RegisterCallback<MouseEnterEvent>(evt =>
            {
                toggle.style.backgroundColor = kHoverColor;
            });
            toggle.RegisterCallback<MouseLeaveEvent>(evt =>
            {
                toggle.style.backgroundColor = new StyleColor(StyleKeyword.Undefined);
            });

            var action = FastReflection.Polymorphism.CreateAction<object>(info, target.GetType());

            // style button
            void buttonAction()
            {
                action(target, args);
                OnInvoke.Invoke();
            }

            var button = new Button(buttonAction)
            {
                text = "Invoke",
                focusable = false
            };
            button.style.width = 80;
            button.style.top = button.style.top.value.value + 2;
            button.style.position = Position.Absolute;
            button.style.alignSelf = Align.FlexEnd;

            // for button evnet implement
            var parameterInfos = info.GetParameters();
            args = new object[parameterInfos.Length];

            for (var i = 0; i < parameterInfos.Length; i++)
            {
                // We need to cache the value of i,
                // because if we use i in lambda, it will directly reference the current i reference,
                // but what we want is the i value at the time of definition.
                var idx = i;
                var pInfo = parameterInfos[idx];
                var pType = pInfo.ParameterType;

                // If the parameter has a default value, set argument to the default value.
                if (pInfo.HasDefaultValue)
                {
                    args[i] = pInfo.DefaultValue;
                }
                // If the parameter doesn't have default value, and it is a value type, we need to create an instance of it.
                // because the valueType can not be null.
                else if (pType.IsValueType)
                {
                    args[i] = Activator.CreateInstance(pType);
                }

                var pElement = PropertyBuilder.Build(
                    pType, $"{pInfo.Name} ({pType.Name}) ", target,
                    () => args[idx],
                    v => args[idx] = v
                    );

                foldout.Add(pElement);
            }

            Add(foldout);
            Add(button);
        }
    }

    partial class MethodElement
    {
        private static readonly StyleColor kHoverColor = new(new Color32(69, 69, 69, 255));
    }
}
