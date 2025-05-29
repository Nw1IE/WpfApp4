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
            if (!dateToDo.SelectedDate.HasValue)
            {
                dateToDo.SelectedDate = DateTime.Now;
            }
            var mainWindow = (MainWindow)Owner;

            mainWindow.ToDoList.Add(new ToDo(titleToDo.Text,
                                    new DateTime(dateToDo.SelectedDate.Value.Year,
                                                dateToDo.SelectedDate.Value.Month,
                                                dateToDo.SelectedDate.Value.Day),
                                    descriptionToDo.Text));
            this.Close();
           
        }
    }
}

