namespace ETModel
{
    public static class URLConst
    {
        public const string version = "1.0.0";
#if UNITY_IOS
        public static string BundleReleaseUrl
			{
				get
				{
					{
						if (true)
						{
							return "https://wapifiles.wordzhgame.net/activityfiles/TestDemo/Android/Release/" +
									version;
						}
						else
						{
							return "https://wapifiles.wordzhgame.net/activityfiles/TestDemo/Android/Debug/" +
									version;
						}
					}
				}
			}

#else
        public static string BundleReleaseUrl
        {
            get
            {
                {
                    if (true)
                    {
                        return "https://wapifiles.wordzhgame.net/activityfiles/TestDemo/Android/Release/" +
                                version;
                    }
                    else
                    {
                        return "https://wapifiles.wordzhgame.net/activityfiles/TestDemo/Android/Debug/" +
                                version;
                    }
                }
            }
        }

#endif
    }
}