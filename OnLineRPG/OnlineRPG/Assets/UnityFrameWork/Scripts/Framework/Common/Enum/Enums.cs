namespace BetaFramework
{
    public enum ResLoadLocation
    {
        Resource,
        Streaming,
        Persistent,
        Catch,
    }

    public enum SpecialPathType
    {
        Resources,

        //#if UNITY
        Persistent,

        StreamingAssets,
        //#endif
    }

    public enum TableFormat
    {
        TextAsset,
        Json,
        Bytes,
        Xml
    }

    public enum BasicFieldType
    {
        Undefined = 0,
        Bool = 1,
        Int = 2,
        Float = 4,
        String = 8,
        Vector2 = 16,
        Vector3 = 32,
        Vector4 = 64,
        Color = 128
    }

    /// <summary>
    /// 资源归类
    /// </summary>
    public enum AssetType
    {
        Config = 0,
        UiPrefab = 1,
    }

    public enum UFConfigType
    {
        Names,
        BgEffect,
        DeGoogleSheets,
        EnGoogleSheets,
        PrefabConfig,
        UI_Config,
        Music_Sound,
        IapProduct,
        AndroidAdsConfig,
        IosAdsConfig,
        RateConfig,
        DailyChallengeConfig,
        MapConfig,
        PreloadAssetConfig
    }
}