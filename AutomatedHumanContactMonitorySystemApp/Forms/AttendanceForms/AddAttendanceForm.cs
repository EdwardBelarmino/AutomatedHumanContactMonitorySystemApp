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
    public partial class AddAttendanceForm : Form
    {
        public MainForm MainForm { get; set; }
        public IAttendanceRepository AttendanceRepository { get; private set; }
        public AddAttendanceForm(IAttendanceRepository attendanceRepository)
        {
            InitializeComponent();
            AttendanceRepository = attendanceRepository;
        }

        private void AddAttendanceForm_Load(object sender, EventArgs e)
        {

        }
    }
}
