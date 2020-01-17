using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Roulette.News;
using TestDataAccesFactory;
using TestDatabase.TestDatabase;

namespace Roulette.Tests
{
    public class NewsItemContainerTests
    {
        NewsItemContainer container;
        NewsItem newsItem;
        NewsItem emptyNewItem;
        InMemRepository repo;

        public NewsItemContainerTests()
        {
            repo = new InMemRepository();
            container = new NewsItemContainer(repo.CreateNewsItemContainerDAL(), repo.CreateNewsItemDAL());
            newsItem = new NewsItem("Special deal", repo.CreateNewsItemDAL());
        }

        [Fact]
        public void AddNewsItem_ShouldWork()
        {
            // Arrange
            int expected = TestDB.GetNewsTable().Count + 1;
            
            // Act
            bool validCall = container.AddNewsItem(newsItem);
            int result = container.NewsItems.Count;

            // Assert
            Assert.True(validCall);
            Assert.Equal(expected, result);            
        }

        [Fact]
        public void AddNewsItem_ShouldNotAddEmptyClassToList()
        {
            // Arrange
            int expected = TestDB.GetNewsTable().Count;

            // Act
            bool validCall = container.AddNewsItem(emptyNewItem);
            int result = container.NewsItems.Count;

            // Assert
            Assert.False(validCall);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void AddNewsItem_ShouldAddWithDuplicateName()
        {
            // Arrange
            int expected = TestDB.GetNewsTable().Count + 2;
            container.AddNewsItem(newsItem);

            // Act
            bool validCall = container.AddNewsItem(new NewsItem("Special deal", null));
            int result = container.NewsItems.Count;

            // Assert
            Assert.True(validCall);
            Assert.Equal(expected, result);            
        }

        [Fact]
        public void RemoveNewsItem_ShouldWorkWithOneEntry()
        {
            // Arrange
            var newsItems = TestDB.GetNewsTable();
            int expected = newsItems.Count - 1;
            var toRemove = (NewsItem)newsItems[0];

            // Act
            bool validCall = container.RemoveNewsItem(toRemove);
            int result = container.NewsItems.Count;

            // Assert
            Assert.True(validCall);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void RemoveNewsItem_ShouldWorkWithMultipleEntries()
        {
            // Arrange
            int expected = TestDB.GetNewsTable().Count + 1;
            container.AddNewsItem(newsItem);
            container.AddNewsItem(new NewsItem("Live Roulette", null));

            // Act
            bool validCall = container.RemoveNewsItem(newsItem);
            int result = container.NewsItems.Count;

            // Assert
            Assert.True(validCall);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void RemoveNewsItem_ShouldDoNothingWithEmptyClass()
        {
            // Arrange
            int expected = TestDB.GetNewsTable().Count;                   

            // Act
            bool validCall = container.RemoveNewsItem(emptyNewItem);
            int result = container.NewsItems.Count;

            // Assert
            Assert.False(validCall);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetAllNewsItems_ShouldWork()
        {
            // Arrange
            var expected = TestDB.GetNewsTable();
            int expectedCount = expected.Count;

            // Act
            var result = container.GetAllNewsItems();
            int resultCount = result.Count;

            // Assert
            Assert.Equal(expectedCount, resultCount);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i].Id, result[i].Id);
                Assert.Equal(expected[i].Title, result[i].Title);
                Assert.Equal(expected[i].Description, result[i].Description);
                Assert.Equal(expected[i].PostDate, result[i].PostDate);
            }
        }
    }
}
