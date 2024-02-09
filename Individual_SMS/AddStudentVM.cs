using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Text.RegularExpressions;

namespace Individual_SMS
{
    public partial class AddStudentVM : ObservableObject

    {

        [ObservableProperty]
        public string firstname;

        [ObservableProperty]
        public string lastname;

        [ObservableProperty]
        public int age;

        [ObservableProperty]
        public string dateofbirth;

        [ObservableProperty]
        public string gender;

        [ObservableProperty]
        public double gpa;

        [ObservableProperty]
        public string title;

        [ObservableProperty]
        public BitmapImage selectedImage;


        public AddStudentVM(Student u)
        {
            Student = u;

            firstname = Student.FirstName;
            lastname = Student.LastName;
            age = Student.Age;
            gpa = Student.GPA;
            gender = Student.Gender;
            dateofbirth = Student.DateOfBirth;
            selectedImage = Student.Image;

        }
        public AddStudentVM()
        {

        }


        [RelayCommand]
        public void UploadPhoto()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.bmp; *.png; *.jpg";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == true)
            {
                selectedImage = new BitmapImage(new Uri(dialog.FileName));

                MessageBox.Show("Imgae uploded!", "successfull");
            }
        }

        public Student Student { get; private set; }

        public Action CloseAction { get; internal set; }

        [RelayCommand]
        public void Save()
        {

            if (gpa < 0 || gpa > 4.00)
            {
                MessageBox.Show("Invalid GPA Value", "Error");
                return;
            }
            if (age < 0)
            {
                MessageBox.Show("Invalid Age", "Error");
            }
            if (Student == null)
            {

                Student = new Student()
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Age = age,
                    DateOfBirth = dateofbirth,
                    Image = selectedImage,
                    Gender = gender,
                    GPA =gpa

                };

            }
            else
            {

                Student.FirstName = firstname;
                Student.LastName = lastname;
                Student.Age = age;
                Student.GPA = gpa;
                Student.Gender = gender;
                Student.Image = selectedImage;
                Student.DateOfBirth = dateofbirth;

            }

            if (Student.FirstName != null)
            {

                  CloseAction();
            }
            else
            {
                MessageBox.Show("Please enter the name of the student", "Error");
            }
          

        }

     
    }
}
