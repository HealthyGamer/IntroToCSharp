# Organizing Code

Our program is pretty simple, less than 100 lines of code. However, as a program grows it gets harder and harder to maintain it in a single file. We use functions, classes, and objects to organize code into different files, and within a single file.

In both cases, there are two main goals:

1. Break up the code into chunks that are easier to read, maintain, and test.
2. Allow code to be reused in other places in the program.

## Functions

Functions are often visualized as a factory. You bring in materials (data), do stuff to it, and finally return a result (also data).

Creating a function in C# looks something like this:
`<modifiers> <return type> FunctionName( <parameterss> ) { //function body }`

There are a few different modifiers that might be required at the beginning of the function. Here are the most common:

- **public, private, or protected:** This determines where you can access the function from. For today, we'll only use public functions, which can be accessed from anywhere in the program (and even outside it!).
- **async:** A full description of asyncronous programing is outside of the scope of this series, as it's quite complicated. In short, it lets your program multitask. For example, you can allow users to interact with the application while waiting for a complex calculation to finish.
- **static:** This will make more sense once we get to objects, but static classes and functions will only ever have one copy in memory.

### Don't Repeat Yourself

One of the first things to do is to look for places where we repeat ourselves within the code. One spot we can improve things is by seperating out all the times that we update energy, water, and growth into a universal function we can reuse.

> **Parameter Types**
>
> With variables, we often use the `var` keyword and let C# determine what type of data is stored in a variable. With function parameters, we don't have that option since there isn't always a value assigned. For that reason, function parameters do have to use types in declaring them.

For this function, we'll pass in the change in water, energy, and growth. Since there's only one spot in the code that the plant actually grows, we'll give that a default value of zero. We won't need to pass in a value for that unless we want it to be something else. The return type is `void`, meaning that we aren't going to return anything.

```csharp
void UpdateStats(int waterChange, int energyChange, int growthChange = 0)
{
    water += waterChange;
    energy += energyChange;
    growthStage += growthChange;
}
```

We can then go through the code and update all the places that change the energy and water values to use the new function.

For example:

```csharp
 if (choice == "grow")
{
    UpdateStats(-2, -1, 1);
    Console.WriteLine($"You spent one energy and two water to grow. Your current growth stage is {growthStage}");
}
```

### More Readable Code

Sometimes we only need something once, but there's enough logic that it's easier to read the code if we move it into a seperate function. The logic for checking if the plant is alive or not is pretty simple now, but it might get more complicated later, so let's move it out to a seperate function.

```csharp
bool IsAlive() {
    return water > 0 && energy > 0;
}
```

We can now swap out our check at the end of the loop to use the new function. Keep in mind we swapped the direction of the boolean. The previous version was true if the plant died, but the function returns true if it's alive. While it's slightly less efficient code, it is a lot easier to read.

## Classes and Objects

Classes and objects are complex structures, and we'll barely touch all the things they can do here. While a function is usually described as a factory, classes are kind of like categories and objects are specific things. So a class might be something like `Dog`, which defines what properties a dogs has and what it can do. An object would be a specific dog, like my two girls, Rikku and Lulu.

In languages like C#, all the code we write is contained within classes, it's just hidden in the Program.cs file. Objects are values, just like the numbers and strings we've been using already.

### Plant Class

There are a few different things you could seperate into classes in our program. The game itself would usually be seperated out, but with a small one like this it isn't necessary. Weather is another thing that I would probably seperate out. The main thing begging for a seperate class is our plant. It has three properties: water, energy, and growthStage. It's also a good place to put the two functions we made since they act on those properties.

In Visual Studio we'll right click the project and choose Add > New Item > Plant.cs. In Visual Studio Code you'll add a new file and name it `Plant.cs`. In VSC you'll also need to copy over a bit of the code that's premade in Visual Studio.

![image of new item menu](./images/VS%20new%20file.png)

You'll end up with something like this (In VSC you won't need to copy all the using statements):

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Plant
    {
    }
}
```

At the top there's a bunch of `using` statements. These are classes from other files that we want to use inside our new class. The ones Visual Studio includes by default are the most common, but we won't need any of them, so you can remove them if you want.

The things we care about are namespace and class. Namespace defines which dll file the class will end up in and helps to avoid name collisions. I might be using a different project that has a Plant class. I can refer to this one as `Project.Plant` and the other one might be something like `Garden.Plant`. Defining classes have many of the same keywords as functions, with some extras you can learn about on your own.

#### Properties

The next thing we'll do is add properties. They get defined a little bit different than variables. If you are in Visual Studio, you can type `prop` and hit tab to auto-create a new property.

```csharp
internal class Plant
{
    public int Energy { get; set; }
    public int Water { get; set; }
    public int GrowthStage { get; set; }
}
```

Properties also have keywords like public, private, and static. They also have a type and get/set functions. A 'getter' retrieves the value, and a 'setter' changes it. You can customize these, but we just want the defaults, which is `{ get; set; }`.

#### Constructor

The constructor is a special function each class has. It is called only when you first create an instance of an object from that class. In C# a contructor function is named exactly the same thing as the class. We use this to do things like set the starting values for our properties. Just like any other function it can take parameters you can use to adjust those values later.

```csharp
public Plant() { 
    Energy = 5;
    Water = 5;
    GrowthStage = 0;
}
```

#### Functions

> **Camel Case vs. Pascal Case**
>
> Computers don't care how we name things, but we can't use spaces in names so we use different types of cases for seperating words. Each programming language has a style guide listing out how to name things for that language. In C# we mainly use camelCase (Every word but the first is capitalized) for variables and function parameters and PascalCase (every word is capitalized) for most other things like classes, functions, and properties.
>
> In other languages you may also see kebab-case and snake_case.

To finish out our class, we'll copy over the functions from Program.cs and update them to use pascal case to match the properties.

```csharp
internal class Plant
{
    public int Energy { get; set; }
    public int Water { get; set; }
    public int GrowthStage { get; set; }

    public void UpdateStats(int water, int energy, int growth = 0)
    {
        Water += water;
        Energy += energy;
        GrowthStage += growth;
    }

    public bool IsAlive()
    {
        return Water > 0 && Energy > 0;
    }
}
```

Back in Program.cs we can update the code to use the new class. In order to create an object that is based on a class we use the `new` keyword. We can replace the energy, water, and growth variables with our new plant.

```csharp
var days = 1;
var running = true;
var plant = new Plant();
```

In order to access stuff inside our new plant object, we use `plant.<thing to access.`. The final step is to go through the code and update the relevant variables and functions to point to the plant object.

```csharp
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
```
