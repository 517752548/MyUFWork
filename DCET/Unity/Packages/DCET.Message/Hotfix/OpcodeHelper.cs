using System.Collections.Generic;

namespace DCET
{
	public static class OpcodeHelper
	{
		private static readonly HashSet<ushort> ignoreDebugLogMessageSet = new HashSet<ushort>();

		public static void AddIgnore(ushort opcode)
		{
			ignoreDebugLogMessageSet.Add(opcode);
		}

		public static bool IsNeedDebugLogMessage(ushort opcode)
		{
			if (ignoreDebugLogMessageSet.Contains(opcode))
			{
				return false;
			}

			return true;
		}

		public static bool IsClientHotfixMessage(ushort opcode)
		{
			return opcode > 10000;
		}
	}
}