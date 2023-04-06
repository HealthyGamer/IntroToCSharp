https://github.com/microsoft/vscode-remote-try-dotnet

# Introduction to C# and .NET

## A Brief History of C#

C# was created by Anders Hejlsberg and his team at Microsoft in the early 2000s, with the first version released in 2002 as part of the .NET Framework. The language's syntax is influenced by C++ and Java, making it familiar to developers from various backgrounds. C# has evolved significantly over the years, with continuous improvements and new features added in each version. It has become popular for developers due to its ease of use, strong typing, and excellent tooling support.

## .NET Framework vs. .NET Core vs. .NET 5+ vs. Mono

The .NET ecosystem has also evolved over time. The .NET Framework, released in 2002, was the first incarnation of the platform. It is a Windows-only framework suitable for building various applications, including desktop, web, and services.

Mono is an open-source implementation of the .NET Framework that aims to bring the .NET platform to non-Windows environments. It was created by Xamarin in 2004 as a way to enable developers to build cross-platform applications using C# and other .NET languages. Mono provides a runtime and class libraries compatible with the .NET Framework, allowing developers to create applications that can run on multiple platforms such as macOS, Linux, and various mobile operating systems.

.NET Core, introduced in 2016, is a cross-platform, open-source successor to the .NET Framework. It is designed to create modern applications running on Windows, macOS, and Linux. .NET Core focuses on performance, modularity, and flexibility, making it ideal for cloud-based and containerized applications.
In November 2020, Microsoft released .NET 5, the unification of .NET Core and .NET Framework. It aims to provide a single, consistent platform for all types of applications. Future .NET releases will follow this new unified approach with .NET 6, .NET 7, etc.

## Setting up the Development Environment

### Installing Visual Studio or Visual Studio Code

To get started with C# development, you'll need an Integrated Development Environment (IDE). Visual Studio and Visual Studio Code are two popular choices.
Visual Studio is a powerful IDE for Windows and macOS, tailored for .NET development. You can download the free Community edition or paid editions from the official website (<https://visualstudio.microsoft.com/>). During installation, select the ".NET Desktop Development" workload.

Visual Studio Code (VSCode) is a lightweight, cross-platform code editor with built-in support for many programming languages. It can be extended with various extensions for C# and .NET development. Download VSCode from the official website (<https://code.visualstudio.com/>), and install Microsoft's "C# for Visual Studio Code" extension from the extension marketplace.

## Hello World

"Hello, World!" is a tradition in the programming world, where beginners write a simple program that displays the message "Hello, World!" on the screen. It serves as a starting point to familiarize oneself with a new programming language or development environment. The tradition dates back to 1978 when Brian Kernighan and Dennis Ritchie, the creators of the C programming language, used the "Hello, World!" example in their book "The C Programming Language." Since then, it has become a rite of passage for programmers learning a new language. The simplicity of the program makes it easy to understand and verify that the development environment is set up correctly. By focusing on a single, straightforward task, newcomers can quickly grasp the basic syntax and structure of a language without being overwhelmed by complex concepts. The "Hello, World!" tradition serves as a symbol of unity among developers, as it represents the shared experience of starting the journey into a new programming language.

### Creating a New Console Application Project

With your IDE installed, you can create a new console application project.

#### For Visual Studio

1. Launch Visual Studio.
2. Click "Create a new project."
3. Choose "Console App (.NET)" from the list of templates.
4. Enter a name and location for your project and click "Create."

#### For Visual Studio Code

1. Launch VSCode.
2. Open a terminal (View > Terminal).
3. Navigate to the desired directory for your project.
4. Execute the following command to create a new console application: `dotnet new console -n YourProjectName`.
5 Open the newly created project folder in VSCode (File > Open Folder).
5. To get the same console experience as Visual Studio users, you'll need to go into .vscode/launch.json and change the `console` setting to `externalTerminal`.

The code for Hello World has gotten much simpler since .NET 6. If you are in Visual Studio, the first line is even written for you when you create a new console app. :)

```csharp
Console.WriteLine("Hello, World!");
Console.ReadLine();
```

### .NET Project Structure

There are a few things to look at in the newly created C# project. Opening the project in File Explorer allows you to see all the files that were created with the new project.

![Open in file explorer from VS menu](./images/Open%20in%20explorer.png)

![A view of the files for a simple C# project](./images/c-sharp%20files.png)

- `.vs` or `.vscode` has the any settings for Visual or Visual Studio Code you change from the defaults.
- `bin` and `obj` are folders that hold the compiled files for the project.
  - `obj` is stuff that is created during the build process but not used in development or in running the program.
  - `bin` holds the actual program files (more on that in a bit).
- `Hello World.sln` has information on how to build the entire program, including all the projects inside it.
- `Hello World.csproj` is a project file. It is essentially a specialized folder within the program.
  - Each project becomes a .dll file once compiled so it can help keep file size down.
  - Projects are often used to seperate different aspects of a piece of software. For example, the UI might go in one project and the code to interface with the database in a different one.
  - Different projects can be running different languages that are built on top of .NET. The three most common are C#, F#, and VB.Net (or Visual Basic .NET).
- `Program.cs` is the only file that the C# code is in for this Hello World software.

If you dig into the `bin` folder you can find a few other things that are interesting. You need to dig down a few levels to get to the actual files.

![Screenshot of files inside on the bin folder](./images/hello%20world%20exe.png)

- `Hello World.deps.json` and `Hello World.runtimeconfig.json` hold similar types of information to the .sln and .csproj files. They tell the computer which .dll files are important and what version of .NET to run.
- `Hello World.dll` is the compiled code.
- `Hello World.exe` is the executable file- it acts as the entry point for the program. Each program will have one .exe file but it can have any number of .dll files.
- `Hello World.pdb` is only generated for debug information. It allows the debugger to relate the compiled code back to your .cs files. For example, it allows the debugger to tell you which file and line number caused an error.