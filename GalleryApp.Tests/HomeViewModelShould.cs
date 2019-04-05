using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalleryApp.Models;
using GalleryApp.Services.Rest.Contracts;
using GalleryApp.ViewModels;
using Moq;
using NUnit.Framework;

namespace GalleryApp.Tests
{
    [TestFixture]
    public class HomeViewModelShould
    {
        private PhotoPresentation _photo;

        [SetUp]
        public void Setup()
        {
            _photo = new PhotoPresentation
            {
                Url = "https://test.com/example"
            };
        }
        
        [Test]
        public void load_photos_from_service()
        {
            //Arrange
            var mockUserService = new Mock<IPhotosService>();
            var responseList = new List<PhotoPresentation> { _photo };
            var response = new Refit.Insane.PowerPack.Data.Response<List<PhotoPresentation>>(responseList);
            mockUserService.Setup(x => x.GetPhotos(default)).Returns(() => Task.FromResult(response));

            //Act
            var homeViewModel = new HomeViewModel(mockUserService.Object);
            homeViewModel.Prepare(string.Empty);
            var output = homeViewModel.PhotosCollection.FirstOrDefault(p => p.Id == _photo.Id);
            
            //Assert
            Assert.NotNull(output);
            Assert.AreEqual(output.Url, _photo.Url);
            mockUserService.VerifyAll();
        }
    }
}
