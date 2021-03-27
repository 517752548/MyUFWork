_G.CameraOrthographicBehavior = class(CameraBaseBehavior)

function CameraOrthographicBehavior:ctor()
end

function CameraOrthographicBehavior:GetType()
	return SceneCameraBehavior.ORTHOGRAPHIC
end

function CameraOrthographicBehavior:Init(sceneCamera)
	CameraOrthographicBehavior.superclass.Init(self, sceneCamera)
	if self.sceneCamera and self.sceneCamera:GetCamera() then
		self.sceneCamera:GetCamera().orthographic = true
	end
end

function CameraOrthographicBehavior:SetOrthographicSize(value)
	if self.sceneCamera and self.sceneCamera:GetCamera() then
		self.sceneCamera:GetCamera().orthographicSize = value
	end
end

function CameraOrthographicBehavior:Update()
end

function CameraOrthographicBehavior:Destroy()
	CameraOrthographicBehavior.superclass.Destroy(self)
end