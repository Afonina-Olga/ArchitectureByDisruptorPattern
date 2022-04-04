using System;
using System.Diagnostics;

namespace ArchitectureByDisruptorPattern
{
	/// <summary>
	/// Execution metrics
	/// </summary>
	public static class ExecutionMetrics
	{
		public static long TotalTicks { get; set; }
		public static int MeasureCount { get; set; }

		public static void MeasureTime(Action action)
		{
			var watch = new Stopwatch();
			watch.Start();
			// Для корректного измерения среднего времени выполнения нужно было бы запустить в цикле несколько итераций
			// т.к. первый запуск метода медленнее из-за компиляции, но в данном задании этого не требуется
			action();
			watch.Stop();
			TotalTicks += watch.ElapsedTicks;
			MeasureCount++;
		}
	}
}
