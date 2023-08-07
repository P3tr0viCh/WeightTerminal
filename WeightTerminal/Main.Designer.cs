namespace WeightTerminal
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.cboxPorts = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.lblWeight = new System.Windows.Forms.Label();
            this.gbTerminalType = new System.Windows.Forms.GroupBox();
            this.rbtnNewton42 = new System.Windows.Forms.RadioButton();
            this.rbtnMidlVda12 = new System.Windows.Forms.RadioButton();
            this.rbtnMicrosimM0601 = new System.Windows.Forms.RadioButton();
            this.gbTerminalType.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboxPorts
            // 
            this.cboxPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxPorts.FormattingEnabled = true;
            this.cboxPorts.Location = new System.Drawing.Point(8, 8);
            this.cboxPorts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboxPorts.Name = "cboxPorts";
            this.cboxPorts.Size = new System.Drawing.Size(184, 25);
            this.cboxPorts.TabIndex = 0;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(8, 272);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(80, 32);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Open";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(384, 272);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 32);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Exit";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 17;
            this.listBox.Location = new System.Drawing.Point(200, 122);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(264, 140);
            this.listBox.TabIndex = 4;
            // 
            // lblWeight
            // 
            this.lblWeight.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWeight.Location = new System.Drawing.Point(200, 8);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(260, 96);
            this.lblWeight.TabIndex = 3;
            this.lblWeight.Text = "0.00";
            this.lblWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbTerminalType
            // 
            this.gbTerminalType.Controls.Add(this.rbtnMicrosimM0601);
            this.gbTerminalType.Controls.Add(this.rbtnNewton42);
            this.gbTerminalType.Controls.Add(this.rbtnMidlVda12);
            this.gbTerminalType.Location = new System.Drawing.Point(8, 40);
            this.gbTerminalType.Name = "gbTerminalType";
            this.gbTerminalType.Size = new System.Drawing.Size(184, 224);
            this.gbTerminalType.TabIndex = 1;
            this.gbTerminalType.TabStop = false;
            this.gbTerminalType.Text = "Прибор";
            // 
            // rbtnNewton42
            // 
            this.rbtnNewton42.AutoSize = true;
            this.rbtnNewton42.Checked = true;
            this.rbtnNewton42.Location = new System.Drawing.Point(16, 32);
            this.rbtnNewton42.Name = "rbtnNewton42";
            this.rbtnNewton42.Size = new System.Drawing.Size(99, 23);
            this.rbtnNewton42.TabIndex = 0;
            this.rbtnNewton42.TabStop = true;
            this.rbtnNewton42.Text = "Ньютон-42";
            this.rbtnNewton42.UseVisualStyleBackColor = true;
            // 
            // rbtnMidlVda12
            // 
            this.rbtnMidlVda12.AutoSize = true;
            this.rbtnMidlVda12.Location = new System.Drawing.Point(16, 64);
            this.rbtnMidlVda12.Name = "rbtnMidlVda12";
            this.rbtnMidlVda12.Size = new System.Drawing.Size(123, 23);
            this.rbtnMidlVda12.TabIndex = 1;
            this.rbtnMidlVda12.Text = "Мидл ВДА/12Я";
            this.rbtnMidlVda12.UseVisualStyleBackColor = true;
            // 
            // rbtnMicrosimM0601
            // 
            this.rbtnMicrosimM0601.AutoSize = true;
            this.rbtnMicrosimM0601.Location = new System.Drawing.Point(16, 96);
            this.rbtnMicrosimM0601.Name = "rbtnMicrosimM0601";
            this.rbtnMicrosimM0601.Size = new System.Drawing.Size(144, 23);
            this.rbtnMicrosimM0601.TabIndex = 2;
            this.rbtnMicrosimM0601.TabStop = true;
            this.rbtnMicrosimM0601.Text = "Микросим М0601";
            this.rbtnMicrosimM0601.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(472, 313);
            this.Controls.Add(this.gbTerminalType);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cboxPorts);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Weight Terminal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.gbTerminalType.ResumeLayout(false);
            this.gbTerminalType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.ComboBox cboxPorts;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.GroupBox gbTerminalType;
        private System.Windows.Forms.RadioButton rbtnNewton42;
        private System.Windows.Forms.RadioButton rbtnMidlVda12;
        private System.Windows.Forms.RadioButton rbtnMicrosimM0601;
    }
}

