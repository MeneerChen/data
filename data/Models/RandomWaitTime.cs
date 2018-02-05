using System;

namespace data.Models
{
    public class RandomWaitTime
    {
        public RandomWaitTime(int fromInSeconds, int toInSeconds)
        {
            FromInSeconds = fromInSeconds;
            ToInSeconds = toInSeconds;
        }

        public int FromInSeconds { get; }
        public int ToInSeconds { get; }
        public int Random => new Random().Next(FromInSeconds, ToInSeconds);
    }
}