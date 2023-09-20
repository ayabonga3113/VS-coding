namespace CARSLIST
{
    internal class Arraylist
    {
        const int Size = 10;
        Cars[] Garage = new Cars[Size];
        int count = 0;
        public Arraylist()
        {
            Garage = new Cars[Size];
            ReadData();
        }
        public int ReturnCount() { return count; }
        public void ReadData()
        {
            string input;
            const char DELIM = ',';
            StreamReader SR = new("carData.txt");
            input = SR.ReadLine();
            while (input != null)
            {
                string[] info = input.Split(DELIM);
                string regNo = info[0];
                string ModName = info[1];
                int year = Convert.ToInt32(info[2]);
                string color = info[3];
                double price = Convert.ToDouble(info[4]);
                string status = info[5].ToLower();
                Cars OneCar = new(regNo, ModName, year, color, price, status);
                AddToList(OneCar);
                input = SR.ReadLine();
            }
            SR.Close();

        }
        public void AddToList(Cars NewCars)
        {
            Garage[count] = NewCars;
            count++;
        }
        public void DisplayAvailable()
        {
            Console.WriteLine("Available Cars :");
            foreach (Cars cars in Garage)
            {
                if ((cars != null) && cars.GetStatus() == "available")
                {
                    cars.DisplayCar();
                }
            }
        }
        public void DisplayAll()
        {
            Console.WriteLine();
            Console.WriteLine("All Cars :");
            for (int i = 0; i < count; i++)
            { Garage[i].DisplayDetailCar(); }
        }
        public void WriteData(string filepath)
        {
            StreamWriter WR = new(filepath);
            for (int x = 0; x < count; x++)
            {
                Cars Car = Garage[x];
                string output = Car.GetRegistration() + "," + Car.GetModelName() + "," +
                                Car.GetYear() + "," + Car.GetColour() + "," +
                                Car.GetPrice() + "," + Car.GetStatus();
                WR.WriteLine(output);
            }
            WR.Close();
            Console.WriteLine("Data written to file successfully!");

        }
        public void DeleteCar()
        {
            int pos = Find();
            if (pos >= 0)
            {
                for (int x = pos; x <= count - 2; x++)
                {
                    Garage[x] = Garage[x++];
                }
                count--;
            }
            else Console.WriteLine("failed to delete");
        }//<==verify delete method
        int Find()
        {
            Console.Write("Enter registration number of car you want: ");
            string wanted = Console.ReadLine();
            int pos = -1;
            wanted = wanted.ToUpper();
            ;for (int x = 0; x < count; x++)
            {
                if (wanted == Garage[x].GetRegistration())
                { pos = x;
                    return pos;
                }
                else
                {
                    Console.WriteLine("car is not found" );
                   
                }
            }
            return pos;
        }
        int LinearSearch(string wanted)
        {
            for (int x = 0; x < count; x++)
            { if (wanted.Equals(Garage[x].GetRegistration())) return x; }
            return -1;


        }
        public void GetCar(int want)
        {
            if (want != -1)
            {
                Garage[want].DisplayDetailCar();
            }
        }//<== NB revise
        public void DisplayNotCheap()
        {
            foreach (Cars cars in Garage)
            {
                if ((cars != null) && cars.IsCheap())
                    cars.DisplayCar();

            }
        }
        public void DisplayCheap()
        {

            foreach (Cars cars in Garage)
            {
                if ((cars != null) && !cars.IsCheap())
                    cars.DisplayCar();

            }
        }
        public void SellCar()
        {
            int pos = Find();
            GetCar(pos);
            Console.WriteLine("Sell car? Y/N");
            string sale = Console.ReadLine();
            sale.ToUpper();
            if (sale == "Y")
            {
                string update = "sold";
                    Garage[pos].SetStatus(update); }
        }
        public void DecreaseCost()
        {
            int pos = Find();
            Console.Write("Enter amount to decrease by: ");
            double amount = Convert.ToDouble(Console.ReadLine());
            Garage[pos].DecreasePrice(amount);

        }
    }
}
