// VisualizationActivity.cs
public class VisualizationActivity : MindfulnessActivity
{
    private List<string> _visualizations = new List<string>
    {
        "Imagine you're sitting by a quiet lake. The surface is perfectly still.",
        "Picture a warm breeze brushing gently through tall grass around you.",
        "Visualize soft clouds drifting slowly across a pale blue sky.",
        "You're walking barefoot on cool sand as the waves lap the shore.",
        "You hear birdsong echoing through a peaceful forest path.",
        "Sunlight streams through the window, warming your skin.",
        "You're wrapped in a soft blanket, safe and calm.",
        "You're lying on a hillside, watching stars slowly appear in the twilight sky.",
        "You breathe in the fresh scent of pine and earth in a quiet mountain meadow."
    };

    public VisualizationActivity() 
        : base("Visualization", 
               "This activity will help you clear your mind by guiding you through a series of calming visualizations. Breathe deeply and imagine each scene as clearly as you can.")
    {
    }

    public override void RunActivity()
    {
        DisplayStartingMessage();

        Random rand = new Random();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            string scene = _visualizations[rand.Next(_visualizations.Count)];
            Console.WriteLine($"\n{scene}");
            PauseWithSpinner(4);
        }

        DisplayEndingMessage();
    }
}