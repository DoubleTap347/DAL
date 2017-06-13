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
    public partial class DeleteFreelancerForm : Form
    {
        private readonly ICustomerService freelancersService;
        public DeleteFreelancerForm()
        {
            freelancersService = new CustomerService();
            InitializeComponent();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            this.Close(); //removed the "this" VS thinks it should be simplified. Let's see if this breaks later on.
        }

        private void btnDeleteFreelancer_Click(object sender, EventArgs e)
        {
            //if it is nulll, don't work. pls m8
            if (!String.IsNullOrEmpty(txtId.Text) &&
                !String.IsNullOrWhiteSpace(txtId.Text))
            {
                int id = 0;//initialize id as 0
                //try parse the input (txtId.Text)
                if (int.TryParse(txtId.Text, out id))
                {
                    try
                    {
                        bool result = freelancersService.DeleteFreelancer(id);

                        if (result)
                        {
                            lblStatus.Text = $"Successfully delete Freelancer with Id {id}!";
                        }
                        else
                        {
                            lblStatus.Text = $"Unable to delete freelancer with Id {id}.";
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
                    lblStatus.Text = "Invalid Freelancer Id.";
                }
            }
        }
    }
}
