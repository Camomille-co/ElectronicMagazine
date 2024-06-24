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
    /// Логика взаимодействия для AddStudentPage.xaml
    /// </summary>
    public partial class AddStudentPage : Page
    {
        ElectronicMagazineEntities context;
        Window window;

        public AddStudentPage(ElectronicMagazineEntities context, Window window)
        {
            InitializeComponent();
            this.context = context;
            this.window = window;
            classBox.ItemsSource = context.Class.ToList();
        }

        private void GoBackclick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MagazinePage(context));
        }

        private void AddClicl(object sender, RoutedEventArgs e)
        {
            try
            {
                Class cl = classBox.SelectedItem as Class;

                Student student = new Student()
                {
                    ID_Student = context.Student.ToList().Last().ID_Student + 1,
                    FIO = fioBox.Text,
                    ID_Class = cl.ID_Class,
                    Class = cl,
                    DateOfBirth = Convert.ToDateTime(dateBox.Text),
                    Floor = floorBox.Text
                };

                context.Student.Add(student);
                context.SaveChanges();
                NavigationService.Navigate(new MagazinePage(context));
            }
            catch (FormatException) //перейдет сюда, если исключение возникло на Convert.To...
            {
                MessageBox.Show("Ошибка вводимых данных!");
            }
            catch //перейдет сюда во всех остальных случаях
            {
                MessageBox.Show("Ошибка!");
            }
        }
    }
}
