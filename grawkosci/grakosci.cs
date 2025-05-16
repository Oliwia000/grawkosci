using System;
using System.Collections.Generic;

namespace grawkosci
{
    public class grakosci
    {
        private List<int> kosciGracza1; //kości gracza 1
        private List<int> kosciGracza2;
        public void Start()
        {
            Console.WriteLine("Rozpoczynamy grę!\n");

            kosciGracza1 = narzedziakosci.RzutKosci();  // pierwszy rzut
            kosciGracza2 = narzedziakosci.RzutKosci();

            Console.WriteLine("Kości gracza 1: " + string.Join(", ", kosciGracza1));  //  join dzeli  'przerwa ,odziela, 'np ' ,', czy '- '
            Console.WriteLine("Kości gracza 2: " + string.Join(", ", kosciGracza2));

            kosciGracza1 = Przerzut(kosciGracza1, "Gracz 1");
            kosciGracza2 = Przerzut(kosciGracza2, "Gracz 2"); //przerzut wybranej kosci

            Console.WriteLine("Ostateczne kości gracza 1: " + string.Join(", ", kosciGracza1));
            Console.WriteLine("Ostateczne kości gracza 2: " + string.Join(", ", kosciGracza2));

            int punkty1 = liczeniepunktow.ObliczPunkty(kosciGracza1);
            int punkty2 = liczeniepunktow.ObliczPunkty(kosciGracza2);

            Console.WriteLine($"Gracz 1: {punkty1} punktów");
            Console.WriteLine($"Gracz 2: {punkty2} punktów");

            if (punkty1 > punkty2)
                Console.WriteLine("Wygrywa Gracz 1!");
            else if (punkty2 > punkty1)
                Console.WriteLine("Wygrywa Gracz 2!");
            else
                Console.WriteLine("Remis!");
        }
        private List<int> Przerzut(List<int> kosci, string gracz)
        {
            Console.WriteLine($"{gracz}, wpisz numery kości do przerzutu (np. 1,3) lub Enter, aby pominąć: "); // ptanie gracza, które kości chce przerzucić lub może pominąć

            string? input = Console.ReadLine();
            var nowaLista = new List<int>(kosci);

            if (!string.IsNullOrWhiteSpace(input)) // jeśli coś wpisano , dzielimy po' , '
            {
                var indeksy = input.Split(',');

                foreach (var indeks in indeksy)
                {
                    if (int.TryParse(indeks.Trim(), out int i) && i >= 1 && i <= 5) //(1–5), odejmujemy 1 bo lista zaczyna się od 0
                        nowaLista[i - 1] = narzedziakosci.RzutJednaKoscia(); // losujemy nową wartość
                }
            }

            return nowaLista;
        }
    }
}