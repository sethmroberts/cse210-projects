using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            int pointsEarned = _goals[goalIndex].RecordEvent();
            _score += pointsEarned;
            Console.WriteLine($"You earned {pointsEarned} points!");
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }

    public void ListGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()}");
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Current Score: {_score}");
        Console.WriteLine($"Level Title: {GetLevelTitle()}");
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.Serialize());
            }
        }
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("No save file found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            Goal goal = GoalFactory.CreateGoalFromString(lines[i]);
            _goals.Add(goal);
        }
    }
    public string GetLevelTitle()
    {
        if (_score >= 5000)
            return "Celestial Champion";
        else if (_score >= 3000)
            return "Faithful Finisher";
        else if (_score >= 1500)
            return "Disciple on the Rise";
        else if (_score >= 500)
            return "Spiritual Novice";
        else
            return "Beginner Adventurer";
    }

    public int GetGoalCount() => _goals.Count;
    public Goal GetGoal(int index) => _goals[index];
}
