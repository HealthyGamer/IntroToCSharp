Console.WriteLine("TODO: Intro text");

// first day
var days = 1;
var water = 10;
var energy = 5;
var growthStage = 1;

Console.WriteLine("Today is day " + days + " . Your plant currently has " + water + " water and " + energy + " energy.");
Console.WriteLine("Would you like to 'grow' or 'wait' for tomorrow?");
var choice = Console.ReadLine();

// complete the day's calculations
var weather = "sunny";
water -= 2;
energy += 2;
growthStage++;

// print the results
Console.WriteLine($"You decided to {choice}.");
Console.WriteLine($"The weather today was {weather}. You gained 2 energy, lost 2 water, and increased your growth stage to {growthStage}.");

// second day
days++;
Console.WriteLine($"Today is day {days}. Your plant currently has {water} water and {energy} energy.");
Console.WriteLine("Would you like to 'grow' or 'wait' for tomorrow?");
choice = Console.ReadLine();

// complete the second day's calculations
weather = "rainny";
water += 10;
energy -= 1;

// print the results
Console.WriteLine($"You decided to {choice}.");
Console.WriteLine($"The weather today was {weather}. You gained 2 energy, lost 2 water, and increased your growth stage to {growthStage}.");
