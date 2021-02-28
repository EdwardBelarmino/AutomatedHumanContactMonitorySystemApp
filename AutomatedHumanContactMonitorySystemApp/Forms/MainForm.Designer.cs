
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
            this.btnPerson = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemAttendance = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAttendanceAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAttendee = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPlace = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPerson
            // 
            this.btnPerson.Location = new System.Drawing.Point(24, 52);
            this.btnPerson.Name = "btnPerson";
            this.btnPerson.Size = new System.Drawing.Size(96, 39);
            this.btnPerson.TabIndex = 0;
            this.btnPerson.Text = "Person";
            this.btnPerson.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(24, 97);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(96, 41);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(24, 144);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(96, 41);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(24, 191);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(96, 41);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // menuStrip1
            // 
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
            this.toolStripMenuItemAttendee.Name = "toolStripMenuItemAttendee";
            this.toolStripMenuItemAttendee.Size = new System.Drawing.Size(67, 20);
            this.toolStripMenuItemAttendee.Text = "Attendee";
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
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnPerson);
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

        private System.Windows.Forms.Button btnPerson;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAttendance;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAttendanceAdd;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAttendee;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPlace;
    }
}

