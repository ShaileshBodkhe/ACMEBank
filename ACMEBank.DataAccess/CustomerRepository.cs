using ACME.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMEBank.DataAccess
{
    public class CustomerRepository : Repository<Customer>
    {
      
        public override Customer Get(int id)
        {
            var rows = GetData("Customer");
            if (rows != null)
            {
                var dr = rows.FirstOrDefault(x => x.Field<int>("Id") == id);
                if (dr != null)
                {
                    return GetCustomer(dr);
                }
            }
            return null;
        }

        private static Customer GetCustomer(DataRow dr)
        {
            var customer = new Customer();
            customer.Id = dr.Field<int>("Id");
            customer.FirstName = dr.Field<string>("FirstName");
            customer.LastName = dr.Field<string>("LastName");
            customer.Email = dr.Field<string>("Email");
            customer.Address = dr.Field<string>("Address");
            return customer;
        }

        public override IEnumerable<Customer> Get()
        {
            var customers = new List<Customer>();
            var rows = GetData("Customer");
            if (rows != null)
            {
                customers.AddRange(rows.Select(dr => new Customer
                {
                    Id = dr.Field<int>("Id"),
                    FirstName = dr.Field<string>("FirstName"),
                    LastName = dr.Field<string>("LastName"),
                    Email = dr.Field<string>("Email"),
                    Address = dr.Field<string>("Address")
                }));
            }
            return customers;
        }

        public override Customer Create(Customer customer)
        {
            var dr = GetDatarow("Customer");

            dr.SetField("FirstName", customer.FirstName);
            dr.SetField("LastName", customer.LastName);
            dr.SetField("Email", customer.Email);
            dr.SetField("Address", customer.Address);
            SaveDatarow("Customer", dr);

            return GetCustomer(dr);
        }

        public override void Delete(int id)
        {
            var rows = GetData("Customer");
            if (rows != null)
            {
                var dr = rows.FirstOrDefault(x => x.Field<int>("Id") == id);
                DeleteDatarow("Customer", dr);
            }
        }
    }
}
