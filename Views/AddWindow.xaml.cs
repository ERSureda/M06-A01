using M06_A01.Domain;
using M06_A01.Models;
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

namespace M06_A01.Views
{
    /// <summary>
    /// Lógica de interacción para AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
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

            Student strudent = new Student()
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

            FirebaseDomainFacory firebaseFactory = new FirebaseDomainFacory();
            IFirebaseDomain firebaseRepository = firebaseFactory.GetFirebaseDomain();
            firebaseRepository.AddStudent(strudent);
        }
    }
}
