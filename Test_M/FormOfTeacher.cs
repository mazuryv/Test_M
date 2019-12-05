using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Test_M
{
    public partial class FormOfTeacher : Form
    {
        public FormOfTeacher()
        {
            InitializeComponent();
        }

        public FormOfTeacher(MainForm MF, int TeacherID)
        {
            InitializeComponent();
            this.MF = MF;
            this.CurrentTeacher = (Teacher)MF.setting.FindAnyUserToID(TeacherID); 
            this.Text = "��������: " + CurrentTeacher.ToString() ;
            this.Reload();
            //�������� �����������  
            if (this.MF.setting.IfRegistrated())
               {
                   this.menuItem8.Visible = false;
               }

        }

        private void buttonAddPredmet_Click(object sender, EventArgs e)
        {
            FormPredmet FP = new FormPredmet("������ ��������� ��������� �� ������");
            FP.ShowDialog();
            if (FP.DialogResult == DialogResult.OK)
            {
                this.CurrentTeacher.AddPredmet(new Predmet(FP.textBox1.Text, this.CurrentTeacher.GetID()));
                FP.Close();
                this.Focus();
                this.Visible = true;
                this.Reload();
            }
        }

        private void listBoxPredmet_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.listBoxGroup.Items.Clear();

            for (int i = 0; i < this.MF.setting.GetAllGroups().Length; i++)
            {
                Predmet[] Predmets = this.MF.setting.GetGroup(i).GetAllPredmet();
                for (int a = 0; a < Predmets.Length; a++)
                {
                    if (Predmets[a].ToString().Equals(this.listBoxPredmet.SelectedItem.ToString())) this.listBoxGroup.Items.Add(this.MF.setting.GetGroup(i));
                }

                if (this.listBoxGroup.Items.Count > 0)
                {
                    this.listBoxGroup.SelectedIndex = 0;
                    this.buttonDelGroup.Enabled =this.menuItem15.Enabled = this.toolStripMenuItem5.Enabled = true;
                }
                else this.buttonDelGroup.Enabled = this.menuItem15.Enabled = this.toolStripMenuItem5.Enabled =false;

                this.listBoxTest.Items.Clear();
                Predmet SelectPredmet = new Predmet();
                SelectPredmet = (Predmet)this.listBoxPredmet.SelectedItem;
                if (SelectPredmet != null)
                {
                    this.listBoxTest.Items.AddRange(SelectPredmet.GetTests());
                }

                if (this.listBoxTest.Items.Count > 0)
                {
                    this.listBoxTest.SelectedIndex = 0;
                    this.buttonDelTest.Enabled = this.buttonIzmNameofTest.Enabled = this.menuItem17.Enabled = this.menuItem18.Enabled = this.toolStripMenuItem8.Enabled = this.toolStripMenuItem9.Enabled = true;
                }
                else this.buttonDelTest.Enabled = this.buttonIzmNameofTest.Enabled = this.menuItem17.Enabled = this.menuItem18.Enabled = this.toolStripMenuItem8.Enabled = this.toolStripMenuItem9.Enabled = false;
            }
        }

        private void buttonDelPredmet_Click(object sender, EventArgs e)
        {
            if (this.listBoxPredmet.SelectedIndex != -1)
            {
                string message = "�������� ��������� - \""+this.listBoxPredmet.SelectedItem.ToString()+"\"?";
                string caption = "�� �� ��������?";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);

                if (result == DialogResult.Yes)
                {


                    this.CurrentTeacher.DelPredmet((Predmet)this.listBoxPredmet.SelectedItem,this.MF.setting );
                    

                }

            }
            else MessageBox.Show("��������� ��������� �� �������");
            Reload();
        }

        private void buttonIzmPredmet_Click(object sender, EventArgs e)
        {
                    
            if (this.listBoxPredmet.SelectedIndex != -1)
            {
            FormPredmet FP = new FormPredmet("������ ����� ��������� ���������",this.listBoxPredmet.SelectedItem.ToString());
            FP.ShowDialog();
            if (FP.DialogResult == DialogResult.OK)
            {
                this.CurrentTeacher.GetArrayOfPredmet()[this.listBoxPredmet.SelectedIndex].SetNameOfPredmet(FP.textBox1.Text);
                FP.Close();
                this.Focus();
                Reload();
            }
        }
        else MessageBox.Show("��������� �� �������");

        
        }

        private void buttonAddGroup_Click(object sender, EventArgs e)
        {
            //������ ����� �� ������� ���������
                FormGroup FG = new FormGroup((Predmet)this.listBoxPredmet.SelectedItem, this.MF.setting);
                FG.ShowDialog();
                if (FG.DialogResult == DialogResult.OK) 
                {
                    this.CurrentTeacher.AddPredmetInGroup((Group)FG.comboBox1.SelectedItem, this.listBoxPredmet.SelectedIndex);
                    FG.Close();
                    this.Focus();
                    this.listBoxGroup.Items.Clear();

                    for (int i = 0; i < this.MF.setting.GetAllGroups().Length; i++)
                    {
                        Predmet[] Predmets = this.MF.setting.GetGroup(i).GetAllPredmet();
                        for (int a = 0; a < Predmets.Length; a++)
                        {
                            if (Predmets[a].ToString().Equals(this.listBoxPredmet.SelectedItem.ToString())) this.listBoxGroup.Items.Add(this.MF.setting.GetGroup(i));
                        }

                    }
                    if (this.listBoxGroup.Items.Count > 0)
                    {
                        this.listBoxGroup.SelectedIndex = 0;
                        this.buttonDelGroup.Enabled = this.menuItem15.Enabled = this.toolStripMenuItem5.Enabled = true;
                    }
                    else this.buttonDelGroup.Enabled = this.menuItem15.Enabled = this.toolStripMenuItem5.Enabled = false;

                    this.listBoxTest.Items.Clear();
                    Predmet SelectPredmet = new Predmet();
                    SelectPredmet = (Predmet)this.listBoxPredmet.SelectedItem;
                    if (SelectPredmet != null)
                    {
                        this.listBoxTest.Items.AddRange(SelectPredmet.GetTests());
                    }

                    if (this.listBoxTest.Items.Count > 0)
                    {
                        this.listBoxTest.SelectedIndex = 0;
                        this.buttonDelTest.Enabled = this.buttonIzmNameofTest.Enabled = this.menuItem17.Enabled = this.menuItem18.Enabled = this.toolStripMenuItem8.Enabled = this.toolStripMenuItem9.Enabled = true;
                    }
                    else this.buttonDelTest.Enabled = this.buttonIzmNameofTest.Enabled = this.menuItem17.Enabled = this.menuItem18.Enabled = this.toolStripMenuItem8.Enabled = this.toolStripMenuItem9.Enabled = false;

                
                }
            

        }

        private void buttonDelGroup_Click(object sender, EventArgs e)
        {
            if (this.listBoxGroup.SelectedIndex != -1)
            {
                string message = "�������� ����� \""+this.listBoxGroup.SelectedItem+"\" �� ������ ���������  - \"" + this.listBoxPredmet.SelectedItem.ToString() + "\"?";
                string caption = "�� ��������?";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);

                if (result == DialogResult.Yes)
                {
                    this.CurrentTeacher.DelPredmetInGroup((Group)this.listBoxGroup.SelectedItem,(Predmet)this.listBoxPredmet.SelectedItem);
                }
           }
            else MessageBox.Show("������ � ������ �� �������");
           this.listBoxGroup.Items.Clear();

           for (int i = 0; i < this.MF.setting.GetAllGroups().Length; i++)
           {
               Predmet[] Predmets = this.MF.setting.GetGroup(i).GetAllPredmet();
               for (int a = 0; a < Predmets.Length; a++)
               {
                   if (Predmets[a].ToString().Equals(this.listBoxPredmet.SelectedItem.ToString())) this.listBoxGroup.Items.Add(this.MF.setting.GetGroup(i));
               }


           }
           if (this.listBoxGroup.Items.Count > 0)
           {
               this.listBoxGroup.SelectedIndex = 0;
               this.buttonDelGroup.Enabled = this.menuItem15.Enabled = this.toolStripMenuItem5.Enabled = true;
           }
           else this.buttonDelGroup.Enabled = this.menuItem17.Enabled  = false;
       }

        private void buttonAddTestOfFile_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.InitialDirectory =  Path.GetFullPath ("Tests");
            this.openFileDialog1.ShowDialog();
            this.listBoxTest.Items.Clear();
            Predmet SelectPredmet = new Predmet();
            SelectPredmet = (Predmet)this.listBoxPredmet.SelectedItem;
            if (SelectPredmet != null)
            {
                this.listBoxTest.Items.AddRange(SelectPredmet.GetTests());
            }

            if (this.listBoxTest.Items.Count > 0)
            {
                this.listBoxTest.SelectedIndex = 0;
                this.buttonDelTest.Enabled = this.buttonIzmNameofTest.Enabled = this.menuItem17.Enabled = this.menuItem18.Enabled = this.toolStripMenuItem8.Enabled = this.toolStripMenuItem9.Enabled = true;
            }
            else this.buttonDelTest.Enabled = this.buttonIzmNameofTest.Enabled = this.menuItem17.Enabled = this.menuItem18.Enabled = this.toolStripMenuItem8.Enabled = this.toolStripMenuItem9.Enabled = false;




        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

            String name= this.openFileDialog1.SafeFileName;
            String Extention = name.Substring(name.Length - 5);
            String ShortName = name.Substring(0, name.Length - 5);
            byte[] Key ={ 13, 20, 94, 153, 8, 22, 109, 154, 231, 97, 91, 118, 97, 208, 214, 249, 128, 246, 150, 170, 173, 191, 207, 138 };
            byte[] IV = { 227, 182, 38, 145, 55, 77, 174, 23 };
            Test NewTest = new Test();
            CollectionOfTest COT = new CollectionOfTest();
            
            if (Extention.Equals(".test")) //���������� �����
            {
                //�������� ��� �� ������ �� �������� (�����)
                
                Object [] AllTest=this.CurrentTeacher.GetArrayOfPredmet()[this.listBoxPredmet.SelectedIndex].GetTests();

                if (!this.MF.setting.GetOnlyOur())
                {//��������� ��������� ����� ����� ���
                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    FileStream fs = new FileStream(
                       this.openFileDialog1.FileName, FileMode.Open, FileAccess.Read);

                    System.Security.Cryptography.CryptoStream cStream = new System.Security.Cryptography.CryptoStream(fs,
                    new System.Security.Cryptography.TripleDESCryptoServiceProvider().CreateDecryptor(Key, IV),
                    System.Security.Cryptography.CryptoStreamMode.Read);
                    NewTest = (Test)bf.Deserialize(cStream);
                    
                    cStream.Close();
                    fs.Close();
                    if (NewTest.GetOwnerID() != this.CurrentTeacher.GetID())
                        MessageBox.Show("  ����, �� ��������, �� ��������� ����.\n ���������� �� ������������� ��� ������������ ����� \n \"��������� ��������� ����� �� �� \"���������\"\".");
                    else
                    {//��������� �� ��� �� ������� ����������� ����

                        bool SameFileITest = false;
                        for (int i = 0; i < AllTest.Length; i++)
                        {
                            if (AllTest[i].ToString().Equals(NewTest.ToString())) SameFileITest = true;
                        }
                        if (SameFileITest) MessageBox.Show("���� � ����� ����� ��� ���������! ������� ����� ����!");
                        else
                        {
                           if(!NewTest.ToString().Equals((new Test()).ToString())) //���� ���-�� � ������ ���������
                               this.CurrentTeacher.GetArrayOfPredmet()[this.listBoxPredmet.SelectedIndex].AddTest(NewTest); //��� ��������� ���� �� �����
                           else MessageBox.Show("��������� �������� ���� � ����� �����! ������� ����� ����!");
                        }
                    }
                }
                else //��������� ���������� ������ ������ ��������������
                {
                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    FileStream fs = new FileStream(
                       this.openFileDialog1.FileName, FileMode.Open, FileAccess.Read);

                    System.Security.Cryptography.CryptoStream cStream = new System.Security.Cryptography.CryptoStream(fs,
                    new System.Security.Cryptography.TripleDESCryptoServiceProvider().CreateDecryptor(Key, IV),
                    System.Security.Cryptography.CryptoStreamMode.Read);
                    NewTest = (Test)bf.Deserialize(cStream);
                   
                    cStream.Close();
                    fs.Close();

                    {//��������� �� ��� �� ������� ����������� ����
                        bool SameFileITest = false;
                        for (int i = 0; i < AllTest.Length; i++)
                        {
                            if (AllTest[i].ToString().Equals(NewTest.ToString())) SameFileITest = true;
                        }
                        if (SameFileITest) MessageBox.Show("���� � ����� ����� ��� ���������! ������� ����� ����!");
                        else
                        {
                            if (!NewTest.ToString().Equals((new Test()).ToString())) //���� ���-�� � ������ ���������
                                this.CurrentTeacher.GetArrayOfPredmet()[this.listBoxPredmet.SelectedIndex].AddTest(NewTest); //��� ��������� ���� �� �����
                            else MessageBox.Show("��������� �������� ���� � ����� �����! ������� ����� ����!");
                        }
                    }
                }
                    

                
            }
            if (Extention.Equals(".tcln")) //���������� ��������
            {
                //�������� ��� �� ������ �� �������� (�����)
                Object[] AllTest = this.CurrentTeacher.GetArrayOfPredmet()[this.listBoxPredmet.SelectedIndex].GetTests();
                
                    if (!this.MF.setting.GetOnlyOur())
                    {//��������� ��������� ����
                        System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                        System.IO.FileStream fs = new FileStream(
                           this.openFileDialog1.FileName, FileMode.Open, FileAccess.Read);

                        System.Security.Cryptography.CryptoStream cStream = new System.Security.Cryptography.CryptoStream(fs,
                                               new System.Security.Cryptography.TripleDESCryptoServiceProvider().CreateDecryptor(Key, IV),
                                               System.Security.Cryptography.CryptoStreamMode.Read);

                        
                       
                        COT = ((CollectionOfTest)bf.Deserialize(cStream));
                        
                        cStream.Close();
                        fs.Close();

                        if (COT.GetOwnerID() != this.CurrentTeacher.GetID())
                            MessageBox.Show("  ����, �� ��������, �� ��������� ����.\n ���������� �� ������������� ��� ������������ ����� \n \"��������� ��������� ����� �� �� \"���������\"\".");
                        else 
                        {
                            bool SameFileITest=false;
                            for (int i = 0; i < AllTest.Length; i++) 
                            {
                                if (AllTest[i].ToString().Equals(COT.ToString())) SameFileITest = true;  
                            }
                            if (SameFileITest) MessageBox.Show("���� � ����� ����� ��� ���������! ������� ����� ����!");
                            else
                                 {
                                     this.CurrentTeacher.GetArrayOfPredmet()[this.listBoxPredmet.SelectedIndex].AddCollection(COT); //��� ��������� ���� �� �����
                                 }
                        }
                    }
                    
                    else 
                    { //��������� ��������� ������ �������������

                        System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                        System.IO.FileStream fs = new FileStream(
                           this.openFileDialog1.FileName, FileMode.Open, FileAccess.Read);

                        System.Security.Cryptography.CryptoStream cStream = new System.Security.Cryptography.CryptoStream(fs,
                                               new System.Security.Cryptography.TripleDESCryptoServiceProvider().CreateDecryptor(Key, IV),
                                               System.Security.Cryptography.CryptoStreamMode.Read);



                        COT = ((CollectionOfTest)bf.Deserialize(cStream));

                        cStream.Close();
                        fs.Close();

                            bool SameFileITest=false;
                            for (int i = 0; i < AllTest.Length; i++) 
                            {
                                if (AllTest[i].ToString().Equals(COT.ToString())) SameFileITest = true;  
                            }
                            if (SameFileITest) MessageBox.Show("���� � ����� ����� ��� ���������! ������� ����� ����!");
                            else
                                 {
                                     this.CurrentTeacher.GetArrayOfPredmet()[this.listBoxPredmet.SelectedIndex].AddCollection(COT); //��� ��������� ���� �� �����
                                 }
                        }
                }
                    
                    
                    
            

        }

        private void buttonDelTest_Click(object sender, EventArgs e)
        {
            
            if (this.listBoxTest.SelectedIndex != -1&&this.listBoxPredmet.SelectedIndex!=-1)
            {
                string message = "�������� ���� � ������?";
                string caption = "�� �� ��������?";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);

                if (result == DialogResult.Yes)
                {
                   this.CurrentTeacher.GetArrayOfPredmet()[this.listBoxPredmet.SelectedIndex].DelTest(this.listBoxTest.SelectedItem);
                }
                this.listBoxTest.Items.Clear();
                Predmet SelectPredmet = new Predmet();
                SelectPredmet = (Predmet)this.listBoxPredmet.SelectedItem;
                if (SelectPredmet != null)
                {
                    this.listBoxTest.Items.AddRange(SelectPredmet.GetTests());
                }

                if (this.listBoxTest.Items.Count > 0)
                {
                    this.listBoxTest.SelectedIndex = 0;
                    this.buttonDelTest.Enabled = this.buttonIzmNameofTest.Enabled = this.menuItem17.Enabled = this.menuItem18.Enabled = this.toolStripMenuItem8.Enabled = this.toolStripMenuItem9.Enabled = true;
                }
                else this.buttonDelTest.Enabled = this.buttonIzmNameofTest.Enabled = this.menuItem17.Enabled = this.menuItem18.Enabled = this.toolStripMenuItem8.Enabled = this.toolStripMenuItem9.Enabled = false;
            }
        }

        private void buttonIzmNameofTest_Click(object sender, EventArgs e)
        {
            if (this.listBoxTest.SelectedIndex != -1 && this.listBoxPredmet.SelectedIndex != -1)
            {
                
               
                FormPredmet FP = new FormPredmet("������ ����� �����", true, this.listBoxTest.SelectedItem.ToString());
                FP.ShowDialog();
                if (FP.DialogResult == DialogResult.OK)
                {
                    this.CurrentTeacher.GetArrayOfPredmet()[this.listBoxPredmet.SelectedIndex].RenameTest(this.listBoxTest.SelectedItem, FP.textBox1.Text);
                    FP.Close();
                }
                    this.listBoxTest.Items.Clear();
                Predmet SelectPredmet = new Predmet();
                SelectPredmet = (Predmet)this.listBoxPredmet.SelectedItem;
                if (SelectPredmet != null)
                {
                    this.listBoxTest.Items.AddRange(SelectPredmet.GetTests());
                }

                if (this.listBoxTest.Items.Count > 0)
                {
                    this.listBoxTest.SelectedIndex = 0;
                    this.buttonDelTest.Enabled = this.buttonIzmNameofTest.Enabled = this.menuItem17.Enabled = this.menuItem18.Enabled = this.toolStripMenuItem8.Enabled = this.toolStripMenuItem9.Enabled = true;
                }
                else this.buttonDelTest.Enabled = this.buttonIzmNameofTest.Enabled = this.menuItem17.Enabled = this.menuItem18.Enabled = this.toolStripMenuItem8.Enabled = this.toolStripMenuItem9.Enabled = false;
            }
        }

        private void buttonAddNewTest_Click(object sender, EventArgs e)
        {
            FormMasterOfTest MOT = new FormMasterOfTest(this.MF.setting, this.CurrentTeacher);
            MOT.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            MF.IfNeedAnyVhod = 1;
            Close();
            
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            MF.IfNeedAnyVhod = 2;
            Close();
        }

        private void menuItem5_Click(object sender, EventArgs e)
        {
            MF.IfNeedAnyVhod = 3;
            Close();
        }

        private void menuItem21_Click(object sender, EventArgs e)
        {

            FormJournal FJ = new FormJournal(this.MF.setting,this.CurrentTeacher);
            FJ.ShowDialog();

        }

        private void menuItem8_Click(object sender, EventArgs e)
        {
            ActivisationForm AF = new ActivisationForm(this.MF.setting);
            AF.ShowDialog();

            //�������� ��������� �� �����������
            if (this.MF.setting.IfRegistrated())
            {
                this.menuItem8.Visible = false;
                
            }

        }

        private void menuItem7_Click(object sender, EventArgs e)
        {
            AboutBox AB = new AboutBox(this.MF.setting);
            AB.ShowDialog();
        }

        private void FormOfTeacher_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.MF.SerializationSetting();
        }

        private void FormOfTeacher_Load(object sender, EventArgs e)
        {

        }
        private void Reload() 
        {
            this.listBoxPredmet.Items.Clear();
            this.listBoxPredmet.Items.AddRange(this.CurrentTeacher.GetArrayOfPredmet());
            if (this.listBoxPredmet.Items.Count > 0)
            {
                this.listBoxPredmet.SelectedIndex = 0;
                this.buttonAddGroup.Enabled = this.buttonAddTestOfFile.Enabled = this.buttonDelPredmet.Enabled =
                this.buttonIzmPredmet.Enabled = this.menuItem10.Enabled = this.menuItem16.Enabled = this.menuItem12.Enabled = this.menuItem13.Enabled = this.toolStripMenuItem2.Enabled = this.toolStripMenuItem3.Enabled = this.toolStripMenuItem4.Enabled = this.toolStripMenuItem6.Enabled = true;
            }
            else this.buttonAddGroup.Enabled = this.buttonAddTestOfFile.Enabled = this.buttonDelPredmet.Enabled =
          this.buttonIzmPredmet.Enabled = this.menuItem10.Enabled = this.menuItem16.Enabled = this.menuItem12.Enabled = this.menuItem13.Enabled = this.toolStripMenuItem2.Enabled = this.toolStripMenuItem3.Enabled = this.toolStripMenuItem4.Enabled = this.toolStripMenuItem6.Enabled= false;
            this.listBoxGroup.Items.Clear();

            for (int i = 0; i < this.MF.setting.GetAllGroups().Length; i++)
            {
                Predmet[] Predmets = this.MF.setting.GetGroup(i).GetAllPredmet();
                for (int a = 0; a < Predmets.Length; a++)
                {
                    if (this.listBoxPredmet.SelectedItem != null)
                        if (Predmets[a].ToString().Equals(this.listBoxPredmet.SelectedItem.ToString())) this.listBoxGroup.Items.Add(this.MF.setting.GetGroup(i));
                }


            }
            if (this.listBoxGroup.Items.Count > 0)
            {
                this.listBoxGroup.SelectedIndex = 0;
                this.buttonDelGroup.Enabled = this.menuItem15.Enabled = this.toolStripMenuItem5.Enabled = true;
            }
            else this.buttonDelGroup.Enabled = this.menuItem15.Enabled = this.toolStripMenuItem5.Enabled = false;
            this.listBoxTest.Items.Clear();
            Predmet SelectPredmet = new Predmet();
            SelectPredmet = (Predmet)this.listBoxPredmet.SelectedItem;
            if (SelectPredmet != null)
            {
                this.listBoxTest.Items.AddRange(SelectPredmet.GetTests());
            }

            if (this.listBoxTest.Items.Count > 0)
            {
                this.listBoxTest.SelectedIndex = 0;
                this.buttonDelTest.Enabled = this.buttonIzmNameofTest.Enabled = this.menuItem17.Enabled = this.menuItem18.Enabled = this.toolStripMenuItem8.Enabled= this.toolStripMenuItem9.Enabled= true;
            }
            else this.buttonDelTest.Enabled = this.buttonIzmNameofTest.Enabled = this.menuItem17.Enabled = this.menuItem18.Enabled = this.toolStripMenuItem8.Enabled = this.toolStripMenuItem9.Enabled = false;
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
             Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "72.htm");

        }

        private void FormOfTeacher_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (this.listBoxPredmet.Focused || this.buttonAddPredmet.Focused||this.buttonDelPredmet.Focused||this.buttonIzmPredmet.Focused) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "721.htm");
                else if (this.listBoxGroup.Focused || this.buttonAddGroup.Focused || this.buttonDelGroup.Focused) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "722.htm");
                else if (this.listBoxTest.Focused || this.buttonIzmNameofTest.Focused || this.buttonAddTestOfFile.Focused || this.buttonDelTest.Focused) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "723.htm");
                else if (this.buttonAddNewTest.Focused ) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "73.htm");
                else Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "72.htm");
            }
        }
    }
}