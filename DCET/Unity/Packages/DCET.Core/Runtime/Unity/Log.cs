using System;

namespace DCETRuntime
{
	public static class Log
	{
#if SERVER
		private static readonly ILog globalLog = new NLogAdapter();
#endif

		public static void Warning(string msg)
		{
#if !SERVER
			UnityEngine.Debug.LogWarning(msg);
#else
			globalLog.Warning(msg);
#endif
		}

		public static void Info(string msg)
		{
#if !SERVER
			UnityEngine.Debug.Log(msg);
#else
			globalLog.Info(msg);
#endif
		}

		public static void Exception(Exception e)
		{
			Error(e.ToString());
		}

		public static void Error(string msg)
		{
#if !SERVER
			UnityEngine.Debug.LogError(msg);
#else
			globalLog.Error(msg);
#endif
		}

		public static void Debug(string msg)
		{
#if !SERVER
			UnityEngine.Debug.Log(msg);
#else
			globalLog.Debug(msg);
#endif
		}

#if SERVER
		public static void Print(object msg)
		{
			Debug(MongoHelper.ToJson(msg));
		}
#endif
	}
}