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
        private readonly IFreelancersService freelancersService;
        public DeleteFreelancerForm()
        {
            freelancersService = new FreelancersService();
            InitializeComponent();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Close(); //removed the "this" VS thinks it should be simplified. Let's see if this breaks later on.
        }

        private void btnDeleteFreelancer_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtId.Text) &&
                !String.IsNullOrWhiteSpace(txtId.Text))
            {
                int id = 0;

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
                        lblStatus.Text = "An error has occurred!";// change the label to display and error has occurred
                        lblError.Text = ex.Message;// display the exception in the label
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
