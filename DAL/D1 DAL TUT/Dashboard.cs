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
        private readonly IProjectService projectsService;
        private readonly ICustomerService CustomerService;

        public Dashboard()
        {

            CustomerService = new CustomerService();
            projectsService = new ProjectsService();
            InitializeComponent();
        }

        private void btnFreelancers_Click(object sender, EventArgs e)
        {
            listBoxResults.Items.Clear();

            try
            {
                List<Customer> freelancers = new List<Customer>();
                freelancers = CustomerService.RetrieveFreelancers();

            }
            catch (Exception ex)
            {
                lblStatus.Text = "An error has occurred!";
                lblError.Text = ex.Message;
                listBoxResults.Items.Add(ex.StackTrace);
            }
        }

        private void btnFreelancersAndProjects_Click(object sender, EventArgs e)
        {
            listBoxResults.Items.Clear();

            try
            {
                List<Customer> freelancers = new List<Customer>();
                freelancers = CustomerService.RetrieveFreelancersWithProjects();

                if (freelancers != null && freelancers.Count > 0)
                {
                    foreach(Customer f in freelancers)
                    {
                        listBoxResults.Items.Add($"Freelancer: {f.LastName}, " +
                            $"{f.FirstName}, Id: {f.Id}.");

                        foreach(Project p in f.Projects)
                        {
                            listBoxResults.Items.Add($"Project: {p.Title}, " +
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

        private void btnGetSingleFreelancer_Click(object sender, EventArgs e)
        {
            //Clear listbox first
            listBoxResults.Items.Clear();

            //Try catch to avoid crashes
            try
            {
                //Retrieve customer
                Customer customer = CustomerService
                    .RetrieveCustomersByLastName(txtFreelancerName.Text);

                // If freelancer is not null
                // the lastname is not empty and is not whitespace
                if (customer != null &&
                    !String.IsNullOrEmpty(customer.LastName) &&
                    !String.IsNullOrWhiteSpace(customer.LastName))
                {
                    //Add the information to the listbox
                    listBoxResults.Items.Add(
                        $"Customer: {customer.FirstName} {customer.LastName}, " +
                        $"Id: {customer.Id}");
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
        //Click events below. Show the forms to allow the user to CRUD
        private void button2_Click(object sender, EventArgs e) //Add freelancer button click event
        {
            new AddFreelancerForm().Show();
        }

        private void btnSearchProjects_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateFreelancer_Click(object sender, EventArgs e)
        {
            new UpdateCustomerForm().Show();
        }

        private void btnDeleteFreelancer_Click(object sender, EventArgs e)
        {
            new DeleteFreelancerForm().Show();
        }

        private void btnTables_Click(object sender, EventArgs e)
        {
            new DataTableForm().Show();
        }

        private void btnProjects_Click(object sender, EventArgs e)
        {

        }
    }
}