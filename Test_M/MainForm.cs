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
    public partial class MainForm : Form
    {
        public Setting setting;
        public int IfNeedAnyVhod;
        private WaitForm WF;


        public MainForm()
        {
            InitializeComponent();
            WF = new WaitForm();
            WF.Show();
            this.IfNeedAnyVhod = 0;
            // 
            // buttonForAdmin
            // 
            this.buttonForAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonForAdmin.Location = new System.Drawing.Point(74, 275);
            this.buttonForAdmin.Name = "buttonForAdmin";
            this.buttonForAdmin.Size = new System.Drawing.Size(507, 77);
            this.buttonForAdmin.TabIndex = 6;
            this.buttonForAdmin.Text = "Вхід для адміністратора";
            this.buttonForAdmin.UseVisualStyleBackColor = true;
            this.buttonForAdmin.Click += new System.EventHandler(this.buttonForAdmin_Click);
            // 
            // buttonForTeacher
            // 
            this.buttonForTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonForTeacher.Location = new System.Drawing.Point(74, 172);
            this.buttonForTeacher.Name = "buttonForTeacher";
            this.buttonForTeacher.Size = new System.Drawing.Size(507, 77);
            this.buttonForTeacher.TabIndex = 5;
            this.buttonForTeacher.Text = "Вхід для викладачів";
            this.buttonForTeacher.UseVisualStyleBackColor = true;
            this.buttonForTeacher.Click += new System.EventHandler(this.buttonForTeacher_Click);
            // 
            // buttonForUser
            // 
            this.buttonForUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonForUser.Location = new System.Drawing.Point(74, 69);
            this.buttonForUser.Name = "buttonForUser";
            this.buttonForUser.Size = new System.Drawing.Size(507, 77);
            this.buttonForUser.TabIndex = 3;
            this.buttonForUser.Tag = "Якщо Ви бажаєте протестуватися нажміть цю кнопку";
            this.buttonForUser.Text = "Вхід для учнів";
            this.buttonForUser.UseVisualStyleBackColor = true;
            this.buttonForUser.Click += new System.EventHandler(this.buttonForUser_Click);
            //таймеры и дата
            this.timerForDT.Enabled = true;
            //пока создание файла установок и сериализация его в конце работы приложения


            this.WF.SetProgress(5);
            this.DeserializationSetting();
            this.WF.SetProgress(100);
            this.groupBoxAdmin.Visible = false;
            WF.Close();

            //запуск помощи первого раза
         String newAdmin = this.setting.GetAllAdmins()[0].ToString();
         try
         {
             if (newAdmin.Equals("NewAdmin"))
             {
                 String urlhelp = Path.GetFullPath("Test_M_Help.chm");
                 Help.ShowHelp(this, urlhelp, HelpNavigator.Topic, "4.htm");
             }
         }
         catch { MessageBox.Show("Файл допомоги не знайдено!"); }
        }

       

        private void buttonForUser_Click(object sender, EventArgs e)
        {
            this.buttonForAdmin.Visible = this.buttonForTeacher.Visible = this.groupBoxAdmin.Visible = this.buttonForUser.Visible = false;
            this.groupBoxUser.Visible = this.buttonNazad.Visible = true;
            this.label3.Visible = this.label4.Visible =this.label5.Visible = this.button3.Visible = this.button4.Visible = this.comboBox2.Visible = this.textBox1.Visible = false;
            this.comboBox1.Items.Clear();
            
            this.comboBox1.Items.AddRange(this.setting.GetAllGroups());
            if (this.comboBox1.Items.Count > 0) this.comboBox1.SelectedIndex = 0;
            if (this.comboBox1.SelectedIndex == 0) { this.comboBox2.Visible = this.label3.Visible = true;}

            
        }

        private void buttonForTeacher_Click(object sender, EventArgs e)
        {

            this.buttonForAdmin.Visible = this.buttonForTeacher.Visible = this.groupBoxAdmin.Visible = this.buttonForUser.Visible = false;
            this.groupBoxTeacher.Visible = this.buttonNazad.Visible = true;
            this.comboBox3.Items.Clear();
            this.comboBox3.Items.AddRange(this.setting.GetAllTeachers());
            if (this.comboBox3.Items.Count > 0) { this.comboBox3.SelectedIndex = 0; this.button1.Enabled = true; }
            else this.button1.Enabled = false;
            this.textBox2.Clear();
            this.textBox2.Focus();


        }

        private void buttonForAdmin_Click(object sender, EventArgs e)
        {
            this.buttonForAdmin.Visible = this.buttonForTeacher.Visible = this.buttonForUser.Visible = false;
            this.groupBoxAdmin.Visible = this.buttonNazad.Visible = true;
            this.comboBoxAdmin.Items.Clear();
            this.comboBoxAdmin.Items.AddRange(this.setting.GetAllAdmins());
            if (this.comboBoxAdmin.Items.Count > 0) this.comboBoxAdmin.SelectedIndex = 0;
            this.textBoxPassword.Clear();
            this.textBoxPassword.Focus();

            this.checkBoxAddUser.Checked = this.setting.GetAddUser();
            this.checkBoxOnlyOur.Checked = this.setting.GetOnlyOur();
            this.checkBoxPovtorSdachi.Checked = this.setting.GetPovtorSdachi();
            this.textBoxTimeForNewTest.Text = this.setting.GetTimeForNewTest().ToString();
            if (this.setting.IfFlagRegistrated())
            {
                this.groupBoxOption.Enabled = true;
                this.buttonMatrixOfMark.Enabled = true;
                this.buttonExport.Enabled = true;
                this.buttonImport.Enabled = true;
                this.menuItemExport.Enabled = this.menuItemImport.Enabled = true;


            } 


        }

        private void timerForDT_Tick(object sender, EventArgs e)
        {
            DateTime currentDT = DateTime.Now;
            String Month="";
            switch (currentDT.ToString("MM"))
            {
                case "01": Month = "січня"; break;
                case "02": Month = "лютого"; break;
                case "03": Month = "березня"; break;
                case "04": Month = "квітня"; break;
                case "05": Month = "травня"; break;
                case "06": Month = "червня"; break;
                case "07": Month = "липня"; break;
                case "08": Month = "серпня"; break;
                case "09": Month = "вересня"; break;
                case "10": Month = "жовтня"; break;
                case "11": Month = "листопада"; break;
                case "12": Month = "грудня"; break;
            }

            this.toolStripStatusLabel1.Text = currentDT.ToString("dd ") + Month +currentDT.ToString(" yyyy року HH-mm-ss ");
            string Vremya="";
            if (Convert.ToInt32(currentDT.ToString("HH")) >= 7 && Convert.ToInt32(currentDT.ToString("HH")) < 11) Vremya = "Добрий ранок, ";
            if (Convert.ToInt32(currentDT.ToString("HH")) >= 11 && Convert.ToInt32(currentDT.ToString("HH")) < 17) Vremya = "Добрий день, ";
            if (Convert.ToInt32(currentDT.ToString("HH")) >= 17 && Convert.ToInt32(currentDT.ToString("HH")) < 22) Vremya = "Добрий вечір, ";
            if (Convert.ToInt32(currentDT.ToString("HH")) >= 22 || Convert.ToInt32(currentDT.ToString("HH")) < 7) Vremya = "Доброї ночі, ";
            string Koristuvach;
            if (this.buttonJurnal.Visible) 
                Koristuvach = this.comboBoxAdmin.SelectedItem.ToString()+"!";
            else Koristuvach="шановний користувач!";
            this.label1.Text = Vremya + Koristuvach;
            this.label1.Location =new Point (this.Width / 2 - this.label1.Width / 2,this.label1.Location.Y);


        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.SerializationSetting();
                                      
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            
            this.comboBox2.Items.Clear();
            this.textBox1.Clear();
            
            this.comboBox2.Items.AddRange(this.setting.GetGroup(this.comboBox1.SelectedIndex).GetAllUser());
            if (this.comboBox2.Items.Count > 0)
            {
                this.comboBox2.SelectedIndex = 0;
                this.button4.Visible = this.label5.Visible = this.textBox1.Visible = this.comboBox2.Visible = true;
                this.label3.Text = "Виберіть себе у списку:";
            }
            else
            {
                this.button4.Visible = this.label5.Visible = this.textBox1.Visible = this.comboBox2.Visible = false;
                this.label3.Text = "                    До вказаної групи не внесено жодного учня!";
            }  
            if (this.setting.GetAddUser()) this.label4.Visible = this.button3.Visible = true;
                this.textBox1.Focus();


        }

        private void button4_Click(object sender, EventArgs e)
        {String password = this.setting.GetGroup(this.comboBox1.SelectedIndex).GetUser(this.comboBox2.SelectedIndex).GetPassword();
        if (!password.Equals(this.textBox1.Text)) //пароль не верен
        {
            MessageBox.Show("Вказаний пароль не є вірним, спробуйте ще раз!");
            this.textBox1.SelectAll();
            this.textBox1.Focus();
        }
        else
        {
            FormOfUser FOU = new FormOfUser(this, this.setting.GetGroup(this.comboBox1.SelectedIndex).GetUser(this.comboBox2.SelectedIndex).GetID());//
            this.Visible = false;
            FOU.ShowDialog();
            this.textBox1.Clear();
            this.Visible = true;
            //проверка блокировки
            if (this.setting.IfStop())
            {
                MessageBox.Show("Програму заблоковано! Для розблокування її необхідно зареєструвати!");
                this.buttonForAdmin.Enabled = this.buttonForTeacher.Enabled = this.buttonForUser.Enabled = false;
                this.menuItem1.Enabled = false;
            }
            else this.buttonForAdmin.Enabled = this.buttonForTeacher.Enabled = this.buttonForUser.Enabled = this.menuItem1.Enabled = true;

            if (IfNeedAnyVhod != 0)
            {
                if (IfNeedAnyVhod == 1) this.menuItem3_Click(this.menuItem3, new EventArgs());
                else if (IfNeedAnyVhod == 2) this.menuItem4_Click(this.menuItem4, new EventArgs());
                else this.menuItem5_Click(this.menuItem5, new EventArgs());

            }
            IfNeedAnyVhod = 0;

        }
    }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Enter)) this.button4_Click(button4, new EventArgs()); 
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            this.textBox1.Focus();
        }

  
        private void button3_Click(object sender, EventArgs e)
        {
            //добавление нового пользователя в систему
            FormNew FON = new FormNew(this);
            this.Visible = false;
            FON.ShowDialog();
            this.Visible = true;
            if (this.comboBox1.Items.Count > 0) this.comboBox1_SelectedIndexChanged(this.comboBox1,new EventArgs());


        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBox2.Clear();
            this.textBox2.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //вход в систему от учителя
            if ((this.comboBox3.Items.Count>0)&&(this.textBox2.Text.Equals(this.setting.GetAllTeachers()[this.comboBox3.SelectedIndex].GetPassword())))
            {
                this.Visible = false;
                
                
                FormOfTeacher FOT = new FormOfTeacher(this, this.setting.GetAllTeachers()[this.comboBox3.SelectedIndex].GetID());
                FOT.ShowDialog();
                this.Visible = true;
                if (this.setting.IfFlagRegistrated()) this.menuItem8.Visible = false;
                if (IfNeedAnyVhod != 0)
                {
                    if (IfNeedAnyVhod == 1) this.menuItem3_Click(this.menuItem3, new EventArgs());
                    else if (IfNeedAnyVhod == 2) this.menuItem4_Click(this.menuItem4, new EventArgs());
                    else this.menuItem5_Click(this.menuItem5, new EventArgs());
                    
                }
                IfNeedAnyVhod = 0;


                this.textBox2.Clear();
                
            }
            else       MessageBox.Show ("Вказаний пароль не є вірним, спробуйте ще раз");
            this.textBox2.SelectAll();
            this.textBox2.Focus();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Enter)) this.button1_Click(button1, new EventArgs());
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            this.groupBoxUser.Visible = this.buttonNazad.Visible = this.groupBoxTeacher.Visible = this.groupBoxAdmin.Visible = this.menuItemExport.Visible = this.menuItemImport.Visible = false;
            this.buttonForAdmin.Visible = this.buttonForTeacher.Visible = this.buttonForUser.Visible = true;
            this.comboBoxAdmin.Visible = true;
            this.textBoxPassword.Visible = true;
            this.buttonEnter.Visible = true;
            this.label7.Visible = true;
            this.label9.Visible = true;
            this.groupBoxRedag.Visible = false;
            this.groupBoxOption.Visible = false;
            this.groupBoxIEN.Visible = false;
            this.buttonJurnal.Visible = false;
            this.buttonMatrixOfMark.Visible = false;
            this.buttonForUser_Click(this.buttonForUser, new EventArgs());
            this.SerializationSetting();

        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            this.groupBoxUser.Visible = this.buttonNazad.Visible = this.groupBoxTeacher.Visible = this.groupBoxAdmin.Visible = this.menuItemExport.Visible = this.menuItemImport.Visible = false;
            this.buttonForAdmin.Visible = this.buttonForTeacher.Visible = this.buttonForUser.Visible = true;
            this.comboBoxAdmin.Visible = true;
            this.textBoxPassword.Visible = true;
            this.buttonEnter.Visible = true;
            this.label7.Visible = true;
            this.label9.Visible = true;
            this.groupBoxRedag.Visible = false;
            this.groupBoxOption.Visible = false;
            this.groupBoxIEN.Visible = false;
            this.buttonJurnal.Visible = false;
            this.buttonMatrixOfMark.Visible = false;
            this.buttonForTeacher_Click(this.buttonForTeacher, new EventArgs());
            this.SerializationSetting();

        }

        private void menuItem5_Click(object sender, EventArgs e)
        {
            this.groupBoxUser.Visible = this.buttonNazad.Visible = this.groupBoxTeacher.Visible = this.groupBoxAdmin.Visible = false;
            this.buttonForAdmin.Visible = this.buttonForTeacher.Visible = this.buttonForUser.Visible = true;
            this.comboBoxAdmin.Visible = true;
            this.textBoxPassword.Visible = true;
            this.buttonEnter.Visible = true;
            this.label7.Visible = true;
            this.label9.Visible = true;
            this.groupBoxRedag.Visible = false;
            this.groupBoxOption.Visible = false;
            this.groupBoxIEN.Visible = false;
            this.buttonJurnal.Visible = false;
            this.buttonMatrixOfMark.Visible = false;
            this.buttonForAdmin_Click(this.buttonForAdmin, new EventArgs());
            this.SerializationSetting();

        }

      

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            //вход в систему от админа

            if (this.textBoxPassword.Text.Equals(this.setting.GetAllAdmins()[this.comboBoxAdmin.SelectedIndex].GetPassword()))
            {
                this.textBoxPassword.Clear();
                this.comboBoxAdmin.Visible = false;
                this.textBoxPassword.Visible = false;
                this.buttonEnter.Visible = false;
                this.label7.Visible = false;
                this.label9.Visible =  false;
                //а теперь покажуться новіе елементи керування
                this.groupBoxRedag.Visible = true;
                this.groupBoxOption.Visible = true;
                this.groupBoxIEN.Visible = true;
                this.buttonJurnal.Visible = true;
                this.buttonMatrixOfMark.Visible = true;
                this.menuItemExport.Visible = this.menuItemImport.Visible = true;
            }
            else MessageBox.Show("Вказаний пароль не є вірним, спробуйте ще раз");
            this.textBoxPassword.SelectAll();
            this.textBoxPassword.Focus();
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Enter)) this.buttonEnter_Click(buttonEnter, new EventArgs());

        }

        private void buttonNazad_Click(object sender, EventArgs e)
        {
            this.groupBoxUser.Visible = this.buttonNazad.Visible = this.groupBoxTeacher.Visible = this.groupBoxAdmin.Visible = this.menuItemExport.Visible = this.menuItemImport.Visible = false;
            this.buttonForAdmin.Visible = this.buttonForTeacher.Visible = this.buttonForUser.Visible = true;
            this.comboBoxAdmin.Visible = true;
            this.textBoxPassword.Visible = true;
            this.buttonEnter.Visible = true;
            this.label7.Visible = true;
            this.groupBoxRedag.Visible = false;
            this.groupBoxOption.Visible = false;
            this.groupBoxIEN.Visible = false;
            this.buttonJurnal.Visible = false;
            this.buttonMatrixOfMark.Visible = false;
            this.label9.Visible = true;
            this.SerializationSetting();
 
        }

 

        private void comboBoxAdmin_DropDownClosed(object sender, EventArgs e)
        {
            this.textBoxPassword.Clear();
            this.textBoxPassword.Focus();

        }

        private void comboBox3_DropDownClosed(object sender, EventArgs e)
        {
            this.textBox2.Clear();
            this.textBox2.Focus();
        }

        private void button2_Click(object sender, EventArgs e) //открытие для редактирования админов
        {
            FormForAdmin FFA = new FormForAdmin(this, ((Admin)this.comboBoxAdmin.SelectedItem).GetID(), 0);
            FFA.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormForAdmin FFA = new FormForAdmin(this, ((Admin)this.comboBoxAdmin.SelectedItem).GetID(), 1);
            FFA.ShowDialog();


        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormForAdmin FFA = new FormForAdmin(this, ((Admin)this.comboBoxAdmin.SelectedItem).GetID(), 2);
            FFA.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FormForAdmin FFA = new FormForAdmin(this, ((Admin)this.comboBoxAdmin.SelectedItem).GetID(), 3);
            FFA.ShowDialog();
        }

        private void checkBoxAddUser_CheckedChanged(object sender, EventArgs e)
        {
            this.setting.SetAddUser(this.checkBoxAddUser.Checked);
        }

        private void checkBoxOnlyOur_CheckedChanged(object sender, EventArgs e)
        {
            this.setting.SetOnlyOur(this.checkBoxOnlyOur.Checked);
        }

        private void checkBoxPovtorSdachi_CheckedChanged(object sender, EventArgs e)
        {
            this.setting.SetPovtorSdachi(this.checkBoxPovtorSdachi.Checked);
            if (this.checkBoxPovtorSdachi.Checked)
            {
                this.label10.Enabled = true;
                this.textBoxTimeForNewTest.Enabled = true;
                this.textBoxTimeForNewTest.Text = this.setting.GetTimeForNewTest().ToString();
            }
            else
            {
                this.label10.Enabled = false;
                this.textBoxTimeForNewTest.Enabled = false;
           
            }
        }

        private void textBoxTimeForNewTest_Leave(object sender, EventArgs e)
        {   int value=0;
            bool OK=true;
            try
                          {
                              value=Convert.ToInt32(this.textBoxTimeForNewTest.Text);
                          }
                          catch (System.ArgumentNullException) {
                                MessageBox.Show ("Час на пересдачу тестів не визначений");
                                OK = false;
                                    }
                          catch (System.FormatException) {
                              MessageBox.Show("Час на пересдачу тестів  визначений не числом");
                             OK = false;
                                    } 
                          catch (System.OverflowException) {
                               MessageBox.Show("Час на пересдачу тестів визначений поза інтервалом");
                             OK = false;
                                    }
                              finally 
                          {
                              this.textBoxTimeForNewTest.SelectAll();
                              this.textBoxTimeForNewTest.Focus();
                          }
        
            if (OK) this.setting.SetTimeForNewTest(value);
        }

        private void menuItem8_Click(object sender, EventArgs e)
        {
            ActivisationForm AF = new ActivisationForm(this.setting);
            AF.ShowDialog();

            //проверка проведена ли регистрация
            if (this.setting.IfRegistrated())
            {
                this.menuItem8.Visible = false;
                this.groupBoxOption.Enabled = true;
                this.buttonMatrixOfMark.Enabled = true;
                this.buttonExport.Enabled = true;
                this.buttonImport.Enabled = true;
                this.menuItemExport.Enabled = this.menuItemImport.Enabled = true;

            }
            //проверка блокировки
            if (this.setting.IfStop())
            {
                MessageBox.Show("Програму заблоковано! Для розблокування її необхідно зареєструвати!");
                this.buttonForAdmin.Enabled = this.buttonForTeacher.Enabled = this.buttonForUser.Enabled = false;
                this.menuItem1.Enabled = false;
            }
            else this.buttonForAdmin.Enabled = this.buttonForTeacher.Enabled = this.buttonForUser.Enabled = this.menuItem1.Enabled = true;

        }

        private void buttonMatrixOfMark_Click(object sender, EventArgs e)
        {
            FormMatrixOfMark FMOM = new FormMatrixOfMark(this.setting);
            FMOM.ShowDialog();
        }

        private void buttonJurnal_Click(object sender, EventArgs e)
        {
            FormJournal FJ = new FormJournal(this.setting);
            FJ.ShowDialog();
        }



        public void SerializationSetting()
        {

            //сериализация в файл

            RegistryKey rk = Registry.CurrentUser.CreateSubKey("Volatile Environment");
            string path0 = rk.GetValue("HOMEDRIVE").ToString() + rk.GetValue("HOMEPATH").ToString() + "\\Local Settings\\Application Data\\MYV\\Data";
            string path1 = path0 + "\\Config";
            string path2 = path0 + "\\font";

            rk.Close();

            if ((!File.Exists(path2)) || (!File.Exists(path1))) MessageBox.Show("Файлів настроювання не знайдено! Буде створено нові файли!");
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf1 = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            FileStream FKey = new FileStream(path2, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter BWKey = new BinaryWriter(FKey);

            for (int a = 0; a < 100; a++)
            {
                byte[] Key1 = new TripleDESCryptoServiceProvider().Key;
                byte[] IV1 = new TripleDESCryptoServiceProvider().Key;
                byte[] dataToEncrypt = new byte[32];
                for (int i = 0; i < 32; i++)
                    if (i < 24) dataToEncrypt[i] = Key1[i];
                    else dataToEncrypt[i] = IV1[i - 24];
                BWKey.Write(dataToEncrypt);
            }
            BWKey.Close();

            FileStream FRKey = new FileStream(path2, FileMode.Open, FileAccess.Read);
            BinaryReader BRKey = new BinaryReader(FRKey);
            for (int a = 0; a < 982; a++) BRKey.ReadByte();
            byte[] encryptedData = BRKey.ReadBytes(32);

            byte[] Key = new byte[24];
            byte[] IV = new byte[8];
            for (int i = 0; i < 24; i++)
                Key[i] = encryptedData[i];
            for (int i = 24; i < 32; i++)
                IV[i - 24] = encryptedData[i];
            FRKey.Close();
            FileStream encripted = File.Open(path1, FileMode.OpenOrCreate);
            CryptoStream cStream = new CryptoStream(encripted,
                new TripleDESCryptoServiceProvider().CreateEncryptor(Key, IV),
                CryptoStreamMode.Write);


            bf1.Serialize(cStream, setting);
            FKey.Close();
            cStream.Close();
            encripted.Close();
            File.SetAttributes(path1, File.GetAttributes(path1) | FileAttributes.System | FileAttributes.Hidden);
            File.SetAttributes(path2, File.GetAttributes(path2) | FileAttributes.System | FileAttributes.Hidden);


        }
    
    private void DeserializationSetting()
        {



            //Десериализация
            RegistryKey rk = Registry.CurrentUser.CreateSubKey("Volatile Environment");
            string path0 = rk.GetValue("HOMEDRIVE").ToString() + rk.GetValue("HOMEPATH").ToString() + "\\Local Settings\\Application Data\\MYV\\Data";
            if (!Directory.Exists(path0)) Directory.CreateDirectory(path0);
            string path1 = path0 + "\\Config";
            string path2 = path0 + "\\font";
            if (path1.Equals("\\Config"))
            {
                path1 = "Config";
                path2 = "font";
            }
            rk.Close();
            try
            {
                if (File.Exists(path1))
                {
                    this.WF.SetProgress(10);
                    if (!File.Exists(path2)) MessageBox.Show("Файлу настроювання2 не знайдено!");
                    FileStream encripted = File.Open(path1, FileMode.Open);
                    FileStream FKey = new FileStream(path2, FileMode.Open, FileAccess.Read);
                    BinaryReader BRKey = new BinaryReader(FKey);
                    for (int a = 0; a < 982; a++) BRKey.ReadByte();
                    byte[] encryptedData = BRKey.ReadBytes(32);
                    byte[] Key = new byte[24];
                    byte[] IV = new byte[8];
                    for (int i = 0; i < 24; i++)
                        Key[i] = encryptedData[i];
                    for (int i = 24; i < 32; i++)
                        IV[i - 24] = encryptedData[i];
                    FKey.Close();
                    CryptoStream cStream = new CryptoStream(encripted,
                        new TripleDESCryptoServiceProvider().CreateDecryptor(Key, IV),
                        CryptoStreamMode.Read);
                    this.WF.SetProgress(15);
                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    setting = (Setting)bf.Deserialize(cStream);
                    BRKey.Close();
                    //cStream.Close();
                    encripted.Close();
                    this.WF.SetProgress(30);
                    //проверка регистрации программы
                    if (!this.setting.IfRegistrated())
                    {//проверка блокировки
                        if (this.setting.IfStop())
                        {
                            MessageBox.Show("Програму заблоковано! Для розблокування її необхідно зареєструвати!");
                            this.buttonForAdmin.Enabled = this.buttonForTeacher.Enabled = this.buttonForUser.Enabled = false;
                            this.menuItem1.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Вказана копія програми не зареєстрована.\nПрограма буде працювати у обмеженому режимі до " + this.setting.GetTimeOfEnd());
                            this.buttonForAdmin.Enabled = this.buttonForTeacher.Enabled = this.buttonForUser.Enabled = this.menuItem1.Enabled = true;

                        }
                    }
                    else
                    {
                        this.menuItem8.Visible = false;
                        this.groupBoxOption.Enabled = true;
                        this.buttonMatrixOfMark.Enabled = true;

                        //проверка блокировки
                        if (this.setting.IfStop())
                        {
                            MessageBox.Show("Програму заблоковано! Для розблокування її необхідно зареєструвати!");
                            this.buttonForAdmin.Enabled = this.buttonForTeacher.Enabled = this.buttonForUser.Enabled = this.menuItem1.Enabled = false;
                        }
                        else this.buttonForAdmin.Enabled = this.buttonForTeacher.Enabled = this.buttonForUser.Enabled = this.menuItem1.Enabled = true;

                    }

                }
                else
                {
                    this.setting = new Setting();
                    this.setting.AddAdmin(new Admin("NewAdmin", "1111"));
                    this.SerializationSetting();

                }
            }
            catch (System.Security.Cryptography.CryptographicException)
            {
                MessageBox.Show("Плохие данные!");

            }
            catch
            {
                MessageBox.Show("Неможливо завантажити настройки програми!");
            }

        }

        private void menuItem7_Click(object sender, EventArgs e)
        {
            AboutBox AB = new AboutBox(this.setting);
            AB.ShowDialog();
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            this.saveFileDialogIES.FileName = "Test_MSetting_" + DateTime.Now.ToShortDateString()+".ies";
            if (this.saveFileDialogIES.ShowDialog() == DialogResult.OK)
                MessageBox.Show("Настройки збережені у файлі: "+Path.GetFullPath(this.saveFileDialogIES.FileName));
            else MessageBox.Show("Настройки не збережено.");

        }

        private void saveFileDialogIES_FileOk(object sender, CancelEventArgs e)
        {
            IESetting ies = new IESetting();
            ies.ExportSetting(this.setting);

            //сериализация в файл 
            byte[] Key ={ 13, 20, 94, 153, 8, 22, 109, 154, 231, 97, 91, 118, 97, 208, 214, 249, 128, 246, 150, 170, 173, 191, 207, 138 };
            byte[] IV = { 227, 182, 38, 145, 55, 77, 174, 23 };

            string path = this.saveFileDialogIES.FileName;
            
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            
            FileStream encripted = File.Open(path, FileMode.OpenOrCreate);

            CryptoStream cStream = new CryptoStream(encripted,
                new TripleDESCryptoServiceProvider().CreateEncryptor(Key, IV),
                CryptoStreamMode.Write);


            bf.Serialize(cStream, ies);
            cStream.Close();
            encripted.Close();


        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            this.openFileDialogIES.ShowDialog();
        }

        private void openFileDialogIES_FileOk(object sender, CancelEventArgs e)
        {
            //десериализация в файл 

            try
            {
                byte[] Key ={ 13, 20, 94, 153, 8, 22, 109, 154, 231, 97, 91, 118, 97, 208, 214, 249, 128, 246, 150, 170, 173, 191, 207, 138 };
                byte[] IV = { 227, 182, 38, 145, 55, 77, 174, 23 };

                string path =this.openFileDialogIES.FileName;

                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                FileStream encripted = File.Open(path, FileMode.Open);

                CryptoStream cStream = new CryptoStream(encripted,
                    new TripleDESCryptoServiceProvider().CreateDecryptor(Key, IV),
                    CryptoStreamMode.Read);


                IESetting ies = (IESetting)bf.Deserialize(cStream);
                cStream.Close();
                //encripted.Close();
                ies.ImportSetting(this.setting);
                MessageBox.Show("Імпорт настройок проведено успішно!");

            }
            catch 
            {
                MessageBox.Show("Імпорт настройок не відбувся через помилку!");
            }

            this.checkBoxAddUser.Checked = this.setting.GetAddUser();
            this.checkBoxOnlyOur.Checked = this.setting.GetOnlyOur();
            this.checkBoxPovtorSdachi.Checked = this.setting.GetPovtorSdachi();
            this.textBoxTimeForNewTest.Text = this.setting.GetTimeForNewTest().ToString();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            if (this.buttonForAdmin.Visible) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "5.htm");
            else if (this.buttonEnter.Visible) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "81.htm");
            else if (this.button1.Visible) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "71.htm");
            else if (this.button4.Visible) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "61.htm");
            
            else if (this.button2.Focused) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "821.htm");
                else if (this.button5.Focused) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "822.htm");
                else if (this.button6.Focused) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "823.htm");
                else if (this.button7.Focused) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "824.htm");
                else if (this.buttonExport.Focused||this.buttonImport.Focused) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "83.htm");
                else if (this.checkBoxAddUser.Focused||this.checkBoxOnlyOur.Focused||this.checkBoxPovtorSdachi.Focused ) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "84.htm");
                else if (this.buttonMatrixOfMark.Focused) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "85.htm");
                else if (this.buttonJurnal.Focused) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "86.htm");
            else    Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "811.htm");

           
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (this.buttonForAdmin.Visible) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "5.htm");
                else if (this.buttonEnter.Visible) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "81.htm");
                else if (this.button1.Visible) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "71.htm");
                else if (this.button4.Visible) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "61.htm");

                else if (this.button2.Focused) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "821.htm");
                else if (this.button5.Focused) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "822.htm");
                else if (this.button6.Focused) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "823.htm");
                else if (this.button7.Focused) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "824.htm");
                else if (this.buttonExport.Focused || this.buttonImport.Focused) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "83.htm");
                else if (this.checkBoxAddUser.Focused || this.checkBoxOnlyOur.Focused || this.checkBoxPovtorSdachi.Focused) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "84.htm");
                else if (this.buttonMatrixOfMark.Focused) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "85.htm");
                else if (this.buttonJurnal.Focused) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "86.htm");
                else Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "811.htm");
            }
        }
    }
}