﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using YAGO.FantasyWorld.Application.WeatherForecastService;
using YAGO.FantasyWorld.Domain.WeatherForecast;
using YAGO.FantasyWorld.Host.Models;

namespace YAGO.FantasyWorld.Host.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly WeatherForecastService _weatherForecastService;

		public WeatherForecastController(WeatherForecastService weatherForecastService)
		{
			_weatherForecastService = weatherForecastService;
		}

		[HttpGet]
		public async Task<IEnumerable<WeatherForecastApi>> Get(CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			var weatherForecasts = await _weatherForecastService.GetWeatherForecastList(cancellationToken);
			return weatherForecasts
				.Select(w => ToApi(w));
		}

		private static WeatherForecastApi ToApi(WeatherForecast weatherForecast)
		{
			return new WeatherForecastApi
			(
				weatherForecast.Date,
				weatherForecast.Temperature,
				weatherForecast.Summary
			);
		}
	}
}
