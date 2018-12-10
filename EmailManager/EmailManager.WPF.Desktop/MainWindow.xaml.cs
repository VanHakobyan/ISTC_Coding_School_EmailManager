using System;
using System.Collections.Generic;
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
using EmailManager.Bll;
using EmailManager.DB;

namespace EmailManager.WPF.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static EmailSender _sendEmail;
        public MainWindow()
        {
            InitializeComponent();
            _sendEmail=new EmailSender();
            DataBase.Init();
            Emails.ItemsSource = DataBase.IstcContacts.Select(x=>x.Email);
            Companies.ItemsSource = DataBase.Companies;
        }

        private void CompanySend_Click(object sender, RoutedEventArgs e)
        {
            var emailsSelectedValue = Emails.SelectedValue;
            var contact = DataBase.AllContacts.FirstOrDefault(x => x.CompanyName != null && x.CompanyName == (string) emailsSelectedValue);
        }

        private void IndividualSend_Click(object sender, RoutedEventArgs e)
        {
            var emailsSelectedValue = Emails.SelectedValue;
            var contact = DataBase.AllContacts.FirstOrDefault(x => x.Email != null && x.Email == (string)emailsSelectedValue);
            _sendEmail.SendEmail(contact);
        }
    }
}
