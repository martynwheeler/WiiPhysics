namespace WiiPhysics
{
    partial class frmSetup
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.gbScanMode = new System.Windows.Forms.GroupBox();
            this.rbCircularMotion = new System.Windows.Forms.RadioButton();
            this.rbBalanceBoard = new System.Windows.Forms.RadioButton();
            this.rbOneDMotion = new System.Windows.Forms.RadioButton();
            this.rbPositionSensor = new System.Windows.Forms.RadioButton();
            this.rbMotionSensor = new System.Windows.Forms.RadioButton();
            this.rbAccelerometer = new System.Windows.Forms.RadioButton();
            this.tbBarLength = new System.Windows.Forms.TextBox();
            this.lbBarLength = new System.Windows.Forms.Label();
            this.gbDisplay = new System.Windows.Forms.GroupBox();
            this.cbDisplay1 = new System.Windows.Forms.CheckBox();
            this.cbDisplay2 = new System.Windows.Forms.CheckBox();
            this.cbDisplay3 = new System.Windows.Forms.CheckBox();
            this.cbDisplay4 = new System.Windows.Forms.CheckBox();
            this.cbDisplay5 = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gbScanMode.SuspendLayout();
            this.gbDisplay.SuspendLayout();
            this.SuspendLayout();
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
            // gbScanMode
            // 
            this.gbScanMode.Controls.Add(this.rbCircularMotion);
            this.gbScanMode.Controls.Add(this.rbBalanceBoard);
            this.gbScanMode.Controls.Add(this.rbOneDMotion);
            this.gbScanMode.Controls.Add(this.rbPositionSensor);
            this.gbScanMode.Controls.Add(this.rbMotionSensor);
            this.gbScanMode.Controls.Add(this.rbAccelerometer);
            this.gbScanMode.Location = new System.Drawing.Point(8, 8);
            this.gbScanMode.Name = "gbScanMode";
            this.gbScanMode.Size = new System.Drawing.Size(147, 193);
            this.gbScanMode.TabIndex = 3;
            this.gbScanMode.TabStop = false;
            this.gbScanMode.Text = "Scan Mode";
            this.toolTip1.SetToolTip(this.gbScanMode, "Select the type of experiment to perform");
            // 
            // rbCircularMotion
            // 
            this.rbCircularMotion.AutoSize = true;
            this.rbCircularMotion.Location = new System.Drawing.Point(7, 139);
            this.rbCircularMotion.Name = "rbCircularMotion";
            this.rbCircularMotion.Size = new System.Drawing.Size(95, 17);
            this.rbCircularMotion.TabIndex = 6;
            this.rbCircularMotion.Text = "Circular Motion";
            this.rbCircularMotion.UseVisualStyleBackColor = true;
            // 
            // rbBalanceBoard
            // 
            this.rbBalanceBoard.AutoSize = true;
            this.rbBalanceBoard.Location = new System.Drawing.Point(7, 169);
            this.rbBalanceBoard.Name = "rbBalanceBoard";
            this.rbBalanceBoard.Size = new System.Drawing.Size(95, 17);
            this.rbBalanceBoard.TabIndex = 5;
            this.rbBalanceBoard.Text = "Balance Board";
            this.rbBalanceBoard.UseVisualStyleBackColor = true;
            // 
            // rbOneDMotion
            // 
            this.rbOneDMotion.AutoSize = true;
            this.rbOneDMotion.Location = new System.Drawing.Point(7, 109);
            this.rbOneDMotion.Name = "rbOneDMotion";
            this.rbOneDMotion.Size = new System.Drawing.Size(77, 17);
            this.rbOneDMotion.TabIndex = 3;
            this.rbOneDMotion.Text = "1-D Motion";
            this.rbOneDMotion.UseVisualStyleBackColor = true;
            this.rbOneDMotion.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbPositionSensor
            // 
            this.rbPositionSensor.AutoSize = true;
            this.rbPositionSensor.Location = new System.Drawing.Point(7, 79);
            this.rbPositionSensor.Name = "rbPositionSensor";
            this.rbPositionSensor.Size = new System.Drawing.Size(98, 17);
            this.rbPositionSensor.TabIndex = 2;
            this.rbPositionSensor.Text = "Position Sensor";
            this.rbPositionSensor.UseVisualStyleBackColor = true;
            this.rbPositionSensor.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbMotionSensor
            // 
            this.rbMotionSensor.AutoSize = true;
            this.rbMotionSensor.Location = new System.Drawing.Point(7, 49);
            this.rbMotionSensor.Name = "rbMotionSensor";
            this.rbMotionSensor.Size = new System.Drawing.Size(93, 17);
            this.rbMotionSensor.TabIndex = 1;
            this.rbMotionSensor.Text = "Motion Sensor";
            this.rbMotionSensor.UseVisualStyleBackColor = true;
            this.rbMotionSensor.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbAccelerometer
            // 
            this.rbAccelerometer.AutoSize = true;
            this.rbAccelerometer.Checked = true;
            this.rbAccelerometer.Location = new System.Drawing.Point(7, 19);
            this.rbAccelerometer.Name = "rbAccelerometer";
            this.rbAccelerometer.Size = new System.Drawing.Size(93, 17);
            this.rbAccelerometer.TabIndex = 0;
            this.rbAccelerometer.TabStop = true;
            this.rbAccelerometer.Text = "Accelerometer";
            this.rbAccelerometer.UseVisualStyleBackColor = true;
            this.rbAccelerometer.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // tbBarLength
            // 
            this.tbBarLength.Location = new System.Drawing.Point(8, 230);
            this.tbBarLength.Name = "tbBarLength";
            this.tbBarLength.Size = new System.Drawing.Size(61, 20);
            this.tbBarLength.TabIndex = 2;
            this.tbBarLength.Text = "0.20";
            this.toolTip1.SetToolTip(this.tbBarLength, "Enter the distance between the two IR sources");
            // 
            // lbBarLength
            // 
            this.lbBarLength.AutoSize = true;
            this.lbBarLength.Location = new System.Drawing.Point(5, 214);
            this.lbBarLength.Name = "lbBarLength";
            this.lbBarLength.Size = new System.Drawing.Size(114, 13);
            this.lbBarLength.TabIndex = 24;
            this.lbBarLength.Text = "Sensor Bar Length / m";
            // 
            // gbDisplay
            // 
            this.gbDisplay.Controls.Add(this.cbDisplay1);
            this.gbDisplay.Controls.Add(this.cbDisplay2);
            this.gbDisplay.Controls.Add(this.cbDisplay3);
            this.gbDisplay.Controls.Add(this.cbDisplay4);
            this.gbDisplay.Controls.Add(this.cbDisplay5);
            this.gbDisplay.Location = new System.Drawing.Point(157, 8);
            this.gbDisplay.Name = "gbDisplay";
            this.gbDisplay.Size = new System.Drawing.Size(123, 193);
            this.gbDisplay.TabIndex = 4;
            this.gbDisplay.TabStop = false;
            this.gbDisplay.Text = "Display";
            this.toolTip1.SetToolTip(this.gbDisplay, "Select which graphs to plot");
            // 
            // cbDisplay1
            // 
            this.cbDisplay1.AutoSize = true;
            this.cbDisplay1.Location = new System.Drawing.Point(9, 21);
            this.cbDisplay1.Name = "cbDisplay1";
            this.cbDisplay1.Size = new System.Drawing.Size(32, 17);
            this.cbDisplay1.TabIndex = 0;
            this.cbDisplay1.Text = "1";
            this.cbDisplay1.UseVisualStyleBackColor = true;
            // 
            // cbDisplay2
            // 
            this.cbDisplay2.AutoSize = true;
            this.cbDisplay2.Location = new System.Drawing.Point(9, 54);
            this.cbDisplay2.Name = "cbDisplay2";
            this.cbDisplay2.Size = new System.Drawing.Size(32, 17);
            this.cbDisplay2.TabIndex = 1;
            this.cbDisplay2.Text = "2";
            this.cbDisplay2.UseVisualStyleBackColor = true;
            // 
            // cbDisplay3
            // 
            this.cbDisplay3.AutoSize = true;
            this.cbDisplay3.Location = new System.Drawing.Point(9, 87);
            this.cbDisplay3.Name = "cbDisplay3";
            this.cbDisplay3.Size = new System.Drawing.Size(32, 17);
            this.cbDisplay3.TabIndex = 2;
            this.cbDisplay3.Text = "3";
            this.cbDisplay3.UseVisualStyleBackColor = true;
            // 
            // cbDisplay4
            // 
            this.cbDisplay4.AutoSize = true;
            this.cbDisplay4.Location = new System.Drawing.Point(9, 120);
            this.cbDisplay4.Name = "cbDisplay4";
            this.cbDisplay4.Size = new System.Drawing.Size(32, 17);
            this.cbDisplay4.TabIndex = 3;
            this.cbDisplay4.Text = "4";
            this.cbDisplay4.UseVisualStyleBackColor = true;
            // 
            // cbDisplay5
            // 
            this.cbDisplay5.AutoSize = true;
            this.cbDisplay5.Location = new System.Drawing.Point(9, 153);
            this.cbDisplay5.Name = "cbDisplay5";
            this.cbDisplay5.Size = new System.Drawing.Size(32, 17);
            this.cbDisplay5.TabIndex = 4;
            this.cbDisplay5.Text = "5";
            this.cbDisplay5.UseVisualStyleBackColor = true;
            // 
            // frmSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.gbDisplay);
            this.Controls.Add(this.lbBarLength);
            this.Controls.Add(this.tbBarLength);
            this.Controls.Add(this.gbScanMode);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "frmSetup";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Scan Parameters";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSetup_FormClosing);
            this.Load += new System.EventHandler(this.frmSetup_Load);
            this.gbScanMode.ResumeLayout(false);
            this.gbScanMode.PerformLayout();
            this.gbDisplay.ResumeLayout(false);
            this.gbDisplay.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox cbDisplay2;
        private System.Windows.Forms.CheckBox cbDisplay3;
        private System.Windows.Forms.CheckBox cbDisplay4;
        private System.Windows.Forms.CheckBox cbDisplay5;
        private System.Windows.Forms.GroupBox gbDisplay;
        private System.Windows.Forms.GroupBox gbScanMode;
        private System.Windows.Forms.Label lbBarLength;
        private System.Windows.Forms.RadioButton rbAccelerometer;
        private System.Windows.Forms.RadioButton rbBalanceBoard;
        private System.Windows.Forms.RadioButton rbMotionSensor;
        private System.Windows.Forms.RadioButton rbPositionSensor;
        private System.Windows.Forms.RadioButton rbOneDMotion;
        private System.Windows.Forms.TextBox tbBarLength;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.RadioButton rbCircularMotion;
        private System.Windows.Forms.CheckBox cbDisplay1;
    }
}