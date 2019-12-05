using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Test_M
{
    public partial class FormNew : Form
    {
        public FormNew()
        {
            InitializeComponent();
            
        }
        public FormNew(MainForm MF)
        {
            InitializeComponent();
            this.MF = MF;
            this.comboBox1.Items.AddRange(this.MF.setting.GetAllGroups());
            if (this.comboBox1.Items.Count > 0) this.comboBox1.SelectedIndex = 0;
            
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Length < 7) { 
                MessageBox.Show("Дуже кототке ім`я користувача!");
                this.textBox1.SelectAll();
                this.textBox1.Focus();
            }
            else if (this.textBox2.Text.Length == 0 && this.textBox3.Text.Length == 0) { 
                MessageBox.Show("Пароль не введено");
                this.textBox2.SelectAll();
                this.textBox2.Focus(); 
            }
            else if (!this.textBox2.Text.Equals(this.textBox3.Text))
            {
                MessageBox.Show("Паролі не співпадають");
                this.textBox2.SelectAll();
                this.textBox2.Focus();
            }
            //теперь все введено
            else
            {
                string message = "Додати користувача згідно введених даних? (видалення можливе лише адміністратором)";
                string caption = "Ви впевнені?";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);

                if (result == DialogResult.Yes)
                {
                    MF.setting.GetGroup(this.comboBox1.SelectedIndex).AddUser(new User(this.textBox1.Text, this.textBox2.Text),MF.setting.GetNewIDAndNext());
                    this.Close();
                }
                this.textBox1.Clear();
                this.textBox2.Clear();
                this.textBox3.Clear();
                this.textBox1.Focus();
            }



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            this.textBox1.Focus();
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Enter)) this.buttonOK_Click(buttonOK, new EventArgs());
        }

        private void FormNew_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "611.htm");

            }
        }
    }
}