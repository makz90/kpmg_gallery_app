using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GalleryApp.Models;
using Refit.Insane.PowerPack.Data;

namespace GalleryApp.Services.Rest.Contracts
{
    public interface IPhotosService
    {
        Task<Response<List<PhotoPresentation>>> GetPhotos(
            CancellationToken cancellationToken = default);
    }
}