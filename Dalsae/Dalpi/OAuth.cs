using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Dalpi
{
    public class TokenPair
    {
        public TokenPair()
        {
        }
        public TokenPair(string token, string secret)
        {
            this.Token = token;
            this.Secret = secret;
        }
        public string Token { get; set; }
        public string Secret { get; set; }
    }

    public class OAuth
    {
        static OAuth()
        {
            ServicePointManager.Expect100Continue = false;
        }

        public OAuth(string appToken, string appSecret)
            : this(appToken, appSecret, null, null)
        {
        }
        public OAuth(string appToken, string appSecret, string userToken, string userSecret)
        {
            this.App = new TokenPair(appToken, appSecret);
            this.User = new TokenPair(userToken, userSecret);
        }

        public TokenPair App { get; }
        public TokenPair User { get; }

        public string CreateSignature(string method, Uri baseUri, IDictionary<string, object> data)
        {
            if (string.IsNullOrWhiteSpace(baseUri.Query))
                throw new ArgumentException("uri query is not null.");

            method = method.ToUpper();
            var dic = new SortedDictionary<string, object>();

            if (data != null)
                foreach (var v in data)
                    dic.Add(v.Key, v.Value);

            if (!string.IsNullOrWhiteSpace(this.User.Token))
                dic.Add("oauth_token", Uri.EscapeDataString(this.User.Token));

            dic.Add("oauth_consumer_key", Uri.EscapeDataString(this.App.Token));
            dic.Add("oauth_nonce", OauthHelper.GetNonce());
            dic.Add("oauth_timestamp", OauthHelper.GetTimeStamp());
            dic.Add("oauth_signature_method", "HMAC-SHA1");
            dic.Add("oauth_version", "1.0");

            var hashKey = string.Format(
                "{0}&{1}",
                Uri.EscapeDataString(this.App.Secret),
                string.IsNullOrWhiteSpace(this.User.Secret) ? null : Uri.EscapeDataString(this.User.Secret));
            var hashData = string.Format(
                    "{0}&{1}&{2}",
                    method.ToUpper(),
                    Uri.EscapeDataString(baseUri.AbsoluteUri),
                    Uri.EscapeDataString(OauthHelper.ToQuery(data, false)));

            using (var hash = new HMACSHA1(Encoding.UTF8.GetBytes(hashKey)))
                dic.Add("oauth_signature", Uri.EscapeDataString(Convert.ToBase64String(hash.ComputeHash(Encoding.UTF8.GetBytes(hashData)))));

            var sbData = new StringBuilder();
            sbData.Append("OAuth ");
            foreach (var st in dic)
                if (st.Key.StartsWith("oauth_"))
                    sbData.AppendFormat("{0}=\"{1}\",", st.Key, Convert.ToString(st.Value));
            sbData.Remove(sbData.Length - 1, 1);

            return sbData.ToString();
        }

        public WebRequest CreateWebRequest(string method, Uri uri, IDictionary<string, object> data = null)
        {
            var req = (HttpWebRequest)WebRequest.Create(uri);
            req.Method = method;
            req.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            req.UserAgent = "Limitation";
            req.Headers.Add("Authorization", this.CreateSignature(method, uri, data));

            return req;
        }

        public T CallApi<T>(BaseParam<T> param)
            where T : class
        {
            return param.GetResponse(this);
        }
    }
}
