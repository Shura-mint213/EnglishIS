using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Database
{
    [Table("users")]
    public class Users
    {
        [Key]
        [Column("user_id")]
        public int Id { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("birthday")]
        public DateOnly? Birthday { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("email")]
        public string? Email { get; set; }
        [Column("phone")]
        public string Phone { get; set; }
        [Column("role_id")]
        public byte RoleId { get; set; }
        [Column("level_id")]
        public byte LevelId { get; set; }

        public Users(string firstName,
            string lastName,
            string phone,
            string password,
            byte levelId,
            byte roleId,
            string? email = null,
            DateOnly? birthday = null
            )
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Password = password;
            LevelId = levelId;
            RoleId = roleId;
            Email = email;
            Birthday = birthday;
        }
    }
}