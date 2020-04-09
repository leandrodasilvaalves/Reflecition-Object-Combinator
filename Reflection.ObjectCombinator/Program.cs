using System;

namespace Reflection.ObjectCombinator
{
    class Program
    {
        static ObjectCombinator<Person> combinator = new ObjectCombinator<Person>();

        static void Main(string[] args)
        {
            var originalData = new Person("Leandro", new DateTime(1986,7,12), "16993947762", 92);
            Test1(originalData);
            Test2(originalData);
            Test3(originalData);
            Test4(originalData);
            Console.ReadKey();
        }

        static void Test1(Person original)
        {
            Console.WriteLine("Test - 1");
            var current = new Person("Leandro", new DateTime(1986, 7, 12), null, 92);
            var mergedData = combinator.MergeObjects(original, current);
            Print(mergedData);
        }

        static void Test2(Person original)
        {
            Console.WriteLine("Test - 2");
            var current = new Person("Leandro", new DateTime(1986, 7, 12), string.Empty, 92);
            var mergedData = combinator.MergeObjects(original, current);
            Print(mergedData);
        }

        static void Test3(Person original)
        {
            Console.WriteLine("Test - 3");
            var current = new Person("Leandro", new DateTime(1986, 7, 12), "", 92);
            var mergedData = combinator.MergeObjects(original, current);
            Print(mergedData);
        }

        static void Test4(Person original)
        {
            Console.WriteLine("Test - 4");
            var current = new Person("Leandro", new DateTime(1986, 7, 12), "61 99988-7766", 85);
            var mergedData = combinator.MergeObjects(original, current);
            Print(mergedData);
        }

        static void Print(Person person)
        {
            Console.WriteLine(person.Name);
            Console.WriteLine(person.DateofBith);
            Console.WriteLine(person.Phone);
            Console.WriteLine(person.Weight );
            Console.WriteLine(new string('-', 25));
        }
    }
}
