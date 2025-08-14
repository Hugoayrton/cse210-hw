public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) 
        : base(name, description, points) { }

    public override void RecordEvent()
    {
        Console.WriteLine($"Eternal goal recorded! You earned {_points} points.");
    }

    public override string GetStatus()
    {
        return "[∞]"; // Nunca se completa
    }
}