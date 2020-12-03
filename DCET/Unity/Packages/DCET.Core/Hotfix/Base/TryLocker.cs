using System;
using System.Threading;

namespace DCET
{
	public class TryLock : IDisposable
	{
		private object locked;

		public bool HasLock { get; private set; }

		public TryLock(object obj)
		{
			if (!Monitor.TryEnter(obj))
			{
				return;
			}

			HasLock = true;
			locked = obj;
		}

		public void Dispose()
		{
			if (!HasLock)
			{
				return;
			}

			Monitor.Exit(locked);
			locked = null;
			HasLock = false;
		}
	}
}
