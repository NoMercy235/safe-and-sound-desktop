using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnS.Classes.App.Objects
{
    public class MessageLabel : Label
    {
        public static LinkedList<MessageLabel> allMessageLabels = new LinkedList<MessageLabel>();
        public static int lastIndex = 0;

        public static MessageLabel create(string message, FlowLayoutPanel panel, Color color)
        {
            MessageLabel messageLabel = new MessageLabel();
            messageLabel.BackColor = color;
            messageLabel.ForeColor = Color.FromArgb(0, 0, 0);
            messageLabel.Margin = new Padding(4);
            messageLabel.Text = message;
            messageLabel.Width = (int)(panel.Width * 0.95);
            messageLabel.TextAlign = ContentAlignment.MiddleLeft;
            messageLabel.Font = new Font(messageLabel.Font, FontStyle.Bold);
            messageLabel.Font = new Font(messageLabel.Font.FontFamily, 18);
            
            messageLabel.AutoSize = true;

            return messageLabel;
        }
    }
}
