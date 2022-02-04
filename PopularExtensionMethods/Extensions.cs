using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;

namespace PopularExtensionMethods
{
    #region Extensions
    public static class Extensions
    {
        #region ToDecimal

        /// <summary>
        /// To Decimal, if error return 0
        /// double a = str.ToDecimal();
        /// NumberDecimalSeparator = ,
        /// NumberGroupSeparator = .
        /// </summary>
        /// <param name="number">String value</param>
        /// <returns></returns>
        public static decimal ToDecimal(this string number)
        {
            NumberFormatInfo provider = new NumberFormatInfo
            {
                NumberDecimalSeparator = ",",
                NumberGroupSeparator = "."
            };
            decimal resultNum = default(decimal);

            try
            {
                if (!string.IsNullOrEmpty(number))
                    resultNum = decimal.Parse(number, provider);
            }
            catch { }
            return resultNum;
        }


        /// <summary>
        /// To Decimal
        /// double a = str.ToDecimal(-1);
        /// NumberDecimalSeparator = ,
        /// NumberGroupSeparator = .
        /// </summary>
        /// <param name="number">String value</param>
        /// <param name="defaultValue">Default value</param>
        /// <returns></returns>
        public static decimal ToDecimal(this string number, decimal defaultValue)
        {
            NumberFormatInfo provider = new NumberFormatInfo
            {
                NumberDecimalSeparator = ",",
                NumberGroupSeparator = "."
            };
            decimal resultNum = defaultValue;

            try
            {
                if (!string.IsNullOrEmpty(number))
                    resultNum = decimal.Parse(number, provider);
            }
            catch { }
            return resultNum;
        }

        /// <summary>
        /// To decimal, if error return 0
        /// double a = str.ToDecimal(",",".");
        /// </summary>
        /// <param name="number">String value</param>
        /// <param name="NumberDecimal">NumberDecimal</param>
        /// <param name="NumberGroupSeperator">NumberGroupSeperator</param>
        /// <returns></returns>
        public static decimal ToDecimal(this string number, string NumberDecimal, string NumberGroupSeperator)
        {
            NumberFormatInfo provider = new NumberFormatInfo
            {
                NumberDecimalSeparator = NumberDecimal,
                NumberGroupSeparator = NumberGroupSeperator
            };

            decimal resultNum = default(decimal);
            try
            {
                if (!string.IsNullOrEmpty(number))
                    resultNum = Convert.ToDecimal(number, provider);
            }
            catch { }
            return resultNum;
        }

        /// <summary>
        /// To decimal
        /// double a = str.ToDecimal(-1, ",",".");
        /// </summary>
        /// <param name="number">String value</param>
        /// <param name="defaultValue">Default value</param>
        /// <param name="NumberDecimal">Number Decimal</param>
        /// <param name="NumberGroupSeperator">Number GroupSeperator</param>
        /// <returns></returns>
        public static decimal ToDecimal(this string number, decimal defaultValue, string NumberDecimal, string NumberGroupSeperator)
        {
            NumberFormatInfo provider = new NumberFormatInfo
            {
                NumberDecimalSeparator = NumberDecimal,
                NumberGroupSeparator = NumberGroupSeperator
            };

            decimal resultNum = defaultValue;
            try
            {
                if (!string.IsNullOrEmpty(number))
                    resultNum = Convert.ToDecimal(number, provider);
            }
            catch { }
            return resultNum;
        }

        #endregion

        #region ToDouble

        /// <summary>
        /// To Double, if error return 0
        /// double a = str.ToDouble();
        /// NumberDecimalSeparator = ,
        /// NumberGroupSeparator = .
        /// </summary>
        /// <param name="number">String value</param>
        /// <returns></returns>
        public static double ToDouble(this string number)
        {
            NumberFormatInfo provider = new NumberFormatInfo
            {
                NumberDecimalSeparator = ",",
                NumberGroupSeparator = "."
            };
            double resultNum = default(double);

            try
            {
                if (!string.IsNullOrEmpty(number))
                    resultNum = double.Parse(number, provider);
            }
            catch { }
            return resultNum;
        }


        /// <summary>
        /// To Double
        /// double a = str.ToDouble(-1);
        /// NumberDecimalSeparator = ,
        /// NumberGroupSeparator = .
        /// </summary>
        /// <param name="number">String value</param>
        /// <param name="defaultValue">Default value</param>
        /// <returns></returns>
        public static double ToDouble(this string number, double defaultValue)
        {
            NumberFormatInfo provider = new NumberFormatInfo
            {
                NumberDecimalSeparator = ",",
                NumberGroupSeparator = "."
            };
            double resultNum = defaultValue;

            try
            {
                if (!string.IsNullOrEmpty(number))
                    resultNum = double.Parse(number, provider);
            }
            catch { }
            return resultNum;
        }

