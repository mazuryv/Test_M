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

    

    public partial class FormOfUser : Form
    {
        private CollectionOfTest COT;
        private Test NameOfColl;



        public FormOfUser()
        {
            InitializeComponent();
        }

        public FormOfUser(MainForm MF, int UserID) //принимает настройки и идентификатор пользователя (для его нахождения в настройках)
        {
            InitializeComponent();
            this.MF = MF;
           CurrentUser=(User) this.MF.setting.FindAnyUserToID(UserID);
           this.Text="Учень: "+ CurrentUser.ToString()+ " Группа/клас: "+CurrentUser.GetGroup().ToString();
           

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void FormOfUser_Shown(object sender, EventArgs e)
        {
            this.listBoxPredmet.Items.Clear();
            this.listBoxPredmet.Items.AddRange(this.CurrentUser.GetGroup().GetAllPredmet());
            if (this.listBoxPredmet.Items.Count > 0) this.listBoxPredmet.SelectedIndex = 0;

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Predmet SelectPredmet=(Predmet)this.listBoxPredmet.Items[this.listBoxPredmet.SelectedIndex];
            //віводим список тестов по данному предмету
            this.listViewTest.Items.Clear();

            //проверка журнала и в случае прохождения этого теста его зачеркивание
            //
            //
            DateTime DT = new DateTime();
            DateTime DTdefault = new DateTime();
            Object[] Tests = new Object[SelectPredmet.GetTests().Length];
            Tests = SelectPredmet.GetTests();
            for (int a = 0; a < Tests.Length; a++)
            {
                DT = this.MF.setting.WhenPassTest(Tests[a], this.CurrentUser.GetID());
                //ловушка от изменения дат
                if (DT.CompareTo(DateTime.Now) > 0)
                {
                    MessageBox.Show("Помилка у часі вже провежених тестів. Тести проведені після сьогодення. \nПрограму буде заблоковано до реєстрації");
                    this.MF.setting.BlockProgramm();
                }

                if (!this.MF.setting.GetPovtorSdachi())
                {
                    if (DT.CompareTo(DTdefault) == 0)
                    {
                        this.listViewTest.Items.Add(Tests[a].ToString());

                    }
                    else
                    {
                        string t = Tests[a].ToString();
                        this.listViewTest.Items.Add(t, 0);
                    }
                }
                else
                {
                    if (DT.CompareTo(DTdefault) == 0)
                    {
                        this.listViewTest.Items.Add(Tests[a].ToString());

                    }
                    else
                    {
                        DateTime Now = DateTime.Now;
                        TimeSpan HowStep = Now - DT;
                        TimeSpan TimeForNewTest= new TimeSpan(0,Convert.ToInt32(this.MF.setting.GetTimeForNewTest()),0);
                        //int arw = HowStep.CompareTo(TimeForNewTest);
                        if (HowStep.CompareTo(TimeForNewTest) >0)
                            this.listViewTest.Items.Add(Tests[a].ToString());
                        else
                        {
                            string t = Tests[a].ToString();
                            this.listViewTest.Items.Add(t, 0);
                        }
                    }

                }

               
                
                

            }
            if (this.listViewTest.Items.Count == 0) this.buttonNext.Enabled = false;
            else
            {
             this.buttonNext.Enabled = true;
            }
            

        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (this.listViewTest.SelectedItems.Count == 0)
                MessageBox.Show("Виберіть тест, який необхідно пройти!");
            else
            {
                Predmet SelectPredmet = (Predmet)this.listBoxPredmet.Items[this.listBoxPredmet.SelectedIndex];
                if (this.listViewTest.SelectedItems[0].ImageIndex != -1)
                    if (!this.MF.setting.GetPovtorSdachi())
                        MessageBox.Show("Повторне складання тестів заборонене адміністратором!");
                    else
                    {
                        DateTime TimePass = this.MF.setting.WhenPassTest(SelectPredmet.FindTest(this.listViewTest.SelectedItems[0].Text), this.CurrentUser.GetID());
                        DateTime TimeForNewTest = TimePass.AddMinutes(Convert.ToInt32(this.MF.setting.GetTimeForNewTest()));
                        TimeSpan interval = TimeForNewTest - DateTime.Now;
                        MessageBox.Show("Повторне складання вказаного тесту Вами можливо лише через " + interval.Hours + " годин та " + interval.Minutes + " хвилин!");
                    }
                else
                {
                    string NameofTest = SelectPredmet.FindTest(this.listViewTest.SelectedItems[0].Text).ToString();
                    string NameColection = NameofTest.Substring(0, 3);
                    if (NameColection.Equals("(K)"))
                    //это коллекция
                    {
                        COT = new CollectionOfTest();
                        
                        COT =(CollectionOfTest) SelectPredmet.FindTest(NameofTest);
                            int SummOfMark = 0;
                            string message = "";
                            System.Collections.ArrayList AOT = COT.GetTests();
                            int[] APrav = new int[AOT.Count];
                            int[] ANeprav = new int[AOT.Count];
                            int[] CollMark = new int[AOT.Count];
                            this.Visible = false;
                            for (int i = 0; i < AOT.Count; i++)
                            {
                                TestForm tf = new TestForm((Test)AOT[i], CurrentUser);

                                tf.ShowDialog();
                                SummOfMark += tf.mark;
                                APrav[i] = tf.prav;
                                ANeprav[i] = tf.neprav;
                                CollMark[i] = tf.mark;
                                message += (i + 1) + ". " + ((Test)AOT[i]).GetNameOfTest() + " - " + tf.mark + "\n";

                            }


                            string caption = "Оцінки за проходження колекції тестів: \"" + NameOfColl + "\"";

                            if (COT.GetHowMark() == 0 || COT.GetHowMark() == 2)
                            {
                                message += "\n Загальна оцінка за вказаними тестами - " + SummOfMark;
                                //запись в журнал результатов
                                this.MF.setting.AddLogCollection(CurrentUser.GetID(), (Predmet)this.listBoxPredmet.SelectedItem, COT, APrav, ANeprav, CollMark, SummOfMark);
                            }
                            else
                            {
                                message += "\n Середньоарифметична оцінка за вказаними тестами - " + ((float)SummOfMark) / (AOT.Count);
                                this.MF.setting.AddLogCollection(CurrentUser.GetID(), (Predmet)this.listBoxPredmet.SelectedItem, COT, APrav, ANeprav, CollMark, ((float)SummOfMark) / (AOT.Count));

                            }

                            MessageBox.Show(message, caption);
                            this.Visible = true;
                        

                    }
                    else
                    //єто тест
                    {
                        Test T = new Test();
                        T = (Test)SelectPredmet.FindTest(NameofTest);
                            TestForm tf = new TestForm(T, CurrentUser);
                            this.Visible = false;
                            tf.ShowDialog();
                            //запись в журнал результатов
                            this.MF.setting.AddLogTest(this.CurrentUser.GetID(), (Predmet)this.listBoxPredmet.SelectedItem, T, tf.prav, tf.neprav, tf.mark);
                            tf.Close();
                            this.Visible = true;
                     }


                    }
                    this.listBox1_SelectedIndexChanged(this.listBoxPredmet, new EventArgs());
                }
            
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            this.MF.IfNeedAnyVhod = 1;
            Close();
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            this.MF.IfNeedAnyVhod = 2;
            Close();
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            this.MF.IfNeedAnyVhod = 3;
            Close();
        }

     

        private void menuItem7_Click(object sender, EventArgs e)
        {
            AboutBox AB = new AboutBox(this.MF.setting);
            AB.ShowDialog();
        }

        private void FormOfUser_Load(object sender, EventArgs e)
        {

        }

        private void listViewTest_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuItem5_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "62.htm");
        }

        private void FormOfUser_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "62.htm");
            }
        }
    }
}