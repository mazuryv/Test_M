using System;
using System.Collections.Generic;
using System.Text;

namespace Test_M
{[Serializable]
    public class Admin
    {   //члены класса
        protected String name; //имя пользователя
        protected String password; //пароль доступа 
        protected int Role; //роль пользователя : 1- ученик, 2- преподаватель, 3- администратор
        protected int ID;
        public Admin()
        {
            name = "";
            password = "";
            Role = 3;
            ID = 0;
            }
        public Admin(String name, String password)
        {
            this.name = name;
            this.password = password;
            Role = 3;
            ID = 0;
        }
       

        //методы для установки значений и их чтения
        public void SetPassword(String password)
        {
            if (password.Length > 0) this.password = password;
            else System.Windows.Forms.MessageBox.Show("Метод User : устанавливаемый пароль пуст");
        }
        public void SetName (String name)
        {
            if (name.Length > 0) this.name = name;
            else System.Windows.Forms.MessageBox.Show("Метод User : устанавливаемое имя пусто");
        }
        public String GetPassword()
        {
            return this.password;
        }
        public override string ToString()
        {
            return name;
        }
        public void SetID(int NewID) {
            if (NewID != 0) this.ID = NewID;
        }
        public int GetID() {
            return ID;
        }
    }


    [Serializable] 
    public class User: Admin
    {   protected Group  group; //указатель группы в которую входит ученик 
        //методы
        //конструкторы
        public User()
        {
            name = "";
            password = "";
            Role = 1;
            group = new Group();
        }
        public User(String name, String password)
        {
            this.name = name;
            this.password = password;
            Role = 1;
            group = new Group();
        }
       
        public User(String name, String password, MainForm MF, String group, int NewID)
        {
            this.name = name;
            this.password = password;
            Role = 1;
            this.group = new Group(group);
            this.group.AddUser(this, NewID);
            MF.setting.AddGroup(this.group);
            
            
        }
    
        public Group GetGroup()
        {
            return this.group;
        }

        public void SetGroup (Group group) 
        {
            if (group != null) this.group = group;
            else System.Windows.Forms.MessageBox.Show("Class User : При установке группы она не была задана!");
        }

       
    }
    [Serializable]
    public class Teacher : Admin
    {
        private System.Collections.ArrayList ArrayOfPredmet; //массив предметов, преподаваемых преподавателем(в которые включаються сами тесты)
        //методы
        //конструкторы
        public Teacher()
        {
            name = "";
            password = "";
            Role = 2;
            ArrayOfPredmet = new System.Collections.ArrayList();

        }
        
        public Teacher(String name, String password)
        {
            this.name = name;
            this.password = password;
            Role = 2;
            ArrayOfPredmet = new System.Collections.ArrayList();

        }
        public Teacher(String name, String password, System.Collections.ICollection c)
        {
            this.name = name;
            this.password = password;
            Role = 2;
            ArrayOfPredmet = new System.Collections.ArrayList(c);
        }
        public void SetArrayOfPredmet(System.Collections.ICollection c)
        {
            if (c.Count > 0) ArrayOfPredmet = new System.Collections.ArrayList(c);
            else System.Windows.Forms.MessageBox.Show("Метод Teacher : Список предметов не задан!");
        }
        public Predmet [] GetArrayOfPredmet()
        {
            Predmet[] ArrPr= new Predmet[this.ArrayOfPredmet.Count];
            for (int i = 0; i < this.ArrayOfPredmet.Count; i++)
            {
                ArrPr.SetValue(ArrayOfPredmet[i], i);
            }
            return ArrPr;
        }
        public void AddPredmet(Predmet Predmet)
        {
            if (Predmet.GetNameOfPredmet().Length > 0) this.ArrayOfPredmet.Add(Predmet);
            else System.Windows.Forms.MessageBox.Show("Class Teacher : При добавлении предмета его название не введено!");
        }
        public void DelPredmet(Predmet Predmet, Setting DelFrom)
        {
            if (Predmet.GetNameOfPredmet().Length > 0) { 
                
                this.ArrayOfPredmet.Remove(Predmet); 
                //нужно удалить его и из всех групп
                for (int i = 0; i < DelFrom.GetAllGroups().Length; i++)
                {
                    for (int a = 0; a < DelFrom.GetGroup(i).GetAllPredmet().Length; a++) {
                        if (DelFrom.GetGroup(i).GetPredmet(a).ToString().Equals(Predmet.ToString())) {
                            this.DelPredmetInGroup(DelFrom.GetGroup(i),Predmet);
                        
                        }
                    }

                }
            
            }
            else System.Windows.Forms.MessageBox.Show("Class Teacher : При удалении предмета его название не введено!");
        }
        public void DelAllPredmetInGroupThisTeacher(BaseSetting DelFrom)
        {

            for (int q = 0; q < this.ArrayOfPredmet.Count; q++)
            {
                for (int i = 0; i < DelFrom.GetAllGroups().Length; i++)
                {
                    for (int a = 0; a < DelFrom.GetGroup(i).GetAllPredmet().Length; a++)
                    {
                        if (DelFrom.GetGroup(i).GetPredmet(a).ToString().Equals(this.ArrayOfPredmet[q].ToString()))
                        {
                            this.DelPredmetInGroup(DelFrom.GetGroup(i), ((Predmet)this.ArrayOfPredmet[q]));

                        }
                    }

                }
            }
        }
        public void AddPredmet(String NameOfPredmet)
        {
            if (NameOfPredmet.Length > 0)
            {
                Predmet predm = new Predmet();
                for (int i = 0; i < this.ArrayOfPredmet.Count; i++)
                {
                    predm = (Predmet)this.ArrayOfPredmet[i];
                    if (predm.GetNameOfPredmet().Equals(NameOfPredmet)) { this.ArrayOfPredmet.RemoveAt(i); break; }
                }
            }
            else System.Windows.Forms.MessageBox.Show("Class Teacher : При удалении предмета его название не введено!");

       }
        public void AddPredmetInGroup(Group group, int IndexOfPredmet)
        {
            if (group != null&& IndexOfPredmet>=0)
            group.AddPredmet((Predmet)ArrayOfPredmet[IndexOfPredmet]);
         }
        public void DelPredmetInGroup(Group group, Predmet predmet)
        {
            if (group != null && predmet !=null)
                group.DelPredmet(predmet);
        }
        public void AddPredmetInGroup(Setting ThisSetting, String NameOfGroup, int IndexOfPredmet)
        {
            if (ThisSetting != null && IndexOfPredmet >= 0)
            {
                Group group = ThisSetting.GetGroup(NameOfGroup);
                group.AddPredmet((Predmet)ArrayOfPredmet[IndexOfPredmet]);
            }
        }
        public void DelPredmetInGroup(Setting ThisSetting, String NameOfGroup, int IndexOfPredmet)
        {
            if (ThisSetting != null && IndexOfPredmet >= 0)
            {
                Group group = ThisSetting.GetGroup(NameOfGroup);
                group.DelPredmet((Predmet)ArrayOfPredmet[IndexOfPredmet]);
            }
        }
    }

