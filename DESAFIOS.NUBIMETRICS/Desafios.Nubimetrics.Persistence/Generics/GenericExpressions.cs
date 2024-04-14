using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Desafios.Nubimetrics.Persistence.Generics;

namespace Desafios.Nubimetrics.Persistence.Generics
{
    public static class LinqExtensions
    {
        #region Pagination

        public static IQueryable<T> OrderByPropertyName<T>(this IQueryable<T> src, string orderBy = null) where T : class
        {
            var queryExpression = src.Expression;
            queryExpression = queryExpression.OrderBy(orderBy);

            if (queryExpression.CanReduce)
                queryExpression = queryExpression.Reduce();

            src = src.Provider.CreateQuery<T>(queryExpression);

            return src;
        }

        private static Expression OrderBy(this Expression source, string orderBy)
        {
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                var orderBys = orderBy.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < orderBys.Length; i++)
                {
                    source = AddOrderBy(source, orderBys[i], i);
                }
            }

            return source;
        }

        private static Expression AddOrderBy(Expression source, string orderBy, int index)
        {
            var orderByParams = orderBy.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string orderByMethodName = index == 0 ? "OrderBy" : "ThenBy";
            string parameterPath = orderByParams[0];
            if (orderByParams.Length > 1 && orderByParams[1].Equals("desc", StringComparison.OrdinalIgnoreCase))
                orderByMethodName += "Descending";

            var sourceType = source.Type.GetGenericArguments().First();
            var parameterExpression = Expression.Parameter(sourceType, "p");
            var orderByExpression = parameterExpression.BuildPropertyPathExpression(parameterPath);
            var orderByFuncType = typeof(Func<,>).MakeGenericType(sourceType, orderByExpression.Type);
            var orderByLambda = Expression.Lambda(orderByFuncType, orderByExpression, new ParameterExpression[] { parameterExpression });

            source = Expression.Call(typeof(Queryable), orderByMethodName, new Type[] { sourceType, orderByExpression.Type }, source, orderByLambda);
            return source;
        }

        private static Expression BuildPropertyPathExpression(this Expression rootExpression, string propertyPath)
        {
            var parts = propertyPath.Split(new[] { '.' }, 2);
            var currentProperty = parts[0];
            var propertyDescription = rootExpression.Type.GetProperty(currentProperty, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
            if (propertyDescription == null)
                throw new KeyNotFoundException($"Cannot find property {rootExpression.Type.Name}.{currentProperty}. The root expression is {rootExpression} and the full path would be {propertyPath}.");

            var propExpr = Expression.Property(rootExpression, propertyDescription);
            if (parts.Length > 1)
                return propExpr.BuildPropertyPathExpression(parts[1]);

            return propExpr;
        }

        #endregion

        #region Order by property name

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName)
        {
            return source.OrderBy(ToLambda<T>(propertyName));
        }

        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string propertyName)
        {
            return source.OrderByDescending(ToLambda<T>(propertyName));
        }

        private static Expression<Func<T, object>> ToLambda<T>(string propertyName)
        {
            var parameter = Expression.Parameter(typeof(T));
            var property = Expression.Property(parameter, propertyName);
            var propAsObject = Expression.Convert(property, typeof(object));

            return Expression.Lambda<Func<T, object>>(propAsObject, parameter);
        }

        #endregion
    }

    public static class QueryExtensions
    {
        public static IQueryable<T> AddWhereWithContains<T, K>(this IQueryable<T> source, string property, List<K> items)
        {
            ParameterExpression entityExp = Expression.Parameter(typeof(T), "x");
            MemberExpression fieldExp = Expression.Property(entityExp, property);

            var whereMethod = typeof(Queryable)
                .GetMethods()
                .First(m =>
                {
                    var parameters = m.GetParameters().ToList();
                    return m.Name == "Where" && m.IsGenericMethodDefinition && parameters.Count == 2;
                })
                .MakeGenericMethod(typeof(T));

            MethodInfo containsMethod = typeof(List<K>).GetMethod("Contains", new[] { typeof(K) })!;

            MethodCallExpression methodCallExpression = Expression.Call(Expression.Constant(items), containsMethod, fieldExp);

            Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(methodCallExpression, entityExp);

            return (IQueryable<T>?)whereMethod.Invoke(whereMethod, new object[] { source, lambda })!;
        }
    }
}
