using Bookshop.Domain.Interface;
using Bookshop.Domain.Models;
using Moq;
using Xunit;

namespace Bookshop.Tests
{
    public class BookServiceTest
    {
        [Fact]
        public void AddBook__ShouldReturnTrue()
        {
            //Arrange
            
            var expectedBook = new Book
            {
                Id = 1,
                Price = 5,
                Name = "Voyna i Mir",
                Size = 10
            };
            var bookRepositoryMock = new Mock<IBookRepository>();
            bookRepositoryMock.Setup(x=>x.Add(expectedBook)).Verifiable();
            
            //act
            
            var bookService = new BookService(bookRepositoryMock.Object);
            var result = bookService.Add(expectedBook);
            
            //Assert
            
            bookRepositoryMock.VerifyAll();
            Assert.True(result);
        }
    }
}