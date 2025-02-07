using Model;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class CustomerDao : BaseDao
    {
        public List<Customer> GetAll()
        {
            string query = "SELECT Id, EmailAddress, FirstName, LastName FROM customers";
            SqlParameter[] parameters = new SqlParameter[0];
            return ReadCustomers(ExecuteSelectQuery(query, parameters));
        }

        public List<Customer> ReadCustomers(DataTable dt)
        {
            List<Customer> customers = new List<Customer>();
            foreach (DataRow row in dt.Rows)
            {
                Customer customer = new Customer(
                    (int)row["Id"],
                    (string)row["EmailAddress"],
                    (string)row["FirstName"],
                    (string)row["LastName"]
                    );
                customers.Add(customer);
            }
            return customers;
        }

        public Customer GetById(int customerId)
        {
            string query = "SELECT Id, EmailAddress, FirstName, LastName FROM customers WHERE Id = @Id";
            SqlParameter[] parameters = new SqlParameter[1]
            {
                new SqlParameter("@Id", customerId)
            };
            return ReadCustomer(ExecuteSelectQuery(query, parameters));
        }

        public Customer ReadCustomer(DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            DataRow row = dt.Rows[0];
            return new Customer(
                (int)row["Id"],
                (string)row["EmailAddress"],
                (string)row["FirstName"],
                (string)row["LastName"]
                );
        }
    }
}
