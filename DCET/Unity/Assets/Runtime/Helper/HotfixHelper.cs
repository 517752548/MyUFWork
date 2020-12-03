namespace DCETRuntime
{
	public static class HotfixHelper
	{
		public static void StartHotfix()
		{
#if XLUA
			LuaHelper.StartHotfix();
#else
			MonoHelper.StartHotfix();
#endif
		}
	}
}
