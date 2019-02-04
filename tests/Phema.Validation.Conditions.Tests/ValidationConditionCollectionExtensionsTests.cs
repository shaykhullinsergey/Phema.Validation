using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Phema.Validation.Tests
{
	public class ValidationConditionCollectionExtensionsTests
	{
		private readonly IValidationContext validationContext;

		public ValidationConditionCollectionExtensionsTests()
		{
			validationContext = new ServiceCollection()
				.AddPhemaValidation(configuration =>
					configuration.AddComponent<TestModelValidationComponent>())
				.BuildServiceProvider()
				.GetRequiredService<IValidationContext>();
		}

		[Fact]
		public void IsEmpty()
		{
			var error = validationContext.When("key", Array.Empty<int>())
				.IsEmpty()
				.AddError<TestModelValidationComponent>(c => c.TestModelTemplate1);

			Assert.NotNull(error);
			Assert.Equal("key", error.Key);
			Assert.Equal("template1", error.Message);
		}

		[Fact]
		public void PropertyIsEmpty()
		{
			var (key, message) = validationContext.When("list", new List<int>())
				.IsEmpty()
				.AddError<TestModelValidationComponent>(c => c.TestModelTemplate1);

			Assert.Equal("list", key);
			Assert.Equal("template1", message);
		}

		[Fact]
		public void IsNotEmpty()
		{
			var (key, message) = validationContext.When("list", new[] { 1 })
				.IsNotEmpty()
				.AddError<TestModelValidationComponent>(c => c.TestModelTemplate1);

			Assert.Equal("list", key);
			Assert.Equal("template1", message);
		}

		[Fact]
		public void PropertyIsNotEmpty()
		{
			var (key, message) = validationContext.When("list", new List<int> { 1 })
				.IsNotEmpty()
				.AddError<TestModelValidationComponent>(c => c.TestModelTemplate1);

			Assert.Equal("list", key);
			Assert.Equal("template1", message);
		}

		[Fact]
		public void HasCount()
		{
			var (key, message) = validationContext.When("list", new[] { 1 })
				.HasCount(1)
				.AddError<TestModelValidationComponent>(c => c.TestModelTemplate1);

			Assert.Equal("list", key);
			Assert.Equal("template1", message);
		}

		[Fact]
		public void PropertyHasCount()
		{
			var (key, message) = validationContext.When("list", new List<int> { 1 })
				.HasCount(1)
				.AddError<TestModelValidationComponent>(c => c.TestModelTemplate1);

			Assert.Equal("list", key);
			Assert.Equal("template1", message);
		}

		[Fact]
		public void NotHasCount()
		{
			var (key, message) = validationContext.When("list", new[] { 1 })
				.NotHasCount(2)
				.AddError<TestModelValidationComponent>(c => c.TestModelTemplate1);

			Assert.Equal("list", key);
			Assert.Equal("template1", message);
		}

		[Fact]
		public void PropertyNotHasCount()
		{
			var (key, message) = validationContext.When("list", new List<int> { 1 })
				.NotHasCount(2)
				.AddError<TestModelValidationComponent>(c => c.TestModelTemplate1);
			

			Assert.Equal("list", key);
			Assert.Equal("template1", message);
		}

		[Fact]
		public void IsContains()
		{
			var (key, message) = validationContext.When("list", new[] { 1 })
				.IsContains(1)
				.AddError<TestModelValidationComponent>(c => c.TestModelTemplate1);

			Assert.Equal("list", key);
			Assert.Equal("template1", message);
		}

		[Fact]
		public void PropertyIsContains()
		{
			var (key, message) = validationContext.When("list", new List<int> { 1 })
				.IsContains(1)
				.AddError<TestModelValidationComponent>(c => c.TestModelTemplate1);

			Assert.Equal("list", key);
			Assert.Equal("template1", message);
		}

		[Fact]
		public void IsNotContains()
		{
			var (key, message) = validationContext.When("list", new[] { "item1" })
				.IsNotContains("item2")
				.AddError<TestModelValidationComponent>(c => c.TestModelTemplate1);

			Assert.Equal("list", key);
			Assert.Equal("template1", message);
		}

		[Fact]
		public void PropertyIsNotContains()
		{
			var (key, message) = validationContext.When("list", new List<int>())
				.IsNotContains(1)
				.AddError<TestModelValidationComponent>(c => c.TestModelTemplate1);

			Assert.Equal("list", key);
			Assert.Equal("template1", message);
		}
	}
}