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

namespace ЭлЖурнал.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        ElectronicMagazineEntities context;
        Window window;
        public Authorization(ElectronicMagazineEntities context, Window window)
        {
            InitializeComponent();
            this.context = context;
            this.window = window;
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            string login = loginBox.Text;
            string password = passwordBox.Text;
            Teacheer user = context.Teacheer.Find(login);
            if (user != null)
            {
                if (user.Password == password)
                {
                    MessageBox.Show("Вы успешно авторизованы!");
                    NavigationService.Navigate(new MagazinePage(context));
                }
                else
                {
                    MessageBox.Show("Неверный пароль!!!");
                }
            }
            else
            {
                MessageBox.Show("Такого пользователя не существует!!!");
            }
        }

        private void RegClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage(context, window));
        }
    }
}
