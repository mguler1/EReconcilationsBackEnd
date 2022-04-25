using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity,new()
    {
        void Add(T companies);
        void Update(T companies);
        void Delete(T companies);
        List<T> GetList(Expression<Func<T,bool>>filter=null);
        T Get(Expression<Func<T, bool>>);
    }
}
