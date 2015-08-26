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
            this.buttAddFriend = new System.Windows.Forms.Button();
            this.chatBox = new System.Windows.Forms.Panel();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.contactsList = new System.Windows.Forms.ListBox();
            this.menuControl.SuspendLayout();
            this.chatPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuControl
            // 
            this.menuControl.Controls.Add(this.chatPage);
            this.menuControl.Controls.Add(this.tabPage2);
            this.menuControl.Location = new System.Drawing.Point(-1, -1);
            this.menuControl.Name = "menuControl";
            this.menuControl.SelectedIndex = 0;
            this.menuControl.Size = new System.Drawing.Size(586, 563);
            this.menuControl.TabIndex = 0;
            // 
            // chatPage
            // 
            this.chatPage.Controls.Add(this.contactsList);
            this.chatPage.Controls.Add(this.buttAddFriend);
            this.chatPage.Controls.Add(this.chatBox);
            this.chatPage.Controls.Add(this.messageBox);
            this.chatPage.Controls.Add(this.sendButton);
            this.chatPage.Location = new System.Drawing.Point(4, 22);
            this.chatPage.Name = "chatPage";
            this.chatPage.Padding = new System.Windows.Forms.Padding(3);
            this.chatPage.Size = new System.Drawing.Size(578, 537);
            this.chatPage.TabIndex = 0;
            this.chatPage.Text = "Chat";
            this.chatPage.UseVisualStyleBackColor = true;
            // 
            // buttAddFriend
            // 
            this.buttAddFriend.Location = new System.Drawing.Point(320, 457);
            this.buttAddFriend.Name = "buttAddFriend";
            this.buttAddFriend.Size = new System.Drawing.Size(249, 63);
            this.buttAddFriend.TabIndex = 6;
            this.buttAddFriend.Text = "button1";
            this.buttAddFriend.UseVisualStyleBackColor = true;
            this.buttAddFriend.Click += new System.EventHandler(this.buttAddFriend_Click);
            // 
            // chatBox
            // 
            this.chatBox.Location = new System.Drawing.Point(9, 20);
            this.chatBox.Name = "chatBox";
            this.chatBox.Size = new System.Drawing.Size(304, 420);
            this.chatBox.TabIndex = 4;
            // 
            // messageBox
            // 
            this.messageBox.Location = new System.Drawing.Point(9, 457);
            this.messageBox.Multiline = true;
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(209, 63);
            this.messageBox.TabIndex = 3;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(224, 457);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(89, 63);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "button1";
            this.sendButton.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(578, 537);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // contactsList
            // 
            this.contactsList.DisplayMember = "id";
            this.contactsList.Location = new System.Drawing.Point(320, 20);
            this.contactsList.MultiColumn = true;
            this.contactsList.Name = "contactsList";
            this.contactsList.Size = new System.Drawing.Size(249, 420);
            this.contactsList.TabIndex = 1;
            this.contactsList.ValueMember = "name";
            this.contactsList.SelectedIndexChanged += new System.EventHandler(this.contactsList_SelectedIndexChanged);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(813, 561);
            this.Controls.Add(this.menuControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserForm";
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
        private System.Windows.Forms.Panel chatBox;
        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button buttAddFriend;
        private System.Windows.Forms.ListBox contactsList;

    }
}