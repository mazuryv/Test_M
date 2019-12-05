using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using Microsoft.Win32;

namespace Test_M
{
    public partial class ActivisationForm : Form
    {
        private Setting setting;
        private byte[] d18 ={ 1, 125, 80, 32 };
        private byte[] m14 ={ 136,88,91,74 };
        private int[] m16 ={ 15, 243, 199, 212 };
        private byte[] mrk = { 24, 34, 93, 35, 126, 143, 116, 32 };
        private int count = 0;

        public ActivisationForm()
        {
            InitializeComponent();
        }
        public ActivisationForm(Setting setting)
        {
            InitializeComponent();
            
            this.setting = setting;
            this.textBox1.Clear(); this.textBox2.Clear(); this.textBox3.Clear();
            this.textBox1.Text = this.setting.GetSN();
            RegistryKey rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\\MICROSOFT\\WINDOWS NT\\CurrentVersion");
            if (rk != null)
            {
                this.textBox2.Text = rk.GetValue("RegisteredOwner").ToString();
                this.textBox3.Text = rk.GetValue("RegisteredOrganization").ToString();

            }
        }



        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (this.richTextBox1.Text.Length > 30)
            {
                count++;
                byte[] v43 = { 154, 194, 169, 67, 115 };
                String SN = this.textBox1.Text;
                String DecriptedData = this.richTextBox1.Text;
                String Result = "";
                int[] ch2 = {156,207,354,156780};
                MemoryStream ms = new MemoryStream();
                try
                {
                    string StrByte = "";
                    byte b;
                    int i = 0;
                    while (i < DecriptedData.Length - 2)
                    {

                        do
                        {
                            StrByte += DecriptedData[i];
                            i++;
                        }
                        while (!DecriptedData[i].Equals('-'));
                        i++;
                        b = Convert.ToByte(StrByte);
                        StrByte = "";

                        ms.WriteByte(b);
                    }
                }
                catch
                {

                }
                try
                {
                ms.Seek(0, SeekOrigin.Begin);

              
                    byte[] htq = new byte[24];
                    htq[0]=268/2;
                    htq[13] = 256 - 12;
                    htq[2]=10;
                    htq[15] = m14[0];
                    htq[1]=53;
                    for (int i = 0; i < 24; i++)
                    {
                      if (i<4)  htq[i+3]=Convert.ToByte(m16[i]);
                      if (i == 14) htq[i] = 109;
                      if (i>18 &&i < 24) htq.SetValue(v43[i-19], i);

                    }
                    htq[7] = 21;
                    htq[Convert.ToInt16(htq[2])] = 58;
                    for (int i = 16; i < 20; i++)
                    {
                        if ( i < 19) htq.SetValue(Convert.ToByte(m14[i - 15]), i);
                        
                    }
                    htq[Convert.ToInt16(htq[3]) - 3] = 207;
                    for (int a = 0; a < 126; a++) htq[8] = Convert.ToByte(a);
                    htq[11] = Convert.ToByte(ch2[0]);
                    htq[9] = d18[2];
                    //{ 134, 53, 10, 15, 243, 199, 212, 21, 125, 80, 58, 156, 207, 244, 109, 136, 88, 91, 74, 154, 194, 169, 67, 115 };
                    
                    
                    
                   

                    CryptoStream cStream = new CryptoStream(ms,
                       new TripleDESCryptoServiceProvider().CreateDecryptor(htq, this.mrk ),
                       CryptoStreamMode.Read);

                    StreamReader SR = new StreamReader(cStream);
                    Result = SR.ReadLine();
                ms.Close();
                cStream.Close();
                SR.Close();
           

            if (SN.Equals(Result))
            {
                this.setting.Activisation(Result,this.textBox2.Text,this.textBox3.Text);
                MessageBox.Show("Реєстрація програми проведено успішно. Приємного користування.");
                this.Close();           
            }

            else
            {
                MessageBox.Show("Активізаційний код не вірний. Перевірте його та спробуйте ще раз. ");
                if (count > 5) MessageBox.Show("Ви ввели невірно Активізаційний код більше 5 разів підряд. \nПрограму буде заблоковано.");

            }
        }
        catch (System.Security.Cryptography.CryptographicException)
        { MessageBox.Show("Активізаційний код не правильний"); }
            }
            else MessageBox.Show("Активізаційний код не введено");

        }

        private void вставитиЗБуфераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Paste();
        }

        private void очиститиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Clear();
        }

        private void ActivisationForm_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("www.mazur.dp.ua");

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void ActivisationForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                //String urlhelp = Path.GetFullPath("Test_M_Help.chm");
                Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "9.htm");
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
}