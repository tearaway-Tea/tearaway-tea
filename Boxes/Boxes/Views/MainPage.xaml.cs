using System.Windows;
using System.Windows.Input;
using Boxes.Components;
using Boxes.Model;
using Boxes.Utils;

namespace Boxes.Views
{
	public partial class MainPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private void OnLoaded(object sender, RoutedEventArgs e)
		{
			UserVo rootUser = UserMockFactory.GetUsersTree();
			new UsersTreeBuilder(rootUser, MainCanvas, OnUserCardMouseLeftButtonDown);
		}

		private void OnUserCardMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			new UserCardMover(LayoutRoot, sender as UserCard, e.GetPosition(LayoutRoot));
		}
	}
}