namespace Cafe;

public class Program
{
    static void Main(String[] args)
    {
        bool isOpen = true;

        Table[] tables = { new Table(1, 4), new Table(2, 8), new Table(3, 10) };

        while (isOpen)
        {
            Console.WriteLine("Administration cafe \n");

            for (int i = 0; i < tables.Length; i++)
            {
                tables[i].ShowInfo();
            }

            Console.Write("Enter number of table: ");
            int wishTable = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Write("Enter number of places for reservation: ");
            int reservationPlaces = Convert.ToInt32(Console.ReadLine());

            bool isReservationCompleted = tables[wishTable].Reserve(reservationPlaces);
            if (isReservationCompleted)
            {
                Console.WriteLine("Reservation success!");
            }
            else
            {
                Console.WriteLine("Reservation failed, not enough places!");
            }

            Console.ReadKey();
            Console.Clear();
        }
    }

    class Table
    {
        public int Number;
        public int MaxPlaces;
        public int FreePlaces;

        public Table(int number, int maxPlaces)
        {
            Number = number;
            MaxPlaces = maxPlaces;
            FreePlaces = maxPlaces;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Table: {Number} Free: {FreePlaces} Places: {MaxPlaces}");
        }

        public bool Reserve(int places)
        {
            if (FreePlaces >= places)
            {
                FreePlaces -= places;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}