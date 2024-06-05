using Model;
using Controller;

namespace View
{
    class Program
    {
        public static readonly string MainMenu = "Main menu";
        public static readonly string Show = "Show";
        public static readonly string Create = "Create";

        static void Main(string[] args)
        {
            int command = 0, auxCommand;
            ViewController controller = new();

            do
            {
                Console.Clear();
                ShowMenu(MainMenu);

                command = ReadCommand();

                Console.Clear();

                switch (command)
                {
                    case 1:
                        ShowMenu(Show);

                        auxCommand = ReadCommand();

                        switch (auxCommand)
                        {
                            case 1:
                                ShowCars(controller.GetAllCars());
                                break;

                            case 2:
                                ShowOperations(controller.GetAllOperations());
                                break;

                            case 3:
                                ShowCarOperations(controller.GetAllCarOperations());
                                break;
                        }
                        break;

                    case 2:
                        ShowMenu(Create);

                        auxCommand = ReadCommand();

                        switch (auxCommand)
                        {
                            case 1:
                                Console.WriteLine(controller.InsertCar(CreateCar()) ? "\nCar successfully inserted\n" : "\nError inserting car\n");
                                break;

                            case 2:
                                Console.WriteLine(controller.InsertOperation(CreateOperation()) ? "\nOperation successfully inserted\n" : "\nError inserting operation\n");
                                break;

                            case 3:
                                Console.WriteLine(controller.InsertCarOperation(CreateCarOperation(controller.GetAllCars(), controller.GetAllOperations())) ? "\nCar operation successfully inserted\n" : "\nError inserting car operation\n");
                                break;
                        }
                        break;
                }

                Console.Write("Press any key to continue...");
                Console.ReadKey();

            } while (command > 0 && command < 3);
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

        private static void ShowOperations(List<Operation> operations)
        {
            if (operations.Count == 0)
            {
                Console.WriteLine("\nNo operations to show.\n");
                return;
            }

            Console.WriteLine("\n > OPERATIONS <\n");

            foreach (var operation in operations)
                Console.WriteLine(operation);
        }

        private static void ShowCarOperations(List<CarOperation> carOperations)
        {
            if (carOperations.Count == 0)
            {
                Console.WriteLine("\nNo car operations to show.\n");
                return;
            }

            Console.WriteLine("\n > CAR OPERATIONS <\n");

            foreach (var carOperation in carOperations)
                Console.WriteLine(carOperation);
        }

        private static Car CreateCar()
        {
            Console.WriteLine("\n > CREATE CAR <\n");

            Console.Write("Plate: ");
            var plate = ReadString();

            Console.Write("Name: ");
            var carName = ReadString();

            Console.Write("Model year: ");
            var modelYear = ReadCommand();

            Console.Write("Manufacture year: ");
            var manufactureYear = ReadCommand();

            Console.Write("Color: ");
            var color = ReadString();

            return new Car()
            {
                Plate = plate, CarName = carName, ModelYear = modelYear, ManufactureYear = manufactureYear, Color = color
            };
        }

        private static Operation CreateOperation()
        {
            Console.WriteLine("\n > CREATE OPERATION < ");
            
            Console.Write("\nDescription: ");
            var description = ReadString();

            return new Operation() { OperationDescription = description };
        }

        private static CarOperation CreateCarOperation(List<Car> cars, List<Operation> operations)
        {
            Console.WriteLine("\n > CREATE CAR OPERATION < ");

            if (cars.Count == 0)
            {
                Console.WriteLine("No cars to show.\n");
                return new CarOperation();
            }

            Console.WriteLine("\n Car plates \n");

            foreach (var car in cars)
                Console.WriteLine($"{car.CarName.PadRight(8, '.')} [{car.Plate}]");

            Console.Write("\nCar plate: ");
            var carPlate = ReadString();
            
            if (operations.Count == 0)
            {
                Console.WriteLine("No operations to show.\n");
                return new CarOperation();
            }

            Console.WriteLine("\n Operation descriptions \n");
            
            foreach (var operation in operations)
                Console.WriteLine($"[{operation.Id}] {operation.OperationDescription}\n");

            Console.Write("Operation id: ");
            var operationId = ReadCommand();
            
            return new CarOperation() { CarPlate = carPlate, OperationId = operationId, OperationStatus = true};
        }

        public static void ShowMenu(string type)
        {
            Console.WriteLine($" > {type.ToUpper()} < \n");

            switch (type)
            {
                case var value when value == MainMenu:
                    Console.WriteLine("[1] Show\n" +
                                      "[2] Create\n" +
                                      
                                      "[any other number] Exit\n\n");
                    break;

                case var value when value == Show:
                    Console.WriteLine("[1] Show cars\n" +
                                      "[2] Show operations\n" +
                                      "[3] Show car operations\n" +
                                      
                                      "[any other number] Exit\n\n");
                    break;

                case var value when value == Create:
                    Console.WriteLine("[1] Create car\n" +
                                      "[2] Create operation\n" +
                                      "[3] Create car operation\n" +

                                      "[any other number] Exit\n\n");
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
}