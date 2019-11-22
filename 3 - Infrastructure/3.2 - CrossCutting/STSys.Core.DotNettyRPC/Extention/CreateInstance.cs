using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace STSys.Core.DotNettyRPC.Extention
{
    public static class CreateInstance
    {
        public static Func<T, object> CreateInstanceDelegate<T>(this Type type)
        {
            Type paramType = typeof(T);
            var construtor = type.GetConstructor(new Type[] { paramType });
            var param = new ParameterExpression[] { Expression.Parameter(paramType, "arg") };

            NewExpression newExp = Expression.New(construtor, param);
            Expression<Func<T, object>> lambdaExp =
                Expression.Lambda<Func<T, object>>(newExp, param);
            Func<T, object> func = lambdaExp.Compile();
            return func;
        }
    }
}
