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
        public void IncrementPersonSalary(string personId)
        {
            throw new System.NotImplementedException();
        }
    }
}
