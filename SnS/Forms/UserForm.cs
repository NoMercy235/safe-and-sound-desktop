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
        private static UserForm self;
        private static System.Windows.Forms.Timer chatTimer = new System.Windows.Forms.Timer();
        private static Contact receiver = null;
        private static string lastSeen = "false";
        private static List<SnS.Classes.UserController.Objects.Message> allMessages = new List<SnS.Classes.UserController.Objects.Message>();

        public UserForm()
        {
            InitializeComponent();
            chatTimer.Interval = 2000;
            chatTimer.Tick += new EventHandler(openChat);
            contactsList.DisplayMember = "name";

            foreach (Contact contact in GlobalVariables.contacts){
                contact.public_key = contact.public_key.Replace(" ", "+");
                contactsList.Items.Add(contact);
            }
            self = this;
        }

        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;                         
        }

        private static void onContactSelect(Contact contact)
        {
            receiver = contact;
            lastSeen = "false";
            self.chatBox.Controls.Clear();
            openChat(null, null);
            chatTimer.Start();
        }

        private static void openChat(object sender, EventArgs e)
        {
            Messages chat = SocialRequests.getMessages(receiver.contact_id, lastSeen);
            chat.messages.Reverse();
            if (lastSeen == "false") lastSeen = "true";

            foreach (SnS.Classes.UserController.Objects.Message message in chat.messages)
            {
                message.message = Functions.RSA.Decrypt(message.message);
                if (message.sent == 0)
                    self.addMessage(message.message, false);
                else
                    self.addMessage(message.message, true);
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
            onContactSelect((Contact)contactsList.SelectedItem);
        }

        private void sendMessage_Click(object sender, EventArgs e)
        {
            if (receiver.contact_id != 0)
            {
                if (messageBox.Text.Length > 0)
                {
                    messageBox.Text = messageBox.Text.Replace("\n", "");
                    if (SocialRequests.postMessage(receiver.contact_id,
                        Functions.RSA.Encrypt(messageBox.Text, receiver.public_key)).message == "success")
                    {
                        addMessage(messageBox.Text, true);
                        messageBox.Text = "";
                    }
                }
                else
                {
                    //no messege to send
                    MessageBox.Show("Please write a message before sending!");
                }
            }
            else
            {
                //no contact selected
                MessageBox.Show("Please select a contact to chat with!");
            }

        }

        private void addMessage(string message, bool sent)
        {
            Color color = sent == true ? Color.FromArgb(153, 102, 153) : Color.FromArgb(0, 153, 0);

            MessageLabel messagelabel = MessageLabel.create(message, chatBox, color);
            self.chatBox.Controls.Add(messagelabel);
            if (self.chatBox.Controls.Count > 25)
            {
                self.chatBox.Controls.RemoveAt(0);
            }
            self.chatBox.VerticalScroll.Value = chatBox.VerticalScroll.Maximum;
            self.chatBox.PerformLayout();
        }

        private void messageBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendMessage_Click(null, null);
            }
        }

    }
}
