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
        public string? LastName { get; set; }
        [Column("age")]
        public int? Age { get; set; }
        [Column("login")]
        public string Login { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("email")]
        public string? Email { get; set; }
        [Column("phone")]
        public string Phone { get; set; }
        [Column("role")]
        public byte Role { get; set; }
    }
}
/*
 Id SERIAL,
    First_Name CHARACTER VARYING(64) NOT NULL,
    Last_Name CHARACTER VARYING(64) NULL,
    Age SMALLINT NULL,	
	Login CHARACTER VARYING(15) UNIQUE NOT NULL,
	Password CHARACTER VARYING (30) NOT NULL,	
    Email CHARACTER VARYING(30) UNIQUE NULL,
    Phone CHARACTER VARYING(30) UNIQUE NOT NULL,
	Role SMALLINT NOT NULL, 
 */
