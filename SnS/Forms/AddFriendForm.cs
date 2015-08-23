using SnS.Classes.Requests;
using SnS.Classes.UserController;
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
    public partial class AddFriendForm : Form
    {
        public AddFriendForm()
        {
            InitializeComponent();
        }

        private void buttAddFriend_Click(object sender, EventArgs e)
        {
            Contact response = SocialRequests.postContact(tbFriendName.Text);
            if (response != null)
            {
                this.Close();
                GlobalVariables.userPanel.addContact(response);
            }
        }
    }
}
