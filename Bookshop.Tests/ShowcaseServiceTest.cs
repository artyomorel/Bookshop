using System;
using Bookshop.BussinesLogic.Services;
using Bookshop.Domain.Interface;
using Bookshop.Domain.Models;
using Moq;
using Xunit;

namespace Bookshop.Tests
{
    public class ShowcaseServiceTest
    {
        [Fact]
        public void AddShowcase__ShouldReturnTrue()
        {
            //arrange
            var expectedShowCase = new Showcase
            {
                Name = "name",
                TotalSize = 100,
                CreateTime = DateTime.Now
            };
            var showcaseRepositoryMock = new Mock<IShowcaseRepository>();

            showcaseRepositoryMock.Setup(x => x.Add(expectedShowCase)).Verifiable();
            //act
            var showcaseService = new ShowcaseService(showcaseRepositoryMock.Object);
            var result = showcaseService.Add(expectedShowCase);

            //Arrange
            showcaseRepositoryMock.VerifyAll();
            Assert.True(result);
        }
        
        [Fact]
        public void DeleteShowcase__ShouldReturnTrue()
        {
            //arrange
            var expectedId = 1;
            var expectedShowCase = new Showcase
            {
                Id = expectedId,
                Name = "name",
                TotalSize = 100,
                CreateTime = DateTime.Now
            };
            var showcaseRepositoryMock = new Mock<IShowcaseRepository>();

            showcaseRepositoryMock.Setup(x => x.Delete(expectedId)).Verifiable();
            showcaseRepositoryMock.Setup(x=>x.GetById(expectedId)).Returns(expectedShowCase);
            //act
            var showcaseService = new ShowcaseService(showcaseRepositoryMock.Object);
            var result = showcaseService.Delete(expectedId);

            //Arrange
            showcaseRepositoryMock.VerifyAll();
            Assert.True(result);
        }
        
        
        [Fact]
        public void DeleteShowcase__ShouldReturnFalse__NoExistShowace()
        {
            //arrange
            var expectedId = 1;
            var showcaseRepositoryMock = new Mock<IShowcaseRepository>();

            showcaseRepositoryMock.Setup(x => x.Delete(expectedId)).Verifiable();
            showcaseRepositoryMock.Setup(x=>x.GetById(expectedId)).Returns((Showcase)null);
            //act
            var showcaseService = new ShowcaseService(showcaseRepositoryMock.Object);
            var result = showcaseService.Delete(expectedId);

            //Arrange
            showcaseRepositoryMock.Verify(x=>x.GetById(expectedId),Times.Once);
            showcaseRepositoryMock.Verify(x=>x.Delete(expectedId),Times.Never);
            Assert.False(result);
        }
        
        
        [Fact]
        public void UpdateShowcase__ShouldReturnFalse__NoExistShowace()
        {
            //arrange
            var expectedShowCase = new Showcase
            {
                Id = 1,
                Name = "name",
                TotalSize = 100,
                CreateTime = DateTime.Now
            };
            var showcaseRepositoryMock = new Mock<IShowcaseRepository>();

            showcaseRepositoryMock.Setup(x => x.Update(expectedShowCase)).Verifiable();
            showcaseRepositoryMock.Setup(x=>x.GetById(expectedShowCase.Id)).Returns((Showcase)null);
            //act
            var showcaseService = new ShowcaseService(showcaseRepositoryMock.Object);
            var result = showcaseService.Update(expectedShowCase);

            //Arrange
            showcaseRepositoryMock.Verify(x=>x.GetById(expectedShowCase.Id),Times.Once);
            showcaseRepositoryMock.Verify(x=>x.Update(expectedShowCase),Times.Never);
            Assert.False(result);
        }
        
        
        [Fact]
        public void UpdateShowcase__ShouldReturnTrue()
        {
            //arrange
            var expectedShowCase = new Showcase
            {
                Id = 1,
                Name = "name",
                TotalSize = 100,
                CreateTime = DateTime.Now
            };
            var showcaseRepositoryMock = new Mock<IShowcaseRepository>();

            showcaseRepositoryMock.Setup(x => x.Update(expectedShowCase)).Verifiable();
            showcaseRepositoryMock.Setup(x=>x.GetById(expectedShowCase.Id)).Returns(expectedShowCase);
            //act
            var showcaseService = new ShowcaseService(showcaseRepositoryMock.Object);
            var result = showcaseService.Update(expectedShowCase);

            //Arrange
            showcaseRepositoryMock.VerifyAll();
            Assert.True(result);
        }
    }
}