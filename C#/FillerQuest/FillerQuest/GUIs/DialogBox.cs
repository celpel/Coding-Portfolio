using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AscendedRPG.GUIs
{
    public partial class DialogBox : Form
    {
        private string[] dialogue;

        int i;

        public DialogBox(string[] d)
        {
            dialogue = d;
            i = 0;
            InitializeComponent();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if(i < dialogue.Length)
            {
                TextBox.Text = dialogue[i];
                i++;
            }
            else
            {
                Close();
            }
        }

        private void DialogTBox_Load(object sender, EventArgs e)
        {
            TextBox.Text = dialogue[i];
            i++;
        }
    }
}
