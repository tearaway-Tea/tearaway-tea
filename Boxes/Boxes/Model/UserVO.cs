using System.Collections.Generic;

namespace Boxes.Model
{
	public class UserVo : BindableObject
	{
		private string _description;
		private string _imageUrl;
		private string _name;
		private List<UserVo> _users;

		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				this.RaisePropertyChanged(p => p.Name);
			}
		}

		public string Description
		{
			get { return _description; }
			set
			{
				_description = value;
				this.RaisePropertyChanged(p => p.Description);
			}
		}

		public string ImageUrl
		{
			get { return _imageUrl; }
			set
			{
				_imageUrl = value;
				this.RaisePropertyChanged(p => p.ImageUrl);
			}
		}

		public List<UserVo> Users
		{
			get
			{
				if (_users == null)
				{
					_users = new List<UserVo>();
				}

				return _users;
			}
		}
	}
}