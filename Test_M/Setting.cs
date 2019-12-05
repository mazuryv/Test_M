using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Security.Permissions;
using System.IO;

namespace Test_M
{
    [Serializable]
    public abstract class BaseSetting
    {
        protected System.Collections.ArrayList Admins;
        protected System.Collections.ArrayList Teachers;
        protected System.Collections.ArrayList Groups;
        protected int NewIDOfUsers;
        protected bool[] Options;
        protected int TimeForNewTest;
        protected int[,] MatrixOfMark ={ { 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 }, { -1, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 }, { -1, -1, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, { -1, -1, -1, 6, 5, 4, 3, 2, 1, 0, 0 }, { -1, -1, -1, -1, 4, 3, 2, 1, 0, 0, 0 }, { -1, -1, -1, -1, -1, 2, 1, 0, 0, 0, 0 } };
        protected Journal journal;


        //можно создавать и другие настройки
        public BaseSetting()
        {
        }
        public void AddAdmin(Admin Adm)
        {
            if (Adm.ToString().Length > 0)
            {
                bool NotFound = true;
                foreach (Admin adm in this.Admins)
                    if (adm.ToString().Equals(Adm.ToString()))
                    {
                        System.Windows.Forms.MessageBox.Show("Class BaseSetting : Админ с таким именем уже существует!");
                        NotFound = false;
                        break;
                    }
                if (NotFound)
                {
                    //присваиваем идентификатор и добавляем счетчик
                    Adm.SetID(this.NewIDOfUsers);
                    NewIDOfUsers++;
                    this.Admins.Add(Adm);
                }
            }
            else System.Windows.Forms.MessageBox.Show("Class BaseSetting : При добавлении админа его имя не указано!");
        }
        public void AddTeacher(Teacher Teach)
        {
            if (Teach.ToString().Length > 0)
            {

                bool NotFound = true;
                foreach (Teacher teacher in this.Teachers)
                    if (teacher.ToString().Equals(Teach.ToString()))
                    {
                        System.Windows.Forms.MessageBox.Show("Class BaseSetting : Учитель с таким именем уже существует!");
                        NotFound = false;
                        break;
                    }

                if (NotFound)
                {
                    Teach.SetID(this.NewIDOfUsers++);
                    this.Teachers.Add(Teach);
                }

            }
            else System.Windows.Forms.MessageBox.Show("Class BaseSetting : При добавлении преподавателя его имя не указано!");
        }
        public void AddGroup(Group group)
        {
            if (group != null)
            {
                if (this.GetGroup(group.ToString()).ToString().Equals(group.ToString()))
                    System.Windows.Forms.MessageBox.Show("Class BaseSetting : Группа с таким название уже существует!");
                else this.Groups.Add(group);
            }

            else System.Windows.Forms.MessageBox.Show("Class BaseSetting : При добавлении группы она не существует!");
        }
        public void DelAdmin(Admin AdminWhoDel)
        {
            if (Admins.Count < 2) System.Windows.Forms.MessageBox.Show("Class BaseSetting : Удалить админа не могу, он последний!");
            else if (AdminWhoDel != null) this.Admins.Remove(AdminWhoDel);
            else System.Windows.Forms.MessageBox.Show("Class BaseSetting : Удалить админа не могу, кого удалять не задано!");
        }
        public void DelAdmin(String AdminWhoDel)
        {
            if (Admins.Count < 2) System.Windows.Forms.MessageBox.Show("Class BaseSetting : Удалить админа не могу, он последний!");
            else if (AdminWhoDel != null)
            {
                for (int i = 0; i < this.Admins.Count; i++)
                {
                    Admin AdminObj = (Admin)Admins[i];
                    if (AdminObj.ToString().Equals(AdminWhoDel))
                        Admins.Remove(this.Admins[i]);
                }
            }
            else System.Windows.Forms.MessageBox.Show("Class BaseSetting : Удалить админа не могу, кого удалять не задано!");

        }
        public void DelTeacher(Teacher TeacherWhoDel)
        {
            if (Teachers.Count < 1) System.Windows.Forms.MessageBox.Show("Class BaseSetting : Удалить учителя не могу, он последний!");
            else if (TeacherWhoDel != null) this.Teachers.Remove(TeacherWhoDel);
            else System.Windows.Forms.MessageBox.Show("Class BaseSetting : Удалить учителя не могу, кого удалять не задано!");


        }
        public void DelTeacher(String TeacherWhoDel)
        {
            if (Teachers.Count < 1) System.Windows.Forms.MessageBox.Show("Class BaseSetting : Удалить учителя не могу, он последний!");
            else if (TeacherWhoDel != null)
            {
                for (int i = 0; i < this.Teachers.Count; i++)
                {
                    Teacher TeacherObj = (Teacher)Teachers[i];
                    if (TeacherObj.ToString().Equals(TeacherWhoDel))
                    {
                        ((Teacher)this.Teachers[i]).DelAllPredmetInGroupThisTeacher(this);
                        Teachers.Remove(this.Teachers[i]);
                    }
                }
            }
            else System.Windows.Forms.MessageBox.Show("Class BaseSetting : Удалить учителя не могу, кого удалять не задано!");

        }
        public void DelGroup(Group GroupWhoDel)
        {
            if (Groups.Count < 1) System.Windows.Forms.MessageBox.Show("Class BaseSetting : Удалить группу не могу, он последний!");
            else if (GroupWhoDel != null) this.Groups.Remove(GroupWhoDel);
            else System.Windows.Forms.MessageBox.Show("Class BaseSetting : Удалить группу не могу, кого удалять не задано!");
        }
        public void DelGroup(String GroupWhoDel)
        {
            if (Groups.Count < 1) System.Windows.Forms.MessageBox.Show("Class BaseSetting : Удалить группу не могу, он последний!");
            else if (GroupWhoDel != null)
            {
                for (int i = 0; i < this.Groups.Count; i++)
                {
                    Group GroupObj = (Group)Groups[i];
                    String GroupObjStr = GroupObj.ToString();
                    if (GroupObjStr.Equals(GroupWhoDel))
                        Groups.Remove(this.Groups[i]);
                }
            }
            else System.Windows.Forms.MessageBox.Show("Class BaseSetting : Удалить группу не могу, кого удалять не задано!");

        }
        public Group[] GetAllGroups()
        {
            Group[] AllGroup = new Group[this.Groups.Count];
            for (int i = 0; i < this.Groups.Count; i++)
            {

                AllGroup.SetValue(this.Groups[i], i);
            }

            return AllGroup;

        }
        public Teacher[] GetAllTeachers()
        {
            Teacher[] AllTeacher = new Teacher[this.Teachers.Count];
            for (int i = 0; i < this.Teachers.Count; i++)
            {

                AllTeacher.SetValue(this.Teachers[i], i);
            }

            return AllTeacher;

        }
        public Admin[] GetAllAdmins()
        {
            Admin[] AllAdmins = new Admin[this.Admins.Count];
            for (int i = 0; i < this.Admins.Count; i++)
            {

                AllAdmins.SetValue(this.Admins[i], i);
            }

            return AllAdmins;

        }
        public Group GetGroup(int index)
        {
            if (index > Groups.Count) { System.Windows.Forms.MessageBox.Show("Класс BaseSetting!! Не могу дать группу вне диапазона"); return new Group(); }
            else return (Group)Groups[index];
        }
        public Group GetGroup(String group)
        {
            if (group != null)
            {
                for (int i = 0; i < this.Groups.Count; i++)
                {
                    Group GroupObj = (Group)Groups[i];
                    if (GroupObj.ToString().Equals(group))
                        return GroupObj;
                }
                return new Group();
            }
            else { System.Windows.Forms.MessageBox.Show("Class BaseSetting : Название группы не задано!"); return new Group(); }
        }
        public Admin FindAnyUserToID(int ID)
        {
            if (ID >= 0)
            {
                for (int i = 0; i < Admins.Count; i++)
                {
                    Admin admin = (Admin)this.Admins[i];
                    if (admin.GetID() == ID) return admin;
                }
                for (int i = 0; i < this.Teachers.Count; i++)
                {
                    Teacher teacher = (Teacher)this.Teachers[i];
                    if (teacher.GetID() == ID) return teacher;
                }
                for (int i = 0; i < this.Groups.Count; i++)
                {
                    Group group = (Group)this.Groups[i];
                    for (int a = 0; a < group.GetAllUser().Length; a++)
                    {
                        User user = group.GetUser(a);
                        if (user.GetID() == ID) return user;
                    }
                }



            }
            else System.Windows.Forms.MessageBox.Show("Class BaseSetting : Id пользователя для поиска меньше 0!");

            return new User("видалено", "");

        }
        public int GetNewIDAndNext()
        {
            this.NewIDOfUsers++;
            return this.NewIDOfUsers - 1;

        }
        public void EditAnyUser(int ID, string name, string password)
        {
            if (name.Length > 1 && password.Length > 0 && ID != 0)
            {
               
                this.FindAnyUserToID(ID).SetName(name);
                this.FindAnyUserToID(ID).SetPassword(password);



            }
            else System.Windows.Forms.MessageBox.Show("Class BaseSetting : При добавлении админа его имя не указано!");


        }
        public void SetAddUser(bool AllowAddUser)
        {
            Options[0] = AllowAddUser;
        }
        public void SetOnlyOur(bool AllowOnlyOur)
        {
            Options[1] = AllowOnlyOur;
        }
        public void SetPovtorSdachi(bool AllowPovtorSdachi)
        {
            Options[2] = AllowPovtorSdachi;
        }
        public bool GetAddUser() { return this.Options[0]; }
        public bool GetOnlyOur() { return this.Options[1]; }
        public bool GetPovtorSdachi() { return this.Options[2]; }
        public void SetTimeForNewTest(int TimeForNewTest)
        {
            if (TimeForNewTest > 0) this.TimeForNewTest = TimeForNewTest;
        }
        public int GetTimeForNewTest() { return this.TimeForNewTest; }
        public void SetMatrixOfMark(int[,] MatrOfMark)
        {
            if (MatrOfMark.GetLength(0) == 6 && MatrOfMark.GetLength(1) == 11)
            {
                for (int a = 0; a < MatrOfMark.GetLength(0); a++)
                    for (int b = 0; b < MatrOfMark.GetLength(1); b++)
                    {
                        if (MatrOfMark[a, b] > -2 && MatrOfMark[a, b] < 100) this.MatrixOfMark[a, b] = MatrOfMark[a, b];
                        else System.Windows.Forms.MessageBox.Show("Class BaseSetting : Матриця оцінювання заповнена значеннями, що не співпадають");
                    }

            }
            else System.Windows.Forms.MessageBox.Show("Class BaseSetting : Матриця оцінювання має інші розміри");
        }
        public int[,] GetMatrixOfMark() { return this.MatrixOfMark; }
        public void AddLogTest(int UserID, Predmet predmet,Test  NameOfTest, int Prav, int Neprav, int Mark)
        {
            if (UserID > 0 && predmet != null && NameOfTest != null && Prav > -1 && Neprav > -1 && Mark > -1)
                this.journal.AddLogTest(UserID, predmet, NameOfTest, Prav, Neprav, Mark);
            else System.Windows.Forms.MessageBox.Show("Класс BaseSetting! входные данные о добавляемой записи теста  не соответсвуют формату ");
        }
        public void AddLogCollection(int UserID, Predmet predmet,CollectionOfTest NameOfTest, int[] Prav, int[] Neprav, int[] CollMark, double Mark)
        {
            if (UserID > 0 && predmet != null && NameOfTest != null && Mark > -1 && Prav.Length > 0 && Neprav.Length > 0 && CollMark.Length > 0)
                this.journal.AddLogCollection(UserID, predmet, NameOfTest, Prav, Neprav, CollMark, Mark);
            else System.Windows.Forms.MessageBox.Show("Класс BaseSetting! входные данные о добавляемой записи коллекции не соответсвуют формату ");
        }
        public Journal GetCopyJournal()
        {
            return new Journal(this.journal);
        }
        public void DelOldJournal(DateTime DTOld)
        {
            for (int i = 0; i < this.journal.Length(); i++)
            {
                if (DTOld.CompareTo(this.journal.GetTime(i)) >0 ) { this.journal.DelLog(i); i--; }

            }

        }
        public void DelNullJournal()
        {
            for (int i = 0; i < this.journal.Length(); i++)
            {
                if ((this.FindAnyUserToID(this.journal.GetUserID(i)).ToString() == "видалено") || (this.FindAnyUserToID(this.journal.GetPredmet(i).GetTeacherID()).ToString() == "видалено")) { this.journal.DelLog(i); i--; }
            }

        }
        public DateTime WhenPassTest(Object WhatTest, int UserID)
        {
            for (int i = this.journal.Length() - 1; i >= 0; i--)
            {
                if ((this.journal.GetNameOfTest(i).Equals(WhatTest.ToString())) && (this.journal.GetUserID(i) == UserID))
                    return this.journal.GetTime(i);
            }
            return new DateTime();
        }

        public void ExportSetting(Setting From)
        {
            this.Admins = From.Admins;
            this.Groups = From.Groups;
            this.MatrixOfMark = From.MatrixOfMark;
            this.NewIDOfUsers = From.NewIDOfUsers;
            this.Options[0] = From.Options[0];
            this.Options[1] = From.Options[1];
            this.Options[2] = From.Options[2];
            this.Teachers = From.Teachers;
            this.TimeForNewTest = From.TimeForNewTest;


        }
        public void ImportSetting(Setting Where)
        {
            Where.Admins = this.Admins;
            Where.Groups = this.Groups;
            Where.MatrixOfMark = this.MatrixOfMark;
            Where.NewIDOfUsers = this.NewIDOfUsers;
            Where.Options[0] = this.Options[0];
            Where.Options[1] = this.Options[1];
            Where.Options[2] = this.Options[2];
            Where.Teachers = this.Teachers;
            Where.TimeForNewTest = this.TimeForNewTest;


        }

    } 
 
    

