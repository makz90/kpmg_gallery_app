using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GalleryApp.Configuration.Api.Attributes;
using GalleryApp.Services.Rest.Models;
using Refit;

namespace GalleryApp.Services.Rest.ApiDefinitions
{
    [AuthApiDefinition]
    public interface IPhotosApi
    {
        [Get("/photos")]
        Task<List<Photo>> GetPhotos(CancellationToken cancellationToken = default);
    }
}