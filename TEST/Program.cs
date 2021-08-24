using System;
using System.Collections;
using System.Linq;

namespace TEST
{
    class Person : IComparable<Person> // IComparable<T> for using orderby in LINQ quiry
    {
        public string Name { get; set; }
        public byte Age { get; set; }
        public Person(string name, byte age)
        {
            Name = name;
            Age = age;
        }
        public override string ToString() => $"{Name} is {Age} years old.";

        public int CompareTo(Person p)
        {
            if (this.Age > p.Age)
                return 1;
            if (this.Age < p.Age)
                return -1;
            else return 0;
        }
    }

    class Room : IEnumerable //IEnumerable for apply OfType<>()
    {
        private ArrayList arrPeople = new ArrayList(0);
        public int Capacity { get => arrPeople.Capacity; }
        public Room() { }
        public void AddPerson(string name, byte age)
        {
            arrPeople.Add(new Person(name, age));
        }

        // Special indexer for iteration in cycle "for" 
        public Person this[int index]
        {
            get => (Person)arrPeople[index];
            set => arrPeople.Insert(index, value);
        }

        public IEnumerator GetEnumerator()
        { return arrPeople.GetEnumerator(); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Room room = new Room();
            room.AddPerson("Stewart", 23);
            room.AddPerson("Bruce", 21);
            room.AddPerson("Strepsils", 25);
            room.AddPerson("Bankoker", 19);

            // example of using cycle "for" in Room type
            for (int i = 0; i < room.Capacity/2; i++)
            { Console.WriteLine(room[i]); }

            //Transofrmation to IEnumerable<Person> for able to use LINQ
            var roomEnum = room.OfType<Person>();

            // LINQ quiry
            Console.WriteLine("LINQ quiry:\n");
            var subset = from person in roomEnum orderby person select person;
            foreach (var item in subset)
            { Console.WriteLine(item); }
        }
    }
}