using System;

namespace data.Models
{
    public class SensorDataId:IEquatable<SensorDataId>
    {
        public SensorDataId(int value)
        {
            Value = value;
        }
        public int Value { get; }

        public bool Equals(SensorDataId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SensorDataId) obj);
        }

        public override int GetHashCode()
        {
            return Value;
        }
    }
}