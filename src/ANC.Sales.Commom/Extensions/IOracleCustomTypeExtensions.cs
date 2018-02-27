using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System;
using System.Linq;

namespace ANC.Sales.Commom.Extensions
{
    public static class IOracleCustomTypeExtensions
    {
        /// <summary>
        /// This method will iterate through all properties marked with OracleObjectMappingAttribute and set it's values
        /// </summary>
        /// <param name="self"></param>
        /// <param name="objCon"></param>
        /// <param name="objUdt"></param>
        public static void SetObjectMappingProperties(this IOracleCustomType self, OracleConnection objCon, IntPtr objUdt)
        {
            // Get oracle mapping properties
            var properties = self.GetType()
                                  .GetProperties()
                                  .Where(p => p.IsDefined(typeof(OracleObjectMappingAttribute), false));

            // Set all values dynamicaly
            foreach (var property in properties)
            {
                var udtTypeName = property.GetCustomAttributeValue<OracleObjectMappingAttribute, string>("AttributeName");
                var value = property.GetValue(self);

                OracleUdt.SetValue(objCon, objUdt, udtTypeName, value);
            }
        }
    }
}
