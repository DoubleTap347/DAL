using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FreelancersDAL.Services;
using FreelancersDAL.Models;

namespace D1_DAL_TUT
{
    public partial class Dashboard : Form
    {
        private readonly IProjectsService projectsService;
        private readonly IFreelancersService freelancersService;

        public Dashboard()
        {

            freelancersService = new FreelancersService();
            projectsService = new ProjectsService();
            InitializeComponent();
        }

        private void btnFreelancers_Click(object sender, EventArgs e)
        {

        }

        private void btnFreelancersAndProjects_Click(object sender, EventArgs e)
        {
            listBoxResults.Items.Clear();

            try
            {
                List<Freelancer> freelancers = new List<Freelancer>();
                freelancers = freelancersService.RetrieveFreelancersWithProjects();

                if (freelancers != null && freelancers.Count > 0)
                {
                    foreach(Freelancer f in freelancers)
                    {
                        listBoxResults.Items.Add($"Freelancer: {f.LastName}, " +
                            $"{f.FirstName}, Id: {f.Id}.");

                        foreach(Project p in f.Projects)
                        {
                            listBoxResults.Items.Add($"         Project: {p.Title}, " +
                                $"linked to Freelancer: {p.FreelancerId}.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "An error has occurred!";
                lblError.Text = ex.Message;

                listBoxResults.Items.Add(ex.StackTrace);
            }
        }

        private void btnProjects_Click(object sender, EventArgs e)
        {
            listBoxResults.Items.Clear();

            try
            {
                List<Project> projects = new List<Project>();
                projects = projectsService.RetrieveProjects();

                if (projects != null && projects.Count > 0)
                {
                    foreach (Project p in projects)
                    {
                        listBoxResults.Items
                            .Add($"Project: {p.Title}, " +
                            $"Id: {p.Id}, " +
                            $"Linked to freelancer: {p.FreelancerId}.");
                    }
                }
                else
                {
                    listBoxResults.Items.Add("WTF no results.");
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error m8";
                lblError.Text = ex.Message;

                listBoxResults.Items.Add(ex.StackTrace);
            }
        }

        private void btnGetSingleFreelancer_Click(object sender, EventArgs e)
        {
            //Clear listbox first
            listBoxResults.Items.Clear();

            //Try catch to avoid crashes
            try
            {
                //Retrieve freelancer
                Freelancer freelancer = freelancersService
                    .RetrieveFreelancerByLastName(txtFreelancerName.Text);

                // If freelancer is not null
                // the lastname is not empty and is not whitespace
                if (freelancer != null &&
                    !String.IsNullOrEmpty(freelancer.LastName) &&
                    !String.IsNullOrWhiteSpace(freelancer.LastName))
                {
                    //Add the information to the listbox
                    listBoxResults.Items.Add(
                        $"Freelancer: {freelancer.FirstName} {freelancer.LastName}, " +
                        $"Id: {freelancer.Id}");
                }
                else
                {
                    listBoxResults.Items.Add(
                        "Could not find last name: " +
                        txtFreelancerName.Text);
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "An error has occured!";
                lblError.Text = ex.Message;

                listBoxResults.Items.Add(ex.StackTrace);
            }
        }

        private void button2_Click(object sender, EventArgs e) //Add freelancer button click event
        {
            new AddFreelancerForm().Show();
        }

        private void btnSearchProjects_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateFreelancer_Click(object sender, EventArgs e)
        {
            new UpdateFreelancerForm().Show();
        }

        private void btnDeleteFreelancer_Click(object sender, EventArgs e)
        {
            new DeleteFreelancerForm().Show();
        }

        private void btnTables_Click(object sender, EventArgs e)
        {
            new DataTableForm().Show();
        }
    }
}