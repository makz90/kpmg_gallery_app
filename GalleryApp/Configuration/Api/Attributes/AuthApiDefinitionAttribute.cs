using GalleryApp.Configuration.Api.Handlers;
using Refit.Insane.PowerPack.Attributes;

namespace GalleryApp.Configuration.Api.Attributes
{
    public class AuthApiDefinitionAttribute : ApiDefinitionAttribute
    {
        public AuthApiDefinitionAttribute() : base(Constants.BaseUrl, 30, typeof(DiagnosticsClientHandler))
        {
        }
    }
}