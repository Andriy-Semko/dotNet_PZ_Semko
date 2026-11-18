using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;


namespace PZ2
{
    class Manager : Employee
    {
        private int subordinatesCount;
        public int SubordinatesCount
        {
            get => subordinatesCount;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Значення не може бути від'ємним.");
                }
                else
                {
                    subordinatesCount = value;
                }
            }
        }
        private float bonusPerSubordinate;
        public float BonusPerSubordinate
        {
            get => bonusPerSubordinate;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Значення не може бути від'ємним.");
                }
                else { 
                    bonusPerSubordinate = value;
                }
            }
        }
        public Manager(string _fullname, int _baseSalary, int _subordinatesCount, float _bonusPerSubordinate) : base(_fullname, _baseSalary)
        {
            SubordinatesCount = _subordinatesCount;
            BonusPerSubordinate = _bonusPerSubordinate;
        }

        public override float CalculateSalary()
        {
            return BaseSalary + SubordinatesCount * BonusPerSubordinate;
        }
        public override void PrintInfo()
        {
            Console.WriteLine($"Name:{FullName} bonus per subordinate:{BonusPerSubordinate} pey:{CalculateSalary()}");
        }
    }
}
