using AutomatedHumanContactMonitorySystemApp.Extensions;
using AutomatedHumanContactMonitorySystemApp.IRepositories;
using AutomatedHumanContactMonitorySystemApp.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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

            ToggleMenuButtons(isDashboard: true);
        }

        private void btnToggleMenu_Click(object sender, EventArgs e)
        {
            ToggleMenuSize();
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
                isAdminClicked = 
                    isContactTracingClicked = !isDashboardClicked;
            }
            else if (isAdminClicked)
            {
                isDashboardClicked = 
                    isContactTracingClicked = !isAdminClicked;
            }
            else if (isContactTracingClicked)
            {
                LoadContactTracingUserControl();

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

        private void LoadContactTracingUserControl()
        {
            var contactTracingUserControl = new ContactTracingUserControl();
            contactTracingUserControl.LoadRepositories(AttendanceRepository, AttendeeRepository, PlaceRepository);
            //contactTracingUserControl.LoadUserControl();
            contactTracingUserControl.Dock = DockStyle.Top;
            flowLayoutPanel1.Controls.Add(contactTracingUserControl);
        }

        private void ClearFlowLayoutPanel()
        {
            flowLayoutPanel1.Controls.Clear();
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

        
    }
}
