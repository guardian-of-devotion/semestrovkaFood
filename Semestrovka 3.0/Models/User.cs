using System;
using System.ComponentModel.DataAnnotations;


namespace Semestrovka_3._0.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Write the password")]
       
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is empty")] 
        
        public string Email { get; set; }

        [Required(ErrorMessage = "Write your name")]
       
        public string Name { get; set; }

        [Required(ErrorMessage = "Write your surname")]
       
        public string Surname { get; set; }

    }
}
    
