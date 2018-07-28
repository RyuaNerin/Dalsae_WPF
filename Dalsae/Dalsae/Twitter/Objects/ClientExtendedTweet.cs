namespace Dalsae.Twitter.Objects
{
    public class ClientExtendedTweet
	{
		public string full_text { get; set; }//140자 넘는 트윗일 경우 사용
		public ClientEntities entities { get; set; }
		public ClientEntities extended_entities { get; set; }
	}
}
