using UnityEngine;

namespace DCETRuntime
{
	public static class ResourcesHelper
	{
		public static Object Load(string path)
		{
			return Resources.Load(path);
		}
	}
}
