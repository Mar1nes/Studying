using System;

namespace TEST
{
    class Car
    {
        public string Model { get; set; }
        public int CurrSpeed { get; set; }
        public int MaxSpeed { get; }
        bool carIsDead = false;

        public Car(string model, int currSpeed, int maxSpeed = 250)
        {
            Model = model;
            CurrSpeed = currSpeed;
            MaxSpeed = maxSpeed;
        }
        public override string ToString() => $"[ model: {Model}; currspeed: {CurrSpeed}; maxspeed: {MaxSpeed} ]";
        public void Accelerate (int delta)
        {
            if (carIsDead)
            { throw new Exception("Car is dead."); }
            else
                CurrSpeed += delta;
            if (CurrSpeed > MaxSpeed)
            {
                carIsDead = true;
                CurrSpeed = 0;
                Console.WriteLine("Car is out of order.");
            }
            if (MaxSpeed - CurrSpeed <= 20)
            { Console.WriteLine($"Care! Max speed: {MaxSpeed}" ); }
            Console.WriteLine($"{CurrSpeed} MPH");
        }
    }
        class Program
    {
        public static void Main()
        {
            Car c = new Car("Ferrari", 180);
            Console.WriteLine(c.ToString());
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    c.Accelerate(10);
                }
            }
            catch(Exception e)
            { Console.WriteLine($"error: {e.Message}"); }
        }
    }
}