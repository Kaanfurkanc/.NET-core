using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculators
{
    public class Calculator : IEnumerable<object[]>
    {
        public int SumArray(int[] array)
        {
            int sum = 0;
            foreach (int i in array)
            {
                sum += i;
            }
            return sum;
        }
        public int Sum(int number1, int number2)
            => number1 + number2;
        public int Subtract(int number1, int number2)
            => number1 - number2;
        public int Multiply(int number1, int number2)
            => number1 * number2;
        public int Divide(int number1, int number2)
            => number1 / number2;

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 2, 3 };
            yield return new object[] { 11, 22, 33 };
            yield return new object[] { 5, 5, 10 };
            yield return new object[] { -8, 1, -7 };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
