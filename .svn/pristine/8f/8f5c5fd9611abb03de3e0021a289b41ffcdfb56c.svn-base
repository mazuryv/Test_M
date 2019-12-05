using System;
using System.Collections.Generic;
using System.Text;

namespace Test_M
{
    [Serializable]
    public class Predmet
    {
        private String NPredmet;
        private System.Collections.ArrayList ArrayOfTest;
        private int TeacherID; //власник вказаного предмету
        //методы
        //конструктор
        public Predmet() {
            this.NPredmet = "";
            this.ArrayOfTest = new System.Collections.ArrayList();
        }
        public Predmet(String Predmet, int TeacherID) { 
        if(Predmet.Length>0) this.NPredmet=Predmet;
        else System.Windows.Forms.MessageBox.Show("Class Predmet :Название предмета не задано!");
        this.ArrayOfTest = new System.Collections.ArrayList();
        this.TeacherID = TeacherID;
        }
        public Predmet(String Predmet, System.Collections.ICollection c, int TeacherID)
        { 
        if(Predmet.Length>0) this.NPredmet=Predmet;
        else System.Windows.Forms.MessageBox.Show("Class Predmet : Название предмета не задано!");
        if(c.Count >0) this.ArrayOfTest= new System.Collections.ArrayList(c);
        else System.Windows.Forms.MessageBox.Show("Class Predmet : Список тестов не предоставлен!");
        this.TeacherID = TeacherID;

        }
        public void SetNameOfPredmet(String Predmet )
        {     
        if(Predmet.Length>0) this.NPredmet=Predmet;
        else System.Windows.Forms.MessageBox.Show("Class Predmet :Название предмета не задано!");
        }
        public String GetNameOfPredmet() { return this.NPredmet; }
        public override string ToString()
        {
            return this.NPredmet;
        }
        public void SetTests(System.Collections.ICollection c ) 
        { 
        if(c.Count >0) this.ArrayOfTest= new System.Collections.ArrayList(c);
        else System.Windows.Forms.MessageBox.Show("Class Predmet : Список тестов не предоставлен!");
        }

        public Object [] GetTests()
        {
            Object [] ArrayOfTests = new Object[this.ArrayOfTest.Count];
            for (int i = 0; i < this.ArrayOfTest.Count; i++)
            {
                ArrayOfTests[i] = this.ArrayOfTest[i];
            }
            return ArrayOfTests;
        
        }
        public void AddTest(Test test)
        {
            if (test.ToString().Length > 0)
                this.ArrayOfTest.Add(test);
            else System.Windows.Forms.MessageBox.Show("Class Predmet : При добавлении теста его данные не полные!");
        }
        public void AddCollection(CollectionOfTest  COT)
        {
            if (COT.ToString().Length > 0)
                this.ArrayOfTest.Add(COT);
            else System.Windows.Forms.MessageBox.Show("Class Predmet : При добавлении теста его данные не полные!");
        }
        public void DelTest( Object test){
            if (test.ToString().Length > 0)
            this.ArrayOfTest.Remove(test);
            else System.Windows.Forms.MessageBox.Show("Class Predmet : При удалении теста его данные не полные!");
        }
        public void DelTest( String Nametest){
        if(Nametest.Length>0)
        {Test test= new Test();
            for(int i=0;i<this.ArrayOfTest.Count;i++){
            test=(Test)this.ArrayOfTest[i];
            if (test.ToString().Equals(Nametest)) { this.ArrayOfTest.RemoveAt(i); break; }
            }   
        } 
            else System.Windows.Forms.MessageBox.Show("Class Predmet : При удалении теста его данные не полные!");
        }
        public int GetTeacherID() { return this.TeacherID; }
        public Object FindTest(String Nametest)
        {
            
            for (int i = 0; i < this.ArrayOfTest.Count; i++)
            {
                if (this.ArrayOfTest[i].ToString().Equals(Nametest)) return this.ArrayOfTest[i];
            }
            return new Test();
        }
        public void RenameTest(Object  WhatRename, String NewName)
        {
            Test NT=new Test();
            
            if (WhatRename.GetType().Equals(NT.GetType()))
            ((Test)ArrayOfTest[ArrayOfTest.IndexOf(WhatRename)]).SetNameOfTest(NewName);
            else 
            ((CollectionOfTest)ArrayOfTest[ArrayOfTest.IndexOf(WhatRename)]).SetName(NewName);
        }

    }
    /*[Serializable]
    public class Test
    {
    private String NameOfTest;
    private String pathOfTest;
        public Test(){
        this.NameOfTest="";
            this.pathOfTest="";
        }
        public Test(String NameOfTest){
        if(NameOfTest.Length >0) this.NameOfTest=NameOfTest;
        else System.Windows.Forms.MessageBox.Show("Class Test :Имя теста не задано!");
        }
        public Test(String NameOfTest, String pathOfTest){
        if(NameOfTest.Length >0) this.NameOfTest=NameOfTest;
        else System.Windows.Forms.MessageBox.Show("Class Test :Имя теста не задано!");
        if(pathOfTest.Length >0) this.pathOfTest=pathOfTest;
        else System.Windows.Forms.MessageBox.Show("Class Test :Путь к тесту не задан!");
        }
        public void SetName(String NameOfTest){
        if(NameOfTest.Length >0) this.NameOfTest=NameOfTest;
        else System.Windows.Forms.MessageBox.Show("Class Test :Имя теста не задано!");
        }
        public void SetPath (String pathOfTest){
        if(pathOfTest.Length >0) this.pathOfTest=pathOfTest;
        else System.Windows.Forms.MessageBox.Show("Class Test :Путь к тесту не задан!");
        }
        public override string ToString()
        {
            return this.NameOfTest;
        }
        public String GetPath() {return this.pathOfTest;}

        public void RenameTest(String NewName) 
        {
            this.NameOfTest = NewName;
        }
     
    }
* */
}





