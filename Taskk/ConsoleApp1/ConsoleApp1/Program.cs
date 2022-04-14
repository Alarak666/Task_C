using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

abstract class Trait { }
interface ITrait<T> where T : Trait { }
class Walkі : Trait { }
class Swimі : Trait { }
class Pengvin : ITrait<Walkі>, ITrait<Swimі> { }

static class AnimalTraits
{
    public static void Walk(this ITrait<Walkі> trait)
    {
        Console.WriteLine("@W");
    }
    public static void Swim(this ITrait<Swimі> trait)
    {
        Console.WriteLine("@Sw");
    }
}
namespace ConsoleApp1
{
    class Program
    {
        class Person : IComparable
        {
            public int age;
            public double height;
            public double weight;
            public Person() { }
            public Person( int age, double height, double weight)
            {
                this.weight = weight;
                this.age = age;
                this.height = height;
            }
            public int CompareTo(object obj)
            {
                Person p = obj as Person;
                if (p != null)
                {
                    if (age < p.age)
                        return -1;
                    else if (age > p.age)
                        return 1;
                    else
                        return 0;
                }
                else
                    throw new Exception("Параметр типаа Персон");
            }
        }
        class Heir : IComparer<Person>
        {
            public int Compare(Person x, Person y)
            {
                if (x.height < y.height)
                    return -1;
                else if (x.height > y.height)
                    return 1;
                else
                    return 0;
            }
        }

        static void Main(string[] args)
        {
            Person[] person = new Person[]
            {
                new Person(112,72,1232),
                new Person(122,1226,112),
                new Person(1112,121,212),
                new Person(132,14512,142),
                new Person(122,212,123)
            };
            for (int i = 0; i < person.Length; i++)
            {
                Console.WriteLine($"Age: {person[i].age}, Height: {person[i].height}, Weight: {person[i].weight}");
            }
            Array.Sort(person, new Heir());
            Console.WriteLine(new string('-', 10));
            for (int i = 0; i < person.Length; i++)
            {
                Console.WriteLine($"Age: {person[i].age}, Height: {person[i].height}, Weight: {person[i].weight}");
            }
        }
    }
}
