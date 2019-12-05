using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Test_M
{

    public partial class FormForAdmin : Form
    {
        private int AdminID;//���������������, ������ �������� ���������
        private Setting setting;
        private int WhatEdit;

        public FormForAdmin()
        {
            InitializeComponent();
        }
        public FormForAdmin(MainForm MF, int AdminID, int WhatEdit)
        {
            InitializeComponent();
            this.setting = MF.setting;
            this.AdminID = AdminID;
            this.WhatEdit = WhatEdit;
            if (WhatEdit == 0) //����������� ������ �������
            {
                this.Text = "����������� ������ ������������";
                ReloadListBox();
            }
            if (WhatEdit == 1) //����������� ������ ��������
            {
                this.Text = "����������� ������ ����������";
                ReloadListBox(); 
                this.buttonAdd.Text = "������ ���������";
                this.buttonDel.Text = "�������� ���������";
                this.buttonEdit.Text = "������ ��� ���������";
                this.label1.Text = "������ ����������:";

            }
            if (WhatEdit == 2) //����������� ������ ����
            {
                this.Text = "����������� ������ ���� ��� �����";
                ReloadListBox();
                this.buttonAdd.Text = "������ ����� ��� ����";
                this.buttonDel.Text = "�������� ����� ��� ����";
                this.buttonEdit.Text = "������ ��� ����� ��� �����";
                this.label1.Text = "������ ���� ��� �����:";
            }
            if (WhatEdit == 3) //����������� ������ ��������
            {
                this.Text = "����������� ������ ���� � ���� ��� ����";
                this.label1.Visible = false;
                this.comboBox1.Visible = this.label2.Visible = this.label3.Visible = true;
                this.buttonAdd.Text = "������ ����";
                this.buttonDel.Text = "�������� ����";
                this.buttonEdit.Text = "������ ��� ����";
                this.comboBox1.Items.Clear();
                this.comboBox1.Items.AddRange(this.setting.GetAllGroups());
                if (this.comboBox1.Items.Count > 0) { this.comboBox1.SelectedIndex = 0; this.buttonAdd.Enabled = this.������������������ToolStripMenuItem.Enabled =true; } 
                else this.buttonAdd.Enabled = this.������������������ToolStripMenuItem.Enabled =false;
                if (this.listBox1.Items.Count > 0)
                {
                    this.listBox1.SelectedIndex = 0;
                    this.buttonDel.Enabled = this.buttonEdit.Enabled = this.��������������������ToolStripMenuItem.Enabled = this.����������������������ToolStripMenuItem.Enabled = true;

                }
                else this.buttonDel.Enabled = this.buttonEdit.Enabled = this.��������������������ToolStripMenuItem.Enabled = this.����������������������ToolStripMenuItem.Enabled = false;

            }



        }


        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ReloadListBox()
        {
            this.listBox1.Items.Clear();
            if (this.WhatEdit == 0) this.listBox1.Items.AddRange(setting.GetAllAdmins());
            if (this.WhatEdit == 1) this.listBox1.Items.AddRange(setting.GetAllTeachers());
            if (this.WhatEdit == 2) this.listBox1.Items.AddRange(setting.GetAllGroups());
            
            if (this.listBox1.Items.Count > 0)
            {
                this.listBox1.SelectedIndex = 0;
                this.buttonDel.Enabled = this.buttonEdit.Enabled = this.��������������������ToolStripMenuItem.Enabled=this.����������������������ToolStripMenuItem.Enabled= true;

            }
            else this.buttonDel.Enabled = this.buttonEdit.Enabled = this.��������������������ToolStripMenuItem.Enabled = this.����������������������ToolStripMenuItem.Enabled = false;


        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (this.WhatEdit == 2)
            {
                FormGroup FG = new FormGroup("������ ����� ���� ����� �� �����");
                FG.ShowDialog();
                if (FG.DialogResult == DialogResult.OK)
                {
                    Group [] G= this.setting.GetAllGroups();
                    bool IsSame=false;
                    for (int i = 0; i < G.Length; i++)
                      if (G.GetValue(i).ToString().Equals(FG.textBox1.Text)) IsSame = true;

                  if (!IsSame) this.setting.AddGroup(new Group(FG.textBox1.Text));
                  else MessageBox.Show("����� ��� ���� �� ����� ������ ��� ����");
                }
                FG.Close();
                ReloadListBox();
            }
            else if (this.WhatEdit == 3)
            {
                FormNewAdmin FNA = new FormNewAdmin(this.WhatEdit, this.setting, this.comboBox1.SelectedItem.ToString());
                FNA.ShowDialog();
                this.comboBox1_SelectedIndexChanged(this.comboBox1, new EventArgs());

            }
            else
            {
                FormNewAdmin FNA = new FormNewAdmin(this.WhatEdit, this.setting);
                FNA.ShowDialog();
                ReloadListBox();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (this.WhatEdit == 0) //����������� ������ �������
            {
                if (((Admin)this.listBox1.SelectedItem).GetID() == this.AdminID) MessageBox.Show("��������� ������ ���� �� �������!!!");
                else if (this.listBox1.SelectedIndex != -1)
                {
                    string message = "�������� ������������ \"" + this.listBox1.SelectedItem.ToString() + "\"?";
                    string caption = "�� �������?";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);

                    if (result == DialogResult.Yes)
                    {
                        this.setting.DelAdmin(this.listBox1.SelectedItem.ToString());
                        ReloadListBox();
                    }

                }
                else MessageBox.Show("����������� ������������ �� �������");
            }
            if (this.WhatEdit == 1) //����������� ������ ��������
            {
                if (this.listBox1.SelectedIndex != -1)
                {
                    string message = "�������� ��������� \"" + this.listBox1.SelectedItem.ToString() + "\"?";
                    string caption = "�� �������?";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);

                    if (result == DialogResult.Yes)
                    {
                        this.setting.DelTeacher(this.listBox1.SelectedItem.ToString());
                        ReloadListBox();
                    }
                }
                else MessageBox.Show("����������� ���������  �� �������!");
            }
            if (this.WhatEdit == 2) //����������� ������ ����
            {
                if (this.listBox1.SelectedIndex != -1)
                {
                    string message = "�������� ����� ��� ���� \"" + this.listBox1.SelectedItem.ToString() + "\"?";
                    string caption = "�� �������?";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);

                    if (result == DialogResult.Yes)
                    {
                        this.setting.DelGroup(this.listBox1.SelectedItem.ToString());
                        ReloadListBox();
                    }
                }
                else MessageBox.Show("��������� ����� ��� ���� �� �������!");
            }
            if (this.WhatEdit == 3) //����������� ������ ��������
            {
                if (this.listBox1.SelectedIndex != -1)
                {
                    string message = "�������� ���� \"" + this.listBox1.SelectedItem.ToString() + "\"?";
                    string caption = "�� �������?";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);

                    if (result == DialogResult.Yes)
                    {
                       ((Group)this.comboBox1.SelectedItem).DelUser((User)this.listBox1.SelectedItem);
                        this.comboBox1_SelectedIndexChanged(this.comboBox1, new EventArgs());
                    }
                }
                else MessageBox.Show("����������� ���� �� �������!");
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (this.WhatEdit == 0) //����������� ������ �������
            {
                if (this.listBox1.SelectedIndex != -1)
                {

                    FormNewAdmin FNA = new FormNewAdmin(this.WhatEdit, this.setting, ((Admin)this.listBox1.SelectedItem).GetID());
                    FNA.ShowDialog();
                    ReloadListBox();
                }
                else MessageBox.Show("���������� ������������ �� �������");
            }
            if (this.WhatEdit == 1) //����������� ������ ��������
            {
                if (this.listBox1.SelectedIndex != -1)
                {

                    FormNewAdmin FNA = new FormNewAdmin(this.WhatEdit, this.setting, ((Teacher)this.listBox1.SelectedItem).GetID());
                    FNA.ShowDialog();
                    ReloadListBox();
                }
                else MessageBox.Show("���������� ��������� �� �������");
            }
                if (this.WhatEdit == 2) //����������� ������ ����
                {
                    if (this.listBox1.SelectedIndex != -1)
                    {
                        FormGroup FG = new FormGroup("������ ����� ����� �� �����", this.listBox1.SelectedItem.ToString());
                        FG.ShowDialog();
                        if (FG.DialogResult == DialogResult.OK)
                        {
                            Group[] G = this.setting.GetAllGroups();
                            bool IsSame = false;
                            for (int i = 0; i < G.Length; i++)
                                if (G.GetValue(i).ToString().Equals(FG.textBox1.Text)) IsSame = true;

                            if (!IsSame) ((Group)this.listBox1.SelectedItem).SetNameOfGroup(FG.textBox1.Text);
                            else MessageBox.Show("����� ��� ���� �� ����� ������ ��� ����");
                        }
                        FG.Close();
                        ReloadListBox();
                    }
                    else MessageBox.Show("�������� ����� ��� ���� �� �������");
                }
                if (this.WhatEdit == 3) //����������� ������ ��������
                {
                    if (this.listBox1.SelectedIndex != -1)
                    {
                       
                        FormNewAdmin FNA = new FormNewAdmin(this.WhatEdit, this.setting, ((User)this.listBox1.SelectedItem).GetID());
                        FNA.ShowDialog();
                        this.comboBox1_SelectedIndexChanged(this.comboBox1, new EventArgs());

                    }
                    else MessageBox.Show("���������� ���� �� �������");
                }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            this.listBox1.Items.AddRange(this.setting.GetGroup(this.comboBox1.SelectedIndex).GetAllUser());
            if (this.listBox1.Items.Count > 0)
            {
                this.listBox1.SelectedIndex = 0;
                this.buttonDel.Enabled = this.buttonEdit.Enabled = this.��������������������ToolStripMenuItem.Enabled = this.����������������������ToolStripMenuItem.Enabled=true;
            }
            else this.buttonDel.Enabled = this.buttonEdit.Enabled = this.��������������������ToolStripMenuItem.Enabled = this.����������������������ToolStripMenuItem.Enabled = false;
        }

        private void FormForAdmin_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (this.WhatEdit == 0) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "821.htm");
                if (this.WhatEdit == 1) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "822.htm");
                if (this.WhatEdit == 2) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "823.htm");
                if (this.WhatEdit == 3) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "824.htm");
            }
        }
    }
}