using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace ProyecTitulacion.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;


        public static string MemberId
        {
            get => AppSettings.GetValueOrDefault(nameof(MemberId), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(MemberId), value);
        }

        public static string MemberFistname
        {
            get => AppSettings.GetValueOrDefault(nameof(MemberFistname), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(MemberFistname), value);
        }

        public static string MemberLastName
        {
            get => AppSettings.GetValueOrDefault(nameof(MemberLastName), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(MemberLastName), value);
        }

        public static string MemberEmail
        {
            get => AppSettings.GetValueOrDefault(nameof(MemberEmail), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(MemberEmail), value);
        }

        public static bool IsLoged
        {
            get => AppSettings.GetValueOrDefault(nameof(IsLoged), false);

            set => AppSettings.AddOrUpdateValue(nameof(IsLoged), value);
        }



        public static bool IsUpdateView
        {
            get => AppSettings.GetValueOrDefault(nameof(IsUpdateView), false);

            set => AppSettings.AddOrUpdateValue(nameof(IsUpdateView), value);
        }

    }
}