using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApplication1.DataAccess;
using WebApplication1.Domain;

namespace WebApplication1
{
    internal class FakePeopleDataContext : PeopleDataContext
    {
        public FakePeopleDataContext()
        {
            var people = GetFakePeople();
            foreach (var person in people)
            {
                People.Add(person);
            }
        }

        private IEnumerable<Person> GetFakePeople()
        {
            yield return new Person {Id = 1, FirstName = "Fred", LastName = "Flintstone", Salary = 90000};
            yield return new Person {Id = 2, FirstName = "Wilma", LastName = "Flintstone", Salary = 80000};
            yield return new Person {Id = 3, FirstName = "Barney", LastName = "Rubble", Salary = 70000};
            yield return new Person {Id = 4, FirstName = "Betty", LastName = "Rubble", Salary = 60000};
        }
    }
}
