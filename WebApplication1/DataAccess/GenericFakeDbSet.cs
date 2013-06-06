using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace WebApplication1.DataAccess
{
    internal class GenericFakeDbSet<T, TKey> : IDbSet<T> where T : class
    {
        private readonly HashSet<T> _hash;
        private readonly Func<T, TKey> _keySelector;
        private readonly IQueryable _query;

        public GenericFakeDbSet(Func<T, TKey> keySelector)
        {
            _hash = new HashSet<T>();
            _query = _hash.AsQueryable();
            _keySelector = keySelector;
        }


        public T Find(params object[] keyValues)
        {
            var value = keyValues.First();
            return this.SingleOrDefault(item => _keySelector(item).Equals(value));
        }


        public T Add(T entity)
        {
            RemoveMatch(entity);
            _hash.Add(entity);
            return entity;
        }

        public T Attach(T entity)
        {
            RemoveMatch(entity);
            _hash.Add(entity);
            return entity;
        }

        public TDerivedEntity Create<TDerivedEntity>()
            where TDerivedEntity : class, T
        {
            return typeof (TDerivedEntity) as TDerivedEntity;
        }

        public T Create()
        {
            return typeof (T) as T;
        }


        public ObservableCollection<T> Local
        {
            get { throw new NotImplementedException("Must override Local"); }
        }

        public T Remove(T entity)
        {
            _hash.Remove(entity);
            return entity;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _hash.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _hash.GetEnumerator();
        }

        public Type ElementType
        {
            get { return _query.ElementType; }
        }

        public Expression Expression
        {
            get { return _query.Expression; }
        }

        public IQueryProvider Provider
        {
            get { return _query.Provider; }
        }

        public void RemoveMatch(T entity)
        {
            if (_keySelector(entity).Equals(default(TKey)))
            {
                return;
            }
            Remove(Find(_keySelector(entity)));
        }
    }
}
