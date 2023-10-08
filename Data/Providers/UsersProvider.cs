using Microsoft.EntityFrameworkCore;
using Models.Database;
using Models.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Providers
{
    public class UsersProvider : IUsersProvider
    {
        private readonly Database _database;
        public UsersProvider(Database database) 
        {
            _database = database;
        }

        /// <summary>
        /// Получения всех пользователей
        /// </summary>
        /// <returns></returns>
        public List<Users> Get()
        {
            return _database.Users.ToList();
        } 

        /// <summary>
        /// Получение пользователя по <paramref name="phone"/> и <paramref name="password"/> 
        /// </summary>
        /// <param name="phone">Номер телефона пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns>Модель данных пользователя</returns>
        public async Task<Users> GetAsync(string phone, string password) 
        {
            return await _database.Users.FirstOrDefaultAsync(u => 
                u.Phone == phone && u.Password == password);
        }

        /// <summary>
        /// Создания нового пользователя
        /// </summary>
        /// <param name="users">Модель данных пользователя</param>
        public void Create(Users users)
        {
            _database.Users.Add(users);
            _database.SaveChanges();
        }

        /// <summary>
        /// Создания нового пользователя асинхронно
        /// </summary>
        /// <param name="users">Модель данных пользователя</param>
        public async Task CreateAsync(Users users)
        {
            await _database.Users.AddAsync(users);
            await _database.SaveChangesAsync();
        }

        /// <summary>
        /// Проверяет есть ли запись с такими данными
        /// </summary>
        /// <param name="phone">Номер телефона</param>
        /// <param name="email">Email</param>
        /// <returns>Если такая запись есть возвращаем ей, иначе null</returns>
        public async Task<Users>? CheckUserAsync(string phone, string? email)
        {
            return await _database.Users.
                FirstOrDefaultAsync(l => l.Phone == phone || l.Email == email);
        }
    }
}
