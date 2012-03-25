using System;
using System.Windows.Controls;

namespace Boxes.Controls
{
	public class NegativeSizesUserControl : UserControl
	{
		public bool IsNegativeSizes { get; set; }

		public new double Height
		{
			get { return (double) GetValue(HeightProperty); }
			set
			{
				IsNegativeSizes = value < 0;

				if (IsNegativeSizes)
				{
					value = Math.Abs(value);
					Canvas.SetTop(this, Canvas.GetTop(this) - value);
				}

				SetValue(HeightProperty, value);
			}
		}

		public new double Width
		{
			get { return (double) GetValue(WidthProperty); }
			set
			{
				IsNegativeSizes = value < 0;

				if (IsNegativeSizes)
				{
					value = Math.Abs(value);
					Canvas.SetLeft(this, Canvas.GetLeft(this) - value);
				}

				SetValue(WidthProperty, value);
			}
		}
	}
}