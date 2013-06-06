using System;

namespace WebApplication1.DataAccess
{
    internal static class FakeDbSetBuilder
    {
        public static FakeDbSetBuilder<T> New<T>() where T : class
        {
            return new FakeDbSetBuilder<T>();
        }
    }

    internal class FakeDbSetBuilder<T> where T : class
    {
        public GenericFakeDbSet<T, TKey> Build<TKey>(Func<T, TKey> keySelector)
        {
            return new GenericFakeDbSet<T, TKey>(keySelector);
        }
    }
}
