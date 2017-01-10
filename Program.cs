using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Очередь
            var queue = new SafeQueue<int>();
            */

            var rand = new Random();
            var list = new List<int>();
            for (int i = 0; i < 100; ++i)
                list.Add(rand.Next(100));
            var sum = rand.Next(100);

            /*  Пары чисел  */
            var result = NumCollectionParser.GetPairSumDict(list, sum);
            foreach (var pair in result)
                Console.WriteLine("{0}\t+\t{1}\t=\t{2}", pair.Key, pair.Value, sum);
        }
    }
}
