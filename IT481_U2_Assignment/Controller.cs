using System;
using System.Data.SqlClient;


namespace IT481_U2_Assignment
{
    internal class Controller
    {
        string connectionString;
        SqlConnection cnn = null;
        private object dataReader;

        public Controller()
        {
            connectionString = "Server = LAPTOP-U7LAS3OD\\SQLEXPRESS; " +
                                        "Trusted_Connection=true;" +
                                        "Database=northwind;" +
                                        "User Instance=fals;" +
                                        "Connection timeout=30;";
        }

        //Constructor that takes DB connection string

        public Controller(string conn)
        {

            connectionString = conn;

        }

        //Method to get the customer table count

        public string getCustomerCount()
        {
            Int32 count = 0;

            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string countQuery = "select count(*) from customers;";
            SqlCommand cmd = new SqlCommand(countQuery, cnn);

            try
            {
                count = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return count.ToString();
        }

        //Method to get the company names

        public object getCompanyNames()
        {
            string names = "";
            SqlDataReader dataReader;

            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string countQuery = "select companyname from customers;";
            SqlCommand cmd = new SqlCommand(countQuery, cnn);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                try
                {
                    names = names + dataReader.GetValue(0) + "\n";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return names;
        }
    }
}
