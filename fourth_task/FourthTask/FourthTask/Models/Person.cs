using System;
using System.ComponentModel.DataAnnotations;

namespace FourthTask.Models
{
    public class Person
    {
        [ScaffoldColumn(false), Display(Name = "ID")]
        public int PersonID { get; set; }

        [Required, StringLength(50), Display(Name = "Name")]
        public string PersonName { get; set; }

        [Required, StringLength(60), Display(Name = "Password")]
        public string Password { get; set; }

        [Required, StringLength(60), Display(Name = "Email")]
        public string Email { get; set; }

        [Required, Display(Name = "Register")]
        public DateTime RegisterDate { get; set; }

        [Required, Display(Name = "LastLogin")]
        public DateTime LastLoginDate { get; set; }

        [Required, Display(Name = "Blocked")]
        public bool Blocked { get; set; }
    }
}