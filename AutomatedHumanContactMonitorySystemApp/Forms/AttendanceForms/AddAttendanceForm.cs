using AutomatedHumanContactMonitorySystemApp.IRepositories;
using AutomatedHumanContactMonitorySystemApp.Models.ContextModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            LGV();
        }


        #region Helpers

        private void LGV()
        {
            dataGridView1.DataSource = GetAttendances();
        }

        private List<Attendance> GetAttendances()
        {
            var attendances = AttendanceRepository.GetAttendances();
            return attendances.ToList();

        }
        #endregion Helpers
    }
}
