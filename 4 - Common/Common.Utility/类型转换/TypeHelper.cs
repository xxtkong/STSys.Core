using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Utility
{
    public class TypeHelper
    {
        /// <summary>
        /// string型转换为Long型
        /// </summary>
        /// <param name="source">字符串</param>
        /// <param name="defValue">默认值</param>
        /// <returns></returns>
        public static long StrToInt64(string source, long defValue)
        {
            long result = 0;
            try
            {
                result = Convert.ToInt64(source);
            }
            catch
            {
                result = defValue;
            }
            return result;
        }

        /// <summary>
        /// string型转换为bool型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的bool类型结果</returns>
        public static bool StrToBool(object expression, bool defValue)
        {
            if (expression != null)
                return StrToBool(expression.ToString(), defValue);

            return defValue;
        }

        /// <summary>
        /// string型转换为bool型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的bool类型结果</returns>
        public static bool StrToBool(string expression, bool defValue)
        {
            if (expression != null)
            {
                if (string.Compare(expression, "true", true) == 0)
                    return true;
                else if (string.Compare(expression, "false", true) == 0)
                    return false;
            }
            return defValue;
        }

        /// <summary>
        /// 将对象转换为Int32类型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static int ObjectToInt(object expression)
        {
            return ObjectToInt(expression, 0);
        }

        /// <summary>
        /// 将对象转换为Int32类型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static int ObjectToInt(object expression, int defValue)
        {
            if (expression != null)
                return StrToInt(expression.ToString(), defValue);

            return defValue;
        }

        /// <summary>
        /// 将对象转换为Int64类型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static long ObjectToInt64(object expression, long defValue)
        {
            if (expression != null)
                return StrToInt64(expression.ToString(), defValue);

            return defValue;
        }

        public static string ObjectToStirng(object expression)
        {
            if (expression == null)
                return String.Empty;

            return expression.ToString();
        }

        /// <summary>
        /// 将对象转换为Int32类型,转换失败返回0
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <returns>转换后的int类型结果</returns>
        public static int StrToInt(string str)
        {
            return StrToInt(str, 0);
        }

        /// <summary>
        /// 将对象转换为Int32类型
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static int StrToInt(string str, int defValue)
        {
            if (string.IsNullOrEmpty(str) || str.Trim().Length >= 11 || !Regex.IsMatch(str.Trim(), @"^([-]|[0-9])[0-9]*(\.\w*)?$"))
                return defValue;

            int rv;
            if (Int32.TryParse(str, out rv))
                return rv;

            return Convert.ToInt32(StrToFloat(str, defValue));
        }


        /// <summary>
        /// string型转换为float型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static float StrToFloat(object strValue, float defValue)
        {
            if ((strValue == null))
                return defValue;

            return StrToFloat(strValue.ToString(), defValue);
        }

        /// <summary>
        /// string型转换为float型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static float ObjectToFloat(object strValue, float defValue)
        {
            if ((strValue == null))
                return defValue;

            return StrToFloat(strValue.ToString(), defValue);
        }

        /// <summary>
        /// string型转换为float型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static float ObjectToFloat(object strValue)
        {
            return ObjectToFloat(strValue.ToString(), 0);
        }

        /// <summary>
        /// string型转换为float型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <returns>转换后的int类型结果</returns>
        public static float StrToFloat(object strValue)
        {
            if ((strValue == null))
                return 0;

            return StrToFloat(strValue.ToString(), 0);
        }

        /// <summary>
        /// string型转换为float型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static float StrToFloat(string strValue, float defValue)
        {
            if ((strValue == null))
                return defValue;

            float intValue = defValue;
            if (strValue != null)
            {
                //bool IsFloat = Regex.IsMatch(strValue, @"^([-]|[0-9])[0-9]*(\.\w*)?$");
                //if (IsFloat)
                if (!float.TryParse(strValue, out intValue))
                    return defValue;
            }
            return intValue;
        }

        /// <summary>
        /// string型转换为decimal型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的decimal类型结果</returns>
        public static decimal ObjectToDecimal(object strValue, decimal defValue)
        {
            if ((strValue == null))
                return defValue;

            return StrToDecimal(strValue.ToString(), defValue);
        }

        /// <summary>
        /// string型转换为decimal型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的decimal类型结果</returns>
        public static decimal ObjectToDecimal(object strValue)
        {
            return ObjectToDecimal(strValue.ToString(), 0);
        }

        /// <summary>
        /// string型转换为decimal型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <returns>转换后的decimal类型结果</returns>
        public static decimal StrToDecimal(string strValue)
        {
            if ((strValue == null))
                return 0;

            return StrToDecimal(strValue.ToString(), 0);
        }

        /// <summary>
        /// string型转换为decimal型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的decimal类型结果</returns>
        public static decimal StrToDecimal(string strValue, decimal defValue)
        {
            if ((strValue == null))
                return defValue;

            decimal intValue = defValue;
            if (strValue != null)
            {
                //bool IsFloat = Regex.IsMatch(strValue, @"^([-]|[0-9])[0-9]*(\.\w*)?$");
                //if (IsFloat)
                if (!decimal.TryParse(strValue, out intValue))
                    return defValue;
            }
            return intValue;
        }

        /// <summary>
        /// 将对象转换为日期时间类型
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static DateTime StrToDateTime(string str, DateTime defValue)
        {
            if (!string.IsNullOrEmpty(str))
            {
                DateTime dateTime;
                if (DateTime.TryParse(str, out dateTime))
                    return dateTime;
            }
            return defValue;
        }

        /// <summary>
        /// 将对象转换为日期时间类型
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <returns>转换后的int类型结果</returns>
        public static DateTime StrToDateTime(string str)
        {
            return StrToDateTime(str, DateTime.Now);
        }

        /// <summary>
        /// 将对象转换为日期时间类型
        /// </summary>
        /// <param name="obj">要转换的对象</param>
        /// <returns>转换后的int类型结果</returns>
        public static DateTime ObjectToDateTime(object obj)
        {
            return obj == null ? DateTime.Now : StrToDateTime(obj.ToString());
        }

        /// <summary>
        /// 将对象转换为日期时间类型
        /// </summary>
        /// <param name="obj">要转换的对象</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static DateTime ObjectToDateTime(object obj, DateTime defValue)
        {
            return StrToDateTime(obj.ToString(), defValue);
        }
        /// <summary>
        /// 日期
        /// </summary>
        /// <param name="date"></param>
        /// <returns>中文的星期几</returns>
        public static string DateToWeek(DateTime date)
        {
            string Week = "";
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Friday: Week = "周五";
                    break;
                case DayOfWeek.Monday: Week = "周一";
                    break;
                case DayOfWeek.Saturday: Week = "周六";
                    break;
                case DayOfWeek.Sunday: Week = "周日";
                    break;
                case DayOfWeek.Thursday: Week = "周四";
                    break;
                case DayOfWeek.Tuesday: Week = "周二";
                    break;
                case DayOfWeek.Wednesday: Week = "周三";
                    break;
                default: Week = "";
                    break;
            }
            return Week;
        }

        /// <summary>
        /// 枚举类数据的校验转换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="val"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static int IntToEnumValue<T>(int val, T defaultVal, bool isThrowError = false)
        {
            if (defaultVal is Enum)
            {
                if (Enum.IsDefined(typeof(T), val))
                    return TypeHelper.ObjectToInt(val);
                else
                {
                    if (isThrowError)
                        throw new Exception("值'" + val + "'不是枚举'" + typeof(T).ToString() + "'的有效数据");
                }
                return Convert.ToInt32(defaultVal);
            }
            else
            {
                if (isThrowError)
                    throw new Exception("类型'" + typeof(T).ToString() + "'不是一个枚举类型");
                return -1;
            }
        }

        /// <summary>
        /// 20080201000000 转换成2008-02-01 00:00:00 
        /// </summary>
        /// <param name="str">需要转换的字符串</param>
        /// <param name="dtstr">转换失败的字符串</param>
        /// <returns></returns>
        public static string StringToDateString(string str, string dtstr)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                string yyyy = str.Substring(0, 4);
                string MM = str.Substring(4, 2);
                string dd = str.Substring(6, 2);
                string HH = str.Substring(8, 2);
                string mm = str.Substring(10, 2);
                string ss = str.Substring(12, 2);
                sb.Append(yyyy).Append("-").Append(MM).Append("-").Append(dd).Append(" ").Append(HH).Append(":").Append(mm).Append(":").Append(ss);
            }
            catch (Exception)
            {
                sb.Append(dtstr);
            }
            return sb.ToString();
        }


        /// <summary>
        /// 2008-02-01 00:00:00 转换成 20080201000000 
        /// </summary>
        /// <param name="str">需要转换的字符串</param>
        /// <param name="dtstr">转换失败的字符串</param>
        /// <returns></returns>
        public static string DateStringToString(string str, string dtstr)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                string yyyy = str.Substring(0, 4);
                string MM = str.Substring(5, 2);
                string dd = str.Substring(8, 2);
                string HH = str.Substring(11, 2);
                string mm = str.Substring(14, 2);
                string ss = str.Substring(17, 2);
                sb.Append(yyyy).Append(MM).Append(dd).Append(HH).Append(mm).Append(ss);
            }
            catch (Exception)
            {
                sb.Append(dtstr);
            }
            return sb.ToString();
        }

    }
}