        /// <summary>
        /// To double, if error return 0
        /// double a = str.ToDouble(",",".");
        /// </summary>
        /// <param name="number">String value</param>
        /// <param name="NumberDecimal">NumberDecimal</param>
        /// <param name="NumberGroupSeperator">NumberGroupSeperator</param>
        /// <returns></returns>
        public static double ToDouble(this string number, string NumberDecimal, string NumberGroupSeperator)
        {
            NumberFormatInfo provider = new NumberFormatInfo
            {
                NumberDecimalSeparator = NumberDecimal,
                NumberGroupSeparator = NumberGroupSeperator
            };

            double resultNum = default(double);
            try
            {
                if (!string.IsNullOrEmpty(number))
                    resultNum = Convert.ToDouble(number, provider);
            }
            catch { }
            return resultNum;
        }

        /// <summary>
        /// To double, if error return 0
        /// double a = str.ToDouble(-1, ",",".");
        /// </summary>
        /// <param name="number">String value</param>
        /// <param name="defaultValue">Default value</param>
        /// <param name="NumberDecimal">Number Decimal</param>
        /// <param name="NumberGroupSeperator">Number GroupSeperator</param>
        /// <returns></returns>
        public static double ToDouble(this string number, double defaultValue, string NumberDecimal, string NumberGroupSeperator)
        {
            NumberFormatInfo provider = new NumberFormatInfo
            {
                NumberDecimalSeparator = NumberDecimal,
                NumberGroupSeparator = NumberGroupSeperator
            };

            double resultNum = defaultValue;
            try
            {
                if (!string.IsNullOrEmpty(number))
                    resultNum = Convert.ToDouble(number, provider);
            }
            catch { }
            return resultNum;
        }

        #endregion

        #region ConvertTo
        /// <summary>
        /// Convert To
        /// int a= str.ConvertTo<int>();
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ConvertTo<T>(this object value)
        {
            return ConvertTo(value, default(T));
        }

        /// <summary>
        /// Convert To
        /// int a= str.ConvertTo<int>(-1);
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="value"></param>
        /// <param name="defaultValue">Default Value</param>
        /// <returns></returns>
        public static T ConvertTo<T>(this object value, T defaultValue)
        {
            if (value == DBNull.Value)
            {
                return defaultValue;
            }

            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch { return defaultValue; }
        }
        #endregion

