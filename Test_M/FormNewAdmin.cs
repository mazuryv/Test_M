using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Test_M
{
    public partial class FormNewAdmin : Form
    {

        private Setting setting;
        private int ID;
        private string NameOfGroup;
        private int WhatEdit;//0-админ, 1- учитель,  3 - ученик

        public FormNewAdmin()
        {
            InitializeComponent();
        }
         public FormNewAdmin(int WhatEdit, Setting setting)
        {
            InitializeComponent();
            this.setting = setting;
            this.ID = 0;
            this.WhatEdit = WhatEdit;
            if (WhatEdit == 0) this.Text="Введення даних нового адміністратора";
            if (WhatEdit == 1) this.Text="Введення даних нового викладача";

        }
        public FormNewAdmin(int WhatEdit, Setting setting, int EditID)
        {
            InitializeComponent();
            this.setting = setting;
            this.ID = EditID;
            this.WhatEdit = WhatEdit;
            this.textBox1.Text = this.setting.FindAnyUserToID(EditID).ToString();
            this.textBox2.Text = this.textBox3.Text = this.setting.FindAnyUserToID(EditID).GetPassword();
            if (WhatEdit == 0) this.Text="Редагування даних адміністратора";
            if (WhatEdit == 1) this.Text="Редагування даних викладача";

        }
        public FormNewAdmin(int WhatEdit, Setting setting, string NameOfGroup)
        {
            InitializeComponent();
            this.setting = setting;
            this.ID = 0;
            this.WhatEdit = WhatEdit;
            this.NameOfGroup = NameOfGroup;
            this.Text = "Добавити нового учня до групи \"" + NameOfGroup + "\".";

        }
        
        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Length < 3) { 
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
                
                    if (ID == 0)
                    {
                        if (WhatEdit == 0) this.setting.AddAdmin(new Admin(this.textBox1.Text, this.textBox2.Text));
                        if (WhatEdit == 1) this.setting.AddTeacher(new Teacher (this.textBox1.Text, this.textBox2.Text));
                        if (WhatEdit == 3)
                        {
                            Group[] G = this.setting.GetAllGroups();
                            Group OurGroup= new Group();
                            for (int i = 0; i < G.Length; i++)
                            {
                                if (G[i].ToString().Equals(this.NameOfGroup)) OurGroup = G[i];
                            }
                            if (OurGroup != null) OurGroup.AddUser(new User(this.textBox1.Text, this.textBox2.Text), setting.GetNewIDAndNext());
                        }

                    }
                    else this.setting.EditAnyUser(ID, this.textBox1.Text, this.textBox2.Text);
                    this.Close();
                
                this.textBox1.Clear();
                this.textBox2.Clear();
                this.textBox3.Clear();
                this.textBox1.Focus();
            }



        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (this.WhatEdit == 0) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "821.htm");
                if (this.WhatEdit == 1) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "822.htm");
            }
        }

        
    }
}