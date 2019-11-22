using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Common.Utility
{
    /// <summary>
    /// 对象复制(反射)
    /// </summary>
    public class TypeCopy
    {
        /// <summary>
        /// 对象转换（不支持多层结构）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static T Copy<T>(object source, T instance = default(T)) where T : class
        {
            if (source == null)
            {
                return default(T);
            }
            if (instance == null)
                instance = Activator.CreateInstance<T>();
            var instanceType = instance.GetType();// typeof(T);//
            PropertyInfo[] properties = source.GetType().GetProperties();
            foreach (PropertyInfo item in properties)
            {
                PropertyInfo property = instanceType.GetProperty(item.Name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (property != null)
                {
                    var cVal = item.GetValue(source, null);
                    if (cVal != null)
                    {
                        SetObjVal(cVal, instance, property);
                    }
                }
            }
            return instance;
        }//end method


        public static T Copy<T, D>(object source, T instance = default(T))
            where T : class
            where D : class
        {
            if (source == null)
            {
                //return default(T);
                return Activator.CreateInstance<T>();
            }
            if (instance == null)
                instance = Activator.CreateInstance<T>();
            var instanceType = instance.GetType(); // typeof(T);//
            PropertyInfo[] properties = source.GetType().GetProperties();
            foreach (PropertyInfo item in properties)
            {
                PropertyInfo property = instanceType.GetProperty(item.Name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (property != null)
                {
                    var cVal = item.GetValue(source, null);
                    if (cVal != null)
                    {
                        //DateTime与string互转
                        if (cVal is D)
                        {
                           property.SetValue(instance, Copy<D>(cVal), null);
                        }
                        else
                            SetObjVal(cVal, instance, property);
                    }
                }
            }
            return instance;
        }

        private static void SetObjVal(object cVal, object instance, PropertyInfo property)
        {
            if (cVal != null && instance != null && property != null)
            {
                //DateTime与string互转
                if (cVal is DateTime && property.PropertyType == typeof(string))
                    property.SetValue(instance, ((DateTime)cVal).ToString(), null);
                else if (cVal is string && property.PropertyType == typeof(DateTime))
                    property.SetValue(instance,(cVal==null|| string.IsNullOrWhiteSpace(cVal.ToString())) ? DateTime.MinValue :TypeHelper.ObjectToDateTime(cVal), null);
                //decimal与double互转
                else if (cVal is decimal && property.PropertyType == typeof(double))
                    property.SetValue(instance, Convert.ToDouble((decimal)cVal), null);
                else if (cVal is double && property.PropertyType == typeof(decimal))
                    property.SetValue(instance, Convert.ToDecimal((double)cVal), null);
                //stirng与Guid互转
                else if (cVal is string && property.PropertyType == typeof(Guid))
                    property.SetValue(instance,cVal==null|| string.IsNullOrWhiteSpace(cVal.ToString()) ? Guid.Empty : Guid.Parse((string)cVal), null);
                else if (cVal is Guid && property.PropertyType == typeof(string))
                    property.SetValue(instance, ((Guid)cVal).ToString(), null);
                else
                    property.SetValue(instance, cVal, null); 
            }
        }

        public static List<T> CopyList<T, D>(IList<D> lst) where T : class
        {
            var result = new List<T>();
            if (lst == null)
                return result; //解决服务端不能返回null
            foreach (var obj in lst)
            {
                var ent = Copy<T>(obj, default(T));
                if (ent != null)
                    result.Add(ent);
            }
            return result;
        }
        public static List<T> CopyList<T, V, D>(IList<D> lst)
            where T : class
            where V : class
        {
            var result = new List<T>();
            if (lst == null)
                return result; //解决服务端不能返回null
            foreach (var obj in lst)
            {
                var ent = Copy<T, V>(obj, default(T));
                if (ent != null)
                    result.Add(ent);
            }
            return result;
        }

    }

}
