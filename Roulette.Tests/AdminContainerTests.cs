using Roulette.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataAccesFactory;
using TestDatabase.TestDatabase;
using Xunit;

namespace Roulette.Tests
{
    public class AdminContainerTests
    {
        AdminContainer container;
        InMemRepository repo;

        public AdminContainerTests()
        {
            repo = new InMemRepository();
            container = new AdminContainer(repo.CreateAdminContainerDAL(), repo.CreateAdminDAL());
        }

        [Fact]
        public void GetAllAdmins_ShouldWork()
        {
            // Arrange
            int expected = TestDB.GetAdminTable().Count;

            // Act
            var result = container.GetAllAdmins();
            int resultCount = result.Count;

            // Assert
            Assert.Equal(expected, resultCount);
        }

        [Fact]
        public void GetAllAdmins_ShouldWorkOnInitialisation()
        {
            // Arrange
            AdminContainer adminContainer = new AdminContainer(repo.CreateAdminContainerDAL(), repo.CreateAdminDAL());
            int expected = TestDB.GetAdminTable().Count;

            // Act
            int result = adminContainer.Admins.Count;

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetAllAdmins_ShouldAssignAllProperties()
        {
            // Arrange

            // Act
            var admins = container.GetAllAdmins();

            // Assert
            foreach (var a in admins)
            {
                Assert.True(a.Id != 0);
                Assert.NotNull(a.Name);
                Assert.NotNull(a.Permissions);
            }

        }

    }
}
