using System.Data.Entity;

namespace FourthTask.Models
{
    public class PersonContext : DbContext
    {
        public PersonContext() : base("FourthTask")
        {
        }
        public DbSet<Person> Persons { get; set; }
    }
}