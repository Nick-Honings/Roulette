using Roulette;
using Roulette.Bets;
using Roulette.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TestDataAccesFactory;
using Xunit;

namespace LogicDALIntegration.Tests
{
    public class BetTests
    {
        MySqlRepository repo;

        public BetTests()
        {
            repo = new MySqlRepository("TestDatabase");
        }


        [Fact]
        public void PlaceBet_ShouldWork()
        {
            // Arrange
            User user = new User("Test", repo.CreateUserDAL(), repo.CreateBetDAL())
            {
                Id = 50
            };
            IBet bet = new ColorBet(InterfaceLayerBD.Bet.IPocketColor.Black)
            {
                Stake = 200
            };


            using (TransactionScope scope = new TransactionScope())
            {
                // Act
                bool validCall = user.MakeBet(bet);

                // Assert
                Assert.True(validCall);
                Assert.Equal(bet, user.CurrentBet);
            }
        }

        [Fact]
        public void PlaceBet_ShouldReturnFalse()
        {
            // Arrange
            User user = new User("Test", repo.CreateUserDAL(), repo.CreateBetDAL());
            IBet bet = new ColorBet(InterfaceLayerBD.Bet.IPocketColor.Black)
            {
                Stake = 200
            };

            
            using(TransactionScope scope = new TransactionScope())
            {
                // Act
                // No user id is specified, so this should return false.
                bool validCall = user.MakeBet(bet);

                // Assert
                Assert.False(validCall);
                Assert.NotEqual(bet, user.CurrentBet);
            }           
        }

        [Fact]
        public void PlaceBet_ShouldFillAllRequiredFieldsColor()
        {
            // Arrange
            User user = new User("Test", repo.CreateUserDAL(), repo.CreateBetDAL())
            {
                Id = 50
            };
            IBet bet = new ColorBet(InterfaceLayerBD.Bet.IPocketColor.Black)
            {
                Stake = 200
            };

            using(TransactionScope scope = new TransactionScope())
            {
                // Act
                user.MakeBet(bet);

                var savedBet = repo.CreateBetDAL().GetCurrentBet(user.Id);

                // Assert
                Assert.Equal(bet.Stake, savedBet.Stake);
                Assert.Equal(bet.Odd, savedBet.Odd);
                // Cast this to int because that's the value you would get from the database.
                Assert.Equal((int)bet.GetBetSpecificInfo()["Color"], savedBet.GetBetSpecificInfo()["Color"]);
            }
        }

        [Fact]
        public void PlaceBet_ShouldFillAllRequiredFieldsEven()
        {
            // Arrange
            User user = new User("Test", repo.CreateUserDAL(), repo.CreateBetDAL())
            {
                Id = 50
            };
            IBet bet = new EvenUnevenBet(true)
            {
                Stake = 200
            };

            using (TransactionScope scope = new TransactionScope())
            {
                // Act
                user.MakeBet(bet);

                var savedBet = repo.CreateBetDAL().GetCurrentBet(user.Id);

                // Assert
                Assert.Equal(bet.Stake, savedBet.Stake);
                Assert.Equal(bet.Odd, savedBet.Odd);
                // Cast this to int because that's the value you would get from the database.
                Assert.Equal(bet.GetBetSpecificInfo()["IsEven"], savedBet.GetBetSpecificInfo()["Even"]);
            }
        }

        [Fact]
        public void PlaceBet_ShouldFillAllRequiredFieldsSingle()
        {
            // Arrange
            User user = new User("Test", repo.CreateUserDAL(), repo.CreateBetDAL())
            {
                Id = 50
            };
            IBet bet = new SingleNumberBet(InterfaceLayerBD.Bet.IPocketNumber.Eight)
            {
                Stake = 200
            };

            using (TransactionScope scope = new TransactionScope())
            {
                // Act
                user.MakeBet(bet);

                var savedBet = repo.CreateBetDAL().GetCurrentBet(user.Id);

                // Assert
                Assert.Equal(bet.Stake, savedBet.Stake);
                Assert.Equal(bet.Odd, savedBet.Odd);
                // Cast this to int because that's the value you would get from the database.
                Assert.Equal(8, savedBet.GetBetSpecificInfo()["Number"]);
            }
        }

        [Fact]
        public void PlaceBet_ShouldFillAllRequiredFieldsNeighbours()
        {
            // Arrange
            User user = new User("Test", repo.CreateUserDAL(), repo.CreateBetDAL())
            {
                Id = 50
            };
            IBet bet = new NeighbourBet(InterfaceLayerBD.Bet.IPocketNumber.Eightteen, InterfaceLayerBD.Bet.IPocketNumber.Nineteen)
            {
                Stake = 200
            };

            using (TransactionScope scope = new TransactionScope())
            {
                // Act
                user.MakeBet(bet);

                var savedBet = repo.CreateBetDAL().GetCurrentBet(user.Id);

                // Assert
                Assert.Equal(bet.Stake, savedBet.Stake);
                Assert.Equal(bet.Odd, savedBet.Odd);
                // Cast this to int because that's the value you would get from the database.
                Assert.Equal(18, savedBet.GetBetSpecificInfo()["FirstNumber"]);
                Assert.Equal(19, savedBet.GetBetSpecificInfo()["LastNumber"]);
            }
        }
    }
}
