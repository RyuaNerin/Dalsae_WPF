namespace Dalsae.Twitter.Objects
{
    public class UserSemi
	{
		public UserSemi(string name, string screen_name, long id, string profile_image_url)
		{
			this.name = name;
			this.screen_name = screen_name;
			this.id = id;
			this.profile_image_url = profile_image_url;
			//this.id_str = id_str;
		}
		
		public string name { get; private set; }
		public string screen_name { get; private set; }
		public long id { get; private set; }
		public string profile_image_url { get; set; }
		public void UpdateName(string name)
		{
			this.name = name;
		}
		//public string id_str { get; private set; }
	}
}
