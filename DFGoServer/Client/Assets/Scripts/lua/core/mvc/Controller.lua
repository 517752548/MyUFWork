_G.Controller = class(BaseObject)

function Controller:ctor()
	self.facade  = nil
	self.enabled = true
end

--subclass override
function Controller:Create()
	--注册对应的消息
end

function Controller:SetEnabled(value)
	self.enabled = value
end

function Controller:GetEnabled()
	return self.enabled
end

function Controller:AddNotification(name, obj, func)
	self.facade:AddNotification(name, obj, func)
end

function Controller:RemoveNotification(name, obj, func)
	self.facade:RemoveNotification(name, obj, func)
end

function Controller:SendNotification(name, body)
	self.facade:SendNotification(name, body)
end
--subclass override
function Controller:OnEnterGame() end
--subclass override
function Controller:OnChangeSceneMap() end
--subclass override
function Controller:OnLeaveSceneMap() end
--subclass override
function Controller:OnLogoutGame() end
--subclass override
function Controller:OnReconnectGame() end

function Controller:OnEnterHome() end