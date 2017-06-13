using FreelancersDAL.Models;
using FreelancersDAL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D1_DAL_TUT
{
    public partial class AddFreelancerForm : Form
    {
        private readonly ICustomerService freelancersService;

        public AddFreelancerForm()
        {
            freelancersService = new CustomerService();
            InitializeComponent();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveFreelancer_Click(object sender, EventArgs e)
        {
            //if the data our user entered is null we go into the try catch below
            if(!String.IsNullOrEmpty(txtFirstName.Text) &&
                !String.IsNullOrWhiteSpace(txtFirstName.Text) &&
                !String.IsNullOrEmpty(txtLastName.Text) &&
                !String.IsNullOrWhiteSpace(txtLastName.Text))
            {
                try//starting the try catch block
                {
                    Customer f = new Customer(0, txtFirstName.Text, txtLastName.Text);//Hold data in the freelancer object. Made possible because of the Parameterized Constructor made earlier
                    //we need to add in the Id as 0 otherwise the constructor will throw an error because it takes in 3 parameters.
                    f = freelancersService.AddFreelancer(f);
                    //Assign f to the object created by Freelancer. If there is data our method will succeed. If it fails it will be null
                    if (f != null)
                    {
                        lblStatus.Text = $"Successfully added Customer {f.FirstName} {f.LastName}";
                    }
                    else
                    {
                        lblStatus.Text = "Unable to add Customer";
                    }
                }
                catch (Exception ex)//If something goes wrong prevent crash and display to user
                {
                    lblStatus.Text = "An error has occured!";
                    lblError.Text = ex.Message;
                }
            }
        }
    }
}
