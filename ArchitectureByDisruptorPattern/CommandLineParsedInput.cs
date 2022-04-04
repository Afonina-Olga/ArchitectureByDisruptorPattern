namespace ArchitectureByDisruptorPattern
{
	/// <summary>
	/// Class for parsed command values from command line
	/// </summary>
	public class CommandLineParsedInput
	{
		/// <summary>
		/// Operation id
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Operation type
		/// </summary>
		public ArithmeticOperationType OperationType { get; set; }

		/// <summary>
		/// Fiirst argumnet
		/// </summary>
		public int Argument1 { get; set; }

		/// <summary>
		/// Second argument
		/// </summary>
		public int Argument2 { get; set; }

		public CommandLineParsedInput(int id, ArithmeticOperationType operationType, int argument1, int argument2)
		{
			Id = id;
			OperationType = operationType;
			Argument1 = argument1;
			Argument2 = argument2;
		}
	}
}
