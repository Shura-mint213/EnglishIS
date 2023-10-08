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
        /// Получение пользователя по <paramref name="phone"/> и <paramref name="password"/> 
        /// </summary>
        /// <param name="phone">Номер телефона пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns>Модель данных пользователя</returns>
        Task<Users>? GetAsync(string phone, string password);

        /// <summary>
        /// Проверяет есть ли запись с такими данными
        /// </summary>
        /// <param name="phone">Номер телефона</param>
        /// <param name="email">Email</param>
        /// <returns>true - если такая запись есть, иначе false</returns>
        Task<Users>? CheckUserAsync(string phone, string? email);

        /// <summary>
        /// Создания нового пОльзователя
        /// </summary>
        /// <param name="users">Модель данных пользователя</param>
        void Create(Users users);

        /// <summary>
        /// Создания нового пользователя асинхронно
        /// </summary>
        /// <param name="users">Модель данных пользователя</param>
        Task CreateAsync(Users users);

    }
}
