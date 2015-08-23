namespace SnS.Forms
{
    partial class AddFriendForm
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
            this.tbFriendName = new System.Windows.Forms.TextBox();
            this.buttAddFriend = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbFriendName
            // 
            this.tbFriendName.Location = new System.Drawing.Point(64, 41);
            this.tbFriendName.Name = "tbFriendName";
            this.tbFriendName.Size = new System.Drawing.Size(100, 20);
            this.tbFriendName.TabIndex = 0;
            // 
            // buttAddFriend
            // 
            this.buttAddFriend.Location = new System.Drawing.Point(64, 86);
            this.buttAddFriend.Name = "buttAddFriend";
            this.buttAddFriend.Size = new System.Drawing.Size(100, 23);
            this.buttAddFriend.TabIndex = 1;
            this.buttAddFriend.Text = "Add Friend";
            this.buttAddFriend.UseVisualStyleBackColor = true;
            this.buttAddFriend.Click += new System.EventHandler(this.buttAddFriend_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(61, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(104, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Search Friend Name";
            // 
            // AddFriendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 161);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.buttAddFriend);
            this.Controls.Add(this.tbFriendName);
            this.Name = "AddFriendForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Friend";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbFriendName;
        private System.Windows.Forms.Button buttAddFriend;
        private System.Windows.Forms.Label lblName;
    }
}