using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace STSys.Core.Admin.Application.Validation
{
    public class MoneyValidationAttribute : ValidationAttribute, IClientModelValidator
    {
        public override bool IsValid(object value)
        {
            if (value == null) return false;
            bool match = Regex.IsMatch(value.ToString(), @"^(-)?(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$");
            return (bool)match;
        }
        public override string FormatErrorMessage(string name)
        {
            if (string.IsNullOrEmpty(name) && !IsValid(name))
                return "请输入正确的金额";
            return name;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            var errorMessage = FormatErrorMessage(context.ModelMetadata.GetDisplayName());
            MergeAttribute(context.Attributes, "data-val-cannotbered", errorMessage);
            MergeAttribute(context.Attributes, "data-val-number", this.ErrorMessage);
        }
        private bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
        {
            if (attributes.ContainsKey(key))
            {
                return false;
            }
            attributes.Add(key, value);
            return true;
        }
    }
}
