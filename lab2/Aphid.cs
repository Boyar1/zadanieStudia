using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class Aphid : Insect
    {
        public Aphid(int n)
        {
            //  'rozmiar' dziedziczony po klasie 'Insect' jest pomocą przy programowaniu wykonywania ruchów przez gracza
            //  'znak' dziedziczony po klasie 'Insect'
            //  'position' dziedziczony po klasie 'Insect', losowana w konstuktorze początkowa pozycja owada
            Random rg = new Random();
            rozmiar= n-1;
            znak = "@";
            position = (rg.Next(n), rg.Next(n));
            //  randomowa pozycja od 0 do (n-1} 
        }

        //   nadpisanie dziedziczonej metody z klasy 'Insect'
        public override void Move(ConsoleKey key)
        {
            //   przy każdym wywoałniu metody Move() dla mszycy funkcją random wybierany jest kierunek ruchu
            //   możliwe jest 8 kierunków(geograficznie): N, E, S, W, NE, NW, SE, SW
            Random ruch = new Random();
            int gdzie = ruch.Next(8)+1;
            
            // w switchu każdy przypadek najpierw sprawdza czy ruch mszycy w danym kierunku jest możliwy
            // następnie jeśli jest możliwy, to pozycja mszycy jest zmieniana.
            // jeśli nie, to mszyca pozostaje w miejscu
            switch(gdzie)
            {
                case 1: if(position.x!=0) //   kierunek N
                            this.position = (position.x-1,position.y);
                        break;
                case 2: if (position.x != 0 && position.y != rozmiar) //   kierunek NE
                            this.position = (position.x-1, position.y+1);
                        break;
                case 3: if (position.y != rozmiar) //   kierunek E
                            this.position = (position.x, position.y+1);
                        break;
                case 4: if (position.x != rozmiar && position.y != rozmiar) //   kierunek SE
                            this.position = (position.x+1, position.y+1); 
                        break;
                case 5: if (position.x != rozmiar) //   kierunek S
                            this.position = (position.x+1, position.y); 
                        break;
                case 6: if (position.x != rozmiar && position.y != 0) //   kierunek SW
                            this.position = (position.x+1, position.y-1);
                        break;
                case 7: if (position.y != 0) //   kierunek W
                            this.position = (position.x, position.y-1); 
                        break;
                case 8: if (position.x != 0 && position.y != 0) //   kierunek NW
                            this.position = (position.x-1, position.y-1); 
                        break;
            }

        }
    }
}
