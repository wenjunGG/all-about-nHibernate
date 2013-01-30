using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public interface IRepository<T>
    {
        T Get(Func<T, bool> expression);
        IList<T> Find(Func<T, bool> expression);
        //IList<T> Find(params Func<T, bool> expression);
        void Delete(Func<T, bool> expression);
        void Delete(T obj);
        void Save(T obj);
    }

    //public interface IUnitOfWork
    //{
    //    void IsNew(object obj);
    //    void IsDirty(object obj);
    //    void IsRemoved(object obj);
    //    void IsClean(object obj);
    //    void BeginTransaction();
    //    void Commit();
    //    void Rollback();
    //}

    //public class UnitOfWorkNh : IUnitOfWork
    //{
    //    private ISession _session;

    //    public void IsNew(object obj)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void IsDirty(object obj)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void IsRemoved(object obj)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void IsClean(object obj)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void BeginTransaction()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Commit()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Rollback()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //public class Repository<T> : IRepository<T>
    //{
    //    private IUnitOfWork _unitOfWork;
        
    //    public Repository(IUnitOfWork unitOfWork)
    //    {
    //        _unitOfWork = unitOfWork;
    //    }

    //    public T Get(Func<T, bool> expression)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IList<T> Find(Func<T, bool> expression)
    //    {
    //        throw new NotImplementedException();
    //    }


    //    public void Delete(Func<T, bool> expression)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Delete(T obj)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Save(T obj)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
