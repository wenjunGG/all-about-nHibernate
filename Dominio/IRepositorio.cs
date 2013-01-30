using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dominio.Repositorio
{
    public interface IRepository<T>
    {
        T Get(Func<T, bool> expression);
        IList<T> Find(Expression<Func<T, bool>> expression);
        void Delete(Expression<Func<T, bool>> expression);
        void Delete(T obj);
        void Save(T obj);
    }
}
