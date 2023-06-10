namespace KentWebForms.App.Services
{
    using System.Web.SessionState;
    using KentWebForms.Infrastructure.Constants;
    using KentWebForms.Infrastructure.Models.Accounts;
    using Newtonsoft.Json;

    public static class StorageService
    {
        public static bool GetRecentRegistered(HttpSessionState session)
        {
            bool recentlyRegistered = false;
            var storage = session[AccountConstants.RecentlyRegistered];

            if (storage != null)
            {
                recentlyRegistered = (bool)session[AccountConstants.RecentlyRegistered];
            }

            return recentlyRegistered;
        }

        public static void SetRecentRegistered(HttpSessionState session)
        {
            session[AccountConstants.RecentlyRegistered] = true;
        }

        public static void ClearRecentRegistered(HttpSessionState session)
        {
            session.Remove(AccountConstants.RecentlyRegistered);
        }

        public static bool GetLoginPrompt(HttpSessionState session)
        {
            bool loginPrompt = false;
            var storage = session[AccountConstants.LoginPrompt];

            if (storage != null)
            {
                loginPrompt = (bool)session[AccountConstants.LoginPrompt];
            }

            return loginPrompt;
        }

        public static void SetLoginPrompt(HttpSessionState session)
        {
            session[AccountConstants.LoginPrompt] = true;
        }

        public static void ClearLoginPrompt(HttpSessionState session)
        {
            session.Remove(AccountConstants.LoginPrompt);
        }

        public static void StoreUserProfile(HttpSessionState session, UserProfile userProfile)
        {
            if (userProfile != null)
            {
                session[AccountConstants.UserProfile] = JsonConvert.SerializeObject(userProfile);
            }
        }

        public static UserProfile GetUserProfile(HttpSessionState session)
        {
            UserProfile userProfile = null;

            var jsonString = session[AccountConstants.UserProfile] as string;

            if (!string.IsNullOrEmpty(jsonString))
            {
                userProfile = JsonConvert.DeserializeObject<UserProfile>(jsonString);
            }
            
            return userProfile;
        }
    }
}