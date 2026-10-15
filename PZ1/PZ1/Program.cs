internal class Program
{
    private static void Main(string[] args)
    {
        bool isRunning = true;
        

        while (isRunning)
        {
            Console.WriteLine("\n=== Меню ===");
            Console.WriteLine("1. Вихід");
            Console.WriteLine("2. км → милі");
            Console.WriteLine("3. милі → км");
            Console.WriteLine("4. кг → фунти");
            Console.WriteLine("5. фунти → кг");
            Console.WriteLine("6. °C → °F");
            Console.WriteLine("7. °F → °C");

            int choice = ReadInt("Виберіть дію: ", 1, 7);
            float input;

            switch (choice)
            {
                case 1:
                    isRunning = false;
                    break;
                case 2:
                    input = ReadFloat("Введіть значення: ", 0);
                    Console.WriteLine(input + "км = " + KmToMilTransfere(input) + "миль");
                    break;
                case 3:
                    input = ReadFloat("Введіть значення: ", 0);
                    Console.WriteLine(input + "миль = " + MilToKmTransfere(input) + "км");
                    break;
                case 4:
                    input = ReadFloat("Введіть значення: ", 0);
                    Console.WriteLine(input + "кг = " + KgToFuTransfere(input) + "фунти");
                    break;
                case 5:
                    input = ReadFloat("Введіть значення: ", 0);
                    Console.WriteLine(input + "фунти = " + FuToKgTransfere(input) + "кг");
                    break;
                case 6:
                    input = ReadFloat("Введіть значення: ", -273.15f);
                    Console.WriteLine(input + "°C = " + CelsToFarTransfere(input) + "°F");
                    break;
                case 7:
                    input = ReadFloat("Введіть значення: ", -459.67f);
                    Console.WriteLine(input + "°F = " + FarToCelsTransfere(input) + "°C");
                    break;
            };
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

    static float ReadFloat(string prompt, float min = float.MinValue, float max = float.MaxValue)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (float.TryParse(input, out float value) && value >= min && value <= max)
            {
                return value;
            }

            Console.WriteLine($"Некоректне значення. Введіть ціле число від {min} до {max}.");
        }
    }

    static float KmToMilTransfere(float arg)
    {
        return (float) Math.Round(arg / 1.609344, 2);
    }
    static float MilToKmTransfere(float arg)
    {
        return (float) Math.Round(arg * 1.609344, 2);
    }
    static float KgToFuTransfere(float arg)
    {
        return (float) Math.Round(arg / 0.45359237, 2);
    }
    static float FuToKgTransfere(float arg)
    {
        return (float) Math.Round(arg * 0.45359237, 2);
    }
    static float CelsToFarTransfere(float arg)
    {
        return (float)Math.Round(arg * 9/5 + 32, 2);
    }
    static float FarToCelsTransfere(float arg)
    {
        return (float)Math.Round((arg - 32) * 5/9, 2);
    }
}