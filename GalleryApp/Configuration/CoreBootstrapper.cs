using AutoMapper;
using GalleryApp.Models;
using GalleryApp.Services.Rest.Models;

namespace GalleryApp.Configuration
{
    public static class CoreBootstrapper
	{
	    private const string UnixStartTime = "01.01.1970";

        private static bool _initialized;

		public static void Init()
		{
			if (_initialized) return;
		    Mapper.Initialize(cfg =>
		    {
		        cfg.Advanced.AllowAdditiveTypeMapCreation = true;

		        cfg.CreateMap<Photo, PhotoPresentation>();
		    });

		    Mapper.AssertConfigurationIsValid();
		    _initialized = true;
        }
    }
}