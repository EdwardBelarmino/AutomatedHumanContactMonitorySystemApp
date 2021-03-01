using AutomatedHumanContactMonitorySystemApp.Forms.AttendeeForms;
using AutomatedHumanContactMonitorySystemApp.IRepositories;
using AutomatedHumanContactMonitorySystemApp.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomatedHumanContactMonitorySystemApp
{
    public partial class MainForm : Form
    {

        public IAttendeeRepository AttendeeRepository { get; private set; }
        public MainForm(IAttendeeRepository attendeeRepository)
        {
            InitializeComponent();
            AttendeeRepository = attendeeRepository;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        
        private void toolStripMenuAddAttendee_Click(object sender, EventArgs e)
        {
            var addAttendeeForm = new AddAttendeeForm(AttendeeRepository);
            addAttendeeForm.Show();
        }

        private void toolStripMenuEditAttendee_Click(object sender, EventArgs e)
        {
            var updateAttendeeForm = new UpdateAttendeeForm(AttendeeRepository);
            updateAttendeeForm.Show();
        }

        private void toolStripMenuDeleteAttendee_Click(object sender, EventArgs e)
        {
            var deleteAttendeeForm = new DeleteAttendeeForm(AttendeeRepository);
            deleteAttendeeForm.Show();
        }
    }
}
