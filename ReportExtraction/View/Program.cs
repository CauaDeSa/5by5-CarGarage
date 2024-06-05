using Model;
using Controller;
using System.Drawing;

internal class Program
{
    private static readonly string MainMenu = "Main menu";
    private static readonly string ByStatus = "Cars by status";
    private static readonly string ByColor = "Cars by color";
    private static readonly string ByManufactureYear = "Cars by manufacture year";

    private static void Main(string[] args)
    {
        ViewController controller = new();

        var command = 0;

        List<Car> cars;

        do
        {
            Console.Clear();
            ShowMenu(MainMenu);

            command = ReadCommand();

            Console.Clear();

            switch (command)
            {
                case 1:

                    ShowMenu(ByStatus);

                    var status = ReadCommand();

                    if (status < 1 || status > 2)
                        break;

                    cars = controller.GetCarsByPlate(controller.GetCarPlatesByStatus(status));

                    if (cars.Count == 0)
                    {
                        Console.WriteLine("\nNo cars found.\n");
                        break;
                    }

                    controller.CreateXmlFile(ByStatus.Replace(" ", "") + status, controller.GenerateXML(cars));

                    ShowCars(cars);
                    break;

                case 2:

                    ShowMenu(ByColor);

                    var color = ReadString();

                    cars = controller.GetCarsByColor(color);

                    if (cars.Count == 0)
                    {
                        Console.WriteLine("\nNo cars found.\n");
                        break;
                    }

                    controller.CreateXmlFile(ByColor.Replace(" ", "") + color,controller.GenerateXML(cars));

                    ShowCars(cars);
                    break;

                case 3:

                    ShowMenu(ByManufactureYear);

                    var year = ReadCommand();

                    cars = controller.GetCarsByManufactureYear(year);

                    if (cars.Count == 0)
                    {
                        Console.WriteLine("\nNo cars found.\n");
                        break;
                    }

                    controller.CreateXmlFile(ByManufactureYear.Replace(" ", "") + year, controller.GenerateXML(cars));

                    ShowCars(cars);
                    break;
            }

            Console.Write("Press any key to continue...");
            Console.ReadKey();

        } while (command > 0 && command < 4);
    }

    private static void ShowCars(List<Car> cars)
    {
        if (cars.Count == 0)
        {
            Console.WriteLine("\nNo cars to show.\n");
            return;
        }

        Console.WriteLine("\n > CARS <\n");

        foreach (var car in cars)
            Console.WriteLine(car);
    }

    public static void ShowMenu(string type)
    {
        Console.WriteLine($" > {type.ToUpper()} < \n");

        switch (type)
        {
            case var value when value == MainMenu:
                Console.WriteLine("[1] Generate report by status.\n" +
                                  "[2] Generate report by color.\n" +
                                  "[3] Generate report by manufacture year.\n" +

                                  "[any other number] Exit\n\n");
                break;

            case var value when value == ByStatus:
                Console.WriteLine("[1] True\n" +
                                  "[2] False\n" +

                                  "[any other number] Exit\n\n");
                break;

            case var value when value == ByColor:
                Console.WriteLine();
                break;

            case var value when value == ByManufactureYear:
                Console.WriteLine();
                break;
        }

        Console.Write("Option: ");
    }

    private static string ReadString()
    {
        string? str;
        int cursorTop = Console.CursorTop;
        int cursorLeft = Console.CursorLeft;

        do
        {
            Console.SetCursorPosition(cursorLeft, cursorTop);
            str = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(str));

        return str;
    }

    private static int ReadCommand()
    {
        int command;
        int cursorTop = Console.CursorTop;
        int cursorLeft = Console.CursorLeft;

        try
        {
            command = int.Parse(ReadString());
        }
        catch (Exception)
        {
            ClearLine(cursorTop, cursorLeft);
            return ReadCommand();
        }

        return command;
    }

    private static void ClearLine(int top, int left)
    {
        Console.SetCursorPosition(left, top);
        Console.WriteLine("                                                 ");
        Console.SetCursorPosition(left, top);
    }
}