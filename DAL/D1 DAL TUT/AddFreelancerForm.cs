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
        private readonly IFreelancersService freelancersService;

        public AddFreelancerForm()
        {
            freelancersService = new FreelancersService();
            InitializeComponent();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            this.Close(); //Close the window
        }

        private void btnSaveFreelancer_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(txtFirstName.Text) &&
                !String.IsNullOrWhiteSpace(txtFirstName.Text) &&
                !String.IsNullOrEmpty(txtLastName.Text) &&
                !String.IsNullOrWhiteSpace(txtLastName.Text))
            {
                try
                {
                    Freelancer f = new Freelancer(0, txtFirstName.Text, txtLastName.Text);

                    f = freelancersService.AddFreelancer(f);

                    if (f != null) //if input is not null
                    {
                        lblStatus.Text = $"Successfully added Freelancer {f.FirstName} {f.LastName}";
                    }
                    else
                    {
                        lblStatus.Text = "Unable to add freelancer";
                    }
                }
                catch (Exception ex) // catching the exception and making the status label say "An error has occured!" and the error label display the exception message: ex.Message
                {
                    lblStatus.Text = "An error has occured!";
                    lblError.Text = ex.Message;
                }
            }
        }
    }
}
