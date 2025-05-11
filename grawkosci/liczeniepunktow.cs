using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grawkosci
{
    public static class liczeniepunktow
    {
        public static int ObliczPunkty(List<int> kosci)
        {
            var grupy = kosci.GroupBy(k => k).OrderByDescending(g => g.Count()).ThenByDescending(g => g.Key).ToList();
            var liczby = kosci.OrderBy(x => x).ToList();

            // Piątka
            if (grupy[0].Count() == 5)
                return 50;

            // Czwórka
            if (grupy[0].Count() == 4)
                return grupy[0].Key * 5 + SumaPozostalych(grupy, 4);

            // Full
            if ((liczby.SequenceEqual(new List<int> { 1, 2, 3, 4, 5 }) || liczby.SequenceEqual(new List<int> { 2, 3, 4, 5, 6 })))
                return 50;

            // Trójka + para
            if (grupy[0].Count() == 3 && grupy.Count > 1 && grupy[1].Count() == 2)
                return grupy[0].Key * 4 + grupy[1].Key * 3;

            // Trójka
            if (grupy[0].Count() == 3)
                return grupy[0].Key * 4 + SumaPozostalych(grupy, 3);

            // Dwie pary lub para
            if (grupy[0].Count() == 2)
                return grupy[0].Key * 3 + SumaPozostalych(grupy, 2);

            // Brak kombinacji
            return kosci.Sum();
        }

        private static int SumaPozostalych(List<IGrouping<int, int>> grupy, int ileDoPominiecia)
        {
            return grupy.Skip(1).SelectMany(g => g).Sum();
        }
    }
}