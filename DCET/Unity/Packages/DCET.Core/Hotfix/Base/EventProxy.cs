using System;
using System.Collections.Generic;

namespace DCET
{
	public class EventProxy: IEvent
	{
		public Action<List<object>> action;
		public List<object> param = new List<object>();

		public EventProxy(Action<List<object>> action)
		{
			this.action = action;
		}

		public void Handle()
		{
			param.Clear();
			action.Invoke(param);
		}

		public void Handle(object a)
		{
			param.Clear();
			param.Add(a);
			action.Invoke(param);
		}

		public void Handle(object a, object b)
		{
			param.Clear();
			param.Add(a);
			param.Add(b);
			action.Invoke(param);
		}

		public void Handle(object a, object b, object c)
		{
			param.Clear();
			param.Add(a);
			param.Add(b);
			param.Add(c);
			action.Invoke(param);
		}
	}
}
