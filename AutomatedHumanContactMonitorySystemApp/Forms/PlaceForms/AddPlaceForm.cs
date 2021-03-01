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
    public partial class AddPlaceForm : Form
    {
        public MainForm MainForm { get; set; }
        public IPlaceRepository PlaceRepository { get; private set; }
        public AddPlaceForm(IPlaceRepository placeRepository)
        {
            InitializeComponent();
            PlaceRepository = placeRepository;
        }

        private void AddPlaceForm_Load(object sender, EventArgs e)
        {

        }
    }
}
