namespace dz4
{
    //Task1
    class Money
    {
        private int _primeValue; //целая часть
        private int _secondValue; // копейки


        public double Value //валюта полная
        {
            get {  return (double)_primeValue + ((double)_secondValue/100); }
        }


        public Type MoneyType { get; private set; } 

        public void Reduce(double value) //уменьшение валюты
        {
            int primevalue = (int)value;
            int secondValue = (int)((value - primevalue) * 100);
            Reduce(primevalue, secondValue);
        }

        public void Reduce(int primeValue, int secondValue)
        {
            if (_primeValue > primeValue + 1)
            {
                _primeValue -= primeValue;
                _secondValue -= secondValue;
                if (secondValue < 0)
                {
                    _primeValue -= 1;
                    _secondValue += 100;
                }
            }
        }

        public void Add(double value) //добавить из копеек
        {
            int primeValue = (int)value;
            int secondValue = (int)((value - primeValue) * 100);
            Add(primeValue, secondValue);
           
        }

        public void Add(int primeValue, int secondValue)
        {
            _secondValue += secondValue;
            _primeValue += primeValue;

            if (_secondValue > 100)
            {
                int pv = _secondValue / 100;
                _primeValue += pv;
                _secondValue -= pv * 100;
            }
        }

        public override string ToString() //стрингуем, для консоли
        {
            return $"{Value.ToString()} in {MoneyType.ToString()}";
        }



        public Money(int primeValue, int secondValue, Type t)
        {
            MoneyType = t;
            Add(primeValue, secondValue);
        }

        public Money (double value, Type t)
        {
            MoneyType = t;
            Add(value);
        }

        public enum Type
        {
            usd,
            rub,
            eur
        }
    }
    class Product
    {
        public string Name { get; private set; } = "";
        public string Description { get; private set; } = "";
        public Money Cost { get; private set; }

        public Product(string name, string description, Money cost)
        {
            Name = name;
            Description = description;
            Cost = cost;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //task1
            Money usd = new Money(100, 0, Money.Type.usd);
            Product apple = new Product("Apple", "Simple Apple", usd);
            apple.Cost.Reduce(25.234);
            Console.WriteLine(usd);
            Console.ReadKey();


        }
    }
}
