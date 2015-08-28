using SnS.Classes.App.Objects;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnS.Forms
{
    public partial class UserForm : Form
    {
        private static Thread chatThread = new Thread(getChat);
        private static  int receiverId = 0;
        private static List<SnS.Classes.UserController.Objects.Message> allMessages = new List<SnS.Classes.UserController.Objects.Message>();

        public UserForm()
        {
            InitializeComponent();

            contactsList.DisplayMember = "name";
            string[] aux = new string[2];
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
            allMessages = allMessages.Union(chat.messages).ToList();

            foreach (SnS.Classes.UserController.Objects.Message message in allMessages)
            {
                addMessage(message.message);
            }
            chatThread.Start();
        }

        private static void getChat()
        {
            while (true)
            {

                Thread.Sleep(2000);
            }
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

        private void sendMessage_Click(object sender, EventArgs e)
        {
            if (receiverId != 0)
            {
                if (messageBox.Text.Length > 0)
                {
                    if (SocialRequests.postMessage(receiverId, messageBox.Text).message == "success")
                    {
                        addMessage(messageBox.Text);
                    }
                    messageBox.Text = "";

                }
                else
                {
                    //no messege to send
                }
            }
            else
            {
                //no contact selected
            }
        }

        private void addMessage(string message)
        {
            MessageLabel messagelabel = MessageLabel.create(message, chatBox, Color.FromArgb(153, 102, 153));
            chatBox.Controls.Add(messagelabel);
            chatBox.VerticalScroll.Value = chatBox.VerticalScroll.Maximum;
            chatBox.PerformLayout();
        }


    }
}
