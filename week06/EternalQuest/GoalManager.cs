using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordGoalEvent(int index)
    {
        if (index >= 0 && index < _goals.Count)
        {
            _goals[index].RecordEvent();
            _score += _goals[index].GetPoints();
        }
    }

    public void DisplayGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i+1}. {_goals[i].GetName()} { _goals[i].GetStatus()}");
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Current Score: {_score}");
    }

    public void Save(string filename)
    {
        using StreamWriter writer = new StreamWriter(filename);
        writer.WriteLine(_score);
        foreach (var goal in _goals)
        {
            writer.WriteLine($"{goal.GetType().Name}|{goal.GetName()}|{goal.GetDescription()}|{goal.GetPoints()}");
        }
        Console.WriteLine("Goals saved!");
    }

    public void Load(string filename)
    {
        if (!File.Exists(filename)) return;

        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            string type = parts[0];
            string name = parts[1];
            string desc = parts[2];
            int points = int.Parse(parts[3]);

            if (type == "SimpleGoal") AddGoal(new SimpleGoal(name, desc, points));
            else if (type == "EternalGoal") AddGoal(new EternalGoal(name, desc, points));
            else if (type == "ChecklistGoal") AddGoal(new ChecklistGoal(name, desc, points, 3, 50)); // Ajuste ejemplo
        }
        Console.WriteLine("Goals loaded!");
    }
}
