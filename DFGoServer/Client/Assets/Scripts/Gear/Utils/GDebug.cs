using UnityEngine;
using System.Collections;

public class GDebug
{
	public static void Log(object log, params object[] args)
	{
		if (args != null && args.Length > 0)
		{
			Debug.LogFormat((string)log, args);
		}
		else
		{
			Debug.Log(log);
		}
	}
	public static void LogWarning(object log, params object[] args)
	{
		if (args != null && args.Length > 0)
		{
			Debug.LogWarningFormat((string)log, args);
		}
		else
		{
			Debug.LogWarning(log);
		}
	}
	public static void LogError(object log, params object[] args)
	{
		if (args != null && args.Length > 0)
		{
			Debug.LogErrorFormat((string)log, args);
		}
		else
		{
			Debug.LogError(log);
		}
	}
}
