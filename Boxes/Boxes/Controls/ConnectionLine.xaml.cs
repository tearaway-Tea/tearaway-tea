using System;
using System.Windows;
using System.Windows.Controls;
using Boxes.Components;

namespace Boxes.Controls
{
	public partial class ConnectionLine
	{
		private const int LineWeight = 2;
		private UserCard _childUserCard;
		private UserCard _parentUserCard;

		public ConnectionLine()
		{
			InitializeComponent();
		}

		public UserCard ParentUserCard
		{
			get { return _parentUserCard; }
			set
			{
				if (_parentUserCard != null)
				{
					_parentUserCard.PositionChanged -= OnUserCardPositionChanged;
				}

				_parentUserCard = value;

				if (value != null)
				{
					value.PositionChanged += OnUserCardPositionChanged;
					UpdateSize();
				}
			}
		}

		public UserCard ChildUserCard
		{
			get { return _childUserCard; }
			set
			{
				if (_childUserCard != null)
				{
					_childUserCard.PositionChanged -= OnUserCardPositionChanged;
				}

				_childUserCard = value;

				if (value != null)
				{
					value.PositionChanged += OnUserCardPositionChanged;
					UpdateSize();
				}
			}
		}

		private void OnSizeChanged(object sender, SizeChangedEventArgs e)
		{
			UpdateLinesSize();
		}

		private void OnUserCardPositionChanged(object sender, EventArgs e)
		{
			UpdateSize();
		}

		private void UpdateSize()
		{
			if (ChildUserCard != null && ParentUserCard != null)
			{
				Canvas.SetTop(this, ParentUserCard.Top + ParentUserCard.Height);
				Canvas.SetLeft(this, ChildUserCard.Left + Math.Round(ChildUserCard.Width/2));
				Height = ChildUserCard.Top - ParentUserCard.Top - ParentUserCard.Height + LineWeight;
				Width = ParentUserCard.Left - ChildUserCard.Left;
			}
		}

		private void UpdateLinesSize()
		{
			Canvas.SetLeft(TopLine, (IsNegativeSizes ? 0 : Width) - LineWeight);
			TopLine.Height = Math.Round(Height/2);

			Canvas.SetTop(MiddleLine, TopLine.Height - LineWeight);
			Canvas.SetLeft(MiddleLine, IsNegativeSizes ? -LineWeight : 0);
			MiddleLine.Width = Width + (IsNegativeSizes ? LineWeight : 0);

			Canvas.SetLeft(BottomLine, IsNegativeSizes ? (Width - LineWeight) : 0);
			Canvas.SetTop(BottomLine, TopLine.Height - LineWeight);
			BottomLine.Height = TopLine.Height + LineWeight;
		}
	}
}