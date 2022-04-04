using NUnit.Framework;
using System.Collections.Generic;

namespace ArchitectureByDisruptorPattern.Tests
{
	public class CommandLineOptionsTests
	{
		[Test]
		public void TryParse_InputIsValid_ReturnValuesCollection()
		{
			// Arrange
			var arguments = new string[] { "1,Sum,1,2", "2,Diff,5,4", "3,Mult,2,3" };

			// Act
			var result = TryParseCommandLineArguments(arguments);

			// Assert
			Assert.IsTrue(result);
		}

		[Test]
		public void TryParse_InvalidFormatCommand_ReturnFalse()
		{
			// Arrange
			var arguments = new string[] { "absd", "2,Diff,5,4", "3,Mult,2,3" };

			// Act
			var result = TryParseCommandLineArguments(arguments);

			// Assert
			Assert.IsFalse(result);
		}

		[Test]
		public void TryParse_WrongCommandNameWithCorrectFormat_ReturnValuesCollection()
		{
			// Arrange
			var arguments = new string[] { "1,Add,5,4", "2,Remove,5,4", "3,Substract,2,3" };

			// Act
			var result = TryParseCommandLineArguments(arguments);

			// Assert
			Assert.IsTrue(result);
		}

		[Test]
		public void TryParse_WrongNumberOfArguments_ReturnFalse()
		{
			// Arrange
			var arguments = new string[] { "1,Add,5,4", "2,Remove,5,4" };

			// Act
			var result = TryParseCommandLineArguments(arguments);

			// Assert
			Assert.IsFalse(result);
		}

		[Test]
		public void TryParse_WrongNumberOfCommandArguments_ReturnFalse()
		{
			// Arrange
			var arguments = new string[] { "1,Sum,5,4", "2,Diff,5,4", "3,Mult5,4" };

			// Act
			var result = TryParseCommandLineArguments(arguments);

			// Assert
			Assert.IsFalse(result);
		}

		private bool TryParseCommandLineArguments(string[] arguments)
		{
			return CommandLineOptions.TryParse(arguments, out List<CommandLineParsedInput> parsedInput);
		}
	}
}