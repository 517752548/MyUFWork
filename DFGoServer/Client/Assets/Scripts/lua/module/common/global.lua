--加载场景的类型
_G.LoadSceneType        = {
	None        = -1, --当前没有进行加载
	EnterGame   = 0, --正在进行进入游戏加载场景
	ChangeScene = 1, --正在进行切换地图加载场景
	Complete    = 2, --加载场景已经完成
}
--当前的加载场景类型LoadSceneType
_G.CurrentLoadSceneType = LoadSceneType.None

_G.AttrType             = {
	--金币数
	GOLD     = 1,
	--体力
	LIVES    = 2,
	--星星
	STAR     = 3,
	--经验值
	EXP      = 4,
	--关卡进度
	STAGE    = 5,
	--关卡奖励进度
	STAGEBOX = 6,
	--星星奖励进度
	STARBOX  = 7,
}
--是否初始化完成存档
_G.IsInitializeStorage = false
--关卡开局的3个道具
_G.BoosterIDList        = {
	9101,
	0,
	0,
}
--关卡道具所加步数
_G.LEVEL_ADDITIONAL_STEP = 3
_G.HomePageID           = {
	TEAM     = 1,
	CULTIVAT = 2,
	HOME     = 3,
	SHOP     = 4,
	RANK     = 5
}

_G.GoldAnimType         = {
	--金币直接跳转过去
	NORMAL        = 1,
	--金币数值平滑的显示过去
	FADE          = 2
}

--用户登录的id,正常情况下device一定存在，另外fb和apple中可能存在一种
_G.LoginIdType   = {
	DeviceID     = "LoginType1",
	FBID         = "LoginType2",
	APPLEID      = "LoginType3"
}