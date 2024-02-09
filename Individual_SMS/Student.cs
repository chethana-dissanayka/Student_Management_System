using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Individual_SMS
{
    public class Student
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public BitmapImage Image { get; set; }

        public string Gender { get; set; }

        public string DateOfBirth { get; set; }
        public double GPA { get; set; }

        public String ImagePath
        {
            get { return $"/Model/Images/{Image}"; }
        }

        public Student(int age, string firstName, string lastName, string dateOfBirth, BitmapImage image, string gender, double gpa)
        {
            Age = age;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Image = image;
            Gender = gender;
            GPA = gpa;
        }

        public Student()
        {
        }
    }
}
