using System;
using System.Collections.Generic;

namespace ArchitectureByDisruptorPattern
{
	public class CommandLineOptions
	{
		/// <summary>
		/// Try parse command line arguments
		/// </summary>
		/// <param name="args">String array</param>
		/// <param name="arguments">List of parsed arguments</param>
		/// <returns>Parsed result</returns>
		public static bool TryParse(string[] args, out List<CommandLineParsedInput> arguments)
		{
			arguments = new List<CommandLineParsedInput>();

			if (args is not { Length: 3 })
				return false;

			foreach (var arg in args)
			{
				if (!TryParseCommand(arg, out CommandLineParsedInput commandLineInput))
					return false;
				else
					arguments.Add(commandLineInput);
			}
			
			return true;
		}

		/// <summary>
		/// Try parse single command
		/// </summary>
		/// <param name="command">String command from command line</param>
		/// <param name="convertedValues">Parsed values</param>
		/// <returns>Parsed result</returns>
		private static bool TryParseCommand(string command, out CommandLineParsedInput convertedValues)
		{
			var values = command.Split(',');
			convertedValues = null;

			if (values is { Length: 4 } &&
				int.TryParse(values[0], out int id) &&
				int.TryParse(values[2], out int arg1) &&
				int.TryParse(values[3], out int arg2))
			{
				if (!Enum.TryParse(values[1], out ArithmeticOperationType operationType))
					operationType = ArithmeticOperationType.Unknown;
				
				convertedValues = new CommandLineParsedInput(id, operationType, arg1, arg2);
				return true;
			}

			return false;
		}

		/// <summary>
		/// Display help info
		/// </summary>
		public static void PrintHelpInfo()
		{
			var output =
				@"Using the command line, it is possible to specify three arguments(for example: 
""1, Sum, 5, 3"" ""2, Diff, 5, 3"" ""3, Mult, 5, 3""), with comma-separated values
for each argument.
The first value is the operation ID.
The second value is the operation shorthand(Sum, Diff, Mult, … )
The third and fourth values are the operation arguments.
For example, if the input is ""1,Sum,5,3"" the calculator performs arithmetic
addition of 5 and 3(the operation identifier is 1).";

			Console.WriteLine(output);
		}
	}
}
