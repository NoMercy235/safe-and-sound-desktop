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
    public partial class UserForm : Form
    {
        private int receiverId = 0;

        public UserForm()
        {
            InitializeComponent();


            foreach (Contact contact in GlobalVariables.contacts)
            {
                Label tbContact = new Label();
                tbContact.Text = contact.name;
                tbContact.Name = contact.contact_id.ToString();
                tbContact.Click += new System.EventHandler(this.openChat);

                contactsList.Controls.Add(tbContact);
            }
            //this.ShowDialog();
        }

        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;                         
            //Hide();
        }

        private void openChat(System.Object sender, EventArgs e)
        {
            Label tb = (Label)sender;
            receiverId = Int32.Parse(tb.Name);
        }

        private void buttAddFriend_Click(object sender, EventArgs e)
        {
            AddFriendForm form = new AddFriendForm();
            form.Show();
        }

        public void addContact(Contact contact)
        {
            Label tbContact = new Label();
            tbContact.Text = contact.name;
            tbContact.Name = contact.contact_id.ToString();
            tbContact.Click += new System.EventHandler(this.openChat);

            contactsList.Controls.Add(tbContact);
            contactsList.Refresh();
        }


    }
}
