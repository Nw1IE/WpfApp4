using System.Collections.ObjectModel;
using System.Diagnostics.PerformanceData;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<ToDo> todo = new List<ToDo>();
        public ObservableCollection<ToDo> ToDoList = new ObservableCollection<ToDo>();
        public int TodoListCount
        {
            get => ToDoList.Count;
        }
        public int ToDoListCountComplited
        {
            get => ToDoList.Where(p => p.Doing == true).Count();
        }

        public MainWindow()
        {
            InitializeComponent();
           

            ToDoList.CollectionChanged += (s, e) => UpdateCounters();
            UpdateCounters();
        }

        private void Boxe_Cheacked(object sender, RoutedEventArgs e)
        {
            if (ToDolist.SelectedItem != null)
            {
                UpdateCounters();
            }
        }
           

        private void Boxe_UnChecked(object sender, RoutedEventArgs e)
        {
            UpdateCounters();
        }

        private void UpdateCounters()
        {
            CounterrText.Text = $"{ToDoList.Count}/{ToDoList.Count(t => t.Doing)}";
            Progress.Maximum = ToDoList.Count;
            Progress.Value = ToDoList.Count(t => t.Doing);
        }

        private void CreateToDo(object sender, RoutedEventArgs e)
        {
            var AddToDo = new NewToDo();
            AddToDo.Show();
            AddToDo.Owner = this;
        }

        private void btnAdd(object sender, RoutedEventArgs e)
        {
            var newToDo = new NewToDo();
            newToDo.Show();
            newToDo.Owner = this;

        }


        private void btnDelete(object sender, RoutedEventArgs e)
        {
            if (ToDolist.SelectedItem as ToDo == null)
            {
                return;
            }
            else
            {
                todo.Remove((ToDo)ToDolist.SelectedItem);

                ToDolist.ItemsSource = null;
                ToDolist.ItemsSource = todo;
            }
        }

       

        public class ToDo
        {
            private bool doing_;
            public string Name { get; set; }
            public DateTime Date { get; set; }
            public string Description { get; set; }
            public bool Doing
            {
                get => doing_;
                set => doing_ = value;
            }
            public ToDo(string name, DateTime date, string description)
            {
                Name = name;
                Date = date;
                Description = description;
                doing_ = false;
            }
        }
    }
}
