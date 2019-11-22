using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STSys.Core.Admin.Application.Extensions
{
    public static class DropDownListEntensions
    {
        public static IEnumerable<SelectListItem> ColumnIdentify(bool? isdefault = false, string value = null)
        {
            if (isdefault.Value)
                return new List<SelectListItem>() { new SelectListItem() { Text = "请选择", Value = "", Selected = true } }.Union(EnumExtend.ToListItemDesc<E_Column_identify>());
            else
                return EnumExtend.ToListItemDesc<E_Column_identify>();
        }
        public static IEnumerable<SelectListItem> CommonEnum<T>(bool? isdefault = false, string value = null)
        {
            if (isdefault.Value)
                return new List<SelectListItem>() { new SelectListItem() { Text = "请选择", Value = "", Selected = true } }.Union(EnumExtend.ToListItem<T>().Select(s => new SelectListItem() { Text = s.Text, Value = s.Value, Selected = s.Value == value }));
            else
                return EnumExtend.ToListItem<T>().Select(s => new SelectListItem() { Text = s.Text, Value = s.Value, Selected = s.Value == value });
        }
    }
}
