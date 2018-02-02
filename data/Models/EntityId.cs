namespace data.Models
{
    public class EntityId
    {
        public EntityId(int value)
        {
            Value = value;
        }

        public EntityId(long value)
        {
            Value = (int)value;
        }

        public int Value { get; }

        public EntityId Add(int value)
        {
            return new EntityId(Value + value);
        }
    }
}