    [Serializable]
    public class Setting : BaseSetting
    {
    [Serializable]
    private class Registration
     {
        public bool IfRegisted=false;
        public bool IfOgranicheno = true;
        public bool IfStop = false;
        public DateTime DateOfCreate = DateTime.Now;
        public DateTime DateOfStop = DateTime.Now.AddDays(30);
        public string NameOfProcessor = "unknown";
        public string NameOfHardDisk = "unknown";
        public string NameOfWindows = "unknown";
        public string ProductIDOfWindows = "unknown";
        public System.Reflection.AssemblyName AssemblityN;
        public string SN;
        public string zarSN;
        public string RegisteredOwner = "";
        public string RegisteredOrganization = "";

     }
        private Registration Registr;
        
        public Setting()
        {
            Admins = new System.Collections.ArrayList();
            Teachers = new System.Collections.ArrayList();
            Groups = new System.Collections.ArrayList();
            NewIDOfUsers = 1;
            Options = new bool[3];
            Options[0] = Options[1] = Options[2] = false;
            TimeForNewTest = 60;
            journal = new Journal();
            Registr = new Registration();

                    try
                    {
                        RegistryKey rk = Registry.LocalMachine.OpenSubKey("HARDWARE\\DESCRIPTION\\SYSTEM\\CentralProcessor\\0");
                        if (rk != null)
                        {
                            this.Registr.NameOfProcessor = rk.GetValue("ProcessorNameString").ToString();
                            if (this.Registr.NameOfProcessor.Equals("")) this.Registr.NameOfProcessor = "unknown";
                        }
                        else this.Registr.NameOfProcessor = "unknown";
                    }
                    catch
                    {
                        System.Windows.Forms.MessageBox.Show("Class Setting : Помилка відкриття даних про процесор");
                    }
                    try
                    {
                        RegistryKey rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\\MICROSOFT\\WINDOWS NT\\CurrentVersion");
                        if (rk != null)
                        {
                            this.Registr.ProductIDOfWindows = rk.GetValue("ProductID").ToString();
                            this.Registr.NameOfWindows = rk.GetValue("ProductName").ToString();
                            if (this.Registr.ProductIDOfWindows.Equals("")) this.Registr.ProductIDOfWindows = "unknown";
                            if (this.Registr.NameOfWindows.Equals("")) this.Registr.NameOfWindows = "unknown";
                        }
                        else //ищем 98
                        {
                            rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\\MICROSOFT\\WINDOWS\\CurrentVersion");
                            if (rk != null)
                            {
                                this.Registr.ProductIDOfWindows = rk.GetValue("ProductID").ToString();
                                this.Registr.NameOfWindows = rk.GetValue("ProductName").ToString();
                                if (this.Registr.ProductIDOfWindows.Equals("")) this.Registr.ProductIDOfWindows = "unknown";
                                if (this.Registr.NameOfWindows.Equals("")) this.Registr.NameOfWindows = "unknown";
                            }
                        }
                    }
                    catch
                    {
                        System.Windows.Forms.MessageBox.Show("Class Setting : Помилка відкриття даних про операційну систему!");
                    }
                    try
                    {
                        RegistryKey rk = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum\\IDE");
                        if (rk != null)
                        {
                            string[] NamesOfHardDisk = rk.GetSubKeyNames();

                            RegistryKey rtemp, rtemp2;
                            for (int i = 0; i < NamesOfHardDisk.GetLength(0); i++)
                            {
                                rtemp = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum\\IDE\\" + NamesOfHardDisk[i].ToString());
                                string[] N = rtemp.GetSubKeyNames();
                                if (N.Length > 0)
                                {
                                    rtemp2 = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum\\IDE\\" + NamesOfHardDisk[i].ToString() + "\\" + N[0]);
                                    string[] ifDisk = (string[])rtemp2.GetValue("CompatibleIDs");
                                    if (ifDisk[0].Equals("GenDisk")) this.Registr.NameOfHardDisk = ((string[])rtemp2.GetValue("HardwareID"))[0];
                                }
                            }

                        }
                        else this.Registr.NameOfHardDisk = "unknown";
                    }
                    catch
                    {
                        System.Windows.Forms.MessageBox.Show("Class Setting : Помилка відкриття даних про ЖД!");
                    }

                    //устанавливаем серийній номер программы 
                    
                    this.Registr.AssemblityN = System.Reflection.AssemblyName.GetAssemblyName("Test_M.exe");

                    this.Registr.SN = this.Registr.NameOfProcessor.GetHashCode().ToString() + "|"
                         + this.Registr.NameOfHardDisk.GetHashCode().ToString() + "|"
                         + this.Registr.NameOfWindows.GetHashCode().ToString() + "|"
                         + this.Registr.ProductIDOfWindows.GetHashCode().ToString() + "|"
                         + this.Registr.DateOfCreate.GetHashCode();

                    //проверка наличия старых записей в реестре от прошлой программы

                    RegistryKey r = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Mazur Y.V.\\Test_M");
                    RegistryKey r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Mazur Y.V.\\Test_M");
                    RegistryKey r2 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Cryptography\\Protect\\Providers\\md1504-84903-fdes845");
                    if (!(r == null && r1 == null && r2 == null))
                    {//установка поверх старой версии
                        DateTime DTNow = DateTime.Now;
                        try
                        {
                            DateTime CreatS = Convert.ToDateTime(r2.GetValue("t1"));
                            DateTime EndS = Convert.ToDateTime(r2.GetValue("t2"));
                            if (!Convert.ToBoolean(r.GetValue("IfRegistration"))) //если не біло зарегистрировано
                            {
                                this.Registr.DateOfCreate = CreatS;
                                this.Registr.DateOfStop = EndS;
                            }
                            else
                            {
                                RegistryKey rk = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Mazur Y.V.\\Test_M");
                                RegistryKey rk1 = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Mazur Y.V.\\Test_M");
                                rk.DeleteValue("zarSN");
                                rk.DeleteValue("RegisteredOrganization");
                                rk.DeleteValue("RegisteredOwner");
                                rk1.DeleteValue("zarSN");
                                rk1.DeleteValue("RegisteredOrganization");
                                rk1.DeleteValue("RegisteredOwner");

                            }
                            if (Convert.ToBoolean(r2.GetValue("B"))) this.BlockProgramm();
                        }
                        catch {

                            System.Windows.Forms.MessageBox.Show("Class Setting : Помилка звернення до реєстру при встановленні нової версії на стару!");
                            try
                            {
                                if (r != null) r.DeleteSubKeyTree("Mazur Y.V.");

                            }
                            catch { }
                            try
                            {
                                if (r1 != null) r1.DeleteSubKeyTree("Mazur Y.V.");
                            }
                            catch { }
                            try
                            {
                                if (r2 != null) r2.DeleteSubKeyTree("md1504-84903-fdes845");
                            }
                            catch { }
                        }
                    }
                    
                    //вводим значения, в том числе и скрытые, в реестр Windows
                    try
                    {
                        
                        RegistryKey rk = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Mazur Y.V.\\Test_M");
                        rk.SetValue("path", Path.GetDirectoryName(Path.GetFullPath("Test_M.exe")));
                        rk.SetValue("time", this.Registr.DateOfCreate.ToString());
                        rk.SetValue("timeStop", this.Registr.DateOfStop.ToString());
                        rk.SetValue("SN", this.Registr.SN);
                        rk.SetValue("IfRegistration", false);
                        RegistryKey rk1 = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Mazur Y.V.\\Test_M");
                        rk1.SetValue("path", Path.GetDirectoryName(Path.GetFullPath("Test_M.exe")));
                        rk1.SetValue("time", this.Registr.DateOfCreate.ToString());
                        rk1.SetValue("timeStop", this.Registr.DateOfStop.ToString());
                        rk1.SetValue("SN", this.Registr.SN);
                        rk1.SetValue("IfRegistration", false);
                        RegistryKey rk2 = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Cryptography\\Protect\\Providers\\md1504-84903-fdes845");
                        rk2.SetValue("t1", this.Registr.DateOfCreate.ToString());
                        rk2.SetValue("t2", this.Registr.DateOfStop.ToString());
                        rk2.SetValue("S", this.Registr.SN);


                    }
                    catch
                    {
                        System.Windows.Forms.MessageBox.Show("Class Setting : Відмова вводу значень реєстру при 1-му запуску\n Запустіть програму в режимі адміністратора!");
                       

                    }


    
                

                    
                           
            

        }
        public bool IfRegistrated()
        { 
            
            if (!this.Registr.IfRegisted)
            {
                DateTime DTNow = DateTime.Now;
                DateTime CreatSetting = this.Registr.DateOfCreate;
                string DC = CreatSetting.ToString();
                CreatSetting = Convert.ToDateTime(DC);
                DateTime EndSetting = this.Registr.DateOfStop;
                string DE = EndSetting.ToString();
                EndSetting = Convert.ToDateTime(DE);
                try
                {
                    RegistryKey rk = Registry.LocalMachine.OpenSubKey ("SOFTWARE\\Mazur Y.V.\\Test_M");
                    DateTime CreatR1 = Convert.ToDateTime(rk.GetValue("time"));
                    DateTime EndR1 = Convert.ToDateTime(rk.GetValue("timeStop"));
                    String SNR1 = rk.GetValue("SN").ToString();
                    rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Mazur Y.V.\\Test_M");
                    DateTime CreatR2 = Convert.ToDateTime(rk.GetValue("time"));
                    DateTime EndR2 = Convert.ToDateTime(rk.GetValue("timeStop"));
                    String SNR2 = rk.GetValue("SN").ToString();
                    rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Cryptography\\Protect\\Providers\\md1504-84903-fdes845");
                    DateTime CreatS = Convert.ToDateTime(rk.GetValue("t1"));
                    DateTime EndS = Convert.ToDateTime(rk.GetValue("t2"));
                    String SNS = rk.GetValue("S").ToString();
                
                //проверка соответсвия дат (антихакинг1)
                bool HackDateOfCreat = true;
                bool HackDateOfEnd = true;
                bool HackSN = true;
                bool CurrentDateLessDateOfCreat = true;

                if (CreatSetting.Equals(CreatR1) && CreatR2.Equals(CreatS) && CreatR1.Equals(CreatS)) HackDateOfCreat = false;
                if (EndSetting.Equals(EndR1) && EndR2.Equals(EndS) && EndR1.Equals(EndS)) HackDateOfEnd = false;
                if (this.Registr.SN.Equals(SNR1) && SNR2.Equals(SNS) && SNS.Equals(this.Registr.SN)) HackSN = false;
                double razn = this.Registr.DateOfCreate.CompareTo(DTNow);
                if (this.Registr.DateOfCreate.CompareTo(DTNow) < 0) CurrentDateLessDateOfCreat = false;

//установка приложения в стоп
                if (HackDateOfCreat || HackDateOfEnd) { 
                    System.Windows.Forms.MessageBox.Show("Дата створення настройок та закінчення роботи програми у обмеженому режимі змінено,\nщо вказує на спробу взломати програму. \n\nПрограмму буде заблоковано до моменту проведення реєстрації");
                    this.BlockProgramm();
                }
                if (CurrentDateLessDateOfCreat)
                {
                    System.Windows.Forms.MessageBox.Show("Дата створення настройок більша за сьогодняшню,\nщо може вказувати на спробу взломати програму. \n\nЗмініть системну дату");
                }
                if (HackSN)
                {
                    System.Windows.Forms.MessageBox.Show("Серійний номер програми змінено,\nщо вказує на спробу взломати програму. \n\nПрограмму буде заблоковано до моменту проведення реєстрації");
                    this.BlockProgramm();
                }
                if (DTNow.CompareTo(EndSetting) >0)
                {
                    System.Windows.Forms.MessageBox.Show("Роботу програми у обмеженому режимі закінчено. \n\nПрограмму буде заблоковано до моменту проведення реєстрації");
                    this.BlockProgramm();
                    this.Registr.IfOgranicheno = false;
                }
//возвращаем отсутствие регистрации
                this.Registr.IfRegisted = false;
                    return false;

            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("При проведенні перевірки до активації, доступ до записів реєстру відхилено\n Запустіть програму в режимі Адміністратора");
               
                return false;

            }
            }
            else
            {//проверка соответствий после регистрации

                //проверка наличия  записей в реестре 
                    RegistryKey r = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Mazur Y.V.\\Test_M");
                    RegistryKey r1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Mazur Y.V.\\Test_M");
                    RegistryKey r2 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Cryptography\\Protect\\Providers\\md1504-84903-fdes845");
                    if (r == null || r1 == null || r2 == null)//если удалена хоть одна ветка
                    {
                        System.Windows.Forms.MessageBox.Show("Дані про програму видалені з реєстру. Реєстрація скасована, необхідна повторна реєстрація.");
                        this.SkasuvatiReesraciyu();
                        return false;
                    }
                    else //если все реестры в наличие
                    {
                        string NewNameOfProcessor = "";
                        string NewProductIDOfWindows = "";
                        string NewNameOfWindows = "";
                        string NewNameOfHardDisk = "";
                        try
                        {
                            RegistryKey rk = Registry.LocalMachine.OpenSubKey("HARDWARE\\DESCRIPTION\\SYSTEM\\CentralProcessor\\0");
                            if (rk != null)
                            {
                                NewNameOfProcessor = rk.GetValue("ProcessorNameString").ToString();
                                if (NewNameOfProcessor.Equals("")) this.Registr.NameOfProcessor = "unknown";
                            }
                            else this.Registr.NameOfProcessor = "unknown";
                        }
                        catch
                        {
                            System.Windows.Forms.MessageBox.Show("Class Setting : Помилка відкриття даних про процесор!");
                        }
                        try
                        {
                            RegistryKey rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\\MICROSOFT\\WINDOWS NT\\CurrentVersion");
                            if (rk != null)
                            {
                                NewProductIDOfWindows = rk.GetValue("ProductID").ToString();
                                NewNameOfWindows = rk.GetValue("ProductName").ToString();
                                if (NewProductIDOfWindows.Equals("")) NewProductIDOfWindows = "unknown";
                                if (NewNameOfWindows.Equals("")) NewNameOfWindows = "unknown";
                            }
                            else //ищем 98
                            {
                                rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\\MICROSOFT\\WINDOWS\\CurrentVersion");
                                if (rk != null)
                                {
                                    NewProductIDOfWindows = rk.GetValue("ProductID").ToString();
                                    NewNameOfWindows = rk.GetValue("ProductName").ToString();
                                    if (NewProductIDOfWindows.Equals("")) NewProductIDOfWindows = "unknown";
                                    if (NewNameOfWindows.Equals("")) NewNameOfWindows = "unknown";
                                }
                            }
                        }
                        catch
                        {
                            System.Windows.Forms.MessageBox.Show("Class Setting : Помилка відкриття даних про операційну систему!");
                        }
                        try
                        {
                            RegistryKey rk = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum\\IDE");
                            if (rk != null)
                            {
                                string[] NamesOfHardDisk = rk.GetSubKeyNames();

                                RegistryKey rtemp, rtemp2;
                                for (int i = 0; i < NamesOfHardDisk.GetLength(0); i++)
                                {
                                    rtemp = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum\\IDE\\" + NamesOfHardDisk[i].ToString());
                                    string[] N = rtemp.GetSubKeyNames();
                                    if (N.Length > 0)
                                    {
                                        rtemp2 = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum\\IDE\\" + NamesOfHardDisk[i].ToString() + "\\" + N[0]);
                                        string[] ifDisk = (string[])rtemp2.GetValue("CompatibleIDs");
                                        if (ifDisk[0].Equals("GenDisk")) NewNameOfHardDisk = ((string[])rtemp2.GetValue("HardwareID"))[0];
                                    }
                                }

                            }
                            else NewNameOfHardDisk = "unknown";
                        }
                        catch
                        {
                            System.Windows.Forms.MessageBox.Show("Class Setting : Помилка відкриття даних про жорсткий диск!");
                        }




                        //проверка соответствий со старіми данніми
                        if (!NewNameOfHardDisk.Equals(this.Registr.NameOfHardDisk))
                        {
                            System.Windows.Forms.MessageBox.Show("Вами змінено конфігурацію комп`ютера, а саме жорсткого диску.\nРеєстрація скасована, необхідна повторна реєстрація.");
                            this.SkasuvatiReesraciyu();
                            return false;
                        } 
                        if (!NewNameOfProcessor.Equals(this.Registr.NameOfProcessor))
                        {
                            System.Windows.Forms.MessageBox.Show("Вами змінено конфігурацію комп`ютера, а саме процесора.\nРеєстрація скасована, необхідна повторна реєстрація.");
                            this.SkasuvatiReesraciyu();
                            return false;
                        } 
                            if (!NewNameOfWindows.Equals(this.Registr.NameOfWindows))
                        {
                            System.Windows.Forms.MessageBox.Show("Вами змінено конфігурацію комп`ютера, а саме операційної системи.\nРеєстрація скасована, необхідна повторна реєстрація.");
                            this.SkasuvatiReesraciyu();
                            return false;
                        } 
                        if (!NewProductIDOfWindows.Equals(this.Registr.ProductIDOfWindows))
                        {
                            System.Windows.Forms.MessageBox.Show("Вами змінено конфігурацію комп`ютера, а саме номеру операційної системи.\nРеєстрація скасована, необхідна повторна реєстрація.");
                            this.SkasuvatiReesraciyu();
                            return false;
                        }
                        //перевірка співпадіння версій
                  

                        RegistryKey reestr = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Mazur Y.V.\\Test_M");
                        
                        try
                        {
                            System.Reflection.AssemblyName myAssemblyName = System.Reflection.AssemblyName.GetAssemblyName("Test_M.exe");
                            
                            if (!myAssemblyName.Equals(this.Registr.AssemblityN))
                            {
                                if ((myAssemblyName.Version.Major > this.Registr.AssemblityN.Version.Major) ||
                                    (myAssemblyName.Version.Minor > this.Registr.AssemblityN.Version.Minor) ||
                                    (myAssemblyName.Version.Build > this.Registr.AssemblityN.Version.Build))
                                {
                                    System.Windows.Forms.MessageBox.Show("Ви використовуєте більш нову програму\nРеєстрація скасована, необхідна повторна реєстрація.");
                                    this.SkasuvatiReesraciyu();
                                    return false;
                                }
                            }

                        }
                        catch
                        {
                            System.Windows.Forms.MessageBox.Show("Программу попередньо було встановлено у каталог:\n" + reestr.GetValue("path") + "\nЗапуск програми можливий лише з цього каталога!");
                            reestr.Close();
                        }



                        if (Convert.ToBoolean(r.GetValue("IfRegistration"))&&Convert.ToBoolean(r1.GetValue("IfRegistration"))&&Convert.ToBoolean(this.IfFlagRegistrated()))
                            return true;



                    }
                    this.Registr.IfRegisted = false;
                    return false;
                
            }

            
        }
        private void SkasuvatiReesraciyu()
        {
            RegistryKey r = Registry.LocalMachine.CreateSubKey("SOFTWARE");
            RegistryKey r1 = Registry.CurrentUser.CreateSubKey("SOFTWARE");
            RegistryKey r2 = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Cryptography\\Protect\\Providers");

            this.Registr.DateOfCreate = DateTime.Now;
            this.Registr.DateOfStop = DateTime.Now.AddDays(30);
            this.Registr.IfOgranicheno = true;
            this.Registr.IfRegisted = false;
            this.Registr.IfStop = false;
            this.Registr.zarSN = "";
            //удаляем все старіе данніе реестра
            try
            {
                if (r != null) r.DeleteSubKeyTree("Mazur Y.V.");

            }
            catch { }
             try
            {
                if (r1 != null) r1.DeleteSubKeyTree("Mazur Y.V.");
            }
            catch { }
            try
            {
                if (r2 != null) r2.DeleteSubKeyTree("md1504-84903-fdes845");
            }
            catch { }
            //а теперь новіе значения от начала и до конца
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey("HARDWARE\\DESCRIPTION\\SYSTEM\\CentralProcessor\\0");
                if (rk != null)
                {
                    this.Registr.NameOfProcessor = rk.GetValue("ProcessorNameString").ToString();
                    if (this.Registr.NameOfProcessor.Equals("")) this.Registr.NameOfProcessor = "unknown";
                }
                else this.Registr.NameOfProcessor = "unknown";
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Class Setting : Помилка у встановлені даних про процесор!");
            }
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\\MICROSOFT\\WINDOWS NT\\CurrentVersion");
                if (rk != null)
                {
                    this.Registr.ProductIDOfWindows = rk.GetValue("ProductID").ToString();
                    this.Registr.NameOfWindows = rk.GetValue("ProductName").ToString();
                    if (this.Registr.ProductIDOfWindows.Equals("")) this.Registr.ProductIDOfWindows = "unknown";
                    if (this.Registr.NameOfWindows.Equals("")) this.Registr.NameOfWindows = "unknown";
                }
                else //ищем 98
                {
                    rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\\MICROSOFT\\WINDOWS\\CurrentVersion");
                    if (rk != null)
                    {
                        this.Registr.ProductIDOfWindows = rk.GetValue("ProductID").ToString();
                        this.Registr.NameOfWindows = rk.GetValue("ProductName").ToString();
                        if (this.Registr.ProductIDOfWindows.Equals("")) this.Registr.ProductIDOfWindows = "unknown";
                        if (this.Registr.NameOfWindows.Equals("")) this.Registr.NameOfWindows = "unknown";
                    }
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Class Setting : Помилка у встановлені даних про ОС!");
            }
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum\\IDE");
                if (rk != null)
                {
                    string[] NamesOfHardDisk = rk.GetSubKeyNames();

                    RegistryKey rtemp, rtemp2;
                    for (int i = 0; i < NamesOfHardDisk.GetLength(0); i++)
                    {
                        rtemp = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum\\IDE\\" + NamesOfHardDisk[i].ToString());
                        string[] N = rtemp.GetSubKeyNames();
                        if (N.Length > 0)
                        {
                            rtemp2 = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum\\IDE\\" + NamesOfHardDisk[i].ToString() + "\\" + N[0]);
                            string[] ifDisk = (string[])rtemp2.GetValue("CompatibleIDs");
                            if (ifDisk[0].Equals("GenDisk")) this.Registr.NameOfHardDisk = ((string[])rtemp2.GetValue("HardwareID"))[0];
                        }
                    }

                }
                else this.Registr.NameOfHardDisk = "unknown";
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Class Setting : Помилка у встановленні даних про ЖД!");
            }

