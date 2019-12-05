using System;
using System.Collections.Generic;
using System.Text;

namespace Test_M
{
    [Serializable]

    public class Journal
    {
        protected List<Log> list;

        public Journal()
        {
            list=new List<Log>();
        }
        public Journal(Journal copy)
        {
            list = new List<Log>();
            list.AddRange(copy.list);
        }
        public void AddLogTest(int UserID, Predmet predmet, Test NameOfTest, int Prav, int Neprav, int Mark)
        {
            if (UserID > 0 && predmet != null && NameOfTest != null && Prav > -1 && Neprav > -1 && Mark > -1)
                list.Add(new Log(UserID, predmet, NameOfTest.ToString(), Prav, Neprav, Mark));
            else System.Windows.Forms.MessageBox.Show("Класс Журнал! входные данные о добавляемой записи теста  не соответсвуют формату ");
        }
        public void AddLogCollection(int UserID, Predmet predmet, CollectionOfTest NameOfTest, int[] Prav, int[] Neprav, int [] CollMark, double Mark)
        {
            if (UserID > 0 && predmet != null && NameOfTest != null&& Mark > -1&&Prav.Length>0&&Neprav.Length>0&&CollMark.Length>0)
                list.Add(new Log(UserID, predmet, NameOfTest.ToString(), Prav,Neprav,CollMark,Mark));
            else System.Windows.Forms.MessageBox.Show("Класс Журнал! входные данные о добавляемой записи коллекции не соответсвуют формату ");
        }
        public int GetUserID(int NumberOfLog) { return list[NumberOfLog].GetUserID(); }
        public DateTime GetTime(int NumberOfLog) { return list[NumberOfLog].GetTime(); }
        public Predmet GetPredmet(int NumberOfLog) { return list[NumberOfLog].GetPredmet(); }
        public String GetNameOfTest(int NumberOfLog) { return list[NumberOfLog].GetNameOfTest(); }
        public double GetMark(int NumberOfLog) { return list[NumberOfLog].GetMark(); }
        public bool IsTest(int NumberOfLog) { return list[NumberOfLog].IfTest(); }
        public int[] GetPrav(int NumberOfLog)
        {
           
                return this.list[NumberOfLog].GetPrav();
           
        }
        public int[] GetNeprav(int NumberOfLog)
        {
            
                return this.list[NumberOfLog].GetNeprav();
           
        }
        public int[] GetCollMark(int NumberOfLog)
        {
            
                return this.list[NumberOfLog].GetCollMark();
           
        }
        public int Length()
        { return list.Count; }
        public void DelOldLog()//по умолчанию месячной давности
        {
            this.list.RemoveAll(Month);
        }

        private static bool Month(Log log)
        {
            TimeSpan  month = new TimeSpan(30,0,0,0,0);
            DateTime result = DateTime.Now.AddMonths(-1);
            if (log.GetTime().CompareTo(result)<0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void DelLog (int NumberOfLog)
        {
            this.list.RemoveAt(NumberOfLog);
        }

    }




    [Serializable]
    public class Log
    {
        private int UserID;//идентификатор ученика
        private DateTime time; //время прохождения теста
        private Predmet predmet; //наименование предмета, по которому проходил тест
        private String NameOfTest; //имя теста
        private bool IsTest;//знак прохождения теста: правда- тест, неправда - коллекция
        private double  Mark; //оценка по тесту (общая по коллекции)
        private int[] Prav; //массив значений правильніх ответов. Prav[0]- колличество правильных в тесте (не коллекции)
        private int[] Neprav;//массив значений неправильніх ответов. Neprav[0]- колличество неправильных в тесте (не коллекции)
        private int[] CollMark;//массив оценок по тестам в коолекции (без указания которых)

        public Log()
        {
            UserID = 0;
            time = DateTime.Now;
            predmet = new Predmet();
            NameOfTest = "";
            IsTest = true;
            Mark = 0;
            Prav = new int[10];
            Neprav = new int[10];
            CollMark = new int[10];
        
        }

        public Log(int UserID, Predmet predmet, String NameOfTest, int Prav, int Neprav, double Mark)//лог для одиночного теста
        {
            this.UserID = UserID;
            this.time = DateTime.Now;
            this.predmet = predmet;
            this.NameOfTest = NameOfTest;
            this.IsTest = true;
            this.Mark = Mark ;
            this.Prav = new int[1];
            this.Prav[0] = Prav;
            this.Neprav = new int[1];
            this.Neprav[0] = Neprav;
            this.CollMark = new int[1];
            this.CollMark[0] = 0;

        }
        public Log(int UserID, Predmet predmet, String NameOfTest, int[] Prav, int[] Neprav, int [] CollMark, double Mark)//лог для одиночного теста
        {
            this.UserID = UserID;
            this.time = DateTime.Now;
            this.predmet = predmet;
            this.NameOfTest = NameOfTest;
            this.IsTest = false;
            this.Mark = Mark;
            this.Prav = new int[Prav.Length];
            for (int i = 0; i < Prav.Length; i++) if (Prav[i]>-1) this.Prav[i] = Prav[i];
            this.Neprav = new int[Neprav.Length];
            for (int i = 0; i < Neprav.Length; i++) if (Neprav[i] > -1) this.Neprav[i] = Neprav[i];
            this.CollMark = new int[CollMark.Length ];
            for (int i = 0; i < CollMark.Length; i++) if (CollMark[i] > -1) this.CollMark[i] = CollMark[i];

        }
        public int GetUserID() { return this.UserID; }
        public DateTime GetTime() { return this.time; }
        public Predmet GetPredmet() { return this.predmet; }
        public String GetNameOfTest() { return this.NameOfTest; }
        public double GetMark() { return this.Mark; }
        public bool IfTest() { return this.IsTest; }
        public int[] GetPrav()
        {
            
                return this.Prav;
            
        }
        public int[] GetNeprav()
        {
            
                return this.Neprav;
          
           
        }
        public int[] GetCollMark()
        {
           
                return this.CollMark;
           
        }

    }
}
