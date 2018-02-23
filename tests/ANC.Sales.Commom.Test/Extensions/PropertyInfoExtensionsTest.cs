using ANC.Sales.Commom.Extensions;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace ANC.Sales.Commom.Test.Extensions
{
    public class PropertyInfoExtensionsTest
    {
        [Fact]
        public void GetCustomAttributeValue_MustGetAttributeValue()
        {
            var objectUT = new ObjectUnderTest
            {
                Name   = "Name",
                Age    = 28,
                Weight = new decimal(83.45),
                IsOK   = true
            };
            
            var properties = objectUT.GetType().GetProperties();
            foreach (var property in properties)
            {
                var propertyName   = property.Name;
                var propertyType   = property.PropertyType;
                var attributeValue = property.GetCustomAttributeValue<RegularExpressionAttribute, string>("Pattern");
                var value          = property.GetValue(objectUT, null); 
            }

            Assert.Equal(4, properties.Length);
        }

        private class ObjectUnderTest
        {
            public ObjectUnderTest()
            { }

            [RegularExpression("NAME")]
            public virtual string Name { get; internal set; }

            [RegularExpression("AGE")]
            public virtual int Age { get; internal set; }

            [RegularExpression("WEIGHT")]
            public virtual decimal Weight { get; internal set; }

            [RegularExpression("IS_OK")]
            public virtual bool IsOK { get; internal set; }
        }
    }
}
