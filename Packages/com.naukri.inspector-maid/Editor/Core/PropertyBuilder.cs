using Naukri.InspectorMaid.UIElements;
using System;
using System.Collections;
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

        private static Dictionary<Type, Func<UObject, PropertyInfo, BindableElement>> _builderDict = null;

        private readonly PropertyInfo info;

        private readonly Type propertyType;

        private readonly UObject target;

        public static Dictionary<Type, Func<UObject, PropertyInfo, BindableElement>> BuilderDict
        {
            get
            {
                if (_builderDict == null)
                {
                    _builderDict = new Dictionary<Type, Func<UObject, PropertyInfo, BindableElement>>();
                    InitDict();
                }
                return _builderDict;
            }
        }

        public static void AddBuilder<T>(Func<UObject, PropertyInfo, BaseField<T>> factory)
        {
            BuilderDict.Add(typeof(T), factory);
        }

        public static void AddBuilderWithBinding<T>(Func<BaseField<T>> factory)
        {
            BuilderDict.Add(typeof(T), (target, info) => factory().WithBind(target, info));
        }

        public static void AddBuilderWithBinding<T, TValue>(Func<BaseField<TValue>> factory)
        {
            BuilderDict.Add(typeof(T), (target, info) => factory().WithBind(target, info));
        }

        internal BindableElement Build()
        {
            if (propertyType.IsEnum)
            {
                var isFlags = info.GetCustomAttribute<FlagsAttribute>() != null;
                return isFlags
                    ? new EnumFlagsField().WithBind(target, info)
                    : new EnumField().WithBind(target, info);
            }
            if (typeof(IList).IsAssignableFrom(propertyType))
            {
                // Todo: Implement ListView
                throw new NotImplementedException();
            }
            var element = BuilderDict[propertyType].Invoke(target, info);

            return element;
        }

        private static void InitDict()
        {
            // C# built-in value types
            AddBuilderWithBinding<bool>(() => new Toggle());
            AddBuilderWithBinding<byte, int>(() => new RangedIntegerField(byte.MinValue, byte.MaxValue));
            AddBuilderWithBinding<sbyte, int>(() => new RangedIntegerField(sbyte.MinValue, sbyte.MaxValue));
            AddBuilderWithBinding<char, string>(() => new TextField(1, false, false, '*'));
            AddBuilderWithBinding<decimal>(() => throw new NotImplementedException());
            AddBuilderWithBinding<double>(() => new DoubleField());
            AddBuilderWithBinding<float>(() => new FloatField());

            AddBuilderWithBinding<int>(() => new IntegerField());
            AddBuilderWithBinding<nint, int>(() => new IntegerField());
            AddBuilderWithBinding<long>(() => new LongField());
            AddBuilderWithBinding<short, int>(() => new RangedIntegerField(short.MinValue, short.MaxValue));

#if UNITY_2022_3_OR_NEWER
            AddBuilderWithBinding<uint>(() => new UnsignedIntegerField());
            AddBuilderWithBinding<nuint, uint>(() => new UnsignedIntegerField());
            AddBuilderWithBinding<ulong>(() => new UnsignedLongField());
#else
            AddBuilderWithBinding<uint, long>(() => new RangedLongField(uint.MinValue, uint.MaxValue));
            AddBuilderWithBinding<nuint, long>(() => new RangedLongField(uint.MinValue, uint.MaxValue));
            AddBuilderWithBinding<ulong, long>(() => throw new NotImplementedException());
#endif

            AddBuilderWithBinding<ushort, int>(() => new RangedIntegerField(ushort.MinValue, ushort.MaxValue));

            // C# built-in reference types
            AddBuilderWithBinding<object>(() => throw new NotImplementedException());
            AddBuilderWithBinding<string>(() => new TextField());
            // Cannot use dynamic because it will be treated as object
            //AddBuilderWithBinding<dynamic>( => throw new NotImplementedException());
            // Unity value type
            AddBuilderWithBinding<Bounds>(() => new BoundsField());
            AddBuilderWithBinding<BoundsInt>(() => new BoundsIntField());
            AddBuilderWithBinding<Hash128>(() => new Hash128Field());
            AddBuilderWithBinding<Rect>(() => new RectField());
            AddBuilderWithBinding<RectInt>(() => new RectIntField());
            AddBuilderWithBinding<Vector2>(() => new Vector2Field());
            AddBuilderWithBinding<Vector2Int>(() => new Vector2IntField());
            AddBuilderWithBinding<Vector3>(() => new Vector3Field());
            AddBuilderWithBinding<Vector3Int>(() => new Vector3IntField());
            AddBuilderWithBinding<Vector4>(() => new Vector4Field());

            // Unity special types
            AddBuilderWithBinding<Color>(() => new ColorField());
            AddBuilderWithBinding<AnimationCurve>(() => new CurveField());
            AddBuilderWithBinding<Gradient>(() => new GradientField());
            // AddWithBinding<Layer, int>(() => new LayerField());
            AddBuilderWithBinding<LayerMask, int>(() => new LayerMaskField());
            // AddWithBinding<Mask, int>(() => new MaskField());
            AddBuilderWithBinding<UObject>(() => new ObjectField());
            // AddWithBinding<Tag, string>(() => new TagField());
        }
    }
}
