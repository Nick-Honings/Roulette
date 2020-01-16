using Roulette.GameStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Roulette.Tests
{
    public class WheelTests
    {
        IWheel wheel;
        IGenerator generator;

        public WheelTests()
        {
            generator = new NumberGenerator();
            wheel = new Wheel(generator);
        }

        [Fact]
        public void Spin_ShouldReturnValidIPocket()
        {
            // Arrange

            // Act
            IPocket pocket = wheel.Spin();

            Assert.True((int)pocket.Number < 37);
            Assert.True(pocket.Even == this.IsNumberEven((int)pocket.Number));
        }

        private bool IsNumberEven(int number)
        {
            if(number % 2 == 0)
            {
                return true;
            }
            return false;
        }
    }
}
