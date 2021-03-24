_G.GameApp       = {}

GameApp.facade   = Facade.New()
GameApp.testMode = false

function GameApp:StartUp()
	ResManager:Init()
	NetManager:Init()
	TimerManager:Init()
	UIManager:Init()
	PfxManager:Init()
	SoundManager:Init()
	AtlasManager:Init()
end

--在这里注册各个模块的controller
function GameApp:RegisterController()
	local facade = self.facade
	facade:AddController(LoginController)
	facade:AddController(SceneController)

end


function GameApp:OnEnterGame()
	local services = self.facade:GetAllService()
	for i, v in ipairs(services) do
		v:OnEnterGame()
	end
	local controllers = self.facade:GetAllController()
	for i, v in ipairs(controllers) do
		v:OnEnterGame()
	end
end


--每次进入到home界面都调用
function GameApp:OnEnterHome()
	local controllers = self.facade:GetAllController()
	for i, v in ipairs(controllers) do
		v:OnEnterHome()
	end
end

function GameApp:OnChangeSceneMap()
	local controllers = self.facade:GetAllController()
	for i, v in ipairs(controllers) do
		v:OnChangeSceneMap()
	end
end

function GameApp:OnLeaveSceneMap()
	local controllers = self.facade:GetAllController()
	for i, v in ipairs(controllers) do
		v:OnLeaveSceneMap()
	end
end

function GameApp:OnLogoutGame()
	local controllers = self.facade:GetAllController()
	for i, v in ipairs(controllers) do
		v:OnLogoutGame()
	end
end

function GameApp:OnReconnectGame()
	local controllers = self.facade:GetAllController()
	for i, v in ipairs(controllers) do
		v:OnReconnectGame()
	end
end

-- 此方法实际没有被调用
function GameApp.OnApplicationQuit()
end
