// PlantOption.cs
public static class PlantOption
{
    public static List<Plant> InitializePlants()
    {
        return new List<Plant>()
        {
            new Plant()
            { 
                Species = "Snake Plant", 
                LightNeeds = 2,  // low light
                AskingPrice = 15.00M, 
                City = "Nashville",
                ZIP = 37206,
                Sold = false,
            },
            new Plant() 
            { 
                Species = "Spider Plant", 
                LightNeeds = 3,  // med light
                AskingPrice = 18.99M, 
                City = "Knoxville",
                ZIP = 37901,
                Sold = true,
            },
            new Plant()
            {
                Species = "Aloe Vera", 
                LightNeeds = 3,  // med light
                AskingPrice = 13.99M, 
                City = "Gallatin",
                ZIP = 37006,
                Sold = false,
            },
            new Plant()
            {
                Species = "Rosemary", 
                LightNeeds = 5,  // full light
                AskingPrice = 25.00M, 
                City = "Chattanooga",
                ZIP = 37341,
                Sold = false,
            },
            new Plant()
            {
                Species = "Hosta", 
                LightNeeds = 1,  // shade
                AskingPrice = 13.50M, 
                City = "Smyrna",
                ZIP = 37086,
                Sold = true,
            }
        };
    }

    public static void DisplayPlantOfTheDay(List<Plant> plants, Random random)
    {
        List<Plant> availablePlants = plants.Where(p => !p.Sold).ToList();

        if (availablePlants.Count == 0)
        {
            Console.WriteLine("No available plants for the Plant of the Day.");
            return;
        }

        int randomIndex = random.Next(0, availablePlants.Count);
        Plant plantOfTheDay = availablePlants[randomIndex];

        Console.WriteLine($"\nThe plant of the day is {plantOfTheDay.Species} in {plantOfTheDay.City} for ${plantOfTheDay.AskingPrice}.");
    }

    public static void DisplayAllPlants(List<Plant> plants)
    {
        Console.WriteLine("Plants:");

        for (int i = 0; i < plants.Count; i++)
        {
            string availability = plants[i].Sold ? "was sold" : "is available";
            Console.WriteLine($"{i + 1}. A {plants[i].Species} in {plants[i].City} {availability} for {plants[i].AskingPrice} dollars");
        }
    }

    public static void PostPlant(List<Plant> plants)
    {
        string species;
        while (true)
        {
            Console.WriteLine("Enter the species of the plant:");
            species = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(species)) break;
            Console.WriteLine("Species cannot be empty. Please try again.");
        }

        int lightNeeds;
        while (true)
        {
            Console.WriteLine("Enter the light needs (1-5, where 1 is shade and 5 is full sun):");
            if (int.TryParse(Console.ReadLine(), out lightNeeds) && lightNeeds >= 1 && lightNeeds <= 5) break;
            Console.WriteLine("Invalid input. Light needs must be a number between 1 and 5. Please try again.");
        }

        decimal askingPrice;
        while (true)
        {
            Console.WriteLine("Enter the asking price:");
            if (decimal.TryParse(Console.ReadLine(), out askingPrice) && askingPrice >= 0) break;
            Console.WriteLine("Invalid input. Asking price must be a positive number. Please try again.");
        }

        string city;
        while (true)
        {
            Console.WriteLine("Enter the city:");
            city = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(city)) break;
            Console.WriteLine("City cannot be empty. Please try again.");
        }

        int zip;
        while (true)
        {
            Console.WriteLine("Enter the ZIP code:");
            if (int.TryParse(Console.ReadLine(), out zip) && zip >= 10000 && zip <= 99999) break;
            Console.WriteLine("Invalid input. ZIP code must be a 5-digit number. Please try again.");
        }

        Plant newPlant = new Plant()
        {
            Species = species,
            LightNeeds = lightNeeds,
            AskingPrice = askingPrice,
            City = city,
            ZIP = zip,
            Sold = false
        };

        plants.Add(newPlant);

        Console.WriteLine("Plant successfully added to the database!");
    }

    public static void AdoptPlant(List<Plant> plants)
    {
        List<Plant> availablePlants = plants.Where(p => !p.Sold).ToList();

        if (availablePlants.Count == 0)
        {
            Console.WriteLine("No plants available for adoption.");
            return;
        }

        while (true)
        {
            Console.WriteLine("Available Plants:");
            for (int i = 0; i < availablePlants.Count; i++)
            {
                Console.WriteLine($"{i + 1}. A {availablePlants[i].Species} in {availablePlants[i].City} for {availablePlants[i].AskingPrice} dollars");
            }

            Console.WriteLine("\nEnter the number of the plant you want to adopt:");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= availablePlants.Count)
            {
                availablePlants[choice - 1].Sold = true;
                Console.WriteLine($"You have successfully adopted the {availablePlants[choice - 1].Species}.");
                break;
            }
            else
            {
                Console.WriteLine("Invalid selection. Please try again.");
            }
        }
    }

    public static void DelistPlant(List<Plant> plants)
    {
        if (plants.Count == 0)
        {
            Console.WriteLine("No plants available to delist.");
            return;
        }

        while (true)
        {
            Console.WriteLine("All Plants:");
            for (int i = 0; i < plants.Count; i++)
            {
                Console.WriteLine($"{i + 1}. A {plants[i].Species} in {plants[i].City} for {plants[i].AskingPrice} dollars");
            }

            Console.WriteLine("\nEnter the number of the plant you want to delist:");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= plants.Count)
            {
                Console.WriteLine($"You have successfully removed the {plants[choice - 1].Species} from the database.");
                plants.RemoveAt(choice - 1);
                break;
            }
            else
            {
                Console.WriteLine("Invalid selection. Please try again.");
            }
        }
    }

    public static void SearchPlantsByLightNeeds(List<Plant> plants)
    {
        Console.WriteLine("Enter the maximum light needs (1-5):");
        if (!int.TryParse(Console.ReadLine(), out int maxLightNeeds) || maxLightNeeds < 1 || maxLightNeeds > 5)
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
            return;
        }

        List<Plant> matchingPlants = new List<Plant>();

        foreach (Plant plant in plants)
        {
            if (plant.LightNeeds <= maxLightNeeds)
            {
                matchingPlants.Add(plant);
            }
        }

        if (matchingPlants.Count == 0)
        {
            Console.WriteLine("No plants match the specified light needs.");
        }
        else
        {
            Console.WriteLine("Matching Plants:");
            foreach (Plant plant in matchingPlants)
            {
                Console.WriteLine($"A {plant.Species} in {plant.City} with light needs of {plant.LightNeeds} for {plant.AskingPrice} dollars.");
            }
        }
    }
}
