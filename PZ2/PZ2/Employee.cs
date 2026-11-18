using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PZ2
{
    abstract class Employee : IComparable<Employee>
    {
        private int baseSalary;
        public string fullName;
        public string FullName { 
            get => fullName;
            set
            {
                if (string.IsNullOrEmpty(value) || !value.All(char.IsLetter))
                {
                    throw new ArgumentException("Некоректне ввнднння ім'я");
                }

                fullName = value;
            }
        }
        //public int BaseSalary { get; set; }
        public int BaseSalary
        {
            get => baseSalary;
            set
            {
                if (value <= 0)
                {
                    throw new InvalidSalaryException("Базова зарплата повинна бути більшою за нуль.");
                }

                baseSalary = value;
            }
        }
        protected Employee(string _fullname, int _baseSalary)
        {
            FullName = _fullname;
            BaseSalary = _baseSalary;
        }
        public abstract float CalculateSalary();
        public virtual void PrintInfo() => Console.WriteLine($"Name:{FullName} salary:{CalculateSalary()}");
        public int CompareTo(Employee? other) => other?.CalculateSalary().CompareTo(CalculateSalary()) ?? 1;
    }
}
