﻿using Microsoft.Extensions.Logging;
using MovieFinder.Services;
using MovieFinder.View;
using MovieFinder.ViewModel;

namespace MovieFinder;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<SearchPage>();
		builder.Services.AddSingleton<BaseViewModel>();
		builder.Services.AddSingleton<MoviesService>();
		builder.Services.AddTransient<MovieDetailsPage>();
		builder.Services.AddTransient<MovieDetailsViewModel>();
		return builder.Build();
	}
}
