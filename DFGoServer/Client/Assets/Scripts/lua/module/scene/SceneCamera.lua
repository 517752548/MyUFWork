_G.SceneCameraBehavior = {
	NONE         = 0,
	NORMAL       = 1,
	FOCUS        = 2,
	T_2POINT5D   = 3,
	ORTHOGRAPHIC = 4,
}
_G.SceneCamera         = class()

function SceneCamera:ctor()
	self.go                         = nil
	self.behaviorList               = nil
	self.behavior                   = nil
	self.camera                     = nil
	self.postProcess                = nil
	self.postProcessLayer           = nil
	self.targetTransform            = nil
	self.updateKey                  = nil
	self.glow                       = nil
	self.snapshotPosition           = nil
	self.snapshotRotationEulerAngle = nil
	self.seq                        = nil
	self.enabledTouchRotate         = true
	self.currBehaviorType           = SceneCameraBehavior.NONE
	self.lastTouchPos               = Vector2.zero
end

function SceneCamera:GetGameObject()
	return self.go
end

function SceneCamera:GetTransform()
	if not self.go then return end
	return self.go.transform
end

function SceneCamera:GetCamera()
	return self.camera
end

function SceneCamera:GetBehaviorType()
	return self.currBehaviorType
end

function SceneCamera:GetLastTouchPos()
	return self.lastTouchPos
end

function SceneCamera:InitGraphics()
	if not self.go then return end
	-- 相机component
	self.camera = self.go.transform:GetComponent(typeof(Camera))
	setCameraDepthTextureMode(self.camera, UnityEngine.DepthTextureMode.Depth)
	self:AllowHDR(GraphicsCurrentConfig.postBloom)
	self:AllowMSAA(false)
	--[[
	self.postProcessLayer = self.go.transform:GetComponent(typeof(UnityEngine.Rendering.PostProcessing.PostProcessLayer))
	self:AllowPostProcessFXAA(GraphicsCurrentConfig.postFXAA)
	self.postProcess = self.go.transform:GetComponent(typeof(TaroPostProcessing))
	if self.postProcess then
		self.postProcess.enabled = true
	else
		self.postProcess = self.go:AddComponent(typeof(TaroPostProcessing))
	end
	]]
	self:CullingMaskRestore()
end

function SceneCamera:Init()
	if not self.go then return end
	self.behaviorList     = {}
	self.currBehaviorType = SceneCameraBehavior.ORTHOGRAPHIC
	self:InitBehavior()
	self:RunUpdate()
	self:SetFieldOfView()
end

function SceneCamera:AllowHDR(value)
	if self.camera then
		self.camera.allowHDR = value
	end
end

function SceneCamera:AllowMSAA(value)
	if self.camera then
		self.camera.allowMSAA = value
	end
end

function SceneCamera:AllowPostProcessFXAA(value)
	if self.postProcessLayer then
		if value then
			self.postProcessLayer.antialiasingMode                      = UnityEngine.Rendering.PostProcessing.PostProcessLayer.Antialiasing.FastApproximateAntialiasing
			self.postProcessLayer.fastApproximateAntialiasing.fastMode  = true
			self.postProcessLayer.fastApproximateAntialiasing.keepAlpha = true
		else
			self.postProcessLayer.antialiasingMode = UnityEngine.Rendering.PostProcessing.PostProcessLayer.Antialiasing.None
		end
	end
end

function SceneCamera:GetBehavior(behaviorIndex)
	if not self.behaviorList then return end
	if not self.behaviorList[behaviorIndex] then
		if behaviorIndex == SceneCameraBehavior.NORMAL then
			self.behaviorList[behaviorIndex] = CameraNormalBehavior.New()
		elseif behaviorIndex == SceneCameraBehavior.FOCUS then
			self.behaviorList[behaviorIndex] = CameraFocusBehavior.New()
		elseif behaviorIndex == SceneCameraBehavior.T_2POINT5D then
			self.behaviorList[behaviorIndex] = Camera2Point5DBehavior.New()
		elseif behaviorIndex == SceneCameraBehavior.ORTHOGRAPHIC then
			self.behaviorList[behaviorIndex] = CameraOrthographicBehavior.New()
		end
	end
	return self.behaviorList[behaviorIndex]
