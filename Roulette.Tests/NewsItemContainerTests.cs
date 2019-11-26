using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Roulette.News;
using DataAccesFactory;

namespace Roulette.Tests
{
    public class NewsItemContainerTests
    {
        NewsItemContainer container;
        NewsItem newsItem;
        NewsItem emptyNewItem;

        public NewsItemContainerTests()
        {
            container = new NewsItemContainer(TestFactory.CreateTestNewsItemContainerDAL());
            newsItem = new NewsItem("Special deal", TestFactory.CreateTestNewsItemDAL());
        }

        [Fact]
        public void AddNewsItem_ShouldWork()
        {
            // Arrange
            int expected = 1;

            // Act
            container.AddNewsItem(newsItem);
            int result = container.NewsItems.Count;

            // Assert
            Assert.Equal(expected, result);
            Assert.Equal(newsItem, container.NewsItems[0]);
        }

        [Fact]
        public void AddNewsItem_ShouldNotAddEmptyClassToList()
        {
            // Arrange
            int expected = 0;

            // Act
            container.AddNewsItem(emptyNewItem);
            int result = container.NewsItems.Count;

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void AddNewsItem_ShouldAddWithDuplicateName()
        {
            // Arrange
            int expected = 2;
            container.AddNewsItem(newsItem);

            // Act
            container.AddNewsItem(new NewsItem("Special deal", null));
            int result = container.NewsItems.Count;

            // Assert
            Assert.Equal(expected, result);
            Assert.Equal(newsItem, container.NewsItems[0]);
        }

        [Fact]
        public void RemoveNewsItem_ShouldWorkWithOneEntry()
        {
            // Arrange
            int expected = 0;
            container.AddNewsItem(newsItem);

            // Act
            container.RemoveNewsItem(newsItem);
            int result = container.NewsItems.Count;

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void RemoveNewsItem_ShouldWorkWithMultipleEntries()
        {
            // Arrange
            int expected = 1;
            container.AddNewsItem(newsItem);
            container.AddNewsItem(new NewsItem("Live Roulette", null));

            // Act
            container.RemoveNewsItem(newsItem);
            int result = container.NewsItems.Count;

            // Assert
            Assert.Equal(expected, result);
            Assert.Equal("Live Roulette", container.NewsItems[0].Title);
        }

        [Fact]
        public void RemoveNewsItem_ShouldDoNothingWithEmptyClass()
        {
            // Arrange
            int expected = 1;
            container.AddNewsItem(newsItem);


            // Act
            container.RemoveNewsItem(emptyNewItem);
            int result = container.NewsItems.Count;

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetAllNewsItems_ShouldWork()
        {
            // Arrange            
            var expected = TestDB.ReturnNewsTable();
            int countExpected = expected.Count;

            // Act
            var result = container.GetAll();
            int countResult = result.Count;

            // Assert
            Assert.Equal(countExpected, countResult);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i].Id, result[i].Id);
                Assert.Equal(expected[i].Title, result[i].Title);
                Assert.Equal(expected[i].Description, result[i].Description);
                Assert.Equal(expected[i].date, result[i].date);
            }
        }
    }
}
