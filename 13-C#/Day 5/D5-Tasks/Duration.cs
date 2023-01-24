using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D5_Tasks
{
    class Duration
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public Duration(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public Duration(int totalSeconds)
        {
            Hours = totalSeconds / 3600;
            Minutes = (totalSeconds % 3600) / 60;
            Seconds = (totalSeconds % 3600) % 60;
        }

        public override string ToString()
        {
            if (Hours == 0)
                return "Minutes: " + Minutes + ", Seconds: " + Seconds;
            else
                return "Hours: " + Hours + ", Minutes: " + Minutes + ", Seconds: " + Seconds;
        }

        public override bool Equals(object obj)
        {
            Duration D = obj as Duration;
            if (D == null) return false;
            if (this.GetType() != D.GetType()) return false;
            if (object.ReferenceEquals(this, D)) return true;

            return (Hours == D.Hours) && (Minutes == D.Minutes) && (Seconds == D.Seconds);
        }


        // converts the full duration into seconds 
        private int ToSeconds()
        {
            return (Hours * 3600) + (Minutes * 60) + Seconds;
        }

        public static Duration operator +(Duration a, Duration b)
        {
            int totalSeconds = a.ToSeconds() + b.ToSeconds();
            return new Duration(totalSeconds);
        }

        public static Duration operator +(Duration a, int b)
        {
            int totalSeconds = a.ToSeconds() + b;
            return new Duration(totalSeconds);
        }

        public static Duration operator +(int a, Duration b)
        {
            int totalSeconds = a + b.ToSeconds();
            return new Duration(totalSeconds);
        }

        public static Duration operator ++(Duration a)
        {
            int totalSeconds = a.ToSeconds() + 60;
            return new Duration(totalSeconds);
        }

        public static Duration operator --(Duration a)
        {
            int totalSeconds = a.ToSeconds() - 60;
            return new Duration(totalSeconds);
        }

        

        public static bool operator >(Duration a, Duration b)
        {
            return a.ToSeconds() > b.ToSeconds();
        }

        public static bool operator <(Duration a, Duration b)
        {
            return a.ToSeconds() < b.ToSeconds();
        }

        public static bool operator >=(Duration a, Duration b)
        {
            return a.ToSeconds() >= b.ToSeconds();
        }

        public static bool operator <=(Duration a, Duration b)
        {
            return a.ToSeconds() <= b.ToSeconds();
        }

        // this is for when given a single duration ==> if (D1) 
        public static bool operator true(Duration a)
        {
            return a.ToSeconds() > 0;
        }

        public static bool operator false(Duration a)
        {
            return a.ToSeconds() <= 0;
        }

        public static explicit operator DateTime(Duration a)
        {
            return new DateTime().AddSeconds(a.ToSeconds());
        }

       
    }
}
