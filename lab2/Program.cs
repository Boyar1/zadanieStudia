namespace lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //   podanie rozmiaru planszy przez użytkownika
            Console.WriteLine("Gracz może przemieszczać się tylko za pomocą klawiszy WSAD.");
            Console.Write("Jaki ma być rozmiar planszy AxA?\n A = ");
            int liczba = int.Parse(Console.ReadLine());

            //   utworzenie obiektu klasy Game i wywołanie funkcji rozpoczynającej grę
            Game g1 = new Game(liczba);
            g1.Graj();
           
        }
    }
}