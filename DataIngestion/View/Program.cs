using Controller;
using Model;

internal class Program
{
    public static void Main(string[] args)
    {
        ViewController controller = new();

        List<Car> cars = controller.GetListFromJson();

        Console.WriteLine(cars.Count == 0 ? "Error reading file." : "File sucessfully readed.");

        Console.WriteLine(controller.Insert(cars) ? "Sql successfully populated!" : "Error inserting cars");
    }
}