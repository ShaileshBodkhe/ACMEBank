using ACME.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMEBank.DataAccess
{
    public interface IRepository<T> where T : EntityBase
    {
        T Get(int id);
        IEnumerable<T> Get();

        T Create(T t);

        void Delete(int id);
    }
}
