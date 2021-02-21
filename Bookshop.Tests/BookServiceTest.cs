using System;
using Bookshop.BussinesLogic.Exceptions;
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
            
            //Assert
            Assert.Throws<ValidateShowcase>(() => bookService.Add(expectedBook));
            bookRepositoryMock.Verify(x=>x.Add(expectedBook),Times.Never);
            showcaseRepositoryMock.VerifyAll();
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

            //Assert
            Assert.Throws<ValidateShowcase>(() => bookService.Add(expectedBook));
            bookRepositoryMock.Verify(x=>x.Add(expectedBook),Times.Never);
            showcaseRepositoryMock.Verify(x=>x.GetById(expectedBook.Id),Times.Once);
            showcaseRepositoryMock.Verify(x=>x.GetFreeSize(expectedBook.Id),Times.Never);
        }

        [Fact]
        public void DeleteBook__ShouldReturnTrue()
        {
            
            //Arrange
            var expectedId = 1;
            
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

            bookRepositoryMock.Setup(x => x.GetById(expectedId)).Returns(expectedBook).Verifiable();
            var bookService = new BookService(bookRepositoryMock.Object, showcaseRepositoryMock.Object);
            
            //Act

            var result = bookService.Delete(expectedId);
            
            
            //Assert
            bookRepositoryMock.VerifyAll();
            Assert.True(result);
        }
        
        [Fact]
        public void DeleteBook__ShouldReturnFalse__NotFoundBook()
        {
            
            //Arrange
            var expectedId = 1;
            

            
            var bookRepositoryMock = new Mock<IBookRepository>();
            var showcaseRepositoryMock = new Mock<IShowcaseRepository>();

            bookRepositoryMock.Setup(x => x.GetById(expectedId)).Returns((Book)null).Verifiable();
            var bookService = new BookService(bookRepositoryMock.Object, showcaseRepositoryMock.Object);
            
            //Act

            //Assert
            Assert.Throws<NotFoundException>(()=> bookService.Delete(expectedId));
            bookRepositoryMock.VerifyAll();
        }

        [Fact]
        public void UpdateBook_ShouldReturnTrue()
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

            bookRepositoryMock.Setup(x=>x.Update(expectedBook)).Verifiable();
            bookRepositoryMock.Setup(x => x.GetById(expectedBook.Id)).Returns(expectedBook);
            showcaseRepositoryMock.Setup(x => x.GetById(expectedBook.Id)).Returns(expectedShowcase).Verifiable();
            showcaseRepositoryMock.Setup(x => x.GetFreeSize(expectedBook.Id)).Returns(100).Verifiable();
            var bookService = new BookService(bookRepositoryMock.Object, showcaseRepositoryMock.Object);
            
            //Act

            var result = bookService.Update(expectedBook);
            
            
            //Assert
            // bookRepositoryMock.VerifyAll();
            // showcaseRepositoryMock.VerifyAll();
            Assert.True(result);
        }
        [Fact]
        public void UpdateBook_ShouldReturnFalse_NotFoundBook()
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

            bookRepositoryMock.Setup(x => x.GetById(expectedBook.Id)).Returns((Book)null).Verifiable();
            var bookService = new BookService(bookRepositoryMock.Object, showcaseRepositoryMock.Object);
            
            //Act
            
            
            
            //Assert
            Assert.Throws<NotFoundException>(()=> bookService.Update(expectedBook));
            bookRepositoryMock.VerifyAll();
        }
        
        
        [Fact]
        public void UpdateBook__ShouldReturnFalse_NotExistShowcase()
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
            
            bookRepositoryMock.Setup(x=>x.Update(expectedBook)).Verifiable();
            showcaseRepositoryMock.Setup(x => x.GetById(expectedBook.Id)).Returns((Showcase)null).Verifiable();
            showcaseRepositoryMock.Setup(x => x.GetFreeSize(expectedBook.Id)).Returns(100).Verifiable();
            //act
            
            var bookService = new BookService(bookRepositoryMock.Object,showcaseRepositoryMock.Object);

            //Assert
            Assert.Throws<NotFoundException>(() => bookService.Update(expectedBook));
            bookRepositoryMock.Verify(x=>x.Update(expectedBook),Times.Never);
            showcaseRepositoryMock.Verify(x=>x.GetById(expectedBook.Id),Times.Never);
            showcaseRepositoryMock.Verify(x=>x.GetFreeSize(expectedBook.Id),Times.Never);
        }
        
        [Fact]
        public void UpdateBook__ShouldReturnFalse_TooManySize()
        {
            //Arrange
            
            var expectedBook = new Book
            {
                Id = 1,
                Price = 5,
                Name = "Voyna i Mir",
                Size = 100,
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
            
            bookRepositoryMock.Setup(x=>x.Update(expectedBook)).Verifiable();
            bookRepositoryMock.Setup(x => x.GetById(expectedBook.Id)).Returns(expectedBook);
            showcaseRepositoryMock.Setup(x => x.GetById(expectedShowcase.Id)).Returns(expectedShowcase).Verifiable();
            showcaseRepositoryMock.Setup(x => x.GetFreeSize(expectedShowcase.Id)).Returns(10).Verifiable();
            //act
            
            var bookService = new BookService(bookRepositoryMock.Object,showcaseRepositoryMock.Object);

            //Assert
            Assert.Throws<ValidateShowcase>(() => bookService.Update(expectedBook));
            bookRepositoryMock.Verify(x=>x.Update(expectedBook),Times.Never);
            showcaseRepositoryMock.Verify(x=>x.GetById(expectedShowcase.Id),Times.Once);
        }
        
    }
}