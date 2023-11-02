using Naukri.InspectorMaid.Editor.Helpers;
using Naukri.InspectorMaid.Editor.UIElements;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using UObject = UnityEngine.Object;

namespace Naukri.InspectorMaid.Editor.Core
{
    public static class PropertyBuilder
    {
        public delegate BindableElement BuilderFunc(string label, UObject target, Func<object> getter, Action<object> setter);

        private static Dictionary<Type, BuilderFunc> _builderDict = null;

        public static Dictionary<Type, BuilderFunc> BuilderDict
        {
            get
            {
                if (_builderDict == null)
                {
                    _builderDict = new Dictionary<Type, BuilderFunc>();
                    InitDict();
                }
                return _builderDict;
            }
        }

        public static void AddBuilderWithBinding<T>(Func<string, BaseField<T>> factory)
        {
            BuilderDict
                .Add(typeof(T), (label, target, getter, setter) =>
                {
                    var field = factory(label);
                    DelegateBinding.Bind(field, getter, setter);
                    return field;
                });
        }

        public static void AddBuilderWithBinding<T, TValue>(Func<string, BaseField<TValue>> factory)
        {
            BuilderDict
                .Add(typeof(T), (label, target, getter, setter) =>
                {
                    var field = factory(label);
                    DelegateBinding.Bind(field, getter, setter);
                    return field;
                });
        }

        internal static BindableElement Build(string label, UObject target, PropertyInfo info)
        {
            var propertyType = info.PropertyType;
            Func<object> getter = info.CanRead
                ? () => info.GetValue(target)
                : null;
            Action<object> setter = info.CanWrite
                ? v =>
                {
                    info.SetValue(target, v);
                    EditorUtility.SetDirty(target);
                }
            : null;

            return Build(propertyType, label, target, getter, setter);
        }

        internal static BindableElement Build(Type type, string label, UObject target, Func<object> getter, Action<object> setter)
        {
            if (type.IsEnum)
            {
                var defaultValue = (Enum)Activator.CreateInstance(type);

                var isFlags = type.HasAttribute<FlagsAttribute>();

                BaseField<Enum> field = isFlags
                    ? new EnumFlagsField(label, defaultValue)
                    : new EnumField(label, defaultValue);

                DelegateBinding.Bind(field, getter, setter);

                return field;
            }

            if (typeof(IList).IsAssignableFrom(type))
            {
                // Todo: Implement ListView
                throw new NotImplementedException();
            }

            var targetType = type;
            while (targetType != null && !BuilderDict.ContainsKey(targetType))
            {
                targetType = targetType.BaseType;
            }

            if (targetType == null)
            {
                throw new Exception($"{type.Name} is not a supported type");
            }

            var element = BuilderDict[targetType].Invoke(label, target, getter, setter);

            // Special processing for ObjectField type filters
            if (element is ObjectField objectField)
            {
                objectField.objectType = type;
            }

            return element;
        }

        private static void InitDict()
        {
            // C# built-in value types
            AddBuilderWithBinding<bool>(label => new Toggle(label));
            AddBuilderWithBinding<byte, int>(label => new RangedIntegerField(label, byte.MinValue, byte.MaxValue));
            AddBuilderWithBinding<sbyte, int>(label => new RangedIntegerField(label, sbyte.MinValue, sbyte.MaxValue));
            AddBuilderWithBinding<char, string>(label => new TextField(label, 1, false, false, '*'));
            AddBuilderWithBinding<decimal>(label => new NoGuiImplemented<decimal>(label));
            AddBuilderWithBinding<double>(label => new DoubleField(label));
            AddBuilderWithBinding<float>(label => new FloatField(label));

            AddBuilderWithBinding<int>(label => new IntegerField(label));
            AddBuilderWithBinding<nint, int>(label => new IntegerField(label));
            AddBuilderWithBinding<long>(label => new LongField(label));
            AddBuilderWithBinding<short, int>(label => new RangedIntegerField(label, short.MinValue, short.MaxValue));

#if UNITY_2022_3_OR_NEWER
            AddBuilderWithBinding<uint>(label => new UnsignedIntegerField(label));
            AddBuilderWithBinding<nuint, uint>(label => new UnsignedIntegerField(label));
            AddBuilderWithBinding<ulong>(label => new UnsignedLongField(label));
#else
            AddBuilderWithBinding<uint, long>(label => new RangedLongField(label, uint.MinValue, uint.MaxValue));
            AddBuilderWithBinding<nuint, long>(label => new RangedLongField(label, uint.MinValue, uint.MaxValue));
            AddBuilderWithBinding<ulong>(label => new NoGuiImplemented<ulong>(label));
#endif

            AddBuilderWithBinding<ushort, int>(label => new RangedIntegerField(label, ushort.MinValue, ushort.MaxValue));

            // C# built-in reference types
            AddBuilderWithBinding<object>(label => new NoGuiImplemented<object>(label));
            AddBuilderWithBinding<string>(label => new TextField(label));
            // Cannot use dynamic because it will be treated as object
            //AddBuilderWithBinding<dynamic>(label => new NoGuiImplemented<dynamic>(label));
            // Unity value type
            AddBuilderWithBinding<Bounds>(label => new BoundsField(label));
            AddBuilderWithBinding<BoundsInt>(label => new BoundsIntField(label));
            AddBuilderWithBinding<Hash128>(label => new Hash128Field(label));
            AddBuilderWithBinding<Rect>(label => new RectField(label));
            AddBuilderWithBinding<RectInt>(label => new RectIntField(label));
            AddBuilderWithBinding<Vector2>(label => new Vector2Field(label));
            AddBuilderWithBinding<Vector2Int>(label => new Vector2IntField(label));
            AddBuilderWithBinding<Vector3>(label => new Vector3Field(label));
            AddBuilderWithBinding<Vector3Int>(label => new Vector3IntField(label));
            AddBuilderWithBinding<Vector4>(label => new Vector4Field(label));

            // Unity special types
            AddBuilderWithBinding<Color>(label => new ColorField(label));
            AddBuilderWithBinding<AnimationCurve>(label => new CurveField(label));
            AddBuilderWithBinding<Gradient>(label => new GradientField(label));
            // AddWithBinding<Layer, int>(label => new LayerField(label));
            AddBuilderWithBinding<LayerMask, int>(label => new LayerMaskField(label));
            // AddWithBinding<Mask, int>(label => new MaskField(label));
            AddBuilderWithBinding<UObject>(label => new ObjectField(label));
            // AddWithBinding<Tag, string>(label => new TagField(label));
        }
    }
}
