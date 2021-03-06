using Disruptor.Dsl;

using ArchitectureByDisruptorPattern.ArithmeticCommands;
using ArchitectureByDisruptorPattern.WorkHandlers;
using System;

namespace ArchitectureByDisruptorPattern
{
	class Program
	{
		private static readonly int _defaultRingBufferSize = 1024;

		static void Main(string[] args)
		{
			if (!CommandLineOptions.TryParse(args, out var options))
			{
				CommandLineOptions.PrintHelpInfo();
				return;
			}

			var disruptor = new Disruptor<ArithmeticOperationEvent>(
				() => new ArithmeticOperationEvent(), ringBufferSize: _defaultRingBufferSize);

			disruptor
				.HandleEventsWithWorkerPool(new DelayWorkHandler())
				.ThenHandleEventsWithWorkerPool(new CalculationWorkHandler());

			var ringBuffer = disruptor.Start();

			foreach (var option in options)
			{
				using var scope = ringBuffer.PublishEvent();
				var operationEvent = scope.Event();

				operationEvent.SetValues(
					option.Id,
					option.Argument1,
					option.Argument2,
					BuildCommand(option.OperationType));
			}

			disruptor.Shutdown();

			Console.WriteLine(new string('-', 100));
			Console.WriteLine($"TotalTicks: {ExecutionMetrics.TotalTicks}, MeasureCount: {ExecutionMetrics.MeasureCount}, AverageTicksForOperation: {ExecutionMetrics.TotalTicks/ExecutionMetrics.MeasureCount}");
			Console.WriteLine(new string('-', 100));
		}

		private static IArithmeticOperationCommand BuildCommand(ArithmeticOperationType operationType)
		{
			try
			{
				return
					new ArithmeticCommandBuilder()
					.For(operationType)
					.Build();
			}
			catch
			{
				return null;
			}
		}
	}
}
