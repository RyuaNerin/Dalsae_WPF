namespace Dalsae.Twitter.Objects
{
    //팔로 리스트 땡길 때 사용
    public class ClientUsers
	{
		public long previous_cursor { get; set; }
		public string previous_cursor_str { get; set; }
		public long next_cursor { get; set; }
		public User[] users;
	}
}
