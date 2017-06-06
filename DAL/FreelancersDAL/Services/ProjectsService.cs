using FreelancersDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient; //allow us to use the MySql connector
using System.Data;
using System.Data.Common;
using FreelancersDAL.Services;


namespace FreelancersDAL.Services
{
    public class ProjectsService : IProjectsService // Implement the IProjectsService interface
    {
        List<Project> projects = new List<Project>(); //create and instantiate the List<Project> object
        string connectionString = ConfigurationManager.ConnectionStrings["FreelancersConnection"].ConnectionString.ToString();

        public List<Project> RetrieveProjects()
        {
            List<Project> projects = new List<Project>();

            MySqlDataReader dataReader;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                //This is the command that holds the query that is sent to the database
                MySqlCommand command =
                    new MySqlCommand("SELECT Id, Title, FreelancerId " +
                    "FROM Projects ORDER BY Id;", conn);
                conn.Open(); //Open the connection here

                dataReader = command.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        projects.Add(new Project
                            (
                                dataReader.GetInt32("Id"),
                                dataReader.GetString("Title"),
                                dataReader.GetInt32("FreelancerId")
                                ));
                    }
                }
                conn.Close();
            }

                return projects;
        }
    }
}