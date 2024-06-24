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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        ElectronicMagazineEntities context;
        Window window;
        public RegistrationPage(ElectronicMagazineEntities context, Window window)
        {
            InitializeComponent();
            this.context = context;
            this.window = window;
            itemBox.ItemsSource = context.Item.ToList();
        }

        private void RegClick(object sender, RoutedEventArgs e)
        {
            Item item = itemBox.SelectedItem as Item;
            Teacheer teacheer = new Teacheer()
            {
                Login = loginBox.Text,
                Password = passwordBox.Text,
                FIO = fioBox.Text,
                ID_Item = item.ID_Item
            };
            context.Teacheer.Add(teacheer);
            context.SaveChanges();
            NavigationService.Navigate(new Authorization(context, window));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
