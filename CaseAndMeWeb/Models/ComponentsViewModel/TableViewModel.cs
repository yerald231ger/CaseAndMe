using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web;

namespace CaseAndMeWeb.Models.ComponentsViewModel
{
    public class OrdenVentaViewModel
    {
        public string Folio { get; set; }
        public string Fecha { get; set; }
        public string MetodoPago { get; set; }
        public string MetodoEnvio { get; set; }
    }

    public class TableViewModelBuilder<TModel> : TableViewModel
    {
        public Dictionary<string, string> displayNames = new Dictionary<string, string>();

        public TableViewModelBuilder<TModel> AddHeader<TKey>(Expression<Func<TModel, TKey>> constraint)
        {
            if (!(constraint.Body is MemberExpression expr))
                throw new ArgumentException(
                    string.Format("Expression '{0}' must be a member expression", constraint), "constraint");

            Headers.Add(expr.Member.Name);
            //var name = PropertiesHelper.BuildColumnNameFromMemberExpression(expr);
            ////return this.FirstOrDefault(c => !string.IsNullOrEmpty(c.Name) && String.Equals(c.Name, name, StringComparison.CurrentCultureIgnoreCase)) as IGridColumn<T>;
            return this;
        }

        public TableViewModelBuilder<TModel> DisplayName(string displayName)
        {
            if (Headers.Count > 0)
                displayNames.Add(Headers.Last(), displayName);
            return this;
        }

        public TableViewModel DataSource(List<TModel> dataSource)
        {
            foreach (var item in dataSource)
            {
                var row = new Row();
                var properties = item.GetType().GetProperties();

                if (Headers.Count > 0)
                    foreach (var header in Headers)
                        if (properties.FirstOrDefault(p => p.Name == header) != null)
                            row.Fields.Add(properties.First(p => p.Name == header).GetValue(item).ToString());

                Rows.Add(row);
            }

            for (int i = 0; i < Headers.Count; i++)
                if (displayNames.ContainsKey(Headers[i]))
                    Headers[i] = displayNames[Headers[i]];

            return this;
        }

        public TableViewModelBuilder<TModel> AddCount(bool count)
        {
            Count = count;
            return this;
        }

        public TableViewModelBuilder<TModel> AddCaption(string caption)
        {
            Caption = caption;
            return this;
        }

        public TableViewModel WithCount(bool isCount)
        {
            Count = isCount;
            return this;
        }
    }

    public class TableViewModel
    {
        public bool Count { get; protected set; }
        public string Caption { get; protected set; }
        public List<string> Headers { get; protected set; }
        public List<Row> Rows { get; protected set; }

        public TableViewModel()
        {
            Headers = new List<string>();
            Rows = new List<Row>();
        }

    }

    public class Row
    {
        public List<string> Fields { get; set; }

        public Row()
        {
            Fields = new List<string>();
        }
    }

    internal static class PropertiesHelper
    {
        private const string PropertiesQueryStringDelimeter = ".";

        public static string BuildColumnNameFromMemberExpression(MemberExpression memberExpr)
        {
            var sb = new StringBuilder();
            Expression expr = memberExpr;
            while (true)
            {
                string piece = GetExpressionMemberName(expr, ref expr);
                if (string.IsNullOrEmpty(piece)) break;
                if (sb.Length > 0)
                    sb.Insert(0, PropertiesQueryStringDelimeter);
                sb.Insert(0, piece);
            }
            return sb.ToString();
        }

        private static string GetExpressionMemberName(Expression expr, ref Expression nextExpr)
        {
            if (expr is MemberExpression)
            {
                var memberExpr = (MemberExpression)expr;
                nextExpr = memberExpr.Expression;
                return memberExpr.Member.Name;
            }
            if (expr is BinaryExpression && expr.NodeType == ExpressionType.ArrayIndex)
            {
                var binaryExpr = (BinaryExpression)expr;
                string memberName = GetExpressionMemberName(binaryExpr.Left, ref nextExpr);
                if (string.IsNullOrEmpty(memberName))
                    throw new InvalidDataException("Cannot parse your column expression");
                return string.Format("{0}[{1}]", memberName, binaryExpr.Right);
            }
            return string.Empty;
        }


        public static PropertyInfo GetPropertyFromColumnName(string columnName, Type type,
                                                             out IEnumerable<PropertyInfo> propertyInfoSequence)
        {
            string[] properies = columnName.Split(new[] { PropertiesQueryStringDelimeter },
                                                  StringSplitOptions.RemoveEmptyEntries);
            if (!properies.Any())
            {
                propertyInfoSequence = null;
                return null;
            }
            PropertyInfo pi = null;
            var sequence = new List<PropertyInfo>();
            foreach (string properyName in properies)
            {
                pi = type.GetProperty(properyName);
                if (pi == null)
                {
                    propertyInfoSequence = null;
                    return null; //no match column
                }
                sequence.Add(pi);
                type = pi.PropertyType;
            }
            propertyInfoSequence = sequence;
            return pi;
        }

        public static Type GetUnderlyingType(Type type)
        {
            Type targetType;
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                targetType = Nullable.GetUnderlyingType(type);
            }
            else
            {
                targetType = type;
            }
            return targetType;
        }

        public static T GetAttribute<T>(this PropertyInfo pi)
        {
            return (T)pi.GetCustomAttributes(typeof(T), true).FirstOrDefault();
        }

        public static T GetAttribute<T>(this Type type)
        {
            return (T)type.GetCustomAttributes(typeof(T), true).FirstOrDefault();
        }
    }
}