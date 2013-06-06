using System;
using System.Data.Entity;
using WebApplication1.Domain;

namespace WebApplication1.DataAccess
{
    public class PeopleDataContext : IPeopleDataContext
    {
        public PeopleDataContext()
        {
            People = new GenericFakeDbSet<Person, int>(r => r.Id);
        }

        public IDbSet<Person> People { get; private set; }

        public void IncrementPersonSalary(int personId)
        {
            var person = People.Find(personId);
            if (person != null)
            {
                person.Salary += 1000;
            }
            else
            {
                throw new ArgumentOutOfRangeException("personId", personId, "person not in the list");
            }
        }
    }
}
