using System;
using System.Collections.Generic;


public delegate void FeedAnimalDelegate(string food);


public delegate string ProduceDelegate();


public interface IAnimal
{
    void Feed(string food); 
    string Produce();
}


public class Cow : IAnimal
{
    public void Feed(string food)
    {
        Console.WriteLine($"Корову годують {food}."); 
    }

    public string Produce()
    {
        return "Отримано молоко від корови."; 
    }
}


public class Chicken : IAnimal
{
    public void Feed(string food)
    {
        Console.WriteLine($"Курку годують {food}."); 
    }

    public string Produce()
    {
        return "Отримано яйця від курки."; 
    }
}


public class Farm
{
    private List<IAnimal> animals; 

    public Farm()
    {
        animals = new List<IAnimal>(); 
    }

   
    public void AddAnimal(IAnimal animal)
    {
        animals.Add(animal);
    }

    
    public void CollectProducts(string food)
    {
        foreach (var animal in animals)
        {
            animal.Feed(food); 
            string product = animal.Produce(); 
            Console.WriteLine(product);
        }
    }
}


public class Farmer
{
    private Farm farm; 

    public Farmer(Farm farm)
    {
        this.farm = farm;
    }

    
    public void AddAnimalToFarm(IAnimal animal)
    {
        farm.AddAnimal(animal);
    }

    
    public void CollectFarmProducts(string food)
    {
        Console.WriteLine("Фермер розпочинає збір продукції від тварин:");
        farm.CollectProducts(food);
        Console.WriteLine("Фермер завершив збір продукції від тварин.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        IAnimal cow = new Cow();
        IAnimal chicken = new Chicken();

        Farm farm = new Farm();

        Farmer farmer1 = new Farmer(farm);
        farmer1.AddAnimalToFarm(cow);

        Farmer farmer2 = new Farmer(farm);
        farmer2.AddAnimalToFarm(chicken);

        string foodForAnimals = "зерном і водою";

        farmer1.CollectFarmProducts(foodForAnimals);
        farmer2.CollectFarmProducts(foodForAnimals);
    }
}