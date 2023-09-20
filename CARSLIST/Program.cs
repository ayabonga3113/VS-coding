namespace CARSLIST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Arraylist ProgramGarage = new();
            bool exit = false;
           
            while (!exit)
            {
                Console.WriteLine();
                int choice = MainMenu();
                switch (choice)
                {
                    case 1:
                        ProgAddCar(ProgramGarage); break;
                    case 2:
                        ProgramGarage.SellCar(); break;
                    case 3:
                        ProgramGarage.DeleteCar(); break;
                    case 4:
                        ProgramGarage.DecreaseCost(); break;
                    case 5:
                        ProgramGarage.DisplayNotCheap(); break;
                    case 6:
                        ProgramGarage.DisplayCheap(); break;
                    case 7:
                        ProgramGarage.DisplayAvailable();break;
                    case 8:
                        ProgramGarage.DisplayAll(); break;
                    case 9:
                        ProgramGarage.WriteData("garageList.txt");
                        exit = true; break;
                    default:
                        Console.WriteLine("Invalid selection try again."); break;
                }
            }
            Console.WriteLine("Press Enter to close program");

        }
        static int MainMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add a car");
            Console.WriteLine("2. Sell a car");
            Console.WriteLine("3. Delete a car");
            Console.WriteLine("4. Decrease the price of a car");
            Console.WriteLine("5. Display registration number and price of cars below R 50 000");
            Console.WriteLine("6. Display registration number and price of cars above R 50 000");
            Console.WriteLine("7. Display registration number and price of all available cars");
            Console.WriteLine("8. Display all the fields for all cars");
            Console.WriteLine("9. Save data and Exit");
            Console.WriteLine();
            Console.Write("Enter your choice: ");
            int ans = Convert.ToInt32(Console.ReadLine());
            return ans;
        }
        static void ProgAddCar(Arraylist ProgramGarage)
        {
            Console.WriteLine("Enter these details:");

            Console.Write("Registration Number: ");
            string registrationNumber = Console.ReadLine();

            Console.Write("Model Name: ");
            string modelName = Console.ReadLine();

            Console.Write("Year: ");
            int year = Convert.ToInt32(Console.ReadLine());

            Console.Write("Colour: ");
            string colour = Console.ReadLine();

            Console.Write("Price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Status: ");
            string status = Console.ReadLine().ToLower();

            Cars car = new(registrationNumber.ToUpper(), modelName, year, colour, price, status);
            ProgramGarage.AddToList(car);
            Console.WriteLine("Car successfully added");

        }

    }
}