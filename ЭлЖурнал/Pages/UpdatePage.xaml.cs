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
    /// Логика взаимодействия для UpdatePage.xaml
    /// </summary>
    public partial class UpdatePage : Page
    {
        ElectronicMagazineEntities context;
        Student student;
        public UpdatePage(ElectronicMagazineEntities cont, Student st)
        {
            InitializeComponent();
            context = cont;
            student = st;
            classBox.ItemsSource = context.Class.ToList();
            classBox.SelectedItem = student.Class;
            fioBox.Text = student.FIO;
            floorBox.Text = student.Floor;
            dateBox.Text = student.DateOfBirth.ToString();
        }

        private void GoBackclick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MagazinePage(context));
        }

        private void SaveClicl(object sender, RoutedEventArgs e)
        {
            try
            {
                Class cl = classBox.SelectedItem as Class;

                student.ID_Class = cl.ID_Class;
                student.DateOfBirth = Convert.ToDateTime(dateBox.Text);
                student.Floor = floorBox.Text;
                student.FIO = fioBox.Text;
                context.SaveChanges();
                NavigationService.Navigate(new MagazinePage(context));
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
        }
    }
}
