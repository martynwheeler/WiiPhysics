namespace WiiPhysics
{
    partial class frmTiming
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
            this.components = new System.ComponentModel.Container();
            this.tbEndTime = new System.Windows.Forms.TextBox();
            this.lbEndTime = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.cbContinuous = new System.Windows.Forms.CheckBox();
            this.lbInformation = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // tbEndTime
            // 
            this.tbEndTime.Location = new System.Drawing.Point(113, 96);
            this.tbEndTime.Name = "tbEndTime";
            this.tbEndTime.Size = new System.Drawing.Size(37, 20);
            this.tbEndTime.TabIndex = 3;
            this.tbEndTime.Text = "30";
            this.tbEndTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.tbEndTime, "Choose a time interval over which to take data");
            // 
            // lbEndTime
            // 
            this.lbEndTime.AutoSize = true;
            this.lbEndTime.Location = new System.Drawing.Point(27, 99);
            this.lbEndTime.Name = "lbEndTime";
            this.lbEndTime.Size = new System.Drawing.Size(80, 13);
            this.lbEndTime.TabIndex = 5;
            this.lbEndTime.Text = "Sample time / s";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCancel.Location = new System.Drawing.Point(205, 242);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnOK.Location = new System.Drawing.Point(205, 214);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cbContinuous
            // 
            this.cbContinuous.AutoSize = true;
            this.cbContinuous.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbContinuous.Location = new System.Drawing.Point(25, 65);
            this.cbContinuous.Name = "cbContinuous";
            this.cbContinuous.Size = new System.Drawing.Size(125, 17);
            this.cbContinuous.TabIndex = 2;
            this.cbContinuous.Text = "Continuous Sampling";
            this.toolTip1.SetToolTip(this.cbContinuous, "Check for continuous sampling of data");
            this.cbContinuous.UseVisualStyleBackColor = true;
            this.cbContinuous.CheckedChanged += new System.EventHandler(this.cbContinuous_CheckedChanged);
            // 
            // lbInformation
            // 
            this.lbInformation.AutoSize = true;
            this.lbInformation.Location = new System.Drawing.Point(28, 25);
            this.lbInformation.Name = "lbInformation";
            this.lbInformation.Size = new System.Drawing.Size(59, 13);
            this.lbInformation.TabIndex = 6;
            this.lbInformation.Text = "Information";
            // 
            // frmTiming
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.lbInformation);
            this.Controls.Add(this.cbContinuous);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbEndTime);
            this.Controls.Add(this.tbEndTime);
            this.Name = "frmTiming";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Timing Parameters";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTiming_FormClosing);
            this.Load += new System.EventHandler(this.frmTiming_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox cbContinuous;
        private System.Windows.Forms.Label lbEndTime;
        private System.Windows.Forms.Label lbInformation;
        private System.Windows.Forms.TextBox tbEndTime;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}