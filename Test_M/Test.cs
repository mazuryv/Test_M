using System;
using System.Collections.Generic;
using System.Text;

namespace Test_M
{ 
    
    [Serializable]
    public class Test
    {   
        private string NameOfTest;
        private string NameOfQuestion;
        private string NameOfAnswer;
        private System.Collections.ArrayList Question;
        private System.Collections.ArrayList Answer;
        private Array AnswerMatr;
        private Array MatrixOfMark;
        private int TimeToText;
        private int OwnerID;

        public Test() {
            NameOfAnswer = "���� �1 ";
            NameOfQuestion = "��������";
            NameOfTest = "�������/������� ��в�����";
            TimeToText = 300;
        
        }

        public void SetNameOfTest(string NameOfTest) {
            if (NameOfTest.Length <= 30) this.NameOfTest = NameOfTest;
            else System.Windows.Forms.MessageBox.Show("����� ���� (������� ������� �������� ��� ����� �����)");
        }
        public string GetNameOfTest()
        {
            return this.NameOfTest;
        }
        public void SetNameOfQuestion(string NameOfQuestion)
        {
            if (NameOfQuestion.Length <= 27) this.NameOfQuestion = NameOfQuestion;
            else System.Windows.Forms.MessageBox.Show("����� ���� (������� ������� �������� ��� ����� ��������)");
        }
        public string GetNameOfQuestion()
        {
            return this.NameOfQuestion;
        }
        public void SetNameOfAnswer(string NameOfAnswer)
        {
            if (NameOfAnswer.Length <= 27) this.NameOfAnswer = NameOfAnswer;
            else System.Windows.Forms.MessageBox.Show("����� ���� (������� ������� �������� ��� ����� ��������)");
        }
        public string GetNameOfAnswer()
        {
            return this.NameOfAnswer;
        }
        public void SetQuestion(params string[] str)
        {
            if (str.Length > 10) System.Windows.Forms.MessageBox.Show("����� ���� (������� ����� �������� �������\n" +
                    "��������� ����������� �� ����� 10!!!)");
            else
            {
                Question = new System.Collections.ArrayList();
                foreach (string item in str)
                {
                    if (item.Length < 101) Question.Add(item);
                    else System.Windows.Forms.MessageBox.Show("����� ���� (������� ������� ������: \n" + item + ")\n");
                }
            }
        }
        public System.Collections.ArrayList GetQuestion() {
            if (this.Question != null) return this.Question;
            else
            {
                System.Windows.Forms.MessageBox.Show("����� ���� (�������� ������� ������� ��� ��������� \n" +
                "��������. ��� �������!!!)");
                return new System.Collections.ArrayList();
            }
        }
        public void SetAnswer(params string[] str)
        {
            if (str.Length > 10) System.Windows.Forms.MessageBox.Show("����� ���� (������� ����� ������� �������\n" +
                    "��������� ����������� �� ����� 10!!!)");
            else
            {
                Answer= new System.Collections.ArrayList();
                foreach (string item in str)
                {
                    if (item.Length < 101) Answer.Add(item);
                    else System.Windows.Forms.MessageBox.Show("����� ���� (������� ������� �����: \n" + item + ")\n");
                }
            }
        }
        public System.Collections.ArrayList GetAnswer()
        {
            if (this.Answer != null) return this.Answer;
            else
            {
                System.Windows.Forms.MessageBox.Show("����� ���� (�������� ������� ������� ��� ��������� \n" +
                "�����  �������. ��� �������!!!)");
                return new System.Collections.ArrayList();
            }
        }
        public void SetAnswerMatr(bool[,] Matrix) {
            if ((this.GetAnswer().Count != 0) && (this.GetQuestion().Count != 0))
            {
                AnswerMatr = new Array[Matrix.GetLength(0), Matrix.GetLength(1)];
                AnswerMatr = (Array)Matrix.Clone();
            }
        }
        public void SetAnswerMatr(string str)
        {//��� �������� � �������� ��������� � ���� "11,22,06" � �.�.
            if ((this.GetAnswer().Count != 0) && (this.GetQuestion().Count != 0))
              {
                if (str.Length < 0) System.Windows.Forms.MessageBox.Show("����� ���� (�� ����� �������� ���� \"11,22,06\")");
                else {
                   
                    bool[,] AnswerMatrix = new bool[this.GetQuestion().Count, this.GetAnswer().Count];
                    for (int i = 0; i < this.GetQuestion().Count; i++)
                    for (int a = 0; a < this.GetAnswer().Count; a++) AnswerMatrix[i, a] = false; //��������� ������� ���������� ���

                char[] ChrStr = new char[str.Length];
                    ChrStr=str.ToCharArray();
                int b = -1, c = -1;
                for (int i = 0; i < ChrStr.Length; i++)
                {
                    if (ChrStr[i] > 47 && ChrStr[i] < 58)
                    {
                        if (b > -1 && b < 10) c = Convert.ToInt32(ChrStr[i])-48;
                        if(b==-1) b = Convert.ToInt32(ChrStr[i])-48; 

                    }
                    else if (ChrStr[i] == ',')
                    {
                        if (b > -1 && b < 10 && c > -1 && c < 10)
                        {//��� �������� �������� ���������� � �������
                            AnswerMatrix[b, c] = true;
                            b = -1; c = -1;
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("����� ���� (�������� ���� \"11,22,06\" ����� �����������(������ ����))");
                            b = -1; c = -1; 
                        }
                        }
                    else System.Windows.Forms.MessageBox.Show("����� ���� (�������� ���� \"11,22,06\" ����� �����������)");
                
                }


                this.SetAnswerMatr(AnswerMatrix);
                }



            }
        }
        public Array GetAnswerMatr() {
            return this.AnswerMatr;
        }
        public void SetTimeForTest(string str) {
            int a =Convert.ToInt32(str);
            if (a > 30) this.TimeToText = a;
            else this.TimeToText = 300;

        }
        public void SetTimeForTest(int time)
        {   if (time > 30) this.TimeToText = time;
            else this.TimeToText = 300;
        }
        public int GetTimeForTest()
        {
            return this.TimeToText;
        }
        public void SetOwnerID(int ID)
        {
            this.OwnerID = ID;        
        }
        public int GetOwnerID() { return this.OwnerID; }

    
     public void SetMatrixOfMark (int[,] Matrix) {
            if ((this.GetAnswer().Count != 0) && (this.GetQuestion().Count != 0))
            {
                this.MatrixOfMark  = new Array[Matrix.GetLength(0), Matrix.GetLength(1)];
                this.MatrixOfMark = (Array)Matrix.Clone();
            }
        }
     public Array GetMatrixOfMark() {
            return this.MatrixOfMark;
        }
        public override string ToString()
        {
            return this.GetNameOfTest();
        }
    }