    [Serializable]
    public class Group {
        private string NameOfGroup;
        private System.Collections.ArrayList Students;
        private System.Collections.ArrayList Predmets;

        public Group() {
            NameOfGroup = "";
            Students = new System.Collections.ArrayList();
            Predmets = new System.Collections.ArrayList();
        }
        public Group(String NameOfGroup)
        {
            this.NameOfGroup = NameOfGroup;
            Students = new System.Collections.ArrayList();
            Predmets = new System.Collections.ArrayList();
        }
        public void SetNameOfGroup(String NameOfGroup)
        {
            this.NameOfGroup = NameOfGroup;
        }
        public override string  ToString()
        {
             return this.NameOfGroup;
        }
        public void AddUser(User user, int NewID)
        {
            if (user != null) {
                user.SetID(NewID);
                Students.Add(user);
                user.SetGroup(this);
            }
            else System.Windows.Forms.MessageBox.Show("Класс Group! Добавляемый элемент не существует!");
        }
        public void DelUser(User user)
        {
            if (user != null) Students.Remove(user);
            else System.Windows.Forms.MessageBox.Show("Класс Group! Удаляемый элемент не существует!");
        }
        public void AddPredmet(Predmet Predmet)
        {
            if (Predmet != null)
            {
                Predmets.Add(Predmet);
                
            }
            else System.Windows.Forms.MessageBox.Show("Класс Group! Добавляемый элемент не существует!");
        }
        public void DelPredmet(Predmet Predmet)
        {
            if (Predmet != null) Predmets.Remove(Predmet);
            else System.Windows.Forms.MessageBox.Show("Класс Group! Удаляемый элемент не существует!");
        }
        public User GetUser(int count)
        {
            if (count > Students.Count) { System.Windows.Forms.MessageBox.Show("Класс Group! Номер вызываемого элемента больше чем элементов в списке!"); return new User(); }
            else return (User)Students[count];
        }
        public User[] GetAllUser() 
        {
            User[] AllUser = new User[this.Students.Count];
            for (int i = 0; i < this.Students.Count; i++)
            {
                AllUser.SetValue(this.Students[i],i);
            }
            return AllUser;
        }
        public Predmet GetPredmet(int count)
        {
            if (count > Predmets.Count) { System.Windows.Forms.MessageBox.Show("Класс Group! Номер вызываемого элемента больше чем элементов в списке!"); return new Predmet(); }
            else return (Predmet)Predmets[count];
        }
        public Predmet[] GetAllPredmet()
        {
            Predmet[] AllPredmet = new Predmet[this.Predmets.Count];
            for (int i = 0; i < this.Predmets.Count; i++)
            {
                AllPredmet.SetValue(this.Predmets[i], i);
            }
            return AllPredmet;
        }




    }
}
