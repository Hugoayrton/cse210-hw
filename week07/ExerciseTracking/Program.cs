using System;
using System.Collections.Generic;
using ExerciseTracking;

namespace ExerciseTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Activity> activities = new List<Activity>();

            Running run = new Running("03 Nov 2022", 30, 3.0); // 3 miles
            Cycling bike = new Cycling("03 Nov 2022", 60, 12.0); // 12 mph
            Swimming swim = new Swimming("03 Nov 2022", 45, 20); // 20 laps

            activities.Add(run);
            activities.Add(bike);
            activities.Add(swim);

            foreach (Activity activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}