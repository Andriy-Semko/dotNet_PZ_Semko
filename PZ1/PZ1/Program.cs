internal class Program
{
    private static void Main(string[] args)
    {
        bool isRunning = true;
        

        while (isRunning)
        {
            Console.WriteLine("\n=== Меню ===");
            Console.WriteLine("0. Вихід\n1. Додати співробітника\n2. Показати список співробітників\n3. Показати сумарний фонд\n4. Показати співробітників відсортованих по їх заробітній платі");

            int choice = ReadInt("Виберіть дію: ", 0, 4);
            float input;

            switch (choice)
            {
                case 0:
                    isRunning = false;
                    break;
                case 1:
                    input = ReadFloat("Введіть значення: ", 0);
                    Console.WriteLine(input + "км = " + KmToMilTransfere(input) + "миль");
                    break;
                case 2:
                    input = ReadFloat("Введіть значення: ", 0);
                    Console.WriteLine(input + "миль = " + MilToKmTransfere(input) + "км");
                    break;
                case 3:
                    input = ReadFloat("Введіть значення: ", 0);
                    Console.WriteLine(input + "кг = " + KgToFuTransfere(input) + "фунти");
                    break;
                case 4:
                    input = ReadFloat("Введіть значення: ", 0);
                    Console.WriteLine(input + "фунти = " + FuToKgTransfere(input) + "кг");
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