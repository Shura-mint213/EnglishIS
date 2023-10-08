using Static.Static;

namespace EnglishIS.Helpers
{
    public static class LoadingIsConfigured
    {
        public static void Download(WebApplication? app) 
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            else
            {
                SettingsApp.ConnectionString = app.Configuration["ConnectionStrings"];
            }
        }
    }
}
