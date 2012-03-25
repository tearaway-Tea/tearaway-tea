using System;
using System.Windows.Controls;
using Boxes.Model;

namespace Boxes.Components
{
	public partial class UserCard
	{
		private UserVo _user;

		public UserCard()
		{
			InitializeComponent();
		}

		public double Top
		{
			get { return Canvas.GetTop(this); }
			set
			{
				Canvas.SetTop(this, value);
				if (PositionChanged != null)
				{
					PositionChanged(this, new EventArgs());
				}
			}
		}

		public double Left
		{
			get { return Canvas.GetLeft(this); }
			set
			{
				Canvas.SetLeft(this, value);
				if (PositionChanged != null)
				{
					PositionChanged(this, new EventArgs());
				}
			}
		}

		public UserVo User
		{
			get { return _user; }
			set
			{
				_user = value;
				DataContext = new UserCardModel {User = value};
			}
		}

		public event EventHandler PositionChanged;
	}
}