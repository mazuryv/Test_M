
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Test_M
{
    public partial class TestForm : Form
    {
        private System.Drawing.Graphics graph;
        private Postroenie p;
        private Test test;
        public int mark;
        public int prav ;
        public int neprav;



        public TestForm()
        {
            InitializeComponent();
        }
        public TestForm(Test T, User CurrentUser) //с указание какой тест строить
        {
            InitializeComponent();
            graph = CreateGraphics();

            p = new Postroenie();
            p.Stroim(this, T, graph); //это будет полный вызов для построения теста в форме
            this.label1.Text = this.label1.Text.Substring(0, this.label1.Text.IndexOf(": ") + 2) + p.GetTimeForTest() +
            this.label1.Text.Substring(this.label1.Text.IndexOf(" с."), this.label1.Text.Length - this.label1.Text.IndexOf(" с."));

       }
        
        public TestForm(Test NewTest) //для построения нового теста
        {
            InitializeComponent();
            graph = CreateGraphics();
            p = new Postroenie();
            this.test = NewTest;
            p.StroimNew(this, NewTest, graph); //это будет полный вызов для построения теста в форме
            this.timer1.Enabled = false;
            this.label1.Visible = false;
            this.buttonReturn.Visible = this.buttonNext.Visible = true;
            this.buttonProv.Visible = false;
            this.toolStripButton1.Text="Введіть правильні відповіді у матрицю (з`єднайте питання у матриці із відповідями)";
            FontFamily fontFamily = new FontFamily("Microsoft Sans Serif");
                Font font = new Font(
                   fontFamily,
                   13,
                   FontStyle.Bold,
                   GraphicsUnit.Pixel);
            this.toolStrip1.Items[0].Font = font;
            this.toolStrip1.Items[0].ForeColor = Color.Blue;
            this.Text = "Шаг 4";


        }
        private void buttonReturn_Click(object sender, EventArgs e)
        {
            this.Close();  
           
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            this.test.SetAnswerMatr(p.SetAnswerMatrix());
           
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            graph = CreateGraphics();
            if ((p!=null) & (graph!=null)) p.AddLines(graph); //если есть п и графика -перерисовать принимая во внимание имеющиеся данные
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            int tick = Convert.ToInt32(this.label1.Text.Substring(this.label1.Text.IndexOf(": ") + 2,
                this.label1.Text.IndexOf(" с.") - this.label1.Text.IndexOf(": ")-2));
            if (tick > 1)
            {
                tick--;
                this.label1.Text = this.label1.Text.Substring(0, this.label1.Text.IndexOf(": ") + 2)+ tick+
                    this.label1.Text.Substring(this.label1.Text.IndexOf(" с."), this.label1.Text.Length-this.label1.Text.IndexOf(" с."));
                
            }
            else {
                this.timer1.Enabled = false;
                MessageBox.Show("Час для виконання вказаного тесту вичерпано! \n Оцінка буде виставлена згідно із наданими відповідями!");
                this.buttonProv_Click(this.buttonProv, null);
            }

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void buttonProv_Click(object sender, EventArgs e)
        {//проверить и поставить оценку
            //проверяем в классе Р
            prav = 0; neprav = 0; mark = 0;
            if (p != null)
                p.Proverka(ref prav, ref neprav, ref mark);
            this.toolStripStatusLabel2.Visible =
                this.toolStripStatusLabel3.Visible =
                this.toolStripStatusLabel4.Visible = true;
            this.toolStripStatusLabel2.Text += " " + prav + ".   ";
            this.toolStripStatusLabel3.Text += " " + neprav + ".   ";
            this.toolStripStatusLabel4.Text += " " + mark + ".   ";
            this.buttonProv.Visible = false;
            this.timer1.Enabled = false;
            


            this.buttonClose.Visible = true;

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            AboutBox AB = new AboutBox();
            AB.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            if (this.label1.Visible) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "63.htm");
            else Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "731.htm");
            
        }

        private void TestForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (this.label1.Visible) Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "63.htm");
                else Help.ShowHelp(this, "Test_M_Help.chm", HelpNavigator.Topic, "731.htm");
            }
        }

       
      

        
        
    }

    
    
    }
    

