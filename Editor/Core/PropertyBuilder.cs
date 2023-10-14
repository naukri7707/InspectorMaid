using Naukri.InspectorMaid.UIElements;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using UObject = UnityEngine.Object;

namespace Naukri.InspectorMaid.Editor.Core
{
    public class PropertyBuilder
    {
        public PropertyBuilder(UObject target, PropertyInfo info)
        {
            this.target = target;
            this.info = info;
            propertyType = info.PropertyType;
        }

        private static Dictionary<Type, Func<string, UObject, PropertyInfo, BindableElement>> _builderDict = null;

        private readonly PropertyInfo info;

        private readonly Type propertyType;

        private readonly UObject target;

        public static Dictionary<Type, Func<string, UObject, PropertyInfo, BindableElement>> BuilderDict
        {
            get
            {
                if (_builderDict == null)
                {
                    _builderDict = new Dictionary<Type, Func<string, UObject, PropertyInfo, BindableElement>>();
                    InitDict();
                }
                return _builderDict;
            }
        }

        public string Label { get; set; }

        public static void AddBuilder<T>(Func<string, UObject, PropertyInfo, BaseField<T>> factory)
        {
            BuilderDict.Add(typeof(T), factory);
        }

        public static void AddBuilderWithBinding<T>(Func<string, BaseField<T>> factory)
        {
            BuilderDict.Add(typeof(T), (label, target, info) => factory(label).WithBind(target, info));
        }

        public static void AddBuilderWithBinding<T, TValue>(Func<string, BaseField<TValue>> factory)
        {
            BuilderDict.Add(typeof(T), (label, target, info) => factory(label).WithBind(target, info));
        }

        public BindableElement Build()
        {
            if (propertyType.IsEnum)
            {
                var isFlags = info.GetCustomAttribute<FlagsAttribute>() != null;
                return isFlags
                    ? new EnumFlagsField(Label).WithBind(target, info)
                    : new EnumField(Label).WithBind(target, info);
            }

            return BuilderDict[propertyType].Invoke(Label, target, info);
        }

        private static void InitDict()
        {
            // C# built-in value types
            AddBuilderWithBinding<bool>(label => new Toggle(label));
            AddBuilderWithBinding<byte, int>(label => new RangedIntegerField(label, byte.MinValue, byte.MaxValue));
            AddBuilderWithBinding<sbyte, int>(label => new RangedIntegerField(label, sbyte.MinValue, sbyte.MaxValue));
            AddBuilderWithBinding<char, string>(label => new TextField(label, 1, false, false, '*'));
            AddBuilderWithBinding<decimal>(label => throw new NotImplementedException());
            AddBuilderWithBinding<double>(label => new DoubleField(label));
            AddBuilderWithBinding<float>(label => new FloatField(label));
            AddBuilderWithBinding<int>(label => new IntegerField(label));
            // Todo: use UnsignedIntegerField / UnsignedLongField  in newer unity version
            AddBuilderWithBinding<uint, long>(label => new RangedLongField(label, uint.MinValue, uint.MaxValue));
            AddBuilderWithBinding<nint, int>(label => new IntegerField(label));
            AddBuilderWithBinding<nuint, long>(label => new RangedLongField(label, uint.MinValue, uint.MaxValue));
            AddBuilderWithBinding<long>(label => new LongField(label));
            AddBuilderWithBinding<ulong, long>(label => throw new NotImplementedException());
            AddBuilderWithBinding<short, int>(label => new RangedIntegerField(label, short.MinValue, short.MaxValue));
            AddBuilderWithBinding<ushort, int>(label => new RangedIntegerField(label, ushort.MinValue, ushort.MaxValue));

            // C# built-in reference types
            AddBuilderWithBinding<object>(label => throw new NotImplementedException());
            AddBuilderWithBinding<string>(label => new TextField(label));
            // Cannot use dynamic because it will be treated as object
            //AddBuilderWithBinding<dynamic>(label => throw new NotImplementedException());
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
