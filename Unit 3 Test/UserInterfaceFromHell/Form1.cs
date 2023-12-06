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
    public partial class Form1 : Form
    {
        int mouseEnterCount = 0;
        static public string yourName = "";
        public Form1()
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

            this.button1.Enabled = false;
            this.label6.Visible = false;
            this.label7.Visible = false;

            this.textBox1.TextChanged += new EventHandler(TxtBoxEmpty__TextChanged);
            this.textBox1.KeyPress += new KeyPressEventHandler(TxtBoxNum__KeyPress);

            this.button1.MouseEnter += new EventHandler(this.Button__MouseEnter);
            this.button1.Click += new EventHandler(Button1__Click);
        }

        private void TxtBoxNum__KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;



            if (e.KeyChar == (char)13)
            {
                Console.WriteLine("enter pressed");
                e.Handled = true;
            }
            if (e.KeyChar == (char)32)
            {
                e.Handled = true;
                Console.WriteLine("space pressed");
            }
            if (e.KeyChar == (char)97 || e.KeyChar == (char)65 || e.KeyChar == (char)101 || e.KeyChar == (char)69 || e.KeyChar == (char)105 || e.KeyChar == (char)73 || e.KeyChar == (char)111 || e.KeyChar == (char)79 || e.KeyChar == (char)117 || e.KeyChar == (char)83)
            {
                Console.WriteLine("vowel pressed");
                tb.Text = e.KeyChar + tb.Text;
                e.Handled = false;

            }
            else
            {
                e.Handled = false;
            }
            /*
            a - 97 - 65
            e - 101 - 69
            i - 105 - 73
            o - 111 - 79
            u - 117 - 85
            */
        }

        private void TxtBoxEmpty__TextChanged(object sender, EventArgs e)
        {
            ValidateAll();
        }
        private void ValidateAll()
        {
            TextBox tb = textBox1;

            if (tb.Text.Contains(" ")) 
            {
                label7.Visible = false;

                if (tb.MaxLength > 0)
                {
                    button1.Enabled = true;
                }
            }
            else
            {
                label7.Visible = true;
            }
            

        }

        private void Button__MouseEnter(object sender, EventArgs e)
        {
            Random rnd = new Random();
            Console.WriteLine(Keys.CapsLock);

            if (Control.IsKeyLocked(Keys.CapsLock) ==false)
            {
                button1.Location = new Point(rnd.Next(75, 700), rnd.Next(75, 285)); //775, 400
                mouseEnterCount++;
                if(mouseEnterCount > 5)
                {
                    this.label6.Visible = true;
                }
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void Button1__Click(object sender, EventArgs e)
        {
            yourName = textBox1.Text;

            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
        
    }
}
