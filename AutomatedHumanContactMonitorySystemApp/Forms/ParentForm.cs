using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutomatedHumanContactMonitorySystemApp.Forms
{
    public partial class ParentForm : Form
    {
        private bool isMenuToggled = true;
        private static readonly int fullWidthMenu = 178;
        private static readonly int toggledWidthMenu = 45;
        public ParentForm()
        {
            InitializeComponent();
        }

        private void btnToggleMenu_Click(object sender, EventArgs e)
        {
            ToggleMenu();
        }

        private void ToggleMenu()
        {
            if (isMenuToggled)
            {
                isMenuToggled = false;
                panelMenu.Width = toggledWidthMenu;
            }
            else
            {
                isMenuToggled = true;
                panelMenu.Width = fullWidthMenu;
            }

            btnAdmin.Visible = 
            btnDashboard.Visible = 
            btnContactTracing.Visible = isMenuToggled;

            
        }

    }
}
