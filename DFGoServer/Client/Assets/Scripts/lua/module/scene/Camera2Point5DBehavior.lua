_G.Camera2Point5DBehavior = class(CameraNormalBehavior)

function Camera2Point5DBehavior:ctor()
end

function Camera2Point5DBehavior:GetType()
	return SceneCameraBehavior.T_2POINT5D
end

function Camera2Point5DBehavior:Init(sceneCamera)
	self.enabledYRotate = false
	self.defRotX        = 25
	self.targetDist     = self.maxDistance
	Camera2Point5DBehavior.superclass.Init(self, sceneCamera)
end

--覆盖父类的方法，让2.5D视角下不开启近距离看脸模式
function Camera2Point5DBehavior:EnabledAutoRotateToFace(value)
end