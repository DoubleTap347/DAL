using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancersDAL.Models
{
    public class Project
    {
        private string v;

        public Project() { } // parameterless to instatiate a class that has no data

        public Project(string v)
        {
            this.v = v;
        }

        public Project(int id, string title, int freelancerId) //when we need a parameterized class to instantiate with data.
        {
            Id = id;
            Title = title;
            FreelancerId = freelancerId;
        }
        // Project has and Id, Title and FreelancerId who's values can be retrieved and set.
        public int Id { get; set; }
        public string Title { get; set; }
        public int FreelancerId { get; set; }
    }
}
//public interface Project
//{

//}