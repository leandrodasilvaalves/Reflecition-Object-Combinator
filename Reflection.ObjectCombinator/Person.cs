using System;

namespace Reflection.ObjectCombinator
{
    public class Person
    {
        public Person(string name, DateTime dateOfBirth, string phone, double weight)
        {
            Name = name;
            DateofBith = dateOfBirth;
            Phone = phone;
            Weight  = weight;
        }

        public string Name { get; set; }

        public DateTime DateofBith { get; set; }

        public string Phone { get; set; }

        public double Weight { get; set; }
    }
}
