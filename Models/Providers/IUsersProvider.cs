using Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Providers
{

    public interface IUsersProvider
    {
        /// <summary>
        /// Получения всех пользователей
        /// </summary>
        /// <returns></returns>
        List<Users> Get();

        /// <summary>
        /// Получение пользователя по <paramref name="login"/> и <paramref name="password"/> 
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns>Модель данных пользователя</returns>
        Task<Users>? GetAsync(string login, string password);

        /// <summary>
        /// Создания нового пОльзователя
        /// </summary>
        /// <param name="users">Модель данных пользователя</param>
        void Create(Users users);
    }
}
