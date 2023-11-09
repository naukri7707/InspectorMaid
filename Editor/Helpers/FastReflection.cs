using Naukri.InspectorMaid.Editor.Extensions;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Naukri.InspectorMaid.Editor.Helpers
{
    public delegate TResult FRGetter<in TObject, out TResult>(TObject target);

    public delegate void FRSetter<in TObject, in TValue>(TObject target, TValue value);

    public delegate void FRAction<in TObject>(TObject target, params object[] values);

    public delegate TResult FRFunc<in TObject, out TResult>(TObject target, params object[] values);

    public static class FastReflection
    {
        public static FRGetter<TObject, TValue> CreateGetter<TObject, TValue>(this FieldInfo fieldInfo)
        {
            var objectExpr = Expression.Parameter(typeof(TObject));
            var fieldExpr = Expression.Field(fieldInfo.IsStatic ? null : objectExpr, fieldInfo);
            var convertedFieldExpr = Expression.Convert(fieldExpr, typeof(TValue));

            return Expression.Lambda<FRGetter<TObject, TValue>>(
                convertedFieldExpr,
                objectExpr
                ).Compile();
        }

        public static FRSetter<TObject, TValue> CreateSetter<TObject, TValue>(this FieldInfo fieldInfo)
        {
            var objectExpr = Expression.Parameter(typeof(TObject));
            var fieldExpr = Expression.Field(fieldInfo.IsStatic ? null : objectExpr, fieldInfo);
            var valueExpr = Expression.Parameter(typeof(TValue));
            var convertedValueExpr = Expression.Convert(valueExpr, fieldInfo.FieldType);
            var assignExpr = Expression.Assign(fieldExpr, convertedValueExpr);

            return Expression.Lambda<FRSetter<TObject, TValue>>(
                assignExpr,
                objectExpr,
                valueExpr
                ).Compile();
        }

        public static FRGetter<TObject, TValue> CreateGetter<TObject, TValue>(this PropertyInfo propertyInfo)
        {
            var objectExpr = Expression.Parameter(typeof(TObject));
            var propertyExpr = Expression.Property(propertyInfo.IsStatic() ? null : objectExpr, propertyInfo);
            var convertPropertyExpr = Expression.Convert(propertyExpr, typeof(TValue));

            return Expression.Lambda<FRGetter<TObject, TValue>>(
                convertPropertyExpr,
                objectExpr
                ).Compile();
        }

        public static FRSetter<TObject, TValue> CreateSetter<TObject, TValue>(this PropertyInfo propertyInfo)
        {
            var objectExpr = Expression.Parameter(typeof(TObject));
            var propertyExpr = Expression.Property(propertyInfo.IsStatic() ? null : objectExpr, propertyInfo);
            var valueExpr = Expression.Parameter(typeof(TValue));
            var convertedValueExpr = Expression.Convert(valueExpr, propertyInfo.PropertyType);
            var assignExpr = Expression.Assign(propertyExpr, convertedValueExpr);

            return Expression.Lambda<FRSetter<TObject, TValue>>(
                assignExpr,
                objectExpr,
                valueExpr
                ).Compile();
        }

        public static FRAction<TObject> CreateAction<TObject>(this MethodInfo methodInfo)
        {
            var parameters = methodInfo.GetParameters();

            var objectExpr = Expression.Parameter(typeof(TObject));
            var argsExpr = Expression.Parameter(typeof(object[]));

            var convertedArgExprs = parameters.Select((p, i) =>
                Expression.Convert(
                    Expression.ArrayIndex(argsExpr, Expression.Constant(i)),
                    p.ParameterType)
                ).ToArray();

            var call = Expression.Call(methodInfo.IsStatic ? null : objectExpr, methodInfo, convertedArgExprs);

            return Expression.Lambda<FRAction<TObject>>(
                call,
                objectExpr,
                argsExpr
                ).Compile();
        }

        public static FRFunc<TObject, TResult> CreateFunc<TObject, TResult>(MethodInfo methodInfo)
        {
            var parameters = methodInfo.GetParameters();

            var objectExpr = Expression.Parameter(typeof(TObject));
            var argsExpr = Expression.Parameter(typeof(object[]));

            var convertedArgExprs = parameters.Select((p, i) =>
                Expression.Convert(
                    Expression.ArrayIndex(argsExpr, Expression.Constant(i)),
                    p.ParameterType)
                ).ToArray();

            var call = Expression.Call(methodInfo.IsStatic ? null : objectExpr, methodInfo, convertedArgExprs);
            var convertedCallExpr = Expression.Convert(call, typeof(TResult));

            return Expression.Lambda<FRFunc<TObject, TResult>>(
                convertedCallExpr,
                objectExpr,
                argsExpr
                ).Compile();
        }

        public static class Polymorphism
        {
            public static FRGetter<TObject, TValue> CreateGetter<TObject, TValue>(FieldInfo fieldInfo, Type instanceType)
            {
                var objectExpr = Expression.Parameter(typeof(TObject));
                var instanceExpr = instanceType.IsClass
                    ? Expression.TypeAs(objectExpr, instanceType)   // class polymorphism
                    : Expression.Convert(objectExpr, instanceType); // struct boxing
                var fieldExpr = Expression.Field(fieldInfo.IsStatic ? null : instanceExpr, fieldInfo);
                var convertedFieldExpr = Expression.Convert(fieldExpr, typeof(TValue));

                return Expression.Lambda<FRGetter<TObject, TValue>>(
                    convertedFieldExpr,
                    objectExpr
                    ).Compile();
            }

            public static FRSetter<TObject, TValue> CreateSetter<TObject, TValue>(FieldInfo fieldInfo, Type instanceType)
            {
                var objectExpr = Expression.Parameter(typeof(TObject));
                var instanceExpr = instanceType.IsClass
                     ? Expression.TypeAs(objectExpr, instanceType)   // class polymorphism
                     : Expression.Convert(objectExpr, instanceType); // struct boxing
                var fieldExpr = Expression.Field(fieldInfo.IsStatic ? null : instanceExpr, fieldInfo);
                var valueExpr = Expression.Parameter(typeof(TValue));
                var convertedValueExpr = Expression.Convert(valueExpr, fieldInfo.FieldType);
                var assignExpr = Expression.Assign(fieldExpr, convertedValueExpr);

                return Expression.Lambda<FRSetter<TObject, TValue>>(
                    assignExpr,
                    objectExpr,
                    valueExpr
                    ).Compile();
            }

            public static FRGetter<TObject, TValue> CreateGetter<TObject, TValue>(PropertyInfo propertyInfo, Type instanceType)
            {
                var objectExpr = Expression.Parameter(typeof(TObject));
                var instanceExpr = instanceType.IsClass
                    ? Expression.TypeAs(objectExpr, instanceType)   // class polymorphism
                    : Expression.Convert(objectExpr, instanceType); // struct boxing
                var propertyExpr = Expression.Property(propertyInfo.IsStatic() ? null : instanceExpr, propertyInfo);
                var convertPropertyExpr = Expression.Convert(propertyExpr, typeof(TValue));

                return Expression.Lambda<FRGetter<TObject, TValue>>(
                    convertPropertyExpr,
                    objectExpr
                    ).Compile();
            }

            public static FRSetter<TObject, TValue> CreateSetter<TObject, TValue>(PropertyInfo propertyInfo, Type instanceType)
            {
                var objectExpr = Expression.Parameter(typeof(TObject));
                var instanceExpr = instanceType.IsClass
                     ? Expression.TypeAs(objectExpr, instanceType)   // class polymorphism
                     : Expression.Convert(objectExpr, instanceType); // struct boxing
                var propertyExpr = Expression.Property(propertyInfo.IsStatic() ? null : instanceExpr, propertyInfo);
                var valueExpr = Expression.Parameter(typeof(TValue));
                var convertedValueExpr = Expression.Convert(valueExpr, propertyInfo.PropertyType);
                var assignExpr = Expression.Assign(propertyExpr, convertedValueExpr);

                return Expression.Lambda<FRSetter<TObject, TValue>>(
                    assignExpr,
                    objectExpr,
                    valueExpr
                    ).Compile();
            }

            public static FRAction<TObject> CreateAction<TObject>(MethodInfo methodInfo, Type instanceType)
            {
                var parameters = methodInfo.GetParameters();

                var objectExpr = Expression.Parameter(typeof(TObject));
                var instanceExpr = instanceType.IsClass
                    ? Expression.TypeAs(objectExpr, instanceType)   // class polymorphism
                    : Expression.Convert(objectExpr, instanceType); // struct boxing
                var argsExpr = Expression.Parameter(typeof(object[]));

                var convertedArgExprs = parameters.Select((p, i) =>
                    Expression.Convert(
                        Expression.ArrayIndex(argsExpr, Expression.Constant(i)),
                        p.ParameterType)
                    ).ToArray();

                var call = Expression.Call(methodInfo.IsStatic ? null : instanceExpr, methodInfo, convertedArgExprs);

                return Expression.Lambda<FRAction<TObject>>(
                    call,
                    objectExpr,
                    argsExpr
                    ).Compile();
            }

            public static FRFunc<TObject, TResult> CreateFunc<TObject, TResult>(MethodInfo methodInfo, Type instanceType)
            {
                var parameters = methodInfo.GetParameters();

                var objectExpr = Expression.Parameter(typeof(TObject));
                var instanceExpr = instanceType.IsClass
                    ? Expression.TypeAs(objectExpr, instanceType)   // class polymorphism
                    : Expression.Convert(objectExpr, instanceType); // struct boxing
                var argsExpr = Expression.Parameter(typeof(object[]));

                var convertedArgExprs = parameters.Select((p, i) =>
                    Expression.Convert(
                        Expression.ArrayIndex(argsExpr, Expression.Constant(i)),
                        p.ParameterType)
                    ).ToArray();

                var call = Expression.Call(methodInfo.IsStatic ? null : instanceExpr, methodInfo, convertedArgExprs);
                var convertedCallExpr = Expression.Convert(call, typeof(TResult));

                return Expression.Lambda<FRFunc<TObject, TResult>>(
                    convertedCallExpr,
                    objectExpr,
                    argsExpr
                    ).Compile();
            }
        }
    }
}
