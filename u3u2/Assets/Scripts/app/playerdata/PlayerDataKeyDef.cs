/// <summary>
/// PlayerPrefs 的key定义，只能往后加，前面的不能改
/// </summary>
public class PlayerDataKeyDef
{
    public const string ACCOUNT_DATA = "0";
    public const string ACCOUNT_DATA_NAME = "0_0";
    public const string ACCOUNT_DATA_PWD = "0_1";
    /// <summary>
    /// 游戏角色uuid
    /// </summary>
    public const string ACCOUNT_DATA_UUID="0_2";
    /// <summary>
    /// 最近联系人
    /// </summary>
    public const string ZUIJINLIANXIREN_DATA = "1";
    /// <summary>
    /// 最近联系人中的玩家信息字段 key
    /// </summary>
    public const string ZUIJINLIANXIREN_DATA_UUID = "1_0";
    public const string ZUIJINLIANXIREN_DATA_NAME = "1_1";
    public const string ZUIJINLIANXIREN_DATA_LV = "1_2";
    public const string ZUIJINLIANXIREN_DATA_PHOTO = "1_3";
    /// <summary>
    /// 矿点缓存数据
    /// </summary>
    public const string KUANGDIAN_DATA = "2";

    /// <summary>
    /// 矿点缓存数据中的信息字段 key
    /// </summary>
    public const string KUANGDIAN_DATA_ID = "2_0";
    public const string KUANGDIAN_DATA_LEIBIE = "2_1";
    public const string KUANGDIAN_DATA_TIME = "2_2";
    public const string KUANGDIAN_DATA_KUANGGONG = "2_3";
    
    public const string CUSTOM_DATA = "3";
    //洗练
    public const string CUSTOM_DATA_Jinritishi_xilian = "3_0";
    //上架
    public const string CUSTOM_DATA_Jinritishi_shangjia = "3_1";
    //显示质量。
    public const string CUSTOM_DATA_DISPLAY_QUALITY = "3_2";
    
    //是否隐藏其他玩家。
    public const string CUSTOM_DATA_IS_HIDE_OTHERS = "3_3";
    //是否播放背景音乐。
    public const string CUSTOM_DATA_IS_PLAY_BG_SOUND = "3_4";
    //是否播放音效。
    public const string CUSTOM_DATA_IS_PLAY_EFFECT_SOUND = "3_5";
    //打造 今日不再提示。
    public const string CUSTOM_DATA_Jinritishi_dazao = "3_6";
    //是否特效全开。
    public const string CUSTOM_DATA_IS_SHOW_PARTICLE_EFFECTS = "3_7";
    //是否自动播放世界频道语音。
    public const string CUSTOM_DATA_IS_AUTO_PLAY_SHIJIE_YUYIN = "3_8";
    //是否自动播放当前频道语音。
    public const string CUSTOM_DATA_IS_AUTO_PLAY_DANGQIAN_YUYIN = "3_9";
    //是否自动播放帮派频道语音。
    public const string CUSTOM_DATA_IS_AUTO_PLAY_BANGPAI_YUYIN = "3_10";
    //是否自动播放队伍频道语音。
    public const string CUSTOM_DATA_IS_AUTO_PLAY_DUIWU_YUYIN = "3_11";
}
