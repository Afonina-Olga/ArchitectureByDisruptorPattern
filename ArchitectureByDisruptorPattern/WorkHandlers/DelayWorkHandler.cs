using Disruptor;
using System.Threading;

namespace ArchitectureByDisruptorPattern.WorkHandlers
{
	/// <summary>
	/// The first disruptor’s worker, which contains only Thread.Sleep(2000)
	/// </summary>
	public class DelayWorkHandler : IWorkHandler<ArithmeticOperationEvent>
	{
		public void OnEvent(ArithmeticOperationEvent evt)
		{
			Thread.Sleep(2000);
		}
	}
}
