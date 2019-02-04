using Microsoft.Extensions.DependencyInjection;

namespace Phema.Validation
{
	public static class ValidationConfigurationExtensions
	{
		/// <summary>
		/// Позволяет зарегистрировать <see cref="IValidation{TModel}"/>, содержащий логику валидации <see cref="TModel"/>
		/// </summary>
		/// <typeparam name="TModel"></typeparam>
		/// <typeparam name="TValidation"></typeparam>
		/// <returns></returns>
		public static IValidationConfiguration AddValidation<TModel, TValidation>(
			this IValidationConfiguration configuration)
				where TValidation : class, IValidation<TModel>
		{
			configuration.Services.AddScoped<IValidation<TModel>, TValidation>();
			return configuration;
		}
		
		/// <summary>
		/// Расширяет функционал <see cref="IValidationConfiguration"/>, добавляя возможность типизировать модель и валидацию для этой модели
		/// </summary>
		/// <param name="configuration"></param>
		/// <typeparam name="TModel"></typeparam>
		/// <typeparam name="TValidation"></typeparam>
		/// <typeparam name="TComponent"></typeparam>
		/// <returns></returns>
		public static IValidationConfiguration AddValidationComponent<TModel, TValidation, TComponent>(
			this IValidationConfiguration configuration)
				where TValidation : class, IValidation<TModel>
				where TComponent : class, IValidationComponent<TModel, TValidation>
		{
			return configuration.AddComponent<TModel, TComponent>()
				.AddValidation<TModel, TValidation>();
		}
	}
}