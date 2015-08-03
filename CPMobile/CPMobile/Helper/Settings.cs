using Refractored.Xam.Settings;
using Refractored.Xam.Settings.Abstractions;

namespace CPMobile.Helper
{
    public static class Settings
    {
        public static ISettings AppSettings
        {
            get { return CrossSettings.Current; }
        }

        private static string authGenralToken = string.Empty;

        public static string AuthToken
        {
            get { return AppSettings.GetValueOrDefault<string>(authGenralToken); }
            set { AppSettings.AddOrUpdateValue<string>(authGenralToken,value);}
        }

        private static string authLoginToken = string.Empty;

        public static string AuthLoginToken
        {
            get { return AppSettings.GetValueOrDefault<string>(authLoginToken); }
            set { AppSettings.AddOrUpdateValue<string>(authLoginToken, value); }
        }
    }
}
