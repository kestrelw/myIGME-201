using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PresidentReplication
{
    public partial class Form1 : Form
    {
        string imgLink = "https://people.rit.edu/dxsigm/";
        string webLink = "https://en.wikipedia.org/wiki/";

        List<RadioButton> radioButtonList = new List<RadioButton>();
        List<System.Windows.Forms.TextBox> textBoxList = new List<System.Windows.Forms.TextBox>();

        ErrorProvider errorProvider = new ErrorProvider();

        public Form1()
        {
            InitializeComponent();
            CreateLists();

            try
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\\WOW6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION",
                    true);
                key.SetValue(Application.ExecutablePath.Replace(Application.StartupPath + "\\", ""), 11001, Microsoft.Win32.RegistryValueKind.DWord);
                key.Close();
            }
            catch
            {

            }

            //set initial values
            this.pictureBox1.ImageLocation = "https://people.rit.edu/dxsigm/GeorgeWashington.jpeg";

            exitButton.Enabled = false;// exit button disabled
            this.radioButton17.Checked = true;//filter all
            this.toolStripProgressBar1.Value = 100;//timer

            this.groupBox2.Text = "https://en.wikipedia.org/wiki/Benjamin_Harrison";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            
            this.webBrowser1.Navigate(this.groupBox2.Text + "#bodyContent");//navigate webbrowser to url
            this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser1__DocumentCompleted);// webbrowser DocumentCopetewd event handler

            this.exitButton.Click += new EventHandler(this.ExitButton__Click);

            for(int i = 0; i < 16; i++)
            {
                radioButtonList[i].CheckedChanged += new EventHandler(this.RadioButtonList__CheckedChanged);
                textBoxList[i].TextChanged += new EventHandler(this.TextBox_TextChanged);
                textBoxList[i].KeyPress += new KeyPressEventHandler(this.TextBox_KeyPress);

                textBoxList[i].MouseHover += new EventHandler(this.TextBox__MouseOver);
            }
            for (int i = 16; i < 21; i++)
            {
                radioButtonList[i].CheckedChanged += new EventHandler(this.FiltersRadioButton__CheckedChanged);
            }


            this.pictureBox1.MouseHover += new EventHandler(this.PictureBox__MouseOver);
            this.pictureBox1.MouseLeave += new EventHandler(this.PictureBox__MouseLeave);

            this.timer.Tick += new EventHandler(Timer__Tick);
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
            radioButtonList.Add(this.radioButton15);
            radioButtonList.Add(this.radioButton16);
            radioButtonList.Add(this.radioButton17);
            radioButtonList.Add(this.radioButton18);
            radioButtonList.Add(this.radioButton19);
            radioButtonList.Add(this.radioButton20);
            radioButtonList.Add(this.radioButton21);
            //radioButtonList[0].

            textBoxList.Add(this.textBox1);
            textBoxList.Add(this.textBox2);
            textBoxList.Add(this.textBox3);
            textBoxList.Add(this.textBox4);
            textBoxList.Add(this.textBox5);
            textBoxList.Add(this.textBox6);
            textBoxList.Add(this.textBox7);
            textBoxList.Add(this.textBox8);
            textBoxList.Add(this.textBox9);
            textBoxList.Add(this.textBox10);
            textBoxList.Add(this.textBox11);
            textBoxList.Add(this.textBox12);
            textBoxList.Add(this.textBox13);
            textBoxList.Add(this.textBox14);
            textBoxList.Add(this.textBox15);
            textBoxList.Add(this.textBox16);
            //textBoxList[0].
        }


        private void Timer__Tick(object sender, EventArgs e)
        {
            --this.toolStripProgressBar1.Value;

            if (this.toolStripProgressBar1.Value == 0)
            {
                this.timer.Stop();
                this.toolStripProgressBar1.Value = 100;//reset

                //reset all text boxes to 0
                for (int i = 0; i < 16; i++)
                {
                    textBoxList[i].Text = "0";
                }
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
                    this.groupBox2.Text = webLink+"Benjamin_Harrison";
                    this.pictureBox1.ImageLocation = imgLink+ "BenjaminHarrison.jpeg";
                }
                if (rb == radioButtonList[1])
                {
                    this.groupBox2.Text = webLink + "Franklin_D_Roosevelt";
                    this.pictureBox1.ImageLocation = imgLink + "FranklinDRoosevelt.jpeg";
                }
                if (rb == radioButtonList[2])
                {
                    this.groupBox2.Text = webLink + "William_J_Clinton";
                    this.pictureBox1.ImageLocation = imgLink + "WilliamJClinton.jpeg";
                }
                if (rb == radioButtonList[3])
                {
                    this.groupBox2.Text = webLink + "James_Buchanan";
                    this.pictureBox1.ImageLocation = imgLink + "JamesBuchanan.jpeg";
                }
                if (rb == radioButtonList[4])
                {
                    this.groupBox2.Text = webLink + "Franklin_Pierce";
                    this.pictureBox1.ImageLocation = imgLink + "FranklinPierce.jpeg";
                }
                if (rb == radioButtonList[5])
                {
                    this.groupBox2.Text = webLink + "George_W_Bush";
                    this.pictureBox1.ImageLocation = imgLink + "GeorgeWBush.jpeg";
                }
                if (rb == radioButtonList[6])
                {
                    this.groupBox2.Text = webLink + "Barack_Obama";
                    this.pictureBox1.ImageLocation = imgLink + "BarackObama.png";
                }
                if (rb == radioButtonList[7])
                {
                    this.groupBox2.Text = webLink + "John_F_Kennedy";
                    this.pictureBox1.ImageLocation = imgLink + "JohnFKennedy.jpeg";
                }
                if (rb == radioButtonList[8])
                {
                    this.groupBox2.Text = webLink + "William_McKinley";
                    this.pictureBox1.ImageLocation = imgLink + "WilliamMcKinley.jpeg";
                }
                if (rb == radioButtonList[9])
                {
                    this.groupBox2.Text = webLink + "Ronald_Reagan";
                    this.pictureBox1.ImageLocation = imgLink + "RonaldReagan.jpeg";
                }
                if (rb == radioButtonList[10])
                {
                    this.groupBox2.Text = webLink + "Dwight_D_Eisenhower";
                    this.pictureBox1.ImageLocation = imgLink + "DwightDEisenhower.jpeg";
                }
                if (rb == radioButtonList[11])
                {
                    this.groupBox2.Text = webLink + "Martin_VanBuren";
                    this.pictureBox1.ImageLocation = imgLink + "MartinVanBuren.jpeg";
                }
                if (rb == radioButtonList[12])
                {
                    this.groupBox2.Text = webLink + "George_Washington";
                    this.pictureBox1.ImageLocation = imgLink + "GeorgeWashington.jpeg";
                }
                if (rb == radioButtonList[13])
                {
                    this.groupBox2.Text = webLink + "John_Adams";
                    this.pictureBox1.ImageLocation = imgLink + "JohnAdams.jpeg";
                }
                if (rb == radioButtonList[14])
                {
                    this.groupBox2.Text = webLink + "Theodore_Roosevelt";
                    this.pictureBox1.ImageLocation = imgLink + "TheodoreRoosevelt.jpeg";
                }
                if (rb == radioButtonList[15])
                {
                    this.groupBox2.Text = webLink + "Thomas_Jefferson";
                    this.pictureBox1.ImageLocation = imgLink + "ThomasJefferson.jpeg";
                }

                this.webBrowser1.Navigate(this.groupBox2.Text + "#bodyContent");
                this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser1__DocumentCompleted);

            }
        }

        private void FiltersRadioButton__CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            // if the radio button is checked
            if (rb.Checked)
            {
                if (rb == radioButtonList[16])//all
                {
                    for (int i = 0; i < 16; i++)
                    {
                        radioButtonList[i].Visible = true;
                        textBoxList[i].Visible = true;
                    }

                    this.radioButton1.Checked = true;//filter all
                }
                if (rb == radioButtonList[17])//democrat
                {
                    for (int i = 0; i < 16; i++)
                    {
                        if ((string)radioButtonList[i].Tag != "Democrat")
                        {
                            radioButtonList[i].Visible = false;
                            textBoxList[i].Visible = false;
                        }
                        else
                        {
                            radioButtonList[i].Visible = true;
                            textBoxList[i].Visible = true;
                        }
                    }

                    this.radioButton2.Checked = true;//filter all
                }
                if (rb == radioButtonList[18])//republican
                {
                    for (int i = 0; i < 16; i++)
                    {
                        if ((string)radioButtonList[i].Tag != "Republican")
                        {
                            radioButtonList[i].Visible = false;
                            textBoxList[i].Visible = false;
                        }
                        else
                        {
                            radioButtonList[i].Visible = true;
                            textBoxList[i].Visible = true;
                        }
                    }
                    this.radioButton1.Checked = true;//filter all
                }
                if (rb == radioButtonList[19])//dem-repub
                {
                    for (int i = 0; i < 16; i++)
                    {
                        if ((string)radioButtonList[i].Tag != "Democratic-Republican")
                        {
                            radioButtonList[i].Visible = false;
                            textBoxList[i].Visible = false;
                        }
                        else
                        {
                            radioButtonList[i].Visible = true;
                            textBoxList[i].Visible = true;
                        }
                    }
                    this.radioButton16.Checked = true;//filter all
                }
                if (rb == radioButtonList[20])//fed
                {
                    for (int i = 0; i < 16; i++)
                    {
                        if ((string)radioButtonList[i].Tag != "Federalist")
                        {
                            radioButtonList[i].Visible = false;
                            textBoxList[i].Visible = false;
                        }
                        else
                        {
                            radioButtonList[i].Visible = true;
                            textBoxList[i].Visible = true;
                        }
                    }
                    this.radioButton13.Checked = true;//filter all
                }
            }
        }

        private void WebBrowser1__DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser wb = (WebBrowser)sender;
            HtmlElementCollection htmlElementCollection = wb.Document.GetElementsByTagName("a");

            foreach (HtmlElement htmlElement in htmlElementCollection)
            {
                htmlElement.MouseOver += new HtmlElementEventHandler(this.webLink__MouseOver);
                htmlElement.MouseLeave += new HtmlElementEventHandler(this.webLink__MouseLeave);
            }

            wb.DocumentCompleted -= WebBrowser1__DocumentCompleted;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;//ignored
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            timer.Interval = 2400;// 2400;
            timer.Tick += new EventHandler(Timer__Tick);
            this.timer.Start();

            System.Windows.Forms.TextBox tb = (System.Windows.Forms.TextBox)sender;


            if ((string)tb.Text != (string)tb.Tag && (string)tb.Text != "0" && tb.Text.Length!=0)
            {
                this.errorProvider.SetError(tb, "This number is incorrect.");
            }
            else
            {
                Console.WriteLine("Correct");
                this.errorProvider.SetError(tb, null);
            }

            ValidateAll();
        }

        private void ValidateAll()
        {
            for (int i = 0; i < 16; i++)
            {
                if (textBoxList[i].Text == (string)textBoxList[i].Tag)
                {
                    //Console.WriteLine("tag "+i+" matches");
                    continue;
                }
                else
                {
                    //Console.WriteLine("incorrect value");
                    return;
                }
            }

            //if none wrong then reach this point
            this.timer.Stop();//pause timer
            this.webBrowser1.Navigate("https://i.pinimg.com/originals/00/ed/7e/00ed7ea3401fe1605ecaffeca76dc7ec.gif");//load fireworks link
            //ORIGINAL LINK WAS NOT WORKING FOR ME 
            this.groupBox2.Text = "https://i.pinimg.com/originals/00/ed/7e/00ed7ea3401fe1605ecaffeca76dc7ec.gif";
            this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser1__DocumentCompleted);
            exitButton.Enabled = true;//enable exit button

        }


        private void PictureBox__MouseOver(object sender, EventArgs e)
        {
            pictureBox1.Size = new System.Drawing.Size(200, 300);
        }

        private void PictureBox__MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Size = new System.Drawing.Size(140, 220);
        }

        private void TextBox__MouseOver(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox rb = (System.Windows.Forms.TextBox)sender;
            //Console.WriteLine("hovering: " + notifyIcon1.Visible);

            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(rb, "Which # President?");
            toolTip1.IsBalloon = true;//text bubbble
        }

        private void webLink__MouseOver(object sender, HtmlElementEventArgs e)
        {
            HtmlElement htmlElement = (HtmlElement)sender;
            toolTip1.Show("Professor Schuh for President!", this.webBrowser1, e.MousePosition.X + 5, e.MousePosition.Y + 15, 30000);
            toolTip1.ShowAlways = true;
            toolTip1.IsBalloon = false;
        }

        private void webLink__MouseLeave(object sender, HtmlElementEventArgs e)
        {
            toolTip1.Hide(this.webBrowser1);
        }

        private void ExitButton__Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
