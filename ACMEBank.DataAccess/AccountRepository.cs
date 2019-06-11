using ACME.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMEBank.DataAccess
{
    public class AccountRepository : Repository<Account>
    {
        public override Account Create(Account t)
        {
            var dr = GetDatarow("Account");

            //dr.SetField("Id", t.Id);
            dr.SetField("CustomerId", t.CustomerId);
            dr.SetField("AccountType", t.AccountType);
            dr.SetField("Status", t.Status);
            SaveDatarow("Account", dr);

            return GetAccount(dr);
        }

        private static Account GetAccount(DataRow dr)
        {
            var account = new Account();
            account.Id = dr.Field<int>("Id");
            account.CustomerId = dr.Field<int>("CustomerId");
            account.Status = dr.Field<string>("Status");
            account.AccountType = dr.Field<string>("AccountType");
            return account;
        }

        public override void Delete(int id)
        {
            var rows = GetData("Account");
            if (rows != null)
            {
                var dr = rows.FirstOrDefault(x => x.Field<int>("Id") == id);
                DeleteDatarow("Account", dr);
            }
        }

        public override Account Get(int id)
        {
            var rows = GetData("Account");
            if (rows != null)
            {
                var dr = rows.FirstOrDefault(x => x.Field<int>("Id") == id);
                if (dr != null)
                {
                    return GetAccount(dr);
                }
            }
            return null;
        }

        public override IEnumerable<Account> Get()
        {
            var accounts = new List<Account>();
            var rows = GetData("Account");
            if (rows != null)
            {
                accounts.AddRange(rows.Select(dr => new Account
                {
                    Id = dr.Field<int>("Id"),
                    CustomerId = dr.Field<int>("CustomerId"),
                    AccountType = dr.Field<string>("AccountType"),
                    Status = dr.Field<string>("Status")
                }));
            }
            return accounts;
        }
    }
}
