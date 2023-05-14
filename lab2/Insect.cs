using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class Insect
    {
        //   'znak' będzie reprezentował pozycję biedronki i mszyc na planszy w tablicy stringów
        public string znak;
        //   'rozmiar' ułatwia zaprogramowanie ruchu, ponieważ przypisuję mu maksymalny indeks tablicy
        //   dzięki czemu stanowi "granicę planszy"
        protected int rozmiar;
        //   pozycję stworzyłem jako krotkę typu (int, int)
        //   jak dla mnie ułatwiło mi to odnoszenie się do pozycji gracza i wrogów
        public (int x, int y) position;
        public Insect() { }


        //   metoda, którą dziedziczą biedronka i mszyce
        public virtual void Move(ConsoleKey key) { }

    }
}
