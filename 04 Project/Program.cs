﻿Console.WriteLine("TODO: Intro text");

// first day
var days = 1;
var water = 10;
var energy = 5;
var growthStage = 1;
var running = true;

while (running)
{
    Console.WriteLine("Today is day " + days + " . Your plant currently has " + water + " water and " + energy + " energy.");
    Console.WriteLine("Would you like to 'grow' or 'wait' for tomorrow, or 'bloom'?");

    var choice = Console.ReadLine();
    Console.WriteLine($"You decided to {choice}.");

    if (choice == "grow")
    {
        growthStage += 1;
        energy -= 1;
        water -= 2;
        Console.WriteLine($"You spent one energy and two water to grow. Your current growth stage is {growthStage}");
    } else if (choice == "wait")
    {
        water -= 1;
        Console.WriteLine("Waiting cost you one water.");
    }
    else if (choice == "bloom")
    {
        if(growthStage >= 3)
        {
            Console.WriteLine($"Congrats! You won in {days} days and became a beautiful flower.");
            running = false;
            break;
        }
        else
        {
            Console.WriteLine($"Still too early to bloom. You need to grow {3 - growthStage} more times. You lose one energy and one water trying");
            water -= 1;
            energy -= 1;
        }
    }
    else
    {
        Console.WriteLine("Invalid option- try again tomorrow. You lost one energy waiting");
        energy -= 1;
    }

    Random random = new Random();
    var randomWeather = random.Next(1, 4);

    switch (randomWeather)
    {
        case 1:
            Console.WriteLine($"The weather today was sunny. You gained two energy from the sunlight.");
            energy += 2;
        break;
        case 2:
            Console.WriteLine($"The weather today was rainy. You gained two water from the shower.");
            water += 2;
        break;
        case 3:
            Console.WriteLine($"The weather today was cloudy.");
            break;
    }
    if (water < 0 || energy < 0)
    {
        Console.WriteLine("Your plant died. :( Try again later.");
        running = false;
        break;
    }
}