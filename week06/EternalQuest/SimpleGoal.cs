public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) 
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            Console.WriteLine($"Goal completed! You earned {_points} points.");
        }
        else
        {
            Console.WriteLine("Goal already completed.");
        }
    }

    public override string GetStatus()
    {
        return _isComplete ? "[X]" : "[ ]";
    }
}
