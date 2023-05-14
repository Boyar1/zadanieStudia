using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    internal class Game
    {
        //   dwuwymiarowa tablica stringów która posłuży za planszę do gry
        private string[,] plansza;
        //   zmienna pomocnicza to przyszłych pętli 'for'
        private int rozmiar;
        
        //   konstruktor, któremu podawany jest rozmiar planszy przez użytkownika
        public Game(int n) 
        {
            this.rozmiar= n;
            this.plansza = new string[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    plansza[i, j] = "~";
        }

        //   metoda, która wyświetla planszę gry w konsoli. Przekazany jest też obiekt klasy Ladybug,
        //   aby móc wyświetlić energię pozostałą graczowi
        public void RysujPlansze(Ladybug gamer)
        {
            //   wyświetlenie energii nad planszą
            Console.WriteLine("Energia: " + gamer.GetEnergy());

            //   wyświetlenie planszy z aktualnym stanem gry
            for (int i = 0; i < rozmiar; i++)
            {
                for (int j = 0; j < rozmiar; j++)
                    Console.Write(plansza[i, j]);
                Console.WriteLine();
            }
        }
        
        //   aktualizacja planszy gry po każdym ruchu gracza
        public void UzupelnijPlansze(List<Aphid> enemies, Ladybug gamer)
        {
            //   napełnienie planszy pustymi polami
            for (int i = 0; i < rozmiar; i++)
                for (int j = 0; j < rozmiar; j++)
                    plansza[i, j] = "~";

            //   napełnienie planszy mszycami
            foreach (Aphid m in enemies)
            {
                plansza[m.position.x, m.position.y] = m.znak;
            }

            // wpisanie na planszę biedronke, nawet jeśli ta pozycja już jest zajęta przez mszycę
            // rozwiązanie tego wyjątku jest obsłużone w metodzie 'Graj()'
            plansza[gamer.position.x, gamer.position.y] = gamer.znak;
        }

        //   metoda, która uruchamia całą grę
        public void Graj() 
        {
            //   utworzenie obiektu gracza 
            Ladybug gracz= new Ladybug(rozmiar);

            //   utworzenie listy, która będzie przechowywać wszystkie żywe mszyce
            List<Aphid> mszyce = new List<Aphid>();

            //   utworzenie listy, która będzie pilnować, które mszyce zostały zjedzone
            List<int> n = new List<int>();

            //   licznik będzie potrzebny w pętlach foreach do ustalania, które mszyce zostały zjedzone
            int licznik;

            //   napełnienie listy taką ilością mszyc, równą rozmiarowi planszy
            for(int i=0; i<rozmiar; i++) 
            {
                mszyce.Add(new Aphid(rozmiar));
                n.Add(i);
            }

            //   sprawdzenie czy na początku gry którakolwiek z mszyc
            //   ma tę samą pozycję startową co biedronka
            licznik = 0;
            foreach(Aphid m in mszyce)
            {
                if (m.position == gracz.position)
                    n[licznik] = 1;
                licznik++;
            }
            //   jeśli jest taka mszyca, to ją program usuwa
            for (int i = 0; i < n.Count; i++)
                if (n[i] == 1)
                    mszyce.RemoveAt(i);


            //   TUTAJ ZACZYNA SIĘ ROZGRYWKA
            while (gracz.GetEnergy() > 0 && mszyce.Count > 0)
            {
                // wyświetlenie planszy z nowymi pozycjami gracza oraz wrogów
                Console.Clear();
                UzupelnijPlansze(mszyce, gracz);
                RysujPlansze(gracz);
                
                // ruch gracza 
                ConsoleKey k = Console.ReadKey(true).Key;                
                gracz.Move(k);

                ///// pożeranie mszyc jeśli znajdą się na tym samym polu przed i po swoim ruchu /////
                
                //   sprawdzanie pozycji mszyc po ruchu gracza, ale przed ruchem mszyc
                licznik = 0;
                foreach(Aphid m in mszyce)
                {
                    if (m.position == gracz.position)
                        n[licznik] =1;
                    licznik++;
                }

                //   usunięcie obiektów zjedzonych mszyc z listy oraz dodanie graczowi energii za nie
                for (int i = 0; i < n.Count; i++)
                {
                    if (n[i] == 1)
                    {
                        mszyce.RemoveAt(i);
                        n.RemoveAt(i);
                        gracz.SetEnergy(gracz.GetEnergy()+2);
                    }
                }
                
                //   ruch wszystkich mszyc pozostałych przy życiu
                foreach (Aphid m in mszyce)
                {
                    m.Move(k);
                }

                //   ponowne sprawdzanie pozycji mszyc względem gracza. Tym razem już po ruchu gracza ORAZ mszyc
                licznik = 0;
                foreach (Aphid m in mszyce)
                {
                    if (m.position == gracz.position)
                        n[licznik] = 1;
                    licznik++;
                }


                //   ponowne usunięcie obiektów zjedzonych mszyc z listy oraz dodanie graczowi energii za nie
                for (int i = 0; i < n.Count; i++)
                {
                    if (n[i] == 1)
                    {
                        mszyce.RemoveAt(i);
                        n.RemoveAt(i);
                        gracz.SetEnergy(gracz.GetEnergy() + 2);
                    }
                }


            }

            // endgame
            // ostatnie wyświetlenie planszy
            Console.Clear();
            UzupelnijPlansze(mszyce, gracz);
            RysujPlansze(gracz);
            //   komunikat o wygranej lub porażce
            if (gracz.GetEnergy()==0) 
                Console.WriteLine("PRZEGRAŁEŚ");
            else
                Console.WriteLine("WYGRAŁEŚ");
        }
    }
}
