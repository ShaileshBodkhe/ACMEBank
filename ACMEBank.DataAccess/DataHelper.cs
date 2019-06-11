using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMEBank.DataAccess
{
    public static class DataHelper
    {
        public static DataSet _ds = null;
        public static DataSet GetCustomer()
        {
            if (_ds == null)
            {
                var ds = new DataSet();
                // ds.ReadXml(@"C:\DEV\PersonalProjects\ACMEBank\ACMEBank\App_Data\Customer.xml");
                // return ds;

                var dt = new DataTable("Customer");
                dt.Columns.Add("Id", typeof(int)).AutoIncrement = true;
                dt.Columns.Add("FirstName", typeof(string));
                dt.Columns.Add("LastName", typeof(string));
                dt.Columns.Add("Email", typeof(string));
                dt.Columns.Add("Address", typeof(string));
                dt.Columns.Add("IsMarried", typeof(bool));
                dt.Columns.Add("BirthDate", typeof(DateTime));
                dt.Columns.Add("Status", typeof(string));

                var dr = dt.NewRow();
                dr["Id"] = 1;
                dr["FirstName"] = "John";
                dr["LastName"] = "Doe";
                dr["Email"] = "John.Doe@gmail.com";
                dr["Address"] = "111 W Addison ave, Chicago, IL";
                dr["IsMarried"] = true;
                dr["BirthDate"] = DateTime.Parse("02/02/1970");
                dr["Status"] = "Active";
                dt.Rows.Add(dr);

                var dr1 = dt.NewRow();
                dr1["Id"] = 2;
                dr1["FirstName"] = "John Two";
                dr1["LastName"] = "Doe Two";
                dr1["Email"] = "John.Doe.Two@gmail.com";
                dr1["Address"] = "222 S NY ave, NYC, NY";
                dr["IsMarried"] = false;
                dr["BirthDate"] = DateTime.Parse("02/02/2001");
                dr["Status"] = "Active";
                dt.Rows.Add(dr1);

                var dr2 = dt.NewRow();
                dr2["Id"] = 3;
                dr2["FirstName"] = "John Three";
                dr2["LastName"] = "Doe Three";
                dr2["Email"] = "John.Doe.Three@gmail.com";
                dr2["Address"] = "333 W Monroe ave, Princeton, NJ";
                dr["IsMarried"] = true;
                dr["BirthDate"] = DateTime.Parse("02/02/1990");
                dr["Status"] = "Inactive";
                dt.Rows.Add(dr2);

                var dr3 = dt.NewRow();
                dr3["Id"] = 4;
                dr3["FirstName"] = "John Four";
                dr3["LastName"] = "Doe Four";
                dr3["Email"] = "John.Doe.Four@gmail.com";
                dr3["Address"] = "333 W Monroe ave, Princeton, NJ";
                dr["IsMarried"] = false;
                dr["BirthDate"] = DateTime.Parse("02/02/1985");
                dr["Status"] = "Active";
                dt.Rows.Add(dr3);

                ds.Tables.Add(dt);
                ds.Tables.Add(GetDataTable());
                ds.Tables.Add(GetTranDataTable());

                _ds = ds;
            }
            //ds.WriteXml(@"C:\DEV\PersonalProjects\ACMEBank\ACMEBank\App_Data\Customer.xml");
            return _ds;
        }

        private static DataTable GetDataTable()
        {
            var dt = new DataTable("Account");
            dt.Columns.Add("Id", typeof(int)).AutoIncrement = true;
            dt.Columns.Add("CustomerId", typeof(int));
            dt.Columns.Add("AccountType", typeof(string));
            dt.Columns.Add("Status", typeof(string));

            var dr = dt.NewRow();
            dr["Id"] = 1;
            dr["CustomerId"] = 1;
            dr["AccountType"] = "Saving";
            dr["Status"] = "Active";
            dt.Rows.Add(dr);

            var dr1 = dt.NewRow();
            dr1["Id"] = 2;
            dr1["CustomerId"] = 1;
            dr1["AccountType"] = "Checking";
            dr1["Status"] = "Active";
            dt.Rows.Add(dr1);

            var dr2 = dt.NewRow();
            dr2["Id"] = 3;
            dr2["CustomerId"] = 2;
            dr2["AccountType"] = "Saving";
            dr2["Status"] = "Active";
            dt.Rows.Add(dr2);

            var dr3 = dt.NewRow();
            dr3["Id"] = 4;
            dr3["CustomerId"] = 4;
            dr3["AccountType"] = "Checking";
            dr3["Status"] = "Active";
            dt.Rows.Add(dr3);

            dr3 = dt.NewRow();
            dr3["Id"] = 5;
            dr3["CustomerId"] = 4;
            dr3["AccountType"] = "Saving";
            dr3["Status"] = "Inactive";
            dt.Rows.Add(dr3);

            return dt;
        }

        private static DataTable GetTranDataTable()
        {
            var dt = new DataTable("Transaction");
            dt.Columns.Add("Id", typeof(int)).AutoIncrement = true;
            dt.Columns.Add("AccountId", typeof(int));
            dt.Columns.Add("Amount", typeof(decimal));
            dt.Columns.Add("Type", typeof(string));
            int i = 0;
            var dr = dt.NewRow();
            dr["Id"] = i++;
            dr["Amount"] = 10.20;
            dr["AccountId"] = 1;
            dr["Type"] = "Cr";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = i++;
            dr["Amount"] = 24.23;
            dr["AccountId"] = 2;
            dr["Type"] = "Cr";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = i++;
            dr["Amount"] = 1;
            dr["AccountId"] = 1;
            dr["Type"] = "Dr";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = i++;
            dr["AccountId"] = 2;
            dr["Amount"] = 20.50;
            dr["Type"] = "Cr";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = i++;
            dr["AccountId"] = 3;
            dr["Amount"] = 50;
            dr["Type"] = "Dr";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = i++;
            dr["Amount"] = 12;
            dr["AccountId"] = 4;
            dr["Type"] = "Cr";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = i++;
            dr["Amount"] = 21;
            dr["AccountId"] = 5;
            dr["Type"] = "Dr";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = i++;
            dr["AccountId"] = 5;
            dr["Amount"] = 9.80;
            dr["Type"] = "Cr";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = i++;
            dr["AccountId"] = 4;
            dr["Amount"] = 7.80;
            dr["Type"] = "Cr";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = i++;
            dr["AccountId"] = 5;
            dr["Amount"] = 98.45;
            dr["Type"] = "Dr";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = i++;
            dr["AccountId"] = 3;
            dr["Amount"] = 40.60;
            dr["Type"] = "Dr";
            dt.Rows.Add(dr);

            return dt;
        }
    }
}
