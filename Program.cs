using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace sslab5;
class Program
{
    private const string BaseApiUrl = "https://api.adviceslip.com/advice/";

    static async Task Main(string[] args)
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("Advice Generator");
            Console.WriteLine("1. Receive Random Advice");
            Console.WriteLine("2. Search for Advice by ID");
            Console.WriteLine("3. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await GetRandomAdvice();
                    break;
                case "2":
                    await SearchAdviceById();
                    break;
                case "3":
                    isRunning = false;
                    Console.WriteLine("Thanks for using my app! Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
            Console.ReadLine();
        }
    }

    private static async Task GetRandomAdvice()
    {
        Random random = new Random();
        int randomId = random.Next(1, 100);

        using (HttpClient client = new HttpClient())
        {
            try
            {
                string apiUrl = $"{BaseApiUrl}{randomId}";
                string responseJson = await client.GetStringAsync(apiUrl);
                Console.WriteLine($"Random Advice ID: {randomId}");
                Console.WriteLine("Random Advice:");
                Console.WriteLine("Random Advice:");
                Console.WriteLine(responseJson);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        Console.ReadLine();
    }
    private static async Task SearchAdviceById()
    {
        Console.Write("Enter an advice ID: ");

        if (int.TryParse(Console.ReadLine(), out int adviceId))
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string apiUrl = $"{BaseApiUrl}{adviceId}";
                    string responseJson = await client.GetStringAsync(apiUrl);
                    Console.WriteLine($"Advice with ID {adviceId}:");
                    Console.WriteLine(responseJson);
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer for the advice ID.");
        }
        Console.ReadLine();
    }



}

