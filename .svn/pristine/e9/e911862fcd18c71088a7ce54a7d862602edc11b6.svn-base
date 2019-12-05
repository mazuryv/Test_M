using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Test_M
{
    public partial class FormGroup : Form
    {
        public FormGroup()
        {
            InitializeComponent();
        }
        
        public FormGroup(Predmet predmet, Setting setting)
        {
            InitializeComponent();
            this.Text = "Виберіть групу, що вивчає дисципліну: \""+predmet.ToString()+"\"";
            //должні біть в списке группі кроме тех, которіе уже изучают
            bool PredmetInGroup = false;
            for (int i = 0; i < setting.GetAllGroups().Length; i++)
            {
                for (int a = 0; a < setting.GetGroup(i).GetAllPredmet().Length; a++)
                {
                    if (predmet.ToString().Equals(setting.GetGroup(i).GetPredmet(a).ToString()))
                    {
                        PredmetInGroup = true;
                    }

                }
                if (!PredmetInGroup) this.comboBox1.Items.Add(setting.GetGroup(i));
                    PredmetInGroup = false;
            }
            if (this.comboBox1.Items.Count > 0) this.comboBox1.SelectedIndex = 0;
 
       }
        public FormGroup(string TextOfForm)
        {
            InitializeComponent();
            this.Text = TextOfForm;
            this.comboBox1.Visible = false;
            this.textBox1.TabIndex = 0;
            this.textBox1.Focus();

        }

        public FormGroup(string TextOfForm, string NameOfGroup)
        {
            InitializeComponent();
            this.Text = TextOfForm;
            this.comboBox1.Visible = false;
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = NameOfGroup;
            this.textBox1.Focus();
            this.textBox1.SelectAll();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            

            if (comboBox1.Visible == false)
            {
                if (this.textBox1.Text.Length < 1)
                {
                    MessageBox.Show("Ім`я групи не введено!");
                    this.textBox1.Focus();
                }
                else DialogResult = DialogResult.OK;

            
            }
            if (this.comboBox1.SelectedIndex > -1)
            {
                this.Visible = false;
                DialogResult = DialogResult.OK;
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void FormGroup_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "722.htm");
              
            }
        }




    }
}