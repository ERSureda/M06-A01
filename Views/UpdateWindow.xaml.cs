using M06_A01.DataAccess.Repositories;
using M06_A01.Domain;
using M06_A01.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace M06_A01.Views
{
    /// <summary>
    /// Lógica de interacción para UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        //private ObservableCollection<Student> studentsCollection = new ObservableCollection<Student>();
        public UpdateWindow()
        {
            InitializeComponent();
            List();
            //StudentsBox.ItemsSource = studentsCollection;
        }

        public async void List()
        {
            FirebaseDomainFacory firebaseFactory = new FirebaseDomainFacory();
            IFirebaseDomain firebaseRepository = firebaseFactory.GetFirebaseDomain();

            List<Student> studentList = await firebaseRepository.GetListStudents();

            foreach (Student student in studentList)
            {
                StudentsBox.Items.Add(student);
            }
        }

        private void StudentsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Student student = (Student)StudentsBox.SelectedItem;
            txt_Id.Text = student.Id;
            txt_Email.Text = student.Email;
            txt_Name.Text = student.FullName;
            txt_Hobbie.Text = student.Hobbies.First();
            txt_Score.Text = student.AverageScore.ToString();
            txt_Cicle.Text = student.Cicle.FullName;
            txt_Date.SelectedDate = student.BirthDate;
            if (student.Dual)
            {
                dual_si.IsChecked = true;
                dual_no.IsChecked = false;
            } else
            {
                dual_si.IsChecked = false;
                dual_no.IsChecked = true;
            }
        }

        private void ButtonModificar_Click(object sender, RoutedEventArgs e)
        {
            FirebaseFactory firebaseFactory = new FirebaseFactory();
            IFirebaseRepository firebaseRepository = firebaseFactory.GetFirebaseRepository();

            string id = txt_Id.Text;
            string name = txt_Name.Text;
            DateTime date = (DateTime)txt_Date.SelectedDate;
            string email = txt_Email.Text;
            string hobbie = txt_Hobbie.Text;
            List<string> list = new List<string>();
            list.Add(hobbie);
            int score = Convert.ToInt32(txt_Score.Text);
            bool dual;
            if (dual_si.IsChecked == true) dual = true;
            else dual = false;
            string cicle = txt_Cicle.Text;

            Cicle cicleObject = new Cicle()
            {
                FullName = cicle,
                Description = "Description cicle.",
                Subjects = list,
            };

            Student student = new Student()
            {
                Id = id,
                FullName = name,
                BirthDate = date.Date,
                Email = email,
                Hobbies = list,
                AverageScore = score,
                Dual = dual,
                Cicle = cicleObject
            };

            firebaseRepository.UpdateStudent(student);
        }

        private void ButtonBorrar_Click(object sender, RoutedEventArgs e)
        {
            Student student = (Student)StudentsBox.SelectedItem;
            FirebaseDomainFacory firebaseFactory = new FirebaseDomainFacory();
            IFirebaseDomain firebaseRepository = firebaseFactory.GetFirebaseDomain();
            firebaseRepository.RemoveStudent(student);
        }
    }
}
