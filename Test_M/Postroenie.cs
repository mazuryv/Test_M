using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Test_M
{    
    public class Postroenie
    {
        private int SizeOfButton = 30;
        private Label[] ArrayQuestion, ArrayAnswer;
        private MyButton[,] ArrayButton;
        private bool[,] AnswerMatrix;
        private int[,] MatrixOfMark;
        private int WhereNextLableY = 33;
        private int WhereFirstButtonY = 33;
        private int HowMAnswer = 0;
        private int TimeForTest = 300;
       
        //���� ����� �������� ���������� ���� ��������� ����� � � ����� Where � ����������� graph
        //������� ����������� �����, �������� ������� ����� � �������� �����������
        public void Stroim(Form Where, Test T, Graphics graph)
        {
            //�������� ������� (��������� ����� � ����, ������� ����� �������)
            if (T != null)
            {
                this.NameOfTest(Where, T.GetNameOfTest());
                this.NameOfQuestion(Where, T.GetNameOfQuestion());
                this.AddQuestion(Where, T.GetQuestion());
                this.NameOfAnswer(Where, T.GetNameOfAnswer());
                this.AddAnswer(Where, T.GetAnswer());
                this.AddButtons(T, Where,false);
                this.AddLines(graph, T.GetAnswer().Count);
                this.AddAnswerMatrix(T.GetAnswerMatr());
                this.SetTimeForTest(T.GetTimeForTest());
                this.AddMatrixOfMark(T.GetMatrixOfMark());
                
            }
            else MessageBox.Show("���� �� ������");
        }
        public void StroimNew(Form Where, Test T, Graphics graph)
        {
            //�������� ������� (��������� ����� � ����, ������� ����� �������)
            if (T != null)
            {
                
                this.NameOfTest(Where, T.GetNameOfTest());
                this.NameOfQuestion(Where, T.GetNameOfQuestion());
                this.AddQuestion(Where, T.GetQuestion());
                this.NameOfAnswer(Where, T.GetNameOfAnswer());
                this.AddAnswer(Where, T.GetAnswer());
                this.AddButtons(T, Where,true);
                this.AddLines(graph, T.GetAnswer().Count);
               
                
            }
            else MessageBox.Show("���� �� ������!");
        }
        public bool[,] SetAnswerMatrix() 
        {
            //����������� ���� ������ ������ � ����� ������������, ����� �� ��� ������
            AnswerMatrix = new bool[this.ArrayButton.GetLength(0), this.ArrayButton.GetLength(1)];
            for (int a = 0; a < this.ArrayButton.GetLength(0); a++)
                for (int b = 0; b < this.ArrayButton.GetLength(1); b++)
                    this.AnswerMatrix[a, b] = this.ArrayButton[a, b].IfCheck();
            return AnswerMatrix;
        
        }
        public void AddLines(System.Drawing.Graphics graph)
        {
            SolidBrush brush = new SolidBrush(System.Drawing.Color.Black);
            Pen pen = new Pen(brush, 2);
            if (this.ArrayAnswer  != null)
            {
                if (this.ArrayAnswer.Length > 0) //���� ������ ��� ������
                    for (int i = 0; i < this.ArrayAnswer.Length; i++)
                    {
                        graph.DrawLine(pen,
                            ArrayButton[0, 0].Location.X - 5,
                            ArrayAnswer[i].Location.Y + ArrayAnswer[i].Size.Height / 2,
                            ArrayButton[0, i].Location.X + this.SizeOfButton / 2,
                            ArrayAnswer[i].Location.Y + ArrayAnswer[i].Size.Height / 2);
                        graph.DrawLine(pen,
                             ArrayButton[0, i].Location.X + this.SizeOfButton / 2,
                             ArrayAnswer[i].Location.Y + ArrayAnswer[i].Size.Height / 2,
                             ArrayButton[0, i].Location.X + this.SizeOfButton / 2,
                             ArrayAnswer[0].Location.Y - 20);
                    }
            }
             
        }
        public int GetTimeForTest()
        {
            return this.TimeForTest;
        }
        public void Proverka(ref int prav, ref int neprav, ref int mark)
        {
            for (int a = 0; a < this.ArrayButton.GetLength(0); a++)
                for (int b = 0; b < this.ArrayButton.GetLength(1); b++)
                    ArrayButton[a, b].Enabled = false;
            if (AnswerMatrix.Length != ArrayButton.Length)
                System.Windows.Forms.MessageBox.Show("����������� ������ � ������ ������� ������� �� ���������!");
            else
            {
                int VsegoPrav = 0;
                for (int a = 0; a < AnswerMatrix.GetLength(0); a++)
                    for (int b = 0; b < AnswerMatrix.GetLength(1); b++)
                    {
                        if (AnswerMatrix[a, b]) VsegoPrav++;
                        if (AnswerMatrix[a, b] && ArrayButton[a, b].IfCheck())
                        {
                            prav++;
                            ArrayButton[a, b].BackgroundImage = global::Test_M.Properties.Resources.plus;
                        }
                        if (AnswerMatrix[a, b] && !ArrayButton[a, b].IfCheck())
                        {
                            neprav++;
                            ArrayButton[a, b].BackgroundImage = global::Test_M.Properties.Resources.minus;
                        }
                        if (ArrayButton[a, b].IfCheck() && !AnswerMatrix[a, b])
                        {
                            neprav++;
                            ArrayButton[a, b].BackgroundImage = global::Test_M.Properties.Resources.minus;
                        }
                    }



                if (prav == VsegoPrav&&neprav==0) mark = this.MatrixOfMark[0,0]; //���� ��� ���������
                if (prav == VsegoPrav)
                {
                    if( neprav==1) mark = this.MatrixOfMark[0,1]; //��� ���������, 1 ����� �����������
                    if ( neprav == 2) mark = this.MatrixOfMark[0, 2]; //��� ���������, 2 ������ �����������
                    if ( neprav == 3) mark = this.MatrixOfMark[0, 3]; //��� ���������, 3 ������ �����������
                    if ( neprav == 4) mark = this.MatrixOfMark[0, 4]; //��� ���������, 4 ������ �����������
                    if ( neprav == 5) mark = this.MatrixOfMark[0, 5]; //��� ���������, 5 ������� �����������
                    if ( neprav == 6) mark = this.MatrixOfMark[0, 6]; //��� ���������, 6 ������� �����������
                    if ( neprav == 7) mark = this.MatrixOfMark[0, 7]; //��� ���������, 7 ������� �����������
                    if ( neprav == 8) mark = this.MatrixOfMark[0, 8]; //��� ���������, 8 ������� �����������
                    if ( neprav == 9) mark = this.MatrixOfMark[0, 9]; //��� ���������, 9 ������� �����������
                    if ( neprav == 10) mark = this.MatrixOfMark[0, 10]; //��� ���������, 10 ������ �����������
                }
                if (prav == VsegoPrav - 1)
                {
                    if (neprav == 1) mark = this.MatrixOfMark[1, 1];
                    if (neprav == 2) mark = this.MatrixOfMark[1, 2];
                    if (neprav == 3) mark = this.MatrixOfMark[1, 3];
                    if (neprav == 4) mark = this.MatrixOfMark[1, 4];
                    if (neprav == 5) mark = this.MatrixOfMark[1, 5];
                    if (neprav == 6) mark = this.MatrixOfMark[1, 6];
                    if (neprav == 7) mark = this.MatrixOfMark[1, 7];
                    if (neprav == 8) mark = this.MatrixOfMark[1, 8];
                    if (neprav == 9) mark = this.MatrixOfMark[1, 9];
                    if (neprav == 10) mark = this.MatrixOfMark[1, 10];
                }
                if (prav == VsegoPrav - 2)
                {
                    if (neprav == 2) mark = this.MatrixOfMark[2, 2];
                    if (neprav == 3) mark = this.MatrixOfMark[2, 3];
                    if (neprav == 4) mark = this.MatrixOfMark[2, 4];
                    if (neprav == 5) mark = this.MatrixOfMark[2, 5];
                    if (neprav == 6) mark = this.MatrixOfMark[2, 6];
                    if (neprav == 7) mark = this.MatrixOfMark[2, 7];
                    if (neprav == 8) mark = this.MatrixOfMark[2, 8];
                    if (neprav == 9) mark = this.MatrixOfMark[2, 9];
                    if (neprav == 10) mark = this.MatrixOfMark[2, 10];
                }
                if (prav == VsegoPrav - 3)
                {
                    if (neprav == 3) mark = this.MatrixOfMark[3, 3];
                    if (neprav == 4) mark = this.MatrixOfMark[3, 4];
                    if (neprav == 5) mark = this.MatrixOfMark[3, 5];
                    if (neprav == 6) mark = this.MatrixOfMark[3, 6];
                    if (neprav == 7) mark = this.MatrixOfMark[3, 7];
                    if (neprav == 8) mark = this.MatrixOfMark[3, 8];
                    if (neprav == 9) mark = this.MatrixOfMark[3, 9];
                    if (neprav == 10) mark = this.MatrixOfMark[3, 10];
                }
                if (prav == VsegoPrav - 4)
                {
                    if (neprav == 4) mark = this.MatrixOfMark[4, 4];
                    if (neprav == 5) mark = this.MatrixOfMark[4, 5];
                    if (neprav == 6) mark = this.MatrixOfMark[4, 6];
                    if (neprav == 7) mark = this.MatrixOfMark[4, 7];
                    if (neprav == 8) mark = this.MatrixOfMark[4, 8];
                    if (neprav == 9) mark = this.MatrixOfMark[4, 9];
                    if (neprav == 10) mark = this.MatrixOfMark[4, 10];
                }
                if (prav == VsegoPrav - 5)
                {
                    if (neprav == 5) mark = this.MatrixOfMark[5, 5];
                    if (neprav == 6) mark = this.MatrixOfMark[5, 6];
                    if (neprav == 7) mark = this.MatrixOfMark[5, 7];
                    if (neprav == 8) mark = this.MatrixOfMark[5, 8];
                    if (neprav == 9) mark = this.MatrixOfMark[5, 9];
                    if (neprav == 10) mark = this.MatrixOfMark[5, 10];
                }
                if (prav == VsegoPrav - 6)
                {
                    if (neprav == 6) mark = this.MatrixOfMark[6, 6];
                    if (neprav == 7) mark = this.MatrixOfMark[6, 7];
                    if (neprav == 8) mark = this.MatrixOfMark[6, 8];
                    if (neprav == 9) mark = this.MatrixOfMark[6, 9];
                    if (neprav == 10) mark = this.MatrixOfMark[6, 10];
                }

            }
        }//���������� �����

        private void buttons_MouseEnter(object sender, ChangedEventArgs args)
        {
            this.ArrayQuestion[args.IndexX].ForeColor = System.Drawing.Color.Crimson;
            this.ArrayAnswer[args.IndexY].ForeColor = System.Drawing.Color.Crimson;

        }
        private void buttons_MouseLeave(object sender, ChangedEventArgs args)
        {
            this.ArrayQuestion[args.IndexX].ForeColor = System.Drawing.Color.Black;
            this.ArrayAnswer[args.IndexY].ForeColor = System.Drawing.Color.Black;

        }
        private void buttons_Click(object sender, ChangedEventArgs args)
        {
            if (!this.ArrayButton[args.IndexX, args.IndexY].IfCheck())
            {
                this.ArrayButton[args.IndexX, args.IndexY].IfCheck(true);
                this.ArrayButton[args.IndexX, args.IndexY].BackgroundImage = global::Test_M.Properties.Resources.videlenie;
                this.ArrayButton[args.IndexX, args.IndexY].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            }
            else {
                this.ArrayButton[args.IndexX, args.IndexY].IfCheck(false);
                this.ArrayButton[args.IndexX, args.IndexY].BackgroundImage = null;
                  }

        }
        private void NameOfTest(Form Where, string Name) {
            Where.Text = "���� \""+Name+"\"";
        }
        private void NameOfQuestion(Form Where, string NameOfQuestion)
        {
            if (NameOfQuestion.Length > 27) System.Windows.Forms.MessageBox.Show("�������� �������� � ����� " +
                    "����� 27 ��������! \n" + "��������� ��������");
            else {
                Label labelOfNameOfQuestion = new Label();
                labelOfNameOfQuestion.AutoSize = true;
                labelOfNameOfQuestion.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                labelOfNameOfQuestion.Location = new System.Drawing.Point(40, 25);
                labelOfNameOfQuestion.Name = "labelOfNameOfQuestion";
                labelOfNameOfQuestion.Size = new System.Drawing.Size(97, 22);
                labelOfNameOfQuestion.Text = NameOfQuestion;
                Where.Controls.Add(labelOfNameOfQuestion);
                this.WhereNextLableY = 50;
            }
        
        }
        private void NameOfAnswer(Form Where, string NameOfAnswer) {
            if (NameOfAnswer.Length > 27) System.Windows.Forms.MessageBox.Show("�������� ������� � ����� " +
                        "����� 27 ��������! \n" + "��������� ��������");
            else
            {
                Label labelOfNameOfAnswer = new Label();
                labelOfNameOfAnswer.AutoSize = true;
                labelOfNameOfAnswer.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                labelOfNameOfAnswer.Location = new System.Drawing.Point(40, this.WhereNextLableY);
                labelOfNameOfAnswer.Name = "labelOfNameOfAnswer";
                labelOfNameOfAnswer.Size = new System.Drawing.Size(97, 22);
                labelOfNameOfAnswer.Text = NameOfAnswer;
                Where.Controls.Add(labelOfNameOfAnswer);
                this.WhereNextLableY += 30;
                this.WhereFirstButtonY += 20;
            }
        
        
        }
        private void AddButtons(Test T, Form Where, bool PokazPravOtvetov)
        {

            int RazmY = T.GetQuestion().Count;
            int RazmX = T.GetAnswer().Count;
            bool[,] AnsMatr=new bool[1,1];
            if (T.GetAnswerMatr() != null && PokazPravOtvetov)
            {
                AnsMatr = new bool[T.GetAnswerMatr().GetLength(0), T.GetAnswerMatr().GetLength(1)];
                AnsMatr = (bool[,])T.GetAnswerMatr().Clone();
            }
            ArrayButton = new MyButton[RazmY, RazmX];
                for (int a = 0; a < RazmX; a++)
                {
                    for (int i = 0; i < RazmY; i++)
                    {
                        ArrayButton[i, a] = new MyButton();
                        ArrayButton[i, a].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;

                        ArrayButton[i, a].Location = new System.Drawing.Point(
                                                                            400 //������ ����� 
                                                                            + a * SizeOfButton,//������� ��������??
                                                                            (this.WhereFirstButtonY -5) //�� ������ ��������� ������
                                                                            + i * SizeOfButton);//�����������������
                        ArrayButton[i, a].Name = "ArrayButton[" + i + "," + a + "]";
                        ArrayButton[i, a].Size = new System.Drawing.Size(SizeOfButton, SizeOfButton);
                        ArrayButton[i, a].TabIndex = 2 + i + a * RazmX;
                        ArrayButton[i, a].UseVisualStyleBackColor = true;
                        Where.Controls.Add(ArrayButton[i, a]);
                        ArrayButton[i, a].MouseLeave += new ChangedEventHandler(buttons_MouseLeave);
                        ArrayButton[i, a].MouseEnter += new ChangedEventHandler(buttons_MouseEnter);
                        ArrayButton[i, a].Click += new ChangedEventHandler(buttons_Click);
                        if ((T.GetAnswerMatr() != null)&&PokazPravOtvetov)
                        {
                            ArrayButton[i, a].IfCheck(AnsMatr[i, a]);
                            if (AnsMatr[i, a])
                                {
                                    ArrayButton[i, a].BackgroundImage = global::Test_M.Properties.Resources.videlenie;
                                    this.ArrayButton[i, a].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                                }
                        }
                   }
                }
                if ((ArrayButton[RazmY - 1, RazmX - 1].Location.X + 30) > Where.ClientSize.Width)
                    Where.ClientSize = new System.Drawing.Size(ArrayButton[RazmY - 1, RazmX - 1].Location.X + 50, Where.ClientSize.Width);
                
            
        }
        private void AddQuestion(Form Where, System.Collections.ArrayList str)
        {       ArrayQuestion = new Label[str.Count];
                int i = 0, Newline = 0;
                String Question = "";
                bool IfNeedNewLine = false;
                foreach (string item in str)
                {
                    if (item.Length > 52)
                    {
                        Question = item.Insert(item.LastIndexOf(" ", 52), "\n");
                        IfNeedNewLine = true;
                    }
                    else Question = item;
                    ArrayQuestion[i] = new Label();
                    ArrayQuestion[i].AutoSize = true;
                    ArrayQuestion[i].Font = new System.Drawing.Font("Times New Roman", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    ArrayQuestion[i].Location = new System.Drawing.Point(20, WhereNextLableY  + 30 * i + Newline);
                    ArrayQuestion[i].Name = "labelQuestion[" + i + "]";
                    ArrayQuestion[i].Size = new System.Drawing.Size(71, 16);
                    ArrayQuestion[i].Text = Question;
                    Where.Controls.Add(ArrayQuestion[i]);
                    if (IfNeedNewLine) Newline += 10;
                    IfNeedNewLine = false;
                    i++;
                }

                SizeOfButton += Newline / str.Count;
                WhereNextLableY = ArrayQuestion[str.Count - 1].Location.Y + ArrayQuestion[str.Count - 1].Size.Height + 10;

         
        }
        private void AddAnswer(Form Where, System.Collections.ArrayList str)
        {   ArrayAnswer = new Label[str.Count];
            int i = 0, Newline = 0;
            String Answer = "";
            bool IfNeedNewLine = false;
            foreach (string item in str)
            {
                if (item.Length > 59)
                {
                    Answer = item.Insert(item.LastIndexOf(" ", 52), "\n");
                    IfNeedNewLine = true;
                }
                else Answer = item;
                ArrayAnswer[i] = new Label();
                ArrayAnswer[i].AutoSize = true;
                ArrayAnswer[i].Font = new System.Drawing.Font("Times New Roman", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                ArrayAnswer[i].Location = new System.Drawing.Point(20, WhereNextLableY + 30 * i + Newline);
                ArrayAnswer[i].Name = "labelAnswer[" + i + "]";
                ArrayAnswer[i].Size = new System.Drawing.Size(71, 16);
                ArrayAnswer[i].Text = Answer;
                Where.Controls.Add(ArrayAnswer[i]);
                if (IfNeedNewLine) Newline += 10;
                IfNeedNewLine = false;
                i++;
            
        }

        if ((ArrayAnswer[str.Count - 1].Location.Y + ArrayAnswer[str.Count - 1].Size.Height) > (Where.ClientSize.Height - 30))
          Where.ClientSize = new System.Drawing.Size(Where.ClientSize.Width, ArrayAnswer[str.Count - 1].Location.Y + ArrayAnswer[str.Count - 1].Size.Height + 80);

      

        }
        private void AddLines(System.Drawing.Graphics graph, int HowMachAnswer) {
            this.HowMAnswer = HowMachAnswer;
            SolidBrush brush =new SolidBrush(System.Drawing.Color.Black);
            Pen pen = new Pen(brush, 2);
                 
            for (int i=0; i < HowMAnswer; i++) {
                graph.DrawLine(pen,
                    ArrayButton[0, 0].Location.X -5,
                    ArrayAnswer[i].Location.Y + ArrayAnswer[i].Size.Height / 2,
                    ArrayButton[0, i].Location.X + this.SizeOfButton / 2,
                    ArrayAnswer[i].Location.Y + ArrayAnswer[i].Size.Height / 2);
                graph.DrawLine(pen,
                     ArrayButton[0, i].Location.X +this.SizeOfButton /2 ,
                     ArrayAnswer[i].Location.Y + ArrayAnswer[i].Size.Height / 2,
                     ArrayButton[0, i].Location.X + this.SizeOfButton / 2,
                     ArrayAnswer[0].Location.Y -20);


            }
        
        }
        private void AddAnswerMatrix(Array AnswerMatr) { 
        if (ArrayButton ==null&&AnswerMatr==null) System.Windows.Forms.MessageBox.Show("������� � ������ ��� �� �������!");
        else {
            AnswerMatrix = new bool[AnswerMatr.GetLength(0), AnswerMatr.GetLength(1)];
            AnswerMatrix = (bool[,])AnswerMatr.Clone();
             }
        }
        private void SetTimeForTest(int TFT)
        {
            if (TFT > 30) this.TimeForTest = TFT;
            else this.TimeForTest = 300; //��������

        }
        private void AddMatrixOfMark(Array MatrixOfMark)
        {
            if (MatrixOfMark == null) System.Windows.Forms.MessageBox.Show("������� ������� �� ������!");
            else
            {
                this.MatrixOfMark = new int[MatrixOfMark.GetLength(0), MatrixOfMark.GetLength(1)];
                this.MatrixOfMark = (int[,])MatrixOfMark.Clone();
            }
        }

    }
}
