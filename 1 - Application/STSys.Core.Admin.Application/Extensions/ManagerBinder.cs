using Microsoft.AspNetCore.Mvc.ModelBinding;
using STSys.Core.Admin.Application.ViewModels;
using STSys.Core.Domain.Interfaces.Repository;
using STSys.Core.Users.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace STSys.Core.Admin.Application.Extensions
{
    public class ManagerBinder : IModelBinder
    {
        private readonly IRepositoryEF<ManagerEntities> _repositoryEF;
        public ManagerBinder(IRepositoryEF<ManagerEntities> repositoryEF)
        {
            this._repositoryEF = repositoryEF;
        }
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ManagerViewModel viewModel = new ManagerViewModel();
            foreach (var Property in typeof(ManagerViewModel).GetProperties())
            {
                PropertyInfo info = viewModel.GetType().GetProperty(Property.Name);
                var value = bindingContext.ValueProvider.GetValue(Property.Name);
                if (Property.Name.Equals("Account"))
                {
                    var count = _repositoryEF.Count(s => s.Account.Equals(value));
                    if (count > 0)
                    {
                        bindingContext.ModelState.AddModelError("Account", "该账户已存在");
                        return Task.CompletedTask;
                    }
                    else
                    {
                        info.SetValue(viewModel, value);
                    }
                }
                else
                {
                    info.SetValue(viewModel, value, null);
                }
            }
            bindingContext.Result = ModelBindingResult.Success(viewModel);



            //string ParameterName = bindingContext.ModelMetadata.ParameterName;

            //string val = bindingContext.HttpContext.Request.Form[ParameterName];

            //if (String.IsNullOrEmpty(val))
            //{
            //    val = bindingContext.HttpContext.Request.Query[ParameterName];
            //}




            ////根据名称获取传递的值
            //ValueProviderResult ValueResult = bindingContext.ValueProvider.GetValue(ParameterName);
            ////从请求的参数集合中，拿到第一个参数
            //string value11 = ValueResult.FirstValue;

            //var modelName = bindingContext.ModelName;
            //var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
            //if (valueProviderResult == ValueProviderResult.None)
            //{
            //    return Task.CompletedTask;
            //}
            //bindingContext.ModelState.SetModelValue(modelName,valueProviderResult);
            //var value = valueProviderResult.FirstValue;
            //if (string.IsNullOrEmpty(value))
            //{
            //    return Task.CompletedTask;
            //}
            //var count = _repositoryEF.Count(s => s.Account.Equals(value));
            //if (count > 0)
            //{
            //    bindingContext.ModelState.AddModelError("Account", "该账户已存在");
            //    return Task.CompletedTask;
            //}
            //var result = bindingContext.Result;
            //bindingContext.Result = ModelBindingResult.Success(value);
            return Task.CompletedTask;
        }
    }
}
