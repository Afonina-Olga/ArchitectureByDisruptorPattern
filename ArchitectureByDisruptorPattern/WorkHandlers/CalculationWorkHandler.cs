using System;
using Disruptor;

namespace ArchitectureByDisruptorPattern.WorkHandlers
{
	/// <summary>
	/// The second disruptor's worker, implementing the business logic of the calculator
	/// </summary>
	public class CalculationWorkHandler : IWorkHandler<ArithmeticOperationEvent>
	{
		public void OnEvent(ArithmeticOperationEvent evt)
		{
			ExecutionMetrics.MeasureTime(() =>
			{
				var code = ArithmeticOperationResult.OperationNotFound;
				var result = "";

				if (evt.Command != null)
				{
					result = evt.Command.Execute(evt.Argument1, evt.Argument2).ToString();
					code = ArithmeticOperationResult.Success;
				}

				Console.WriteLine($"Operation Id: {evt.Id}, Code: {code}, Result: {result}");
			});
		}
	}
}
