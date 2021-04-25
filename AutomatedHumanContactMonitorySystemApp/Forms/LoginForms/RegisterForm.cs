using AutomatedHumanContactMonitorySystemApp.IRepositories;
using AutomatedHumanContactMonitorySystemApp.Models.ContextModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutomatedHumanContactMonitorySystemApp.Forms.LoginForms
{
    public partial class RegisterForm : Form
    {
        public IPlaceRepository PlaceRepository { get; set; }
        public IAppUserRepository AppUserRepository { get; set; }
        public RegisterForm(IPlaceRepository placeRepository, IAppUserRepository appUserRepository)
        {
            InitializeComponent();

            PlaceRepository = placeRepository;
            AppUserRepository = appUserRepository;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUsername.Text) && 
                !string.IsNullOrWhiteSpace(txtPassword.Text) &&
                !string.IsNullOrWhiteSpace(txtConfirmPassword.Text) &&
                !string.IsNullOrWhiteSpace(cmbSelectLocation.Text))
            {
                 if (txtPassword.Text == txtConfirmPassword.Text)
                {
                    var newAppUser = new AppUser()
                    {
                        Username = txtUsername.Text,
                        Password = txtPassword.Text,
                        PlaceId = int.Parse(cmbSelectLocation.SelectedItem.ToString()),
                        IsAdmin = radAdmin.Checked
                    };

                    var register = AppUserRepository.Register(newAppUser);

                    MessageBox.Show(register);
                }
                else
                {
                    MessageBox.Show("Password does not match.");
                }
            }
            else
            {
                MessageBox.Show("Please input all details!");
            }
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            var places = PlaceRepository.GetPlaces();
            
            foreach (var place in places)
            {
                cmbSelectLocation.Items.Add(place.Id);
            }

            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
