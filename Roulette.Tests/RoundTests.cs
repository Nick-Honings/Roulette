using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Roulette.Tests
{
    public class RoundTests
    {
        Round round;
        Result expected;

        public RoundTests()
        {
            round = new Round(1);
            expected = new Result(Color.Black, 10);
        }

        [Fact]
        public void AddResult_ShouldWork()
        {
            // Act
            round.AddResult(expected);
            Result result = round.Result;

            //Assert
            Assert.Equal(expected, result);            
        }

        [Fact]
        public void AddResult_ShouldNotOverwriteResultProperty()
        {
            // Arrange
            round.AddResult(expected);

            // Act
            round.AddResult(new Result(Color.Red, 1));

            // Assert
            Assert.Equal(expected, round.Result);
        }

        [Fact]
        public void GetResult_ShouldReturnSameValue()
        {
            // Arrange
            round.AddResult(expected);


            // Act
            Result result = round.GetResult();

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
