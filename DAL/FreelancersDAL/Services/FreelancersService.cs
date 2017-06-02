using FreelancersDAL.Models;
using FreelancersDAL.Services;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancersDAL.Services
{
    public class FreelancersService
    {
        public bool DeleteFreelancer(int freelancerId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
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
        string connectionString = ConfigurationManager
            .ConnectionStrings["FreelancersConnection"]
            .ConnectionString.ToString();

        public Freelancer AddFreelancer(Freelancer freelancer)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(
                    "INSERT INTO Freelancers (FirstName, LastName) " +
                    "VALUES (@firstName, @lastName);", conn);

                MySqlParameter firstName =
                    new MySqlParameter("@firstName", MySqlDbType.VarChar, 200);
                MySqlParameter lastName =
                    new MySqlParameter("@lastName", MySqlDbType.VarChar, 200);
                MySqlParameter id =
                    new MySqlParameter("@id", MySqlDbType.UInt32, 11);

                firstName.Value = freelancer.FirstName;
                lastName.Value = freelancer.LastName;
                id.Value = freelancer.Id;

                command.Parameters.Add(firstName);
                command.Parameters.Add(lastName);
                command.Parameters.Add(id);

                conn.Open();
                command.Prepare();

                int result = command.ExecuteNonQuery();

                conn.Close();

                if (result <= 0)
                {
                    return null;
                }
                return freelancer;
            }
        }

        public Freelancer RetrieveFreelancerByLastName(string lastName)
        {
            //Initializing empty object to hold data.
            Freelancer freelancer = new Freelancer();

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

        public List<Freelancer> RetrieveFreelancersWithProjects()
        {
            List<Freelancer> freelancers = new List<Freelancer>();
            MySqlDataReader dataReader;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(
                    "SELECT Freelancers.Id, Freelancers.FirstName, " +
                    "Freelancers.LastName, Projects.Title " +
                    "FROM Freelancers " +
                    "INNER JOIN Projects " +
                    "ON Projects.FreelancerId = Freelancers.Id " +
                    "ORDER BY Freelancers.Id", conn);

                conn.Open();
                dataReader = command.ExecuteReader();

                if (dataReader.HasRows)
                {
                    // We are going to avoid duplicating data from the intersection table.
                    int freelancerId = 0;

                    while (dataReader.Read())
                    {
                        //Same freelancer. let's join the projects together.
                        if (freelancerId == dataReader.GetInt32("Id"))
                        {
                            freelancers.Last().Projects.Add(new Project(
                                0,
                                dataReader.GetString("Title"),
                                dataReader.GetInt32("Id")
                                ));
                        }
                        else   // ELSE
                        {
                            freelancerId = dataReader.GetInt32("Id");

                            Project p = new Project(
                                0,
                                dataReader.GetString("Title"),
                                dataReader.GetInt32("Id")
                                );

                            freelancers.Add(new Freelancer(
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
        public List<Freelancer> RetrieveFreelancers()
        {
            throw new NotImplementedException("Throw exception test. Is this a messagebox?");
        }
    }
}
