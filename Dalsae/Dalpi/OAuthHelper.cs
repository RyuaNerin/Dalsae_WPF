using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Dalpi
{
    internal static class OauthHelper
    {
        private static readonly Random rnd = new Random(DateTime.Now.Millisecond);
        public static string GetNonce()
        {
            return rnd.Next(int.MinValue, int.MaxValue).ToString("X");
        }

        private static readonly DateTime GenerateTimeStampDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        public static string GetTimeStamp()
        {
            return Convert.ToInt64((DateTime.UtcNow - GenerateTimeStampDateTime).TotalSeconds).ToString();
        }

        public static string ToQuery(IDictionary<string, object> dic, bool isPostData)
        {
            var sb = new StringBuilder();

            if (dic.Count > 0)
            {
                foreach (var st in dic)
                    if (st.Value is bool)
                        sb.AppendFormat("{0}={1}&", st.Key, (bool)st.Value ? "true" : "false");
                    else if (isPostData)
                        sb.AppendFormat("{0}={1}&", st.Key, Uri.EscapeDataString(Convert.ToString(st.Value)));
                    else
                        sb.AppendFormat("{0}={1}&", st.Key, Uri.EscapeUriString(Convert.ToString(st.Value)));

                if (sb.Length > 0)
                    sb.Remove(sb.Length - 1, 1);
            }

            return sb.ToString();
        }

        private static string GetValue(this string data, string keyName)
            => Regex.Match(data, $"{keyName}=([^&]+)").Groups[1].Value;

        public static readonly JsonSerializerSettings JsonSetting = new JsonSerializerSettings
        {
            DateFormatString = "ddd MMM dd HH:mm:ss zzzz yyyy"
        };

        public static T ParseJsonObject<T>(string json)
            => JsonConvert.DeserializeObject<T>(json, JsonSetting);

        private static readonly Regex ReNamedTag = new Regex(@"\{(.+?)\}");
        public static string NamedFormat(string str, IDictionary<string, object> argument)
        {
            foreach (Match m in ReNamedTag.Matches(str))
                str = str.Replace(m.Groups[0].Value, argument[m.Groups[1].Value]);

            return str;
        }
    }
}
