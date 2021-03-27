_G.LoginController            = Controller.New()

function LoginController:Create()
end



-- 初始化登录界面
function LoginController:InitLogin()
	UIManager:OpenUI(UIPanelName.LoginPanel, true)
end

-- 销毁登录界面
function LoginController:HideLogin()
	UIManager:HideUI(UIPanelName.LoginPanel)
end

----------------------------------------------------------
function LoginController:DoEnterGame()
	LoginController:HideLogin()
end

function LoginController:DoLogoutGame()
	--调用下所有controller的OnLogoutGame
	GameApp:OnLogoutGame()

end

function LoginController:OnLogoutGame()
	LoginModel:OnLogoutGame()
end

