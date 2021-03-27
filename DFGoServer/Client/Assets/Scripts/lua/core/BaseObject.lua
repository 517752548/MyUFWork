---@class BaseObject @这是作为lua脚本层面最基础的一个类，这里提供了基础的Update，LateUpdate，FixedUpdate三个方法的回调
_G.BaseObject = class()

function BaseObject:ctor()
	self.updateKey     = nil
	self.lateUpdateKey = nil
end

function BaseObject:RunUpdate(delay)
	delay = delay or 0
	TimerManager:RemoveTimer(self.updateKey)
	self.updateKey = TimerManager:AddTimer(function()
		self:Update()
	end, delay, 0)
end

function BaseObject:StopUpdate()
	TimerManager:RemoveTimer(self.updateKey)
	self.updateKey = nil
end

---@return nil @由子类覆盖
function BaseObject:Update()

end

function BaseObject:RunLateUpdate()
	TimerManager:RemoveLateTimer(self.lateUpdateKey)
	self.lateUpdateKey = TimerManager:AddLateTimer(function()
		self:LateUpdate()
	end, 0, 0)
end

function BaseObject:StopLateUpdate()
	TimerManager:RemoveLateTimer(self.lateUpdateKey)
	self.lateUpdateKey = nil
end

---@return nil @由子类覆盖
function BaseObject:LateUpdate()

end

function BaseObject:Destroy()
	self:StopUpdate()
	self:StopLateUpdate()
end