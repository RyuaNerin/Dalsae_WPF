using Dalsae.Twitter.Objects;

namespace Dalsae.Manager
{
    //클라이언트 사용자 관련 값들을 들고있음
    public class DalsaeUserInfo
    {
        public string Token { get; private set; }
        public string TokenSecret { get; private set; }
        public User user { get; set; } = new User();
        public void Clear()
        {
            Token = string.Empty;
            TokenSecret = string.Empty;
            user.profile_image_url = "";
        }
        public void UpdateToken(Web.ResOAuth oauth)
        {
            this.Token = oauth.tokenStr;
            this.TokenSecret = oauth.secretStr;
        }

        //public void UpdateSecretToken(string secret)	{		this.TokenSecret = secret;	}
        //public void UpdateToken(string token)	{		this.Token = token;	}
        public void UpdateScreenName(string name) { user.screen_name = name; }
        public void UpdateUser(User user) { this.user = user; }
    }
}
