_G.CameraNormalBehavior = class(CameraBaseBehavior)

function CameraNormalBehavior:ctor()
	self.targetTransform          = nil
	self.defRotX                  = 10
	self.defBattleRotX            = 45
	self.defRotY                  = nil
	self.minRotX                  = -8
	self.defTargetDist            = 7
	self.targetDist               = self.defTargetDist
	self.maxMapDistance           = 0
	self.maxDistance              = CAMERA_MAX_DISTANCE_NORMAL
	self.minDistance              = 2
	self.enabledAutoRotateForward = false
	self.enabledAutoRotateFace    = false
	self.isRotateFaceComplete     = false
	self.defFaceX                 = -3
	self.isAdjustedRotX           = false
	self.hasMapInitRot            = false
	self.touchAxisRate            = 0.05
	self.isDebugRotateAround      = false
	self.isAdjustingRotY          = false
	self.enabledYRotate           = true
end

function CameraNormalBehavior:GetType()
	return SceneCameraBehavior.NORMAL
end
local modelHeightGap        = -0.2
local tempDist              = 0
local heightTempVector
local heightTempVolicity    = Vector3.New()
local tempTargetPosition    = Vector3.New()
local tmpBackward           = Vector3.zero
local modelHeight           = 0        --模型高度
local tempModelHeight       = 0
local rotateHSpeed          = 60       --鼠标横向滑动速度
local rotateVSpeed          = 60       --鼠标纵向滑动速度
local zoomSpeed             = 20       --缩进速度
local ray                   = Ray.New(Vector3.one, Vector3.down)
local tempTouchPos1         = Vector2.zero
local tempTouchPos2         = Vector2.zero
local oldTouchPos1          = Vector2.zero
local oldTouchPos2          = Vector2.zero
local autoRotateForwardTime = 0.01
local autoRotateFaceTime    = 0.05
local rayResult, rayHitInfo = false, nil

function CameraNormalBehavior:Init(sceneCamera)
	CameraNormalBehavior.superclass.Init(self, sceneCamera)
	if IsIPhonePlayer then
		self.touchAxisRate = 0.2
	elseif IsAndroidPlayer then
		self.touchAxisRate = 0.15
	end
	local player    = MainPlayerController:GetPlayer()
	modelHeight     = (player and player:GetModelHeight() or t_playerinfo[MainPlayerController:GetProfID()].height) + modelHeightGap
	tempModelHeight = modelHeight
	local map       = t_map[SceneController:GetCurMapID()]
	if map.cameraDist > 0 then
		self.maxMapDistance = map.cameraDist
		self.defTargetDist  = self.maxMapDistance
		self.targetDist     = self.maxMapDistance
	end
	--初始化距离
	self.maxDistance                        = math.max(self.maxDistance, self.maxMapDistance)
	self.targetDist                         = Mathf.Clamp(self.targetDist, self.minDistance, self.maxDistance)
	tempDist                                = self.targetDist
	--初始化角度
	local initRotEulerAngles                = GetCommaTable(map.cameraRotate)
	self.hasMapInitRot                      = map.cameraRotate ~= ""
	local initRotX                          = self.hasMapInitRot and initRotEulerAngles[1] ~= "" and tonumber(initRotEulerAngles[1]) or self.defRotX
	self.defRotX                            = initRotX
	local initRotY                          = self.hasMapInitRot and initRotEulerAngles[2] ~= "" and tonumber(initRotEulerAngles[2]) or self.targetTransform.eulerAngles.y
	self.defRotY                            = initRotY
	local initRotZ                          = self.hasMapInitRot and initRotEulerAngles[3] ~= "" and tonumber(initRotEulerAngles[3]) or 0
	local destQuaternion                    = Quaternion.Euler(initRotX, initRotY, initRotZ)
	self:GetSceneCameraTransform().rotation = destQuaternion
	--找出摄像机的初始位置，这里是计算出距离后，找到人物身后的一个点
	heightTempVector                        = self.targetTransform.position
	heightTempVector.y                      = heightTempVector.y + modelHeight
	--四元数乘以一个方向距离向量，得到一个对应旋转的方向和距离  再加上一个向量坐标 得到的就是 这个向量坐标往对应方向和距离的延伸点 也就是摄像机所在的位置
	local vector                            = (self:GetSceneCameraTransform().rotation * Vector3.New(0, 0, -self.targetDist)) + heightTempVector
	self:GetSceneCameraTransform().position = vector
