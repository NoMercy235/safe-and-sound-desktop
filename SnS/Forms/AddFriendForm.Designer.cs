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
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbFriendName
            // 
            this.tbFriendName.Location = new System.Drawing.Point(73, 50);
            this.tbFriendName.Name = "tbFriendName";
            this.tbFriendName.Size = new System.Drawing.Size(100, 20);
            this.tbFriendName.TabIndex = 0;
            // 
            // buttAddFriend
            // 
            this.buttAddFriend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttAddFriend.Location = new System.Drawing.Point(53, 121);
            this.buttAddFriend.Name = "buttAddFriend";
            this.buttAddFriend.Size = new System.Drawing.Size(140, 28);
            this.buttAddFriend.TabIndex = 1;
            this.buttAddFriend.Text = "Add Friend";
            this.buttAddFriend.UseVisualStyleBackColor = true;
            this.buttAddFriend.Click += new System.EventHandler(this.buttAddFriend_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblName.Location = new System.Drawing.Point(31, 18);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(173, 20);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Search Friend Name";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(61, 84);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 20);
            this.lblError.TabIndex = 3;
            // 
            // AddFriendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(241, 161);
            this.Controls.Add(this.lblError);
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
        private System.Windows.Forms.Label lblError;
    }
}