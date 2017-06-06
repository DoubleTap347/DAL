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

        private void btnUpdateFreelancer_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtFirstName.Text) &&
                !String.IsNullOrWhiteSpace(txtFirstName.Text) &&
                !String.IsNullOrEmpty(txtLastName.Text) &&
                !String.IsNullOrWhiteSpace(txtLastName.Text) &&
                !String.IsNullOrEmpty(txtId.Text) &&
                !String.IsNullOrWhiteSpace(txtId.Text))
            {
                int id = 0;
                
                if (int.TryParse(txtId.Text, out id))
                {
                    try
                    {
                        Freelancer f = new Freelancer(
                        id,
                        txtFirstName.Text,
                        txtLastName.Text
                        );

                        f = freelancersService.UpdateFreelancer(f);

                        if (f != null)
                        {
                            lblStatus.Text = $"Successfully updated Freelancer " +
                                $"{f.FirstName} {f.LastName}!";
                        }
                        else
                        {
                            lblStatus.Text = $"Sorry, couldn't update freelancer.";
                        }
                    }
                    catch (Exception ex)
                    {
                        lblStatus.Text = "An error has occurred!";
                        lblError.Text = ex.Message;
                    }
                }
                else
                {
                    lblStatus.Text = "Invalid Freelancer Id";
                }
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
