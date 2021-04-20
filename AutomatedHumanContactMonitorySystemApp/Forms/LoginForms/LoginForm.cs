﻿using AutomatedHumanContactMonitorySystemApp.Helpers;
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
    public partial class LoginForm : Form
    {
        public IAppUserRepository AppUserRepository { get; set; }
        public LoginForm(IAppUserRepository appUserRepository)
        {
            AppUserRepository = appUserRepository;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var appUser = new AppUser()
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text
            };

            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Username/Password should not be blank");
            }
            else
            {
                try
                {
                    var appUserLogin = AppUserRepository.IsAuthorized(appUser);

                    if (appUserLogin != null)
                    {
                        PlaceHelper.AppUserName = appUserLogin.Username;
                        PlaceHelper.PlaceId = appUserLogin.PlaceId;
                        PlaceHelper.IsAdmin = appUserLogin.IsAdmin;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Incorrect Username/Password");
                }
            }

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
