using Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Providers
{
    public class UsersProvider
    {
        private readonly Database _database;
        public UsersProvider() 
        {
            _database = new Database();
        }

        public List<Users> Get()
        {
            return _database.Users.ToList();
        } 

        public void Create(Users users)
        {
            _database.Users.Add(users);
            _database.SaveChanges();
        }
    }
}
