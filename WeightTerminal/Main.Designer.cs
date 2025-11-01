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
            this.lblWeight = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.PictureBox();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnAbout = new System.Windows.Forms.PictureBox();
            this.btnUpdateApp = new System.Windows.Forms.PictureBox();
            this.btnChannels = new System.Windows.Forms.PictureBox();
            this.btnState = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblDiffRight = new System.Windows.Forms.Label();
            this.lblDiffNear = new System.Windows.Forms.Label();
            this.lblDiffLeft = new System.Windows.Forms.Label();
            this.lblDiffFar = new System.Windows.Forms.Label();
            this.lblChannelRightNear = new System.Windows.Forms.Label();
            this.lblChannelRightFar = new System.Windows.Forms.Label();
            this.lblChannelLeftNear = new System.Windows.Forms.Label();
            this.lblChannelLeftFar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAbout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdateApp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnChannels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnState)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWeight
            // 
            this.lblWeight.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWeight.Location = new System.Drawing.Point(120, 72);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.lblWeight.Size = new System.Drawing.Size(288, 88);
            this.lblWeight.TabIndex = 0;
            this.lblWeight.Text = "-999.999";
            this.lblWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.Location = new System.Drawing.Point(496, 200);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(32, 32);
            this.btnSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnSettings.TabIndex = 7;
            this.btnSettings.TabStop = false;
            this.toolTip.SetToolTip(this.btnSettings, "Настройки");
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "cog-outline");
            this.imageList.Images.SetKeyName(1, "cog");
            this.imageList.Images.SetKeyName(2, "link-circle-outline");
            this.imageList.Images.SetKeyName(3, "link-circle");
            this.imageList.Images.SetKeyName(4, "link-circle-outline-red");
            this.imageList.Images.SetKeyName(5, "link-circle-red");
            this.imageList.Images.SetKeyName(6, "information-outline");
            this.imageList.Images.SetKeyName(7, "information");
            this.imageList.Images.SetKeyName(8, "download-circle-outline");
            this.imageList.Images.SetKeyName(9, "download-circle");
            this.imageList.Images.SetKeyName(10, "fit-to-page-outline");
            this.imageList.Images.SetKeyName(11, "fit-to-page");
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.Location = new System.Drawing.Point(496, 0);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(32, 32);
            this.btnAbout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnAbout.TabIndex = 9;
            this.btnAbout.TabStop = false;
            this.toolTip.SetToolTip(this.btnAbout, "О программе");
            this.btnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            // 
            // btnUpdateApp
            // 
            this.btnUpdateApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdateApp.Location = new System.Drawing.Point(0, 200);
            this.btnUpdateApp.Name = "btnUpdateApp";
            this.btnUpdateApp.Size = new System.Drawing.Size(32, 32);
            this.btnUpdateApp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnUpdateApp.TabIndex = 10;
            this.btnUpdateApp.TabStop = false;
            this.toolTip.SetToolTip(this.btnUpdateApp, "Обновление");
            this.btnUpdateApp.Click += new System.EventHandler(this.BtnUpdateApp_Click);
            // 
            // btnChannels
            // 
            this.btnChannels.Location = new System.Drawing.Point(200, 0);
            this.btnChannels.Name = "btnChannels";
            this.btnChannels.Size = new System.Drawing.Size(32, 32);
            this.btnChannels.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnChannels.TabIndex = 19;
            this.btnChannels.TabStop = false;
            this.toolTip.SetToolTip(this.btnChannels, "Каналы");
            this.btnChannels.Click += new System.EventHandler(this.BtnChannels_Click);
            // 
            // btnState
            // 
            this.btnState.Location = new System.Drawing.Point(0, 0);
            this.btnState.Name = "btnState";
            this.btnState.Size = new System.Drawing.Size(32, 32);
            this.btnState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnState.TabIndex = 8;
            this.btnState.TabStop = false;
            this.btnState.Click += new System.EventHandler(this.BtnState_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Location = new System.Drawing.Point(40, 208);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(448, 23);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "status";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDiffRight
            // 
            this.lblDiffRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiffRight.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblDiffRight.Location = new System.Drawing.Point(384, 100);
            this.lblDiffRight.Margin = new System.Windows.Forms.Padding(18, 0, 18, 0);
            this.lblDiffRight.Name = "lblDiffRight";
            this.lblDiffRight.Size = new System.Drawing.Size(144, 32);
            this.lblDiffRight.TabIndex = 5;
            this.lblDiffRight.Text = "-999.999";
            this.lblDiffRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDiffNear
            // 
            this.lblDiffNear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiffNear.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblDiffNear.Location = new System.Drawing.Point(148, 165);
            this.lblDiffNear.Margin = new System.Windows.Forms.Padding(18, 0, 18, 0);
            this.lblDiffNear.Name = "lblDiffNear";
            this.lblDiffNear.Size = new System.Drawing.Size(232, 32);
            this.lblDiffNear.TabIndex = 7;
            this.lblDiffNear.Text = "-999.999";
            this.lblDiffNear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblDiffLeft
            // 
            this.lblDiffLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDiffLeft.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblDiffLeft.Location = new System.Drawing.Point(0, 100);
            this.lblDiffLeft.Margin = new System.Windows.Forms.Padding(18, 0, 18, 0);
            this.lblDiffLeft.Name = "lblDiffLeft";
            this.lblDiffLeft.Size = new System.Drawing.Size(144, 32);
            this.lblDiffLeft.TabIndex = 4;
            this.lblDiffLeft.Text = "-999.999";
            this.lblDiffLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDiffFar
            // 
            this.lblDiffFar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiffFar.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblDiffFar.Location = new System.Drawing.Point(148, 37);
            this.lblDiffFar.Margin = new System.Windows.Forms.Padding(18, 0, 18, 0);
            this.lblDiffFar.Name = "lblDiffFar";
            this.lblDiffFar.Size = new System.Drawing.Size(232, 32);
            this.lblDiffFar.TabIndex = 2;
            this.lblDiffFar.Text = "-999.999";
            this.lblDiffFar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblChannelRightNear
            // 
            this.lblChannelRightNear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChannelRightNear.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.lblChannelRightNear.Location = new System.Drawing.Point(384, 152);
            this.lblChannelRightNear.Margin = new System.Windows.Forms.Padding(18, 0, 18, 0);
            this.lblChannelRightNear.Name = "lblChannelRightNear";
            this.lblChannelRightNear.Size = new System.Drawing.Size(144, 48);
            this.lblChannelRightNear.TabIndex = 8;
            this.lblChannelRightNear.Text = "-999.999";
            this.lblChannelRightNear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblChannelRightFar
            // 
            this.lblChannelRightFar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChannelRightFar.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.lblChannelRightFar.Location = new System.Drawing.Point(384, 32);
            this.lblChannelRightFar.Margin = new System.Windows.Forms.Padding(18, 0, 18, 0);
            this.lblChannelRightFar.Name = "lblChannelRightFar";
            this.lblChannelRightFar.Size = new System.Drawing.Size(144, 48);
            this.lblChannelRightFar.TabIndex = 3;
            this.lblChannelRightFar.Text = "-999.999";
            this.lblChannelRightFar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblChannelLeftNear
            // 
            this.lblChannelLeftNear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblChannelLeftNear.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.lblChannelLeftNear.Location = new System.Drawing.Point(0, 152);
            this.lblChannelLeftNear.Margin = new System.Windows.Forms.Padding(18, 0, 18, 0);
            this.lblChannelLeftNear.Name = "lblChannelLeftNear";
            this.lblChannelLeftNear.Size = new System.Drawing.Size(144, 48);
            this.lblChannelLeftNear.TabIndex = 6;
            this.lblChannelLeftNear.Text = "-999.999";
            this.lblChannelLeftNear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblChannelLeftFar
            // 
            this.lblChannelLeftFar.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.lblChannelLeftFar.Location = new System.Drawing.Point(0, 32);
            this.lblChannelLeftFar.Margin = new System.Windows.Forms.Padding(18, 0, 18, 0);
            this.lblChannelLeftFar.Name = "lblChannelLeftFar";
            this.lblChannelLeftFar.Size = new System.Drawing.Size(144, 48);
            this.lblChannelLeftFar.TabIndex = 1;
            this.lblChannelLeftFar.Text = "-999.999";
            this.lblChannelLeftFar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(528, 232);
            this.Controls.Add(this.btnChannels);
            this.Controls.Add(this.lblDiffRight);
            this.Controls.Add(this.lblDiffNear);
            this.Controls.Add(this.lblDiffLeft);
            this.Controls.Add(this.lblDiffFar);
            this.Controls.Add(this.lblChannelRightNear);
            this.Controls.Add(this.lblChannelRightFar);
            this.Controls.Add(this.lblChannelLeftNear);
            this.Controls.Add(this.lblChannelLeftFar);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnUpdateApp);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnState);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.lblWeight);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Весовой терминал";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Main_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.btnSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAbout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdateApp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnChannels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnState)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.PictureBox btnSettings;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.PictureBox btnState;
        private System.Windows.Forms.PictureBox btnAbout;
        private System.Windows.Forms.PictureBox btnUpdateApp;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblDiffRight;
        private System.Windows.Forms.Label lblDiffNear;
        private System.Windows.Forms.Label lblDiffLeft;
        private System.Windows.Forms.Label lblDiffFar;
        private System.Windows.Forms.Label lblChannelRightNear;
        private System.Windows.Forms.Label lblChannelRightFar;
        private System.Windows.Forms.Label lblChannelLeftNear;
        private System.Windows.Forms.Label lblChannelLeftFar;
        private System.Windows.Forms.PictureBox btnChannels;
    }
}

