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
    public partial class DataTableForm : Form
    {
        private readonly ICustomerService freelancersService;
        private DataSet dataSetFreelancers;
        public DataTableForm()
        {
            freelancersService = new CustomerService();
            this.gridViewFreelancers = new DataGridView();

            InitializeComponent();
        }

        private void InitializeDataGrid()
        {
            try
            {
                dataSetFreelancers = freelancersService.GetDisconnectedData();

                this.gridViewFreelancers.DataSource = dataSetFreelancers.Tables["Freelancers"];
                this.gridViewFreelancers.DataMember = "Freelancers";
                gridViewFreelancers.Refresh();
            }
            catch(Exception ex)
            {
                lblStatus.Text = "An error has occurred!";
                lblError.Text = ex.Message;
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            InitializeDataGrid();
        }
    }
}
