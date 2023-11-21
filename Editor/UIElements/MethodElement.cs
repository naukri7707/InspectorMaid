using Naukri.InspectorMaid.Editor.Helpers;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Naukri.InspectorMaid.Editor.UIElements
{
    public partial class MethodElement : VisualElement
    {
        public MethodElement(object target, MethodInfo info, SerializedObject serializedObject)
        {
            this.target = target;
            this.info = info;
            this.serializedObject = serializedObject;
            label = ObjectNames.NicifyVariableName(info.Name);
        }

        private readonly MethodInfo info;

        private readonly SerializedObject serializedObject;

        private readonly object target;

        private string _label;

        private object[] args;

        [SuppressMessage("Style", "IDE1006")]
        public string label { get => _label; set => _label = value; }

        public event Action OnInvoke = () => { };

        public void Build()
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
                Undo.RecordObject(serializedObject.targetObject, "Method Invoke");
                action(target, args);
                OnInvoke.Invoke();
                EditorUtility.SetDirty(serializedObject.targetObject);
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

            if (parameterInfos.Length == 0)
            {
                // Hide checkMark if the method doesn't have parameter.
                var checkMark = toggle.Q<VisualElement>(className: Toggle.checkmarkUssClassName);
                checkMark.visible = false;
            }
            else
            {
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

                    var propertyElement = PropertyBuilder.Build(
                        pType, $"{pInfo.Name} ({pType.Name}) ", target,
                        () => args[idx],
                        v => args[idx] = v
                        );

                    foldout.Add(propertyElement);
                }
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
