_G.LoginPanel = class(LoginPanelHybridUI)

UIManager:RegisterUIClass(UIPanelName.LoginPanel, LoginPanel)
function LoginPanel:ctor()
end

function LoginPanel:OnLoaded()
	LoginPanel.superclass.OnLoaded(self)

	UIUtil:FixFullScreenUITransform(self.bgImg)

	------------------
	self.DanjiBtn:OnClick(function()
		UIManager:OpenUI(UIPanelName.DanjiPanel)
	end)
	self.OnLineBtn:OnClick(function()
		UIManager:OpenUI(UIPanelName.OnLinePanel)
	end)
end

function LoginPanel:OnShow(args)
end

-- 点击进入游戏
function LoginPanel:EnterGameClick()
	UIManager:OpenUI(UIPanelName.OnLinePanel)
	--LoginController:DoEnterGame()
end

function LoginPanel:OnHide()
end
