using System;

namespace DCET
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class EventAttribute: BaseAttribute
	{
		public string Type { get; }

		public EventAttribute(string type)
		{
			Type = type;
		}
	}
}