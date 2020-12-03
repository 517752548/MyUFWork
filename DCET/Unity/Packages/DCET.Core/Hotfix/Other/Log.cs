using System;

namespace DCET
{
	public static class Log
	{
		public static void Warning(string msg)
		{
			DCETRuntime.Log.Warning(msg);
		}

		public static void Info(string msg)
		{
			DCETRuntime.Log.Info(msg);
		}

		public static void Exception(Exception e)
		{
			if (e != null)
			{
				Error(e.ToString());
			}
			else
			{
				Error("Unknown exception");
			}
		}

		public static void Error(string msg)
		{
			DCETRuntime.Log.Error(msg);
		}

		public static void Debug(string msg)
		{
			DCETRuntime.Log.Debug(msg);	
		}

		public static void Print(object msg)
		{
			Debug(StringHelper.ToString(msg));
		}
	}
}