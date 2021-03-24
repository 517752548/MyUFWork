_G.Notifier     = GameApp.facade
_G.NotifyConsts = {
	------------------------UI面板---------------------------
	OnUIShow                    = "OnUIShow",
	OnUIFullShow                = "OnUIFullShow",
	OnUIHide                    = "OnUIHide",

	------------------------PuzzlePlay--------------------------
	UpdateLeftStep              = "UpdateLeftStep",
	UpdatePickGroup             = "UpdatePickGroup",
	UpdatePowerShape            = "UpdatePowerShape",
	AddScore                    = "AddScore",
	AddPower                    = "AddPower",
	ClearPower                  = "ClearPower",
	AddPassTargetCount          = "AddPassTargetCount",
	--触发随机所有挑选图形
	ReshuffleAllShape           = "ReshuffleAllShape",
	--道具面板中的炸弹启用
	ItemPanelBombEnabled        = "ItemPanelBombEnabled",
	--道具面板中的万能格子启用
	ItemPanelPointEnabled       = "ItemPanelPointEnabled",
	--道具面板中的旋转启用
	ItemPanelRotateEnabled      = "ItemPanelRotateEnabled",
	--道具面板中的锤子启用
	ItemPanelHammerEnabled      = "ItemPanelHammerEnabled",
	--挑选界面中的旋转格子启用
	PickPanelRotateShapeEnabled = "PickPanelRotateShapeEnabled",

	-------------------------数据通知-----------------------------
	--改变属性
	ChangeAttr                  = "ChangeAttr",
	--增加属性
	AddAttr                     = "AddAttr",
	--减少属性
	ReduceAttr                  = "ReduceAttr",
	--更新金币
	UpdateCoin                  = "UpdateCoin",
}