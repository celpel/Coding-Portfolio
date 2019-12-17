using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FillerQuest
{
    public partial class NewGameGUI : Form
    {
        public NewGameGUI()
        {
            InitializeComponent();
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            SaveManager.NewGame(NameBox.Text);
            Close();
        }
    }
}
