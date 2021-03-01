using AutomatedHumanContactMonitorySystemApp.IRepositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutomatedHumanContactMonitorySystemApp.Forms.AttendanceForms
{
    public partial class UpdateAttendanceForm : Form
    {
        public MainForm MainForm { get; set; }
        public IAttendanceRepository AttendanceRepository { get; private set; }
        public UpdateAttendanceForm(IAttendanceRepository attendanceRepository)
        {
            InitializeComponent();
            AttendanceRepository = attendanceRepository;
        }

        private void UpdateAttendanceForm_Load(object sender, EventArgs e)
        {

        }
    }
}