end

function SceneCamera:InitBehavior()
	if self.currBehaviorType == SceneCameraBehavior.NONE then
		self:UseNormalBehavior()
	elseif self.currBehaviorType == SceneCameraBehavior.NORMAL then
		self:UseNormalBehavior()
	elseif self.currBehaviorType == SceneCameraBehavior.T_2POINT5D then
		self:Use2P5DBehavior()
	elseif self.currBehaviorType == SceneCameraBehavior.ORTHOGRAPHIC then
		self:UseOrthographicBehavior()
	end
end

function SceneCamera:SwitchBehavior()
	if self.currBehaviorType == SceneCameraBehavior.NORMAL then
		self:Use2P5DBehavior()
	elseif self.currBehaviorType == SceneCameraBehavior.T_2POINT5D then
		self:UseNormalBehavior()
	elseif self.currBehaviorType == SceneCameraBehavior.ORTHOGRAPHIC then
		self:UseOrthographicBehavior()
	end
end

function SceneCamera:UseNormalBehavior()
	if self.behavior then
		self.behavior:Exit()
	end
	self.behavior = self:GetBehavior(SceneCameraBehavior.NORMAL)
	if not self.behavior then return end
	self.behavior.targetTransform = self.targetTransform
	self.behavior:Init(self)
	self.currBehaviorType = self.behavior:GetType()
end

function SceneCamera:UseFocusBehavior(focusTransform)
	if not focusTransform then return end
	if self.behavior then
		self.behavior:Exit()
	end
	self.behavior = self:GetBehavior(SceneCameraBehavior.FOCUS)
	if not self.behavior then return end
	self.behavior.targetTransform      = self.targetTransform
	self.behavior.targetFocusTransform = focusTransform
	self.behavior:Init(self)
	self.currBehaviorType = self.behavior:GetType()
end

function SceneCamera:Use2P5DBehavior()
	if self.behavior then
		self.behavior:Exit()
	end
	self.behavior = self:GetBehavior(SceneCameraBehavior.T_2POINT5D)
	if not self.behavior then return end
	self.behavior.targetTransform = self.targetTransform
	self.behavior:Init(self)
	self.currBehaviorType = self.behavior:GetType()
end

function SceneCamera:UseOrthographicBehavior()
	if self.behavior then
		self.behavior:Exit()
	end
	self.behavior = self:GetBehavior(SceneCameraBehavior.ORTHOGRAPHIC)
	if not self.behavior then return end
	self.behavior:Init(self)
	self.currBehaviorType = self.behavior:GetType()
end

function SceneCamera:SetEnabled(value)
	if not self.camera then return end
	self.camera.enabled = value
end

function SceneCamera:SetPos(value)
	if self.go then
		self.go.transform.position = value
	end
end

function SceneCamera:SetEulerAngles(value)
	if self.go then
		self.go.transform.rotation = Quaternion.Euler(value.x, value.y, value.z)
	end
end

function SceneCamera:SetEnabledTouchRotate(value)
	self.enabledTouchRotate = value
end

function SceneCamera:SetMaxDistance(value)
	if not self.behavior then return end
	if self.currBehaviorType == SceneCameraBehavior.NORMAL then
		return self.behavior:SetMaxDistance(value)
	end
end

function SceneCamera:ChangeDistToMax()
	if not self.behavior then return end
	if self.currBehaviorType == SceneCameraBehavior.NORMAL then
		return self.behavior:ChangeDistToMax()
	end
end

function SceneCamera:ChangeDistToDefault()
	if not self.behavior then return end
	if self.currBehaviorType == SceneCameraBehavior.NORMAL then
		return self.behavior:ChangeDistToDefault()
	end
end

