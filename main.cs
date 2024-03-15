using System;

class Program
{
    static void Main(string[] args)
    {
        bool exitProgram = false;

        while (!exitProgram)
        {
            Console.WriteLine("Enter activity number (1-5) or type 'exit' to quit:");
            string activityInput = Console.ReadLine();

            if (activityInput.ToLower() == "exit")
            {
                Console.WriteLine("Exiting program...");
                break;
            }

            if (!int.TryParse(activityInput, out int activityNumber) || activityNumber < 1 || activityNumber > 5)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                continue;
            }

            switch (activityNumber)
            {
                case 1:
                    ActivityMoneyDenomination();
                    break;
                case 2:
                    ActivityNumberDivisibility();
                    break;
                case 3:
                    ActivityInputMessage();
                    break;
                case 4:
                    ActivityBuildPyramid();
                    break;
                case 5:
                    ActivitySumVsAppend(out exitProgram);
                    break;
            }

            if (!exitProgram)
            {
                Console.WriteLine("Do you want to continue? (yes/no)");
                string continueInput = Console.ReadLine();
                if (continueInput.ToLower() != "yes")
                {
                    exitProgram = true;
                }
            }
        }
    }

    static void ActivityMoneyDenomination()
    {
        Console.WriteLine("Enter the denomination of the Philippine bank note (in pesos):");
        string denominationEntered = Console.ReadLine();

        if (decimal.TryParse(denominationEntered, out decimal denomination))
        {
            string personality = GetPersonalityFromDenomination(denomination);
            if (personality != null)
            {
                Console.WriteLine($"Personality found: {personality}");
            }
            else
            {
                Console.WriteLine("No person found on the bank note.");
            }
        }
        else
        {
            Console.WriteLine($"Invalid Denomination: {denominationEntered}");
        }
    }

    static string GetPersonalityFromDenomination(decimal denomination)
    {
        switch (denomination)
        {
            case 1m:
                return "Jose Rizal";
            case 5m:
                return "Emilio Aguinaldo";
            case 10m:
                return "Andres Bonifacio, Apolinario Mabini";
            case 20m:
                return "Manuel L. Quezon";
            case 50m:
                return "Sergio Osmena";
            case 100m:
                return "Manuel Roxas";
            case 200m:
                return "Diosdado Macapagal";
            case 500m:
                return "Benigno Sr. and Corazon Aquino";
            case 1000m:
                return "Jose Abad Santos, Vicente Lim, Josefa Llanes Escoda";
            default:
                return null;
        }
    }

    static void ActivityNumberDivisibility()
    {
        Console.WriteLine("Enter a number:");
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            FooBar(number);
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }

    static void FooBar(int x)
    {
        for (int i = 1; i <= x; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.WriteLine("FooBar");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("Foo");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("Bar");
            }
            else
            {
                Console.WriteLine(i);
            }
        }
    }

    static void ActivityInputMessage()
    {
        int previousNumber = 0;
        string currentMessage = "";

        while (true)
        {
            Console.Write("Enter something: ");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "exit")
            {
                Console.WriteLine("Closing Program...");
                break;
            }

            if (int.TryParse(userInput, out int number))
            {
                previousNumber += number;
                Console.WriteLine($"Adding {number} to {previousNumber - number} = {previousNumber}");
            }
            else
            {
                currentMessage += userInput;
                Console.WriteLine($"Current Message is: {currentMessage}");
            }
        }
    }

    static void ActivityBuildPyramid()
    {
        while (true)
        {
            Console.Write("Enter a number: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
            {
                Console.WriteLine("Closing program...");
                break;
            }

            if (!int.TryParse(input, out int number))
            {
                Console.WriteLine($"Invalid value: {input}");
                continue;
            }

            if (number == 0)
            {
                Console.WriteLine("Closing program...");
                break;
            }

            for (int i = 1; i <= number; i++)
            {
                string spaces = new string(' ', number - i);
                string asterisks = new string('*', 2 * i - 1);
                Console.WriteLine(spaces + asterisks);
            }
        }
    }

    static void ActivitySumVsAppend(out bool exitProgram)
    {
        int sum = 0;
        string currentMessage = "";

        while (true)
        {
            Console.Write("Enter something: ");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "exit")
            {
                Console.WriteLine("Closing Program...");
                exitProgram = true;
                return;
            }

            if (int.TryParse(userInput, out int number))
            {
                sum += number;
                Console.WriteLine($"Sum: {sum}");
            }
            else
            {
                currentMessage += userInput;
                Console.WriteLine($"Current Message is: {currentMessage}");
            }
        }
    }
}