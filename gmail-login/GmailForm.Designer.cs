namespace sun_bm
{
    partial class GmailForm
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
            this.btnImportEmail = new System.Windows.Forms.Button();
            this.btnOpenEmail = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.lblNumberEmail = new System.Windows.Forms.Label();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailRecover = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImportEmail
            // 
            this.btnImportEmail.Location = new System.Drawing.Point(91, 12);
            this.btnImportEmail.Name = "btnImportEmail";
            this.btnImportEmail.Size = new System.Drawing.Size(52, 23);
            this.btnImportEmail.TabIndex = 2;
            this.btnImportEmail.Text = "Import";
            this.btnImportEmail.UseVisualStyleBackColor = true;
            this.btnImportEmail.Click += new System.EventHandler(this.btnImportEmail_Click);
            // 
            // btnOpenEmail
            // 
            this.btnOpenEmail.Location = new System.Drawing.Point(23, 12);
            this.btnOpenEmail.Name = "btnOpenEmail";
            this.btnOpenEmail.Size = new System.Drawing.Size(51, 23);
            this.btnOpenEmail.TabIndex = 1;
            this.btnOpenEmail.Text = "Email";
            this.btnOpenEmail.UseVisualStyleBackColor = true;
            this.btnOpenEmail.Click += new System.EventHandler(this.btnOpenEmail_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(23, 311);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Run";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.Email,
            this.Pass,
            this.EmailRecover,
            this.Status});
            this.dataGridView.Location = new System.Drawing.Point(23, 51);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(584, 254);
            this.dataGridView.TabIndex = 3;
            // 
            // lblNumberEmail
            // 
            this.lblNumberEmail.AutoSize = true;
            this.lblNumberEmail.Location = new System.Drawing.Point(166, 17);
            this.lblNumberEmail.Name = "lblNumberEmail";
            this.lblNumberEmail.Size = new System.Drawing.Size(13, 13);
            this.lblNumberEmail.TabIndex = 4;
            this.lblNumberEmail.Tag = "0";
            this.lblNumberEmail.Text = "0";
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.Width = 40;
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.Width = 150;
            // 
            // Pass
            // 
            this.Pass.HeaderText = "Pass";
            this.Pass.Name = "Pass";
            // 
            // EmailRecover
            // 
            this.EmailRecover.HeaderText = "EmailRecover";
            this.EmailRecover.Name = "EmailRecover";
            this.EmailRecover.Width = 150;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // GmailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 346);
            this.Controls.Add(this.lblNumberEmail);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnImportEmail);
            this.Controls.Add(this.btnOpenEmail);
            this.Name = "GmailForm";
            this.Text = "Gmail Regsiter";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnImportEmail;
        private System.Windows.Forms.Button btnOpenEmail;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label lblNumberEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pass;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmailRecover;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}