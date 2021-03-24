_G.Model = class()

function Model:ctor()
	self.facade = GameApp.facade
end
function Model:AddNotification(name, obj, func)
	self.facade:AddNotification(name, obj, func)
end

function Model:RemoveNotification(name, obj, func)
	self.facade:RemoveNotification(name, obj, func)
end

function Model:SendNotification(name, body)
	self.facade:SendNotification(name, body)
end