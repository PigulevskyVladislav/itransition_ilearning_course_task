using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FourthTask.Models
{
    [Table("persons", Schema = "public")]
    public class Person
    {
        public int PersonID { get; set; }

        public string PersonName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime RegisterDate { get; set; }

        public DateTime LastLoginDate { get; set; }

        public bool Blocked { get; set; }
    }
}