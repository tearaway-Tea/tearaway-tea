using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Boxes.Model
{
	public abstract class BindableObject : INotifyPropertyChanged
	{
		#region INotifyPropertyChanged Members

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

		public void RaisePropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}

	public static class BindableObjectEx
	{
		public static void RaisePropertyChanged<T, TProperty>(this T observableBase, Expression<Func<T, TProperty>> expression)
			where T : BindableObject
		{
			observableBase.RaisePropertyChanged(observableBase.GetPropertyName(expression));
		}

		public static string GetPropertyName<T, TProperty>(this T owner, Expression<Func<T, TProperty>> expression)
		{
			var memberExpression = expression.Body as MemberExpression;
			if (memberExpression == null)
			{
				var unaryExpression = expression.Body as UnaryExpression;
				if (unaryExpression != null)
				{
					memberExpression = unaryExpression.Operand as MemberExpression;

					if (memberExpression == null)
					{
						throw new NotImplementedException();
					}
				}
				else
				{
					throw new NotImplementedException();
				}
			}

			string propertyName = memberExpression.Member.Name;

			return propertyName;
		}
	}
}