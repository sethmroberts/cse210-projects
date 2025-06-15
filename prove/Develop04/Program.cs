class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Start Visualization Activity");
            Console.WriteLine("5. Quit");
            Console.Write("Select an option: ");
            
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine("Please enter a number.");
                Thread.Sleep(1500);
                continue;
            }

            MindfulnessActivity activity = null;

            switch (choice)
            {
                case 1:
                    activity = new BreathingActivity();
                    break;
                case 2:
                    activity = new ReflectionActivity();
                    break;
                case 3:
                    activity = new ListingActivity();
                    break;
                case 4:
                    activity = new VisualizationActivity();
                    break;
                case 5:
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    Thread.Sleep(1500);
                    continue;
            }

            activity.RunActivity();
            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
        }
    }
}
