﻿using Microsoft.EntityFrameworkCore;
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
        public UsersProvider() 
        {
            _database = new Database();
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
        /// Получение пользователя по <paramref name="login"/> и <paramref name="password"/> 
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns>Модель данных пользователя</returns>
        public Task<Users>? GetAsync(string login, string password) 
        {
            return _database.Users.FirstOrDefaultAsync(u => 
                (u.Email == login || u.Phone == login) && u.Password == password);
        }

        /// <summary>
        /// Создания нового пОльзователя
        /// </summary>
        /// <param name="users">Модель данных пользователя</param>
        public void Create(Users users)
        {
            _database.Users.Add(users);
            _database.SaveChanges();
        }
    }
}
