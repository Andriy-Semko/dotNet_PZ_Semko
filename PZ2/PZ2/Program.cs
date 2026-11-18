namespace PZ2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Employee> staff = new() { 
                new Manager("Gregor", 10000, 3, 1000), 
                new Manager("John", 10500, 6, 1000), 
                new Developer("Nix", 2000, "Junior"),
                new Developer("Gustavo", 5000, "Middle"),
                new Developer("Tobias", 6000, "Senior")
            };

            bool isRunning = true;


            while (isRunning)
            {
                Console.WriteLine("\n=== Меню ===");
                Console.WriteLine("0. Вихід\n1. Додати співробітника\n2. Показати список співробітників\n3. Показати сумарний фонд\n4. Показати співробітників відсортованих по їх заробітній платі");


                int choice = ReadInt("Виберіть дію: ", 0, 4);


                switch (choice)
                {
                    case 0:
                        isRunning = false;
                        break;
                    case 1:
                        string name, level;
                        int salary, subordinates, bonus;
                        Console.WriteLine("\n=== Меню ===");
                        Console.WriteLine("0. Manager\n1. Developer\n");
                        choice = ReadInt("Виберіть посаду: ", 0, 1);
                        try
                        {
                            switch (choice)
                            {
                                case 0:

                                    Console.Write("Ім'я: ");
                                    name = Console.ReadLine();
                                    if(string.IsNullOrEmpty(name) || !name.All(char.IsLetter))
                                    {
                                        throw new ArgumentException("Некоректне ввнднння ім'я");
                                    }
                                    Console.Write("Базова зарплатня: ");
                                    salary = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Кількість підлеглих: ");
                                    subordinates = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Бонус за підлеглого: ");
                                    bonus = Convert.ToInt32(Console.ReadLine());
                                    staff.Add(new Manager(name, salary, subordinates, bonus));
                                    break;
                                case 1:

                                    Console.Write("Ім'я: ");
                                    name = Console.ReadLine();
                                    if (string.IsNullOrEmpty(name) || !name.All(char.IsLetter))
                                    {
                                        throw new ArgumentException("Некоректне ввнднння ім'я");
                                    }
                                    Console.Write("Базова зарплатня: ");
                                    salary = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Рівень: ");
                                    level = Console.ReadLine();
                                    staff.Add(new Developer(name, salary, level));
                                    break;
                            }
                        }
                        catch (InvalidSalaryException ex)
                        {
                            Console.WriteLine($"Помилка зарплати: {ex.Message}");
                        }
                        catch (NonexistentJobLevelException ex)
                        {
                            Console.WriteLine($"Помилка рівня: {ex.Message}");
                        }
                       
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Помилка: {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Непередбачена помилка: {ex.Message}");
                        }
                        break;

                    case 2:
                        foreach (Employee employee in staff)
                        {
                            employee.PrintInfo();
                        }
                        break;
                    case 3:
                        float sum = 0;
                        foreach (Employee employee in staff)
                        {
                            sum += employee.CalculateSalary();
                        }
                        Console.WriteLine($"Sum:{sum}");
                        break;
                    case 4:
                        List<Employee> sortedStaff = staff.OrderBy(employee => employee).ToList();
                        foreach (Employee employee in sortedStaff)
                        {
                            employee.PrintInfo();
                        }
                        break;
                }    
                
            }

            static int ReadInt(string prompt, int min = int.MinValue, int max = int.MaxValue)
            {
                while (true)
                {
                    Console.Write(prompt);
                    string? input = Console.ReadLine();

                    if (int.TryParse(input, out int value) && value >= min && value <= max)
                    {
                        return value;
                    }

                    Console.WriteLine($"Некоректне значення. Введіть ціле число від {min} до {max}.");
                }
            }
        }
        
    }

}

public class NonexistentJobLevelException : Exception
{
    public NonexistentJobLevelException() : base("Такого рівня розробника не існує.") { }
    public NonexistentJobLevelException(string message) : base(message) { }
    public NonexistentJobLevelException(string message, Exception inner) : base(message, inner) { }
}

public class InvalidSalaryException : Exception
{
    public InvalidSalaryException() : base("Некоректне значення зарплати.") { }
    public InvalidSalaryException(string message) : base(message) { }
    public InvalidSalaryException(string message, Exception inner) : base(message, inner) { }
}