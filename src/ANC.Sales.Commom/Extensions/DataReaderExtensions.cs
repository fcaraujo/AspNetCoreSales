using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace ANC.Sales.Commom.Extensions
{
    public static class DataReaderExtensions
    {
        /// <summary>
        /// This method helps to dump all column/values for a DataReader
        /// </summary>
        /// <param name="reader"></param>
        public static void DebugValues(this IDataReader reader)
        {
            var listValues = new List<string>();
            while (reader.Read())
            {
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    try
                    {
                        var name  = reader.GetName(i);
                        var value = reader.GetValue(i);

                        var debugValue = $"ITEM   : {i}\n" +
                                         $"TYPE   : {value.GetType()}\n" +
                                         $"COLUMN : {name}\n" +
                                         $"VALUE  : {value}";

                        listValues.Add(debugValue);
                    }
                    catch (Exception ex)
                    {
                        listValues.Add($"ITEM   : {i}\n" + ex.ToString());
                    }
                }
            }

            Debug.WriteLine($"Dump Values:\n{string.Join("\n\n", listValues)}");
        }
    }
}
