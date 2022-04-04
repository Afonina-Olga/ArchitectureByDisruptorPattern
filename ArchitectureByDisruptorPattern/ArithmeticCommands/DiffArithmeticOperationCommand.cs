﻿namespace ArchitectureByDisruptorPattern.ArithmeticCommands
{
	public class DiffArithmeticOperationCommand : IArithmeticOperationCommand
	{
		public int Execute(int argument1, int argument2)
		{
			return argument1 - argument2;
		}
	}
}
