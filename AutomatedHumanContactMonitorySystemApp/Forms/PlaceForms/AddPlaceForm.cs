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
            LGV();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddPlace();
            LGV();
        }
        #region Helpers
        private List<Place> GetPlaces()
        {
            var places = PlaceRepository.GetPlaces();
            return places.ToList();
        }
        private void LGV()
        {
            dataGridView1.DataSource = GetPlaces();
        }

        private void AddPlace()
        {
            var placeToAdd = new Place()
            {
                Location = txtLocation.Text
            };

            PlaceRepository.PostPlace(placeToAdd);
        }

        #endregion Helpers




    }
}
