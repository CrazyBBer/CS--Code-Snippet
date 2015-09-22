using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCode
{


    public enum Animal
    {
        Dog = 1,
        Cat,
        Bird

    }

    public class AnimalTypeAttribute : Attribute
    {
        public AnimalTypeAttribute(Animal pet)
        {

            DefaultPet = pet;
        }
        public Animal DefaultPet { get; set; }
    }

    public class AnimalTypeTessClass
    {
        [AnimalType(Animal.Dog)]
        public void Dog() { }

        [AnimalType(Animal.Cat)]
        public void Cat() { }

        [AnimalType(Animal.Bird)]
        public void Bird() { }

    }

    class Program
    {
        static void Main(string[] args)
        {

            var testclass = new AnimalTypeTessClass();
            var type = testclass.GetType();


            foreach (var info in type.GetMethods())
            {
                foreach (var attr in Attribute.GetCustomAttributes(info).Where(attr => attr.GetType() == typeof(AnimalTypeAttribute)))
                {
                    Console.WriteLine("Method {0} has a pet {1} attribute.", info.Name, ((AnimalTypeAttribute)attr).DefaultPet);
                }

            }
            Console.Read();
        }


    }
}
