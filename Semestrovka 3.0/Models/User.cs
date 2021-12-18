using System;
using System.ComponentModel.DataAnnotations;
using LinqToDB.Mapping;

namespace Semestrovka_3._0.Models
{
    [Table(Name = "Users")]
    public class User
    {
        [Column("user_id"), PrimaryKey, NotNull]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "Write the password")]
        [Column("password"), NotNull]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is empty")]
        [Column("email"), NotNull]
        public string Email { get; set; }

        [Required(ErrorMessage = "Write your name")]
        [Column("name"), NotNull]
        public string Name { get; set; }

        [Required(ErrorMessage = "Write your surname")]
        [Column("surname"), NotNull]
        public string Surname { get; set; }

    }
}
    
