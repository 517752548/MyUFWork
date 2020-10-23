
namespace app.state
{
    public enum StateDef
    {
        /// <summary>
        /// 初始
        /// </summary>
        init,

        /// <summary>
        /// 初始化ui
        /// </summary>
        initUI,

        /// <summary>
        /// 验证配置
        /// </summary>
        //verifyConfig,

        /// <summary>
        /// 登录
        /// </summary>
        login,

        /// <summary>
        /// 创建角色
        /// </summary>
        selAvatar,

        /// <summary>
        /// 主场景
        /// </summary>
        //mainScene,

        /// <summary>
        /// 战斗场景
        /// </summary>
        battleState,

        /// <summary>
        /// 关卡场景
        /// </summary>
        //missionScene,
        /// <summary>
        /// 副本地图场景。
        /// </summary>
        zoneState,

		/// <summary>
		/// 剧情。
		/// </summary>
		storyState
    }
}
