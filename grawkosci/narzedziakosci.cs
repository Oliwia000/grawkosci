using System;
using System.Collections.Generic;
namespace grawkosci
{
    public static class narzedziakosci
    {
        private static Random random = new Random();
        public static List<int> RzutKosci()
        {
            var kosci = new List<int>();
            for (int i = 0; i < 5; i++)
                kosci.Add(RzutJednaKoscia());  // dodaj rzut jednej kości
            return kosci;
        }
        public static int RzutJednaKoscia()
        {
            return random.Next(1, 7); // losuje liczbę od 1 do 6
        }
    }

}