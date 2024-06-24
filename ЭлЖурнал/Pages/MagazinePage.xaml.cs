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
    /// Логика взаимодействия для MagazinePage.xaml
    /// </summary>
    public partial class MagazinePage : Page
    {
        ElectronicMagazineEntities context;
        Window window;
        public MagazinePage(ElectronicMagazineEntities context)
        {
            InitializeComponent();
            this.context = context;
            table.ItemsSource = context.Student.ToList();
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            //Запрос пользователю, точно ли он хочет удалить
            MessageBoxResult result = MessageBox.Show("Вы точно хотите удалить данный заказ?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try //если в этом блоке произойдет исключение, программа не вылетит, а перейдет в блок catch
                {
                    //получаем заказ, по которому лкикнули "Удалить"
                    Student student = table.SelectedItem as Student;
                    //удаляем
                    context.Student.Remove(student);
                    //сохраняем изменения
                    context.SaveChanges();
                    //снова выводим список в таблицу
                    table.ItemsSource = context.Student.ToList();
                }
                catch
                {
                    MessageBox.Show("Ошибка!");
                }
            }
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddStudentPage(context, window));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization(context,window));
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            Student student = table.SelectedItem as Student;
            NavigationService.Navigate(new UpdatePage(context, student));
        }
    }
}
