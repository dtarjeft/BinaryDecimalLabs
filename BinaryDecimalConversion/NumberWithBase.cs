namespace BaseConversion
{
    public class NumberWithBase
    {
        
        public int Value { get; private set; }
        public int BaseValue { get; private set; }

        public NumberWithBase(int value, int baseValue = 10)
        {
            BaseValue = baseValue;
            Value = value;
        }

        public void ChangeBase(int newBase)
        {
            var oldVal = Value;
            Value = 0;
            var evenFlag = oldVal%2 == 0;

            while (oldVal != 0)
            {
                Value *= BaseValue;
                Value += oldVal%newBase;
                oldVal /= newBase;
            }
            if (evenFlag)
            {
                Value *= BaseValue;
            }
            BaseValue = newBase;
        }

        private void _checkBase()
        {
            var oldVal = Value;
            var newVal = 0;
            var evenFlag = oldVal %2 == 0;

            while (oldVal != 0)
            {
                var token = oldVal%10;
                if (token >= BaseValue)
                {
                    oldVal -= BaseValue;
                    oldVal += 10;
                    continue;
                }
                oldVal /= 10;
                newVal *= 10;
                newVal += token;
            }
            if (evenFlag)
            {
                newVal *= 10;
            }
            Value = newVal;

        }


        public static NumberWithBase operator +(NumberWithBase n1, NumberWithBase n2)
        {
            if (n2.BaseValue != n1.BaseValue)
            {
                n2.ChangeBase(n1.BaseValue);
            }
            var numToAdd = new NumberWithBase( n1.Value + n2.Value, n1.BaseValue);
            numToAdd._checkBase();
            return numToAdd;
        }
    }
}