namespace InterfaceExample
{
    class App
    {
        public static void Main()
        {
            Dog myPet = new Dog("Ella");
            Cat neighboursPet = new Cat("Yoda");
            ITrainable trainedPet = myPet;
            ITrainable myRobotDog = new RobotDog();

            // Bunch of examples to test wether our methods work
            // Console.WriteLine(neighboursPet.MakeSound());
            // Console.WriteLine(myPet.MakeSound());
            // Console.WriteLine(trainedPet.Train());
            // Console.WriteLine(myRobotDog.Train());

            // To train both animals and non-animals
            // We can put them all in a list of ITrainable instances and train them all at once
            List<ITrainable> army = new List<ITrainable>
            {
                trainedPet,
                myRobotDog
            };

            foreach (ITrainable dog in army)
            {
                Console.WriteLine("Army: " + dog.Train());
            }

            // What about animals that are not trainable?
            // Lets create a list of animals
            List<Animal> pets = new List<Animal>
            {
                myPet,
                neighboursPet
            };

            foreach (Animal pet in pets)
            {
                if (pet is ITrainable trainable)
                {
                    Console.WriteLine(pet.Name + " is trainable");
                    Console.WriteLine(pet.Name + " " + trainable.Train());
                }
                else
                {
                    Console.WriteLine(pet.Name + " is not trainable");
                    Console.WriteLine($"{pet.Name} is a {pet.GetType().Name} and refuses training. Some beings cannot be controlled.");
                }
            }

        }
    }

    // Abstract Base class (abstract members must be implemented by derived classes)
    // Can contain implementation
    // Can contain fields
    // support single inheritance only
    public abstract class Animal
    {
        public abstract string Name { get; set; }

        public abstract string MakeSound();
    }

    // Derived class through inheritance
    // Must override base class implementation
    // Can only inherit from one base class
    public class Dog : Animal, ITrainable
    {
        public override string Name { get; set; }

        public Dog(string name)
        {
            Name = name;
        }

        public override string MakeSound()
        {
            return "BARK";
        }

        public string Train()
        {
            return "The dog trains";
        }
    }

    // This class does not inherit from the Animal class and thus it cannot have a name or make a sound, only train
    public class RobotDog : ITrainable
    {
        public string Train()
        {
            return "Robot dog initiates a new training module";
        }
    }

    // Derived class through inheritance
    public class Cat : Animal
    {
        public override string Name { get; set; }

        public Cat(string name)
        {
            Name = name;
        }

        public override string MakeSound()
        {
            return "MEW";
        }
    }

    // Interfaces
    // Cannot be instantiated
    // Can be applied to many classes
    // Cannot have fields, but can have methods and properties
    public interface ITrainable
    {
        string Train();
    }
}