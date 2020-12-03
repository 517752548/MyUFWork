namespace DCET
{
	public static class Game
	{
		public static Scene Scene = null;

#if SERVER
		public static Options Options;
#endif

		private static EventSystem eventSystem;

		public static EventSystem EventSystem
		{
			get
			{
				return eventSystem ?? (eventSystem = new EventSystem());
			}
		}

		private static ObjectPool objectPool;

		public static ObjectPool ObjectPool
		{
			get
			{
				return objectPool ?? (objectPool = new ObjectPool());
			}
		}

		public static void Close()
		{
			Scene?.Dispose();
			Scene = null;
			
#if SERVER
			Options = null;
#endif

			objectPool?.Dispose();
			objectPool = null;

			eventSystem = null;
	}
}
}