using System;

namespace TEST
{
    class Car
    {
        private readonly string model;
        private readonly int speed;
        public Car() { }
        public Car(string model, int speed)
        { this.model = model; this.speed = speed; }
        public override string ToString() => $"{this.model} is going {this.speed} MPH";
    }
    class Program
    {
        static void Main(string[] args)
        {
            Car c = new Car("Lancer", 230);
            Console.WriteLine(c.ToString());

            // Create 50 000 items of Car
            Car[] arr = new Car[50000];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new Car();
            }

            // Start GC
            GC.Collect();
            GC.WaitForPendingFinalizers();

            // Check 9000's item after GC
            if (arr[9000] != null)
            { Console.WriteLine("The generation of 9000's item: {0}", GC.GetGeneration(arr[9000])); }
            else
            { Console.WriteLine("9000's item deleted."); }

            // Reflect some properties of GC and memory
            Console.WriteLine("Max lvl of generation is {0}. Total count of generations is: {1}", GC.MaxGeneration, GC.MaxGeneration + 1);
            Console.WriteLine("Total memory of heap: {0} bytes", GC.GetTotalMemory(false));
            Console.WriteLine("Numbers of collect 0 generation: {0}", GC.CollectionCount(0));
            Console.WriteLine("Numbers of collect 1 generation: {0}", GC.CollectionCount(1));
            Console.WriteLine("Numbers of collect 2 generation: {0}", GC.CollectionCount(2));
        }
    }
}
