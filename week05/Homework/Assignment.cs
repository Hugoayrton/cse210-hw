public class Assignment
{
    private string _studentName;
    private string _topic;

    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }

    // Método para que las clases derivadas puedan acceder al nombre
    public string GetStudentName()
    {
        return _studentName;
    }
}