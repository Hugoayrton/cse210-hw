using System;

public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();  
    public abstract string GetStatus();

    public string GetName() => _name;
    public string GetDescription() => _description;
    public int GetPoints() => _points;
}
