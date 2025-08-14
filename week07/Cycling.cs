using System;

namespace ExerciseTracking
{
    public class Cycling : Activity
    {
        private double _speed; // in mph

        public Cycling(string date, int length, double speed) : base(date, length)
        {
            _speed = speed;
        }

        public override double GetDistance()
        {
            return (_speed * GetLength()) / 60;
        }

        public override double GetSpeed()
        {
            return _speed;
        }

        public override double GetPace()
        {
            double distance = GetDistance();
            return distance == 0 ? 0 : GetLength() / distance;
        }
    }
}