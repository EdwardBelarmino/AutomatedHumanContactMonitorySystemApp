
namespace AutomatedHumanContactMonitorySystemApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemAttendance = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAttendanceAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAttendee = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuAddAttendee = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuEditAttendee = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuDeleteAttendee = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPlace = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAttendance,
            this.toolStripMenuItemAttendee,
            this.toolStripMenuItemPlace});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(775, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItemAttendance
            // 
            this.toolStripMenuItemAttendance.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAttendanceAdd});
            this.toolStripMenuItemAttendance.Name = "toolStripMenuItemAttendance";
            this.toolStripMenuItemAttendance.Size = new System.Drawing.Size(80, 20);
            this.toolStripMenuItemAttendance.Text = "Attendance";
            // 
            // toolStripMenuItemAttendanceAdd
            // 
            this.toolStripMenuItemAttendanceAdd.Name = "toolStripMenuItemAttendanceAdd";
            this.toolStripMenuItemAttendanceAdd.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItemAttendanceAdd.Text = "Add Attendance";
            // 
            // toolStripMenuItemAttendee
            // 
            this.toolStripMenuItemAttendee.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuAddAttendee,
            this.toolStripMenuEditAttendee,
            this.toolStripMenuDeleteAttendee});
            this.toolStripMenuItemAttendee.Name = "toolStripMenuItemAttendee";
            this.toolStripMenuItemAttendee.Size = new System.Drawing.Size(67, 20);
            this.toolStripMenuItemAttendee.Text = "Attendee";
            // 
            // toolStripMenuAddAttendee
            // 
            this.toolStripMenuAddAttendee.Name = "toolStripMenuAddAttendee";
            this.toolStripMenuAddAttendee.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuAddAttendee.Text = "Add Attendee";
            this.toolStripMenuAddAttendee.Click += new System.EventHandler(this.toolStripMenuAddAttendee_Click);
            // 
            // toolStripMenuEditAttendee
            // 
            this.toolStripMenuEditAttendee.Name = "toolStripMenuEditAttendee";
            this.toolStripMenuEditAttendee.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuEditAttendee.Text = "Edit Attendee";
            this.toolStripMenuEditAttendee.Click += new System.EventHandler(this.toolStripMenuEditAttendee_Click);
            // 
            // toolStripMenuDeleteAttendee
            // 
            this.toolStripMenuDeleteAttendee.Name = "toolStripMenuDeleteAttendee";
            this.toolStripMenuDeleteAttendee.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuDeleteAttendee.Text = "Delete Attendee";
            this.toolStripMenuDeleteAttendee.Click += new System.EventHandler(this.toolStripMenuDeleteAttendee_Click);
            // 
            // toolStripMenuItemPlace
            // 
            this.toolStripMenuItemPlace.Name = "toolStripMenuItemPlace";
            this.toolStripMenuItemPlace.Size = new System.Drawing.Size(47, 20);
            this.toolStripMenuItemPlace.Text = "Place";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAttendance;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAttendanceAdd;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAttendee;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPlace;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuAddAttendee;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuEditAttendee;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuDeleteAttendee;
    }
}

