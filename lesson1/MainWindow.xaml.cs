using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace lesson1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public class Attributs
    {
        public string Addr;
        public string Name;
        //public string To;
        public string SMTP;
        public string Port;
        public string Password;
        public string Sign;
        //public string Body;
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            wndAbout about = new wndAbout();
            about.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new MailEngine(tbAddress.Text, tbYour_name.Text,
                tbTo.Text, tbSMTP.Text, tbPort.Text, tbPassword.Text, tbBody.Text, tbFullSign.Text);
            MessageBox.Show("Сообщение должно быть отправлено");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnSend.Content = TextBox.TextProperty;
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            Attributs attr = new Attributs();
            attr.Addr = tbAddress.Text;
            attr.Name = tbYour_name.Text;
            attr.SMTP = tbSMTP.Text;
            attr.Port = tbPort.Text;
            attr.Password = tbPassword.Text;
            attr.Sign = tbSign.Text;

            string filename = "options.xml";
            XmlSerializer ser = new XmlSerializer(typeof(Attributs), filename);
            Stream f = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
            ser.Serialize(f, attr);
            f.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Attributs attr = new Attributs();
            string filename = "options.xml";
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Attributs), filename);
                Stream f = new FileStream(filename, FileMode.Open, FileAccess.Read);
                attr = (Attributs)ser.Deserialize(f);
                tbAddress.Text = attr.Addr;
                tbYour_name.Text = attr.Name;
                tbSMTP.Text=attr.SMTP;
                tbPort.Text = attr.Port;
                tbPassword.Text = attr.Password;
                tbFullSign.Text=attr.Sign+' '+attr.Name;
                tbSign.Text = attr.Sign;
                f.Close();
            }
            finally { };

        }
    }
}
