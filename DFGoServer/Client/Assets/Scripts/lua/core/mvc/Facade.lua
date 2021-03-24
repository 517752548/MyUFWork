_G.Facade = class()

function Facade:ctor()
	self.controllerList = {}
	self.notifier       = Notification.New()
end

function Facade:AddController(controller)
	table.insert(self.controllerList, controller)
	controller.facade = self
	controller:Create()
end

function Facade:GetAllController()
	return self.controllerList
end

function Facade:AddNotification(name, obj, func)
	return self.notifier:Add(name, obj, func)
end

function Facade:RemoveNotification(name, obj, func)
	return self.notifier:Remove(name, obj, func)
end

function Facade:SendNotification(name, body)
	self.notifier:SendNotification(name, body)
end