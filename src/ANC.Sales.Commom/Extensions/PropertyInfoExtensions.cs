using System;
using System.Reflection;

namespace ANC.Sales.Commom.Extensions
{
    public static class PropertyInfoExtensions
    {
        public static TResult GetCustomAttributeValue<TAttribute, TResult>(this PropertyInfo property, string propertyName)
            where TAttribute : Attribute
        {
            var attr = property.GetCustomAttribute<TAttribute>(true);

            var val = attr.GetType().GetProperty(propertyName)?.GetValue(attr, null);

            return (TResult)val;
        }
    }
}
