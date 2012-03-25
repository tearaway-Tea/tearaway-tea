using System.Windows;
using System.Windows.Input;
using Boxes.Components;

namespace Boxes.Utils
{
	public class UserCardMover
	{
		private readonly Point _userCardPosition;
		private readonly Point _whitespacePosition;
		private UserCard _userCard;
		private UIElement _whitespace;

		public UserCardMover(UIElement whitespace, UserCard userCard, Point position)
		{
			_whitespace = whitespace;
			_userCard = userCard;
			_whitespacePosition = position;
			_userCardPosition = new Point(userCard.Left, userCard.Top);

			whitespace.MouseMove += OnWhitespaceMouseMove;
			whitespace.MouseLeftButtonUp += OnWhitespaceMouseLeftButtonUp;
		}

		public static Point SubtractPoint(Point point1, Point point2)
		{
			return new Point(point1.X - point2.X, point1.Y - point2.Y);
		}

		private void OnWhitespaceMouseMove(object sender, MouseEventArgs e)
		{
			Point shift = SubtractPoint(e.GetPosition(_whitespace), _whitespacePosition);
			_userCard.Top = _userCardPosition.Y + shift.Y;
			_userCard.Left = _userCardPosition.X + shift.X;
		}

		private void OnWhitespaceMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			_whitespace.MouseMove -= OnWhitespaceMouseMove;
			_whitespace.MouseLeftButtonUp -= OnWhitespaceMouseLeftButtonUp;
			_whitespace = null;
			_userCard = null;
		}
	}
}