using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;
using ЛБ_27_WPF_DOTMET.Models;
using ЛБ_27_WPF_DOTMET.Models.DbDataContext;
namespace ЛБ_27_WPF_DOTMET
{
    /// <summary>
    /// Логика взаимодействия для AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        bool change = false;
        Student not_chanhed_student;
        int student_id;
        public AddStudent()
        {
            InitializeComponent();
        }

        public AddStudent(Student student, bool change)
        {
            InitializeComponent();
            if (student != null)
            {
                not_chanhed_student = student;
                NumBookText.Text = student.Num_book;
                GroupText.Text = student.Group;
                NameText.Text = student.Name;
                YearText.Text = student.Year.ToString();
                student_id = student.Id;
            }

            this.change = change;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Random rnd = new Random();
            using (DbDataContext db = new DbDataContext())
            {
                if (not_chanhed_student == null)
                {
                    not_chanhed_student = new Student();
                }
                not_chanhed_student.Num_book = NumBookText.Text;
                not_chanhed_student.Group = GroupText.Text;
                not_chanhed_student.Name = NameText.Text;
                not_chanhed_student.Year = int.Parse(YearText.Text);


                db.Set<Student>().AddOrUpdate(not_chanhed_student);
                db.SaveChanges();
            }
            using (DbDataContext db = new DbDataContext())
            {
                Student student = db.Set<Student>().Where(s => s.Name == not_chanhed_student.Name).FirstOrDefault();

                if (!change)
                {

                    Session session = new Session
                    {
                        StudentId = student.Id,
                        Informatics = rnd.Next(0, 10),
                        Mathematics = rnd.Next(0, 10),
                        Philosophy = rnd.Next(0, 10),
                    };
                    db.Set<Session>().Add(session);
                }
                db.SaveChanges();
            }

            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
        
    }
}