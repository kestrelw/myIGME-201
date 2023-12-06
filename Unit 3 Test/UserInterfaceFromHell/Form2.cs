using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace UserInterfaceFromHell
{
    public partial class Form2 : Form
    {
        List<RadioButton> radioButtonList = new List<RadioButton>();
        List<TextBox> textBoxList = new List<System.Windows.Forms.TextBox>();
        List<Label> labelList = new List<Label>();
        ErrorProvider errorProvider = new ErrorProvider();
        //System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        Stopwatch stopWatch = new Stopwatch();
        static public string timeTaken;

        public Form2()
        {
            InitializeComponent();
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
            CreateLists();
            DeactivateAll();

            button2.Visible = false;

            for (int i = 0; i < 5; i++)
            {
                textBoxList[i].MouseEnter += new EventHandler(this.HighlightTextBox__MouseEnter);
                textBoxList[i].MouseLeave += new EventHandler(this.HighlightTextBox__MouseLeave);
                labelList[i].MouseEnter += new EventHandler(this.HighlightLabel__MouseEnter);
                labelList[i].MouseLeave += new EventHandler(this.HighlightLabel__MouseLeave);
            }
            for (int i = 0; i < radioButtonList.Count; i++)
            {
                radioButtonList[i].CheckedChanged += new EventHandler(this.RadioButtonList__CheckedChanged);
            }

            this.button1.Click += new EventHandler(this.CloseButton__Clicked);
            this.button2.Click += new EventHandler(this.CheckButton__Clicked);
            

        }

        private void CreateLists()//the lists to make life easier
        {
            radioButtonList.Add(this.radioButton1);
            radioButtonList.Add(this.radioButton2);
            radioButtonList.Add(this.radioButton3);
            radioButtonList.Add(this.radioButton4);
            radioButtonList.Add(this.radioButton5);
            radioButtonList.Add(this.radioButton6);
            radioButtonList.Add(this.radioButton7);
            radioButtonList.Add(this.radioButton8);
            radioButtonList.Add(this.radioButton9);
            radioButtonList.Add(this.radioButton10);
            radioButtonList.Add(this.radioButton11);
            radioButtonList.Add(this.radioButton12);
            radioButtonList.Add(this.radioButton13);
            radioButtonList.Add(this.radioButton14);
            //radioButtonList[0].

            textBoxList.Add(this.textBox1);
            textBoxList.Add(this.textBox2);
            textBoxList.Add(this.textBox3);
            textBoxList.Add(this.textBox4);
            textBoxList.Add(this.textBox5);
            //textBoxList[0].

            labelList.Add(this.label1);
            labelList.Add(this.label2);
            labelList.Add(this.label3);
            labelList.Add(this.label4);
            labelList.Add(this.label5);
        }

        private void DeactivateAll()
        {
            for (int i = 0; i < 5; i++)
            {
                textBoxList[i].Enabled = false;
                labelList[i].Enabled = false;
            }
            for (int i = 0; i < radioButtonList.Count; i++)
            {
                radioButtonList[i].Enabled = false;
            }
        }
        private void ActivateAll()
        {
            for (int i = 0; i < 5; i++)
            {
                textBoxList[i].Enabled = true;
                labelList[i].Enabled = true;
            }
            for (int i = 0; i < radioButtonList.Count; i++)
            {
                radioButtonList[i].Enabled = true;
            }
        }

        private void RadioButtonList__CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            // if the radio button is checked
            if (rb.Checked)
            {
                if (rb == radioButtonList[0])
                {
                    Blackout();
                    textBoxList[0].BackColor = Color.Ivory;
                    textBoxList[0].BorderStyle = BorderStyle.FixedSingle;
                    labelList[0].ForeColor = Color.Ivory;

                }
                else if (rb == radioButtonList[1])
                {
                    Blackout();
                    textBoxList[1].BackColor = Color.Ivory;
                    textBoxList[1].BorderStyle = BorderStyle.FixedSingle;
                    labelList[1].ForeColor = Color.Ivory;
                }
                else if (rb == radioButtonList[2])
                {
                    Blackout();
                    textBoxList[2].BackColor = Color.Ivory;
                    textBoxList[2].BorderStyle = BorderStyle.FixedSingle;
                    labelList[2].ForeColor = Color.Ivory;
                }
                else if (rb == radioButtonList[3])
                {
                    Blackout();
                    textBoxList[3].BackColor = Color.Ivory;
                    textBoxList[3].BorderStyle = BorderStyle.FixedSingle;
                    labelList[3].ForeColor = Color.Ivory;
                }
                else if (rb == radioButtonList[4])
                {
                    Blackout();
                    textBoxList[4].BackColor = Color.Ivory;
                    textBoxList[4].BorderStyle = BorderStyle.FixedSingle;
                    labelList[4].ForeColor = Color.Ivory;
                }
                else
                {
                    Blackout();
                }


            }
        }

        public void TxtBoxEmpty__Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (tb.Text.Length == 0)
            {
                this.errorProvider.SetError(tb, "This field cannot be empty.");
                e.Cancel = true;
            }
            else
            {
                this.errorProvider.SetError(tb, null);
                e.Cancel = false;
            }


        }

        public void TxtBox__TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;

            this.errorProvider.SetError(tb, null);

            for (int i = 0; i < 5; i++)
            {
                if (textBoxList[i].Text.Length > 0)
                {
                    continue;
                }
                else
                {
                    return;
                }
            }

            button2.Visible = true;
        }

        private void Blackout()
        {
            this.BackColor = Color.Black;

            for (int i = 0; i < 5; i++)
            {
                textBoxList[i].BackColor = Color.Black;
                textBoxList[i].BorderStyle = BorderStyle.None;
                labelList[i].ForeColor = Color.Black;


            }
        }

        private void BlackoutPopup()
        {
            groupBox1.Visible = true;
            groupBox1.BackColor = Color.DarkGray;
            groupBox1.ForeColor = Color.DarkRed;
            label6.Text = "It appears we are having some power\ndifficulties. Why don’t you try and feel around for\na few moments to try and get your bearings.\n\n Bzz Bzzt";
        }

        private void HighlightTextBox__MouseEnter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = Color.Ivory;
            textBox.BorderStyle = BorderStyle.FixedSingle;
        }
        private void HighlightTextBox__MouseLeave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = Color.Black;
            textBox.BorderStyle = BorderStyle.None;
        }

        private void HighlightLabel__MouseEnter(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.ForeColor = Color.Ivory;
        }
        private void HighlightLabel__MouseLeave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.ForeColor = Color.Black;
        }

        private void CloseButton__Clicked(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            for (int i = 0; i < 5; i++)
            {
                textBoxList[i].Validating += new CancelEventHandler(TxtBoxEmpty__Validating);
                textBoxList[i].TextChanged += new EventHandler(TxtBox__TextChanged);
                
            }

            //Thread.Sleep(3000);//causing groupbox visibility remain errors
            Blackout();

            if (textBoxList[0].Enabled == false)
            {
                BlackoutPopup();
            }
            ActivateAll();

            stopWatch.Start();


        }

        private void CheckButton__Clicked(object sender, EventArgs e)
        {
            ValidateAll();
        }
        private void ValidateAll()
        {
            bool incorrect = false;

            for (int i = 0; i < 5; i++)
            {
                if (textBoxList[i].Text.ToLower() == (string)textBoxList[i].Tag)
                {
                    continue;
                }
                else
                {
                    this.errorProvider.SetError(textBoxList[i], "This answer is incorrect.");
                    incorrect = true;
                }
            }

            
            if (incorrect)
            {
                return;
            }
            

            //if none wrong then reach this point
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            timeTaken =  String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);

            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }
        
    }
}


