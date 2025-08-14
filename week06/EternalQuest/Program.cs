using System;

class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();

        while (true)
        {
            Console.WriteLine("\n--- Eternal Quest ---");
            Console.WriteLine("1. Add Goal");
            Console.WriteLine("2. Record Goal Event");
            Console.WriteLine("3. Display Goals");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Goal type (simple, eternal, checklist): ");
                    string type = Console.ReadLine();
                    Console.Write("Name: "); string name = Console.ReadLine();
                    Console.Write("Description: "); string desc = Console.ReadLine();
                    Console.Write("Points: "); int points = int.Parse(Console.ReadLine());
                    if (type == "simple") manager.AddGoal(new SimpleGoal(name, desc, points));
                    else if (type == "eternal") manager.AddGoal(new EternalGoal(name, desc, points));
                    else if (type == "checklist") manager.AddGoal(new ChecklistGoal(name, desc, points, 3, 50));
                    break;

                case "2":
                    manager.DisplayGoals();
                    Console.Write("Select goal number to record: ");
                    int idx = int.Parse(Console.ReadLine()) - 1;
                    manager.RecordGoalEvent(idx);
                    break;

                case "3": manager.DisplayGoals(); break;
                case "4": manager.DisplayScore(); break;
                case "5": manager.Save("goals.txt"); break;
                case "6": manager.Load("goals.txt"); break;
                case "0": return;
                default: Console.WriteLine("Invalid option."); break;
            }
        }
    }
}
