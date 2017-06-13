using FreelancersDAL.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancersDAL.Services
{
    public class CustomerService : ICustomerService
    {
        //connection string to connect to the database
        string connectionString = ConfigurationManager.ConnectionStrings["CustardConnection"].ConnectionString.ToString();

        public DataSet GetDisconnectedData()
        {
            DataSet dataSetFreelancers = new DataSet();

            using (MySqlConnection conn = new MySqlConnection(connectionString))//using a MySqlConnection to connect to the database
            {
                //Sql query to be executed in the database
                MySqlCommand command = new MySqlCommand("SELECT * FROM customers;", conn);
                command.CommandType = System.Data.CommandType.Text;
                MySqlDataAdapter dataAdapterFreelancers = new MySqlDataAdapter(command);

                conn.Open();
                dataAdapterFreelancers.Fill(dataSetFreelancers, "customers");
            }

            return dataSetFreelancers;
        }
        //custard
        public Customer UpdateFreelancer(Customer customer) // For updating the customer details
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                //yet another sql query.
                //the @"field" are for preventing sql injection
                MySqlCommand command = new MySqlCommand(
                    "UPDATE customers SET " +
                    "FirstName = @firstName, " +
                    "LastName = @lastName " +
                    "WHERE Id = @id;", conn);

                //below we are taking the input from the user and executing them as SQL, but done with an "@" to avoid sql injection.
                MySqlParameter firstName = new MySqlParameter("@firstName", MySqlDbType.VarChar, 200);
                MySqlParameter lastName = new MySqlParameter("@lastName", MySqlDbType.VarChar, 200);
                MySqlParameter id = new MySqlParameter("@id", MySqlDbType.UInt32, 11);

                firstName.Value = customer.FirstName;
                lastName.Value = customer.LastName;
                id.Value = customer.Id;

                command.Parameters.Add(firstName);
                command.Parameters.Add(lastName);
                command.Parameters.Add(id);

                conn.Open(); //open the connection
                command.Prepare(); // command parameters are prepared.

                int result = command.ExecuteNonQuery(); // execute will return the number of changes, hence the int.

                conn.Close(); //close the connection. You said this was important. :)

                if (result <= 0)
                {
                    return null;
                }

                return customer;
            }
        }

        public bool DeleteFreelancer(int freelancerId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                //MySql Query with @ to protect against sql injection
                MySqlCommand command = new MySqlCommand(
                    "DELETE FROM Freelancers " +
                    "WHERE Id = @id;", conn);

                MySqlParameter id =
                    new MySqlParameter("@id", MySqlDbType.UInt32, 11);

                id.Value = freelancerId;

                command.Parameters.Add(id);
                conn.Open();
                command.Prepare();

                int result = command.ExecuteNonQuery();

                conn.Close();

                if (result <= 0)
                {
                    return false;
                }

                return true;
            }
        }

        public Customer AddFreelancer(Customer freelancer)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                //MySql Query with @ to protect against sql injection
                MySqlCommand command = new MySqlCommand(
                    "INSERT INTO Freelancers (FirstName, LastName) " +
                    "VALUES (@firstName, @lastName);", conn);
                //below is input taken from the user but also avoiding sql injection
                MySqlParameter firstName =
                    new MySqlParameter("@firstName", MySqlDbType.VarChar, 200);
                MySqlParameter lastName =
                    new MySqlParameter("@lastName", MySqlDbType.VarChar, 200);

                firstName.Value = freelancer.FirstName;
                lastName.Value = freelancer.LastName;
                //opening the connection and preparing the parameters
                command.Parameters.Add(firstName);
                command.Parameters.Add(lastName);

                conn.Open();//open connection
                command.Prepare();//prepare the command with the parameters

                int result = command.ExecuteNonQuery(); //method executes a query that does not return results but the number of changes. 
                //If the integer result contains more than 1 we have successfully made changes to the database(inserted a new freelancer)
                conn.Close();// important to close the connection

                if (result <= 0)
                {
                    freelancer = null; //If the "insert into" statement failed tell the user about it by returning a null object
                }
            }
            return freelancer; //return the freelancer object back. If there is data we know it worked
        }

        public Customer RetrieveFreelancerByLastName(string lastName)
        {
            //Initializing empty object to hold data.
            Customer freelancer = new Customer();

            MySqlDataReader dataReader;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                // This is the command to run an SQL query
                MySqlCommand command = new MySqlCommand(
                    "SELECT Id, FirstName, LastName " +
                    "FROM Freelancers " +
                    "WHERE LastName = @lastName;", conn);

                MySqlParameter lastNameParameter =
                    new MySqlParameter("@lastName", MySqlDbType.VarChar, 200)
                    {
                        Value = lastName
                    };
                conn.Open();

                command.Parameters.Add(lastNameParameter);
                command.Prepare();

                dataReader = command.ExecuteReader();

                // Return the first row.
                if (dataReader.HasRows)
                {
                    dataReader.Read();

                    freelancer.FirstName = dataReader.GetString("FirstName");
                    freelancer.LastName = dataReader.GetString("LastName");
                    freelancer.Id = dataReader.GetInt32("Id");
                }
                conn.Close();
            }

                return freelancer;
        }

        public List<Customer> RetrieveFreelancersWithProjects()
        {
            List<Customer> freelancers = new List<Customer>();
            MySqlDataReader dataReader;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(//MySql Query with @ to protect against sql injection
                    "SELECT Freelancers.Id, Freelancers.FirstName, " +
                    "Freelancers.LastName, Projects.Title " +
                    "FROM Freelancers " +
                    "INNER JOIN Projects " +
                    "ON Projects.FreelancerId = Freelancers.Id " +
                    "ORDER BY Freelancers.Id", conn);

                conn.Open();//Open the connection and execute the command
                dataReader = command.ExecuteReader();

                if (dataReader.HasRows)
                {
                    // We are going to avoid duplicating data from the intersection table.
                    int freelancerId = 0;

                    while (dataReader.Read())
                    {
                        //Same freelancer. let's join the projects together.
                        //
                        if (freelancerId == dataReader.GetInt32("Id"))
                        {
                            freelancers.Last().Projects.Add(new Project(
                                0,
                                dataReader.GetString("Title"),
                                dataReader.GetInt32("Id")
                                ));
                        }
                        else
                        {
                            freelancerId = dataReader.GetInt32("Id");

                            Project p = new Project(
                                0,
                                dataReader.GetString("Title"),
                                dataReader.GetInt32("Id")
                                );

                            freelancers.Add(new Customer(
                                dataReader.GetInt32("Id"),
                                dataReader.GetString("FirstName"),
                                dataReader.GetString("LastName"),
                                new List<Project> { p }
                                ));
                        }
                    }
                }
                conn.Close();
            }
            return freelancers;
        }
        public List<Customer> RetrieveFreelancers()//throws an "NotImplementedException" if it occurs
        {
            throw new NotImplementedException("Throw exception test. This goes into the error label");
        }
    }
}
