using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ2
{
    class Developer : Employee
    {
        public string Level { get; set; }
        
        private int LevelBonus;
        
        public Developer(string _fullname, int _baseSalary, string _level) : base (_fullname, _baseSalary)
        {
            Level = _level;
            LevelBonus = Level switch
            {
                "Junior" => 0,
                "Middle" => 5000,
                "Senior" => 10000,
                _ => throw new NonexistentJobLevelException("Неіснуючий рівень")
            };
        }
        public override float CalculateSalary()
        {
            return BaseSalary + LevelBonus;
        }
        public override void PrintInfo()
        {
            Console.WriteLine($"Name:{FullName} level:{Level} pey:{CalculateSalary()}");
        }
    }
}
