using SnS.Classes;
using SnS.Classes.Requests;
using SnS.Classes.UserController.Objects;
using SnS.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnS.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttLogin_Click(object sender, EventArgs e)
        {
            if (tbEmail.Text == "")
            {
                MessageBox.Show("Email is required");
                return;
            }

            if (tbPassword.Text == "")
            {
                MessageBox.Show("Username is required");
                return;
            }

            MessageResponse result = AuthRequests.postLogin(tbEmail.Text, tbPassword.Text);

            if (result.message == "Login successful!")
            {
                lblError.Text = "";
                GlobalVariables.bIsLoggedIn = true;
                GlobalVariables.userPanel = new Forms.UserForm();
                GlobalVariables.userPanel.Show();
                if (GlobalVariables.user.public_key != "")
                {
                    Functions.RSA.setPrivateKey(RegistryData.getRegistryPrivateKey());
                }
            }
            else
            {
                lblError.Text = result.message;
            }
        }
    }
}
