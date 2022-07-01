using System;
using System.Collections.Generic;

namespace PersonManagement
{
    internal class Program
    {
        public static List<Person> persons { get; set; } = new List<Person>();
        static void Main(string[] args)
        {
            

            Console.WriteLine("Our available commands :");
            Console.WriteLine("/add-new-person");
            Console.WriteLine("/remove-person");
            Console.WriteLine("/show-persons");
            Console.WriteLine("/remove-all");
            Console.WriteLine("/exit");

            while (true)
            {
                Console.WriteLine();
                Console.Write("Enter command : ");
                string command = Console.ReadLine();

                if (command == "/add-new-person")
                {
                    Console.Write("Please add person's name :");
                    string name = Console.ReadLine();

                    Console.Write("Please add person's surname :");
                    string lastName = Console.ReadLine();

                    Console.Write("Please add person's FIN code :");
                    string fin = Console.ReadLine();

                    Person person = AddNewPerson(name,lastName,fin);
                    
                    Console.WriteLine(person.GetInfo() + " - Added to system.");

                }
                else if (command == "/remove-person")
                {
                    Console.Write("To remove person, please enter his/her FIN code : ");
                    string fin = Console.ReadLine();

                    RemovePerson(fin);
                }
                else if (command == "/show-persons")
                {
                    Console.WriteLine("Persons in database : ");
                    ShowPerson();
                    
                }
                else if (command == "/remove-all")
                {
                    RemoveAllPersons();
                    Console.WriteLine("All persons removed");
                }
                else if (command == "/exit")
                {
                    Console.WriteLine("Thanks for using our application!");
                    break;
                }
                else
                {
                    Console.WriteLine("Command not found, please enter command from list!");
                    Console.WriteLine();
                }
            }

            
        }
        public static Person AddNewPerson(string name,string lastname,string fin)
        {
            Person person = new Person(name, lastname, fin);
            persons.Add(person); 
            return person;
            
        }

        public static void RemovePerson(string fin)
        {
            for (int i = 0; i < persons.Count; i++)
            {
                if (persons[i].FIN == fin)
                {
                    Console.WriteLine(persons[i].GetInfo());
                    persons.RemoveAt(i);
                    Console.WriteLine("Person removed successfully");
                }
            }
        }

        public static void ShowPerson()
        {
            foreach (Person person in persons)
            {
                Console.WriteLine(person.GetInfo());
            }
        }

        public static void RemoveAllPersons()
        {
            for (int i = persons.Count - 1; i >= 0; i--)
            {
                persons.RemoveAt(i);
            }
        }

    }

    class Person
    {
        public static int _idcounter=1;
        public int ID { get; private set; } 
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FIN { get; set; }

        public Person(string name, string lastName, string fin)
        {
            ID=_idcounter;
            Name = name;
            LastName = lastName;
            FIN = fin;
            _idcounter++;
        }

        public string GetFullName()
        {
            return Name + " " + LastName;
        }

        public string GetInfo()
        {
            return ID+" "+Name + " " + LastName + " " + FIN;
        }
    }
}
