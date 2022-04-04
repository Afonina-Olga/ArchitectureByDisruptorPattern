using Disruptor;
using System.Threading;

namespace ArchitectureByDisruptorPattern.WorkHandlers
{
	public class DelayWorkHandler : IWorkHandler<ArithmeticOperationEvent>
	{
		public void OnEvent(ArithmeticOperationEvent evt)
		{
			Thread.Sleep(2000);
		}
	}
}