end

function CameraNormalBehavior:Update()
	if tolua.isnull(self.targetTransform) then return end
	self:UpdateDist()
	self:AutoRotateToForward()
	--self:AutoRotateToFace() --TODO 屏蔽镜头拉近的近景模式，因为不适合游戏
	self:UpdateCamera()
	self:UpdateCameraPos()
	if self.isDebugRotateAround then
		local sceneCameraTransform    = self:GetSceneCameraTransform()
		sceneCameraTransform.rotation = Quaternion.Euler(sceneCameraTransform.rotation.eulerAngles.x, sceneCameraTransform.rotation.eulerAngles.y + Time.deltaTime * 15, sceneCameraTransform.rotation.eulerAngles.z)
	end
end

local touchDistRate = 0.04
function CameraNormalBehavior:UpdateDist()
	if MovController:IsMoving() then return end
	if not self.sceneCamera.enabledTouchRotate then return end
	local dist = 0
	if IsWindowsPlayer or IsRunInEditor then
		dist = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed
	else
		--多点触摸
		if not IsJoystickMove and Input.touchCount > 1 then
			local touch1      = Input.GetTouch(0)
			local touch2      = Input.GetTouch(1)
			local touchStart1 = touch1.phase == TouchPhase.Stationary or touch1.phase == TouchPhase.Began
			local touchStart2 = touch2.phase == TouchPhase.Stationary or touch2.phase == TouchPhase.Began
			if touchStart1 or touchStart2 then
				tempTouchPos1 = touch1.position
				tempTouchPos2 = touch2.position
				oldTouchPos1  = tempTouchPos1
				oldTouchPos2  = tempTouchPos2
			end

			local touchMove1 = touch1.phase == TouchPhase.Moved
			local touchMove2 = touch2.phase == TouchPhase.Moved
			if (touchMove1 or touchMove2) then
				tempTouchPos1 = touch1.position
				tempTouchPos2 = touch2.position
				local diff    = Vector2.Distance(oldTouchPos1, oldTouchPos2) - Vector2.Distance(tempTouchPos1, tempTouchPos2)
				if diff < 0 and not self.enabledAutoRotateFace then
					dist = touchDistRate * zoomSpeed
				elseif diff > 0 then
					dist = touchDistRate * zoomSpeed * -1
				end
				oldTouchPos1 = tempTouchPos1
				oldTouchPos2 = tempTouchPos2
			end
			local touchEnd1 = touch1.phase == TouchPhase.Ended or touch1.phase == TouchPhase.Canceled
			local touchEnd2 = touch2.phase == TouchPhase.Ended or touch2.phase == TouchPhase.Canceled
			if touchEnd1 or touchEnd2 then
				dist = 0
			end
		end
	end
	--距离缓动
	tempDist         = tempDist - dist
	tempDist         = Mathf.Max(0.1, tempDist)
	local mainPlayer = MainPlayerController:GetPlayer()
	if MainPlayerController:IsMoveState() or (mainPlayer and mainPlayer:IsSkillPlaying()) or AutoBattleController:GetAutoHang() or not SceneController:IsFieldMap() then
		--人物移动过程中，释放技能中，挂机中 不能拉近
		tempDist = Mathf.Clamp(tempDist, self.minDistance + 0.15, self.maxDistance)
	else
		tempDist = Mathf.Clamp(tempDist, self.minDistance, self.maxDistance)
	end
	self.targetDist = Mathf.SmoothStep(self.targetDist, tempDist, 0.3)

end

local temp_camera_eulerAngle = Vector3.zero
local isTouchUIBegan1        = false
local isTouchUIBegan2        = false
local isTouchJoystick1       = false
local isTouchJoystick2       = false
local axisXVelocity          = 0
local axisYVelocity          = 0
local axisXGap               = 0
local axisYGap               = 0

function CameraNormalBehavior:ClearValue()
	temp_camera_eulerAngle = Vector3.zero
	isTouchUIBegan1        = false
	isTouchUIBegan2        = false
	isTouchJoystick1       = false
	isTouchJoystick2       = false
	axisXVelocity          = 0
	axisYVelocity          = 0
	axisXGap               = 0
	axisYGap               = 0
