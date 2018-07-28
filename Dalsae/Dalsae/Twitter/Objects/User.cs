using Dalsae.Template;

namespace Dalsae.Twitter.Objects
{
    public class User:BaseNoty
	{
		public User() { }
		public static void CopyUser(User to, User from)
		{
			to.profile_image_url = from.profile_image_url;
			to.name = from.name;
			to.id = from.id;
			to.verified = from.verified;
			to.screen_name = from.screen_name;
			to.favourites_count = from.favourites_count;
			to.friends_count = from.friends_count;
		}
		[Newtonsoft.Json.JsonIgnore]
		private string _profile_image_url = string.Empty;
		public string profile_image_url
		{
			get { return _profile_image_url; }
			set { _profile_image_url = value; OnPropertyChanged("profile_image_url"); }
		}
		public string name { get; set; } = string.Empty;
		public string screen_name { get; set; } = string.Empty;
		public long id { get; set; } = 0;
		public bool Protected { get; set; } = false;
		public bool verified { get; set; } = false;
		public int favourites_count { get; set; } = 0;
		public int friends_count { get; set; } = 0;
	}
}
