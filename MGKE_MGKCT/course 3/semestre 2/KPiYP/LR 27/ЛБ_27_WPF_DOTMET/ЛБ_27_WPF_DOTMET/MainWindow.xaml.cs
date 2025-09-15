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
using ЛБ_27_WPF_DOTMET.Models.DbDataContext;
using ЛБ_27_WPF_DOTMET.Models;
namespace ЛБ_27_WPF_DOTMET
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StudentGrid_Loaded(object sender, RoutedEventArgs e)
        {
            using (DbDataContext db = new DbDataContext())
            {
                StudentGrid.ItemsSource = db.Set<Student>().ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddStudent addStudent = new AddStudent();
            addStudent.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Student student = (Student)StudentGrid.SelectedItem;
            AddStudent addStudent = new AddStudent(student, true);
            addStudent.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Student student = (Student)StudentGrid.SelectedItem;

            using (DbDataContext db = new DbDataContext())
            {
                Student studentDel = db.Set<Student>().Where(s => s.Id == student.Id).FirstOrDefault();
                Session sessionDel = db.Set<Session>().Where(s => s.StudentId == studentDel.Id).FirstOrDefault();
                if (sessionDel != null)
                {
                    db.Set<Session>().Remove(sessionDel);
                }
                db.Set<Student>().Remove(studentDel);
                db.SaveChanges();
            }
            StudentGrid.Items.Refresh();
            SessionGrid.Items.Refresh();
        }

        private void SessionGrid_Loaded(object sender, RoutedEventArgs e)
        {
            using (DbDataContext db = new DbDataContext())
            {
                SessionGrid.ItemsSource = db.Set<Session>().ToList();
            }
        }
    }
}
