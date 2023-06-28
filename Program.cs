using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Runtime.InteropServices;
using System.Security.Policy;

namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            //  создаём пустой список с типом данных Contact
            var phoneBook = new List<Contact>();

            // добавляем контакты
            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

            var sortPhoneBook = phoneBook.OrderBy(contact => contact.Name)
                     .ThenBy(contact => contact.LastName)
                     .Select(c => c);
            
            while (true)
            {
                Console.Write("Введите значение: ");
                var userInput = Console.ReadLine();

                if(userInput == null) 
                {
                    Console.WriteLine("Вы ввели неправильно значение!");
                    break;
                }

                switch (userInput)
                {
                    case "1":
                        var pageOne = sortPhoneBook.Take(2);
                        Console.WriteLine("Запись первой страницы: ");
                        foreach (Contact contact in pageOne)
                        {
                            Console.WriteLine($"\n\t{contact.Name} {contact.LastName}, {contact.PhoneNumber}, {contact.Email}\n");
                        }
                    break;
                    case "2":
                        var pageTwo = sortPhoneBook.Skip(2).Take(2);
                        Console.WriteLine("Запись второй страницы: ");
                        foreach (Contact contact in pageTwo)
                        {
                            Console.WriteLine($"\n\t{contact.Name} {contact.LastName}, {contact.PhoneNumber}, {contact.Email}\n");
                        }
                        break;
                    case "3":
                        var pageThree = sortPhoneBook.Skip(4).Take(2);
                        Console.WriteLine("Запись третьей страницы: ");
                        foreach (Contact contact in pageThree)
                        {
                            Console.WriteLine($"\n\t{contact.Name} {contact.LastName}, {contact.PhoneNumber}, {contact.Email}\n");
                        }
                        break;
                }
            }


            Console.ReadKey();
        }
    }
    public class Contact // модель класса
    {
        public Contact(string name, string lastName, long phoneNumber, String email) // метод-конструктор
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public String Name { get; }
        public String LastName { get; }
        public long PhoneNumber { get; }
        public String Email { get; }
    }
}