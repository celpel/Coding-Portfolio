using AscendedRPG.Files;
using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace AscendedRPG.GUIs
{
    public partial class CharacterSelect : Form
    {
        private static readonly string PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Ascended", "profilePictures");
        private string[] images;
        private string i_path;
        private PictureBox selected;
        private int index;

        private Player p;

        public CharacterSelect(Player pl)
        {
            p = pl;
            InitializeComponent();
        }

        private void CharacterSelect_Load(object sender, EventArgs e)
        { 
            index = 0;
            images = Directory.GetFiles(PATH);
            selected = pictureBox1;
            i_path = string.Empty;
            DisplayImages();
        }

        private void DisplayImages()
        {
            PictureBox[] pbs = { pictureBox1, pictureBox2, pictureBox3 };
            for (int i = 0; i < pbs.Length; i++)
            {
                pbs[i].Visible = true;
                pbs[i].Image = Image.FromFile(images[index]);
                pbs[i].ImageLocation = images[index];
                index++;
            }
        }

        private void nextSet_Click(object sender, EventArgs e)
        {
            blink.Stop();

            int test = index + 3;

            if(test >= images.Length)
            {
                index = test - images.Length;
            }

            i_path = string.Empty;

            DisplayImages();
        }

        private void oldSet_Click(object sender, EventArgs e)
        {
            blink.Stop();

            index -= 6;

            if(index < 0)
            {
                index = images.Length - 3;
            }

            i_path = string.Empty;

            DisplayImages();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            blink.Stop();

            pictureBox2.Visible = true;

            pictureBox3.Visible = true;

            selected = pictureBox1;

            i_path = pictureBox1.ImageLocation;

            blink.Start();
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            blink.Stop();

            pictureBox1.Visible = true;

            pictureBox3.Visible = true;

            selected = pictureBox2;

            i_path = pictureBox2.ImageLocation;

            blink.Start();

        }

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            blink.Stop();

            pictureBox2.Visible = true;

            pictureBox1.Visible = true;

            selected = pictureBox3;

            i_path = pictureBox3.ImageLocation;

            blink.Start();

        }

        private void blink_Tick(object sender, EventArgs e)
        {
            selected.Visible = !selected.Visible;
        }

        private void CharacterSelect_FormClosing(object sender, FormClosingEventArgs e)
        {
            blink.Stop();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if(i_path.Equals(string.Empty))
            {
                MessageBox.Show("Pick a proflie pic to continue.");
            }
            else
            {
                if (MessageBox.Show("Are you sure you want this image as your profile picture? There's no going back once it's chosen.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    p.Picture = i_path;

                    SaveManager.SaveGame(p);

                    SaveManager.SaveWeaknessIndex(new WeaknessIndex());

                    SaveManager.SaveRelicManager(new FillerQuest.Relics.RelicManager());

                    Visible = false;

                    string[] d = {
                        "You are a villager from a far off island.",
                        "It was a few weeks ago that you received your calling.",
                        "Since then, you've journed across the globe to find what is known as \"The Endless Dungeon.\"",
                        "When every young villager grows up, it becomes their duty to journey to this far off place.",
                        "Rumor has it that if you reach the bottom, you can attain enlightenment beyond normal human comprehension.",
                        "However, no one has been able to confirm it.",
                        "All who try to fully traverse The Endless Dungeon disappear.",
                        "But, you will be different.",
                        "You are a gamer, and gamers rise up and conquer all challenges.",
                        "So, go, my fellow gamer... rise up...",
                        "...AND ASCEND!!!!",
                        "~ this post was made by the \"totally not a scam\" gang"
                    };

                    DialogBox db = new DialogBox(d);
                    db.StartPosition = FormStartPosition.Manual;
                    db.Location = Location;
                    db.ShowDialog();

                    DisplayInventory();
                }
            }
        }

        private void DisplayInventory()
        {
            Thread thread = new Thread(new ThreadStart(() =>
            {
                var inv = new Inventory();
                inv.StartPosition = FormStartPosition.Manual;
                inv.Location = Location;
                Application.Run(inv);
            }));

            thread.Start();
            Close();
        }
    }
}
