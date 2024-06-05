using Controller;
using Model;

internal class Program
{
    private static void Main(string[] args)
    {
        ViewController controller = new();
        Random random = new Random();

        List<string> colors = new List<string>
        {
            "Red",
            "Green",
            "Black",
            "Orange",
            "Purple",
            "Pink",
            "Blue",
            "Yellow",
            "White",
            "Brown",
            "Gray",
            "Silver"
        };

        List<string> names = new List<string>
        {
            "Gol",
            "Uno",
            "Corsa",
            "Fusca",
            "Opala",
            "Marea",
            "Celta",
            "Palio",
            "Fiesta",
            "Ka"
        };

        List<string> plates = new();

        for (int i = 0; i < 30; i++)
        {
            string plate = string.Empty;

            for (int j = 0; j < 3; j++)
                plate += (char)random.Next(65, 91);

            plate += " ";

            for (int j = 0; j < 4; j++)
                plate += random.Next(0, 9);

            plates.Add(plate);
        }

        List<IEntity> cars = new();

        for (int i = 0; i < 30; i++)
        {
            int modelYear = random.Next(1990, 2023);

            cars.Add(new Car
            {
                Plate = plates[i],
                CarName = names[random.Next(0, names.Count)],
                ModelYear = modelYear,
                ManufactureYear = random.Next(modelYear, 2023),
                Color = colors[random.Next(0, colors.Count)]
            });
        }

        Console.WriteLine(controller.CreateJson(cars) ? "Cars inserted successfully!" : "Error mocking cars!");
    }
}