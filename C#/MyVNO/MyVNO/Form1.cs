using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyVNO
{
    public partial class Main : Form
    {
        int defVal = 500;
        int fullhp, n, max;
        List<ProgressBar> subbars;
        int[] hpmarkers;
        public Main()
        {
            max = 0;
            fullhp = 0;
            n = 0;
            subbars = new List<ProgressBar>();

            InitializeComponent();

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
            if (progressBar1.Value != 0)
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
                }
                catch (FormatException)
                { }    
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
                Reset();
                progressBar1.Value = hp;
            }
            else
            {
                while (hp < hpmarkers[n])
                {
                    subbars.ElementAt(n).Visible = false;
                    n--;
                }

                int remainder = DivByDef(hp);

                if (remainder == 0)
                {
                    progressBar1.Value = defVal;
                    subbars.ElementAt(n).Visible = false;
                    n--;
                }
                else
                {
                    progressBar1.Value = remainder;
                }
            }

        }

        // sample: 1000, expected output: [500][1]
        private void GenBar(int hp)
        {
            int remainder = DivByDef(hp); // output 0
            int reserveHP = hp - remainder; // output 1000
            n = (reserveHP / defVal) - 1; // output 1

            for(int i = 0; i < n; i++)
            {
                subbars.ElementAt(i).Visible = true;
            }

            if(hp != 0)
            {
                if (remainder == 0)
                {
                    progressBar1.Value = defVal;
                }
                else
                {
                    progressBar1.Value = remainder;
                }
            }
            else
            {
                progressBar1.Value = 0;
            }


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

        private void Reset()
        {
            foreach (ProgressBar p in subbars)
            {
                p.MarqueeAnimationSpeed = 0;
                p.Visible = false;
            }
        }
    }
}