        #region IsNullOrEmpty
        /// <summary>
        /// Is Null or Empty
        /// bool a = str.IsNullOrEmpty();
        /// </summary>
        /// <param name="prmInput">Parameter</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this object prmInput)
        {
            if (prmInput == null)
                return true;
            else
            {
                if (string.IsNullOrEmpty(prmInput.ToString()))
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// Is Null or Empty Including Space Character
        /// bool a = str.IsNullOrEmpty(true);
        /// </summary>
        /// <param name="prmInput">Parameter</param>
        /// <param name="includingSpace">Including Space</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string prmInput, bool includingSpace)
        {
            if (prmInput == null)
                return true;
            else
            {
                if (string.IsNullOrEmpty(includingSpace ? prmInput.ToString().Trim() : prmInput.ToString()))
                    return true;
                else
                    return false;
            }

        }
        #endregion

        #region IsValidMail
        /// <summary>
        /// Mail Addresses is valid?
        /// bool a = str.IsValidMail();
        /// </summary>
        /// <param name="prmInput">Parameter</param>
        /// <returns></returns>
        public static bool IsValidMail(this string prmInput)
        {
            if (prmInput.IsNullOrEmpty(true))
                return false;
            else
            {
                const string pattern = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                  + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                  + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                  + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                  + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                  + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

                return Regex.IsMatch(prmInput, pattern);
            }
        }


        #endregion

        #region JSON

        #region IsValidJson
        /// <summary>
        /// Is this string suitable for JSON?
        /// bool a = str.IsValidJson();
        /// </summary>
        /// <param name="strInput">Parameter </param>
        /// <returns></returns>
        public static bool IsValidJson(this string strInput)
        {
            if (string.IsNullOrWhiteSpace(strInput)) return false;
            strInput = strInput.Trim();

            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]")))   //For array
            {
                try
                {
                    // valid
                    var obj = JContainer.Parse(strInput);
                    return true;
                }
                catch // not valid
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Deserialize_Object
        /// <summary>
        /// JSON string to Model type
        /// Students st = str.Deserialize_Object<Students>();
        /// </summary>
        /// <typeparam name="T">Model</typeparam>
        /// <param name="str"> JSON string</param>
        /// <returns></returns>
        public static T Deserialize_Object<T>(this string str)
        {
            //Students st = str.Deserialize_Object<Students>();

            object returnedList = null;
            try
            {
                if (str.IsValidJson())
                    returnedList = (T)JsonConvert.DeserializeObject(str, typeof(T));
            }
            catch (Exception) { returnedList = null; }

            return (T)returnedList;
        }
        #endregion

        #region Deserialize_ListObject
        /// <summary>
        /// JSON string to List Model type
        /// List<Students> stList = str.Deserialize_ListObject<Students>();
        /// </summary>
        /// <typeparam name="T">Model</typeparam>
        /// <param name="str">JSOn String</param>
        /// <returns></returns>
        public static List<T> Deserialize_ListObject<T>(this string str)
        {
            // List<Students> stList = str.Deserialize_ListObject<Students>();

            List<T> returnedList = null;
            try
            {
                if (str.IsValidJson())
                    returnedList = (List<T>)JsonConvert.DeserializeObject(str, typeof(List<T>));
            }
            catch (Exception) { returnedList = null; }

            return returnedList;
        }
        #endregion

        #region ToJson
        
        public static string ToJson<T>(this T instance)
        {
            return JsonConvert.SerializeObject(instance, JsonSettings.SerializerDefaults);
        }

        private static class JsonSettings
        {
            static readonly DefaultContractResolver _contractResolver =
                new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                };

            internal static JsonSerializerSettings SerializerDefaults { get; } =
                new JsonSerializerSettings
                {
                    DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate,
                    ContractResolver = _contractResolver,
                    Formatting = Formatting.Indented,
                    NullValueHandling = NullValueHandling.Ignore
                };
        }


        #endregion

        #endregion

        #region List

        #region HasElements
        /// <summary>
        /// Collection has elements? 
        /// bool a = list.HasElements();
        /// </summary>
        /// <param name="prmInput">Parameter </param>
        /// <returns></returns>
        public static bool HasElements(this ICollection prmInput)
        {
            if (prmInput != null && prmInput.Count > 0)
                return true;
            else
                return false;

        }
        #endregion

        #region DistinctBy
        /// <summary>
        /// Select the distinct values in the List
        /// SecondList = FirstList.DistinctBy(r => r.Name).ToList();
        /// </summary>
        /// <typeparam name="T">TSource</typeparam>
        /// <typeparam name="TKey">TKey</typeparam>
        /// <param name="source">Source</param>
        /// <param name="keySelector">Selector</param>
        /// <returns></returns>
        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector)
        {
            // List<Models> FirstList;
            // SecondList = FirstList.DistinctBy(r => r.Name).ToList();

            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (T element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
        #endregion

        #region RemoveDuplicates
        /// <summary>
        /// List<string> sss = new List<string> { "aa", "bb", "cc", "dd", "bb" };
        /// List<string> ssss = sss.RemoveDuplicates<string>();
        /// Remove duplicated records from lists
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static List<T> RemoveDuplicates<T>(this List<T> input)
        {
            Dictionary<T, int> uniqueStore = new Dictionary<T, int>();
            List<T> finalList = new List<T>();

            foreach (T currValue in input)
            {
                if (!uniqueStore.ContainsKey(currValue))
                {
                    uniqueStore.Add(currValue, 0);
                    finalList.Add(currValue);
                }
            }
            return finalList;
        }

        #endregion

        #region ToDataTable
        /// <summary>
        /// Collection to Datatable
        /// DataTable dt = stList.ToDataTable<Models>();
        /// </summary>
        /// <typeparam name="T">Model</typeparam>
        /// <param name="list">List</param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> list)
        {
            Type type = typeof(T);
            var properties = type.GetProperties();

            DataTable dataTable = new DataTable();
            foreach (PropertyInfo info in properties)
            {
                dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }

            foreach (T entity in list)
            {
                object[] values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(entity);
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
        #endregion

        #region FromDataTable
        /// <summary>
        /// List<Student> ss = dt.FromDataTable<Student>();
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> FromDataTable<T>(this DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
        #endregion

        #endregion

    }
    #endregion
}
