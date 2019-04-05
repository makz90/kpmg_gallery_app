using System;
using System.Collections.Generic;
using System.Net.Http;
using Autofac;
using GalleryApp.Configuration.Api;
using GalleryApp.Configuration.Api.Attributes;
using GalleryApp.Configuration.Api.Handlers;
using GalleryApp.Configuration.Ioc.Contracts;
using GalleryApp.Services;
using GalleryApp.Services.Rest;
using GalleryApp.Services.Rest.Contracts;
using Refit.Insane.PowerPack.Configuration;
using Refit.Insane.PowerPack.Services;

namespace GalleryApp.Configuration.Ioc.Modules
{
	public class PortableDepenedenciesModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			builder.RegisterType<ViewAndViewModelResolver>().As<IViewAndViewModelResolver>().SingleInstance();

			builder.RegisterType<FormsNavigationService>().As<INavigationService>()
				.AsSelf().SingleInstance();

            builder.Register(context =>
            {
                var dict = new Dictionary<Type, DelegatingHandler>();
                dict.Add(typeof(DiagnosticsClientHandler), new DiagnosticsClientHandler());
                var restService = new RefitRestServiceRetryProxy(new RefitRestService(dict), ThisAssembly);
                BaseApiConfiguration.ApiUri = new Uri(Constants.BaseUrl);
                return restService;
            }).As<IRestService>()
                .SingleInstance();

            builder.RegisterType<PhotosService>().As<IPhotosService>();
		}
	}
}