using System;
using Bookshop.BussinesLogic.Services;
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
                Size = 10,
                ShowcaseId = 1
            };

            var expectedShowcase = new Showcase
            {
                Id = 1,
                TotalSize = 100,
                CreateTime = DateTime.Now.AddDays(-1),
            };
            
            var bookRepositoryMock = new Mock<IBookRepository>();
            var showcaseRepositoryMock = new Mock<IShowcaseRepository>();
            
            bookRepositoryMock.Setup(x=>x.Add(expectedBook)).Verifiable();
            showcaseRepositoryMock.Setup(x => x.GetById(expectedShowcase.Id)).Returns(expectedShowcase).Verifiable();
            showcaseRepositoryMock.Setup(x => x.GetFreeSize(expectedShowcase.Id)).Returns(50).Verifiable();
            //act
            
            var bookService = new BookService(bookRepositoryMock.Object,showcaseRepositoryMock.Object);
            var result = bookService.Add(expectedBook);
            
            //Assert
            bookRepositoryMock.VerifyAll();
            showcaseRepositoryMock.VerifyAll();
            Assert.True(result);
        }
        
        [Fact]
        public void AddBook__ShouldReturnFalse_TooManySize()
        {
            //Arrange
            
            var expectedBook = new Book
            {
                Id = 1,
                Price = 5,
                Name = "Voyna i Mir",
                Size = 10,
                ShowcaseId = 1
            };

            var expectedShowcase = new Showcase
            {
                Id = 1,
                TotalSize = 100,
                CreateTime = DateTime.Now.AddDays(-1),
            };
            
            var bookRepositoryMock = new Mock<IBookRepository>();
            var showcaseRepositoryMock = new Mock<IShowcaseRepository>();
            
            bookRepositoryMock.Setup(x=>x.Add(expectedBook)).Verifiable();
            showcaseRepositoryMock.Setup(x => x.GetById(expectedShowcase.Id)).Returns(expectedShowcase).Verifiable();
            showcaseRepositoryMock.Setup(x => x.GetFreeSize(expectedShowcase.Id)).Returns(5).Verifiable();
            //act
            
            var bookService = new BookService(bookRepositoryMock.Object,showcaseRepositoryMock.Object);
            var result = bookService.Add(expectedBook);
            
            //Assert
            bookRepositoryMock.Verify(x=>x.Add(expectedBook),Times.Never);
            showcaseRepositoryMock.VerifyAll();
            Assert.False(result);
        }

        [Fact]
        public void AddBook__ShouldReturnFalse_NotExistShowcase()
        {
            //Arrange
            
            var expectedBook = new Book
            {
                Id = 1,
                Price = 5,
                Name = "Voyna i Mir",
                Size = 10,
                ShowcaseId = 1
            };

            
            var bookRepositoryMock = new Mock<IBookRepository>();
            var showcaseRepositoryMock = new Mock<IShowcaseRepository>();
            
            bookRepositoryMock.Setup(x=>x.Add(expectedBook)).Verifiable();
            showcaseRepositoryMock.Setup(x => x.GetById(expectedBook.Id)).Returns((Showcase)null).Verifiable();
            showcaseRepositoryMock.Setup(x => x.GetFreeSize(expectedBook.Id)).Returns(100).Verifiable();
            //act
            
            var bookService = new BookService(bookRepositoryMock.Object,showcaseRepositoryMock.Object);
            var result = bookService.Add(expectedBook);
            
            //Assert
            bookRepositoryMock.Verify(x=>x.Add(expectedBook),Times.Never);
            showcaseRepositoryMock.Verify(x=>x.GetById(expectedBook.Id),Times.Once);
            showcaseRepositoryMock.Verify(x=>x.GetFreeSize(expectedBook.Id),Times.Never);
            Assert.False(result);
        }
    }
}