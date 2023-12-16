using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterfaceFromHell
{
    public partial class Form3 : Form
    {
        List<Label> positive3List = new List<Label>();
        List<Label> positive1List = new List<Label>();
        List<Label> negative1List = new List<Label>();
        int clickCount = 0;
        public Form3()
        {
            InitializeComponent();
            CreateLists();

            //this.progressBar1.Value = 100;//for debugging
            try
            {
                // Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.2; WOW64; Trident / 7.0; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.30729; .NET CLR 3.5.30729; wbx 1.0.0)
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\\WOW6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION",
                    true);
                key.SetValue(Application.ExecutablePath.Replace(Application.StartupPath + "\\", ""), 12001, Microsoft.Win32.RegistryValueKind.DWord);
                key.Close();
            }
            catch
            {

            }

            progressBar1.Visible = false;
            
            for(int i = 0; i < positive3List.Count; i++)
            {
                positive3List[i].ForeColor = SystemColors.Control;
                positive3List[i].Click += new EventHandler(AdjustProgress__Click);
            }
            for(int i = 0;i < positive1List.Count; i++)
            {
                positive1List[i].ForeColor = SystemColors.Control;
                positive1List[i].Click += new EventHandler(AdjustProgress__Click);
            }
            for(int i = 0;i < negative1List.Count; i++)
            {
                negative1List[i].ForeColor = SystemColors.Control;
                negative1List[i].Click += new EventHandler(AdjustProgress__Click);
            }
            
            pictureBox1.Click += new EventHandler(ClickCount);
        }

        public void CreateLists()
        {
            //positive 3 points
            positive3List.Add(this.label6);
            positive3List.Add(this.label7);
            positive3List.Add(this.label8);
            positive3List.Add(this.label9);
            positive3List.Add(this.label10);
            positive3List.Add(this.label11);
            positive3List.Add(this.label12);
            positive3List.Add(this.label13);
            positive3List.Add(this.label14);
            positive3List.Add(this.label15);

            //positive 1 points
            positive1List.Add(this.label16);
            positive1List.Add(this.label17);
            positive1List.Add(this.label18);
            positive1List.Add(this.label19);
            positive1List.Add(this.label20);
            positive1List.Add(this.label21);
            positive1List.Add(this.label22);
            positive1List.Add(this.label23);
            positive1List.Add(this.label24);
            positive1List.Add(this.label25);

            //negatvive 1 points
            negative1List.Add(this.label26);
            negative1List.Add(this.label27);
            negative1List.Add(this.label28);
            negative1List.Add(this.label29);
            negative1List.Add(this.label30);
            negative1List.Add(this.label31);
            negative1List.Add(this.label32);
            negative1List.Add(this.label33);
            negative1List.Add(this.label34);
            negative1List.Add(this.label35);
            negative1List.Add(this.label36);
            negative1List.Add(this.label37);
            negative1List.Add(this.label38);
            negative1List.Add(this.label39);
            negative1List.Add(this.label40);
            negative1List.Add(this.label41);
            negative1List.Add(this.label42);
            negative1List.Add(this.label43);
            negative1List.Add(this.label44);
            negative1List.Add(this.label45);
        }

        public void AdjustProgress__Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;

            if((string)label.Tag == "+1")
            {
                if (progressBar1.Visible == false)
                {
                    progressBar1.Visible = true;
                }
                label.ForeColor = Color.Green;
                if (this.progressBar1.Value <= 75)
                {
                    this.progressBar1.Value += 5;
                }
                else
                {
                    this.progressBar1.Value = 100;
                }
            }
            else if ((string)label.Tag == "-1")
            {
                label.ForeColor = Color.DarkRed;
                if (this.progressBar1.Value >= 5)
                {
                    this.progressBar1.Value= this.progressBar1.Value-5;
                }
                else
                {
                    this.progressBar1.Value = 0;
                }
                
            }
            else if ((string)label.Tag == "+3")
            {
                if (progressBar1.Visible == false)
                {
                    progressBar1.Visible = true;
                }
                label.ForeColor = Color.Green;
                if (this.progressBar1.Value <= 75)
                {
                    this.progressBar1.Value += 15;
                }
                else
                {
                    this.progressBar1.Value = 100;
                }
            }

            if (this.progressBar1.Value >= 100)
            {
                groupBox1.Visible = false;
                string name = Form1.yourName;
                string timeTaken = Form2.timeTaken;

                label2.Text = name;
                label3.Text = timeTaken;
                label4.Text = clickCount.ToString()+" clicks";
            }

        }

        public void ClickCount(object sender, EventArgs e)
        {
            clickCount++;
        }
    }
}
