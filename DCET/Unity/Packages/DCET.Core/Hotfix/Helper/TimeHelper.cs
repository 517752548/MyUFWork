namespace DCET
{
	public static class TimeHelper
	{
		public static long CurrentLocalMilliseconds()
		{
			return DCETRuntime.LocalTimeHelper.CurrentMilliseconds();
		}

		public static long CurrentLocalSeconds()
		{
			return DCETRuntime.LocalTimeHelper.CurrentSeconds();
		}
    }
}