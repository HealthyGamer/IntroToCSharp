# Control Flow

While there might occassionally be a script that only requires a single set of steps, programs get more powerful once they gain the ability to repeat the same steps and to make desicions. In the case of our little game, we need to do different things based on what the weather for the day is, what the player chooses to do, and we need to repeat all these steps each "day."

## Conditionals

Conditionals are the main way programs make desicions. Even AIs technically make desicions this way, though how they do it is extremely complex. There are a couple ways to do this. The most common is an if/else statement.

The most basic form is just the `if` part. The parenthesis after the keyword have a statement that must evaluate to true or false. All the main comparison operators you are likely used to are supported: <, >, <=, !=, etc.. The main differece is that equals is shown with `==` instead of a sinle `=`. This is because the single equals sign is used for assigning values to variables. Double equals indicates comparison. There are some other special ones, but we won't go into that now.

> **Implicit Casts**
>
> In some languages you may be able to do something like if(variable){} in order to determine whether or not a variable has a value. C# doesn't currently have this feature.

```csharp
var num = 5;
if (num > 0) 
{
    Console.WriteLine("The number is positive.");
}
```

In order to run something if the expression evaluates to false, we can add an `else` section. It works just like the if part, but there's nothing we need to check.

```csharp
var num = 5;
if (num > 0) 
{
    Console.WriteLine("The number is positive.");
} else {
    Console.WriteLine("The number is not positive.");
}
```

In the case where we have more than two options, like a user choosing between "grow", "wait", or typing something invalid, you can chain conditions with `else if`.

```csharp
var num = 5;
if (num > 0) 
{
    Console.WriteLine("The number is positive.");
} else if (num == 0) {
    Console.WriteLine("The number is zero.");
} else {
    Console.WriteLine("The number is negative.");
}
```

We won't use it till later, but you can also combine different conditions with && (and) and || (or).

```csharp
var num = 5;
if (num > 0 && num % 2 == 0) 
{
    Console.WriteLine("The number is positive and even.");
} else {
    Console.WriteLine("The number is negative or odd.");
}
```

Now we can actually react to what the player typed in as their action.

```csharp
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
else
{
    Console.WriteLine("Invalid option- try again tomorrow. You lost one energy waiting");
    energy -= 1;
}
```

There's another way to do comparisons that's rarely used, but is extremely useful when you need it. `switch` takes a single variable and compares it to a set of conditions. It runs the first one that passes, or default if none of them do.

We'll use this for the weather. In order to generate that, we'll have C# generate a random number between one and three.

```csharp
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
```

## Loops

The next thing to make the game more flexible is to make each "day" into a loop. We go through the same steps each time, so it's a good spot to improve code functionality.

There are three main types of loops in C# and one variant. `for` loops are the first. We use it to loop through code a set number of times. Inside the statement we have three elements. The first is the index (often abreviated to i). Usually we create a new varaible specifically for this purpose. The second is the condition we check at the start of each loop.

```csharp
for (var i = 1; i <= 10; i++) 
{
    Console.WriteLine(i);
}
```

The second is a foreach loop. It runs once for each item in a collection. You can write this with a `for` loop, but `foreach` is easier to read.

```csharp
int[] numbers = { 1, 2, 3, 4, 5 };

foreach (int number in numbers)
{
    Console.WriteLine(number);
}
```

The third is far less common, but is a key element in programs like games. `while` loops run until a condition evaluates to false. Games often use some variant of `while(true) {}` to make the game run until the player quits. If you've seen game perfomance measured in "ticks per second," it's referring to how many times the game can run through that loop in a single second.

Since our game has a win/lose condition, we'll make a way for the program to decide when to break out of the loop. Wrapping all the code for the player action and weather in a while loop allows the game to repeat until we hit one of those two states.

```csharp
Console.WriteLine("TODO: Intro text");

var days = 1;
var water = 10;
var energy = 5;
var growthStage = 1;
var running = true;

while (running)
{
    Console.WriteLine("Today is day " + days + " . Your plant currently has " + water + " water and " + energy + " energy.");
    Console.WriteLine("Would you like to 'grow' or 'wait' for tomorrow?");
    var choice = Console.ReadLine();

    Random random = new Random();
    var randomWeather = random.Next(1, 4);

    switch (randomWeather) {...}

    Console.WriteLine($"You decided to {choice}.");

    if (choice == "grow") { ... }

    days++;
}
```

## Win/Loss Conditions

While we have the `running` variable in order to break the loop, we currently don't set it. We need to add one more `else if` to the player's choices see if they won and a new if statement to check if they lose.

First we'll update the dailly instruction to include the win option:

```csharp
Console.WriteLine("Would you like to 'grow' or 'wait' for tomorrow, or 'bloom'?");
```

Then we need to add that to the player's choice calculations. `break` just lets us skip the rest of the code in the loop.

```charp
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
```

Finally, at the end of the day, we check if the player is out of energy or water.

```csharp
if (water < 0 || energy < 0)
{
    Console.WriteLine("Your plant died. :( Try again later.");
    running = false;
    break;
}
```
