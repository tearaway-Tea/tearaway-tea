namespace Boxes.Model
{
	public class UserMockFactory
	{
		public static UserVo GetUsersTree()
		{
			var rootUser = new UserVo
			               	{
			               		Name = "George Washington",
			               		Description =
			               			"Born in 1732 into a Virginia planter family, he learned the morals, manners, and body of knowledge requisite for an 18th century Virginia gentleman.",
			               		ImageUrl = "/images/george-washington.jpg"
			               	};

			var leafUser1 = new UserVo
			                	{
			                		Name = "John Adams",
			                		Description =
			                			"His administration focused on France, where the Directory, the ruling group, had refused to receive the American envoy and had suspended commercial relations.",
			                		ImageUrl = "/images/john-adams.jpg"
			                	};
			rootUser.Users.Add(leafUser1);

			var leafUser2 = new UserVo
			                	{
			                		Name = "Thomas Jefferson",
			                		Description =
			                			"In the thick of party conflict in 1800, Thomas Jefferson wrote in a private letter, \"I have sworn upon the altar of God eternal hostility against every form of tyranny over the mind of man.\"",
			                		ImageUrl = "/images/thomas-jefferson.jpg"
			                	};
			rootUser.Users.Add(leafUser2);

			var subLeafUser1 = new UserVo
			                   	{
			                   		Name = "James Madison",
			                   		Description =
			                   			"When delegates to the Constitutional Convention assembled at Philadelphia, the 36-year-old Madison took frequent and emphatic part in the debates.",
			                   		ImageUrl = "/images/james-madison.jpg"
			                   	};
			leafUser1.Users.Add(subLeafUser1);

			var subLeafUser2 = new UserVo
			                   	{
			                   		Name = "James Monroe",
			                   		Description =
			                   			"Born in Westmoreland County, Virginia, in 1758, Monroe attended the College of William and Mary, fought with distinction in the Continental Army, and practiced law in Fredericksburg, Virginia.",
			                   		ImageUrl = "/images/james-monroe.jpg"
			                   	};
			leafUser1.Users.Add(subLeafUser2);

			var subLeafUser3 = new UserVo
			                   	{
			                   		Name = "Andrew Jackson",
			                   		Description =
			                   			"More nearly than any of his predecessors, Andrew Jackson was elected by popular vote; as President he sought to act as the direct representative of the common man.",
			                   		ImageUrl = "/images/andrew-jackson.jpg"
			                   	};
			leafUser2.Users.Add(subLeafUser3);

			var subLeafUser4 = new UserVo
			                   	{
			                   		Name = "Franklin Pierce",
			                   		Description =
			                   			"Probably because the Democrats stood more firmly for the Compromise than the Whigs, and because Whig candidate Gen. Winfield Scott was suspect in the South, Pierce won with a narrow margin of popular votes.",
			                   		ImageUrl = "/images/franklin-pierce.jpg"
			                   	};
			leafUser2.Users.Add(subLeafUser4);

			return rootUser;
		}
	}
}