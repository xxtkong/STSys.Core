using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace STSys.Core.Data.Repository.Dapper
{

    public static class CommonHelper<TEntity> where TEntity : class
    {


        public static KeyValuePair<string, List<string>> GetPropertiesUpdate(Expression<Func<TEntity, object[]>> expression, bool w = false)
        {
            StringBuilder cols = new StringBuilder();
            List<string> param = new List<string>();
            int i = 0;
            foreach (MemberExpression exp in GetExpressionMembers(expression))
            {
                string paramName = string.Format("@p_{0}", exp.Member.Name);
                if (!string.IsNullOrEmpty(exp.Member.Name))
                {
                    if (w)
                        cols.AppendFormat("{0} = {1} and", exp.Member.Name, paramName);
                    else
                        cols.AppendFormat("{0} = {1},", exp.Member.Name, paramName);
                    param.Add(paramName);
                    i++;
                }
            }
            return new KeyValuePair<string, List<string>>(cols.ToString().TrimEnd(','), param);
        }

        public static IList<MemberExpression> GetExpressionMembers(Expression<Func<TEntity, object[]>> expression)
        {
            IList<MemberExpression> list = new List<MemberExpression>();
            if (expression.Body.NodeType == ExpressionType.NewArrayInit)
            {
                var arrExp = (expression.Body as NewArrayExpression).Expressions;
                foreach (Expression exp in arrExp)
                {
                    MemberExpression me;
                    if (exp.NodeType == ExpressionType.Convert)
                    {
                        me = (exp as UnaryExpression).Operand as MemberExpression;
                    }
                    else
                    {
                        me = exp as MemberExpression;
                    }
                    list.Add(me);
                }
            }
            return list;
        }


        public static dynamic GetParameters(string[] pName, object[] pValue)
        {
            int count = pName.Count();
            dynamic info = new System.Dynamic.ExpandoObject();
            var dic = (IDictionary<string, object>)info;
            for (int i = 0; i < count; i++)
            {
                dic.Add(new KeyValuePair<string, object>("@" + pName[i], pValue[i]));
            }
            return dic;

            //List<SqlParameter> pList = new List<SqlParameter>();
            //int count = pName.Count();
            //for (int i = 0; i < count; i++)
            //{
            //    //验证字段
            //    var op = new System.Data.SqlClient.SqlParameter();
            //    op.ParameterName = pName[i];
            //    op.Value = pValue[i];
            //    if (op.Value == null && (op.Direction == ParameterDirection.Input || op.Direction == ParameterDirection.InputOutput))
            //    {
            //        op.Value = DBNull.Value;
            //    }
            //    pList.Add(op);
            //}
            //return pList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="par"></param>
        /// <returns></returns>
        public static object GetParameters(List<KeyValuePair<string,object>> par ) {

            dynamic info = new System.Dynamic.ExpandoObject();
            var dic = (IDictionary<string, object>)info;
            for (int i = 0; i < par.Count; i++)
            {
                dic.Add(new KeyValuePair<string, object>("@" + par[i].Key, par[i].Value));
            }
            return  (object)dic;
        }

        public static dynamic GetOraParameters(KeyValuePair<string, KeyValuePair<string[], object[]>> command)
        {
            return GetParameters(command.Value.Key, command.Value.Value);
        }

        public static KeyValuePair<string, KeyValuePair<string[], object[]>> GetPropertiesFirst(Expression<Func<TEntity, bool>> where)
        {
            ConditionBuilder whereBuilder = new ConditionBuilder((typeof(TEntity)).ToString());
            whereBuilder.Build(where.Body);
            List<string> param = new List<string>();
            List<object> pvalue = new List<object>();
            param.AddRange(whereBuilder.WhereParam);
            pvalue.AddRange(whereBuilder.Arguments);
            string sql = string.Format("select *from {0} WHERE {1}", (typeof(TEntity)).ToString().Split('.').Last(),  whereBuilder.Condition);
            KeyValuePair<string, KeyValuePair<string[], object[]>> kvp = new KeyValuePair<string, KeyValuePair<string[], object[]>>(sql, new KeyValuePair<string[], object[]>(param.ToArray(), pvalue.ToArray()));
            return kvp;
        }

        public static KeyValuePair<string, KeyValuePair<string[], object[]>> GetPropertiesDelete(Expression<Func<TEntity, bool>> where)
        {
            ConditionBuilder whereBuilder = new ConditionBuilder((typeof(TEntity)).ToString());
            whereBuilder.Build(where.Body);
            List<string> param = new List<string>();
            List<object> pvalue = new List<object>();
            param.AddRange(whereBuilder.WhereParam);
            pvalue.AddRange(whereBuilder.Arguments);
            string sql = string.Format("delete from  {0} WHERE {1}", (typeof(TEntity)).ToString().Split('.').Last(), whereBuilder.Condition);
            KeyValuePair<string, KeyValuePair<string[], object[]>> kvp = new KeyValuePair<string, KeyValuePair<string[], object[]>>(sql, new KeyValuePair<string[], object[]>(param.ToArray(), pvalue.ToArray()));
            return kvp;
        }

        public static KeyValuePair<string, KeyValuePair<string[], object[]>> GetPropertiesUpdate(Expression<Func<TEntity>> expression, Expression<Func<TEntity, bool>> where)
        {
            ConditionBuilder whereBuilder = new ConditionBuilder((typeof(TEntity)).ToString());
            whereBuilder.Build(where.Body);
            var updateExp = expression.Body as MemberInitExpression;
            var updateList = updateExp.Bindings.Cast<MemberAssignment>().Select(a => new
            {
                Name = a.Member.Name,
                Value = GetMemeberValue(a)
            });
            StringBuilder sqlUpdate = new StringBuilder();
            int i = 0;
            List<string> param = new List<string>();
            List<object> pvalue = new List<object>();
            foreach (var item in updateList)
            {
                string column = item.Name;
                string pname = string.Format("p{0}__{1}", i.ToString(), column);
                if (!string.IsNullOrEmpty(column))
                {
                    sqlUpdate.AppendFormat(" {0} = @{1},", column, pname);
                    param.Add(pname);
                    //zsp  空时间更新为空
                    if (item.Value != null && item.Value is DateTime && ((DateTime)item.Value) == DateTime.MinValue)
                    {
                        pvalue.Add(null);
                    }
                    else
                    {
                        pvalue.Add(item.Value);
                    }
                    i++;
                }
            }
            param.AddRange(whereBuilder.WhereParam);
            pvalue.AddRange(whereBuilder.Arguments);
            string sql = string.Format("UPDATE {0} SET {1} WHERE {2}", (typeof(TEntity)).ToString().Split('.').Last(), sqlUpdate.ToString().TrimEnd(','), whereBuilder.Condition);
            KeyValuePair<string, KeyValuePair<string[], object[]>> kvp = new KeyValuePair<string, KeyValuePair<string[], object[]>>(sql, new KeyValuePair<string[], object[]>(param.ToArray(), pvalue.ToArray()));
            return kvp;

        }

        /// <summary>
        /// 复制单个对象
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static TEntity Copy(object model)
        {
            if (model == null)
            {
                return default(TEntity);
            }
            TEntity target = Activator.CreateInstance<TEntity>();
            Type targetType = target.GetType();
            PropertyInfo[] perties = model.GetType().GetProperties();
            foreach (var item in perties)
            {
                var per = targetType.GetProperty(item.Name, BindingFlags.IgnoreCase | BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                if (per != null && per.CanWrite)
                {
                    per.SetValue(target, item.GetValue(model, null), null);
                }
            }

            return target;
        }

        public static object GetMemeberValue(MemberAssignment assgin)
        {
            if (assgin.Expression is ConstantExpression)
            {
                return (assgin.Expression as ConstantExpression).Value;
            }
            LambdaExpression lambda = Expression.Lambda(assgin.Expression);
            Delegate fn = lambda.Compile();
            return Expression.Constant(fn.DynamicInvoke(null), assgin.Expression.Type).Value;
        }


    }

    internal class ConditionBuilder : ExpressionVisitor
    {
        internal ConditionBuilder(string typeName)
        {
            m_typeName = typeName;
            WhereParam = new List<string>();
        }

        private string m_typeName;
        private List<object> m_arguments;
        private Stack<string> m_conditionParts;
        public IList<string> WhereParam { get; set; }
        public string Condition { get; private set; }


        public object[] Arguments { get; private set; }
        public string LastColumn { get; private set; }

        public void Build(Expression expression)
        {
            PartialEvaluator evaluator = new PartialEvaluator();
            Expression evaluatedExpression = evaluator.Eval(expression);
            this.m_arguments = new List<object>();
            this.m_conditionParts = new Stack<string>();
            try
            {
                this.Visit(evaluatedExpression);
            }
            catch (Exception ex)
            {
            }

            this.Arguments = this.m_arguments.ToArray();
            this.Condition = this.m_conditionParts.Count > 0 ? this.m_conditionParts.Pop() : null;
        }

        protected override Expression VisitConstant(ConstantExpression c)
        {
            if (c == null) return c;
            this.m_arguments.Add(c.Value);
            string wParam = String.Format("wp{0}__{1}", this.m_arguments.Count - 1, LastColumn);
            this.m_conditionParts.Push("@" + wParam);
            WhereParam.Add(wParam);
            return c;
        }
        protected override Expression VisitBinary(BinaryExpression b)
        {
            if (b == null) return b;

            string opr;
            switch (b.NodeType)
            {
                case ExpressionType.Equal:
                    opr = "=";
                    break;
                case ExpressionType.NotEqual:
                    opr = "<>";
                    break;
                case ExpressionType.GreaterThan:
                    opr = ">";
                    break;
                case ExpressionType.GreaterThanOrEqual:
                    opr = ">=";
                    break;
                case ExpressionType.LessThan:
                    opr = "<";
                    break;
                case ExpressionType.LessThanOrEqual:
                    opr = "<=";
                    break;
                case ExpressionType.AndAlso:
                    opr = "AND";
                    break;
                case ExpressionType.OrElse:
                    opr = "OR";
                    break;
                case ExpressionType.Add:
                    opr = "+";
                    break;
                case ExpressionType.Subtract:
                    opr = "-";
                    break;
                case ExpressionType.Multiply:
                    opr = "*";
                    break;
                case ExpressionType.Divide:
                    opr = "/";
                    break;
                default:
                    throw new NotSupportedException(b.NodeType + " is not supported.");
            }

            this.Visit(b.Left);
            this.Visit(b.Right);

            string right = this.m_conditionParts.Pop();
            string left = this.m_conditionParts.Pop();

            string condition = String.Format("({0} {1} {2})", left, opr, right);
            this.m_conditionParts.Push(condition);
            return b;
        }

        protected override Expression VisitMember(MemberExpression m)
        {
            if (m == null) return m;
            PropertyInfo propertyInfo = m.Member as PropertyInfo;
            if (propertyInfo == null) return m;
            string column = propertyInfo.Name;
            if (!string.IsNullOrEmpty(column))
            {
                this.m_conditionParts.Push(column);
                LastColumn = column;
            }
            return m;
        }
        protected override Expression VisitMethodCall(MethodCallExpression m)
        {
            if (m == null) return m;

            this.Visit(m.Object);
            this.Visit(m.Arguments[0]);
            string right = this.m_conditionParts.Pop();
            string left = this.m_conditionParts.Pop();
            var value = this.m_arguments.Last().ToString();
            string format = "({0} LIKE {1})";
            switch (m.Method.Name)
            {
                case "StartsWith":
                    value += "%";
                    break;
                case "Contains":
                    //if (this.m_arguments.Last().GetType().FullName.Contains("System.Collections.Generic"))
                    //{ 
                    //    value = ZWCQ.FrameWork.Base.Utils.StringHelper.ToString(this.m_arguments.Last() as List<int>, ",");
                    //    format = "(" + right + " in(" + value + "))"; 
                    //}
                    //else
                    //{
                    //    value = "%" + value + "%";
                    //}
                    value = "%" + value + "%";
                    break;
                case "EndsWith":
                    value = "%" + value;
                    break;
                //case "IsNullOrEmpty":
                //    {
                //        format = "(" + right + " is null or " + right + "='')"; 
                //        value = "";
                //    }
                //    break;
                default:
                    throw new NotSupportedException(m.Method.Name + " is not supported!");
            }
            this.m_arguments.RemoveAt(this.m_arguments.Count() - 1);
            this.m_arguments.Add(value);
            this.m_conditionParts.Push(String.Format(format, left, right));
            return m;
        }

    }

    public class PartialEvaluator : ExpressionVisitor
    {
        private Func<Expression, bool> m_fnCanBeEvaluated;
        private HashSet<Expression> m_candidates;

        public PartialEvaluator()
            : this(CanBeEvaluatedLocally)
        { }

        public PartialEvaluator(Func<Expression, bool> fnCanBeEvaluated)
        {
            this.m_fnCanBeEvaluated = fnCanBeEvaluated;
        }

        public Expression Eval(Expression exp)
        {
            this.m_candidates = new Nominator(this.m_fnCanBeEvaluated).Nominate(exp);

            return this.Visit(exp);
        }

        public override Expression Visit(Expression exp)
        {
            if (exp == null)
            {
                return null;
            }

            if (this.m_candidates.Contains(exp))
            {
                return this.Evaluate(exp);
            }

            return base.Visit(exp);
        }

        private Expression Evaluate(Expression e)
        {
            if (e.NodeType == ExpressionType.Constant)
            {
                return e;
            }

            LambdaExpression lambda = Expression.Lambda(e);
            Delegate fn = lambda.Compile();

            return Expression.Constant(fn.DynamicInvoke(null), e.Type);
        }

        private static bool CanBeEvaluatedLocally(Expression exp)
        {
            return exp.NodeType != ExpressionType.Parameter;
        }
        /// <summary>
        /// Performs bottom-up analysis to determine which nodes can possibly
        /// be part of an evaluated sub-tree.
        /// </summary>
        private class Nominator : ExpressionVisitor
        {
            private Func<Expression, bool> m_fnCanBeEvaluated;
            private HashSet<Expression> m_candidates;
            private bool m_cannotBeEvaluated;

            internal Nominator(Func<Expression, bool> fnCanBeEvaluated)
            {
                this.m_fnCanBeEvaluated = fnCanBeEvaluated;
            }

            internal HashSet<Expression> Nominate(Expression expression)
            {
                this.m_candidates = new HashSet<Expression>();
                this.Visit(expression);
                return this.m_candidates;
            }

            public override Expression Visit(Expression expression)
            {
                if (expression != null)
                {
                    bool saveCannotBeEvaluated = this.m_cannotBeEvaluated;
                    this.m_cannotBeEvaluated = false;

                    base.Visit(expression);

                    if (!this.m_cannotBeEvaluated)
                    {
                        if (this.m_fnCanBeEvaluated(expression))
                        {
                            this.m_candidates.Add(expression);
                        }
                        else
                        {
                            this.m_cannotBeEvaluated = true;
                        }
                    }

                    this.m_cannotBeEvaluated |= saveCannotBeEvaluated;
                }

                return expression;
            }
        }

    }
}
