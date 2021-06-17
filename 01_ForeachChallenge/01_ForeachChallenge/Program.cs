using System;
using System.Collections.Generic;

namespace _01_ForeachChallenge
{
    class Program
    {
        //Create a Console app that has a
        //List<string> populated with a set of
        //names. Loop through the names using 
        //the foreach. For every name, print it
        //to the console.

        static void Main(string[] args)
        {

            foreach (string person in GetPersonString())
            {
                Console.WriteLine(person);
            }

            foreach (PersonModel personModel in GetPersonModel())
            {
                Console.WriteLine(personModel.FullName);
            }

            Console.ReadKey();
        }


        private static List<string> GetPersonString() =>
            new List<string>()
            {
                "Gerard",
                "Car",
                "Bev",
                "Will"
                
            };


        private static List<PersonModel> GetPersonModel() =>
            new List<PersonModel>()
            {
                new PersonModel { FirstName="Anthony", LastName="Becker" },
                new PersonModel { FirstName="Cam", LastName="DeGuzman" },
                new PersonModel { FirstName="Fiona", LastName="Gil" },
                new PersonModel { FirstName="Hanna", LastName="Ibrahim" },
            };

        




    }
}