            //устанавливаем серийній номер программы 
            this.Registr.AssemblityN = System.Reflection.AssemblyName.GetAssemblyName("Test_M.exe");



            this.Registr.SN = this.Registr.NameOfProcessor.GetHashCode().ToString() + "|"
                 + this.Registr.NameOfHardDisk.GetHashCode().ToString() + "|"
                 + this.Registr.NameOfWindows.GetHashCode().ToString() + "|"
                 + this.Registr.ProductIDOfWindows.GetHashCode().ToString() + "|"
                 + this.Registr.DateOfCreate.GetHashCode();

            //вводим значения, в том числе и скрытые, в реестр Windows
            try
            {

                RegistryKey rk = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Mazur Y.V.\\Test_M");
                rk.SetValue("path", Path.GetDirectoryName(Path.GetFullPath("Test_M.exe")));
                rk.SetValue("time", this.Registr.DateOfCreate.ToString());
                rk.SetValue("timeStop", this.Registr.DateOfStop.ToString());
                rk.SetValue("SN", this.Registr.SN);
                rk.SetValue("IfRegistration", false);
                RegistryKey rk1 = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Mazur Y.V.\\Test_M");
                rk1.SetValue("path", Path.GetDirectoryName(Path.GetFullPath("Test_M.exe")));
                rk1.SetValue("time", this.Registr.DateOfCreate.ToString());
                rk1.SetValue("timeStop", this.Registr.DateOfStop.ToString());
                rk1.SetValue("SN", this.Registr.SN);
                rk1.SetValue("IfRegistration", false);
                RegistryKey rk2 = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Cryptography\\Protect\\Providers\\md1504-84903-fdes845");
                rk2.SetValue("t1", this.Registr.DateOfCreate.ToString());
                rk2.SetValue("t2", this.Registr.DateOfStop.ToString());
                rk2.SetValue("S", this.Registr.SN);


            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Class Setting : Помилка у введенні нових значень у реєстр при скасуванні реєстрації!");
            }
            
        }
        public void Activisation(string EncrSN, string RegisteredOwner, string RegisteredOrganization)
        {
            if (EncrSN.Equals(this.Registr.SN))
            {
                this.Registr.zarSN = EncrSN;
                this.Registr.IfOgranicheno = false;
                this.Registr.IfStop = false;
                this.Registr.IfRegisted = true;
                RegistryKey rk = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Mazur Y.V.\\Test_M");
                rk.SetValue("path", Path.GetDirectoryName(Path.GetFullPath("Test_M.exe")));
                rk.SetValue("timeStop", DateTime.Now.AddYears(3)); 
                rk.SetValue("zarSN", this.Registr.SN);
                rk.SetValue("IfRegistration", true);
                rk.SetValue("RegisteredOwner", RegisteredOwner);
                rk.SetValue("RegisteredOrganization", RegisteredOrganization);
                RegistryKey rk1 = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Mazur Y.V.\\Test_M");
                rk1.SetValue("path", Path.GetDirectoryName(Path.GetFullPath("Test_M.exe")));
                rk1.SetValue("timeStop", DateTime.Now.AddYears(3));
                rk1.SetValue("zarSN", this.Registr.SN);
                rk1.SetValue("IfRegistration", true);
                rk1.SetValue("RegisteredOwner", RegisteredOwner);
                rk1.SetValue("RegisteredOrganization", RegisteredOrganization);
                this.Registr.RegisteredOrganization = RegisteredOrganization;
                this.Registr.RegisteredOwner =RegisteredOwner;
                
            }

        }
        public bool IfFlagRegistrated()
        {
             return this.Registr.IfRegisted;
        }
        public bool IfStop()
        {return this.Registr.IfStop;}
        public string GetTimeOfEnd()
        { return this.Registr.DateOfStop.ToString(); }
        public void BlockProgramm()
        {
            this.Registr.IfStop = true;
            this.Registr.DateOfStop = DateTime.Now;
            RegistryKey rk = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Mazur Y.V.\\Test_M");
            rk.SetValue("timeStop", this.Registr.DateOfStop.ToString());
            rk.SetValue("IfRegistration", false);
            RegistryKey rk1 = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Mazur Y.V.\\Test_M");
            rk1.SetValue("timeStop", this.Registr.DateOfStop.ToString());
            rk1.SetValue("IfRegistration", false);
            RegistryKey rk2 = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Cryptography\\Protect\\Providers\\md1504-84903-fdes845");
            rk2.SetValue("t2", this.Registr.DateOfStop.ToString());
            rk2.SetValue("B", true);
        }
        public string GetSN() { return this.Registr.SN; }
        public string GetZarSn() {

            if (this.Registr.zarSN != null) return this.Registr.zarSN;
            else return "";
        }
        public string GetRegisteredOwner() { return this.Registr.RegisteredOwner; }
        public string GetRegisteredOrganization() { return this.Registr.RegisteredOrganization; }


    }














    [Serializable]
    public class IESetting : BaseSetting
    {
        public IESetting()
        {
            Admins = new System.Collections.ArrayList();
            Teachers = new System.Collections.ArrayList();
            Groups = new System.Collections.ArrayList();
            NewIDOfUsers = 1;
            Options = new bool[3];
            Options[0] = Options[1] = Options[2] = false;
            TimeForNewTest = 60;
        }

        


    }
}
