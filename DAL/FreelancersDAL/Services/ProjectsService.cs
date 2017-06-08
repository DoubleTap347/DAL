using FreelancersDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;
using FreelancersDAL.Services;


namespace FreelancersDAL.Services
{
    public class ProjectsService : IProjectsService
    {
        List<Project> projects = new List<Project>();
        string connectionString = ConfigurationManager.ConnectionStrings["FreelancersConnection"].ConnectionString.ToString();

        public List<Project> RetrieveProjects()
        {
            List<Project> projects = new List<Project>();

            MySqlDataReader dataReader;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                //Sql query to be executed in the database
                MySqlCommand command =
                    new MySqlCommand("SELECT Id, Title, FreelancerId " +
                    "FROM Projects ORDER BY Id;", conn);
                conn.Open();

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