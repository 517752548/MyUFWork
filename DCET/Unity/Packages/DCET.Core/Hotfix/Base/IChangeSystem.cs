using System;

namespace DCET
{
	public interface IChangeSystem
	{
		Type Type();
		void Run(object o);
	}

	public abstract class ChangeSystem<T> : IChangeSystem
	{
		public void Run(object o)
		{
			Change((T)o);
		}

		public Type Type()
		{
			return typeof(T);
		}

		public abstract void Change(T self);
	}
}
