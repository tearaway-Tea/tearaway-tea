using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Boxes.Model
{
	public class UserCardModel : BindableObject
	{
		private ImageSource _image;
		private UserVo _user;

		public UserVo User
		{
			get { return _user; }
			set
			{
				_user = value;
				this.RaisePropertyChanged(p => p.User);

				Image = new BitmapImage();
				((BitmapImage) Image).UriSource = new Uri(value.ImageUrl, UriKind.RelativeOrAbsolute);
			}
		}

		public ImageSource Image
		{
			get { return _image; }
			set
			{
				_image = value;
				this.RaisePropertyChanged(p => p.Image);
			}
		}
	}
}