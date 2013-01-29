using System;
using System.Collections.Generic;

namespace Dominio.Simples.Dao
{
    public interface IDaoGeneric<T>
    {
        int Save(T obj);
        void Delete(T obj);
        T Get(Func<T, bool> expression);
        IList<T> Find(Func<T, bool> expression);
    }

    public abstract class DaoFactory
    {
        public abstract IDaoGeneric<T> GetDao<T>();
    }

    public class DaoFactoryNh : DaoFactory
    {
        public override IDaoGeneric<T> GetDao<T>()
        {
            return new DaoGenericNh<T>();
        }
    }

    public class DaoGenericNh<T> : IDaoGeneric<T>
    {
        public int Save(T obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(T obj)
        {
            throw new NotImplementedException();
        }

        public T Get(Func<T, bool> expression)
        {
            throw new NotImplementedException();
        }

        public IList<T> Find(Func<T, bool> expression)
        {
            throw new NotImplementedException();
        }
    }
}
