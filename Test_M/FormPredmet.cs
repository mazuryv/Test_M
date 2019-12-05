using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Test_M
{
    public partial class FormPredmet : Form
    {   
        public FormPredmet()
        {
            InitializeComponent();
        }
        
        public FormPredmet(String TextOfForm)
        {
            InitializeComponent();
            
            this.Text = TextOfForm;
            this.textBox1.Clear();
            this.textBox1.Focus();
            
        }

        public FormPredmet(String TextOfForm, String NameOfPredmet)
        {
            InitializeComponent();
            this.Text = TextOfForm;
            this.textBox1.Text=NameOfPredmet;
            this.textBox1.SelectAll();
            this.textBox1.Focus();
        }

        public FormPredmet(String TextOfForm, bool IfNewNameOfTest, String NameOfTest)
        {
            InitializeComponent();
            if (IfNewNameOfTest) {
                this.label1.Text = "Введіть нову назву:";
                }
            this.Text = TextOfForm;
            string NameColection = NameOfTest.Substring(0,3);
            if (NameColection.Equals("(K)"))
                this.textBox1.Text = NameOfTest.Substring(4, NameOfTest.Length-4);
            else this.textBox1.Text = NameOfTest;
            this.textBox1.SelectAll();
            this.textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Length < 1) MessageBox.Show("Назва навчальної дисципліни не введена, повторіть, будь ласка!");
            else
            {
                this.Visible = false;
                DialogResult = DialogResult.OK;
            }  
            this.textBox1.Focus();
        }

        private void FormPredmet_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "721.htm");
            }
        }
    }
}