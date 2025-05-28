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
using System.Windows.Shapes;
using static WpfApp4.MainWindow;

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для NewToDo.xaml
    /// </summary>
    public partial class NewToDo : Window
    {
        public NewToDo()
        {
            InitializeComponent();

            dateToDo.SelectedDate = DateTime.Now;
        }


        private void ToDoSave(object sender, RoutedEventArgs e)
        {
            if (dateToDo.SelectedDate == null)
            {
                MessageBox.Show("Выберите дату!");
                return;
            }
            var main = (MainWindow)Owner;

            var temp = dateToDo.SelectedDate.Value;
            main.todo.Add(new ToDo(titleToDo.Text, temp, descriptionToDo.Text));

            main.ToDolist.ItemsSource = null;
            main.ToDolist.ItemsSource = main.todo;

            Hide();
        }
    }
}

