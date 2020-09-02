namespace BetaFramework
{
    public enum OpCodes : short
    {
        Error = -1,

        Start = 32000,

        /// <summary>
        /// 登陆接口
        /// </summary>
        Login,

        /// <summary>
        /// fb登陆的时候同步数据
        /// </summary>
        FblogInSync,

        /// <summary>
        /// 用户主动同步数据
        /// </summary>
        ButtonClickSync,

        /// <summary>
        /// 其他时机通用的同步数据
        /// </summary>
        NormalSync,

        /// <summary>
        /// 请求礼包
        /// </summary>
        RequsetGift,

        /// <summary>
        /// 内购校验
        /// </summary>
        ValidateReceipt,

        /// <summary>   上传用户数据. </summary>
        UploadUserData,

        //动态关卡
        ReqestDdl,

        /// <summary>   获取每日奖励数据. </summary>
        GetDilaySignGiftConfig,
        

        /// <summary>
        /// 锦标赛上传数据
        /// </summary>
        WeekRankUpload,

        /// <summary>
        /// 锦标赛拉取排行榜
        /// </summary>
        WeekRankGetList,
        /// <summary>
        /// 获取其他玩家统计数据
        /// </summary>
        PlayerProfile,
        /// <summary>
        /// 请求宝箱
        /// </summary>
        ReqestChest,
        ACRank,

        //login页面的Event列表
        ReqestEventList,
        
        PetFromLine,
        //卡包
        CardBag,
        
        OnLineItem,
        
        // 娃娃机
        PrizeClawCode,

        //成就
        Achievement,
        //PVE所有段位
        PveDan,
        //参加PVE子活动并获取对手信息
        PveEnter,
        //获取PVE子活动排行榜
        PveRank,
        //上传PVE子活动分数
        PveUpload
    }
}
