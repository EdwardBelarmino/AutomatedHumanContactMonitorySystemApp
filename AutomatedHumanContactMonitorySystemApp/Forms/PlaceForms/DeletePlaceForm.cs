using AutomatedHumanContactMonitorySystemApp.IRepositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutomatedHumanContactMonitorySystemApp.Forms.PlaceForms
{
    public partial class DeletePlaceForm : Form
    {
        public MainForm MainForm { get; set; }
        public IPlaceRepository PlaceRepository { get; private set; }
        public DeletePlaceForm(IPlaceRepository placeRepository)
        {
            InitializeComponent();
            PlaceRepository = placeRepository;
        }

        private void DeletePlaceForm_Load(object sender, EventArgs e)
        {

        }
    }
}
