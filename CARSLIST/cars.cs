namespace CARSLIST
{
    internal class Cars
    {
        string registrationNumber;
        string modelName;
        int year;
        string colour;
        double price;
        string status;

        public Cars(string RegNumber, string modelName, int year, string color, double price, string status)
        {
            this.registrationNumber = RegNumber;
            this.modelName = modelName;
            this.year = year;
            this.colour = color;
            this.price = price;
            this.status = status;

        }
        public string GetRegistration() { return registrationNumber; }
        public string GetModelName() { return modelName; }
        public int GetYear() { return year; }
        public string GetColour() { return colour; }
        public double GetPrice() { return price; }
        public string GetStatus() { return status; }
        public void SetStatus(string status) { this.status = status;}
        public bool IsCheap()
        {
            if (price < 50000)
                return true;
            else
                return false;

        }
        public void DecreasePrice(double amount) { price = price - amount; }
        public void DisplayCar()
        {
            Console.Write("Registration Number is " + registrationNumber);
            Console.WriteLine(" price is {0:C}", price);
        }
        public void DisplayDetailCar()
        {
            Console.Write("Registration Number: " + registrationNumber);
            Console.Write(" Model Name: " + modelName);
            Console.Write(" Year: " + year);
            Console.Write(" Colour: " + colour);
            Console.Write(" Price: {0:C}", price);
            Console.WriteLine(" Status: " + status);
        }

    }
}
