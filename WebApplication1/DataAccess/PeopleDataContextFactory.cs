using System;

namespace WebApplication1.DataAccess
{
    public static class PeopleDataContextFactory
    {
        private static readonly Lazy<IPeopleDataContext> PeopleDataContext =
            new Lazy<IPeopleDataContext>(() => new FakePeopleDataContext());

        public static IPeopleDataContext GetPeopleDataContext()
        {
            return PeopleDataContext.Value;
        }
    }
}
