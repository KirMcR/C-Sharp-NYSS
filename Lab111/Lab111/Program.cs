using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Zapis> spis = new List<Zapis> { };
            int i = 999;
            DateTime d = new DateTime(2001, 01, 01);
            Zapis default1 = new Zapis("Pavelo", "Pavel", "Pavlov", 898232901, "Russia", "01.01.2000", "WMW", "Boss1", "...");
            Zapis default2 = new Zapis("Pavelo", "Ivan", "Pavlov", 898232901, "Russia", "01.01.2001", "WMW", "Boss2", "...");
            Zapis default3 = new Zapis("Pavelo", "Anton", "Pavlov", 898232901, "Russia", "01.01.2003", "WMW", "Boss3", "...");

            spis.Add(default1);
            spis.Add(default2);
            spis.Add(default3);
            Console.WriteLine("Добро пожаловать в записную телефонную книжку!");
            while (i != -1)
            {

                Console.WriteLine("\n1 - Создать запись \n2 - Редактировать запись \n3 - Удалить запись \n4 - Просмотр учетных записей \n5 - Показать все созданные записи, с краткой информацией \n-1 - Выход\n");
                if (Int32.TryParse(Console.ReadLine(), out i))
                {
                    int j = 0;
                    int ti = 0;
                    switch (i)
                    {
                        case 1:

                            spis.Add(Zapis.AddZapis());
                            break;
                        case 2:
                            j = 0;
                            Zapis.ShowAll(spis);
                            while (j == 0)
                            {
                                ti = Zapis.GetInt("Введите номер учетной записи, которую необходимо отредактировать(вернуться назад:99):");
                                if (ti > 0 & ti <= spis.Count)
                                {
                                    j = 1;
                                    Console.WriteLine(spis[ti - 1].ToString());
                                    int doing = -1;
                                    while (doing == -1)
                                    {

                                        int vi = Zapis.GetInt("Введите номер поля, которое необходимо изменить(вернуться назад:99):");
                                        if (vi == 1 | vi == 2 | vi == 3 | vi == 4 | vi == 5 | vi == 6 | vi == 7 | vi == 8 | vi == 9)
                                        {
                                            spis[ti - 1].Change(vi);
                                        }
                                        else if (vi == 99) { break; }
                                        else { continue; }
                                        doing = Zapis.GetInt("Для выхода из режима редактирования введите любое число, кроме -1:");
                                    }
                                }
                                else if (ti == 99) { break; }
                            }
                            break;
                        case 3:
                            j = 0;
                            Zapis.ShowAll(spis);
                            while (j == 0)
                            {
                                ti = Zapis.GetInt("Введите номер учетной записи, котору необхожимо удалить(вернуться назад:99):");
                                if (ti > 0 & ti <= spis.Count)
                                {
                                    spis.Remove(spis[ti - 1]);
                                    Console.WriteLine("Запись была удалена");
                                }
                                else if (ti == 99) { break; }
                            }
                            break;
                        case 4:
                            j = 0;
                            Zapis.ShowAll(spis);
                            while (j == 0)
                            {

                                ti = Zapis.GetInt("Введите номер учетной записи, котору вы хотите увидеть полностью(вернуться назад:99):");
                                if (ti > 0 & ti <= spis.Count)
                                {

                                    Console.WriteLine(spis[ti - 1].ToString());
                                }
                                else if (ti == 99) { break; }
                            }
                            break;
                        case 5:
                            Zapis.ShowAll(spis);
                            break;
                        case -1:
                            break;
                        default:
                            Console.WriteLine("Ошибка ввода: неверная команда, повторите еще раз");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка ввода: неверный формат, повторите еще раз");
                }
            }
            Console.WriteLine(i);
            Console.Read();
        }
    }
    class Zapis
    {
        public string name, sname, fname, birth, country, org, dolg, etc;
        public int number;

        public Zapis(string sname, string name, string fname, int number, string country, string birth, string org, string dolg, string etc)
        {
            this.name = name;
            this.sname = sname;
            this.number = number;
            this.country = country;
            this.birth = birth;
            this.fname = fname;
            this.org = org;
            this.dolg = dolg;
            this.etc = etc;
        }
        public static Zapis AddZapis()
        {

            string sname, name, fname, country, org, dolg, etc, birth;
            int number = 0;


            sname = Zapis.What("Введите фамилию(обязательно) - только буквы:");
            name = Zapis.What("Введите имя(обязательно) - только буквы:");
            fname = Zapis.AddWord("Введите отчество(необязательно) - только буквы:");

            number = Zapis.GetInt("Введите номер телефона(обязательно) - только цифры:");
            country = Zapis.What("Введите название страны(обязательно) - только буквы:");

            birth = Zapis.CheckDate("Введите дату рождения в формате dd.mm.yyyy черз точку:");
            Console.WriteLine("Введите название организации(необязательно):");
            org = Console.ReadLine();
            Console.WriteLine("Введите название должности(необязательно):");
            dolg = Console.ReadLine();
            Console.WriteLine("Введите прочие заметки(необязательно):");
            etc = Console.ReadLine();
            Zapis NewIt = new Zapis(sname, name, fname, number, country, birth, org, dolg, etc);
            return NewIt;
        }
        public static bool IsItOk(string s)
        {
            if (s == "" | s == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static string What(string s)
        {
            int z = 0;
            string something = "Chto-to";
            while (z == 0)
            {

                Console.WriteLine(s);
                something = Console.ReadLine();
                if (Zapis.IsItOk(something)) { if (Zapis.IsItLetter(something)) { z = 1; } }

            }
            return something;
        }
        public static string AddWord(string s)
        {
            int i = 0;
            string something = "";
            while (i == 0)
            {
                Console.WriteLine(s);
                something = Console.ReadLine();
                if (s == "" | s == null) { i = 1; }
                else if (Zapis.IsItLetter(something)) { i = 1; }


            }
            return something;
        }
        public static bool IsItLetter(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }

        public static int GetInt(string s)
        {
            int integ = 0;
            int i = 0;
            while (i == 0)
            {
                Console.WriteLine(s);
                if (int.TryParse(Console.ReadLine(), out integ)) { i = 1; }

            }
            return integ;
        }
        public static string CheckDate(string s)
        {
            int i = 0;
            string ans = "";
            DateTime value = new DateTime();
            while (i == 0)
            {
                Console.WriteLine(s);
                ans = Console.ReadLine();
                if (ans == "" | ans == null) { i = 1; break; }
                else if (DateTime.TryParse(ans, out value))
                {
                    i = 1;
                    ans = value.ToShortDateString();
                }

            }
            return ans;

        }
        public void Change(int nuum)
        {
            switch (nuum)
            {
                case 1:
                    this.sname = Zapis.What("Введите фамилию(обязательно):");
                    break;
                case 2:
                    Console.WriteLine("Введите имя(обязательно):");
                    this.name = Zapis.What("Введите имя(обязательно):");
                    break;
                case 3:
                    Console.WriteLine("Введите отчество:");
                    this.fname = Console.ReadLine();
                    break;
                case 4:
                    this.number = Zapis.GetInt("Введите номер телефона(обязательно):");
                    break;
                case 5:
                    this.country = Zapis.What("Введите название страны(обязательно):");

                    break;
                case 6:
                    this.birth = Zapis.CheckDate("Введите дату рождения в формате dd.mm.yyyy черз точку:");

                    break;
                case 7:
                    Console.WriteLine("Введите название организации:");
                    this.org = Console.ReadLine();
                    break;
                case 8:
                    Console.WriteLine("Введите название должности:");
                    this.dolg = Console.ReadLine();
                    break;
                case 9:
                    Console.WriteLine("Введите прочие заметки:");
                    this.etc = Console.ReadLine();
                    break;
            }
        }
        public override string ToString()
        {
            return $"1.Фамилия: {this.sname}\n2.Имя: {this.name}\n3.Отчество: {this.fname}\n4.Номер телефона: {this.number}\n5.Страна: {this.country}\n6.Дата рождения: {this.birth}\n7.Организация: {this.org}\n8.Должность {this.dolg}\n9.Прочие заметки: {this.etc}";
        }
        public static void ShowAll(List<Zapis> spis)
        {
            for (int i = 0; i < spis.Count; i++)
            {
                Console.WriteLine($"Запись номер: {i + 1}\nФмилия: {spis[i].sname}\nИмя: {spis[i].name}\nНомер телефона: {spis[i].number}\n");
            }
        }

    }
}
