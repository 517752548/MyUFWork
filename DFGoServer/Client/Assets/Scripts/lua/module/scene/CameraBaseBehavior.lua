_G.CameraBaseBehavior = class()

function CameraBaseBehavior:ctor()
	self.sceneCamera     = nil
	self.tweenMode       = false
	self.tweenCaller     = nil
	self.onTweenComplete = nil
	self.sceneCameraTSF  = nil
end

function CameraBaseBehavior:GetType()

end

function CameraBaseBehavior:Init(sceneCamera)
	self.sceneCamera = sceneCamera
	if self.sceneCamera and self.sceneCamera.go then
		self.sceneCameraTSF = self.sceneCamera.go.transform
	end
end

function CameraBaseBehavior:GetSceneCameraTransform()
	return self.sceneCameraTSF
end

function CameraBaseBehavior:Update()

end

function CameraBaseBehavior:LateUpdate()

end

function CameraBaseBehavior:ChangeModelHeight(height)
end

function CameraBaseBehavior:Exit()
	self:Destroy()
end

function CameraBaseBehavior:Destroy()
	self.sceneCamera     = nil
	self.tweenMode       = false
	self.tweenCaller     = nil
	self.onTweenComplete = nil
end