    [Serializable]
    public class CollectionOfTest
    {
        private System.Collections.ArrayList ArrayOfTest;
        private int HowMark;
        private int OwnerID;
        private string name;

        public CollectionOfTest()
        {
            ArrayOfTest = new System.Collections.ArrayList(10);
            HowMark = 0; //������ ����� ����������� ����� 
            name = "";
        }

        public void AddTestInListBox(System.Windows.Forms.ListBox listBox)
        {
            foreach (Test NewTest in ArrayOfTest)
            {
                if (NewTest != null) listBox.Items.Add(NewTest);
            }
        }
        public void DelTestOfCollection(Test DelTest)
        {                ArrayOfTest.Remove(DelTest);
                        }
        public void SetName(String Name)
        {
            if (Name.Length > 0) this.name = "(K) "+Name;
        }

        public override string ToString()
        {
            return name;
        }
        public int AddTestInCollection(Test NewTest)
        {
            if (ArrayOfTest.Count> 10)
            {
                System.Windows.Forms.MessageBox.Show("������� ����� 10 ����� ��� ��������. ����� ����� 10-�� �������� �� ������!");
                return 1;
            }
           
            //�������� ������� ��������� �����
            for (int i=0; i<ArrayOfTest.Count;i++)
                if(ArrayOfTest[i].ToString()==NewTest.ToString())
                    {   System.Windows.Forms.MessageBox.Show("���� � ������ \"" + NewTest + "\" ��� ��������� �� ��������. ������� ����� ����.");
                        return 1;
                    }


                    if(ArrayOfTest.Add(NewTest)>-1) return 0;//��� ����
                    
            return 1;

        }
        public void SetHowMark(int how)
        {
            if (how >= 0 && how < 4) this.HowMark = how;
            else System.Windows.Forms.MessageBox.Show("Class CollectionOfTest. ����������� ������� ����� ����������... ��������� ������ �� 0 �� 3");
        }
        public int GetHowMark()
        { return this.HowMark; }
        public System.Collections.ArrayList GetTests() 
        {
            return this.ArrayOfTest;
        }
        public void SetOwnerID(int ID)
        {
            this.OwnerID = ID;
        }
        public int GetOwnerID() { return this.OwnerID; }
    }
}

       

