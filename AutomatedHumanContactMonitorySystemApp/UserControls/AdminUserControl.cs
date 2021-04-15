using AutomatedHumanContactMonitorySystemApp.IRepositories;
using AutomatedHumanContactMonitorySystemApp.Models.ContextModels;
using AutomatedHumanContactMonitorySystemApp.Models.Dtos;
using AutomatedHumanContactMonitorySystemApp.Models.Dtos.AttendanceDtos;
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
    public partial class AdminUserControl : UserControl
    {
        private IAttendanceRepository AttendanceRepository { get; set; }
        private IAttendeeRepository AttendeeRepository { get; set; }
        private Attendance SelectedAttendance = new Attendance();
        public AdminUserControl()
        {
            InitializeComponent();
        }

        private void AdminUserControl_Load(object sender, EventArgs e)
        {

        }

        public void LoadRepositories(IAttendanceRepository attendanceRepository, IAttendeeRepository attendeeRepository)
        {
            AttendanceRepository = attendanceRepository;
            AttendeeRepository = attendeeRepository;
        }

        public void LoadAttendanceList()
        {
            dgvAttendances.Rows.Clear();

            var searchDto = new SearchDto()
            {
                SearchBy = comboSearchBy.Text,
                SearchText = txtSearchText.Text
            };

            var attendances = AttendanceRepository.GetAttendanceBySearchParameter(searchDto);
            

            foreach (var attendance in attendances)
            {
                dgvAttendances.Rows.Add(attendance.Name,
                                       attendance.VisitedDateTime,
                                       attendance.Temperature,
                                       attendance.Location,
                                       attendance.AttendeeRFID,
                                       attendance.Status,
                                       attendance.Id,
                                       attendance.AttendeeId);
            }
        }

        private void UpdateAttendanceById()
        {
            SelectedAttendance.Status = comboStatus.Text;
            
            if (SelectedAttendance.Id > 0)
            {
                AttendanceRepository.UpdateAttendanceStatus(SelectedAttendance);
                AttendeeRepository.UpdateAttendeeStatus(new Attendee { Id = SelectedAttendance.AttendeeId, Status = SelectedAttendance.Status });
            }

            if (SelectedAttendance.Status == "POSITIVE")
            {
                UpdateMultipleAttendances();
            }

            SelectedAttendance = new Attendance();
        }

        private void UpdateMultipleAttendances()
        {
            var attendances = AttendanceRepository.GetAttendances().Where(a => a.VisitedDateTime.Year <= SelectedAttendance.VisitedDateTime.Year &&
                                                                                  a.VisitedDateTime.Month <= SelectedAttendance.VisitedDateTime.Month &&
                                                                                  a.VisitedDateTime.Day <= SelectedAttendance.VisitedDateTime.Day &&
                                                                                  a.VisitedDateTime.Date >= SelectedAttendance.VisitedDateTime.Date.AddDays(-14));

            foreach (var attendance in attendances)
            {
                if (attendance.Id != SelectedAttendance.Id && attendance.Status != "POSITIVE")
                    AttendanceRepository.UpdateAttendanceStatus(new Attendance { Id = attendance.Id, Status = "PUI" });
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadAttendanceList();
        }

        private void dgvAttendances_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedAttendance.Id = int.Parse(dgvAttendances.CurrentRow.Cells[6].Value.ToString());
            SelectedAttendance.Status = dgvAttendances.CurrentRow.Cells[5].Value.ToString();
            SelectedAttendance.VisitedDateTime = DateTime.Parse(dgvAttendances.CurrentRow.Cells[1].Value.ToString());
            SelectedAttendance.AttendeeId = int.Parse(dgvAttendances.CurrentRow.Cells[7].Value.ToString());

            comboStatus.Text = SelectedAttendance.Status;
            txtRfid.Text = dgvAttendances.CurrentRow.Cells[4].Value.ToString();
        }

        private void comboStatus_DrawItem(object sender, DrawItemEventArgs e)
        {
            // By using Sender, one method could handle multiple ComboBoxes
            ComboBox cbx = sender as ComboBox;
            if (cbx != null)
            {
                // Always draw the background
                e.DrawBackground();

                // Drawing one of the items?
                if (e.Index >= 0)
                {
                    // Set the string alignment.  Choices are Center, Near and Far
                    StringFormat sf = new StringFormat();
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Alignment = StringAlignment.Center;

                    // Set the Brush to ComboBox ForeColor to maintain any ComboBox color settings
                    // Assumes Brush is solid
                    Brush brush = new SolidBrush(cbx.ForeColor);

                    // If drawing highlighted selection, change brush
                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                        brush = SystemBrushes.HighlightText;

                    // Draw the string
                    e.Graphics.DrawString(cbx.Items[e.Index].ToString(), cbx.Font, brush, e.Bounds, sf);
                }
            }
        }

        private void btnSetStatus_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            UpdateAttendanceById();
            LoadAttendanceList();

            this.Cursor = Cursors.Default;
        }
    }
}
