using System;

namespace ExerciseTracking
{
    public abstract class Activity
    {
        private string _date;
        private int _length; // in minutes

        public Activity(string date, int length)
        {
            _date = date;
            _length = length;
        }

        public string GetDate() => _date;
        public int GetLength() => _length;

        public abstract double GetDistance();
        public abstract double GetSpeed();
        public abstract double GetPace();

        public virtual string GetSummary()
        {
            return $"{_date} {this.GetType().Name} ({_length} min) - Distance: {GetDistance():0.00}, Speed: {GetSpeed():0.00}, Pace: {GetPace():0.00} min per unit";
        }
    }
}