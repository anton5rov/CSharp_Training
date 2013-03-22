//Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful
//constructors and methods. Dogs, frogs and cats are Animals. All animals
//can produce sound (specified by the ISound interface). Kittens and
//tomcats are cats. All animals are described by age, name and sex. Kittens
//can be only female and tomcats can be only male. Each animal produces a specific
//sound. Create arrays of different kinds of animals and calculate the average
//age of each kind of animal using a static method (you may use LINQ).


using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    class TestAnimals
    {
        static void Main()
        {
            //test for trying to set wrong sex to kitten and tomcat
            Kitten Kity = new Kitten("Kitty", 1);
            try
            {
                Kity.AnimalSex = Animal.Sex.male;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine(Kity);
            Tomcat Tom = new Tomcat("Tom", 4);
            try
            {
                Tom.AnimalSex = Animal.Sex.female;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine(Tom);

            //------------------------------
            // try to set the sex of Cat class - permitted
            Cat Pisana = new Cat("Pisana", 2, Animal.Sex.male);
            Console.WriteLine("Pisana now is {0}", Pisana.AnimalSex);
            Pisana.AnimalSex = Animal.Sex.female;
            Console.WriteLine("Pisana now is {0}", Pisana.AnimalSex);
            Console.WriteLine();
            
            // make list of different animals
            List<Animal> animals = new List<Animal>();
            animals.Add(Kity);
            animals.Add(Tom);
            animals.Add(Pisana);
            animals.Add(new Frog("Froggy", 10, Animal.Sex.male));
            animals.Add(new Dog("Asho", 7, Animal.Sex.male));
            animals.Add(new Dog("Elza", 15, Animal.Sex.female));
            Console.WriteLine("List of animals:");
            PrintList(animals);

            double avrg = Animal.AverageAge(animals);
            Console.WriteLine("Average age of all animals: {0}", avrg);
            Console.WriteLine();
            
            // LINQ for dogs in list only
            var dogList =
                from dog in animals
                where (dog is Dog)
                select dog;
            Console.WriteLine("Dogs in list: ");
            PrintList(dogList);
            avrg = Animal.AverageAge(dogList.ToList());
            Console.WriteLine("Average age of dogs in list: {0}", avrg);
            Console.WriteLine();

            // LINQ for cats in list only
            var catList =
                from cat in animals
                where (cat is Cat)
                select cat;
            Console.WriteLine("Cats in list: ");
            PrintList(catList);
            avrg = Animal.AverageAge(catList.ToList());
            Console.WriteLine("Average age of cats in list: {0}", avrg);
            Console.WriteLine();
            
            // demonstrate Say()
            Console.WriteLine("Animals converstion:");
            animals[4].Say();
            Tom.Say();
        }

        public static void PrintList<T>(IEnumerable<T> list)
        {
            foreach (var element in list)
            {
                Console.WriteLine(element);
            }
        }
    }
}
