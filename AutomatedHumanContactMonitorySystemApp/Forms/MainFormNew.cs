using AutomatedHumanContactMonitorySystemApp.Extensions;
using AutomatedHumanContactMonitorySystemApp.Forms.LoginForms;
using AutomatedHumanContactMonitorySystemApp.IRepositories;
using AutomatedHumanContactMonitorySystemApp.Models.ContextModels;
using AutomatedHumanContactMonitorySystemApp.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AutomatedHumanContactMonitorySystemApp.Forms
{
    public partial class MainFormNew : Form
    {
        private bool isMenuSizeToggled = true;
        private bool isDashboardClicked;
        private bool isAdminClicked;
        private bool isContactTracingClicked;

        private static readonly int fullWidthMenu = 178;
        private static readonly int toggledWidthMenu = 45;

        private Place PlaceInfo { get; set; }
        public IAttendeeRepository AttendeeRepository { get; private set; }
        public IPlaceRepository PlaceRepository { get; private set; }
        public IAttendanceRepository AttendanceRepository { get; private set; }
        public IAppUserRepository AppUserRepository { get; private set; }

        public MainFormNew(IAttendeeRepository attendeeRepository, IPlaceRepository placeRepository, IAttendanceRepository attendanceRepository, IAppUserRepository appUserRepository)
        {
            InitializeComponent();

            AttendeeRepository = attendeeRepository;
            PlaceRepository = placeRepository;
            AttendanceRepository = attendanceRepository;
            AppUserRepository = appUserRepository;

            
            LoadLoginForm();
            CheckPermissions();

            ToggleMenuButtons(isDashboard: true);

        }

        private void btnToggleMenu_Click(object sender, EventArgs e)
        {
            ToggleMenuSize();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ToggleMenuButtons(isDashboard: true);
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            ToggleMenuButtons(isAdmin: true);
        }

        private void btnContactTracing_Click(object sender, EventArgs e)
        {
            ToggleMenuButtons(isContactTracing: true);
        }

        #region Helpers
        private void CheckPermissions()
        {
            btnAdmin.Visible = Helpers.PlaceHelper.IsAdmin;
        }
        private void ToggleMenuSize()
        {
            if (isMenuSizeToggled)
            {
                isMenuSizeToggled = false;
                panelMenu.Width = toggledWidthMenu;
            }
            else
            {
                isMenuSizeToggled = true;
                panelMenu.Width = fullWidthMenu;
            }

            btnAdmin.Visible =
                btnDashboard.Visible =
                    btnContactTracing.Visible = isMenuSizeToggled;

            CheckPermissions();
        }

        private void ToggleMenuButtons(bool isDashboard = false, bool isAdmin = false, bool isContactTracing = false)
        {
            isDashboardClicked = isDashboard;
            isAdminClicked = isAdmin;
            isContactTracingClicked = isContactTracing;

            ClearFlowLayoutPanel();
            SetActiveMenuButton();

            if (isDashboardClicked)
            {
                LoadDashboardUserControl();

                isAdminClicked =
                    isContactTracingClicked = !isDashboardClicked;
            }
            else if (isAdminClicked)
            {
                LoadAdminUserControl();

                isDashboardClicked =
                    isContactTracingClicked = !isAdminClicked;
            }
            else if (isContactTracingClicked)
            {
                LoadContactTracingForm();
                
                isDashboardClicked =
                    isAdminClicked = !isContactTracingClicked;
            }

        }

        private void SetActiveMenuButton()
        {
            if (isDashboardClicked)
            {
                btnDashboard.SetActiveButton();

                btnAdmin.UnsetActiveButton();
                btnContactTracing.UnsetActiveButton();
            }
            else if (isAdminClicked)
            {
                btnAdmin.SetActiveButton();

                btnDashboard.UnsetActiveButton();
                btnContactTracing.UnsetActiveButton();
            }
            else if (isContactTracingClicked)
            {
                btnContactTracing.SetActiveButton();

                btnDashboard.UnsetActiveButton();
                btnAdmin.UnsetActiveButton();
            }
        }


        private void LoadContactTracingForm()
        {
            var contactTracingForm = new ContactTracingForm();
            contactTracingForm.LoadRepositories(AttendanceRepository, AttendeeRepository, PlaceRepository);
            contactTracingForm.LoadUserControl();
            contactTracingForm.ShowDialog();
        }

        private void LoadAttendanceListUserControl()
        {
            var attendanceListUserControl = new AttendanceListUserControl();
            attendanceListUserControl.LoadRepositories(AttendanceRepository);
            attendanceListUserControl.LoadAttendanceList();

            flowLayoutPanel1.Controls.Add(attendanceListUserControl);
        }

        private void LoadAdminUserControl()
        {
            var adminUserControl = new AdminUserControl();
            adminUserControl.LoadRepositories(AttendanceRepository, AttendeeRepository);
            adminUserControl.LoadAttendanceList();

            flowLayoutPanel1.Controls.Add(adminUserControl);
        }

        private void LoadDashboardUserControl()
        {
            var dashboardUserControl = new DashboardUserControl();
            dashboardUserControl.LoadRepositories(AttendanceRepository);
            dashboardUserControl.LoadAttendanceList(DateTime.Now);

            flowLayoutPanel1.Controls.Add(dashboardUserControl);
        }
        public void ClearFlowLayoutPanel()
        {
            flowLayoutPanel1.Controls.Clear();
        }
        #endregion Helpers

        #region Login
        private void LoadLoginForm()
        {
            var loginForm = new LoginForm(AppUserRepository);

            loginForm.FormClosed += LoginForm_FormClosed;
            this.Hide();
            loginForm.ShowDialog();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Helpers.PlaceHelper.PlaceId > 0)
            {
                PlaceInfo = PlaceRepository.GetPlaces().Where(a => a.Id == Helpers.PlaceHelper.PlaceId).SingleOrDefault();
                lblLocationName.Text = PlaceInfo.Location;
                lblAppUserName.Text = Helpers.PlaceHelper.AppUserName;
                this.Show();

            }
            else
            {
                Application.Exit();
            }

            
        }

        #endregion Login

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
