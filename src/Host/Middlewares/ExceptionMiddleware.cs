﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace YAGO.FantasyWorld.Host.Middlewares
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<ExceptionMiddleware> _logger;

		public ExceptionMiddleware(RequestDelegate next,
			ILogger<ExceptionMiddleware> logger)
		{
			_next = next;
			_logger = logger;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next.Invoke(context);
			}
			catch (Domain.Exceptions.ApplicationException ex)
			{
				_logger.LogInformation(ex.Message, ex);
				context.Response.StatusCode = ex.ErrorCode;
				context.Response.ContentType = "application/json";
				await context.Response.WriteAsync(ex.Message);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message, ex);
				context.Response.StatusCode = 500;
				context.Response.ContentType = "application/json";
				await context.Response.WriteAsync("Неизвестная ошибка.");
			}
		}
	}
}
