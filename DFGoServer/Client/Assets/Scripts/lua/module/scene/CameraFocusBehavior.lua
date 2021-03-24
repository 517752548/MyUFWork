_G.CameraFocusBehavior = class(CameraBaseBehavior)

function CameraFocusBehavior:ctor()
	self.targetTransform      = nil
	self.targetFocusTransform = nil

	self.targetDist           = 6
	self.maxDistance          = 12
	self.minDistance          = 2
end

function CameraFocusBehavior:GetType()
	return SceneCameraBehavior.FOCUS
end

local heightTempVector      = Vector3.New()
local heightTempVolicity    = Vector3.New()
local tmpBackward           = Vector3.zero
local modelHeight           = 0        --模型高度
local ray                   = Ray.New(Vector3.one, Vector3.down)
local rayResult, rayHitInfo = false, nil

function CameraFocusBehavior:Init(sceneCamera)
	CameraFocusBehavior.superclass.Init(self, sceneCamera)
	modelHeight = t_playerinfo[MainPlayerController:GetProfID()].height
end

function CameraFocusBehavior:LateUpdate()
	self:UpdateCamera()
end
function CameraFocusBehavior:UpdateCamera()
	local sceneCameraTransform    = self:GetSceneCameraTransform()

	local rotX                    = sceneCameraTransform.eulerAngles.x
	local rotY                    = GetDirTwoPoint(self.targetTransform.position, self.targetFocusTransform.position)
	local rotZ                    = sceneCameraTransform.eulerAngles.z

	sceneCameraTransform.rotation = Quaternion.Euler(rotX, rotY, rotZ)
	--距离跟随
	local targetPosition          = self.targetTransform.position
	targetPosition.y              = targetPosition.y + modelHeight
	heightTempVector              = Vector3.SmoothDamp(heightTempVector, targetPosition, heightTempVolicity, Time.unscaledDeltaTime);
	tmpBackward.z                 = -self.targetDist
	local targetCameraPos         = ((sceneCameraTransform.rotation * tmpBackward)) + heightTempVector;
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
	ray.direction         = sceneCameraTransform.position - heightTempVector
	rayResult, rayHitInfo = Physics.Raycast(ray, nil, Vector3.Distance(self:GetSceneCameraTransform().position, heightTempVector) + 2)
	if rayResult then
		sceneCameraTransform.position = rayHitInfo.point + (self:GetSceneCameraTransform().rotation * Vector3.forward) * 2
	end
end
function CameraFocusBehavior:Destroy()
	self.targetTransform      = nil
	self.targetFocusTransform = nil
	CameraFocusBehavior.superclass.Destroy(self)
end