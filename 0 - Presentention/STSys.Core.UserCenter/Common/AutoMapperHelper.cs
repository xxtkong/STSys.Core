using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace STSys.Core.UserCenter.Common
{
    public static class AutoMapperHelper
    {
        /// <summary>
        /// 实体类转KeyValuePair集合
        /// </summary>
        /// <returns></returns>
        public static List<KeyValuePair<String, String>> MapToKeyValuePair<T>(this T obj)
        {
            if (obj == null) return new List<KeyValuePair<string, string>>();
            List<KeyValuePair<String, String>> models = new List<KeyValuePair<string, string>>();
            var type = obj.GetType();
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var item in props)
            {
                if (item.GetValue(obj, null) != null)
                {
                    var keyValuePair0 = new KeyValuePair<string, string>(item.Name, item.GetValue(obj, null).ToString());
                    models.Add(keyValuePair0);
                }
            }
            return models;
        }
    }
}
