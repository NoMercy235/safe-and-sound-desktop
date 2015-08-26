using SnS.Classes.Requests;
using SnS.Classes.UserController;
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
    public partial class UserForm : Form
    {
        private int receiverId = 0;

        public UserForm()
        {
            InitializeComponent();

            contactsList.DisplayMember = "name";
            foreach (Contact contact in GlobalVariables.contacts){
                contactsList.Items.Add(contact);
            }
            //this.ShowDialog();
        }

        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;                         
            //Hide();
        }

        private void openChat(Contact contact)
        {
            receiverId = contact.contact_id;
            Messages chat = SocialRequests.getMessages(receiverId);


        }

        private void buttAddFriend_Click(object sender, EventArgs e)
        {
            AddFriendForm form = new AddFriendForm();
            form.Show();
        }

        public void addContact(Contact contact)
        {
            contactsList.Items.Add(contact);
            contactsList.Refresh();
        }

        private void contactsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            openChat((Contact)contactsList.SelectedItem);
        }


    }
}
