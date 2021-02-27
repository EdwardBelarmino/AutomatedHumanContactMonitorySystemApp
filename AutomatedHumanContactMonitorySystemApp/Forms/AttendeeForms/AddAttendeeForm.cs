using AutomatedHumanContactMonitorySystemApp.IRepositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutomatedHumanContactMonitorySystemApp.Forms.AttendeeForms
{
    public partial class AddAttendeeForm : Form
    {

        private IAttendeeRepository AttendeeRepository;

        public AddAttendeeForm(IAttendeeRepository attendeeRepository)
        {
            InitializeComponent();
            AttendeeRepository = attendeeRepository;
        }

        private void AddAttendeeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