function SceneCamera:SetOrthographicSize(value)
	if not self.behavior then return end
	if self.currBehaviorType == SceneCameraBehavior.ORTHOGRAPHIC then
		return self.behavior:SetOrthographicSize(value)
	end
end

function SceneCamera:ChangeModelHeight(height)
	if not self.behavior then return end
	self.behavior:ChangeModelHeight(height)
end

function SceneCamera:ExitToFace()
	if not self.behavior then return end
	if self.currBehaviorType == SceneCameraBehavior.NORMAL then
		self.behavior:ExitToFace()
	end
end

---@type fun @保存当前摄像机的位置和角度
function SceneCamera:SnapshotTransform()
	self.snapshotPosition           = self.go.transform.position:Clone()
	self.snapshotRotationEulerAngle = self.go.transform.eulerAngles:Clone()
end

---@type fun @缓动到当前的摄像机位置和角度快照
function SceneCamera:TweenToSnapshotTransform(time, callBack)
	if not self:GetTransform() then return end
	if not self.snapshotPosition or not self.snapshotRotationEulerAngle then return end
	local transform = self:GetTransform()
	if time > 0 then
		self:SetFieldOfView()
		transform:DORotate(self.snapshotRotationEulerAngle, time, RotateMode.Fast)
		transform:DOMove(self.snapshotPosition, time):OnComplete(function()
			if callBack then
				callBack()
			end
		end)
	else
		self:SetFieldOfView(nil, false)
		transform.rotation = Quaternion.Euler(self.snapshotRotationEulerAngle.x, self.snapshotRotationEulerAngle.y, self.snapshotRotationEulerAngle.z)
		transform.position = self.snapshotPosition
	end
end

function SceneCamera:TweenToRotate(destEulerAngle, time, callBack)
	if not self:GetTransform() then return end
	local transform = self:GetTransform()
	if time > 0 then
		transform:DORotate(destEulerAngle, time, RotateMode.Fast):OnComplete(function()
			if callBack then
				callBack()
			end
		end)
	else
		transform.rotation = Quaternion.Euler(destEulerAngle.x, destEulerAngle.y, destEulerAngle.z)
	end
end

function SceneCamera:TweenToBehavior(caller, callBack)
	if not self.behavior then return end
	self.behavior.tweenCaller     = caller
	self.behavior.onTweenComplete = callBack
	self.behavior.tweenMode       = true
end

function SceneCamera:RunUpdate()
	TimerManager:RemoveTimer(self.updateKey)
	self.updateKey = TimerManager:AddTimer(function()
		self:Update()
	end, 0, 0)
end

function SceneCamera:StopUpdate()
	TimerManager:RemoveTimer(self.updateKey)
	self.updateKey = nil
end
function SceneCamera:Update()
	if not self.behavior then return end
	self.behavior:Update()
	--检测鼠标点击并且记录
	if IsWindowsPlayer or IsRunInEditor then
		self:UpdateMouse()
	else
		self:UpdateTouch()
	end
end

function SceneCamera:UpdateMouse()
	if Input.GetMouseButtonDown(0) then
		if not UIManager:GetUIRoot() then return end
		if not UIManager:GetUIRoot():GetStageCamera() then return end
		local _, pos        = RectTransformUtility.ScreenPointToLocalPointInRectangle(UIManager:GetLayer(UILayerConsts.TOUCH).transform, Input.mousePosition, UIManager:GetUIRoot():GetStageCamera(), nil)
		self.lastTouchPos.x = pos.x
		self.lastTouchPos.y = pos.y
	end
end

function SceneCamera:UpdateTouch()
	if Input.touchCount == 0 then
		return
	end
	local touch = Input.GetTouch(0)
	if not touch then
		return
	end
	if touch.phase == TouchPhase.Began then
		if not UIManager:GetUIRoot() then return end
		if not UIManager:GetUIRoot():GetStageCamera() then return end
		local _, pos        = RectTransformUtility.ScreenPointToLocalPointInRectangle(UIManager:GetLayer(UILayerConsts.TOUCH).transform, touch.position, UIManager:GetUIRoot():GetStageCamera(), nil)
		self.lastTouchPos.x = pos.x
		self.lastTouchPos.y = pos.y
	end
