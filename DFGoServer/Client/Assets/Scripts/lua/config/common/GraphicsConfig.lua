--品质常量 目前只用到2，3，4这三个 1和5为预留，目前不会用到
_G.QUALITY_FAST                = 1
_G.QUALITY_LOW                 = 2
_G.QUALITY_MID                 = 3
_G.QUALITY_HIGH                = 4
_G.QUALITY_EXTREMA             = 5
_G.QUALITY_CUSTOM              = 6
--分辨率的级别
_G.RESOLUTION_LOW              = 1
_G.RESOLUTION_MID              = 2
--阴影质量的3个级别
_G.SHADOWS_QUALITY_LOW         = 1
_G.SHADOWS_QUALITY_MID         = 2
_G.SHADOWS_QUALITY_HIGH        = 3
--Unity的画质等级
_G.SETTINGS_QUALITY_LOW        = 1
_G.SETTINGS_QUALITY_MID        = 2
_G.SETTINGS_QUALITY_HIGH       = 3

_G.FRAMERATE_LOW               = 30
_G.FRAMERATE_HIGH              = 60
_G.GraphicsFixedConfig         = {
	[QUALITY_LOW]  = {
		resolution            = RESOLUTION_LOW,
		postBloom             = false,
		postColorGrading      = false,
		postDOF               = false,
		postFXAA              = false,
		otherPlayerPfxVisible = false,
		monsterPfxVisible     = false,
		shadowsQuality        = SHADOWS_QUALITY_LOW,
		settingsQuality       = SETTINGS_QUALITY_LOW,
	},
	[QUALITY_MID]  = {
		resolution            = RESOLUTION_MID,
		postBloom             = false,
		postColorGrading      = true,
		postDOF               = false,
		postFXAA              = false,
		otherPlayerPfxVisible = true,
		monsterPfxVisible     = true,
		shadowsQuality        = SHADOWS_QUALITY_MID,
		settingsQuality       = SETTINGS_QUALITY_MID,
	},
	[QUALITY_HIGH] = {
		resolution            = RESOLUTION_MID,
		postBloom             = true,
		postColorGrading      = true,
		postDOF               = true,
		postFXAA              = true,
		otherPlayerPfxVisible = true,
		monsterPfxVisible     = true,
		shadowsQuality        = SHADOWS_QUALITY_HIGH,
		settingsQuality       = SETTINGS_QUALITY_HIGH,
	}
}
_G.GraphicsCurrentQuality      = nil
_G.GraphicsCurrentConfig       = {}

_G.GraphicsBasicConfig         = {
	gameMaxFrameRate = FRAMERATE_HIGH,
	otherPlayerNum   = 10,
}

_G.BasicSettingsConfig         = {
	musicVolume = 0.8,
	sfxVolume   = 0.8,
}

_G.AUPNormalConfig             = {
	asyncUploadTimeSlice        = 4,
	asyncUploadBufferSize       = 16,
	asyncUploadPersistentBuffer = true,
}

_G.AUPLoadingConfig            = {
	asyncUploadTimeSlice        = 4,
	asyncUploadBufferSize       = 32,
	asyncUploadPersistentBuffer = true,
}

_G.BattleSettingsDefaultConfig = {
	medicineRatio         = 0.8, --自动吃药血量下限比率比例
	autoBuyEnabled        = true, --自动买药开关
	autoReviveEnabled     = false, --自动复活开关
	autoLoadGundamEnabled = true, --自动上机甲战斗
	autoBattleSkill       = "all", --自动释放技能，如果为"all"，表示所有技能都可以。如果有值的话 用字符串 逗号分隔存储表示
}

_G.BattleSettingsConfig        = {
	medicineRatio         = 0,
	autoBuyEnabled        = true,
	autoReviveEnabled     = true,
	autoLoadGundamEnabled = true,
	autoBattleSkill       = "all",
}