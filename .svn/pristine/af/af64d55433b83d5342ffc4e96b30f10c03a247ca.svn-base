using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace Test_M
{
    public partial class FormMasterOfTest : Form
    {
        public FormMasterOfTest()
        {
            InitializeComponent();
        }

      
        
        
        public FormMasterOfTest(Setting setting, Teacher CurrentTeacher)
        {
            InitializeComponent();
            this.setting = setting;
            this.CurrentTeacher = CurrentTeacher;
            this.Step = 0;
            this.groupBox0.Visible=true;
            this.groupBox1.Visible= false;
            this.groupBox2.Visible = false;
            this.groupBox3.Visible = false;
            this.groupBox4.Visible = false;
            this.groupBox5.Visible = false;
            this.groupBox6.Visible = false;

            this.radioButton1.Focus();

            
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked == true)
            {
                this.richTextBox1.Text = "Підготовка окремого одиничного тесту із окремої дисципліни.\nПісля закінчення робо" +
                "ти \"Мастера...\", вказаний тест буде збережено у окремому файлі та може бути вико" +
                "ристаний у подальших тестуваннях";
                this.radioButton1.Focus();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton2.Checked == true) 
            {
                this.richTextBox1.Text = "Підготовка колекції тестів.\nВикористовується для "+
                "проведення тестування з використанням декількох (до 10) окремих тестових завдань" +
                " по принципу \"один за одним\" \nВ результаті робо"+
                "ти \"Мастера...\", вказана колекція буде збережена у окремому файлі колекції та може бути вико" +
                "ристана у подальших тестуваннях";
                this.radioButton2.Focus();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton3.Checked == true)
            {
                this.richTextBox1.Text = "Зміна існуючого тесту або колекції тестів.\n" +
                    "Використовується для зміни попередньо збереженого на диску тесту (колекції тестів.";
                this.radioButton3.Focus();
            }
        }

     

          private void richTextBox1_MouseDown(object sender, MouseEventArgs e) //делает невозможнім віделение
        {
            if (this.radioButton1.Checked) this.radioButton1.Focus();
            if (this.radioButton2.Checked) this.radioButton2.Focus();
            if (this.radioButton3.Checked) this.radioButton3.Focus();

        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked) this.radioButton1.Focus();
            if (this.radioButton2.Checked) this.radioButton2.Focus();
            if (this.radioButton3.Checked) this.radioButton3.Focus();

        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked )Step++;
            if (this.radioButton2.Checked) Step += 10;
            if (this.radioButton3.Checked) Step += 100;
            
            if (Step == 1)
            {
                NewTest = new Test();
                //интерфейс
                this.groupBox0.Visible = false;
                this.groupBox1.Visible = true;
                this.buttonReturn.Text = "Назад";
                this.textBox2.SelectAll();
                this.textBox3.SelectAll();
                this.textBox1.Focus();
            }

            if (Step == 2)
            {
                if (this.textBox1.Text.Length > 3) NewTest.SetNameOfTest(this.textBox1.Text);
                else
                {
                    MessageBox.Show("Назва тесту дуже мала! Введіть нову назву!");
                    this.textBox1.Focus();
                    Step--;
                }
                if (this.textBox2.Text.Length > 0 && this.textBox2.Text.Length<28) NewTest.SetNameOfQuestion(this.textBox2.Text);
                else
                {
                    if (this.textBox2.Text.Length > 27) MessageBox.Show("Назва запитань більша за 27 символів, зменшіть назву!");
                    else MessageBox.Show("Назва запитань не введена! Введіть нову назву запитань!");
                    this.textBox2.Text = "ЗАПИТАННЯ";
                    this.textBox2.SelectAll();
                    this.textBox2.Focus();
                    Step--;
                }
                if (this.textBox3.Text.Length > 0 && this.textBox3.Text.Length < 28) NewTest.SetNameOfAnswer(this.textBox3.Text);
                else
                {
                    if (this.textBox3.Text.Length > 27) MessageBox.Show("Назва відповідей більша за 27 символів, зменшіть назву!");
                    else MessageBox.Show("Назва відповідей не введена! Введіть нову назву відповідей!");
                    this.textBox3.Text = "ВІДПОВІДІ";
                    this.textBox3.SelectAll();
                    this.textBox3.Focus();
                    Step--;
                }
                
 
                //интерфейс
                if (Step == 2)
                {//второй шаг!
                    this.buttonNext.Text = "Далі";
                    this.groupBox1.Visible = false;
                    this.groupBox2.Visible = true;
                    this.label1.Text = NewTest.GetNameOfQuestion()+":";
                    this.richTextBox2.Focus();
                }
            }

                 //перевірка та третій шаг   
                if (Step == 3)
                {
                    this.buttonNext.Text = "Далі";
                    bool ProverkaOK = true;
                    if (this.richTextBox2.Lines.Length < 1)
                    {
                        ProverkaOK = false;
                        MessageBox.Show("Помилка у складанні запитань (максимальна кількість запитань -  не менше 1)");
                    }
                    if (this.richTextBox2.Lines.Length > 10)
                    {
                        ProverkaOK = false;
                        MessageBox.Show("Помилка у складанні запитань (максимальна кількість запитань -  не більше 10)");
                    }
                    int a = 0;
                    foreach (string item in this.richTextBox2.Lines)
                    {
                        a++;
                        if (item.Length < 1 || item.Length > 100)
                        {
                            ProverkaOK = false;
                            MessageBox.Show("Помилка у складанні запитання №" + a + " ( довжина запитання -від 1 до 100 символів))");
                        }
                    }
                    if (!ProverkaOK)
                    {
                        Step--;
                    }
                    else NewTest.SetQuestion(this.richTextBox2.Lines);

                    if (ProverkaOK) 
                    {//новий шаг
                        this.groupBox2.Visible = false;
                        this.groupBox3.Visible = true;
                        this.label10.Text = NewTest.GetNameOfAnswer() + ":";
                        this.richTextBox3.Focus();                      
                    }


                }
                //перевірка та четвертий шаг   
                if (Step == 4)
                {
                    this.buttonNext.Text = "Далі";
                    bool ProverkaOK = true;
                    if (this.richTextBox3.Lines.Length  <1)
                    {
                        ProverkaOK = false;
                        MessageBox.Show("Помилка у складанні відповідей (максимальна кількість відповідей не менше 1)");
                    }
                    if (this.richTextBox3.Lines.Length > 10)
                    {
                        ProverkaOK = false; 
                        MessageBox.Show("Помилка у складанні відповідей (максимальна кількість відповідей не більше 10)");
                    }
                    int a=0;
                    foreach (string item in this.richTextBox3.Lines)
                    {
                        a++;
                        if (item.Length < 1 || item.Length > 100)
                        {
                            ProverkaOK = false;
                            MessageBox.Show("Помилка у складанні відповіді №" + a + " ( довжина відповіді -від 1 до 100 символів))");
                        }
                    }
                    if (!ProverkaOK)
                    {
                        Step--;
                    }
                    else NewTest.SetAnswer(this.richTextBox3.Lines);

                    if (ProverkaOK)
                    {//новий шаг
                        this.groupBox3.Visible = false;
                        
                        TestForm tf = new TestForm(NewTest);
                        this.Visible = false;
                        if (tf.ShowDialog() == DialogResult.OK)
                        {
                            this.Visible = true;
                            //интерфейс следующего шага
                            this.groupBox3.Visible = false;
                            this.buttonNext.Text = "Зберегти тест";
                            this.groupBox4.Visible = true;
                            this.groupBox4.Text  = "Шаг 5";
                            this.textBox4.SelectAll();
                            this.textBox4.Focus(); 

                        
                   
                   Array MoA = new Array[NewTest.GetAnswerMatr().GetLength(0), NewTest.GetAnswerMatr().GetLength(1)];
                   MoA = NewTest.GetAnswerMatr();
                   int pravilnih = 0;
                   foreach (bool item in MoA) if (item) pravilnih++;


                   //матрица оценивания по умолчанию
                   int [,] MatrOfMark = this.setting.GetMatrixOfMark();
                   this.dataGridView1.Rows.Clear();
                   this.dataGridView1.Rows.Add("Правильно всі", MatrOfMark.GetValue(0, 0), MatrOfMark.GetValue(0, 1), MatrOfMark.GetValue(0, 2), MatrOfMark.GetValue(0, 3), MatrOfMark.GetValue(0, 4), MatrOfMark.GetValue(0, 5), MatrOfMark.GetValue(0, 6), MatrOfMark.GetValue(0, 7), MatrOfMark.GetValue(0, 8), MatrOfMark.GetValue(0, 9), MatrOfMark.GetValue(0, 10));
                   if (pravilnih > 1) this.dataGridView1.Rows.Add("Правильно:"+ (pravilnih-1), MatrOfMark.GetValue(1, 0), MatrOfMark.GetValue(1, 1), MatrOfMark.GetValue(1, 2), MatrOfMark.GetValue(1, 3), MatrOfMark.GetValue(1, 4), MatrOfMark.GetValue(1, 5), MatrOfMark.GetValue(1, 6), MatrOfMark.GetValue(1, 7), MatrOfMark.GetValue(1, 8), MatrOfMark.GetValue(1, 9), MatrOfMark.GetValue(1, 10));
                   if (pravilnih > 2) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih-2), MatrOfMark.GetValue(2, 0), MatrOfMark.GetValue(2, 1), MatrOfMark.GetValue(2, 2), MatrOfMark.GetValue(2, 3), MatrOfMark.GetValue(2, 4), MatrOfMark.GetValue(2, 5), MatrOfMark.GetValue(2, 6), MatrOfMark.GetValue(2, 7), MatrOfMark.GetValue(2, 8), MatrOfMark.GetValue(2, 9), MatrOfMark.GetValue(2, 10));
                   if (pravilnih > 3) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih-3), MatrOfMark.GetValue(3, 0), MatrOfMark.GetValue(3, 1), MatrOfMark.GetValue(3, 2), MatrOfMark.GetValue(3, 3), MatrOfMark.GetValue(3, 4), MatrOfMark.GetValue(3, 5), MatrOfMark.GetValue(3, 6), MatrOfMark.GetValue(3, 7), MatrOfMark.GetValue(3, 8), MatrOfMark.GetValue(3, 9), MatrOfMark.GetValue(3, 10));
                   if (pravilnih > 4) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih-4), MatrOfMark.GetValue(4, 0), MatrOfMark.GetValue(4, 1), MatrOfMark.GetValue(4, 2), MatrOfMark.GetValue(4, 3), MatrOfMark.GetValue(4, 4), MatrOfMark.GetValue(4, 5), MatrOfMark.GetValue(4, 6), MatrOfMark.GetValue(4, 7), MatrOfMark.GetValue(4, 8), MatrOfMark.GetValue(4, 9), MatrOfMark.GetValue(4, 10));
                   if (pravilnih > 5) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih-5), MatrOfMark.GetValue(5, 0), MatrOfMark.GetValue(5, 1), MatrOfMark.GetValue(5, 2), MatrOfMark.GetValue(5, 3), MatrOfMark.GetValue(5, 4), MatrOfMark.GetValue(5, 5), MatrOfMark.GetValue(5, 6), MatrOfMark.GetValue(5, 7), MatrOfMark.GetValue(5, 8), MatrOfMark.GetValue(5, 9), MatrOfMark.GetValue(5, 10));

                   for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
                       for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
                           if (dataGridView1.Rows[j].Cells[i].Value.ToString() == "-1") dataGridView1.Rows[j].Cells[i].Value = "-";
                   this.dataGridView1.Columns[0].ReadOnly = true;
               }
                       else
                       {
                           this.Visible = true;
                           Step--;
                           this.groupBox3.Visible = true;
                           this.label10.Text = NewTest.GetNameOfAnswer() + ":";
                           this.richTextBox3.Focus();
                       }
                   }
              }
              if (Step == 5)
              {
                  //введення часу на тест та матриці оцінювання
                  if ((Convert.ToInt32(this.textBox4.Text)) > 10) NewTest.SetTimeForTest(Convert.ToInt32(this.textBox4.Text));
                  else
                  {
                      MessageBox.Show("Час для проходження тесту не введено. Введіть його!");
                      Step--;
                  }
                  //проверка наличия значений в матрице оценивания
                 int[,] MatrOfMark = new int[6,11];
                 int value=0;
                 bool OK = true;
                 for (int a=0;a<this.dataGridView1.Rows.Count;a++)
                      for (int b = 1; b < this.dataGridView1.Columns.Count; b++)
                      {
                          if (this.dataGridView1.Rows[a].Cells[b].Value == null)
                          {
                              MessageBox.Show("Ячейка (" + a + "," + (b - 1) + ") не заповнена");
                              this.dataGridView1.Rows[a].Cells[b].Value = "-";
                              OK = false;
                          }
                          if(this.dataGridView1.Rows[a].Cells[b].Value.ToString().Equals("-")) value=-1;
                          else {
                          try
                          {
                              value=Convert.ToInt32(this.dataGridView1.Rows[a].Cells[b].Value);
                          }
                          catch (System.ArgumentNullException) {
                                MessageBox.Show ("Ячейка ("+a+","+(b-1)+") не заповнена");
                                OK = false;
                                    }
                          catch (System.FormatException) {
                              MessageBox.Show("Ячейка (" + a + "," + (b - 1) + ") заповнена не числом");
                             OK = false;
                                    } 
                           catch (System.OverflowException) {
                               MessageBox.Show("Ячейка (" + a + "," + (b - 1) + ") поза інтервалом");
                             OK = false;
                                    }
                              finally 
                          {this.dataGridView1.Rows[a].Cells[b].Selected=true;}
                          }

                          if (value>=-1&&value<=99) MatrOfMark[a,b-1]=value;
                          else MessageBox.Show("Ячейка (" + a + "," + (b - 1) + ") заповнена поза інтервалом");
                          
                      }


                  //внесение в матрицу
                  if (OK)
                  {
                      NewTest.SetMatrixOfMark(MatrOfMark);
                      //


                      this.saveFileDialogTest.FileName = this.textBox1.Text;
                      if (this.saveFileDialogTest.ShowDialog() == DialogResult.OK)
                      {
                          MessageBox.Show("Файл тесту збережено!");
                          this.Close();
                      }
                      else Step--;
                  }
                  else Step--;




              }


            //
            //колекция тестов
            //
            //
              if (Step == 10)
              {
                  COF=new CollectionOfTest(); //не более 10 тестов в коллекции
                  //интерфейс
                  this.groupBox5.Visible = true;
                  this.listBox1.Items.Clear();
                  this.buttonReturn.Text = "Назад";

              }
              if (Step == 20)
              {
                  //интерфейс
                  if (this.listBox1.Items.Count > 1)
                  {
                      this.groupBox5.Visible = false;
                      this.groupBox6.Visible = true;
                      this.radioButton4.Checked = true;
                  }
                  else
                  {
                      MessageBox.Show("До колекції не додано 2 і більше тестів");
                      Step -= 10;
                  }
              }
              if (Step == 30)
              {
                  //интерфейс
                  if (this.radioButton4.Checked)//заг. кількість балів
                  {
                      COF.SetHowMark(0);
                      
                      if (saveFileDialogCollection.ShowDialog() == DialogResult.OK)
                      {

                          MessageBox.Show("Файл колекції збережено");
                          this.Close();
                      }
                  }
                  if (this.radioButton5.Checked)
                  {
                      COF.SetHowMark(1);
                      
                      if (saveFileDialogCollection.ShowDialog() == DialogResult.OK)
                      {

                          MessageBox.Show("Файл колекції збережено");
                          this.Close();
                      }
                  }
                  if (this.radioButton6.Checked||this.radioButton7.Checked) 
                  {
                      if (this.radioButton6.Checked)COF.SetHowMark(2);
                      else COF.SetHowMark(3);
                      this.groupBox6.Visible = false;
                      this.groupBox4.Visible = true;
                      groupBox4.Text = "Шаг 3";
                      this.textBox4.Visible = false;
                      this.label12.Visible = false;


                      System.Collections.ArrayList AoT = COF.GetTests();

                      if (AoT.Count > 1)
                      {
                          this.NewTest=(Test)AoT[0];
                          this.label11.Text = "Змініть оцінки тесту \"" + NewTest.ToString()+"\"";
                          

                   Array Matrix = new Array[NewTest.GetAnswerMatr().GetLength(0), NewTest.GetAnswerMatr().GetLength(1)];
                   Matrix = NewTest.GetAnswerMatr();
                   int pravilnih = 0;
                   foreach (bool item in Matrix) if (item) pravilnih++;

                          Array MoM = new Array[NewTest.GetMatrixOfMark().GetLength(0), NewTest.GetMatrixOfMark().GetLength(1)];
                          MoM = NewTest.GetMatrixOfMark() ;
                          this.dataGridView1.Rows.Clear();
                          this.dataGridView1.Rows.Add("Правильно всі", MoM.GetValue(0, 0), MoM.GetValue(0, 1), MoM.GetValue(0, 2), MoM.GetValue(0, 3), MoM.GetValue(0, 4), MoM.GetValue(0, 5), MoM.GetValue(0, 6), MoM.GetValue(0, 7), MoM.GetValue(0, 8), MoM.GetValue(0, 9), MoM.GetValue(0, 10));
                          if (pravilnih > 1) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 1), MoM.GetValue(1, 0), MoM.GetValue(1, 1), MoM.GetValue(1, 2), MoM.GetValue(1, 3), MoM.GetValue(1, 4), MoM.GetValue(1, 5), MoM.GetValue(1, 6), MoM.GetValue(1, 7), MoM.GetValue(1, 8), MoM.GetValue(1, 9), MoM.GetValue(1, 10));
                          if (pravilnih > 2) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 2),  MoM.GetValue(2,0),MoM.GetValue(2,1),MoM.GetValue(2,2),MoM.GetValue(2,3),MoM.GetValue(2,4),MoM.GetValue(2,5),MoM.GetValue(2,6),MoM.GetValue(2,7),MoM.GetValue(2,8),MoM.GetValue(2,9),MoM.GetValue(2,10));
                          if (pravilnih > 3) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 3),  MoM.GetValue(3,0),MoM.GetValue(3,1),MoM.GetValue(3,2),MoM.GetValue(3,3),MoM.GetValue(3,4),MoM.GetValue(3,5),MoM.GetValue(3,6),MoM.GetValue(3,7),MoM.GetValue(3,8),MoM.GetValue(3,9),MoM.GetValue(3,10));
                          if (pravilnih > 4) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 4),  MoM.GetValue(4,0),MoM.GetValue(4,1),MoM.GetValue(4,2),MoM.GetValue(4,3),MoM.GetValue(4,4),MoM.GetValue(4,5),MoM.GetValue(4,6),MoM.GetValue(4,7),MoM.GetValue(4,8),MoM.GetValue(4,9),MoM.GetValue(4,10));
                          if (pravilnih > 5) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 5),  MoM.GetValue(5,0),MoM.GetValue(5,1),MoM.GetValue(5,2),MoM.GetValue(5,3),MoM.GetValue(5,4),MoM.GetValue(5,5),MoM.GetValue(5,6),MoM.GetValue(5,7),MoM.GetValue(5,8),MoM.GetValue(5,9),MoM.GetValue(5,10));

                          for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
                              for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
                                  if (dataGridView1.Rows[j].Cells[i].Value.ToString()== "-1") dataGridView1.Rows[j].Cells[i].Value = "-";
                          this.dataGridView1.Columns[0].ReadOnly = true;

                          Step -= 9; //с 30 делает 21
                          
                      }
                    
                  }
              }
              if (Step > 30 && Step < 100) //10 - предідущие 9
              {
                  //сначала запомним єтот
                  //проверка наличия значений в матрице оценивания
                  int[,] MatrOfMark = new int[6, 11];
                  int value = 0;
                  bool OK = true;
                  for (int a = 0; a < this.dataGridView1.Rows.Count; a++)
                      for (int b = 1; b < this.dataGridView1.Columns.Count; b++)
                      {
                          if (this.dataGridView1.Rows[a].Cells[b].Value == null)
                          {
                              MessageBox.Show("Ячейка (" + a + "," + (b - 1) + ") не заповнена");
                              this.dataGridView1.Rows[a].Cells[b].Value = "-";
                              OK = false;
                          }
                          if (this.dataGridView1.Rows[a].Cells[b].Value.ToString().Equals("-")) value = -1;
                          else
                          {
                              try
                              {
                                  value = Convert.ToInt32(this.dataGridView1.Rows[a].Cells[b].Value);
                              }
                              catch (System.ArgumentNullException)
                              {
                                  MessageBox.Show("Ячейка (" + a + "," + (b - 1) + ") не заповнена");
                                  OK = false;
                              }
                              catch (System.FormatException)
                              {
                                  MessageBox.Show("Ячейка (" + a + "," + (b - 1) + ") заповнена не числом");
                                  OK = false;
                              }
                              catch (System.OverflowException)
                              {
                                  MessageBox.Show("Ячейка (" + a + "," + (b - 1) + ") поза інтервалом");
                                  OK = false;
                              }
                              finally
                              { this.dataGridView1.Rows[a].Cells[b].Selected = true; }
                          }

                          if (value >= -1 && value <= 99) MatrOfMark[a, b - 1] = value;
                          else MessageBox.Show("Ячейка (" + a + "," + (b - 1) + ") заповнена поза інтервалом");

                      }


                  
                  if (OK)
                  {
                      this.NewTest.SetMatrixOfMark(MatrOfMark);
                      //и нарисуем следующий
                      int index = Step - 30;
                      System.Collections.ArrayList AoT = COF.GetTests();
                      AoT[index - 1] = NewTest;


                      if (index > 0 && index < AoT.Count)
                      {
                          NewTest = (Test)AoT[index];
                          this.label11.Text = "Змініть оцінки тесту \"" + NewTest.ToString() + "\"";


                          Array Matrix = new Array[NewTest.GetAnswerMatr().GetLength(0), NewTest.GetAnswerMatr().GetLength(1)];
                          Matrix = NewTest.GetAnswerMatr();
                          int pravilnih = 0;
                          foreach (bool item in Matrix) if (item) pravilnih++;

                          Array MoM = new Array[NewTest.GetMatrixOfMark().GetLength(0), NewTest.GetMatrixOfMark().GetLength(1)];
                          MoM = NewTest.GetMatrixOfMark();

                          this.dataGridView1.Rows.Clear();
                          this.dataGridView1.Rows.Add("Правильно всі", MoM.GetValue(0, 0), MoM.GetValue(0, 1), MoM.GetValue(0, 2), MoM.GetValue(0, 3), MoM.GetValue(0, 4), MoM.GetValue(0, 5), MoM.GetValue(0, 6), MoM.GetValue(0, 7), MoM.GetValue(0, 8), MoM.GetValue(0, 9), MoM.GetValue(0, 10));
                          if (pravilnih > 1) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 1), MoM.GetValue(1, 0), MoM.GetValue(1, 1), MoM.GetValue(1, 2), MoM.GetValue(1, 3), MoM.GetValue(1, 4), MoM.GetValue(1, 5), MoM.GetValue(1, 6), MoM.GetValue(1, 7), MoM.GetValue(1, 8), MoM.GetValue(1, 9), MoM.GetValue(1, 10));
                          if (pravilnih > 2) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 2), MoM.GetValue(2, 0), MoM.GetValue(2, 1), MoM.GetValue(2, 2), MoM.GetValue(2, 3), MoM.GetValue(2, 4), MoM.GetValue(2, 5), MoM.GetValue(2, 6), MoM.GetValue(2, 7), MoM.GetValue(2, 8), MoM.GetValue(2, 9), MoM.GetValue(2, 10));
                          if (pravilnih > 3) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 3), MoM.GetValue(3, 0), MoM.GetValue(3, 1), MoM.GetValue(3, 2), MoM.GetValue(3, 3), MoM.GetValue(3, 4), MoM.GetValue(3, 5), MoM.GetValue(3, 6), MoM.GetValue(3, 7), MoM.GetValue(3, 8), MoM.GetValue(3, 9), MoM.GetValue(3, 10));
                          if (pravilnih > 4) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 4), MoM.GetValue(4, 0), MoM.GetValue(4, 1), MoM.GetValue(4, 2), MoM.GetValue(4, 3), MoM.GetValue(4, 4), MoM.GetValue(4, 5), MoM.GetValue(4, 6), MoM.GetValue(4, 7), MoM.GetValue(4, 8), MoM.GetValue(4, 9), MoM.GetValue(4, 10));
                          if (pravilnih > 5) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 5), MoM.GetValue(5, 0), MoM.GetValue(5, 1), MoM.GetValue(5, 2), MoM.GetValue(5, 3), MoM.GetValue(5, 4), MoM.GetValue(5, 5), MoM.GetValue(5, 6), MoM.GetValue(5, 7), MoM.GetValue(5, 8), MoM.GetValue(5, 9), MoM.GetValue(5, 10));

                          for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
                              for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
                                  if (dataGridView1.Rows[j].Cells[i].Value.ToString() == "-1") dataGridView1.Rows[j].Cells[i].Value = "-";
                          this.dataGridView1.Columns[0].ReadOnly = true;

                          Step -= 9; //с 31 делает 22

                      }
                      else if (saveFileDialogCollection.ShowDialog() == DialogResult.OK)
                      {

                          MessageBox.Show("Файл колекції збережено");
                          this.Close();
                      }
                      else Step -= 10;
                  }

                  else Step -= 10;
              }
            
            //изменения коллекции или теста
              if (Step == 100)
              {
                  this.openFileDialogTest.InitialDirectory = Path.GetFullPath("Tests");
                  if (openFileDialogTestAndCollection.ShowDialog() != DialogResult.OK) Step -= 100;
                  else //если откріли, изменяем тест 
                      if (Step == 100) //тест
                      {
                          this.groupBox0.Visible = false;
                          this.groupBox1.Visible = true;
                          this.buttonReturn.Text = "Назад";
                          this.textBox1.Text = this.NewTest.GetNameOfTest();
                          this.textBox1.SelectAll();
                          this.textBox2.Text = this.NewTest.GetNameOfQuestion();
                          this.textBox3.Text = this.NewTest.GetNameOfAnswer();
                          this.textBox1.Focus();

                      }
                     if (Step == 1000) //Колекция
                        {
                            this.groupBox5.Visible = true;
                            this.buttonReturn.Text = "Назад";
                            listBox1.Items.Clear();
                         COF.AddTestInListBox(this.listBox1);

                        }
              }
              if (Step == 200)
              {
                  this.buttonNext.Text = "Далі";
                  if (this.textBox1.Text.Length > 0) NewTest.SetNameOfTest(this.textBox1.Text);
                  else
                  {
                      MessageBox.Show("Назва тесту не введена! Введіть нову назву!");
                      this.textBox1.Focus();
                      Step-=100;
                  }
                  if (this.textBox2.Text.Length > 0 && this.textBox2.Text.Length < 28) NewTest.SetNameOfQuestion(this.textBox2.Text);
                  else
                  {
                      if (this.textBox2.Text.Length > 27) MessageBox.Show("Назва запитань більша за 27 символів, зменшіть назву!");
                      else MessageBox.Show("Назва запитань не введена! Введіть нову назву запитань!");
                      this.textBox2.Text = "ЗАПИТАННЯ";
                      this.textBox2.SelectAll();
                      this.textBox2.Focus();
                      Step-=100;
                  }
                  if (this.textBox3.Text.Length > 0 && this.textBox3.Text.Length < 28) NewTest.SetNameOfAnswer(this.textBox3.Text);
                  else
                  {
                      if (this.textBox3.Text.Length > 27) MessageBox.Show("Назва відповідей більша за 27 символів, зменшіть назву!");
                      else MessageBox.Show("Назва відповідей не введена! Введіть нову назву відповідей!");
                      this.textBox3.Text = "ВІДПОВІДІ";
                      this.textBox3.SelectAll();
                      this.textBox3.Focus();
                      Step-=100;
                  }


                  //интерфейс
                  if (Step == 200)
                  {//второй шаг!
                      this.buttonNext.Text = "Далі";
                      this.groupBox1.Visible = false;
                      this.groupBox2.Visible = true;
                      this.label1.Text = NewTest.GetNameOfQuestion() + ":";
                      string[] ArrayOfLines = new string[this.NewTest.GetQuestion().Count];
                      int i=0;
                      foreach (string item in this.NewTest.GetQuestion())
                      {
                          ArrayOfLines.SetValue(item, i);
                          i++;
                      }
                      this.richTextBox2.Lines = ArrayOfLines;
                      this.richTextBox2.Refresh(); 
                      this.richTextBox2.SelectAll();
                      this.richTextBox2.Focus();
                  }
              }
              //перевірка та третій шаг   
              if (Step == 300)
              {
                  this.buttonNext.Text = "Далі";
                  bool ProverkaOK = true;
                  if (this.richTextBox2.Lines.Length < 1)
                  {
                      ProverkaOK = false;
                      MessageBox.Show("Помилка у складанні запитань (максимальна кількість запитань -  не менше 1)");
                  }
                  if (this.richTextBox2.Lines.Length > 10)
                  {
                      ProverkaOK = false;
                      MessageBox.Show("Помилка у складанні запитань (максимальна кількість запитань -  не більше 10)");
                  }
                  int a = 0;
                  foreach (string item in this.richTextBox2.Lines)
                  {
                      a++;
                      if (item.Length < 1 || item.Length > 100)
                      {
                          ProverkaOK = false;
                          MessageBox.Show("Помилка у складанні запитання №" + a + " ( довжина запитання -від 1 до 100 символів))");
                      }
                  }
                  if (!ProverkaOK)
                  {
                      Step-=100;
                  }
                  else NewTest.SetQuestion(this.richTextBox2.Lines);

                  if (ProverkaOK)
                  {//новий шаг
                      this.groupBox2.Visible = false;
                      this.groupBox3.Visible = true;
                      this.label10.Text = NewTest.GetNameOfAnswer() + ":";
                      string[] ArrayOfLines = new string[this.NewTest.GetAnswer().Count];
                      int i=0;
                      foreach (string item in this.NewTest.GetAnswer())
                      {
                          ArrayOfLines.SetValue(item, i);
                          i++;
                      }
                      this.richTextBox3.Lines = ArrayOfLines;
                      this.richTextBox3.Refresh(); 
                      this.richTextBox3.SelectAll();
                      this.richTextBox3.Focus();
                  }


              }
              //перевірка та четвертий шаг   
              if (Step == 400)
              {
                  this.buttonNext.Text = "Далі";
                  bool ProverkaOK = true;
                  if (this.richTextBox3.Lines.Length < 1)
                  {
                      ProverkaOK = false;
                      MessageBox.Show("Помилка у складанні відповідей (максимальна кількість відповідей не менше 1)");
                  }
                  if (this.richTextBox3.Lines.Length > 10)
                  {
                      ProverkaOK = false;
                      MessageBox.Show("Помилка у складанні відповідей (максимальна кількість відповідей не більше 10)");
                  }
                  int a = 0;
                  foreach (string item in this.richTextBox3.Lines)
                  {
                      a++;
                      if (item.Length < 1 || item.Length > 100)
                      {
                          ProverkaOK = false;
                          MessageBox.Show("Помилка у складанні відповіді №" + a + " ( довжина відповіді -від 1 до 100 символів))");
                      }
                  }
                  if (!ProverkaOK)
                  {
                      Step-=100;
                  }
                  else NewTest.SetAnswer(this.richTextBox3.Lines);

                  if (ProverkaOK)
                  {//новий шаг
                      this.groupBox3.Visible = false;
                      TestForm tf = new TestForm(NewTest);
                      this.Visible = false;
                      if (tf.ShowDialog() == DialogResult.OK)
                      {
                          this.Visible = true;
                          //интерфейс следующего шага
                          this.groupBox3.Visible = false;
                          this.buttonNext.Text = "Зберегти тест";
                          this.groupBox4.Visible = true;
                          groupBox4.Text = "Шаг 5";
                          this.textBox4.SelectAll();
                          this.textBox4.Focus();

                      }
                      else
                      {
                          this.Visible = true;
                          Step-=100;
                          this.groupBox3.Visible = true;
                          this.label10.Text = NewTest.GetNameOfAnswer() + ":";
                          string[] ArrayOfLines = new string[this.NewTest.GetAnswer().Count];
                          int i=0;
                          foreach (string item in this.NewTest.GetAnswer())
                          {
                              ArrayOfLines.SetValue(item, i);
                              i++;
                          }
                          this.richTextBox3.Lines = ArrayOfLines;
                          this.richTextBox3.Refresh(); 
                          this.richTextBox3.SelectAll();
                          this.richTextBox3.Focus();
                      }
                  }

                  this.textBox4.Text=NewTest.GetTimeForTest().ToString();
                  Array Matrix = new Array[NewTest.GetAnswerMatr().GetLength(0), NewTest.GetAnswerMatr().GetLength(1)];
                  Matrix = NewTest.GetAnswerMatr();
                  int pravilnih = 0;
                  foreach (bool item in Matrix) if (item) pravilnih++;

                  Array MoM = new Array[NewTest.GetMatrixOfMark().GetLength(0), NewTest.GetMatrixOfMark().GetLength(1)];
                  MoM = NewTest.GetMatrixOfMark();
                  this.dataGridView1.Rows.Clear();
                  this.dataGridView1.Rows.Add("Правильно всі", MoM.GetValue(0, 0), MoM.GetValue(0, 1), MoM.GetValue(0, 2), MoM.GetValue(0, 3), MoM.GetValue(0, 4), MoM.GetValue(0, 5), MoM.GetValue(0, 6), MoM.GetValue(0, 7), MoM.GetValue(0, 8), MoM.GetValue(0, 9), MoM.GetValue(0, 10));
                  if (pravilnih > 1) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 1), MoM.GetValue(1, 0), MoM.GetValue(1, 1), MoM.GetValue(1, 2), MoM.GetValue(1, 3), MoM.GetValue(1, 4), MoM.GetValue(1, 5), MoM.GetValue(1, 6), MoM.GetValue(1, 7), MoM.GetValue(1, 8), MoM.GetValue(1, 9), MoM.GetValue(1, 10));
                  if (pravilnih > 2) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 2), MoM.GetValue(2, 0), MoM.GetValue(2, 1), MoM.GetValue(2, 2), MoM.GetValue(2, 3), MoM.GetValue(2, 4), MoM.GetValue(2, 5), MoM.GetValue(2, 6), MoM.GetValue(2, 7), MoM.GetValue(2, 8), MoM.GetValue(2, 9), MoM.GetValue(2, 10));
                  if (pravilnih > 3) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 3), MoM.GetValue(3, 0), MoM.GetValue(3, 1), MoM.GetValue(3, 2), MoM.GetValue(3, 3), MoM.GetValue(3, 4), MoM.GetValue(3, 5), MoM.GetValue(3, 6), MoM.GetValue(3, 7), MoM.GetValue(3, 8), MoM.GetValue(3, 9), MoM.GetValue(3, 10));
                  if (pravilnih > 4) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 4), MoM.GetValue(4, 0), MoM.GetValue(4, 1), MoM.GetValue(4, 2), MoM.GetValue(4, 3), MoM.GetValue(4, 4), MoM.GetValue(4, 5), MoM.GetValue(4, 6), MoM.GetValue(4, 7), MoM.GetValue(4, 8), MoM.GetValue(4, 9), MoM.GetValue(4, 10));
                  if (pravilnih > 5) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 5), MoM.GetValue(5, 0), MoM.GetValue(5, 1), MoM.GetValue(5, 2), MoM.GetValue(5, 3), MoM.GetValue(5, 4), MoM.GetValue(5, 5), MoM.GetValue(5, 6), MoM.GetValue(5, 7), MoM.GetValue(5, 8), MoM.GetValue(5, 9), MoM.GetValue(5, 10));

                  for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
                      for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
                          if (dataGridView1.Rows[j].Cells[i].Value.ToString() == "-1") dataGridView1.Rows[j].Cells[i].Value = "-";
                  this.dataGridView1.Columns[0].ReadOnly = true;

                  
              }
             if (Step == 500)
              {
                  //введення часу на тест та матриці оцінювання
                  if ((Convert.ToInt32(this.textBox4.Text)) > 10) NewTest.SetTimeForTest(Convert.ToInt32(this.textBox4.Text));
                  else
                  {
                      MessageBox.Show("Час для проходження тесту не введено. Введіть його!");
                      Step-=100;
                  }
                  //проверка наличия значений в матрице оценивания
                  int[,] MatrOfMark = new int[6, 11];
                  int value = 0;
                  bool OK = true;
                  for (int a = 0; a < this.dataGridView1.Rows.Count; a++)
                      for (int b = 1; b < this.dataGridView1.Columns.Count; b++)
                      {
                          if (this.dataGridView1.Rows[a].Cells[b].Value == null)
                          {
                              MessageBox.Show("Ячейка (" + a + "," + (b - 1) + ") не заповнена");
                              this.dataGridView1.Rows[a].Cells[b].Value = "-";
                              OK = false;
                          }
                          if (this.dataGridView1.Rows[a].Cells[b].Value.ToString().Equals("-")) value = -1;
                          else
                          {
                              try
                              {
                                  value = Convert.ToInt32(this.dataGridView1.Rows[a].Cells[b].Value);
                              }
                              catch (System.ArgumentNullException)
                              {
                                  MessageBox.Show("Ячейка (" + a + "," + (b - 1) + ") не заповнена");
                                  OK = false;
                              }
                              catch (System.FormatException)
                              {
                                  MessageBox.Show("Ячейка (" + a + "," + (b - 1) + ") заповнена не числом");
                                  OK = false;
                              }
                              catch (System.OverflowException)
                              {
                                  MessageBox.Show("Ячейка (" + a + "," + (b - 1) + ") поза інтервалом");
                                  OK = false;
                              }
                              finally
                              { this.dataGridView1.Rows[a].Cells[b].Selected = true; }
                          }

                          if (value >= -1 && value <= 99) MatrOfMark[a, b - 1] = value;
                          else MessageBox.Show("Ячейка (" + a + "," + (b - 1) + ") заповнена поза інтервалом");

                      }
                  //внесение в матрицу
                  if (OK)
                  {
                      NewTest.SetMatrixOfMark(MatrOfMark);
                      this.saveFileDialogTest.FileName = this.textBox1.Text;
                      if (this.saveFileDialogTest.ShowDialog() == DialogResult.OK)
                      {
                          MessageBox.Show("Файл тесту збережено!");
                          this.Close();
                      }
                      else Step-=100;
                  }
                  else Step-=100;
              }

              if (Step == 1100)
              {
                  //интерфейс
                  if (this.listBox1.Items.Count > 1)
                  {
                      this.groupBox5.Visible = false;
                      this.groupBox4.Visible = false;
                      this.groupBox6.Visible = true;
                      int HowMark = COF.GetHowMark();
                      if (HowMark == 0) this.radioButton4.Checked = true;
                      else if (HowMark == 1) this.radioButton5.Checked = true;
                      else if (HowMark == 2) this.radioButton6.Checked = true;
                      else this.radioButton7.Checked = true;

                  }
                  else
                  {
                      MessageBox.Show("До колекції не додано 2 і більше тестів");
                      Step -= 100;
                  }
              }
              if (Step == 1200)
              {
                  //интерфейс
                  if (this.radioButton4.Checked)//заг. кількість балів
                  {
                      COF.SetHowMark(0);
                      saveFileDialogCollection.ShowDialog();
                      this.Close();
                  }
                  if (this.radioButton5.Checked)
                  {
                      COF.SetHowMark(1);
                      saveFileDialogCollection.ShowDialog();
                      this.Close();
                  }
                  if (this.radioButton6.Checked || this.radioButton7.Checked)
                  {
                      if (this.radioButton6.Checked) COF.SetHowMark(2);
                      else COF.SetHowMark(3);
                      this.groupBox6.Visible = false;
                      this.groupBox5.Visible = false;
                      this.groupBox4.Visible = true;
                      groupBox4.Text = "Шаг 3";
                      this.textBox4.Visible = false;
                      this.label12.Visible = false;


                      System.Collections.ArrayList AoT = COF.GetTests();

                      if (AoT.Count > 1)
                      {
                          this.NewTest = (Test)AoT[0];
                          this.label11.Text = "Змініть оцінки тесту \"" + NewTest.ToString() + "\"";


                          Array Matrix = new Array[NewTest.GetAnswerMatr().GetLength(0), NewTest.GetAnswerMatr().GetLength(1)];
                          Matrix = NewTest.GetAnswerMatr();
                          int pravilnih = 0;
                          foreach (bool item in Matrix) if (item) pravilnih++;

                          Array MoM = new Array[NewTest.GetMatrixOfMark().GetLength(0), NewTest.GetMatrixOfMark().GetLength(1)];
                          MoM = NewTest.GetMatrixOfMark();
                          this.dataGridView1.Rows.Clear();
                          this.dataGridView1.Rows.Add("Правильно всі", MoM.GetValue(0, 0), MoM.GetValue(0, 1), MoM.GetValue(0, 2), MoM.GetValue(0, 3), MoM.GetValue(0, 4), MoM.GetValue(0, 5), MoM.GetValue(0, 6), MoM.GetValue(0, 7), MoM.GetValue(0, 8), MoM.GetValue(0, 9), MoM.GetValue(0, 10));
                          if (pravilnih > 1) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 1), MoM.GetValue(1, 0), MoM.GetValue(1, 1), MoM.GetValue(1, 2), MoM.GetValue(1, 3), MoM.GetValue(1, 4), MoM.GetValue(1, 5), MoM.GetValue(1, 6), MoM.GetValue(1, 7), MoM.GetValue(1, 8), MoM.GetValue(1, 9), MoM.GetValue(1, 10));
                          if (pravilnih > 2) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 2), MoM.GetValue(2, 0), MoM.GetValue(2, 1), MoM.GetValue(2, 2), MoM.GetValue(2, 3), MoM.GetValue(2, 4), MoM.GetValue(2, 5), MoM.GetValue(2, 6), MoM.GetValue(2, 7), MoM.GetValue(2, 8), MoM.GetValue(2, 9), MoM.GetValue(2, 10));
                          if (pravilnih > 3) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 3), MoM.GetValue(3, 0), MoM.GetValue(3, 1), MoM.GetValue(3, 2), MoM.GetValue(3, 3), MoM.GetValue(3, 4), MoM.GetValue(3, 5), MoM.GetValue(3, 6), MoM.GetValue(3, 7), MoM.GetValue(3, 8), MoM.GetValue(3, 9), MoM.GetValue(3, 10));
                          if (pravilnih > 4) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 4), MoM.GetValue(4, 0), MoM.GetValue(4, 1), MoM.GetValue(4, 2), MoM.GetValue(4, 3), MoM.GetValue(4, 4), MoM.GetValue(4, 5), MoM.GetValue(4, 6), MoM.GetValue(4, 7), MoM.GetValue(4, 8), MoM.GetValue(4, 9), MoM.GetValue(4, 10));
                          if (pravilnih > 5) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 5), MoM.GetValue(5, 0), MoM.GetValue(5, 1), MoM.GetValue(5, 2), MoM.GetValue(5, 3), MoM.GetValue(5, 4), MoM.GetValue(5, 5), MoM.GetValue(5, 6), MoM.GetValue(5, 7), MoM.GetValue(5, 8), MoM.GetValue(5, 9), MoM.GetValue(5, 10));

                          for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
                              for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
                                  if (dataGridView1.Rows[j].Cells[i].Value.ToString() == "-1") dataGridView1.Rows[j].Cells[i].Value = "-";
                          this.dataGridView1.Columns[0].ReadOnly = true;

                          Step -= 90; //с 1200 делает 1110

                      }

                  }
              }
              if (Step > 1200 && Step < 1310) //10 - предідущие 9
              {
                  //сначала запомним єтот
                  //проверка наличия значений в матрице оценивания
                  int[,] MatrOfMark = new int[6, 11];
                  int value = 0;
                  bool OK = true;
                  for (int a = 0; a < this.dataGridView1.Rows.Count; a++)
                      for (int b = 1; b < this.dataGridView1.Columns.Count; b++)
                      {
                          if (this.dataGridView1.Rows[a].Cells[b].Value == null)
                          {
                              MessageBox.Show("Ячейка (" + a + "," + (b - 1) + ") не заповнена");
                              this.dataGridView1.Rows[a].Cells[b].Value = "-";
                              OK = false;
                          }
                          if (this.dataGridView1.Rows[a].Cells[b].Value.ToString().Equals("-")) value = -1;
                          else
                          {
                              try
                              {
                                  value = Convert.ToInt32(this.dataGridView1.Rows[a].Cells[b].Value);
                              }
                              catch (System.ArgumentNullException)
                              {
                                  MessageBox.Show("Ячейка (" + a + "," + (b - 1) + ") не заповнена");
                                  OK = false;
                              }
                              catch (System.FormatException)
                              {
                                  MessageBox.Show("Ячейка (" + a + "," + (b - 1) + ") заповнена не числом");
                                  OK = false;
                              }
                              catch (System.OverflowException)
                              {
                                  MessageBox.Show("Ячейка (" + a + "," + (b - 1) + ") поза інтервалом");
                                  OK = false;
                              }
                              finally
                              { this.dataGridView1.Rows[a].Cells[b].Selected = true; }
                          }

                          if (value >= -1 && value <= 99) MatrOfMark[a, b - 1] = value;
                          else MessageBox.Show("Ячейка (" + a + "," + (b - 1) + ") заповнена поза інтервалом");

                      }



                  if (OK)
                  {
                      this.NewTest.SetMatrixOfMark(MatrOfMark);
                      //и нарисуем следующий
                      int index = (Step - 1200) / 10;
                      System.Collections.ArrayList AoT = COF.GetTests();
                      AoT[index - 1] = NewTest;


                      if (index > 0 && index < AoT.Count)
                      {
                          NewTest = (Test)AoT[index];
                          this.label11.Text = "Змініть оцінки тесту \"" + NewTest.ToString() + "\"";


                          Array Matrix = new Array[NewTest.GetAnswerMatr().GetLength(0), NewTest.GetAnswerMatr().GetLength(1)];
                          Matrix = NewTest.GetAnswerMatr();
                          int pravilnih = 0;
                          foreach (bool item in Matrix) if (item) pravilnih++;

                          Array MoM = new Array[NewTest.GetMatrixOfMark().GetLength(0), NewTest.GetMatrixOfMark().GetLength(1)];
                          MoM = NewTest.GetMatrixOfMark();

                          this.dataGridView1.Rows.Clear();
                          this.dataGridView1.Rows.Add("Правильно всі", MoM.GetValue(0, 0), MoM.GetValue(0, 1), MoM.GetValue(0, 2), MoM.GetValue(0, 3), MoM.GetValue(0, 4), MoM.GetValue(0, 5), MoM.GetValue(0, 6), MoM.GetValue(0, 7), MoM.GetValue(0, 8), MoM.GetValue(0, 9), MoM.GetValue(0, 10));
                          if (pravilnih > 1) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 1), MoM.GetValue(1, 0), MoM.GetValue(1, 1), MoM.GetValue(1, 2), MoM.GetValue(1, 3), MoM.GetValue(1, 4), MoM.GetValue(1, 5), MoM.GetValue(1, 6), MoM.GetValue(1, 7), MoM.GetValue(1, 8), MoM.GetValue(1, 9), MoM.GetValue(1, 10));
                          if (pravilnih > 2) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 2), MoM.GetValue(2, 0), MoM.GetValue(2, 1), MoM.GetValue(2, 2), MoM.GetValue(2, 3), MoM.GetValue(2, 4), MoM.GetValue(2, 5), MoM.GetValue(2, 6), MoM.GetValue(2, 7), MoM.GetValue(2, 8), MoM.GetValue(2, 9), MoM.GetValue(2, 10));
                          if (pravilnih > 3) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 3), MoM.GetValue(3, 0), MoM.GetValue(3, 1), MoM.GetValue(3, 2), MoM.GetValue(3, 3), MoM.GetValue(3, 4), MoM.GetValue(3, 5), MoM.GetValue(3, 6), MoM.GetValue(3, 7), MoM.GetValue(3, 8), MoM.GetValue(3, 9), MoM.GetValue(3, 10));
                          if (pravilnih > 4) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 4), MoM.GetValue(4, 0), MoM.GetValue(4, 1), MoM.GetValue(4, 2), MoM.GetValue(4, 3), MoM.GetValue(4, 4), MoM.GetValue(4, 5), MoM.GetValue(4, 6), MoM.GetValue(4, 7), MoM.GetValue(4, 8), MoM.GetValue(4, 9), MoM.GetValue(4, 10));
                          if (pravilnih > 5) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 5), MoM.GetValue(5, 0), MoM.GetValue(5, 1), MoM.GetValue(5, 2), MoM.GetValue(5, 3), MoM.GetValue(5, 4), MoM.GetValue(5, 5), MoM.GetValue(5, 6), MoM.GetValue(5, 7), MoM.GetValue(5, 8), MoM.GetValue(5, 9), MoM.GetValue(5, 10));

                          for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
                              for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
                                  if (dataGridView1.Rows[j].Cells[i].Value.ToString() == "-1") dataGridView1.Rows[j].Cells[i].Value = "-";
                          this.dataGridView1.Columns[0].ReadOnly = true;

                          Step -= 90; //с 1310 делает 1220

                      }
                      else if (saveFileDialogCollection.ShowDialog() == DialogResult.OK)
                      {
                          MessageBox.Show("Файл колекції збережено");
                          this.Close();
                      }
                      else Step -= 100;
                  }

                  else Step -= 100;
              }
            



            



        }

        private void radioButton1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Enter)) this.buttonNext_Click(buttonNext, new EventArgs());
        }

        private void radioButton2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Enter)) this.buttonNext_Click(buttonNext, new EventArgs());

        }

        private void radioButton3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Enter)) this.buttonNext_Click(buttonNext, new EventArgs());

        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked) Step--;
            if (this.radioButton2.Checked) Step -= 10;
            if (this.radioButton3.Checked) Step -= 100;

            if (Step == -1||Step==-10||Step==-100) 
            {//спросить хочет ли выходить, если да - нафиг!!!
                string message = "Хочете вийти із Мастера?";
                string caption = "Чи Ви впевнені?";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);

                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
                else
                {
                    if (this.radioButton1.Checked) Step++;
                    if (this.radioButton2.Checked) Step+= 10;
                    if (this.radioButton3.Checked) Step += 100;
                }
                
            }
            if (Step == 0)
            {
                this.groupBox0.Visible = true;
                this.groupBox1.Visible = false;
                this.groupBox5.Visible = false;
                this.buttonReturn.Text = "Вихід";
                this.radioButton1.Checked = true;
            }
            if (Step == 1)
            {
                
                //интерфейс
                this.groupBox0.Visible = false;
                this.groupBox2.Visible = false;
                this.groupBox1.Visible = true;
                this.buttonReturn.Text = "Назад";
                this.buttonNext.Text = "Далі";
                this.textBox1.SelectAll();
                this.textBox2.SelectAll();
                this.textBox3.SelectAll();
                this.textBox1.Focus();
            }
            if (Step == 2)
            {
                this.groupBox3.Visible = false;
                this.groupBox2.Visible = true;
                this.buttonNext.Text = "Далі";
                this.richTextBox2.Focus();
            }
            if (Step == 3)
            {
                this.groupBox4.Visible = false;
                this.buttonNext.Text = "Далі";
                TestForm tf = new TestForm(NewTest);
                this.Visible = false;
                if (tf.ShowDialog() == DialogResult.OK)
                {
                    this.Visible = true;
                    //интерфейс следующего шага
                    this.groupBox3.Visible = false;
                    this.groupBox4.Visible = true;
                    groupBox4.Text = "Шаг 3";
                    this.textBox4.SelectAll();
                    this.textBox4.Focus();

                }
                else
                {
                    this.Visible = true;
                    this.groupBox3.Visible = true;
                    this.label10.Text = NewTest.GetNameOfAnswer() + ":";
                    this.richTextBox3.Focus();
                }
            }
            if (Step == 10)
            {
                //интерфейс
                this.groupBox6.Visible = false;
                this.groupBox5.Visible = true;
            }
            if (Step == 20)
            {
                //интерфейс
                if (this.listBox1.Items.Count > 1)
                {
                    this.groupBox5.Visible = false;
                    this.groupBox6.Visible = true;
                    this.groupBox4.Visible = false;

                    this.radioButton4.Checked = true;
                }
                else
                {
                    MessageBox.Show("До колекції не додано 2 і більше тестів");
                    Step -= 10;
                }
            }
            //Как назад при переоценивании?
            //Шаг между 20-30 (до изменения єтой кнопкой)
            //индекс откріваемого теста ЖЖ шаг-30
            if (Step == 11)
            {
                //интерфейс

                this.groupBox4.Visible = false;
                this.groupBox6.Visible = true;
                this.textBox4.Visible = true;
                this.label12.Visible = true;
                Step += 9;

           }

            if (Step >11 &&Step <20)
            {
                      //и рисуем предідущую
                      int index = Step - 12; //шаг-20=индекс теста например 21-20=1 (второй тест)
                      System.Collections.ArrayList AoT = COF.GetTests();
                      if (index >= 0 && index < AoT.Count)
                      {
                          NewTest = (Test)AoT[index];
                          this.label11.Text = "Змініть оцінки тесту \"" + NewTest.ToString() + "\"";


                          Array Matrix = new Array[NewTest.GetAnswerMatr().GetLength(0), NewTest.GetAnswerMatr().GetLength(1)];
                          Matrix = NewTest.GetAnswerMatr();
                          int pravilnih = 0;
                          foreach (bool item in Matrix) if (item) pravilnih++;

                          Array MoM = new Array[NewTest.GetMatrixOfMark().GetLength(0), NewTest.GetMatrixOfMark().GetLength(1)];
                          MoM = NewTest.GetMatrixOfMark();

                          this.dataGridView1.Rows.Clear();
                          this.dataGridView1.Rows.Add("Правильно всі", MoM.GetValue(0, 0), MoM.GetValue(0, 1), MoM.GetValue(0, 2), MoM.GetValue(0, 3), MoM.GetValue(0, 4), MoM.GetValue(0, 5), MoM.GetValue(0, 6), MoM.GetValue(0, 7), MoM.GetValue(0, 8), MoM.GetValue(0, 9), MoM.GetValue(0, 10));
                          if (pravilnih > 1) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 1), MoM.GetValue(1, 0), MoM.GetValue(1, 1), MoM.GetValue(1, 2), MoM.GetValue(1, 3), MoM.GetValue(1, 4), MoM.GetValue(1, 5), MoM.GetValue(1, 6), MoM.GetValue(1, 7), MoM.GetValue(1, 8), MoM.GetValue(1, 9), MoM.GetValue(1, 10));
                          if (pravilnih > 2) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 2), MoM.GetValue(2, 0), MoM.GetValue(2, 1), MoM.GetValue(2, 2), MoM.GetValue(2, 3), MoM.GetValue(2, 4), MoM.GetValue(2, 5), MoM.GetValue(2, 6), MoM.GetValue(2, 7), MoM.GetValue(2, 8), MoM.GetValue(2, 9), MoM.GetValue(2, 10));
                          if (pravilnih > 3) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 3), MoM.GetValue(3, 0), MoM.GetValue(3, 1), MoM.GetValue(3, 2), MoM.GetValue(3, 3), MoM.GetValue(3, 4), MoM.GetValue(3, 5), MoM.GetValue(3, 6), MoM.GetValue(3, 7), MoM.GetValue(3, 8), MoM.GetValue(3, 9), MoM.GetValue(3, 10));
                          if (pravilnih > 4) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 4), MoM.GetValue(4, 0), MoM.GetValue(4, 1), MoM.GetValue(4, 2), MoM.GetValue(4, 3), MoM.GetValue(4, 4), MoM.GetValue(4, 5), MoM.GetValue(4, 6), MoM.GetValue(4, 7), MoM.GetValue(4, 8), MoM.GetValue(4, 9), MoM.GetValue(4, 10));
                          if (pravilnih > 5) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 5), MoM.GetValue(5, 0), MoM.GetValue(5, 1), MoM.GetValue(5, 2), MoM.GetValue(5, 3), MoM.GetValue(5, 4), MoM.GetValue(5, 5), MoM.GetValue(5, 6), MoM.GetValue(5, 7), MoM.GetValue(5, 8), MoM.GetValue(5, 9), MoM.GetValue(5, 10));

                          for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
                              for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
                                  if (dataGridView1.Rows[j].Cells[i].Value.ToString() == "-1") dataGridView1.Rows[j].Cells[i].Value = "-";
                          this.dataGridView1.Columns[0].ReadOnly = true;
                                                    

                      }
                      Step+=9;
                  
              
            }
            if (Step == 100)
            {

                //интерфейс
                this.groupBox0.Visible = false;
                this.groupBox2.Visible = false;
                this.groupBox1.Visible = true;
                this.buttonReturn.Text = "Назад";
                this.buttonNext.Text = "Далі";
                this.textBox1.SelectAll();
                this.textBox2.SelectAll();
                this.textBox3.SelectAll();
                this.textBox1.Focus();
            }
            if (Step == 200)
            {
                this.buttonNext.Text = "Далі";
                this.groupBox3.Visible = false;
                this.groupBox2.Visible = true;
                this.richTextBox2.Focus();
            }
            if (Step == 300)
            {
                this.buttonNext.Text = "Далі";
                this.groupBox4.Visible = false;
                TestForm tf = new TestForm(NewTest);
                this.Visible = false;
                if (tf.ShowDialog() == DialogResult.OK)
                {
                    this.Visible = true;
                    //интерфейс следующего шага
                    this.groupBox3.Visible = false;
                    this.groupBox4.Visible = true;
                    groupBox4.Text = "Шаг 5";
                    this.textBox4.SelectAll();
                    this.textBox4.Focus();
                    Step += 100;

                }
                else
                {
                    this.Visible = true;
                    this.groupBox3.Visible = true;
                    this.label10.Text = NewTest.GetNameOfAnswer() + ":";
                    this.richTextBox3.Focus();
                }
            }
            if (Step == 900)
            {
                Step = 0;
                this.groupBox0.Visible = true;
                this.groupBox1.Visible = false;
                this.groupBox2.Visible = false;
                this.groupBox3.Visible = false;
                this.groupBox4.Visible = false;
                this.groupBox5.Visible = false;
                this.groupBox6.Visible = false;
                this.buttonReturn.Text = "Вихід";
                this.radioButton1.Checked = true;
            }
            
            
            if (Step == 1000) //Колекция
            {
                this.groupBox5.Visible = true;
                this.buttonReturn.Text = "Назад";
                listBox1.Items.Clear();
                COF.AddTestInListBox(this.listBox1);
                

            }


            
            if (Step > 1020 && Step < 1300) //10 - предідущие 9
            {
                // нарисуем предыдущий
                int index = ((Step - 1000) / 10) - 2;
                System.Collections.ArrayList AoT = COF.GetTests();


                if (index > 0 && index < AoT.Count)
                {
                    NewTest = (Test)AoT[index];
                    this.label11.Text = "Змініть оцінки тесту \"" + NewTest.ToString() + "\"";


                    Array Matrix = new Array[NewTest.GetAnswerMatr().GetLength(0), NewTest.GetAnswerMatr().GetLength(1)];
                    Matrix = NewTest.GetAnswerMatr();
                    int pravilnih = 0;
                    foreach (bool item in Matrix) if (item) pravilnih++;

                    Array MoM = new Array[NewTest.GetMatrixOfMark().GetLength(0), NewTest.GetMatrixOfMark().GetLength(1)];
                    MoM = NewTest.GetMatrixOfMark();

                    this.dataGridView1.Rows.Clear();
                    this.dataGridView1.Rows.Add("Правильно всі", MoM.GetValue(0, 0), MoM.GetValue(0, 1), MoM.GetValue(0, 2), MoM.GetValue(0, 3), MoM.GetValue(0, 4), MoM.GetValue(0, 5), MoM.GetValue(0, 6), MoM.GetValue(0, 7), MoM.GetValue(0, 8), MoM.GetValue(0, 9), MoM.GetValue(0, 10));
                    if (pravilnih > 1) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 1), MoM.GetValue(1, 0), MoM.GetValue(1, 1), MoM.GetValue(1, 2), MoM.GetValue(1, 3), MoM.GetValue(1, 4), MoM.GetValue(1, 5), MoM.GetValue(1, 6), MoM.GetValue(1, 7), MoM.GetValue(1, 8), MoM.GetValue(1, 9), MoM.GetValue(1, 10));
                    if (pravilnih > 2) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 2), MoM.GetValue(2, 0), MoM.GetValue(2, 1), MoM.GetValue(2, 2), MoM.GetValue(2, 3), MoM.GetValue(2, 4), MoM.GetValue(2, 5), MoM.GetValue(2, 6), MoM.GetValue(2, 7), MoM.GetValue(2, 8), MoM.GetValue(2, 9), MoM.GetValue(2, 10));
                    if (pravilnih > 3) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 3), MoM.GetValue(3, 0), MoM.GetValue(3, 1), MoM.GetValue(3, 2), MoM.GetValue(3, 3), MoM.GetValue(3, 4), MoM.GetValue(3, 5), MoM.GetValue(3, 6), MoM.GetValue(3, 7), MoM.GetValue(3, 8), MoM.GetValue(3, 9), MoM.GetValue(3, 10));
                    if (pravilnih > 4) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 4), MoM.GetValue(4, 0), MoM.GetValue(4, 1), MoM.GetValue(4, 2), MoM.GetValue(4, 3), MoM.GetValue(4, 4), MoM.GetValue(4, 5), MoM.GetValue(4, 6), MoM.GetValue(4, 7), MoM.GetValue(4, 8), MoM.GetValue(4, 9), MoM.GetValue(4, 10));
                    if (pravilnih > 5) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 5), MoM.GetValue(5, 0), MoM.GetValue(5, 1), MoM.GetValue(5, 2), MoM.GetValue(5, 3), MoM.GetValue(5, 4), MoM.GetValue(5, 5), MoM.GetValue(5, 6), MoM.GetValue(5, 7), MoM.GetValue(5, 8), MoM.GetValue(5, 9), MoM.GetValue(5, 10));

                    for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
                        for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
                            if (dataGridView1.Rows[j].Cells[i].Value.ToString() == "-1") dataGridView1.Rows[j].Cells[i].Value = "-";
                    this.dataGridView1.Columns[0].ReadOnly = true;

                    Step += 90; //с 1310 делает 1220

                }
                else Step += 100;
            }
            if (Step == 1020)
            {
                //интерфейс
                if (this.radioButton4.Checked)//заг. кількість балів
                {
                    COF.SetHowMark(0);
                    saveFileDialogCollection.ShowDialog();
                }
                if (this.radioButton5.Checked)
                {
                    COF.SetHowMark(1);
                    saveFileDialogCollection.ShowDialog();
                }
                if (this.radioButton6.Checked || this.radioButton7.Checked)
                {
                    if (this.radioButton6.Checked) COF.SetHowMark(2);
                    else COF.SetHowMark(3);
                    this.groupBox6.Visible = false;
                    this.groupBox4.Visible = true;
                    groupBox4.Text = "Шаг 3";
                    this.textBox4.Visible = false;
                    this.label12.Visible = false;


                    System.Collections.ArrayList AoT = COF.GetTests();

                    if (AoT.Count > 1)
                    {
                        this.NewTest = (Test)AoT[0];
                        this.label11.Text = "Змініть оцінки тесту \"" + NewTest.ToString() + "\"";


                        Array Matrix = new Array[NewTest.GetAnswerMatr().GetLength(0), NewTest.GetAnswerMatr().GetLength(1)];
                        Matrix = NewTest.GetAnswerMatr();
                        int pravilnih = 0;
                        foreach (bool item in Matrix) if (item) pravilnih++;

                        Array MoM = new Array[NewTest.GetMatrixOfMark().GetLength(0), NewTest.GetMatrixOfMark().GetLength(1)];
                        MoM = NewTest.GetMatrixOfMark();
                        this.dataGridView1.Rows.Clear();
                        this.dataGridView1.Rows.Add("Правильно всі", MoM.GetValue(0, 0), MoM.GetValue(0, 1), MoM.GetValue(0, 2), MoM.GetValue(0, 3), MoM.GetValue(0, 4), MoM.GetValue(0, 5), MoM.GetValue(0, 6), MoM.GetValue(0, 7), MoM.GetValue(0, 8), MoM.GetValue(0, 9), MoM.GetValue(0, 10));
                        if (pravilnih > 1) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 1), MoM.GetValue(1, 0), MoM.GetValue(1, 1), MoM.GetValue(1, 2), MoM.GetValue(1, 3), MoM.GetValue(1, 4), MoM.GetValue(1, 5), MoM.GetValue(1, 6), MoM.GetValue(1, 7), MoM.GetValue(1, 8), MoM.GetValue(1, 9), MoM.GetValue(1, 10));
                        if (pravilnih > 2) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 2), MoM.GetValue(2, 0), MoM.GetValue(2, 1), MoM.GetValue(2, 2), MoM.GetValue(2, 3), MoM.GetValue(2, 4), MoM.GetValue(2, 5), MoM.GetValue(2, 6), MoM.GetValue(2, 7), MoM.GetValue(2, 8), MoM.GetValue(2, 9), MoM.GetValue(2, 10));
                        if (pravilnih > 3) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 3), MoM.GetValue(3, 0), MoM.GetValue(3, 1), MoM.GetValue(3, 2), MoM.GetValue(3, 3), MoM.GetValue(3, 4), MoM.GetValue(3, 5), MoM.GetValue(3, 6), MoM.GetValue(3, 7), MoM.GetValue(3, 8), MoM.GetValue(3, 9), MoM.GetValue(3, 10));
                        if (pravilnih > 4) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 4), MoM.GetValue(4, 0), MoM.GetValue(4, 1), MoM.GetValue(4, 2), MoM.GetValue(4, 3), MoM.GetValue(4, 4), MoM.GetValue(4, 5), MoM.GetValue(4, 6), MoM.GetValue(4, 7), MoM.GetValue(4, 8), MoM.GetValue(4, 9), MoM.GetValue(4, 10));
                        if (pravilnih > 5) this.dataGridView1.Rows.Add("Правильно:" + (pravilnih - 5), MoM.GetValue(5, 0), MoM.GetValue(5, 1), MoM.GetValue(5, 2), MoM.GetValue(5, 3), MoM.GetValue(5, 4), MoM.GetValue(5, 5), MoM.GetValue(5, 6), MoM.GetValue(5, 7), MoM.GetValue(5, 8), MoM.GetValue(5, 9), MoM.GetValue(5, 10));

                        for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
                            for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
                                if (dataGridView1.Rows[j].Cells[i].Value.ToString() == "-1") dataGridView1.Rows[j].Cells[i].Value = "-";
                        this.dataGridView1.Columns[0].ReadOnly = true;
                        Step += 90;


                    }

                }
            }

            if (Step == 1010)
            {

                Step = 1100;
                this.groupBox5.Visible = false;
                this.groupBox6.Visible = true;
                int HowMark = COF.GetHowMark();
                if (HowMark == 0) this.radioButton4.Checked = true;
                else if (HowMark == 1) this.radioButton5.Checked = true;
                else if (HowMark == 2) this.radioButton6.Checked = true;
                else this.radioButton7.Checked = true;

            }




           



        }

        private void виділитиУсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox2.SelectAll();
        }

        private void вставитиЗБуфераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox2.Paste();
        }

        private void копіюватиДоБуфераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox2.Copy();
        }

        private void richTextBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) //текущая проверка
                if (this.richTextBox2.Text.Length != 0) //єнтер с прошлого окна
                    if (this.richTextBox2.Lines[this.richTextBox2.Lines.Length - 2].Length == 0)//последняя введенная строка
                    {
                        MessageBox.Show("Запитання №" + (this.richTextBox2.Lines.Length-1) + " не введено!");
                        this.richTextBox2.Text = this.richTextBox2.Text.Substring(0, this.richTextBox2.Text.Length - 1);
                        
                       
                    }
                    else //запитання введено
                    {
                        if (this.richTextBox2.Lines[this.richTextBox2.Lines.Length - 2].Length > 100)
                        {
                            MessageBox.Show("Запитання №" + (this.richTextBox2.Lines.Length - 1) + " перевищує 100 символів, зменшіть його довжину!");
                            this.richTextBox2.Select(this.richTextBox2.Text.LastIndexOf(this.richTextBox2.Lines[this.richTextBox2.Lines.Length - 2]), this.richTextBox2.Lines[this.richTextBox2.Lines.Length - 2].Length);
                            this.richTextBox2.Focus();

                        }
                    }
            if (this.richTextBox2.Lines.Length > 11) 
            {
                MessageBox.Show("Введено більше 10 запитань. Зменшіть їх кількість");
                this.richTextBox2.SelectAll();
            }

        }

         private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.richTextBox3.SelectAll();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.richTextBox3.Paste();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.richTextBox3.Copy();
        }

        private void richTextBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) //текущая проверка
                if (this.richTextBox3.Text.Length != 0) //єнтер с прошлого окна
                    if (this.richTextBox3.Lines[this.richTextBox3.Lines.Length - 2].Length == 0)//последняя введенная строка
                    {
                        MessageBox.Show("Відповідь №" + (this.richTextBox3.Lines.Length - 1) + " не введено!");
                        this.richTextBox3.Text = this.richTextBox3.Text.Substring(0, this.richTextBox3.Text.Length - 1);


                    }
                    else //запитання введено
                    {
                        if (this.richTextBox3.Lines[this.richTextBox3.Lines.Length - 2].Length > 100)
                        {
                            MessageBox.Show("Відповідь №" + (this.richTextBox3.Lines.Length - 1) + " перевищує 100 символів, зменшіть її довжину!");
                            this.richTextBox3.Select(this.richTextBox3.Text.LastIndexOf(this.richTextBox3.Lines[this.richTextBox3.Lines.Length - 2]), this.richTextBox3.Lines[this.richTextBox3.Lines.Length - 2].Length);
                            this.richTextBox3.Focus();

                        }
                    }
            if (this.richTextBox3.Lines.Length > 11)
            {
                MessageBox.Show("Введено більше 10 відповідей. Зменшіть їх кількість");
                this.richTextBox3.SelectAll();
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            this.NewTest.SetOwnerID(this.CurrentTeacher.GetID());

            byte[] Key ={13,20,94,153,8,22,109,154,231,97,91,118,97,208,214,249,128,246,150,170,173,191,207,138 };
            byte[] IV = { 227, 182, 38, 145, 55, 77, 174, 23 };

            //збереження нового тесту
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            
            string path = this.saveFileDialogTest.FileName;
            FileStream encripted;
            if (File.Exists(path))
            {
                encripted = File.Open(path, FileMode.OpenOrCreate);
            }
            else 
            {
                encripted = new FileStream(path, FileMode.Create, FileAccess.Write);

            }
                CryptoStream cStream = new CryptoStream(encripted,
                    new TripleDESCryptoServiceProvider().CreateEncryptor(Key, IV),
                    CryptoStreamMode.Write);

                bf.Serialize(cStream, this.NewTest);
                cStream.Close();
                encripted.Close();
            
        }

        private void buttonAddTest_Click(object sender, EventArgs e)
        {
            if (this.openFileDialogTest.ShowDialog() == DialogResult.OK)
            {
                this.listBox1.Items.Clear();
                COF.AddTestInListBox(this.listBox1);
                             
            } 
        }

        private void buttonDelTest_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex != -1)
            {
                string message = "Видалити тест \""+this.listBox1.SelectedItem.ToString()+"\" з колекції ?";
                string caption = "Чи Ви впевнені?";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);

                if (result == DialogResult.Yes)
                {//обновляем
                COF.DelTestOfCollection((Test)this.listBox1.SelectedItem);
                this.listBox1.Items.Clear();
                COF.AddTestInListBox(this.listBox1);
                
                }
            }
            else MessageBox.Show("Видаляємий тест не вибрано. Виберіть його");
        }

        private void buttonClearTest_Click(object sender, EventArgs e)
        {
            string message = "Очистити список тестів у колекції?";
            string caption = "Чи Ви впевнені?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);

            if (result == DialogResult.Yes)
            {
                this.listBox1.Items.Clear();
                this.COF = new CollectionOfTest();
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            byte[] Key ={ 13, 20, 94, 153, 8, 22, 109, 154, 231, 97, 91, 118, 97, 208, 214, 249, 128, 246, 150, 170, 173, 191, 207, 138 };
            byte[] IV = { 227, 182, 38, 145, 55, 77, 174, 23 };
            Test NewTest = new Test();
            string[] ListOfFiles = this.openFileDialogTest.FileNames;
            foreach (string FileNames in ListOfFiles)
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                FileStream encripted = File.Open(FileNames, FileMode.Open);
                if (File.Exists(FileNames))
                {
                    CryptoStream cStream = new CryptoStream(encripted,
                        new TripleDESCryptoServiceProvider().CreateDecryptor(Key, IV),
                        CryptoStreamMode.Read);


                    NewTest = (Test)bf.Deserialize(cStream);
                    cStream.Close();
                    encripted.Close();

                }
                if (!this.setting.GetOnlyOur())
                {
                if (NewTest.GetOwnerID()!=this.CurrentTeacher.GetID()) 
                    MessageBox.Show(" Тест, що додається, не створений Вами.\n Зверніться до адміністратора для встановлення опції \n \"Дозволити додавання тестів не їх \"власником\"\".");
                else if (this.COF.AddTestInCollection(NewTest) == 1) break;//проверка ошибки добавления ошибка добавления
                }
                else if (this.COF.AddTestInCollection(NewTest) == 1) break;//проверка ошибки добавления ошибка добавления

                

            }



        }

        private void saveFileDialogCollection_FileOk(object sender, CancelEventArgs e)
        {
            //сохранение файла колекции через еe сериализацию
            this.COF.SetOwnerID(this.CurrentTeacher.GetID());
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            byte[] Key ={ 13, 20, 94, 153, 8, 22, 109, 154, 231, 97, 91, 118, 97, 208, 214, 249, 128, 246, 150, 170, 173, 191, 207, 138 };
            byte[] IV = { 227, 182, 38, 145, 55, 77, 174, 23 };

            
            string path = this.saveFileDialogCollection.FileName;
            COF.SetName(Path.GetFileNameWithoutExtension(this.saveFileDialogCollection.FileName ));
            FileStream encripted;
            if (File.Exists(path))
            {
                encripted = File.Open(path, FileMode.OpenOrCreate);
            }
            else
            {
                encripted = new FileStream(path, FileMode.Create, FileAccess.Write);
            }
           
            CryptoStream cStream = new CryptoStream(encripted,
                new TripleDESCryptoServiceProvider().CreateEncryptor(Key, IV),
                CryptoStreamMode.Write);

            bf.Serialize(cStream, this.COF);
            cStream.Close();
            encripted.Close();
                

        }

        private void openFileDialogTestAndCollection_FileOk(object sender, CancelEventArgs e)
        {
            //вставить проверку на принадлежность теста
            byte[] Key ={ 13, 20, 94, 153, 8, 22, 109, 154, 231, 97, 91, 118, 97, 208, 214, 249, 128, 246, 150, 170, 173, 191, 207, 138 };
            byte[] IV = { 227, 182, 38, 145, 55, 77, 174, 23 };

            String FileName = this.openFileDialogTestAndCollection.FileName;
            String name = this.openFileDialogTestAndCollection.SafeFileName;
            String Extention = name.Substring(name.Length - 5);

            if (Extention.Equals(".tcln")) Step+=900;
            //добавление теста
            
               System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                FileStream encripted = File.Open(FileName, FileMode.Open);
                if (File.Exists(FileName))
                {
                    CryptoStream cStream = new CryptoStream(encripted,
                        new TripleDESCryptoServiceProvider().CreateDecryptor(Key, IV),
                        CryptoStreamMode.Read);


                    if (Extention.Equals(".tcln")) this.COF = (CollectionOfTest)bf.Deserialize(cStream);
                    else this.NewTest = (Test)bf.Deserialize(cStream);



                    if (Extention.Equals(".tcln"))
                    {
                        if (COF.GetOwnerID() != this.CurrentTeacher.GetID())
                        {
                            MessageBox.Show("  Колекція, що змінюється, не створена Вами.\n Зверніться до адміністратора для встановлення опції \n \"Дозволити додавання тестів не їх \"власником\"\".");
                            DialogResult = DialogResult.Abort;
                        }
                    }
                    else if (NewTest.GetOwnerID() != this.CurrentTeacher.GetID())
                    {
                        MessageBox.Show("  Тест, що змінюється, не створений Вами.\n Зверніться до адміністратора для встановлення опції \n \"Дозволити додавання тестів не їх \"власником\"\".");
                        DialogResult = DialogResult.Abort;
                    }
                    cStream.Close();
                    encripted.Close();
                }


            }

        private void FormMasterOfTest_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (this.radioButton1.Checked) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "731.htm");
                if (this.radioButton2.Checked) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "732.htm");
                if (this.radioButton3.Checked) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "733.htm");
            }
        }

       

   

      

       

       
    }
}