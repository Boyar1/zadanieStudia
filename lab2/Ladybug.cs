using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class Ladybug : Insect
    {
        private int energia;

        public Ladybug(int n) 
        {
            //  'energia' jako pozostała ilość ruchów gracza
            //  'rozmiar' dziedziczony po klasie 'Insect' jest pomocą przy programowaniu wykonywania ruchów przez gracza
            //  'znak' dziedziczony po klasie 'Insect',
            //  'position' dziedziczony po klasie 'Insect', losowana w konstuktorze początkowa pozycja owada
            Random rg = new Random();
            rozmiar = n-1;
            energia = n;
            znak = "#";
            position = (rg.Next(n), rg.Next(n));
            //  randomowa pozycja od 0 do (n-1} 
        }

        //   nadpisanie dziedziczonej metody z klasy 'Insect'
        override public void Move(ConsoleKey key)
        {

            //  wykonywanie ruchu poprzez wciskanie klawiszy WSAD
            //  i sprawdzenie czy gracz nie wyjdzie poza rozmiar tablicy z planszą
            //  UWAGA! jeśli gracz spróbuje wyjść poza planszę
            //  TO WTEDY: energia nie zostanie zużyta, mszyce się przemieszczą, gracz pozostanie w miejscu
            if (key == ConsoleKey.W && position.x != 0)
            {
                energia--;
                position = (position.x-1, position.y);
            }
            else if (key == ConsoleKey.S && position.x != rozmiar)
            {
                energia--;
                position = (position.x + 1, position.y);
            }
            else if (key == ConsoleKey.A && position.y != 0)
            {
                energia--;
                position = (position.x, position.y-1);
            }
            else if (key == ConsoleKey.D && position.y != rozmiar)
            {
                energia--;
                position = (position.x, position.y+1);
            }
        }


        //   'int energia' została stworzona jako 'private', więc trzeba było getter i setter do niej dopisać
        public int GetEnergy()
        {
            return energia;
        }

        public void SetEnergy(int energy)
        {
            this.energia = energy;
        }
    }
}
