﻿namespace WeightTerminal
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
            this.btnState = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAbout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnState)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWeight
            // 
            this.lblWeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWeight.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWeight.Location = new System.Drawing.Point(0, 0);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(279, 129);
            this.lblWeight.TabIndex = 3;
            this.lblWeight.Text = "999999";
            this.lblWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.Location = new System.Drawing.Point(247, 97);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(32, 32);
            this.btnSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnSettings.TabIndex = 7;
            this.btnSettings.TabStop = false;
            this.toolTip.SetToolTip(this.btnSettings, "Настройки");
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            this.btnSettings.MouseEnter += new System.EventHandler(this.BtnSettings_MouseEnter);
            this.btnSettings.MouseLeave += new System.EventHandler(this.BtnSettings_MouseLeave);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "cog-outline-custom.png");
            this.imageList.Images.SetKeyName(1, "cog-custom.png");
            this.imageList.Images.SetKeyName(2, "link-circle-outline-custom.png");
            this.imageList.Images.SetKeyName(3, "link-circle-custom.png");
            this.imageList.Images.SetKeyName(4, "link-circle-outline-custom-red.png");
            this.imageList.Images.SetKeyName(5, "link-circle-custom-red.png");
            this.imageList.Images.SetKeyName(6, "information-outline-custom.png");
            this.imageList.Images.SetKeyName(7, "information-custom.png");
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.Location = new System.Drawing.Point(247, 0);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(32, 32);
            this.btnAbout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnAbout.TabIndex = 9;
            this.btnAbout.TabStop = false;
            this.toolTip.SetToolTip(this.btnAbout, "О программе");
            this.btnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            this.btnAbout.MouseEnter += new System.EventHandler(this.BtnAbout_MouseEnter);
            this.btnAbout.MouseLeave += new System.EventHandler(this.BtnAbout_MouseLeave);
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
            this.btnState.MouseEnter += new System.EventHandler(this.BtnState_MouseEnter);
            this.btnState.MouseLeave += new System.EventHandler(this.BtnState_MouseLeave);
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(279, 129);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnState);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.lblWeight);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Weight Terminal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Main_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.btnSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAbout)).EndInit();
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
    }
}

