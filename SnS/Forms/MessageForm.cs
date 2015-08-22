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
    public partial class Message : Form
    {
        public Message(String message)
        {
            InitializeComponent();
            textBox1.Text = message + " \n";
            this.TopMost = true;
  
            this.ShowDialog();
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {
        }

        private void closeButtonEvent(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
