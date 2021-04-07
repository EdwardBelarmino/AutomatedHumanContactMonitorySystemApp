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
using Sharer;

namespace AutomatedHumanContactMonitorySystemApp.Forms.AttendanceForms
{
    public partial class AddAttendanceForm : Form
    {
        bool isTimerRunning = true;
        string rfidValue = string.Empty;
        string bodytempValue = string.Empty;
        string proximityValue = string.Empty;

        private SharerConnection connection = new SharerConnection("COM6", 9600);
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
            timer1.Start();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            LoadGridViewAttendances();
            double temperature = double.Parse(txtTemperature.Text);
            if (temperature > 38)
            {
                string message1 = "Fever";
                MessageBox.Show(message1);

            }
            else
            {
                AddAttendance();
            }

        }

        #region Cell-Clicks
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
            txtID.Text = row.Cells[0].Value.ToString();
            txtAttendeeRFID.Text = row.Cells[1].Value.ToString();
            txtName.Text = row.Cells[2].Value.ToString();
            txtAge.Text = row.Cells[3].Value.ToString();
            txtAddress.Text = row.Cells[4].Value.ToString();
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
                AttendeeId = int.Parse(txtID.Text),
                RFID = long.Parse(txtAttendeeRFID.Text),
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!connection.Connected)
            {
                connection.Connect();
                // Scan all functions shared
                connection.RefreshFunctions();
                connection.RefreshVariables();
            }

            if (isTimerRunning)
            {
                rfidValue = connection.Call("returnRfid").Value.ToString(); //ok
                txtAttendeeRFID.Text = rfidValue.ToString().PadLeft(10, '0'); //ok
            }

            if (txtAttendeeRFID.Text != "0000000000" && txtAttendeeRFID.Text != "") //ok
            {
                if (isTimerRunning)
                {
                    connection.WriteVariable("i", 2);
                }

                isTimerRunning = false; //ok

                proximityValue = connection.Call("returnProximity").Value.ToString();

                if (proximityValue == "0")
                {
                    bodytempValue = connection.Call("returnTemperature").Value.ToString(); //ok
                    txtTemperature.Text = bodytempValue;
                }
                else
                {
                    txtTemperature.Text = string.Empty;
                }

            }

            //try
            //{
            //    if (isTimerRunning)
            //    {

            //    }

            //    if (value.ToString() != "0" || value.ToString() != "")
            //    {
            //        isTimerRunning = false;



            //        var runFunctionChangeVariableIToNum = connection.WriteVariable("i", 2);

            //        connection.WriteVariable("rfid", 0);
            //    }

            //}
            //catch(Exception ex)
            //{

            //}


        }
    }
}
