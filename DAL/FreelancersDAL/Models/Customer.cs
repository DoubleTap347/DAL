using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancersDAL.Models
{
    public class Customer
    {
        public Customer() { }
        public Customer(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public Customer(int id, string firstName, string lastName, List<Project> projects)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Projects = projects;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Project> Projects { get; set; }
    }
}
