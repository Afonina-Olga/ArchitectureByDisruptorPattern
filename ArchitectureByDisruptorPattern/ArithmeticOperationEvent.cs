using ArchitectureByDisruptorPattern.ArithmeticCommands;

namespace ArchitectureByDisruptorPattern
{
	public class ArithmeticOperationEvent
	{
		/// <summary>
		/// Operation Id
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// First argument from command
		/// </summary>
		public int Argument1 { get; set; }

		/// <summary>
		/// Second argument from command
		/// </summary>
		public int Argument2 { get; set; }

		/// <summary>
		/// Arithmetic command
		/// </summary>
		public IArithmeticOperationCommand Command { get; set; }

		/// <summary>
		/// Set values
		/// </summary>
		/// <param name="id">Id</param>
		/// <param name="argument1">Argument1</param>
		/// <param name="argument2">Argument2</param>
		/// <param name="command">Arithmetic command</param>
		public void SetValues(int id, int argument1, int argument2, IArithmeticOperationCommand command)
		{
			Id = id;
			Argument1 = argument1;
			Argument2 = argument2;
			Command = command;
		}
	}
}
