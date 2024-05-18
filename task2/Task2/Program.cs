namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kettle kettle = new Kettle("Чайник Philips", "Чайник для кипячения воды, 1.7L, 2000W");
            Microwave microwave = new Microwave("Микроволновка LG", "Микроволновая печь, 700W, 20L");
            Car car = new Car("Автомобиль Tesla", "Электромобиль, 300kW, 600km range");
            Steamship steamship = new Steamship("Пароход Titanic", "Пассажирский пароход, длина 268.98 м, ширина –– 28.2 м");

            Device[] devices = { kettle, microwave, car, steamship };

            foreach (var device in devices)
            {
                device.Show();
                device.Desc();
                device.Sound();
                Console.WriteLine();
            }
        }
    }

    public abstract class Device
    {
        public string Name { get; set; }
        public string Characteristics { get; set; }

        public Device(string name, string characteristics)
        {
            Name = name;
            Characteristics = characteristics;
        }

        public abstract void Sound();
        public void Show()
        {
            Console.WriteLine($"Устройство: {Name}");
        }
        public void Desc()
        {
            Console.WriteLine($"Описание: {Characteristics}");
        }
    }
    //чайник
    public class Kettle : Device
    {
        public Kettle(string name, string characteristics) : base(name, characteristics) { }

        public override void Sound()
        {
            Console.WriteLine("Чайник: Шипит\n");
        }
    }
    //микроволновка
    public class Microwave : Device
    {
        public Microwave(string name, string characteristics) : base(name, characteristics) { }

        public override void Sound()
        {
            Console.WriteLine("Микроволновка: Пищит");
        }
    }
    //автомобиль
    public class Car : Device
    {
        public Car(string name, string characteristics) : base(name, characteristics) { }

        public override void Sound()
        {
            Console.WriteLine("Автомобиль: рычит");
        }
    }
    //пароход
    public class Steamship : Device
    {
        public Steamship(string name, string characteristics) : base(name, characteristics) { }

        public override void Sound()
        {
            Console.WriteLine("Пароход: Гудит");
        }
    }
}
