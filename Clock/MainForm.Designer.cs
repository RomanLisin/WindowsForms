﻿namespace Clock
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.labelTime = new DoubleBufferedControl(); //System.Windows.Forms.Label();
			this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ToolStripMenuItemTopmost = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItemShowControls = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolStripMenuItemShowDate = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItemShowWeekDay = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolStripMenuItemChooseFont = new System.Windows.Forms.ToolStripMenuItem();
			this.digitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.moscowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.snowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItemColors = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemBackgroundColor = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemForegroundColor = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolStripMenuItemLoadOnWindowsStartup = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.cbShowDate = new System.Windows.Forms.CheckBox();
			this.checkBoxShowWeekDay = new System.Windows.Forms.CheckBox();
			this.buttonHideControls = new System.Windows.Forms.Button();
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelTime
			// 
			this.labelTime.AutoSize = true;
			this.labelTime.ContextMenuStrip = this.contextMenuStrip;
			this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelTime.Location = new System.Drawing.Point(13, 13);
			this.labelTime.Name = "labelTime";
			this.labelTime.Size = new System.Drawing.Size(122, 51);
			this.labelTime.TabIndex = 0;
			this.labelTime.Text = "Time";
			this.labelTime.UseWaitCursor = true;
			this.labelTime.DoubleClick += new System.EventHandler(this.labelTime_DoubleClick);
			// 
			// contextMenuStrip
			// 
			this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemTopmost,
            this.ToolStripMenuItemShowControls,
            this.toolStripSeparator1,
            this.ToolStripMenuItemShowDate,
            this.ToolStripMenuItemShowWeekDay,
            this.toolStripSeparator2,
            this.ToolStripMenuItemChooseFont,
            this.ToolStripMenuItemColors,
            this.toolStripSeparator3,
            this.ToolStripMenuItemLoadOnWindowsStartup,
            this.toolStripSeparator4,
            this.ToolStripMenuItemExit});
			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.Size = new System.Drawing.Size(210, 226);
			// 
			// ToolStripMenuItemTopmost
			// 
			this.ToolStripMenuItemTopmost.CheckOnClick = true;
			this.ToolStripMenuItemTopmost.Name = "ToolStripMenuItemTopmost";
			this.ToolStripMenuItemTopmost.Size = new System.Drawing.Size(209, 22);
			this.ToolStripMenuItemTopmost.Text = "Topmost";
			this.ToolStripMenuItemTopmost.Click += new System.EventHandler(this.ToolStripMenuItemTopmost_CheckedChanged);
			// 
			// ToolStripMenuItemShowControls
			// 
			this.ToolStripMenuItemShowControls.CheckOnClick = true;
			this.ToolStripMenuItemShowControls.Name = "ToolStripMenuItemShowControls";
			this.ToolStripMenuItemShowControls.Size = new System.Drawing.Size(209, 22);
			this.ToolStripMenuItemShowControls.Text = "Show controls";
			this.ToolStripMenuItemShowControls.CheckedChanged += new System.EventHandler(this.showControlsToolStripMenuItemShowControls_CheckedChanged);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(206, 6);
			// 
			// ToolStripMenuItemShowDate
			// 
			this.ToolStripMenuItemShowDate.CheckOnClick = true;
			this.ToolStripMenuItemShowDate.Name = "ToolStripMenuItemShowDate";
			this.ToolStripMenuItemShowDate.Size = new System.Drawing.Size(209, 22);
			this.ToolStripMenuItemShowDate.Text = "Show date";
			this.ToolStripMenuItemShowDate.CheckedChanged += new System.EventHandler(this.ToolStripMenuItemShowDate_CheckedChanged);
			// 
			// ToolStripMenuItemShowWeekDay
			// 
			this.ToolStripMenuItemShowWeekDay.CheckOnClick = true;
			this.ToolStripMenuItemShowWeekDay.Name = "ToolStripMenuItemShowWeekDay";
			this.ToolStripMenuItemShowWeekDay.Size = new System.Drawing.Size(209, 22);
			this.ToolStripMenuItemShowWeekDay.Text = "Show week day";
			this.ToolStripMenuItemShowWeekDay.CheckedChanged += new System.EventHandler(this.ToolStripMenuItemShowWeekDay_CheckedChanged);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(206, 6);
			// 
			// ToolStripMenuItemChooseFont
			// 
			this.ToolStripMenuItemChooseFont.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.digitToolStripMenuItem,
            this.moscowToolStripMenuItem,
            this.snowToolStripMenuItem});
			this.ToolStripMenuItemChooseFont.Name = "ToolStripMenuItemChooseFont";
			this.ToolStripMenuItemChooseFont.Size = new System.Drawing.Size(209, 22);
			this.ToolStripMenuItemChooseFont.Text = "Choose font";
			// 
			// digitToolStripMenuItem
			// 
			this.digitToolStripMenuItem.CheckOnClick = true;
			this.digitToolStripMenuItem.Name = "digitToolStripMenuItem";
			this.digitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.digitToolStripMenuItem.Text = "Light Led";
			this.digitToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
			// 
			// moscowToolStripMenuItem
			// 
			this.moscowToolStripMenuItem.CheckOnClick = true;
			this.moscowToolStripMenuItem.Name = "moscowToolStripMenuItem";
			this.moscowToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.moscowToolStripMenuItem.Text = "Moscow 2024";
			this.moscowToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
			// 
			// snowToolStripMenuItem
			// 
			this.snowToolStripMenuItem.CheckOnClick = true;
			this.snowToolStripMenuItem.Name = "snowToolStripMenuItem";
			this.snowToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.snowToolStripMenuItem.Text = "Terminator";
			this.snowToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
			// 
			// ToolStripMenuItemColors
			// 
			this.ToolStripMenuItemColors.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemBackgroundColor,
            this.toolStripMenuItemForegroundColor});
			this.ToolStripMenuItemColors.Name = "ToolStripMenuItemColors";
			this.ToolStripMenuItemColors.Size = new System.Drawing.Size(209, 22);
			this.ToolStripMenuItemColors.Text = "Colors";
			// 
			// toolStripMenuItemBackgroundColor
			// 
			this.toolStripMenuItemBackgroundColor.CheckOnClick = true;
			this.toolStripMenuItemBackgroundColor.Name = "toolStripMenuItemBackgroundColor";
			this.toolStripMenuItemBackgroundColor.Size = new System.Drawing.Size(180, 22);
			this.toolStripMenuItemBackgroundColor.Text = "Background color";
			this.toolStripMenuItemBackgroundColor.Click += new System.EventHandler(this.ToolStripMenuItemBackgroundColor_Click);
			// 
			// toolStripMenuItemForegroundColor
			// 
			this.toolStripMenuItemForegroundColor.CheckOnClick = true;
			this.toolStripMenuItemForegroundColor.Name = "toolStripMenuItemForegroundColor";
			this.toolStripMenuItemForegroundColor.Size = new System.Drawing.Size(180, 22);
			this.toolStripMenuItemForegroundColor.Text = "Foreground color";
			this.toolStripMenuItemForegroundColor.Click += new System.EventHandler(this.ToolStripMenuItemForegroundColor_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(206, 6);
			// 
			// ToolStripMenuItemLoadOnWindowsStartup
			// 
			this.ToolStripMenuItemLoadOnWindowsStartup.CheckOnClick = true;
			this.ToolStripMenuItemLoadOnWindowsStartup.Name = "ToolStripMenuItemLoadOnWindowsStartup";
			this.ToolStripMenuItemLoadOnWindowsStartup.Size = new System.Drawing.Size(209, 22);
			this.ToolStripMenuItemLoadOnWindowsStartup.Text = "Load on Windows startup";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(206, 6);
			// 
			// ToolStripMenuItemExit
			// 
			this.ToolStripMenuItemExit.Name = "ToolStripMenuItemExit";
			this.ToolStripMenuItemExit.Size = new System.Drawing.Size(209, 22);
			this.ToolStripMenuItemExit.Text = "Exit";
			this.ToolStripMenuItemExit.Click += new System.EventHandler(this.ToolStripMenuItemExit_Click);
			// 
			// timer
			// 
			this.timer.Enabled = true;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// cbShowDate
			// 
			this.cbShowDate.AutoSize = true;
			this.cbShowDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cbShowDate.Location = new System.Drawing.Point(22, 196);
			this.cbShowDate.Name = "cbShowDate";
			this.cbShowDate.Size = new System.Drawing.Size(132, 29);
			this.cbShowDate.TabIndex = 1;
			this.cbShowDate.Text = "Show date";
			this.cbShowDate.UseVisualStyleBackColor = true;
			// 
			// checkBoxShowWeekDay
			// 
			this.checkBoxShowWeekDay.AutoSize = true;
			this.checkBoxShowWeekDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.checkBoxShowWeekDay.Location = new System.Drawing.Point(22, 251);
			this.checkBoxShowWeekDay.Name = "checkBoxShowWeekDay";
			this.checkBoxShowWeekDay.Size = new System.Drawing.Size(181, 29);
			this.checkBoxShowWeekDay.TabIndex = 2;
			this.checkBoxShowWeekDay.Text = "Show week day";
			this.checkBoxShowWeekDay.UseVisualStyleBackColor = true;
			// 
			// buttonHideControls
			// 
			this.buttonHideControls.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonHideControls.Location = new System.Drawing.Point(79, 308);
			this.buttonHideControls.Name = "buttonHideControls";
			this.buttonHideControls.Size = new System.Drawing.Size(181, 55);
			this.buttonHideControls.TabIndex = 3;
			this.buttonHideControls.Text = "Hide controls";
			this.buttonHideControls.UseVisualStyleBackColor = true;
			this.buttonHideControls.Click += new System.EventHandler(this.buttonHideControls_Click);
			// 
			// notifyIcon
			// 
			this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
			this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
			this.notifyIcon.Text = "notifyIcon";
			this.notifyIcon.Visible = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(337, 392);
			this.Controls.Add(this.buttonHideControls);
			this.Controls.Add(this.checkBoxShowWeekDay);
			this.Controls.Add(this.cbShowDate);
			this.Controls.Add(this.labelTime);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Calc VPD_311";
			this.contextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelTime;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.CheckBox cbShowDate;
		private System.Windows.Forms.CheckBox checkBoxShowWeekDay;
		private System.Windows.Forms.Button buttonHideControls;
		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemTopmost;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemShowControls;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemShowDate;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemShowWeekDay;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemChooseFont;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemColors;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBackgroundColor;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemForegroundColor;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		public System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemLoadOnWindowsStartup;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemExit;
		private System.Windows.Forms.ToolStripMenuItem digitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem moscowToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem snowToolStripMenuItem;
	}
}

