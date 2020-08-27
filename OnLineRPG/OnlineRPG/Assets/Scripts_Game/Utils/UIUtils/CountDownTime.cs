namespace Scripts.Utility
{
    public class CountDownTime
    {
        public const int DaySeconds = 86400;
        public const int HourSeconds = 3600;
        public const int MinuteSeconds = 60;

        private int totalSeconds;

        public CountDownTime(int seconds)
        {
            totalSeconds = seconds;
        }

        public int Day
        {
            get
            {
                return totalSeconds / DaySeconds;
            }
        }

        public int TotalHour
        {
            get
            {
                return totalSeconds / HourSeconds;
            }
        }

        public int Hour
        {
            get
            {
                if (totalSeconds < DaySeconds)
                    return totalSeconds / HourSeconds;
                else
                    return (totalSeconds % DaySeconds) / HourSeconds;
            }
        }

        public int TotalMinute
        {
            get
            {
                return totalSeconds / MinuteSeconds;
            }
        }

        public int Minute
        {
            get
            {
                return (totalSeconds % HourSeconds) / MinuteSeconds;
            } 
        }

        public int TotalSecond
        {
            get
            {
                return totalSeconds;
            }
        }

        public int Second
        {
            get
            {
                return totalSeconds % MinuteSeconds;
            }
        }

        public override string ToString()
        {
            if (totalSeconds >= DaySeconds)
                return string.Format("{0}d:{1}h", Day, Hour);
            else
                return string.Format("{0}:{1:D2}:{2:D2}", TotalHour, Minute, Second);
        }
    }
}