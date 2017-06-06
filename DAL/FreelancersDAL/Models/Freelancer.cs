using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancersDAL.Models
{
    public class Freelancer
    {
        public Freelancer() { } // parameterless to instatiate a class that has no data
        public Freelancer(int id, string firstName, string lastName) //when we need a parameterized class to instantiate with data
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public Freelancer(int id, string firstName, string lastName, List<Project> projects) //when we need a parameterized class to instantiate with data.
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Projects = projects;
        }
        // get set allow us to retrieve and change the values
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Project> Projects { get; set; }
    }
}
