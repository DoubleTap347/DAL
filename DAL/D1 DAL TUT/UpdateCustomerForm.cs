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
    public partial class UpdateCustomerForm : Form
    {
        private readonly ICustomerService freelancersService;
        public UpdateCustomerForm()
        {
            freelancersService = new CustomerService();
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
                        Customer f = new Customer(
                        id,
                        txtFirstName.Text,
                        txtLastName.Text
                        );

                        f = freelancersService.UpdateFreelancer(f);

                        if (f != null)
                        {
                            lblStatus.Text = $"Successfully updated customer " +
                                $"{f.FirstName} {f.LastName}!";
                        }
                        else
                        {
                            lblStatus.Text = $"Sorry, couldn't update customer.";
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
                    lblStatus.Text = "Invalid Customer Id";
                }
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
