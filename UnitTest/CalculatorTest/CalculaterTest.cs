using Calculators;
using Xunit;

namespace CalculatorTest
{
    public class CalculaterTest
    {
        Calculator calculator;

        public CalculaterTest()
        {
            calculator = new Calculator();
        }


        [Fact]
        public void Sum_AddingTwoNumber_SummationTest()
        {
            // arrange region

            var number1 = 15;
            var number2 = 10;
            var expected = 25;

            // Act region
            var result = calculator.Sum(number1, number2);

            // Assert Region 

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(100,5,500)]
        [InlineData(4,0,0)]
        public void Multiply_TwoNumber_MultiplyTest(int number1, int number2, int expected)
        {

            var result = calculator.Multiply(number1, number2);

            Assert.Equal(expected, result);
        
        }

        // Skip following test method . 

        [Theory(Skip ="This test is not necessary for now")]
        [InlineData(new int[5] {1,2,3,4,5},15)]
        [InlineData(new int[10] {2,4,5,6,3,7,8,9,55,123}, 222)]
        public void SumArray_IntArray_ReturnInt(int[] numbers, int expected)
        {
            var result = calculator.SumArray(numbers);

            Assert.Equal(expected, result);
        }
        
        public static IEnumerable<object[]> datas => new List<object[]>
        {
            new object[]{12,4,3},
            new object[]{72,24,3},
            new object[]{55,5,11},
            new object[]{12,6,2}
        };

        [Theory]
        [MemberData(nameof(datas))]
        public void Divide_TwoNumbers_DivisionTest(int number1, int number2,int expected)
        {

            int result = calculator.Divide(number1, number2);

            Assert.Equal(expected, result);
        }


        [Theory]
        [ClassData(typeof(Calculator))]
        public void Sum_ClassData_ReturnIntSum(int number1, int number2,int expected)
        {
            int result = calculator.Sum(number1, number2);

            Assert.Equal(expected, result);

        }
    }
}