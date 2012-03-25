using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Boxes.Components;
using Boxes.Controls;
using Boxes.Model;

namespace Boxes.Utils
{
	public class UsersTreeBuilder
	{
		private const int HorizontalCenter = 750;
		private const int HorizontalGap = 40;
		private const int VerticalGap = 50;
		private readonly Dictionary<int, TreeBuilderLevelData> _itemsLevels;
		private readonly MouseButtonEventHandler _mouseLeftButtonDownHandler;
		private readonly Panel _whitespace;
		private int _userCardNumber;

		public UsersTreeBuilder(UserVo rootUser, Panel whitespace,
		                        MouseButtonEventHandler mouseLeftButtonDownHandler)
		{
			_whitespace = whitespace;
			_mouseLeftButtonDownHandler = mouseLeftButtonDownHandler;

			_itemsLevels = new Dictionary<int, TreeBuilderLevelData>
			               	{
			               		{0, new TreeBuilderLevelData {Count = 1}}
			               	};

			LoadItemsLevels(rootUser, 1);
			CreateUserCard(rootUser, 0);
		}

		private void LoadItemsLevels(UserVo user, int level)
		{
			if (user.Users.Count != 0)
			{
				if (!_itemsLevels.ContainsKey(level))
				{
					_itemsLevels.Add(level, new TreeBuilderLevelData {Count = 0});
				}

				_itemsLevels[level].Count += user.Users.Count;

				foreach (UserVo childUser in user.Users)
				{
					LoadItemsLevels(childUser, level + 1);
				}
			}
		}

		private UserCard CreateUserCard(UserVo user, int level)
		{
			var userCard = new UserCard {User = user};

			double left = Math.Round(HorizontalCenter - (userCard.Width*_itemsLevels[level].Count/2));
			userCard.Top = VerticalGap*(level + 1) + userCard.Height*level;
			userCard.Left = left + userCard.Width*_itemsLevels[level].Proccesed +
			                HorizontalGap*(_itemsLevels[level].Proccesed + 1);

			userCard.SetValue(FrameworkElement.NameProperty, "UserCard" + _userCardNumber++);
			Canvas.SetZIndex(userCard, 2);
			userCard.MouseLeftButtonDown += _mouseLeftButtonDownHandler;
			_whitespace.Children.Add(userCard);

			_itemsLevels[level].Proccesed++;

			foreach (UserVo childUser in user.Users)
			{
				UserCard childUserCard = CreateUserCard(childUser, level + 1);

				var line = new ConnectionLine {ParentUserCard = userCard, ChildUserCard = childUserCard};
				Canvas.SetZIndex(line, 1);
				_whitespace.Children.Add(line);
			}

			return userCard;
		}
	}
}