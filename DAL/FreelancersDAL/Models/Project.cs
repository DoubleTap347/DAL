using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancersDAL.Models
{
    public class Project
    {
        public Project() { }

        public Project(int id, string title, int freelancerId)
        {
            id = Id;
            title = Title;
            freelancerId = FreelancerId;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int FreelancerId { get; set; }
    }
}
//public interface Project
//{

//}