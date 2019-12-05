using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Test_M
{
    

    public partial class FormMatrixOfMark : Form
    {
        private int[,] MatrOfMark;
        private Setting setting;

        public FormMatrixOfMark()
        {
            InitializeComponent();
        }
          public FormMatrixOfMark(Setting setting)
        {
            InitializeComponent();
            this.MatrOfMark = setting.GetMatrixOfMark();
            this.setting = setting;
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Rows.Add("Правильно всі", this.MatrOfMark.GetValue(0, 0), this.MatrOfMark.GetValue(0, 1), this.MatrOfMark.GetValue(0, 2), this.MatrOfMark.GetValue(0, 3), this.MatrOfMark.GetValue(0, 4), this.MatrOfMark.GetValue(0, 5), this.MatrOfMark.GetValue(0, 6), this.MatrOfMark.GetValue(0, 7), this.MatrOfMark.GetValue(0, 8), this.MatrOfMark.GetValue(0, 9), this.MatrOfMark.GetValue(0, 10));
            this.dataGridView1.Rows.Add("Правильно:-1" , this.MatrOfMark.GetValue(1, 0), this.MatrOfMark.GetValue(1, 1), this.MatrOfMark.GetValue(1, 2), this.MatrOfMark.GetValue(1, 3), this.MatrOfMark.GetValue(1, 4), this.MatrOfMark.GetValue(1, 5), this.MatrOfMark.GetValue(1, 6), this.MatrOfMark.GetValue(1, 7), this.MatrOfMark.GetValue(1, 8), this.MatrOfMark.GetValue(1, 9), this.MatrOfMark.GetValue(1, 10));
            this.dataGridView1.Rows.Add("Правильно:-2" , this.MatrOfMark.GetValue(2, 0), this.MatrOfMark.GetValue(2, 1), this.MatrOfMark.GetValue(2, 2), this.MatrOfMark.GetValue(2, 3), this.MatrOfMark.GetValue(2, 4), this.MatrOfMark.GetValue(2, 5), this.MatrOfMark.GetValue(2, 6), this.MatrOfMark.GetValue(2, 7), this.MatrOfMark.GetValue(2, 8), this.MatrOfMark.GetValue(2, 9), this.MatrOfMark.GetValue(2, 10));
            this.dataGridView1.Rows.Add("Правильно:-3" , this.MatrOfMark.GetValue(3, 0), this.MatrOfMark.GetValue(3, 1), this.MatrOfMark.GetValue(3, 2), this.MatrOfMark.GetValue(3, 3), this.MatrOfMark.GetValue(3, 4), this.MatrOfMark.GetValue(3, 5), this.MatrOfMark.GetValue(3, 6), this.MatrOfMark.GetValue(3, 7), this.MatrOfMark.GetValue(3, 8), this.MatrOfMark.GetValue(3, 9), this.MatrOfMark.GetValue(3, 10));
            this.dataGridView1.Rows.Add("Правильно:-4", this.MatrOfMark.GetValue(4, 0), this.MatrOfMark.GetValue(4, 1), this.MatrOfMark.GetValue(4, 2), this.MatrOfMark.GetValue(4, 3), this.MatrOfMark.GetValue(4, 4), this.MatrOfMark.GetValue(4, 5), this.MatrOfMark.GetValue(4, 6), this.MatrOfMark.GetValue(4, 7), this.MatrOfMark.GetValue(4, 8), this.MatrOfMark.GetValue(4, 9), this.MatrOfMark.GetValue(4, 10));
            this.dataGridView1.Rows.Add("Правильно:-5" , this.MatrOfMark.GetValue(5, 0), this.MatrOfMark.GetValue(5, 1), this.MatrOfMark.GetValue(5, 2), this.MatrOfMark.GetValue(5, 3), this.MatrOfMark.GetValue(5, 4), this.MatrOfMark.GetValue(5, 5), this.MatrOfMark.GetValue(5, 6), this.MatrOfMark.GetValue(5, 7), this.MatrOfMark.GetValue(5, 8), this.MatrOfMark.GetValue(5, 9), this.MatrOfMark.GetValue(5, 10));


           


            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
                for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
                    if (dataGridView1.Rows[j].Cells[i].Value.ToString() == "-1") dataGridView1.Rows[j].Cells[i].Value = "-";
            this.dataGridView1.Columns[0].ReadOnly = true;



        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
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



                  if (OK)
                  {
                      setting.SetMatrixOfMark(this.MatrOfMark);
                  }
                  this.Close();
        }

        private void FormMatrixOfMark_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
               Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "85.htm");

            }
        }
    }
}