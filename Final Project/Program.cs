using System;

namespace PlantGame
{
    public enum WeatherType { Rain, Sun, Clouds }
    public enum PlantAction { Grow, Wait, Flower }

    public class Plant
    {
        public int Water { get; set; }
        public int Energy { get; set; }
        public int Growth { get; set; }

        public Plant()
        {
            Water = 50;
            Energy = 50;
            Growth = 0;
        }
    }

    public class Weather
    {
        private static Random random = new Random();

        public static WeatherType GetRandomWeather()
        {
            return (WeatherType)random.Next(0, 3);
        }
    }

    public class Game
    {
        private Plant plant;
        private int days;

        public Game()
        {
            plant = new Plant();
            days = 1;
        }

        public void Play()
        {
            Console.WriteLine("Welcome to the Plant Game!");

            while (true)
            {
                Console.WriteLine($"Day {days}");
                WeatherType weather = Weather.GetRandomWeather();
                Console.WriteLine($"Today's weather: {weather}");

                switch (weather)
                {
                    case WeatherType.Rain:
                        plant.Water += 20;
                        break;
                    case WeatherType.Sun:
                        plant.Energy += 20;
                        break;
                    case WeatherType.Clouds:
                        plant.Water += 10;
                        plant.Energy += 10;
                        break;
                }

                Console.WriteLine($"Water: {plant.Water}, Energy: {plant.Energy}, Growth: {plant.Growth}");

                Console.Write("Choose an action (Grow, Wait, Flower): ");
                string input = Console.ReadLine();
                PlantAction action;

                if (Enum.TryParse(input, true, out action))
                {
                    switch (action)
                    {
                        case PlantAction.Grow:
                            plant.Water -= 15;
                            plant.Energy -= 15;
                            plant.Growth++;
                            break;
                        case PlantAction.Wait:
                            plant.Water -= 5;
                            plant.Energy -= 5;
                            break;
                        case PlantAction.Flower:
                            if (plant.Growth >= 10)
                            {
                                Console.WriteLine("Congratulations! Your plant has flowered, and you have won the game!");
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Your plant is not ready to flower yet. It needs to grow more.");
                            }
                            break;
                    }

                    if (plant.Water <= 0 || plant.Energy <= 0)
                    {
                        Console.WriteLine("Your plant has run out of water or energy, and the game is over.");
                        return;
                    }

                    days++;
                }
                else
                {
                    Console.WriteLine("Invalid action. Please try again.");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Play();
        }
    }
}
