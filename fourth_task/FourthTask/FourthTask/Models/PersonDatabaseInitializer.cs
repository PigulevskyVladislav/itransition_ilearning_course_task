using System.Collections.Generic;
using System.Data.Entity;
using System;

namespace FourthTask.Models
{
    public class PersonDatabaseInitializer : DropCreateDatabaseIfModelChanges<PersonContext>
    {
        protected override void Seed(PersonContext context)
        {
            GetPersons().ForEach(p => context.Persons.Add(p));
        }

        private static List<Person> GetPersons()
        {
            var categories = new List<Person> {
                new Person
                {
                    PersonID = 1,
                    PersonName = "Наташа",
                    Password = "1111",
                    Email = "nashanatasha@mail.ru",
                    RegisterDate = new DateTime(2020, 12, 2),
                    LastLoginDate = new DateTime(2020, 12, 14),
                    Blocked = false
                },
                new Person
                {
                    PersonID = 2,
                    PersonName = "Дмитрий",
                    Password = "123zxc",
                    Email = "dimaizrima@gmail.com",
                    RegisterDate = new DateTime(2020, 12, 7),
                    LastLoginDate = new DateTime(2020, 12, 10),
                    Blocked = false
                },
                new Person
                {
                    PersonID = 3,
                    PersonName = "Игорь",
                    Password = "7890",
                    Email = "igor7070@mail.ru",
                    RegisterDate = new DateTime(2020, 11, 15),
                    LastLoginDate = new DateTime(2020, 11, 25),
                    Blocked = false
                },
                new Person
                {
                    PersonID = 4,
                    PersonName = "Святослав",
                    Password = "5",
                    Email = "guypaladin@gmail.com",
                    RegisterDate = new DateTime(2020, 11, 5),
                    LastLoginDate = new DateTime(2020, 12, 19),
                    Blocked = false
                },
            };

            return categories;
        }
    }
}