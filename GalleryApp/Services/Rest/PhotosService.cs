using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GalleryApp.Models;
using GalleryApp.Services.Rest.ApiDefinitions;
using GalleryApp.Services.Rest.Contracts;
using GalleryApp.Services.Rest.Models;
using Refit.Insane.PowerPack.Data;
using Refit.Insane.PowerPack.Services;

namespace GalleryApp.Services.Rest
{
    public class PhotosService : IPhotosService
    {
        private readonly IRestService _restService;

        public PhotosService(IRestService restService)
        {
            _restService = restService;
        }

        public async Task<Response<List<PhotoPresentation>>> GetPhotos(
            CancellationToken cancellationToken = default)
        {
            try
            {
                var result =
                    await _restService.Execute<IPhotosApi, List<Photo>>(api => api.GetPhotos(cancellationToken));

                if (result.IsSuccess)
                {
                    var documents = result.Results.Select(Mapper.Map<PhotoPresentation>).ToList();
                    return new Response<List<PhotoPresentation>>(documents);
                }

                return new Response<List<PhotoPresentation>>().AddErrorMessage(result.FormattedErrorMessages);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return new Response<List<PhotoPresentation>>().AddErrorMessage(e.Message);
            }
        }
    }
}