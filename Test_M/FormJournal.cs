using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;


namespace Test_M
{
    public partial class FormJournal : Form
    {
        
        private  Journal journal;
        private Setting setting;
        private readonly Teacher CurrentTeacher;

        public FormJournal()
        {
            InitializeComponent();

        }

        public FormJournal(Setting setting)
        {
            InitializeComponent();


            this.setting = setting;
            this.journal = this.setting.GetCopyJournal();
            for (int i = 0; i < this.journal.Length(); i++)
            {
                string Prav = "";
                string Neprav = "";
                string CollMark = "-";

                if (!journal.IsTest(i))
                {

                    Prav = journal.GetPrav(i)[0].ToString();
                    for (int a = 1; a < journal.GetPrav(i).Length; a++)
                        Prav = Prav + "," + journal.GetPrav(i)[a];
                }
                else Prav = journal.GetPrav(i)[0].ToString();

                if (!journal.IsTest(i))
                {
                    Neprav = journal.GetNeprav(i)[0].ToString();
                    for (int a = 1; a < journal.GetNeprav(i).Length; a++)
                        Neprav = Neprav + "," + journal.GetNeprav(i)[a];
                }
                else Neprav = journal.GetNeprav(i)[0].ToString();

                if (!journal.IsTest(i))
                {
                    CollMark = journal.GetCollMark(i)[0].ToString();
                    for (int a = 1; a < journal.GetCollMark(i).Length; a++)
                        CollMark = CollMark + "," + journal.GetCollMark(i)[a];
                }



                this.dataGridView1.Rows.Add(journal.GetTime(i).ToString(),
                    ((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString(),
                    setting.FindAnyUserToID(journal.GetUserID(i)).ToString(),
                    journal.GetPredmet(i).ToString(),
                    setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString(),
                    journal.GetNameOfTest(i).ToString(),
                    journal.GetMark(i), Prav, Neprav, CollMark);


                if (this.comboBoxTime.Items.IndexOf(journal.GetTime(i).ToShortDateString()) == -1)
                    this.comboBoxTime.Items.Add(journal.GetTime(i).ToShortDateString());
                if (this.comboBoxGroup.Items.IndexOf(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString()) == -1)
                    this.comboBoxGroup.Items.Add(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString());
                if (this.comboBoxName.Items.IndexOf(setting.FindAnyUserToID(journal.GetUserID(i)).ToString()) == -1)
                    this.comboBoxName.Items.Add(setting.FindAnyUserToID(journal.GetUserID(i)).ToString());
                if (this.comboBoxPredmet.Items.IndexOf(journal.GetPredmet(i).ToString()) == -1)
                    this.comboBoxPredmet.Items.Add(journal.GetPredmet(i).ToString());
                if (this.comboBoxTeacher.Items.IndexOf(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString()) == -1)
                    this.comboBoxTeacher.Items.Add(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString());
                if (this.comboBoxTest.Items.IndexOf(journal.GetNameOfTest(i).ToString()) == -1)
                    this.comboBoxTest.Items.Add(journal.GetNameOfTest(i).ToString());

            }

            if (this.setting.IfFlagRegistrated())
            {
                this.groupBoxDelete.Enabled = true;
                this.button1.Enabled = true;
            }




           
        }
        public FormJournal(Setting setting, Teacher CurrentTeacher)
        {
            InitializeComponent();
            this.CurrentTeacher = CurrentTeacher;

            this.setting = setting;
            this.journal = this.setting.GetCopyJournal();
            this.radioButton2.Enabled = this.comboBox1.Enabled = false;

            for (int i = 0; i < this.journal.Length(); i++)
            {
                string Prav = "";
                string Neprav = "";
                string CollMark = "-";

                if (!journal.IsTest(i))
                {

                    Prav = journal.GetPrav(i)[0].ToString();
                    for (int a = 1; a < journal.GetPrav(i).Length; a++)
                        Prav = Prav + "," + journal.GetPrav(i)[a];
                }
                else Prav = journal.GetPrav(i)[0].ToString();

                if (!journal.IsTest(i))
                {
                    Neprav = journal.GetNeprav(i)[0].ToString();
                    for (int a = 1; a < journal.GetNeprav(i).Length; a++)
                        Neprav = Neprav + "," + journal.GetNeprav(i)[a];
                }
                else Neprav = journal.GetNeprav(i)[0].ToString();

                if (!journal.IsTest(i))
                {
                    CollMark = journal.GetCollMark(i)[0].ToString();
                    for (int a = 1; a < journal.GetCollMark(i).Length; a++)
                        CollMark = CollMark + "," + journal.GetCollMark(i)[a];
                }


                if (this.CurrentTeacher.GetID().Equals(journal.GetPredmet(i).GetTeacherID()))
                {
                    this.dataGridView1.Rows.Add(journal.GetTime(i).ToString(),
                       ((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString(),
                       setting.FindAnyUserToID(journal.GetUserID(i)).ToString(),
                       journal.GetPredmet(i).ToString(),
                       setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString(),
                       journal.GetNameOfTest(i).ToString(),
                       journal.GetMark(i), Prav, Neprav, CollMark);


                    if (this.comboBoxTime.Items.IndexOf(journal.GetTime(i).ToShortDateString()) == -1)
                        this.comboBoxTime.Items.Add(journal.GetTime(i).ToShortDateString());
                    if (this.comboBoxGroup.Items.IndexOf(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString()) == -1)
                        this.comboBoxGroup.Items.Add(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString());
                    if (this.comboBoxName.Items.IndexOf(setting.FindAnyUserToID(journal.GetUserID(i)).ToString()) == -1)
                        this.comboBoxName.Items.Add(setting.FindAnyUserToID(journal.GetUserID(i)).ToString());
                    if (this.comboBoxPredmet.Items.IndexOf(journal.GetPredmet(i).ToString()) == -1)
                        this.comboBoxPredmet.Items.Add(journal.GetPredmet(i).ToString());
                    if (this.comboBoxTeacher.Items.IndexOf(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString()) == -1)
                        this.comboBoxTeacher.Items.Add(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString());
                    if (this.comboBoxTest.Items.IndexOf(journal.GetNameOfTest(i).ToString()) == -1)
                        this.comboBoxTest.Items.Add(journal.GetNameOfTest(i).ToString());
                }
            }
            if (this.setting.IfFlagRegistrated())
            {
                this.groupBoxDelete.Enabled = true;
                this.button1.Enabled = true;
            }


        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDeleteOld_Click(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked)
            {//видалити записи з видаленими сутностями

                this.setting.DelNullJournal();
               
            }
            else 
            {
                string DTstr = this.comboBox1.SelectedItem.ToString();

                DateTime DT = new DateTime(Convert.ToInt32(DTstr.Substring(6)),Convert.ToInt32(DTstr.Substring(3,2)),Convert.ToInt32(DTstr.Substring(0,2)));
               //string DTstr = this.comboBox1.SelectedItem.ToString();




                this.setting.DelOldJournal(DT);
            }

            this.journal = this.setting.GetCopyJournal();
           




            this.dataGridView1.Rows.Clear();
            this.comboBoxTime.Items.Clear();
            this.comboBoxGroup.Items.Clear();
            this.comboBoxName.Items.Clear();
            this.comboBoxPredmet.Items.Clear();
            this.comboBoxTeacher.Items.Clear();
            this.comboBoxTest.Items.Clear();

            for (int i = 0; i < this.journal.Length(); i++)
            {
                string Prav = "";
                string Neprav = "";
                string CollMark = "-";

                if (!journal.IsTest(i))
                {

                    Prav = journal.GetPrav(i)[0].ToString();
                    for (int a = 1; a < journal.GetPrav(i).Length; a++)
                        Prav = Prav + "," + journal.GetPrav(i)[a];
                }
                else Prav = journal.GetPrav(i)[0].ToString();

                if (!journal.IsTest(i))
                {
                    Neprav = journal.GetNeprav(i)[0].ToString();
                    for (int a = 1; a < journal.GetNeprav(i).Length; a++)
                        Neprav = Neprav + "," + journal.GetNeprav(i)[a];
                }
                else Neprav = journal.GetNeprav(i)[0].ToString();

                if (!journal.IsTest(i))
                {
                    CollMark = journal.GetCollMark(i)[0].ToString();
                    for (int a = 1; a < journal.GetCollMark(i).Length; a++)
                        CollMark = CollMark + "," + journal.GetCollMark(i)[a];
                }


                if (this.CurrentTeacher ==null)
                {
                    this.dataGridView1.Rows.Add(journal.GetTime(i).ToString(),
                            ((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString(),
                            setting.FindAnyUserToID(journal.GetUserID(i)).ToString(),
                            journal.GetPredmet(i).ToString(),
                            setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString(),
                            journal.GetNameOfTest(i).ToString(),
                            journal.GetMark(i), Prav, Neprav, CollMark);

                    if (this.comboBoxTime.Items.IndexOf(journal.GetTime(i).ToShortDateString()) == -1)
                        this.comboBoxTime.Items.Add(journal.GetTime(i).ToShortDateString());
                    if (this.comboBoxGroup.Items.IndexOf(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString()) == -1)
                        this.comboBoxGroup.Items.Add(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString());
                    if (this.comboBoxName.Items.IndexOf(setting.FindAnyUserToID(journal.GetUserID(i)).ToString()) == -1)
                        this.comboBoxName.Items.Add(setting.FindAnyUserToID(journal.GetUserID(i)).ToString());
                    if (this.comboBoxPredmet.Items.IndexOf(journal.GetPredmet(i).ToString()) == -1)
                        this.comboBoxPredmet.Items.Add(journal.GetPredmet(i).ToString());
                    if (this.comboBoxTeacher.Items.IndexOf(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString()) == -1)
                        this.comboBoxTeacher.Items.Add(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString());
                    if (this.comboBoxTest.Items.IndexOf(journal.GetNameOfTest(i).ToString()) == -1)
                        this.comboBoxTest.Items.Add(journal.GetNameOfTest(i).ToString());
                }
                    else if (this.CurrentTeacher.GetID().Equals(journal.GetPredmet(i).GetTeacherID()))
                    {
                        this.dataGridView1.Rows.Add(journal.GetTime(i).ToString(),
                                ((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString(),
                                setting.FindAnyUserToID(journal.GetUserID(i)).ToString(),
                                journal.GetPredmet(i).ToString(),
                                setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString(),
                                journal.GetNameOfTest(i).ToString(),
                                journal.GetMark(i), Prav, Neprav, CollMark);

                        if (this.comboBoxTime.Items.IndexOf(journal.GetTime(i).ToShortDateString()) == -1)
                            this.comboBoxTime.Items.Add(journal.GetTime(i).ToShortDateString());
                        if (this.comboBoxGroup.Items.IndexOf(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString()) == -1)
                            this.comboBoxGroup.Items.Add(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString());
                        if (this.comboBoxName.Items.IndexOf(setting.FindAnyUserToID(journal.GetUserID(i)).ToString()) == -1)
                            this.comboBoxName.Items.Add(setting.FindAnyUserToID(journal.GetUserID(i)).ToString());
                        if (this.comboBoxPredmet.Items.IndexOf(journal.GetPredmet(i).ToString()) == -1)
                            this.comboBoxPredmet.Items.Add(journal.GetPredmet(i).ToString());
                        if (this.comboBoxTeacher.Items.IndexOf(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString()) == -1)
                            this.comboBoxTeacher.Items.Add(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString());
                        if (this.comboBoxTest.Items.IndexOf(journal.GetNameOfTest(i).ToString()) == -1)
                            this.comboBoxTest.Items.Add(journal.GetNameOfTest(i).ToString());
                    }
                    
            }
        }

        private void comboBoxTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            object item = this.comboBoxTime.SelectedItem;

            this.dataGridView1.Rows.Clear();
            this.comboBoxTime.Items.Clear();
            this.comboBoxGroup.Items.Clear();
            this.comboBoxName.Items.Clear();
            this.comboBoxPredmet.Items.Clear();
            this.comboBoxTeacher.Items.Clear();
            this.comboBoxTest.Items.Clear();


  for (int i=0; i<this.journal.Length();i++)
            {
                string Prav="";
                string Neprav = "";
                string CollMark = "-";

                if (!journal.IsTest(i))
                {

                    Prav = journal.GetPrav(i)[0].ToString();
                    for (int a = 1; a < journal.GetPrav(i).Length; a++)
                        Prav = Prav + "," + journal.GetPrav(i)[a];
                }
                else Prav = journal.GetPrav(i)[0].ToString();

                if (!journal.IsTest(i))
                {
                    Neprav = journal.GetNeprav(i)[0].ToString();
                    for (int a = 1; a < journal.GetNeprav(i).Length; a++)
                        Neprav = Neprav + "," + journal.GetNeprav(i)[a];
                }
                else Neprav = journal.GetNeprav(i)[0].ToString();

                if (!journal.IsTest(i))
                {
                    CollMark = journal.GetCollMark(i)[0].ToString();
                    for (int a = 1; a < journal.GetCollMark(i).Length; a++)
                        CollMark = CollMark + "," + journal.GetCollMark(i)[a];
                }

                if (this.CurrentTeacher == null)
                {
                    if (journal.GetTime(i).ToShortDateString().Equals(item))

                        this.dataGridView1.Rows.Add(journal.GetTime(i).ToString(),
                        ((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString(),
                        setting.FindAnyUserToID(journal.GetUserID(i)).ToString(),
                        journal.GetPredmet(i).ToString(),
                        setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString(),
                        journal.GetNameOfTest(i).ToString(),
                        journal.GetMark(i), Prav, Neprav, CollMark);


                    if (this.comboBoxTime.Items.IndexOf(journal.GetTime(i).ToShortDateString()) == -1)
                        this.comboBoxTime.Items.Add(journal.GetTime(i).ToShortDateString());
                    if (this.comboBoxGroup.Items.IndexOf(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString()) == -1)
                        this.comboBoxGroup.Items.Add(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString());
                    if (this.comboBoxName.Items.IndexOf(setting.FindAnyUserToID(journal.GetUserID(i)).ToString()) == -1)
                        this.comboBoxName.Items.Add(setting.FindAnyUserToID(journal.GetUserID(i)).ToString());
                    if (this.comboBoxPredmet.Items.IndexOf(journal.GetPredmet(i).ToString()) == -1)
                        this.comboBoxPredmet.Items.Add(journal.GetPredmet(i).ToString());
                    if (this.comboBoxTeacher.Items.IndexOf(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString()) == -1)
                        this.comboBoxTeacher.Items.Add(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString());
                    if (this.comboBoxTest.Items.IndexOf(journal.GetNameOfTest(i).ToString()) == -1)
                        this.comboBoxTest.Items.Add(journal.GetNameOfTest(i).ToString());
                }
                else if ((this.CurrentTeacher.GetID().Equals(journal.GetPredmet(i).GetTeacherID()))&&(journal.GetTime(i).ToShortDateString().Equals(item)))
                {
                    this.dataGridView1.Rows.Add(journal.GetTime(i).ToString(),
                            ((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString(),
                            setting.FindAnyUserToID(journal.GetUserID(i)).ToString(),
                            journal.GetPredmet(i).ToString(),
                            setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString(),
                            journal.GetNameOfTest(i).ToString(),
                            journal.GetMark(i), Prav, Neprav, CollMark);

                    if (this.comboBoxTime.Items.IndexOf(journal.GetTime(i).ToShortDateString()) == -1)
                        this.comboBoxTime.Items.Add(journal.GetTime(i).ToShortDateString());
                    if (this.comboBoxGroup.Items.IndexOf(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString()) == -1)
                        this.comboBoxGroup.Items.Add(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString());
                    if (this.comboBoxName.Items.IndexOf(setting.FindAnyUserToID(journal.GetUserID(i)).ToString()) == -1)
                        this.comboBoxName.Items.Add(setting.FindAnyUserToID(journal.GetUserID(i)).ToString());
                    if (this.comboBoxPredmet.Items.IndexOf(journal.GetPredmet(i).ToString()) == -1)
                        this.comboBoxPredmet.Items.Add(journal.GetPredmet(i).ToString());
                    if (this.comboBoxTeacher.Items.IndexOf(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString()) == -1)
                        this.comboBoxTeacher.Items.Add(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString());
                    if (this.comboBoxTest.Items.IndexOf(journal.GetNameOfTest(i).ToString()) == -1)
                        this.comboBoxTest.Items.Add(journal.GetNameOfTest(i).ToString());
                }
            }
           
        }

        private void comboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            object item = this.comboBoxGroup.SelectedItem;

            this.dataGridView1.Rows.Clear();
            this.comboBoxTime.Items.Clear();
            this.comboBoxGroup.Items.Clear();
            this.comboBoxName.Items.Clear();
            this.comboBoxPredmet.Items.Clear();
            this.comboBoxTeacher.Items.Clear();
            this.comboBoxTest.Items.Clear();


            for (int i = 0; i < this.journal.Length(); i++)
            {
                string Prav = "";
                string Neprav = "";
                string CollMark = "-";

                if (!journal.IsTest(i))
                {

                    Prav = journal.GetPrav(i)[0].ToString();
                    for (int a = 1; a < journal.GetPrav(i).Length; a++)
                        Prav = Prav + "," + journal.GetPrav(i)[a];
                }
                else Prav = journal.GetPrav(i)[0].ToString();

                if (!journal.IsTest(i))
                {
                    Neprav = journal.GetNeprav(i)[0].ToString();
                    for (int a = 1; a < journal.GetNeprav(i).Length; a++)
                        Neprav = Neprav + "," + journal.GetNeprav(i)[a];
                }
                else Neprav = journal.GetNeprav(i)[0].ToString();

                if (!journal.IsTest(i))
                {
                    CollMark = journal.GetCollMark(i)[0].ToString();
                    for (int a = 1; a < journal.GetCollMark(i).Length; a++)
                        CollMark = CollMark + "," + journal.GetCollMark(i)[a];
                }

                if (this.CurrentTeacher == null)
                {

                    if (((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString().Equals(item))

                        this.dataGridView1.Rows.Add(journal.GetTime(i).ToString(),
                        ((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString(),
                        setting.FindAnyUserToID(journal.GetUserID(i)).ToString(),
                        journal.GetPredmet(i).ToString(),
                        setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString(),
                        journal.GetNameOfTest(i).ToString(),
                        journal.GetMark(i), Prav, Neprav, CollMark);


                    if (this.comboBoxTime.Items.IndexOf(journal.GetTime(i).ToShortDateString()) == -1)
                        this.comboBoxTime.Items.Add(journal.GetTime(i).ToShortDateString());
                    if (this.comboBoxGroup.Items.IndexOf(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString()) == -1)
                        this.comboBoxGroup.Items.Add(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString());
                    if (this.comboBoxName.Items.IndexOf(setting.FindAnyUserToID(journal.GetUserID(i)).ToString()) == -1)
                        this.comboBoxName.Items.Add(setting.FindAnyUserToID(journal.GetUserID(i)).ToString());
                    if (this.comboBoxPredmet.Items.IndexOf(journal.GetPredmet(i).ToString()) == -1)
                        this.comboBoxPredmet.Items.Add(journal.GetPredmet(i).ToString());
                    if (this.comboBoxTeacher.Items.IndexOf(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString()) == -1)
                        this.comboBoxTeacher.Items.Add(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString());
                    if (this.comboBoxTest.Items.IndexOf(journal.GetNameOfTest(i).ToString()) == -1)
                        this.comboBoxTest.Items.Add(journal.GetNameOfTest(i).ToString());
                }
                else if ((this.CurrentTeacher.GetID().Equals(journal.GetPredmet(i).GetTeacherID())) && ((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString().Equals(item))
                {
                    this.dataGridView1.Rows.Add(journal.GetTime(i).ToString(),
                            ((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString(),
                            setting.FindAnyUserToID(journal.GetUserID(i)).ToString(),
                            journal.GetPredmet(i).ToString(),
                            setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString(),
                            journal.GetNameOfTest(i).ToString(),
                            journal.GetMark(i), Prav, Neprav, CollMark);

                    if (this.comboBoxTime.Items.IndexOf(journal.GetTime(i).ToShortDateString()) == -1)
                        this.comboBoxTime.Items.Add(journal.GetTime(i).ToShortDateString());
                    if (this.comboBoxGroup.Items.IndexOf(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString()) == -1)
                        this.comboBoxGroup.Items.Add(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString());
                    if (this.comboBoxName.Items.IndexOf(setting.FindAnyUserToID(journal.GetUserID(i)).ToString()) == -1)
                        this.comboBoxName.Items.Add(setting.FindAnyUserToID(journal.GetUserID(i)).ToString());
                    if (this.comboBoxPredmet.Items.IndexOf(journal.GetPredmet(i).ToString()) == -1)
                        this.comboBoxPredmet.Items.Add(journal.GetPredmet(i).ToString());
                    if (this.comboBoxTeacher.Items.IndexOf(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString()) == -1)
                        this.comboBoxTeacher.Items.Add(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString());
                    if (this.comboBoxTest.Items.IndexOf(journal.GetNameOfTest(i).ToString()) == -1)
                        this.comboBoxTest.Items.Add(journal.GetNameOfTest(i).ToString());
                }
            }
        }

        private void comboBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            object item = this.comboBoxName.SelectedItem;

            this.dataGridView1.Rows.Clear();
            this.comboBoxTime.Items.Clear();
            this.comboBoxGroup.Items.Clear();
            this.comboBoxName.Items.Clear();
            this.comboBoxPredmet.Items.Clear();
            this.comboBoxTeacher.Items.Clear();
            this.comboBoxTest.Items.Clear();


            for (int i = 0; i < this.journal.Length(); i++)
            {
                string Prav = "";
                string Neprav = "";
                string CollMark = "-";

                if (!journal.IsTest(i))
                {

                    Prav = journal.GetPrav(i)[0].ToString();
                    for (int a = 1; a < journal.GetPrav(i).Length; a++)
                        Prav = Prav + "," + journal.GetPrav(i)[a];
                }
                else Prav = journal.GetPrav(i)[0].ToString();

                if (!journal.IsTest(i))
                {
                    Neprav = journal.GetNeprav(i)[0].ToString();
                    for (int a = 1; a < journal.GetNeprav(i).Length; a++)
                        Neprav = Neprav + "," + journal.GetNeprav(i)[a];
                }
                else Neprav = journal.GetNeprav(i)[0].ToString();

                if (!journal.IsTest(i))
                {
                    CollMark = journal.GetCollMark(i)[0].ToString();
                    for (int a = 1; a < journal.GetCollMark(i).Length; a++)
                        CollMark = CollMark + "," + journal.GetCollMark(i)[a];
                }

                if (this.CurrentTeacher == null)
                {
                    if (setting.FindAnyUserToID(journal.GetUserID(i)).ToString().Equals(item))

                        this.dataGridView1.Rows.Add(journal.GetTime(i).ToString(),
                        ((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString(),
                        setting.FindAnyUserToID(journal.GetUserID(i)).ToString(),
                        journal.GetPredmet(i).ToString(),
                        setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString(),
                        journal.GetNameOfTest(i).ToString(),
                        journal.GetMark(i), Prav, Neprav, CollMark);


                    if (this.comboBoxTime.Items.IndexOf(journal.GetTime(i).ToShortDateString()) == -1)
                        this.comboBoxTime.Items.Add(journal.GetTime(i).ToShortDateString());
                    if (this.comboBoxGroup.Items.IndexOf(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString()) == -1)
                        this.comboBoxGroup.Items.Add(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString());
                    if (this.comboBoxName.Items.IndexOf(setting.FindAnyUserToID(journal.GetUserID(i)).ToString()) == -1)
                        this.comboBoxName.Items.Add(setting.FindAnyUserToID(journal.GetUserID(i)).ToString());
                    if (this.comboBoxPredmet.Items.IndexOf(journal.GetPredmet(i).ToString()) == -1)
                        this.comboBoxPredmet.Items.Add(journal.GetPredmet(i).ToString());
                    if (this.comboBoxTeacher.Items.IndexOf(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString()) == -1)
                        this.comboBoxTeacher.Items.Add(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString());
                    if (this.comboBoxTest.Items.IndexOf(journal.GetNameOfTest(i).ToString()) == -1)
                        this.comboBoxTest.Items.Add(journal.GetNameOfTest(i).ToString());
                }
                else if ((this.CurrentTeacher.GetID().Equals(journal.GetPredmet(i).GetTeacherID())) && (setting.FindAnyUserToID(journal.GetUserID(i)).ToString().Equals(item)))
                {
                    this.dataGridView1.Rows.Add(journal.GetTime(i).ToString(),
                            ((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString(),
                            setting.FindAnyUserToID(journal.GetUserID(i)).ToString(),
                            journal.GetPredmet(i).ToString(),
                            setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString(),
                            journal.GetNameOfTest(i).ToString(),
                            journal.GetMark(i), Prav, Neprav, CollMark);

                    if (this.comboBoxTime.Items.IndexOf(journal.GetTime(i).ToShortDateString()) == -1)
                        this.comboBoxTime.Items.Add(journal.GetTime(i).ToShortDateString());
                    if (this.comboBoxGroup.Items.IndexOf(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString()) == -1)
                        this.comboBoxGroup.Items.Add(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString());
                    if (this.comboBoxName.Items.IndexOf(setting.FindAnyUserToID(journal.GetUserID(i)).ToString()) == -1)
                        this.comboBoxName.Items.Add(setting.FindAnyUserToID(journal.GetUserID(i)).ToString());
                    if (this.comboBoxPredmet.Items.IndexOf(journal.GetPredmet(i).ToString()) == -1)
                        this.comboBoxPredmet.Items.Add(journal.GetPredmet(i).ToString());
                    if (this.comboBoxTeacher.Items.IndexOf(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString()) == -1)
                        this.comboBoxTeacher.Items.Add(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString());
                    if (this.comboBoxTest.Items.IndexOf(journal.GetNameOfTest(i).ToString()) == -1)
                        this.comboBoxTest.Items.Add(journal.GetNameOfTest(i).ToString());
                }
            }
        }

        private void comboBoxPredmet_SelectedIndexChanged(object sender, EventArgs e)
        {
            object item = this.comboBoxPredmet.SelectedItem;

            this.dataGridView1.Rows.Clear();
            this.comboBoxTime.Items.Clear();
            this.comboBoxGroup.Items.Clear();
            this.comboBoxName.Items.Clear();
            this.comboBoxPredmet.Items.Clear();
            this.comboBoxTeacher.Items.Clear();
            this.comboBoxTest.Items.Clear();


            for (int i = 0; i < this.journal.Length(); i++)
            {
                string Prav = "";
                string Neprav = "";
                string CollMark = "-";

                if (!journal.IsTest(i))
                {

                    Prav = journal.GetPrav(i)[0].ToString();
                    for (int a = 1; a < journal.GetPrav(i).Length; a++)
                        Prav = Prav + "," + journal.GetPrav(i)[a];
                }
                else Prav = journal.GetPrav(i)[0].ToString();

                if (!journal.IsTest(i))
                {
                    Neprav = journal.GetNeprav(i)[0].ToString();
                    for (int a = 1; a < journal.GetNeprav(i).Length; a++)
                        Neprav = Neprav + "," + journal.GetNeprav(i)[a];
                }
                else Neprav = journal.GetNeprav(i)[0].ToString();

                if (!journal.IsTest(i))
                {
                    CollMark = journal.GetCollMark(i)[0].ToString();
                    for (int a = 1; a < journal.GetCollMark(i).Length; a++)
                        CollMark = CollMark + "," + journal.GetCollMark(i)[a];
                }

                if (this.CurrentTeacher == null)
                {

                    if (journal.GetPredmet(i).ToString().Equals(item))

                        this.dataGridView1.Rows.Add(journal.GetTime(i).ToString(),
                        ((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString(),
                        setting.FindAnyUserToID(journal.GetUserID(i)).ToString(),
                        journal.GetPredmet(i).ToString(),
                        setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString(),
                        journal.GetNameOfTest(i).ToString(),
                        journal.GetMark(i), Prav, Neprav, CollMark);


                    if (this.comboBoxTime.Items.IndexOf(journal.GetTime(i).ToShortDateString()) == -1)
                        this.comboBoxTime.Items.Add(journal.GetTime(i).ToShortDateString());
                    if (this.comboBoxGroup.Items.IndexOf(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString()) == -1)
                        this.comboBoxGroup.Items.Add(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString());
                    if (this.comboBoxName.Items.IndexOf(setting.FindAnyUserToID(journal.GetUserID(i)).ToString()) == -1)
                        this.comboBoxName.Items.Add(setting.FindAnyUserToID(journal.GetUserID(i)).ToString());
                    if (this.comboBoxPredmet.Items.IndexOf(journal.GetPredmet(i).ToString()) == -1)
                        this.comboBoxPredmet.Items.Add(journal.GetPredmet(i).ToString());
                    if (this.comboBoxTeacher.Items.IndexOf(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString()) == -1)
                        this.comboBoxTeacher.Items.Add(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString());
                    if (this.comboBoxTest.Items.IndexOf(journal.GetNameOfTest(i).ToString()) == -1)
                        this.comboBoxTest.Items.Add(journal.GetNameOfTest(i).ToString());
                }
                else if ((this.CurrentTeacher.GetID().Equals(journal.GetPredmet(i).GetTeacherID())) && (journal.GetPredmet(i).ToString().Equals(item)))
                {
                    this.dataGridView1.Rows.Add(journal.GetTime(i).ToString(),
                            ((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString(),
                            setting.FindAnyUserToID(journal.GetUserID(i)).ToString(),
                            journal.GetPredmet(i).ToString(),
                            setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString(),
                            journal.GetNameOfTest(i).ToString(),
                            journal.GetMark(i), Prav, Neprav, CollMark);

                    if (this.comboBoxTime.Items.IndexOf(journal.GetTime(i).ToShortDateString()) == -1)
                        this.comboBoxTime.Items.Add(journal.GetTime(i).ToShortDateString());
                    if (this.comboBoxGroup.Items.IndexOf(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString()) == -1)
                        this.comboBoxGroup.Items.Add(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString());
                    if (this.comboBoxName.Items.IndexOf(setting.FindAnyUserToID(journal.GetUserID(i)).ToString()) == -1)
                        this.comboBoxName.Items.Add(setting.FindAnyUserToID(journal.GetUserID(i)).ToString());
                    if (this.comboBoxPredmet.Items.IndexOf(journal.GetPredmet(i).ToString()) == -1)
                        this.comboBoxPredmet.Items.Add(journal.GetPredmet(i).ToString());
                    if (this.comboBoxTeacher.Items.IndexOf(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString()) == -1)
                        this.comboBoxTeacher.Items.Add(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString());
                    if (this.comboBoxTest.Items.IndexOf(journal.GetNameOfTest(i).ToString()) == -1)
                        this.comboBoxTest.Items.Add(journal.GetNameOfTest(i).ToString());
                }
            }
        }

        private void comboBoxTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            object item = this.comboBoxTeacher.SelectedItem;

            this.dataGridView1.Rows.Clear();
            this.comboBoxTime.Items.Clear();
            this.comboBoxGroup.Items.Clear();
            this.comboBoxName.Items.Clear();
            this.comboBoxPredmet.Items.Clear();
            this.comboBoxTeacher.Items.Clear();
            this.comboBoxTest.Items.Clear();


            for (int i = 0; i < this.journal.Length(); i++)
            {
                string Prav = "";
                string Neprav = "";
                string CollMark = "-";

                if (!journal.IsTest(i))
                {

                    Prav = journal.GetPrav(i)[0].ToString();
                    for (int a = 1; a < journal.GetPrav(i).Length; a++)
                        Prav = Prav + "," + journal.GetPrav(i)[a];
                }
                else Prav = journal.GetPrav(i)[0].ToString();

                if (!journal.IsTest(i))
                {
                    Neprav = journal.GetNeprav(i)[0].ToString();
                    for (int a = 1; a < journal.GetNeprav(i).Length; a++)
                        Neprav = Neprav + "," + journal.GetNeprav(i)[a];
                }
                else Neprav = journal.GetNeprav(i)[0].ToString();

                if (!journal.IsTest(i))
                {
                    CollMark = journal.GetCollMark(i)[0].ToString();
                    for (int a = 1; a < journal.GetCollMark(i).Length; a++)
                        CollMark = CollMark + "," + journal.GetCollMark(i)[a];
                }

                if (this.CurrentTeacher == null)
                {
                    if (setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString().Equals(item))

                        this.dataGridView1.Rows.Add(journal.GetTime(i).ToString(),
                        ((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString(),
                        setting.FindAnyUserToID(journal.GetUserID(i)).ToString(),
                        journal.GetPredmet(i).ToString(),
                        setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString(),
                        journal.GetNameOfTest(i).ToString(),
                        journal.GetMark(i), Prav, Neprav, CollMark);


                    if (this.comboBoxTime.Items.IndexOf(journal.GetTime(i).ToShortDateString()) == -1)
                        this.comboBoxTime.Items.Add(journal.GetTime(i).ToShortDateString());
                    if (this.comboBoxGroup.Items.IndexOf(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString()) == -1)
                        this.comboBoxGroup.Items.Add(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString());
                    if (this.comboBoxName.Items.IndexOf(setting.FindAnyUserToID(journal.GetUserID(i)).ToString()) == -1)
                        this.comboBoxName.Items.Add(setting.FindAnyUserToID(journal.GetUserID(i)).ToString());
                    if (this.comboBoxPredmet.Items.IndexOf(journal.GetPredmet(i).ToString()) == -1)
                        this.comboBoxPredmet.Items.Add(journal.GetPredmet(i).ToString());
                    if (this.comboBoxTeacher.Items.IndexOf(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString()) == -1)
                        this.comboBoxTeacher.Items.Add(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString());
                    if (this.comboBoxTest.Items.IndexOf(journal.GetNameOfTest(i).ToString()) == -1)
                        this.comboBoxTest.Items.Add(journal.GetNameOfTest(i).ToString());
                }
                else if ((this.CurrentTeacher.GetID().Equals(journal.GetPredmet(i).GetTeacherID())) && (setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString().Equals(item)))
                {
                    this.dataGridView1.Rows.Add(journal.GetTime(i).ToString(),
                            ((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString(),
                            setting.FindAnyUserToID(journal.GetUserID(i)).ToString(),
                            journal.GetPredmet(i).ToString(),
                            setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString(),
                            journal.GetNameOfTest(i).ToString(),
                            journal.GetMark(i), Prav, Neprav, CollMark);

                    if (this.comboBoxTime.Items.IndexOf(journal.GetTime(i).ToShortDateString()) == -1)
                        this.comboBoxTime.Items.Add(journal.GetTime(i).ToShortDateString());
                    if (this.comboBoxGroup.Items.IndexOf(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString()) == -1)
                        this.comboBoxGroup.Items.Add(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString());
                    if (this.comboBoxName.Items.IndexOf(setting.FindAnyUserToID(journal.GetUserID(i)).ToString()) == -1)
                        this.comboBoxName.Items.Add(setting.FindAnyUserToID(journal.GetUserID(i)).ToString());
                    if (this.comboBoxPredmet.Items.IndexOf(journal.GetPredmet(i).ToString()) == -1)
                        this.comboBoxPredmet.Items.Add(journal.GetPredmet(i).ToString());
                    if (this.comboBoxTeacher.Items.IndexOf(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString()) == -1)
                        this.comboBoxTeacher.Items.Add(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString());
                    if (this.comboBoxTest.Items.IndexOf(journal.GetNameOfTest(i).ToString()) == -1)
                        this.comboBoxTest.Items.Add(journal.GetNameOfTest(i).ToString());
                
                }
            }
        }

        private void comboBoxTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            object item = this.comboBoxTest.SelectedItem;

            this.dataGridView1.Rows.Clear();
            this.comboBoxTime.Items.Clear();
            this.comboBoxGroup.Items.Clear();
            this.comboBoxName.Items.Clear();
            this.comboBoxPredmet.Items.Clear();
            this.comboBoxTeacher.Items.Clear();
            this.comboBoxTest.Items.Clear();


            for (int i = 0; i < this.journal.Length(); i++)
            {
                string Prav = "";
                string Neprav = "";
                string CollMark = "-";

                if (!journal.IsTest(i))
                {

                    Prav = journal.GetPrav(i)[0].ToString();
                    for (int a = 1; a < journal.GetPrav(i).Length; a++)
                        Prav = Prav + "," + journal.GetPrav(i)[a];
                }
                else Prav = journal.GetPrav(i)[0].ToString();

                if (!journal.IsTest(i))
                {
                    Neprav = journal.GetNeprav(i)[0].ToString();
                    for (int a = 1; a < journal.GetNeprav(i).Length; a++)
                        Neprav = Neprav + "," + journal.GetNeprav(i)[a];
                }
                else Neprav = journal.GetNeprav(i)[0].ToString();

                if (!journal.IsTest(i))
                {
                    CollMark = journal.GetCollMark(i)[0].ToString();
                    for (int a = 1; a < journal.GetCollMark(i).Length; a++)
                        CollMark = CollMark + "," + journal.GetCollMark(i)[a];
                }

                if (this.CurrentTeacher == null)
                {
                    if (journal.GetNameOfTest(i).ToString().Equals(item))

                        this.dataGridView1.Rows.Add(journal.GetTime(i).ToString(),
                        ((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString(),
                        setting.FindAnyUserToID(journal.GetUserID(i)).ToString(),
                        journal.GetPredmet(i).ToString(),
                        setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString(),
                        journal.GetNameOfTest(i).ToString(),
                        journal.GetMark(i), Prav, Neprav, CollMark);


                    if (this.comboBoxTime.Items.IndexOf(journal.GetTime(i).ToShortDateString()) == -1)
                        this.comboBoxTime.Items.Add(journal.GetTime(i).ToShortDateString());
                    if (this.comboBoxGroup.Items.IndexOf(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString()) == -1)
                        this.comboBoxGroup.Items.Add(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString());
                    if (this.comboBoxName.Items.IndexOf(setting.FindAnyUserToID(journal.GetUserID(i)).ToString()) == -1)
                        this.comboBoxName.Items.Add(setting.FindAnyUserToID(journal.GetUserID(i)).ToString());
                    if (this.comboBoxPredmet.Items.IndexOf(journal.GetPredmet(i).ToString()) == -1)
                        this.comboBoxPredmet.Items.Add(journal.GetPredmet(i).ToString());
                    if (this.comboBoxTeacher.Items.IndexOf(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString()) == -1)
                        this.comboBoxTeacher.Items.Add(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString());
                    if (this.comboBoxTest.Items.IndexOf(journal.GetNameOfTest(i).ToString()) == -1)
                        this.comboBoxTest.Items.Add(journal.GetNameOfTest(i).ToString());
                }
                else if ((this.CurrentTeacher.GetID().Equals(journal.GetPredmet(i).GetTeacherID())) && (journal.GetNameOfTest(i).ToString().Equals(item)))
                {
                    this.dataGridView1.Rows.Add(journal.GetTime(i).ToString(),
                            ((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString(),
                            setting.FindAnyUserToID(journal.GetUserID(i)).ToString(),
                            journal.GetPredmet(i).ToString(),
                            setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString(),
                            journal.GetNameOfTest(i).ToString(),
                            journal.GetMark(i), Prav, Neprav, CollMark);

                    if (this.comboBoxTime.Items.IndexOf(journal.GetTime(i).ToShortDateString()) == -1)
                        this.comboBoxTime.Items.Add(journal.GetTime(i).ToShortDateString());
                    if (this.comboBoxGroup.Items.IndexOf(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString()) == -1)
                        this.comboBoxGroup.Items.Add(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString());
                    if (this.comboBoxName.Items.IndexOf(setting.FindAnyUserToID(journal.GetUserID(i)).ToString()) == -1)
                        this.comboBoxName.Items.Add(setting.FindAnyUserToID(journal.GetUserID(i)).ToString());
                    if (this.comboBoxPredmet.Items.IndexOf(journal.GetPredmet(i).ToString()) == -1)
                        this.comboBoxPredmet.Items.Add(journal.GetPredmet(i).ToString());
                    if (this.comboBoxTeacher.Items.IndexOf(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString()) == -1)
                        this.comboBoxTeacher.Items.Add(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString());
                    if (this.comboBoxTest.Items.IndexOf(journal.GetNameOfTest(i).ToString()) == -1)
                        this.comboBoxTest.Items.Add(journal.GetNameOfTest(i).ToString());
                
                }
            }
        }

        private void buttonShowAll_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            this.comboBoxTime.Items.Clear();
            this.comboBoxGroup.Items.Clear();
            this.comboBoxName.Items.Clear();
            this.comboBoxPredmet.Items.Clear();
            this.comboBoxTeacher.Items.Clear();
            this.comboBoxTest.Items.Clear();

            for (int i = 0; i < this.journal.Length(); i++)
            {
                string Prav = "";
                string Neprav = "";
                string CollMark = "-";

                if (!journal.IsTest(i))
                {

                    Prav = journal.GetPrav(i)[0].ToString();
                    for (int a = 1; a < journal.GetPrav(i).Length; a++)
                        Prav = Prav + "," + journal.GetPrav(i)[a];
                }
                else Prav = journal.GetPrav(i)[0].ToString();

                if (!journal.IsTest(i))
                {
                    Neprav = journal.GetNeprav(i)[0].ToString();
                    for (int a = 1; a < journal.GetNeprav(i).Length; a++)
                        Neprav = Neprav + "," + journal.GetNeprav(i)[a];
                }
                else Neprav = journal.GetNeprav(i)[0].ToString();

                if (!journal.IsTest(i))
                {
                    CollMark = journal.GetCollMark(i)[0].ToString();
                    for (int a = 1; a < journal.GetCollMark(i).Length; a++)
                        CollMark = CollMark + "," + journal.GetCollMark(i)[a];
                }


                if (this.CurrentTeacher == null)
                {
                    this.dataGridView1.Rows.Add(journal.GetTime(i).ToString(),
                            ((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString(),
                            setting.FindAnyUserToID(journal.GetUserID(i)).ToString(),
                            journal.GetPredmet(i).ToString(),
                            setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString(),
                            journal.GetNameOfTest(i).ToString(),
                            journal.GetMark(i), Prav, Neprav, CollMark);

                    if (this.comboBoxTime.Items.IndexOf(journal.GetTime(i).ToShortDateString()) == -1)
                        this.comboBoxTime.Items.Add(journal.GetTime(i).ToShortDateString());
                    if (this.comboBoxGroup.Items.IndexOf(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString()) == -1)
                        this.comboBoxGroup.Items.Add(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString());
                    if (this.comboBoxName.Items.IndexOf(setting.FindAnyUserToID(journal.GetUserID(i)).ToString()) == -1)
                        this.comboBoxName.Items.Add(setting.FindAnyUserToID(journal.GetUserID(i)).ToString());
                    if (this.comboBoxPredmet.Items.IndexOf(journal.GetPredmet(i).ToString()) == -1)
                        this.comboBoxPredmet.Items.Add(journal.GetPredmet(i).ToString());
                    if (this.comboBoxTeacher.Items.IndexOf(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString()) == -1)
                        this.comboBoxTeacher.Items.Add(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString());
                    if (this.comboBoxTest.Items.IndexOf(journal.GetNameOfTest(i).ToString()) == -1)
                        this.comboBoxTest.Items.Add(journal.GetNameOfTest(i).ToString());
                }
                else if (this.CurrentTeacher.GetID().Equals(journal.GetPredmet(i).GetTeacherID()))
                {
                    this.dataGridView1.Rows.Add(journal.GetTime(i).ToString(),
                            ((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString(),
                            setting.FindAnyUserToID(journal.GetUserID(i)).ToString(),
                            journal.GetPredmet(i).ToString(),
                            setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString(),
                            journal.GetNameOfTest(i).ToString(),
                            journal.GetMark(i), Prav, Neprav, CollMark);

                    if (this.comboBoxTime.Items.IndexOf(journal.GetTime(i).ToShortDateString()) == -1)
                        this.comboBoxTime.Items.Add(journal.GetTime(i).ToShortDateString());
                    if (this.comboBoxGroup.Items.IndexOf(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString()) == -1)
                        this.comboBoxGroup.Items.Add(((User)setting.FindAnyUserToID(journal.GetUserID(i))).GetGroup().ToString());
                    if (this.comboBoxName.Items.IndexOf(setting.FindAnyUserToID(journal.GetUserID(i)).ToString()) == -1)
                        this.comboBoxName.Items.Add(setting.FindAnyUserToID(journal.GetUserID(i)).ToString());
                    if (this.comboBoxPredmet.Items.IndexOf(journal.GetPredmet(i).ToString()) == -1)
                        this.comboBoxPredmet.Items.Add(journal.GetPredmet(i).ToString());
                    if (this.comboBoxTeacher.Items.IndexOf(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString()) == -1)
                        this.comboBoxTeacher.Items.Add(setting.FindAnyUserToID(journal.GetPredmet(i).GetTeacherID()).ToString());
                    if (this.comboBoxTest.Items.IndexOf(journal.GetNameOfTest(i).ToString()) == -1)
                        this.comboBoxTest.Items.Add(journal.GetNameOfTest(i).ToString());
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.saveFileDialog1.ShowDialog()==DialogResult.OK)
                MessageBox.Show("Файл журналу збережено."); 
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
           
           string FileName=  this.saveFileDialog1.FileName;
           System.IO.FileStream fs1;
           fs1 = new System.IO.FileStream
              (FileName, FileMode.Create, FileAccess.Write);
            StreamWriter SW=new StreamWriter(fs1);

            if (fs1 != null)
            {
                for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    for (int a = 0; a < this.dataGridView1.Columns.Count; a++)
                    {

                        SW.Write(this.dataGridView1.Rows[i].Cells[a].Value.ToString());
                        SW.Write("\t");

                    }
                    SW.Write("\n");
                }
                SW.Close();
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton2.Checked)
            {
                this.comboBox1.Enabled = true;
                for (int i = 0; i < this.journal.Length(); i++)
                {
                    //string Prav = "";
                    if (this.CurrentTeacher == null)
                    {
                        if (this.comboBox1.Items.IndexOf(journal.GetTime(i).ToShortDateString()) == -1)
                            this.comboBox1.Items.Add(journal.GetTime(i).ToShortDateString());
                    }
                    else if (this.CurrentTeacher.GetID().Equals(journal.GetPredmet(i).GetTeacherID()))
                    {
                        if (this.comboBox1.Items.IndexOf(journal.GetTime(i).ToShortDateString()) == -1)
                            this.comboBox1.Items.Add(journal.GetTime(i).ToShortDateString());

                    }

                }
                if (this.comboBox1.Items.Count > 0) this.comboBox1.SelectedIndex = 0;
            }
            else
            {
                this.comboBox1.Items.Clear();
                this.comboBox1.Enabled = false;

            }
        }

        private void FormJournal_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (this.radioButton2.Enabled) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "86.htm");
                else Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "74.htm");

            }
        }
    }
}

