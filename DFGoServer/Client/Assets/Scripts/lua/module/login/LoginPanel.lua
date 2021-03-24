_G.LoginPanel = class(LoginPanelHybridUI)

UIManager:RegisterUIClass(UIPanelName.LoginPanel, LoginPanel)
function LoginPanel:ctor()
end

function LoginPanel:OnLoaded()
	LoginPanel.superclass.OnLoaded(self)

	UIUtil:FixFullScreenUITransform(self.bgImg)

	------------------
	self.btnEnter:OnClick(function()
		self:EnterGameClick()
	end)
end

function LoginPanel:OnShow(args)
end

-- 点击进入游戏
function LoginPanel:EnterGameClick()
	LoginController:DoEnterGame()
end

function LoginPanel:OnHide()
end
