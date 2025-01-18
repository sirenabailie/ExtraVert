// See https://aka.ms/new-console-template for more information

using static System.Runtime.InteropServices.JavaScript.JSType;

List<Plant> plants = new List<Plant>()
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

string greeting = @"Welcome to Extravert
The Plant Adoption App";

Console.WriteLine(greeting);

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
");

    choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.WriteLine("Feature not implemented: Display all plants.");
            break;

        case "2":
            Console.WriteLine("Feature not implemented: Post a Plant to be Adopted.");
            break;

        case "3":
            Console.WriteLine("Feature not implemented: Adopt a Plant.");
            break;

        case "4":
            Console.WriteLine("Feature not implemented: Delist a Plant.");
            break;

        case "0":
            Console.WriteLine("Thank you for using ExtraVert. Goodbye!");
            return; 

        default:
            Console.Clear();
            Console.WriteLine("Invalid choice. Please enter a number between 0 and 4.");
            break;
    }

    // Pause to allow the user to read the message before clearing the console
    if (choice != "0")
    {
        Console.WriteLine("\nPress Enter to return to the menu...");
        Console.ReadLine();
    }
}
