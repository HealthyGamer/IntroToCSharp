using Project;

Console.WriteLine("TODO: Intro text");

var days = 1;
var running = true;
var plant = new Plant();
Random random = new Random();

while (running)
{
    Console.WriteLine("Today is day " + days + " . Your plant currently has " + plant.Water + " water and " + plant.Energy + " energy.");
    Console.WriteLine("Would you like to 'grow' or 'wait' for tomorrow, or 'bloom'?");

    var choice = Console.ReadLine();
    Console.WriteLine($"You decided to {choice}.");

    if (choice == "grow")
    {
        plant.UpdateStats(-2, -1, 1);
        Console.WriteLine($"You spent one energy and two water to grow. Your current growth stage is {plant.GrowthStage}");
    } else if (choice == "wait")
    {
        plant.UpdateStats(-1, 0);
        Console.WriteLine("Waiting cost you one water.");
    }
    else if (choice == "bloom")
    {
        if(plant.GrowthStage >= 3)
        {
            Console.WriteLine($"Congrats! You won in {days} days and became a beautiful flower.");
            running = false;
            break;
        }
        else
        {
            Console.WriteLine($"Still too early to bloom. You need to grow {3 - plant.GrowthStage} more times. You lose one energy and one water trying");
            plant.UpdateStats(-1, -1);
        }
    }
    else
    {
        Console.WriteLine("Invalid option- try again tomorrow. You lost one energy waiting");
        plant.UpdateStats(0, -1);
    }

    var randomWeather = random.Next(1, 4);

    switch (randomWeather)
    {
        case 1:
            Console.WriteLine($"The weather today was sunny. You gained two energy from the sunlight.");
            plant.UpdateStats(0, 2);
            break;
        case 2:
            Console.WriteLine($"The weather today was rainy. You gained two water from the shower.");
            plant.UpdateStats(2, 0);
            break;
        case 3:
            Console.WriteLine($"The weather today was cloudy.");
            break;
    }
    if (!plant.IsAlive())
    {
        Console.WriteLine("Your plant died. :( Try again later.");
        running = false;
        break;
    }

    days++;
}