using Data;
using Data.Providers;
using Models.Providers;

namespace EnglishIS.Services
{
    public static class ProviderServiceExtensions
    {
        /// <summary>
        /// Метод расширения для добавления связок между интерфейсами и классам,
        /// которые взаимодействуют с БД
        /// </summary>
        /// <param name="services"></param>
        public static void AddDbProviders(this IServiceCollection services)
        {
            services.AddTransient<Database>();
            services.AddTransient<IUsersProvider, UsersProvider>();
        }
    }
}
