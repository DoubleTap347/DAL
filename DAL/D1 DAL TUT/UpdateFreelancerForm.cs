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
    public partial class UpdateFreelancerForm : Form
    {
        private readonly IFreelancersService freelancersService;

        public UpdateFreelancerForm()
        {
            freelancersService = new FreelancersService();
            InitializeComponent();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveFreelancer_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtFirstName.Text) &&
                !String.IsNullOrWhiteSpace(txtFirstName.Text) &&
                !String.IsNullOrEmpty(txtLastName.Text) &&
                !String.IsNullOrWhiteSpace(txtLastName.Text))
            {
                try
                {
                    Freelancer f = new Freelancer(0, txtFirstName.Text, txtLastName.Text);

                    f = freelancersService.UpdateFreelancer(f);

                    if (f != null)
                    {
                        lblStatus.Text = $"Successfully added Freelancer {f.FirstName} {f.LastName}";
                    }
                    else
                    {
                        lblStatus.Text = "Unable to add freelancer";
                    }
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "An error has occured!";
                    lblError.Text = ex.Message;
                }
            }
        }
    }
}
