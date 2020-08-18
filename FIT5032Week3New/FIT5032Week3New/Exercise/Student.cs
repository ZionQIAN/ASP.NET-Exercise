using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace FIT5032_Week03.Exercise
{
    public class Student
    {
        public String Name { get; set; }
        public String PhoneNumber { get; set; }

        public Student(String Name, String PhoneNumber)
        {
            this.Name = Name;
            this.PhoneNumber = PhoneNumber;
        }
    }

    public class ExampleDictionary
    {
        public void Example()
        {
            Dictionary<int, Student> studentDictionary = new Dictionary<int, Student>();

            Student s1 = new Student("Cat", "0455543456");
            Student s2 = new Student("Dog", "0432223456");

            studentDictionary.Add(1, s1);
            studentDictionary.Add(2, s2);

            Student result = new Student("", "");

            studentDictionary.TryGetValue(1, out result);
            Debug.WriteLine("result is: " + result.Name);
        }
    }
}