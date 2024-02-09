using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Individual_SMS
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Student> students;
        [ObservableProperty]
        public Student selectedStudent = null;


        [RelayCommand]
        public void message()
        {

            MessageBox.Show($"{selectedStudent.FirstName} GPA value must be between 0 and 4.", "Error");
        }

        [RelayCommand]
        public void AddStudent()
        {
            var vm = new AddStudentVM();
            vm.title = "ADD STUDENT ";
            AddStudentWindow window = new AddStudentWindow(vm);
            window.ShowDialog();

            if (vm.Student.FirstName != null)
            {
                students.Add(vm.Student);
            }
        }

        [RelayCommand]
        public void Delete()
        {
            if (selectedStudent != null)
            {
                string name = selectedStudent.FirstName;
                students.Remove(selectedStudent);
                MessageBox.Show($"{name} is Deleted .", "DELETED \a ");

            }
            else
            {
                MessageBox.Show("Plese Select the Student .", "Error");

            }
        }
        [RelayCommand]
        public void ExecuteEditStudentCommand()
        {
            if (selectedStudent != null)
            {
                var vm = new AddStudentVM(selectedStudent);
                vm.title = "EDIT STUDENT DATA";
                var window = new AddStudentWindow(vm);
                window.ShowDialog();
                int index = students.IndexOf(selectedStudent);
                students.RemoveAt(index);
                students.Insert(index, vm.Student);

            }
            else
            {
                MessageBox.Show("Please Select the student", "Warning!");
            }
        }
        public MainWindowVM()
        {
            students = new ObservableCollection<Student>();
            BitmapImage student_image1 = new BitmapImage(new Uri("/Model/Images/1.png", UriKind.Relative));
            students.Add(new Student(12, "Sam1", "Broono1", "12/1/2011", student_image1, "Male", 2.32));
            BitmapImage student_image2 = new BitmapImage(new Uri("/Model/Images/2.png", UriKind.Relative));
            students.Add(new Student(13, "Sam2", "Broono2", "3/3/2010", student_image2, "Male", 3.21));
            BitmapImage student_image3 = new BitmapImage(new Uri("/Model/Images/3.png", UriKind.Relative));
            students.Add(new Student(14, "Sam3", "Broono3", "12/11/2009", student_image3, "Male", 2.93));
            BitmapImage student_image4 = new BitmapImage(new Uri("/Model/Images/4.png", UriKind.Relative));
            students.Add(new Student(12, "Sam4", "Broono4", "8/1/2011", student_image4, "Female", 3.12));
            BitmapImage student_image5 = new BitmapImage(new Uri("/Model/Images/5.png", UriKind.Relative));
            students.Add(new Student(22, "Sam5", "Broono5", "12/4/2001", student_image5, "Male", 2.58));

        }
    }
}
