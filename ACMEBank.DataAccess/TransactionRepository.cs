using ACME.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMEBank.DataAccess
{
    public class TransactionRepository : Repository<Transaction>
    {
        public override Transaction Get(int id)
        {
            var rows = GetData("Transaction");
            if (rows != null)
            {
                var dr = rows.FirstOrDefault(x => x.Field<int>("Id") == id);
                if (dr != null)
                {
                    return GetTransaction(dr);
                }
            }
            return null;
        }

        public override IEnumerable<Transaction> Get()
        {
            var transaction = new List<Transaction>();
            var rows = GetData("Transaction");
            if (rows != null)
            {
                transaction.AddRange(rows.Select(dr => new Transaction
                {
                    Id = dr.Field<int>("Id"),
                    AccountId = dr.Field<int>("AccountId"),
                    Amount = dr.Field<decimal>("Amount"),
                    Type = dr.Field<string>("Type")
                }));
            }
            return transaction;
        }

        private static Transaction GetTransaction(DataRow dr)
        {
            var transaction = new Transaction();
            transaction.Id = dr.Field<int>("Id");
            transaction.AccountId = dr.Field<int>("AccountId");
            transaction.Amount = dr.Field<decimal>("Amount");
            transaction.Type = dr.Field<string>("Type");
            return transaction;
        }


        public override Transaction Create(Transaction t)
        {
            var dr = GetDatarow("Transaction");

            //dr.SetField("Id", t.Id);
            dr.SetField("AccountId", t.AccountId);
            dr.SetField("Amount", t.Amount);
            dr.SetField("Type", t.Type);
            SaveDatarow("Transaction", dr);

            return GetTransaction(dr);
        }

        public override void Delete(int id)
        {
            var rows = GetData("Transaction");
            if (rows != null)
            {
                var dr = rows.FirstOrDefault(x => x.Field<int>("Id") == id);
                DeleteDatarow("Transaction", dr);
            }
        }
    }
}
