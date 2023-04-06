# First Steps (Variables and Operators)

For this lesson, we'll use `Console.WriteLine()` and `Console.ReadLine()` to interact with users. These functions are built into C# for simple interaction and logging. We'll talk more about functions later.

> If you use Visual Studio Code, go into your .vscode/launch.json file and change the console option to "externalTerminal." This will allow you to interact with it the same way as people using Visual Studio. The file might not be created until you first try to run the program.

Last time we started with a single-line program:

```csharp
Console.WriteLine("Hello, World!");
```

It just opens a console to print `Hello world` to it, which is not very useful. The first step will be to replace this with the intro text for the game. We'll create it as a `TODO` item (all caps is standard practice) that you can fill in later.

```csharp
Console.WriteLine("TODO: Intro text");
```

In this first version, we won't worry about making decisions or the game loop and hard code each day. If you aren't familiar with hard coding, it's just the practice of setting data in the code instead of using a settings file or user input.

## Variables

One of the core features of most coding languages is variables. Just like in algebra class, a variable is a stand-in for a value, but in coding, they are far more flexible.

There are three main reasons to use variables:

1. Variables are used for values we don't know when writing the code. This could be user input or data retrieved from an external source like a database.
2. To give values names so it is easier to understand what the value is for. `2` could mean two ducks, do something two times, or users can't have more than two roles. Giving the value a name makes it more evident to any developer reading the code what is meant.
3. To make it easier to change. If the value `2` is a limit on the user roles, this may be scattered all over your code. To change it to `3`, you'd need to find every place it is used and change it. If I create a variable called `maxRoles` and use it instead, I only need to change the value once.

The first variable we'll make is a `days` counter. For now, we'll need to change this for each new day, but later we can make it count up on its own until it (theoretically) hits the max value. Since the max is 2,147,483,647, it won't be an issue.

> **Types**
>
> In coding, every variable has a type which is what kind of data is stored inside. Common ones include string (text), integer (whole number), and boolean (true/false).
>
> C# is a statically typed language. Dynamically typed languages like JavaScript or Python use dynamic typing, where the same variable could store different data types. Static typing means that defining a variable also requires setting a type that can't change later.

To declare the variable, the syntax is `<type> <name> = <value>;`. There are two options here. If we want to be specific, we can create it as an integer `int days = 1;`. However, in most cases, it's simpler to let C# figure out the type based on the data. `var days = 1;`. This doesn't make it dynamic- `days` will always be an integer, but it's simpler to type `var` each time than to remember the keyword for each type.

In addition, we can create two more integers to hold the plant's water and energy values.

```csharp
Console.WriteLine("TODO: Intro text");

var days = 1;
var water = 10;
var energy = 5;
var growthStage = 1;
```

## Operators

Operators are symbols that perform specific operations on one or more operands and return a result. They are used to manipulate data, compare values, or perform calculations. We've already used the assignment operator `=` to assign the values to the newly created variables. These include all the basic math operators, comparisons, and many other things. (<https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/> for a complete list.)

For the following line of code, we can use the concatenation operator to include the variables in a message for the user. Even though the message has one type (string) and the variables have a different one (integer), C# is smart enough to understand what we want and convert, known as casting, the integers to strings.

```csharp
Console.WriteLine("Today is day " + days + ". Your plant currently has " + water + " water and " + energy + " energy.");
```

> **String Interpolation**
>
> While it is possible to use the concatenation operator to combine strings, it's difficult to read and easy to make mistakes. String interpolation is preferred since it allows embedding variables directly into the string. In C#, this requires putting a dollar sign at the beginning and enclosing the variable name in curly braces. `$"Today is day {days}."`

## First Interaction

Games aren't fun if you can't play them, so we must let players make decisions. `Console.ReadLine()` will get input from the user, which we can assign to a variable.

```csharp
Console.WriteLine("Would you like to 'grow' or 'wait' for tomorrow?");
var choice = Console.ReadLine();
```

Later, we'll be able to make decisions based on this input, but for now, we'll echo it back and complete the values for that day.

```csharp
// complete the day's calculations
var weather = "sunny";
water -= 2;
energy += 2;
growthStage++;
```

There are a couple new operators here, and we are reassigning the data inside the variables. When changing the data in a variable, you leave out the `var` keyword, which works much like the original assignment. The new operators are just shortcuts for common mathematical operations.

`x += 2;` is equivelent to `x = x + 2;`

`x++;` is the same as writing `x = x + 1;` (it always increments by one)

Finally, it's time to let the user know what happened and start the next day. From now on, we'll use string interpolation since it's the preferred method for creating strings.

```csharp
// print the results
Console.WriteLine($"You decided to {choice}.");
Console.WriteLine($"The weather today was {weather}. You gained 2 energy, lost 2 water, and increased your growth stage to {growthStage}.");
```
