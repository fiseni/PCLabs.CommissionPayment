namespace PCLabs.SharedKernel.Data
{
    public abstract class ValueObject
    {
        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }
            return ReferenceEquals(left, null) || left.Equals(right);
        }

        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !EqualOperator(left, right);
        }

        protected abstract IEnumerable<object> GetAtomicValues();

        public override bool Equals(object? obj)
        {
            if (obj is null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;
            var thisValues = GetAtomicValues().GetEnumerator();
            var otherValues = other.GetAtomicValues().GetEnumerator();
            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                if (ReferenceEquals(thisValues.Current, null) ^
                    ReferenceEquals(otherValues.Current, null))
                {
                    return false;
                }

                if (thisValues.Current is not null &&
                    !thisValues.Current.Equals(otherValues.Current))
                {
                    return false;
                }
            }
            return !thisValues.MoveNext() && !otherValues.MoveNext();
        }

        public override int GetHashCode()
        {
            return GetAtomicValues()
                .Select(x => x is not null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }
    }
}
