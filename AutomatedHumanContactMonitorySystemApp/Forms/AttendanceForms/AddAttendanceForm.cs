using AutomatedHumanContactMonitorySystemApp.IRepositories;
using AutomatedHumanContactMonitorySystemApp.Models.ContextModels;
using AutomatedHumanContactMonitorySystemApp.Models.Dtos.AttendanceDtos;
using AutomatedHumanContactMonitorySystemApp.Repositories;
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
        public IAttendeeRepository AttendeeRepository { get; private set; }
        public IPlaceRepository PlaceRepository { get; private set; }
        public AddAttendanceForm(IAttendanceRepository attendanceRepository, IAttendeeRepository attendeeRepository, IPlaceRepository placeRepository)
        {
            InitializeComponent();
            AttendanceRepository = attendanceRepository;
            AttendeeRepository = attendeeRepository;
            PlaceRepository = placeRepository;
        }

        private void AddAttendanceForm_Load(object sender, EventArgs e)
        {
            LoadGridViewAttendances();
            LoadGridViewAttendees();
            LoadGridViewPlaces();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddAttendance();
            LoadGridViewAttendances();

        }

        #region Cell-Clicks
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
            txtAttendeeId.Text = row.Cells[0].Value.ToString();
            txtName.Text = row.Cells[1].Value.ToString();
            txtAge.Text = row.Cells[2].Value.ToString();
            txtAddress.Text = row.Cells[3].Value.ToString();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView3.Rows[e.RowIndex];
            txtPlaceId.Text = row.Cells[0].Value.ToString();
            txtLocation.Text = row.Cells[1].Value.ToString();
        }
        #endregion
        #region Helpers Attendance

        private void LoadGridViewAttendances()
        {
            dataGridView1.DataSource = GetAttendances();
        }

        private List<AttendanceDto> GetAttendances()
        {
            var attendances = AttendanceRepository.GetAttendances();
            return attendances.ToList();
        }

        private void AddAttendance()
        {
            var attendanceToAdd = new AttendanceDto()
            {
                AttendeeId = int.Parse(txtAttendeeId.Text),
                VisitedDateTime = DateTime.Now,
                Temperature = double.Parse(txtTemperature.Text),
                PlaceId = int.Parse(txtPlaceId.Text)
            };

            AttendanceRepository.PostAttendance(attendanceToAdd);
        }

        #endregion Helpers
        #region Helpers Attendee

        private List<Attendee> GetAttendees()
        {
            var attendees = AttendeeRepository.GetAttendees();
            return attendees.ToList();
        }
        private void LoadGridViewAttendees()
        {
            dataGridView2.DataSource = GetAttendees();
        }
        #endregion
        #region Helpers Place

        private List<Place> GetPlaces()
        {
            var places = PlaceRepository.GetPlaces();
            return places.ToList();
        }
        private void LoadGridViewPlaces()
        {
            dataGridView3.DataSource = GetPlaces();
        }

        #endregion

    
    }
}