end

function SceneCamera:GetAutoRotateFaceEnabled()
	if not self.behavior then return end
	if self.currBehaviorType == SceneCameraBehavior.NORMAL then
		return self.behavior.enabledAutoRotateFace
	end
end

function SceneCamera:EnabledAutoRotateToFace(value)
	if not self.behavior then return end
	if self.currBehaviorType == SceneCameraBehavior.NORMAL then
		self.behavior:EnabledAutoRotateToFace(value)
	end
end

function SceneCamera:EnabledAutoRotateToForward(value)
	if not self.behavior then return end
	if self.currBehaviorType == SceneCameraBehavior.NORMAL then
		self.behavior:EnabledAutoRotateToForward(value)
	end
end

function SceneCamera:AutoRotateToForward(isForce)
	if not self.behavior then return end
	if self.currBehaviorType == SceneCameraBehavior.NORMAL then
		self.behavior:AutoRotateToForward(isForce)
	end
end

function SceneCamera:Clear()
	self:StopUpdate()
	if self.behaviorList then
		for i, v in pairs(self.behaviorList) do
			if v then
				v:Destroy()
				v = nil
			end
		end
	end
	self.behaviorList               = nil
	self.behavior                   = nil
	self.camera                     = nil
	self.postProcess                = nil
	self.go                         = nil
	self.targetTransform            = nil
	self.glow                       = nil
	self.snapshotPosition           = nil
	self.snapshotRotationEulerAngle = nil
end

------------------遮挡剔除-----------------
-- 设置相机在交谈时的状态
function SceneCamera:SetCameraWithTalk(isTalk)
	if isTalk then
		self:CullingMaskWithOutLayer(LayerConsts.LAYER_NAME_UI,
				LayerConsts.LAYER_NAME_NPC,
				LayerConsts.LAYER_NAME_MONSTER,
				LayerConsts.LAYER_NAME_COLLECTION,
				LayerConsts.LAYER_NAME_DROPITEM,
				LayerConsts.LAYER_NAME_PFX,
				LayerConsts.LAYER_NAME_PLAYER,
				LayerConsts.LAYER_NAME_MAINPLAYER,
				LayerConsts.LAYER_NAME_PORTAL,
				LayerConsts.LAYER_NAME_TRAP,
				LayerConsts.LAYER_NAME_PET
		)
		self:StopUpdate()
	else
		self:CullingMaskRestore()
		self:CameraRotationRestore()
	end
	SceneController:SetHUDEnabled(not isTalk)
end

function SceneCamera:CullingMaskWithOutLayer(...)
	local args = { ... }
	for i, v in pairs(args) do
		self.camera.cullingMask = self.camera.cullingMask & (~(1 << LayerMask.NameToLayer(v)))
	end
end

-- 相机还原
function SceneCamera:CullingMaskRestore()
	if not self.camera then
		return
	end

	self.camera.cullingMask = -1
	--默认的相机不带有 UI层
	self:CullingMaskWithOutLayer(LayerConsts.LAYER_NAME_UI)
end

---------------------------------------------------------------------

---------------------------POST PROCESS---------------------------
function SceneCamera:EnabledGaussianBlur(enabled, radius, downSample, iteration)
	radius     = radius or -1
	downSample = downSample or 1
	iteration  = iteration or 2
	if not self.postProcess then return end
	self.postProcess.enableGaussianBlur = enabled
	if not enabled then
		return
	end
	self.postProcess.gaussianBlurRadius = radius
	self.postProcess.gaussianDownSample = downSample
	self.postProcess.gaussianIteration  = iteration
end

------------------------------------------------------------------
-- 设置视角
function SceneCamera:SetFieldOfView(num, isTween)
	num     = num or 55
	isTween = isTween == nil and true or false
	if not self.camera then
		return
	end
	if isTween then
		self.camera:DOFieldOfView(num, 0.5)
	else
		self.camera.fieldOfView = num
	end
end