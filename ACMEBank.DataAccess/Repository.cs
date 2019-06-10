using ACME.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMEBank.DataAccess
{
    public abstract class Repository<T> : IRepository<T> where T : EntityBase
    {
        public abstract T Get(int id);

        public abstract IEnumerable<T> Get();

        public abstract T Create(T t);

        public virtual EnumerableRowCollection<DataRow> GetData(string tableName)
        {
            var ds = DataHelper.GetCustomer();
            var dt = ds.Tables[tableName];
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.AsEnumerable();
            }
            return null;
        }

        public virtual DataRow GetDatarow(string tableName)
        {
            var ds = DataHelper.GetCustomer();
            var dt = ds.Tables[tableName];
            return dt.NewRow();
        }

        public virtual void SaveDatarow(string tableName, DataRow dr)
        {
            dr.Table.Rows.Add(dr);
        }

        public virtual void DeleteDatarow(string tableName, DataRow dr)
        {
            dr.Table.Rows.Remove(dr);
        }

        public abstract void Delete(int id);
    }
}