end

function CameraNormalBehavior:UpdateCamera()
	if MovController:IsMoving() then
		self:ClearValue()
		return
	end
	if not self.sceneCamera.enabledTouchRotate then return end
	if IsWindowsPlayer or IsRunInEditor then
		if Input.GetMouseButton(1) then
			axisXGap = Input.GetAxis("Mouse X") * 2
			if self.enabledYRotate then
				axisYGap = Input.GetAxis("Mouse Y") * 2
			end
		elseif Input.GetKeyDown(KeyCode.Q) then
			axisXGap = -2
		elseif Input.GetKeyDown(KeyCode.E) then
			axisXGap = 2
		end
	else
		local touchCount = Input.touchCount
		if touchCount == 1 and not IsJoystickMove then
			local touch = Input.GetTouch(0)
			if not isTouchUIBegan1 and touch.phase == TouchPhase.Began then
				--如果没设置过这个，并且手指没移动，也就是手指第一次触碰屏幕的时候检测下触碰的是不是UI部分
				isTouchUIBegan1 = EventSystem.current:IsPointerOverGameObject(touch.fingerId)
			elseif not isTouchUIBegan1 and touch.phase == TouchPhase.Moved then
				axisXGap = touch.deltaPosition.x * self.touchAxisRate
				if self.enabledYRotate then
					axisYGap = touch.deltaPosition.y * self.touchAxisRate
				end
			end
		end

		if touchCount > 1 and IsJoystickMove then
			local touch1 = Input.GetTouch(0)
			local touch2 = Input.GetTouch(1)
			if not isTouchJoystick1 then
				isTouchJoystick1 = self:_isTouchJoystick(touch1.position)
			end
			if not isTouchJoystick2 then
				isTouchJoystick2 = self:_isTouchJoystick(touch2.position)
			end
			if not isTouchUIBegan1 and not isTouchJoystick2 then
				--如果没设置过这个，并且手指没移动，也就是手指第一次触碰屏幕的时候检测下触碰的是不是UI部分
				isTouchUIBegan1 = EventSystem.current:IsPointerOverGameObject(touch1.fingerId)
			end
			if not isTouchUIBegan2 and not isTouchJoystick1 then
				--如果没设置过这个，并且手指没移动，也就是手指第一次触碰屏幕的时候检测下触碰的是不是UI部分
				isTouchUIBegan2 = EventSystem.current:IsPointerOverGameObject(touch2.fingerId)
			end
			if (not isTouchUIBegan1) and (not isTouchJoystick1) and touch1.phase == TouchPhase.Moved then
				axisXGap = touch1.deltaPosition.x * self.touchAxisRate
				if self.enabledYRotate then
					axisYGap = touch1.deltaPosition.y * self.touchAxisRate
				end
			elseif (not isTouchUIBegan2) and (not isTouchJoystick2) and touch2.phase == TouchPhase.Moved then
				axisXGap = touch2.deltaPosition.x * self.touchAxisRate
				if self.enabledYRotate then
					axisYGap = touch2.deltaPosition.y * self.touchAxisRate
				end
			end
		end
		--当手指抬起，触摸结束后重置一下
		if touchCount == 1 then
			local touch    = Input.GetTouch(0)
			local touchEnd = touch.phase == TouchPhase.Ended or touch.phase == TouchPhase.Canceled
			if touchEnd then
				isTouchUIBegan1  = false
				isTouchJoystick1 = false
				isTouchUIBegan2  = false
				isTouchJoystick2 = false
			end
		end
		if touchCount > 1 then
			local touch1    = Input.GetTouch(0)
			local touchEnd1 = touch1.phase == TouchPhase.Ended or touch1.phase == TouchPhase.Canceled
			if touchEnd1 then
				isTouchUIBegan1  = false
				isTouchJoystick1 = false
			end
			local touch2    = Input.GetTouch(1)
			local touchEnd2 = touch2.phase == TouchPhase.Ended or touch2.phase == TouchPhase.Canceled
			if touchEnd2 then
				isTouchUIBegan2  = false
				isTouchJoystick2 = false
			end
		end
	end

	local sceneCameraTransform = self:GetSceneCameraTransform()
	if axisXGap ~= 0 or axisYGap ~= 0 then
		axisXGap   = Mathf.SmoothDamp(axisXGap, 0, axisXVelocity, Time.fixedDeltaTime * 3.5)
		axisYGap   = Mathf.SmoothDamp(axisYGap, 0, axisYVelocity, Time.fixedDeltaTime * 3.5)
		local rotX = sceneCameraTransform.eulerAngles.x + (rotateVSpeed * Time.unscaledDeltaTime * axisYGap * -1)
		rotX       = ClampAngle(rotX, -30, 60)
		local rotY = sceneCameraTransform.eulerAngles.y + rotateHSpeed * Time.unscaledDeltaTime * axisXGap
		local rotZ = sceneCameraTransform.eulerAngles.z
		temp_camera_eulerAngle:Set(rotX, rotY, rotZ)
		sceneCameraTransform.eulerAngles = temp_camera_eulerAngle
		self:EnabledAutoRotateToForward(false)
		self.isAdjustedRotX  = true
		self.isAdjustingRotY = true
		--如果进入了近景模式，那么动一下角度就不再自动转向了
		if self.enabledAutoRotateFace then
			self.isRotateFaceComplete = true
		end
		if IsShakingCamera then
			sceneCameraTransform:DOKill()
			IsShakingCamera = false
		end
	else
		self.isAdjustingRotY = false
	end

