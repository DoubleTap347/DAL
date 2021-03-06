﻿using FreelancersDAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancersDAL.Services
{
    public interface IFreelancersService
    {
        //Declare new methods
        List<Freelancer> RetrieveFreelancers();
        List<Freelancer> RetrieveFreelancersWithProjects();
        Freelancer RetrieveFreelancerByLastName(string lastname);
        Freelancer AddFreelancer(Freelancer freelancer);
        Freelancer UpdateFreelancer(Freelancer freelancer);
        bool DeleteFreelancer(int freelancerId);
        DataSet GetDisconnectedData();
    }
}