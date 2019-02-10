namespace WiiPhysics
{
    partial class frmUpdate
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnOKCancel = new System.Windows.Forms.Button();
            this.lbInformation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // btnOKCancel
            // 
            this.btnOKCancel.Location = new System.Drawing.Point(62, 41);
            this.btnOKCancel.Name = "btnOKCancel";
            this.btnOKCancel.Size = new System.Drawing.Size(75, 23);
            this.btnOKCancel.TabIndex = 0;
            this.btnOKCancel.Text = "OK";
            this.btnOKCancel.UseVisualStyleBackColor = true;
            this.btnOKCancel.Click += new System.EventHandler(this.btnOKCancel_Click);
            // 
            // lbInformation
            // 
            this.lbInformation.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbInformation.Location = new System.Drawing.Point(0, 0);
            this.lbInformation.Name = "lbInformation";
            this.lbInformation.Size = new System.Drawing.Size(199, 38);
            this.lbInformation.TabIndex = 1;
            this.lbInformation.Text = "lbInformation";
            this.lbInformation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(199, 81);
            this.Controls.Add(this.lbInformation);
            this.Controls.Add(this.btnOKCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Checking for Updates";
            this.Load += new System.EventHandler(this.frmUpdate_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnOKCancel;
        private System.Windows.Forms.Label lbInformation;
    }
}