end
local vec_forward = Vector3.forward
function CameraNormalBehavior:UpdateCameraPos()
	local sceneCameraTransform = self:GetSceneCameraTransform()
	--高度缓动
	tempModelHeight            = Mathf.SmoothStep(tempModelHeight, modelHeight, 0.3)
	--距离跟随
	tempTargetPosition         = self.targetTransform.position:Add(Vector3.New(0, tempModelHeight, 0))
	heightTempVector           = Vector3.SmoothDamp(heightTempVector, tempTargetPosition, heightTempVolicity, Time.unscaledDeltaTime)
	tmpBackward.z              = -self.targetDist
	local targetCameraPos      = ((sceneCameraTransform.rotation * tmpBackward)):Add(heightTempVector)
	if self.tweenMode then
		sceneCameraTransform.position = Vector3.Slerp(sceneCameraTransform.position, targetCameraPos, Time.unscaledDeltaTime * 2)
		if CheckVector3Equals(sceneCameraTransform.position, targetCameraPos, 0.02) then
			--缓动完成
			self.tweenMode = false
			if self.onTweenComplete then
				self.onTweenComplete(self.tweenCaller)
				self.tweenCaller     = nil
				self.onTweenComplete = nil
			end
		end
	else
		sceneCameraTransform.position = targetCameraPos
	end
	--射线碰撞检测
	ray.origin            = heightTempVector
	ray.direction         = sceneCameraTransform.position:Sub(heightTempVector)
	rayResult, rayHitInfo = Physics.Raycast(ray, nil, Vector3.Distance(self:GetSceneCameraTransform().position, heightTempVector) + 2)
	if rayResult then
		sceneCameraTransform.position = rayHitInfo.point:Add((self:GetSceneCameraTransform().rotation * vec_forward):Mul(2))
	end
end
local tempForwardEulerAnglesY = 0
function CameraNormalBehavior:AutoRotateToForward(isForce)
	if not isForce and not self.enabledAutoRotateForward then return end
	local rotX
	if not self.isAdjustedRotX then
		local toRotX
		if AutoBattleController:GetAutoHang() then
			toRotX = self.defBattleRotX
		else
			toRotX = self.defRotX
		end
		rotX = Mathf.LerpAngle(self:GetSceneCameraTransform().eulerAngles.x, toRotX, autoRotateForwardTime)
	else
		rotX = self:GetSceneCameraTransform().eulerAngles.x
	end
	local rotY
	if AutoBattleController:GetAutoHang() then
		rotY = self:GetSceneCameraTransform().eulerAngles.y
	else
		if not self.isAdjustingRotY then
			rotY = Mathf.SmoothDampAngle(self:GetSceneCameraTransform().eulerAngles.y, self.targetTransform.eulerAngles.y, tempForwardEulerAnglesY, autoRotateForwardTime, 35)
		else
			rotY = self:GetSceneCameraTransform().eulerAngles.y
		end
	end
	local rotZ                              = self:GetSceneCameraTransform().eulerAngles.z
	self:GetSceneCameraTransform().rotation = Quaternion.Euler(rotX, rotY, rotZ)
