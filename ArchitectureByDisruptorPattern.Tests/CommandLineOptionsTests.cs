using NUnit.Framework;
using System.Collections.Generic;

namespace ArchitectureByDisruptorPattern.Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void TryParse_InputIsValid_ReturnValuesCollection()
		{
			// Arrange
			var arguments = new string[] { "1,Sum,1,2", "2,Diff,5,4", "3,Mult,2,3" };

			// Act
			var result = CommandLineOptions.TryParse(arguments, out List<CommandLineParsedInput> parsedInput);

			// Assert
			Assert.IsTrue(result);
		}
	}
}