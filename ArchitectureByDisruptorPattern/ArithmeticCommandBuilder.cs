using System;

using ArchitectureByDisruptorPattern.ArithmeticCommands;

namespace ArchitectureByDisruptorPattern
{
	public class ArithmeticCommandBuilder
	{
		private ArithmeticOperationType _operationType;

		public ArithmeticCommandBuilder For(ArithmeticOperationType operationType)
		{
			_operationType = operationType;
			return this;
		}

		public IArithmeticOperationCommand Build()
		{
			return _operationType switch
			{
				ArithmeticOperationType.Diff => new DiffArithmeticOperationCommand(),
				ArithmeticOperationType.Sum => new SumArithmeticOperationCommand(),
				_ => throw new ArgumentException("Unknown operation type"),
			};
		}
	}
}
