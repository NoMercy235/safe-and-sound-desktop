namespace SnS.Forms
{
    partial class UserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuControl = new System.Windows.Forms.TabControl();
            this.chatPage = new System.Windows.Forms.TabPage();
            this.chatBox = new System.Windows.Forms.FlowLayoutPanel();
            this.contactsList = new System.Windows.Forms.ListBox();
            this.buttAddFriend = new System.Windows.Forms.Button();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.sendMessage = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.menuControl.SuspendLayout();
            this.chatPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuControl
            // 
            this.menuControl.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.menuControl.Controls.Add(this.chatPage);
            this.menuControl.Controls.Add(this.tabPage2);
            this.menuControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuControl.Location = new System.Drawing.Point(-1, -1);
            this.menuControl.Name = "menuControl";
            this.menuControl.SelectedIndex = 0;
            this.menuControl.Size = new System.Drawing.Size(586, 563);
            this.menuControl.TabIndex = 0;
            // 
            // chatPage
            // 
            this.chatPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chatPage.Controls.Add(this.chatBox);
            this.chatPage.Controls.Add(this.contactsList);
            this.chatPage.Controls.Add(this.buttAddFriend);
            this.chatPage.Controls.Add(this.messageBox);
            this.chatPage.Controls.Add(this.sendMessage);
            this.chatPage.Location = new System.Drawing.Point(4, 28);
            this.chatPage.Name = "chatPage";
            this.chatPage.Padding = new System.Windows.Forms.Padding(3);
            this.chatPage.Size = new System.Drawing.Size(578, 531);
            this.chatPage.TabIndex = 0;
            this.chatPage.Text = "Chat";
            // 
            // chatBox
            // 
            this.chatBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chatBox.AutoScroll = true;
            this.chatBox.AutoSize = true;
            this.chatBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.chatBox.BackColor = System.Drawing.Color.Gray;
            this.chatBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chatBox.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.chatBox.Location = new System.Drawing.Point(9, 17);
            this.chatBox.MaximumSize = new System.Drawing.Size(392, 410);
            this.chatBox.MinimumSize = new System.Drawing.Size(392, 410);
            this.chatBox.Name = "chatBox";
            this.chatBox.Size = new System.Drawing.Size(392, 410);
            this.chatBox.TabIndex = 0;
            this.chatBox.WrapContents = false;
            // 
            // contactsList
            // 
            this.contactsList.BackColor = System.Drawing.Color.Gray;
            this.contactsList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contactsList.DisplayMember = "id";
            this.contactsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactsList.ItemHeight = 29;
            this.contactsList.Location = new System.Drawing.Point(407, 20);
            this.contactsList.Name = "contactsList";
            this.contactsList.Size = new System.Drawing.Size(168, 408);
            this.contactsList.TabIndex = 1;
            this.contactsList.ValueMember = "name";
            this.contactsList.SelectedIndexChanged += new System.EventHandler(this.contactsList_SelectedIndexChanged);
            // 
            // buttAddFriend
            // 
            this.buttAddFriend.BackColor = System.Drawing.Color.Gray;
            this.buttAddFriend.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttAddFriend.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttAddFriend.Location = new System.Drawing.Point(407, 436);
            this.buttAddFriend.Name = "buttAddFriend";
            this.buttAddFriend.Size = new System.Drawing.Size(162, 63);
            this.buttAddFriend.TabIndex = 6;
            this.buttAddFriend.Text = "Add Friend";
            this.buttAddFriend.UseVisualStyleBackColor = false;
            this.buttAddFriend.Click += new System.EventHandler(this.buttAddFriend_Click);
            // 
            // messageBox
            // 
            this.messageBox.BackColor = System.Drawing.Color.Gray;
            this.messageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.messageBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageBox.Location = new System.Drawing.Point(9, 436);
            this.messageBox.Multiline = true;
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(297, 63);
            this.messageBox.TabIndex = 3;
            // 
            // sendMessage
            // 
            this.sendMessage.BackColor = System.Drawing.Color.Gray;
            this.sendMessage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sendMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendMessage.Location = new System.Drawing.Point(312, 436);
            this.sendMessage.Name = "sendMessage";
            this.sendMessage.Size = new System.Drawing.Size(89, 63);
            this.sendMessage.TabIndex = 2;
            this.sendMessage.Text = "Send";
            this.sendMessage.UseVisualStyleBackColor = false;
            this.sendMessage.Click += new System.EventHandler(this.sendMessage_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(578, 531);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(585, 561);
            this.Controls.Add(this.menuControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Panel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserForm_FormClosing);
            this.menuControl.ResumeLayout(false);
            this.chatPage.ResumeLayout(false);
            this.chatPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl menuControl;
        private System.Windows.Forms.TabPage chatPage;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.Button sendMessage;
        private System.Windows.Forms.Button buttAddFriend;
        private System.Windows.Forms.ListBox contactsList;
        private System.Windows.Forms.FlowLayoutPanel chatBox;

    }
}