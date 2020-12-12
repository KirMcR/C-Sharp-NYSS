using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace courceWork
{
    /// <summary>
    /// Логика взаимодействия для GetFile.xaml
    /// </summary>
    public partial class GetFile : Window
    {
     
        static string Path { get; set; } = "";
      
        public GetFile()
        {
            InitializeComponent();
        }
        public string GetPath()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "Text documents (*.txt)|*.txt";
            if (dialog.ShowDialog() == true)
            {
                return dialog.FileName;
            }
            return null;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int a;
            if ((int.TryParse(text.Text, out a))|| !(Regex.IsMatch(text.Text, "^[А-Яа-я]+$")))
            {
                MessageBox.Show("Ключ должен содержать только буквы русского алфавита!", "Некорректный ключ",
                     MessageBoxButton.OK, MessageBoxImage.Error);
           }
            else
            {
                List<char> key = new List<char>();
               
                 foreach(char q in text.Text)
                {
                    key.Add(q);
                }
                 
                string s="";
                foreach (char vv in GetFile.Dishifr(Path, key))
                {
                    s += vv;
                }
                result1.Text = s;
                Wher.Visibility = Visibility.Visible;
                



            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Path=this.GetPath();
        }
        public static List<char> Dishifr(string path, List<char> key)
        {
            List<char> alph = new List<char> { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
            int Alf = alph.Count;
            List<char> message = new List<char>();
            message = GetT.GetText(path);
            List<char> keq = new List<char> { };
            int j = 0;
            for (int i = 0; i < message.Count; i++)
            {

                if (GetFile.IsRus(message[i], alph))
                {
                    keq.Add(key[j]);
                    if ((j < key.Count - 1))
                    {
                        j++;
                    }
                    else { j = 0; }
                }
                else
                {
                    keq.Add(message[i]);
                }

            }
            List<char> result = new List<char>();
            for (int i = 0; i < message.Count; i++)
            {
                if (GetFile.IsRus(message[i], alph))
                {
                    result.Add(alph[((GetFile.WhatIn(message[i], alph) - GetFile.WhatIn(keq[i], alph) + alph.Count) % alph.Count)]);
                }
                else
                {
                    result.Add(message[i]);
                }
            }
            
            return result;
        }
        public static int WhatIn(char beg, List<char> alf)
        {
            int b = -1;
            int i = 0;
            while (b == -1)
            {
                if (beg == alf[i])
                {
                    b = i;
                    break;
                }
                i++;
            }

            return b;
        }
        public static bool IsRus(char beg, List<char> alf)
        {
            for (int i = 0; i < alf.Count; i++)
            {
                if (beg == alf[i])
                {
                    return true;
                }

            }

            return false;
        }

        private void WherSv(object sender, RoutedEventArgs e)
        {
            Create();
        }
        private void Create()
        {
          
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "Text documents(*.txt) | *.txt";
                if (saveFile.ShowDialog() == true)
                {
                    using (StreamWriter sw = new StreamWriter(saveFile.OpenFile(), Encoding.Default))
                    {
                        sw.Write(result1.Text);
                        sw.Close();
                    }
                    MessageBox.Show("Файл сохранен");
                }
           

        }

        private void Button_main(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }
    }
}
