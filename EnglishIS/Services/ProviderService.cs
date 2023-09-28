using Data.Providers;
using Models.Providers;

namespace EnglishIS.Services
{
    public static class ServiceProviderExtensions
    {
        /// <summary>
        /// Метод расширения для добавления связок между интерфейсами и классам,
        /// которые взаимодействуют с БД
        /// </summary>
        /// <param name="services"></param>
        public static void AddDbProviders(this IServiceCollection services)
        {
            services.AddTransient<IUsersProvider, UsersProvider>();
            //services.AddTransient
        }
    }
}
