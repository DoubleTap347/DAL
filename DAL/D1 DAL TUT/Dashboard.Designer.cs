namespace D1_DAL_TUT
{
    partial class Dashboard
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
            this.btnFreelancersAndProjects = new System.Windows.Forms.Button();
            this.btnProjects = new System.Windows.Forms.Button();
            this.btnFreelancers = new System.Windows.Forms.Button();
            this.listBoxResults = new System.Windows.Forms.ListBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.txtFreelancerName = new System.Windows.Forms.TextBox();
            this.btnGetSingleFreelancer = new System.Windows.Forms.Button();
            this.btnSearchProjects = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnUpdateFreelancer = new System.Windows.Forms.Button();
            this.btnDeleteFreelancer = new System.Windows.Forms.Button();
            this.btnTables = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFreelancersAndProjects
            // 
            this.btnFreelancersAndProjects.Location = new System.Drawing.Point(102, 29);
            this.btnFreelancersAndProjects.Name = "btnFreelancersAndProjects";
            this.btnFreelancersAndProjects.Size = new System.Drawing.Size(144, 23);
            this.btnFreelancersAndProjects.TabIndex = 0;
            this.btnFreelancersAndProjects.Text = "FreelancersAndProjects";
            this.btnFreelancersAndProjects.UseVisualStyleBackColor = true;
            this.btnFreelancersAndProjects.Click += new System.EventHandler(this.btnFreelancersAndProjects_Click);
            // 
            // btnProjects
            // 
            this.btnProjects.Location = new System.Drawing.Point(252, 29);
            this.btnProjects.Name = "btnProjects";
            this.btnProjects.Size = new System.Drawing.Size(75, 23);
            this.btnProjects.TabIndex = 1;
            this.btnProjects.Text = "Projects";
            this.btnProjects.UseVisualStyleBackColor = true;
            this.btnProjects.Click += new System.EventHandler(this.btnProjects_Click);
            // 
            // btnFreelancers
            // 
            this.btnFreelancers.Location = new System.Drawing.Point(12, 29);
            this.btnFreelancers.Name = "btnFreelancers";
            this.btnFreelancers.Size = new System.Drawing.Size(75, 23);
            this.btnFreelancers.TabIndex = 2;
            this.btnFreelancers.Text = "Freelancers";
            this.btnFreelancers.UseVisualStyleBackColor = true;
            this.btnFreelancers.Click += new System.EventHandler(this.btnFreelancers_Click);
            // 
            // listBoxResults
            // 
            this.listBoxResults.FormattingEnabled = true;
            this.listBoxResults.Location = new System.Drawing.Point(12, 206);
            this.listBoxResults.Name = "listBoxResults";
            this.listBoxResults.Size = new System.Drawing.Size(507, 173);
            this.listBoxResults.TabIndex = 3;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 65);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(99, 65);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(29, 13);
            this.lblError.TabIndex = 5;
            this.lblError.Text = "Error";
            // 
            // txtFreelancerName
            // 
            this.txtFreelancerName.Location = new System.Drawing.Point(12, 100);
            this.txtFreelancerName.Name = "txtFreelancerName";
            this.txtFreelancerName.Size = new System.Drawing.Size(100, 20);
            this.txtFreelancerName.TabIndex = 6;
            // 
            // btnGetSingleFreelancer
            // 
            this.btnGetSingleFreelancer.Location = new System.Drawing.Point(118, 97);
            this.btnGetSingleFreelancer.Name = "btnGetSingleFreelancer";
            this.btnGetSingleFreelancer.Size = new System.Drawing.Size(189, 23);
            this.btnGetSingleFreelancer.TabIndex = 7;
            this.btnGetSingleFreelancer.Text = "Look up freelancer by last name";
            this.btnGetSingleFreelancer.UseVisualStyleBackColor = true;
            this.btnGetSingleFreelancer.Click += new System.EventHandler(this.btnGetSingleFreelancer_Click);
            // 
            // btnSearchProjects
            // 
            this.btnSearchProjects.Location = new System.Drawing.Point(313, 97);
            this.btnSearchProjects.Name = "btnSearchProjects";
            this.btnSearchProjects.Size = new System.Drawing.Size(123, 23);
            this.btnSearchProjects.TabIndex = 9;
            this.btnSearchProjects.Text = "Look up projects";
            this.btnSearchProjects.UseVisualStyleBackColor = true;
            this.btnSearchProjects.Click += new System.EventHandler(this.btnSearchProjects_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 177);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(157, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Add new Freelancer";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnUpdateFreelancer
            // 
            this.btnUpdateFreelancer.Location = new System.Drawing.Point(184, 177);
            this.btnUpdateFreelancer.Name = "btnUpdateFreelancer";
            this.btnUpdateFreelancer.Size = new System.Drawing.Size(157, 23);
            this.btnUpdateFreelancer.TabIndex = 12;
            this.btnUpdateFreelancer.Text = "Update Freelancer";
            this.btnUpdateFreelancer.UseVisualStyleBackColor = true;
            this.btnUpdateFreelancer.Click += new System.EventHandler(this.btnUpdateFreelancer_Click);
            // 
            // btnDeleteFreelancer
            // 
            this.btnDeleteFreelancer.Location = new System.Drawing.Point(347, 177);
            this.btnDeleteFreelancer.Name = "btnDeleteFreelancer";
            this.btnDeleteFreelancer.Size = new System.Drawing.Size(157, 23);
            this.btnDeleteFreelancer.TabIndex = 13;
            this.btnDeleteFreelancer.Text = "Delete Freelancer";
            this.btnDeleteFreelancer.UseVisualStyleBackColor = true;
            this.btnDeleteFreelancer.Click += new System.EventHandler(this.btnDeleteFreelancer_Click);
            // 
            // btnTables
            // 
            this.btnTables.Location = new System.Drawing.Point(12, 385);
            this.btnTables.Name = "btnTables";
            this.btnTables.Size = new System.Drawing.Size(84, 29);
            this.btnTables.TabIndex = 14;
            this.btnTables.Text = "Data Editor";
            this.btnTables.UseVisualStyleBackColor = true;
            this.btnTables.Click += new System.EventHandler(this.btnTables_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 442);
            this.Controls.Add(this.btnTables);
            this.Controls.Add(this.btnDeleteFreelancer);
            this.Controls.Add(this.btnUpdateFreelancer);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSearchProjects);
            this.Controls.Add(this.btnGetSingleFreelancer);
            this.Controls.Add(this.txtFreelancerName);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.listBoxResults);
            this.Controls.Add(this.btnFreelancers);
            this.Controls.Add(this.btnProjects);
            this.Controls.Add(this.btnFreelancersAndProjects);
            this.Name = "Dashboard";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFreelancersAndProjects;
        private System.Windows.Forms.Button btnProjects;
        private System.Windows.Forms.Button btnFreelancers;
        private System.Windows.Forms.ListBox listBoxResults;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.TextBox txtFreelancerName;
        private System.Windows.Forms.Button btnGetSingleFreelancer;
        private System.Windows.Forms.Button btnSearchProjects;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnUpdateFreelancer;
        private System.Windows.Forms.Button btnDeleteFreelancer;
        private System.Windows.Forms.Button btnTables;
    }
}

