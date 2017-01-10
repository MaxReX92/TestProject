using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TestProject
{
    public class NumCollectionParser
    {       
        /// <summary>
        /// Получить пары чисел из коллекции, которые в сумме равны переданному значению
        /// </summary>
        /// <param name="nums">Коллекция</param>
        /// <param name="sum">Значение суммы</param>
        public static Dictionary<int, int> GetPairSumDict(ICollection<int> nums, int sum)
        {
            var resultDict = new Dictionary<int, int>();
            var list = nums.ToList();
            list.Sort();
            var startIndex = 0;
            var endIndex = list.Count - 1;

            while (startIndex < endIndex)
            {
                var first = list[startIndex];
                var last = list[endIndex];
                var s = first + last;
                if (s == sum)
                {
                    if (!resultDict.ContainsKey(first))
                        resultDict.Add(first, last);
                    startIndex++;
                    endIndex--;
                }
                else
                {
                    if (s < sum)
                        startIndex++;
                    else
                        endIndex--;
                }
            }

            return resultDict;
        }
    }
}
