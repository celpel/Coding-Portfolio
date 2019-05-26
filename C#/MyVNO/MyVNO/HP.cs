using MyVNO.ScreenShotDemo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyVNO
{
    public partial class Main : Form
    {
        private int defVal = 0;
        private int fullhp, n, max;
        private List<ProgressBar> subbars;
        private int[] hpmarkers;

        public Main()
        {
            defVal = 500;
            max = 0;
            fullhp = 0;
            n = 0;
            
            InitializeComponent();

            hptext.ForeColor = Color.Green;

            subbars = new List<ProgressBar>();
            subbars.Add(progressBar22);
            subbars.Add(progressBar23);
            subbars.Add(progressBar24);
            subbars.Add(progressBar25);
            subbars.Add(progressBar16);
            subbars.Add(progressBar17);
            subbars.Add(progressBar18);
            subbars.Add(progressBar19);
            subbars.Add(progressBar20);
            subbars.Add(progressBar11);
            subbars.Add(progressBar12);
            subbars.Add(progressBar13);
            subbars.Add(progressBar14);
            subbars.Add(progressBar15);
            subbars.Add(progressBar6);
            subbars.Add(progressBar7);
            subbars.Add(progressBar8);
            subbars.Add(progressBar9);
            subbars.Add(progressBar10);
            subbars.Add(progressBar5);
            subbars.Add(progressBar4);
            subbars.Add(progressBar3);
            subbars.Add(progressBar2);
            subbars.Add(ahp_1);
            subbars.Add(progressBar21);
            subbars.Add(progressBar27);
            subbars.Add(progressBar28);
            subbars.Add(progressBar29);
            subbars.Add(progressBar30);
            subbars.Add(progressBar31);
            subbars.Add(progressBar32);
            subbars.Add(progressBar26);
            subbars.Add(progressBar34);
            subbars.Add(progressBar35);
            subbars.Add(progressBar36);
            subbars.Add(progressBar37);
            subbars.Add(progressBar38);
            subbars.Add(progressBar39);
            subbars.Add(progressBar33);
            subbars.Add(progressBar41);
            subbars.Add(progressBar42);
            subbars.Add(progressBar40);
            subbars.Add(progressBar61);
            subbars.Add(progressBar62);
            subbars.Add(progressBar60);
            subbars.Add(progressBar54);
            subbars.Add(progressBar55);
            subbars.Add(progressBar56);
            subbars.Add(progressBar57);
            subbars.Add(progressBar58);
            subbars.Add(progressBar59);
            subbars.Add(progressBar53);
            subbars.Add(progressBar47);
            subbars.Add(progressBar48);
            subbars.Add(progressBar49);
            subbars.Add(progressBar50);
            subbars.Add(progressBar51);
            subbars.Add(progressBar52);
            subbars.Add(progressBar46);
            subbars.Add(progressBar44);
            subbars.Add(progressBar45);
            subbars.Add(progressBar43);
            subbars.Add(progressBar67);
            subbars.Add(progressBar68);
            subbars.Add(progressBar69);
            subbars.Add(progressBar66);
            subbars.Add(progressBar63);
            subbars.Add(progressBar64);
            subbars.Add(progressBar65);
            subbars.Add(progressBar74);
            subbars.Add(progressBar75);
            subbars.Add(progressBar76);
            subbars.Add(progressBar73);
            subbars.Add(progressBar70);
            subbars.Add(progressBar71);
            subbars.Add(progressBar72);
            subbars.Add(progressBar81);
            subbars.Add(progressBar82);
            subbars.Add(progressBar83);
            subbars.Add(progressBar80);
            subbars.Add(progressBar77);
            subbars.Add(progressBar78);
            subbars.Add(progressBar79);
            subbars.Add(progressBar102);
            subbars.Add(progressBar103);
            subbars.Add(progressBar104);
            subbars.Add(progressBar101);
            subbars.Add(progressBar98);
            subbars.Add(progressBar99);
            subbars.Add(progressBar100);
            subbars.Add(progressBar95);
            subbars.Add(progressBar96);
            subbars.Add(progressBar97);
            subbars.Add(progressBar94);
            subbars.Add(progressBar91);
            subbars.Add(progressBar92);
            subbars.Add(progressBar93);
            subbars.Add(progressBar88);
            subbars.Add(progressBar89);
            subbars.Add(progressBar90);
            subbars.Add(progressBar87);
            subbars.Add(progressBar84);
            subbars.Add(progressBar85);
            subbars.Add(progressBar86);
            subbars.Add(progressBar123);
            subbars.Add(progressBar124);
            subbars.Add(progressBar125);
            subbars.Add(progressBar122);
            subbars.Add(progressBar119);
            subbars.Add(progressBar120);
            subbars.Add(progressBar121);
            subbars.Add(progressBar116);
            subbars.Add(progressBar117);
            subbars.Add(progressBar118);
            subbars.Add(progressBar115);
            subbars.Add(progressBar112);
            subbars.Add(progressBar113);
            subbars.Add(progressBar114);
            subbars.Add(progressBar109);
            subbars.Add(progressBar110);
            subbars.Add(progressBar111);
            subbars.Add(progressBar108);
            subbars.Add(progressBar105);
            subbars.Add(progressBar106);
            subbars.Add(progressBar107);
            subbars.Add(progressBar144);
            subbars.Add(progressBar145);
            subbars.Add(progressBar146);
            subbars.Add(progressBar143);
            subbars.Add(progressBar140);
            subbars.Add(progressBar141);
            subbars.Add(progressBar142);
            subbars.Add(progressBar137);
            subbars.Add(progressBar138);
            subbars.Add(progressBar139);
            subbars.Add(progressBar137);
            subbars.Add(progressBar138);
            subbars.Add(progressBar139);
            subbars.Add(progressBar136);
            subbars.Add(progressBar133);
            subbars.Add(progressBar134);
            subbars.Add(progressBar135);
            subbars.Add(progressBar130);
            subbars.Add(progressBar131);
            subbars.Add(progressBar132);
            subbars.Add(progressBar129);
            subbars.Add(progressBar126);
            subbars.Add(progressBar127);
            subbars.Add(progressBar128);

            hpmarkers = new int[subbars.Count];

            int v = defVal;
            for(int i = 0; i < hpmarkers.Length; i++)
            {
                hpmarkers[i] = v;
                v += defVal;
            }

            progressBar1.Maximum = defVal;
            Reset();
        }

        private void attk_Click(object sender, EventArgs e)
        {
            if (progressBar1.Value > 0)
            {
                try
                {
                    int val = Int32.Parse(attkbox.Text);
                    fullhp -= val;

                    if(fullhp <= 0)
                    {
                        GenBar(0);
                    }
                    else
                    {
                        ReduceBar(fullhp);
                    }

                    hptext.Text = $"{progressBar1.Value}/{defVal}";
                }
                catch (FormatException)
                { }    
            }
            else
            {
                progressBar1.Value = 0;
            }
        }

        private void bosshp_Click(object sender, EventArgs e)
        {
            Reset();
            int hp = Int32.Parse(bhp.Text);
            max = fullhp;
            fullhp = hp;
            GenBar(hp);
        }

        private void ReduceBar(int hp)
        {
            if(hp <= hpmarkers[0])
            {
                subbars.ElementAt(0).Value = 0;
                progressBar1.Value = hp;
            }
            else
            {
                while (hp < hpmarkers[n - 1])
                {
                    subbars.ElementAt(n - 1).Value = 0;
                    n--;
                }

                int remainder = DivByDef(hp);

                if (remainder == 0)
                {
                    progressBar1.Value = defVal;
                    subbars.ElementAt(n - 1).Value = 0;
                    n--;
                }
                else
                {
                    progressBar1.Value = remainder;
                }
            }

        }

        // sample: 600, expected output: [100][1]
        private void GenBar(int hp)
        {
            int remainder = DivByDef(hp); // output 0
            int reserveHP = hp - remainder; // output 100
            n = (reserveHP / defVal);

            for(int i = 0; i < hpmarkers.Length; i++)
            {
                if(hp < hpmarkers[i])
                {
                    break;
                }
                else
                {
                    subbars.ElementAt(i).Visible = true;
                } 
            }

            if(remainder == 0 && fullhp > 0)
            {
                remainder = defVal;
                subbars.ElementAt(n - 1).Visible = false;
            }

            if(fullhp <= 0)
            {
                remainder = 0;
            }
            progressBar1.Value = remainder;
            hptext.Text = $"{progressBar1.Value}/{defVal}";
        }

        private void ndefault_Click(object sender, EventArgs e)
        {
            string s = defaultv.Text;

            try
            {
                defVal = Int32.Parse(s);
            }
            catch(Exception)
            {
                defVal = 500;
            }

            hpmarkers = new int[subbars.Count];

            int v = defVal;
            for (int i = 0; i < hpmarkers.Length; i++)
            {
                hpmarkers[i] = v;
                v += defVal;
            }

            progressBar1.Maximum = defVal;

            Reset();
        }

        private int DivByDef(int hp)
        {
            int remainder = 0;
            while(hp % defVal != 0)
            {
                hp--;
                remainder++;
            }
            return remainder;
        }

        private void screenshott_Click(object sender, EventArgs e)
        {
            ScreenShot();
        }

        private void Reset()
        {
            foreach(ProgressBar p in subbars)
            {
                p.MarqueeAnimationSpeed = 0;
                p.Value = p.Maximum;
                p.Visible = false;
            }
        }

        private void ScreenShot()
        {
            string path = @"C:\Temp\temp.png";
            string path2 = @"C:\Temp\crop_image.png";

            ScreenCapture sc = new ScreenCapture();
            Image img = sc.CaptureScreen();

            sc.CaptureWindowToFile(Handle, path, ImageFormat.Png);
            img.Dispose();

            Rectangle crop = new Rectangle(10, 1, 417, 160);
            Bitmap src = Image.FromFile(path) as Bitmap;
            Bitmap target = new Bitmap(crop.Width, crop.Height);

            using (Graphics g = Graphics.FromImage(target))
            {
                g.DrawImage(src, new Rectangle(0, 0, target.Width, target.Height), crop, GraphicsUnit.Pixel);
            }

            src.Dispose();

            if(File.Exists(path2))
            {
                File.Delete(path2);
            }

            target.Save(path2, ImageFormat.Png);
            target.Dispose();
            File.Delete(path);
        }
    }
}
