---
--- Created by Yanghongbin.
--- DateTime: 2017/7/8 17:18
---

_G.FunctionQueue = class()
function FunctionQueue:ctor()
	self.idCounter = 0
	self.queue = {}
	self.isExecuting = false
	self.executingId = 0
	self.onComplete = nil
end

function FunctionQueue:GetQueueCount()
	return #self.queue
end

function FunctionQueue:Add(func, ...)
	local item = {}
	self.idCounter = self.idCounter + 1
	item.id = self.idCounter
	item.func = func
	item.args = { ... }
    table.insert(self.queue, item)
	return item.id
end

function FunctionQueue:Execute()
	if not self.isExecuting then
		self:_ExecuteOne()
	end
end

function FunctionQueue:_ExecuteOne()
	if self.queue and #self.queue > 0 then
		self.isExecuting = true
		local item = self.queue[1]
		self.executingId = item.id --记录当前执行的id
		item.func(self, item.args)
	end
end

function FunctionQueue:ExecuteNext()
	self.isExecuting = false
	local item
	if self.queue and #self.queue > 0 then
		if self.queue[1].id == self.executingId then
			item = self.queue[1]
		end
	end
	if not item then
		return
	end
	item.id = 0
	item.func = nil
	item.args = nil
	--移除第一个
	table.remove(self.queue, 1)
	self.executingId = 0
	--全部执行完调用回调
	if #self.queue == 0 then
		if self.onComplete then
			self.onComplete()
			self.onComplete = nil
			self:Destroy()
		end
		return
	end
	--执行下一个
	self:_ExecuteOne()
end

function FunctionQueue:Destroy()
	self.isExecuting = false
	self.queue = nil
	self.onComplete = nil
end