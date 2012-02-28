using System;
using System.Collections.Generic;
using BabyFubuApp.Domain;
using Raven.Client;
using Raven.Client.Linq;

namespace BabyFubuApp.Core
{
    public interface ICrudService<T> where T : DomainEntity
    {
        void Create(T t);
        void Delete(T t);
        IEnumerable<T> FindAll();
        T Retrieve(Guid id);
    }

    public class CrudService<T> : ICrudService<T> where T : DomainEntity
    {
        private readonly IDocumentStore _store;

        public CrudService(IDocumentStore store)
        {
            _store = store;
        }

        public void Create(T t)
        {
            using(var session = _store.OpenSession())
            {
                var entity = t;
                entity.Created = DateTime.Now;
                entity.LastModified = entity.Created;

                session.Store(entity);
                session.SaveChanges();
            }
        }

        public void Delete(T t)
        {
            using (var session = _store.OpenSession())
            {
                session.Delete(t);
                session.SaveChanges();
            }
        }

        public IEnumerable<T> FindAll()
        {
            using (var session = _store.OpenSession())
            {
                return session.Query<T>();
            }
        }

        public T Retrieve(Guid id)
        {
            using(var session = _store.OpenSession())
            {
                return session.Load<T>(id);
            }
        }
    }
}