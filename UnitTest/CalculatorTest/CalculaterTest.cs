using Calculators;

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
        [InlineData(100,5)]
        public void Multiply_TwoNumber_MultiplyTest(int number1, int number2)
        {
            int expected = 500;
        
            var resuult = calculator.Multiply(number1, number2);

            Assert.Equal(expected, resuult);
        
        }

        public static IEnumerable<object[]> datas => new List<object[]>
        {
            new object[]{12,4,3},
            new object[]{72,24,7},
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
    }
}