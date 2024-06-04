using System;
using System.Threading;

class VirtualPet
{
    private string name;
    private string petType;
    private int hunger;
    private int happiness;
    private int health;
    public VirtualPet(string name, string petType)
    {
        this.name = name;
        this.petType = petType;
        hunger = 5;
        happiness = 5;
        health = 5;
    }

    public string getName()
    {
        return name;
    }

    public string getPetType()
    {
        return petType;
    }

    public int getHunger()
    {
        return hunger;
    }

    public int getHappiness()
    {
        return happiness;
    }

    public int getHealth()
    {
        return health;
    }

    public void feed()
    {
        hunger = Math.Max(1, hunger - 1);
        health = Math.Min(10, health + 1);
        Console.WriteLine($"Feeding {name} succeeded: Hunger {hunger}, Health: {health}");
    }

    public void play()
    {
        if (hunger > 7)
        {
            Console.WriteLine($"{name} is too hungry to play, please feed it.");
            return;
        }
        happiness = Math.Min(10, happiness + 2);
        hunger = Math.Min(10, hunger + 1);
        Console.WriteLine($"{name} played. Happiness: {happiness}, Hunger: {hunger}");
    }

    public void reset()
    {
        health = Math.Min(10, health + 2);
        happiness = Math.Max(1, happiness - 1);
        Console.WriteLine($"{name} is resting. Health: {health}, Happiness: {happiness}");
    }

    public void displayStatus()
    {
        Console.WriteLine($"{name}'s Status - Hunger: {hunger}, Happiness: {happiness}, Health: {health}");
        if (hunger >= 8)
            Console.WriteLine($"{name} is very hungry!");
        if (happiness <= 2)
            Console.WriteLine($"{name} is very unhappy!");
        if (health <= 2)
            Console.WriteLine($"{name} is very unhealthy!");
    }

    public void simulateTimePassing()
    {
        hunger = Math.Min(10, hunger + 1);
        happiness = Math.Max(1, happiness - 1);
        if (hunger >= 8 || happiness <= 2)
        {
            health = Math.Max(1, health - 1);
        }
    }
}

class VirtualPetSimulator
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Virtual Pet Simulator!");
        Console.WriteLine("Let us get you started.");
        Console.Write("Choose a pet type (e.g., cat, dog, rabbit): ");
        string type = Console.ReadLine();
        Console.Write("Give your pet a name: ");
        string name = Console.ReadLine();
        VirtualPet pet = new VirtualPet(name, type);
        Console.Clear();
        Console.WriteLine($"Welcome to your pet virtual pet {name} the {type} management");
        Thread.Sleep(2000);

        while (true)
        {
            Console.Clear();
            pet.displayStatus();
            Console.WriteLine("Choose an action (1 - 5), 6 to exit:");
            Console.WriteLine("1. Feed");
            Console.WriteLine("2. Play");
            Console.WriteLine("3. Rest");
            Console.WriteLine("4. Simulate the passage of time");
            Console.WriteLine("5. Display Pet's status");
            Console.WriteLine("6. Exit");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    pet.feed();
                    break;
                case "2":
                    pet.play();
                    break;
                case "3":
                    pet.reset();
                    break;
                case "4":
                    Console.WriteLine("Simulate time passsing");
                    pet.simulateTimePassing();
                    break;
                case "5":
                    pet.displayStatus();
                    Thread.Sleep(1000);
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    continue;
            }

            Thread.Sleep(1000);

        }
    }
}
