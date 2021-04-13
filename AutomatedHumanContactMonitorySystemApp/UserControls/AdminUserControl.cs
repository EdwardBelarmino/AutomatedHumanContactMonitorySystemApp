using AutomatedHumanContactMonitorySystemApp.IRepositories;
using AutomatedHumanContactMonitorySystemApp.Models.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutomatedHumanContactMonitorySystemApp.UserControls
{
    public partial class AdminUserControl : UserControl
    {
        private IAttendanceRepository AttendanceRepository { get; set; }
        public AdminUserControl()
        {
            InitializeComponent();
        }

        private void AdminUserControl_Load(object sender, EventArgs e)
        {

        }

        public void LoadRepositories(IAttendanceRepository attendanceRepository)
        {
            AttendanceRepository = attendanceRepository;
        }

        public void LoadAttendanceList()
        {
            dataGridView1.Rows.Clear();

            var searchDto = new SearchDto()
            {
                SearchBy = comboSearchBy.Text,
                SearchText = txtSearchText.Text
            };

            var attendances = AttendanceRepository.GetAttendanceBySearchParameter(searchDto);

            foreach (var attendance in attendances)
            {
                dataGridView1.Rows.Add(attendance.Name,
                                       attendance.VisitedDateTime,
                                       attendance.Temperature,
                                       attendance.Location,
                                       attendance.RFID,
                                       attendance.Status);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadAttendanceList();
        }
    }
}
