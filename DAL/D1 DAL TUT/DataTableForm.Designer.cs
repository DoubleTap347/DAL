namespace D1_DAL_TUT
{
    partial class DataTableForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridViewFreelancers = new System.Windows.Forms.DataGridView();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFreelancers)).BeginInit();
            this.SuspendLayout();
            // 
            // gridViewFreelancers
            // 
            this.gridViewFreelancers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewFreelancers.Location = new System.Drawing.Point(12, 12);
            this.gridViewFreelancers.Name = "gridViewFreelancers";
            this.gridViewFreelancers.Size = new System.Drawing.Size(383, 163);
            this.gridViewFreelancers.TabIndex = 0;
            // 
            // btnDashboard
            // 
            this.btnDashboard.Location = new System.Drawing.Point(57, 305);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(116, 23);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(227, 305);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(116, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 232);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Status";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(12, 263);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(29, 13);
            this.lblError.TabIndex = 4;
            this.lblError.Text = "Error";
            // 
            // DataTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 340);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnDashboard);
            this.Controls.Add(this.gridViewFreelancers);
            this.Name = "DataTableForm";
            this.Text = "DataTableForm";
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFreelancers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridViewFreelancers;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblError;
    }
}