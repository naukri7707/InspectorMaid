﻿using Naukri.InspectorMaid.UIElements;
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
    public static class PropertyBuilder
    {
        private static Dictionary<Type, Func<string, UObject, PropertyInfo, BindableElement>> _builderDict = null;

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

        internal static BindableElement Build(string label, UObject target, PropertyInfo info)
        {
            var propertyType = info.PropertyType;

            if (propertyType.IsEnum)
            {
                var isFlags = info.GetCustomAttribute<FlagsAttribute>() != null;
                return isFlags
                    ? new EnumFlagsField(label).WithBind(target, info)
                    : new EnumField(label).WithBind(target, info);
            }
            if (typeof(IList).IsAssignableFrom(propertyType))
            {
                // Todo: Implement ListView
                throw new NotImplementedException();
            }
            var element = BuilderDict[propertyType].Invoke(label, target, info);

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
