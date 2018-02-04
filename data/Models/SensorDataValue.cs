using System;
using System.Collections.Generic;

namespace data.Models
{
    public class SensorDataValue : IEquatable<SensorDataValue>
    {
        public static IList<SensorDataValue> SensorDataValues =
            new List<SensorDataValue> {Leftside, Rightside, Back, Belly, Outofbed};

        public SensorDataValue(string value)
        {
            Value = value;
        }

        public static SensorDataValue Leftside => new SensorDataValue("Leftside");
        public static SensorDataValue Rightside => new SensorDataValue("Rightside");
        public static SensorDataValue Back => new SensorDataValue("Back");
        public static SensorDataValue Belly => new SensorDataValue("Belly");
        public static SensorDataValue Outofbed => new SensorDataValue("Outofbed");

        public static SensorDataValue RandomValue() => SensorDataValues[new Random().Next(0, SensorDataValues.Count - 1)];

        public string Value { get; }

        public bool Equals(SensorDataValue other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Value, other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((SensorDataValue) obj);
        }

        public override int GetHashCode()
        {
            return Value != null ? Value.GetHashCode() : 0;
        }
    }
}