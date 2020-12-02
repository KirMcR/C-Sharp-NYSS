using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace lab02_0
{
    /// <summary>
    /// Логика взаимодействия для Load_Poup.xaml
    /// </summary>
     public partial class Load_Popup : Window
    {
        public static string Dir { get; set; }
        public static bool checker = false;
        public Load_Popup()
        {
            InitializeComponent();
            
            string url = "https://bdu.fstec.ru/files/documents/thrlist.xlsx";
            if (findFile("thrlist.xlsx"))
            {
                var result = MessageBox.Show("Файл найден на диске, оставить его его?  \"Нет\" - Файл скачается с интернета.", "Файл найден на ПК", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    checker = true;
                }
            }
            if (!checker) //Файла нет
            {
                try
                {
                    if (!Directory.Exists(Environment.CurrentDirectory + @"\ThreatTable\"))
                    {
                        Directory.CreateDirectory(Environment.CurrentDirectory + @"\ThreatTable\");
                    }
                    WebClient client = new WebClient();
                   
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                    client.DownloadFileAsync(new Uri(url), Environment.CurrentDirectory + @"\ThreatTable\thrlist.xlsx");
                    Dir = Environment.CurrentDirectory + @"\ThreatTable\thrlist.xlsx";
                }
                catch { MessageBox.Show("При загрузке произошла ошибка.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
            else //Файл есть
            {
                Dir = Environment.CurrentDirectory + @"\ThreatTable\thrlist.xlsx";
                MessageBox.Show("Файл загружен с ПК", "Успех");
                this.Close();
            }
        }

        bool findFile(string fileName)
        {
            string catalog = Environment.CurrentDirectory + @"\ThreatTable\";
            try
            {
                foreach (string findedFile in Directory.EnumerateFiles(catalog, fileName,
                    SearchOption.TopDirectoryOnly))
                {
                    try
                    {
                        return true;
                    }
                    catch
                    {
                        continue;
                    }

                }
            }
            catch { return false; }
            return false;
        }

        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Ok_Button.IsEnabled = true;
            PageInfo.Content = @"Файл сохранен в папку \ThreatTable";
            this.Title = "Загрузка завершена!";
        }

        private void Ok_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

