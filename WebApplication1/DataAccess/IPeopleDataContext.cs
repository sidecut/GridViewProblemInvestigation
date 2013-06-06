using System.Data.Entity;
using WebApplication1.Domain;

namespace WebApplication1.DataAccess
{
    public interface IPeopleDataContext
    {
        IDbSet<Person> People { get; }

        void IncrementPersonSalary(int personId);
    }
}
