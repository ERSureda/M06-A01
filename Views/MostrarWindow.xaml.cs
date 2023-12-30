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
    /// Lógica de interacción para MostrarWindow.xaml
    /// </summary>
    public partial class MostrarWindow : Window
    {
        public ObservableCollection<Student> studentsCollection;
        public MostrarWindow()
        {
            InitializeComponent();
            studentsCollection = new ObservableCollection<Student>();
            StudentsGrid.ItemsSource = studentsCollection;
            List();
        }

        public async void List()
        {
            FirebaseDomainFacory firebaseFactory = new FirebaseDomainFacory();
            IFirebaseDomain firebaseRepository = firebaseFactory.GetFirebaseDomain();

            List<Student> studentList = await firebaseRepository.GetListStudents();

            foreach (Student student in studentList)
            {
                studentsCollection.Add(student);
            }
        }
    }
}
