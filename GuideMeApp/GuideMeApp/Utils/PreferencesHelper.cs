namespace GuideMeApp.Utils
{
    public interface IPreferencesHelper
    {
        int GetUserId();
        void SetUserId(int userId);
    }

    public class PreferencesHelper : IPreferencesHelper
    {
        private const string UserIdKey = "user_id";

        public int GetUserId()
        {
            return Preferences.Get(UserIdKey, -1);
        }

        public void SetUserId(int userId)
        {
            Preferences.Set(UserIdKey, userId);
        }
    }

}
