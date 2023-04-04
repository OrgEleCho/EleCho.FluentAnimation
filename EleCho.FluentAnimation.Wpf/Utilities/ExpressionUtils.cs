using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using Expression = 
    System.Linq.Expressions.Expression;



namespace EleCho.FluentAnimation.Wpf.Utilities
{
    internal static class ExpressionUtils
    {
        public static PropertyPath ToPropertyPath<TSource, TResult>(this Expression<Func<TSource, TResult>> expression)
        {
            Stack<string> pathes = 
                new Stack<string>();

            string? parameterName =
                expression.Parameters[0].Name;

            Expression currentExpression =
                expression.Body;

            while (true)
            {
                if (currentExpression is MemberExpression memberExpression)
                {
                    if (memberExpression.Member is not PropertyInfo)
                        throw new ArgumentException("Cannot access a non property member");
                    if (memberExpression.Expression == null)
                        throw new ArgumentException("Cannot find parent node of member access expression");

                    pathes.Push(memberExpression.Member.Name);
                    currentExpression = memberExpression.Expression;
                }
                else if (currentExpression is UnaryExpression unaryExpression)
                {
                    if (unaryExpression.NodeType != ExpressionType.TypeAs &&
                        unaryExpression.NodeType != ExpressionType.Convert)
                        throw new ArgumentException($"Invalid unary expression type: {unaryExpression.NodeType}");

                    string path = pathes.Pop();
                    if (path.Contains('.'))
                        throw new ArgumentException("You cannot use two type conversions at the same time");

                    pathes.Push($"({unaryExpression.Type.Name}.{path})");
                    currentExpression = unaryExpression.Operand;
                }
                else if (currentExpression is ParameterExpression parameterExpression)
                {
                    if (parameterExpression.Name != parameterName)
                        throw new ArgumentException("Name of parameter expression doesn't match the lambdas parameters");

                    break;
                }
                else
                {
                    throw new ArgumentException($"Invalid expression: {expression.NodeType}");
                }
            }

            StringBuilder propertyPathBuilder =
                new StringBuilder();

            if (pathes.Count == 0)
                throw new ArgumentException("Path is empty");

            propertyPathBuilder.Append(pathes.Pop());

            while (pathes.Count > 0)
            {
                propertyPathBuilder.Append('.');
                propertyPathBuilder.Append(pathes.Pop());
            }

            return new PropertyPath(propertyPathBuilder.ToString());
        }
    }
}
