using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Dalsae.Twitter.Objects;
using static Dalsae.DataManager;

namespace Dalsae.Converter
{
    public class PropicConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object ret = null;
            string param = parameter?.ToString() ?? "";
            if (targetType.Name == "ImageSource")
            {
                if (value is ClientTweet)
                {
                    ClientTweet tweet = value as ClientTweet;
                    if (tweet.originalTweet == null)
                    {
                        App.SendException("Propic Converter Original Tweet NULL!", "");
                        return null;
                    }
                    if (tweet.originalTweet.user == null)
                    {
                        App.SendException("Propic Converter Original Tweet -> user NULL!", "");
                        return null;
                    }
                    if (param == "big")
                        ret = tweet.originalTweet?.user?.profile_image_url.Replace("_normal", "_bigger");
                    else
                        ret = tweet.originalTweet?.user?.profile_image_url;
                }
                else if (value is string)
                {
                    string str = value.ToString();
                    if (param == "big")
                        ret = str.Replace("_normal", "_bigger");
                    else
                        ret = str;
                }
            }
            else if (targetType.Name == "Visibility")
            {
                if (param == "big")
                    ret = DataInstence.option.isBigPropic ? Visibility.Visible : Visibility.Collapsed;
                else
                    ret = DataInstence.option.isBigPropic == false ? Visibility.Visible : Visibility.Collapsed;
            }
            return ret;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
