public static class GoalFactory
{
    public static Goal CreateGoalFromString(string line)
    {
        string[] parts = line.Split(':');
        if (parts.Length != 2)
            throw new Exception("Invalid goal format.");

        string type = parts[0];
        string[] values = parts[1].Split(',');

        switch (type)
        {
            case "SimpleGoal":
                return new SimpleGoal(
                    values[0], values[1], int.Parse(values[2]), bool.Parse(values[3]));

            case "EternalGoal":
                return new EternalGoal(
                    values[0], values[1], int.Parse(values[2]));

            case "ChecklistGoal":
                return new ChecklistGoal(
                    values[0], values[1], int.Parse(values[2]),
                    int.Parse(values[3]), int.Parse(values[4]), int.Parse(values[5]));

            default:
                throw new Exception("Unknown goal type: " + type);
        }
    }
}
