using AutomatedHumanContactMonitorySystemApp.IRepositories;
using AutomatedHumanContactMonitorySystemApp.Models.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutomatedHumanContactMonitorySystemApp.UserControls
{
    public partial class DashboardUserControl : UserControl
    {
        private IAttendanceRepository AttendanceRepository { get; set; }
        public DashboardUserControl()
        {
            InitializeComponent();
        }

        private void DashboardUserControl_Load(object sender, EventArgs e)
        {

        }
        public void LoadRepositories(IAttendanceRepository attendanceRepository)
        {
            AttendanceRepository = attendanceRepository;
        }

        public void LoadAttendanceList(DateTime? date)
        {
            var searchDto = new SearchDto()
            {
                Date = date.Value.ToUniversalTime()
            };

            var attendances = AttendanceRepository.GetAttendanceByDate(searchDto);

            string puiCount = attendances.Where(a => a.Status == "PUI").Count().ToString();
            string positiveCount = attendances.Where(a => a.Status == "POSITIVE").Count().ToString();

            lblPuiCount.Text = puiCount;
            lblPositiveCount.Text = positiveCount;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadAttendanceList(dateTimePicker1.Value);
        }
    }
}