end

function CameraNormalBehavior:EnabledAutoRotateToForward(value)
	self.enabledAutoRotateForward = value
end

function CameraNormalBehavior:AutoRotateToFace()
	if self.targetDist > self.minDistance + 0.1 then
		self:EnabledAutoRotateToFace(false)
		self.isRotateFaceComplete = false
	else
		self:EnabledAutoRotateToFace(true)
	end
	if not self.enabledAutoRotateFace then return end
	if self.isRotateFaceComplete then return end
	local rotX                              = Mathf.LerpAngle(self:GetSceneCameraTransform().eulerAngles.x, self.defFaceX, autoRotateFaceTime)
	local targetFaceRotY                    = self.targetTransform.eulerAngles.y + 180
	local rotY                              = Mathf.LerpAngle(self:GetSceneCameraTransform().eulerAngles.y, targetFaceRotY, autoRotateFaceTime)
	local rotZ                              = self:GetSceneCameraTransform().eulerAngles.z
	self:GetSceneCameraTransform().rotation = Quaternion.Euler(rotX, rotY, rotZ)

	if math.abs(rotX - self.defFaceX) >= 360 and math.floor(math.abs(rotY - targetFaceRotY)) == 0 then
		self.isRotateFaceComplete = true
	end

end

function CameraNormalBehavior:EnabledAutoRotateToFace(value)
	if value ~= self.enabledAutoRotateFace then
		self.enabledAutoRotateFace = value
		if value then
			SettingsUtil:EnabledDOF()
			UIManager:HideLayerBeyond()
			self.sceneCamera:CullingMaskWithOutLayer(LayerConsts.LAYER_NAME_UI,
					LayerConsts.LAYER_NAME_NPC,
					LayerConsts.LAYER_NAME_MONSTER,
					LayerConsts.LAYER_NAME_COLLECTION,
					LayerConsts.LAYER_NAME_DROPITEM,
					LayerConsts.LAYER_NAME_PFX,
					LayerConsts.LAYER_NAME_PLAYER,
					LayerConsts.LAYER_NAME_PORTAL,
					LayerConsts.LAYER_NAME_TRAP,
					LayerConsts.LAYER_NAME_PET,
					LayerConsts.LAYER_NAME_HUD
			)
			SceneController:SetHUDEnabled(false)
			if mainPlayer then
				mainPlayer:StopLeisureAnimation()
			end
		else
			SettingsUtil:EnabledDOF(false)
			UIManager:ShowLayerBeyond()
			self.sceneCamera:CullingMaskRestore()
			SceneController:SetHUDEnabled(true)
		end
	end
end

function CameraNormalBehavior:SetMaxDistance(value)
	self.maxDistance = value
	self.maxDistance = math.max(self.maxDistance, self.maxMapDistance)
end

function CameraNormalBehavior:ChangeDistToMax()
	tempDist = self.maxDistance
end

function CameraNormalBehavior:ChangeDistToDefault()
	tempDist = self.defTargetDist
end
function CameraNormalBehavior:ChangeModelHeight(height)
	modelHeight = height + modelHeightGap
end

function CameraNormalBehavior:ExitToFace()
	if self.enabledAutoRotateFace then
		tempDist        = Mathf.Clamp(tempDist, self.minDistance + 0.15, self.maxDistance)
		self.targetDist = tempDist
	end
end

function CameraNormalBehavior:_isTouchJoystick(position)
	local joystick = UIManager:GetUI("JoystickView")
	if joystick and joystick:IsShow() then
		local rangeGO = joystick:GetRangeGameObject()
		if not rangeGO then return false end
		return checkTouchPositionOnGameObject(position, rangeGO)
	end
	return false
end

function CameraNormalBehavior:Destroy()
	self.targetTransform          = nil
	self.enabledAutoRotateForward = false
	self.enabledAutoRotateFace    = false
	self.isRotateFaceComplete     = false
	self.isAdjustedRotX           = false
	self.hasMapInitRot            = false
	CameraNormalBehavior.superclass.Destroy(self)
end