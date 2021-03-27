_G.SceneController         = Controller.New()

SceneController.mainCamera = nil
function SceneController:Create()
end

function SceneController:OnEnterGame()
end

--------------------------------------------场景主相机相关START------------------------------------------------
function SceneController:InitMainCamera()
	local go = GameObject.FindWithTag('MainCamera')
	if not go then
		logError('没有找到主摄像机 ')
	end
	if not self.mainCamera then
		self.mainCamera = SceneCamera.New()
	end
	self.mainCamera.go  = go
	CSGlobal.faceCamera = go
end

function SceneController:UpdateMainCamera()
	self.mainCamera:InitGraphics()
	self.mainCamera:Init()
end

function SceneController:GetMainCamera()
	return self.mainCamera
end

function SceneController:GetMainCameraGameObject()
	if self.mainCamera and self.mainCamera:GetGameObject() then
		return self.mainCamera:GetGameObject()
	end
	return GameObject.FindWithTag('MainCamera')
end

function SceneController:ClearCamera()
	if not self.mainCamera then return end
	self.mainCamera:Clear()
end

function SceneController:UpdateCameraOrthographicSize()
	if not self.mainCamera then return end
	self.mainCamera:SetOrthographicSize(math.max(UIManager:GetUIReferenceResolution().y / 2 / 100, UIManager:GetScreenFullSizeDelta().y / 2 / 100))
end
--------------------------------------------场景主相机相关END------------------------------------------------

function SceneController:OnLogoutGame()
	--关闭所有UI面板
	UIManager:DestroyAllUIImmediately()
	--清除摄像机
	self:ClearCamera()
	--清除所有特效
	PfxManager:ClearAllPfx()

	--清除对象池
	ObjPoolManager:ClearAll()

	self.mainCamera   = nil
	self.currMapId    = 0
	self.shadowcaster = nil
	self.gimmicksDict = {}
end

function SceneController:OnChangeSceneMap()
end