using static System.Runtime.InteropServices.JavaScript.JSType;

// Initialize plants using PlantOption
List<Plant> plants = PlantOption.InitializePlants();
Random random = new Random();

string greeting = @"Welcome to Extravert!
The Plant Adoption App";

Console.WriteLine(greeting);

// Display the plant of the day
PlantOption.DisplayPlantOfTheDay(plants, random);

string choice = null;

while (choice != "0")
{
    Console.WriteLine(@"
Choose an option:
0. Exit
1. Display All Plants
2. Post a Plant to be Adopted
3. Adopt a Plant
4. Delist a Plant
5. Search Plants by Light Needs
6. View Statistics
");

    choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Clear();
            PlantOption.DisplayAllPlants(plants); // Call DisplayAllPlants from PlantOption
            break;

        case "2":
            Console.Clear();
            PlantOption.PostPlant(plants); // Call PostPlant from PlantOption
            break;

        case "3":
            Console.Clear();
            PlantOption.AdoptPlant(plants); // Call AdoptPlant from PlantOption
            break;

        case "4":
            Console.Clear();
            PlantOption.DelistPlant(plants); // Call DelistPlant from PlantOption
            break;

        case "5":
            Console.Clear();
            PlantOption.SearchPlantsByLightNeeds(plants); // Call SearchPlantsByLightNeeds from PlantOption
            break;

        case "6":
            Console.Clear();
            PlantOption.DisplayStatistics(plants); // Call DisplayStatistics from PlantOption
            break;

        case "0":
            Console.Clear();
            Console.WriteLine("Thank you for using ExtraVert. Goodbye!");
            return;

        default:
            Console.Clear();
            Console.WriteLine("Invalid choice. Please enter a number between 0 and 6.");
            break;
    }

    // Pause to allow the user to read the message before clearing the console
    if (choice != "0")
    {
        Console.WriteLine("\nPress Enter to return to the menu...");
        Console.ReadLine();
        Console.Clear();
    }
}
