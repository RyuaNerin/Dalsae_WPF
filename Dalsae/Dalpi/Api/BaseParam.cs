using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Dalpi.Api
{
    internal class IsArgumentAttribute : Attribute
    {
    }

    internal class IsPrimaryAttribute : Attribute
    {
    }

    public abstract class BaseParam<T>
    {
        internal BaseParam(string method, string url, bool autoReqeust = true)
        {
            this.m_method = method;
            this.m_url = url;
            this.m_autoRequest = autoReqeust;
        }

        private readonly string m_method;
        private readonly string m_url;

        private readonly bool m_autoRequest;
        private readonly Func<string, T> m_convert;

        internal T GetResponse(OAuth oauth)
        {
            var req = GetRequest(oauth);

            using (var res = req.GetResponse())
            {
                var resStream = res.GetResponseStream();

                return this.ParseResult(resStream);
            }
        }

        internal virtual WebRequest GetRequest(OAuth oauth)
        {
            var param = this.GetParameters();

            var req = oauth.CreateWebRequest(this.m_method, this.GetUri(param), param);

            if (this.m_method == "POST" && this.m_autoRequest)
            {
                var postData = OauthHelper.ToQuery(param, true);
                var buff = Encoding.UTF8.GetBytes(postData);

                if (buff.Length > 0)
                {
                    req.ContentType = "application/x-www-form-urlencoded";
                    req.GetRequestStream().Write(buff, 0, buff.Length);
                }
            }

            return req;
        }

        protected virtual T ParseResult(Stream stream)
        {
            var reader = new StreamReader(stream);
            return this.ParseResultString(reader.ReadToEnd());
        }
        protected virtual T ParseResultString(string data)
            => OauthHelper.ParseJsonObject<T>(data);

        private Uri GetUri(IDictionary<string, object> param)
        {
            if (this.m_method == "GET")
            {
                var ub = new UriBuilder(this.m_url)
                {
                    Query = OauthHelper.ToQuery(param, false)
                };

                ub.Path = OauthHelper.NamedFormat(NamedFormat, param);

                return ub.Uri;
            }
            else
                return new Uri(this.m_url);
        }

        private IDictionary<string, object> GetParameters()
        {
            var dic = new SortedDictionary<string, object>();

            foreach (var property in this.GetType().GetProperties())
            {
                if (property.GetCustomAttributes(typeof(ParamPropertyAttribute), false)?.Length > 0)
                    dic[property.Name] = property.GetValue(this);
            }

            return dic;
        }
    }
}
