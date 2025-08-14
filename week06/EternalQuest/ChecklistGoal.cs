public class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _targetTimes;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int targetTimes, int bonus) 
        : base(name, description, points)
    {
        _timesCompleted = 0;
        _targetTimes = targetTimes;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        _timesCompleted++;
        Console.WriteLine($"Checklist goal progress: {_timesCompleted}/{_targetTimes} times. You earned {_points} points.");

        if (_timesCompleted >= _targetTimes)
        {
            Console.WriteLine($"Goal completed! Bonus: {_bonus} points!");
        }
    }

    public override string GetStatus()
    {
        return $"Completed {_timesCompleted}/{_targetTimes} times";
    }
}
