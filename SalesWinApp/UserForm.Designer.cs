namespace SalesWinApp
{
    partial class UserForm
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
            this.ldUser = new System.Windows.Forms.Label();
            this.lEmailUser = new System.Windows.Forms.Label();
            this.lCompanyName = new System.Windows.Forms.Label();
            this.lCity = new System.Windows.Forms.Label();
            this.lCountry = new System.Windows.Forms.Label();
            this.lPass = new System.Windows.Forms.Label();
            this.txtEmailUser = new System.Windows.Forms.TextBox();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtidUser = new System.Windows.Forms.TextBox();
            this.dgvUserOrder = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // ldUser
            // 
            this.ldUser.AutoSize = true;
            this.ldUser.Location = new System.Drawing.Point(16, 19);
            this.ldUser.Name = "ldUser";
            this.ldUser.Size = new System.Drawing.Size(18, 15);
            this.ldUser.TabIndex = 0;
            this.ldUser.Text = "ID";
            // 
            // lEmailUser
            // 
            this.lEmailUser.AutoSize = true;
            this.lEmailUser.Location = new System.Drawing.Point(16, 57);
            this.lEmailUser.Name = "lEmailUser";
            this.lEmailUser.Size = new System.Drawing.Size(36, 15);
            this.lEmailUser.TabIndex = 1;
            this.lEmailUser.Text = "Email";
            // 
            // lCompanyName
            // 
            this.lCompanyName.AutoSize = true;
            this.lCompanyName.Location = new System.Drawing.Point(16, 96);
            this.lCompanyName.Name = "lCompanyName";
            this.lCompanyName.Size = new System.Drawing.Size(59, 15);
            this.lCompanyName.TabIndex = 2;
            this.lCompanyName.Text = "Company";
            // 
            // lCity
            // 
            this.lCity.AutoSize = true;
            this.lCity.Location = new System.Drawing.Point(16, 135);
            this.lCity.Name = "lCity";
            this.lCity.Size = new System.Drawing.Size(28, 15);
            this.lCity.TabIndex = 3;
            this.lCity.Text = "City";
            // 
            // lCountry
            // 
            this.lCountry.AutoSize = true;
            this.lCountry.Location = new System.Drawing.Point(16, 174);
            this.lCountry.Name = "lCountry";
            this.lCountry.Size = new System.Drawing.Size(50, 15);
            this.lCountry.TabIndex = 4;
            this.lCountry.Text = "Country";
            // 
            // lPass
            // 
            this.lPass.AutoSize = true;
            this.lPass.Location = new System.Drawing.Point(16, 211);
            this.lPass.Name = "lPass";
            this.lPass.Size = new System.Drawing.Size(57, 15);
            this.lPass.TabIndex = 5;
            this.lPass.Text = "Password";
            // 
            // txtEmailUser
            // 
            this.txtEmailUser.Location = new System.Drawing.Point(79, 49);
            this.txtEmailUser.Name = "txtEmailUser";
            this.txtEmailUser.Size = new System.Drawing.Size(100, 23);
            this.txtEmailUser.TabIndex = 6;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(79, 88);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(100, 23);
            this.txtCompanyName.TabIndex = 7;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(79, 127);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(100, 23);
            this.txtCity.TabIndex = 8;
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(79, 166);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(100, 23);
            this.txtCountry.TabIndex = 9;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(79, 203);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(100, 23);
            this.txtPass.TabIndex = 10;
            // 
            // txtidUser
            // 
            this.txtidUser.Location = new System.Drawing.Point(79, 11);
            this.txtidUser.Name = "txtidUser";
            this.txtidUser.Size = new System.Drawing.Size(100, 23);
            this.txtidUser.TabIndex = 11;
            // 
            // dgvUserOrder
            // 
            this.dgvUserOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserOrder.Location = new System.Drawing.Point(221, 12);
            this.dgvUserOrder.Name = "dgvUserOrder";
            this.dgvUserOrder.RowTemplate.Height = 25;
            this.dgvUserOrder.Size = new System.Drawing.Size(567, 426);
            this.dgvUserOrder.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(79, 335);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(16, 415);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 14;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvUserOrder);
            this.Controls.Add(this.txtidUser);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.txtEmailUser);
            this.Controls.Add(this.lPass);
            this.Controls.Add(this.lCountry);
            this.Controls.Add(this.lCity);
            this.Controls.Add(this.lCompanyName);
            this.Controls.Add(this.lEmailUser);
            this.Controls.Add(this.ldUser);
            this.Name = "UserForm";
            this.Text = "UserForm";
            this.Load += new System.EventHandler(this.UserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ldUser;
        private System.Windows.Forms.Label lEmailUser;
        private System.Windows.Forms.Label lCompanyName;
        private System.Windows.Forms.Label lCity;
        private System.Windows.Forms.Label lCountry;
        private System.Windows.Forms.Label lPass;
        private System.Windows.Forms.TextBox txtEmailUser;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtidUser;
        private System.Windows.Forms.DataGridView dgvUserOrder;
        private Button btnSave;
        private Button BtnCancel;
    }
}