namespace ArchitectureByDisruptorPattern.ArithmeticCommands
{
	public interface IArithmeticOperationCommand
	{
		int Execute(int argument1, int argument2);
	}
}
