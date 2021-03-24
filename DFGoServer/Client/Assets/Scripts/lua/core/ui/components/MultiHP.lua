---@class MultiHP @用来做多血条显示的类，包括血条的初始化以及减血的操作。这个类并不会跟随HybridUI来自动生成出来，这是一个纯操作代理类，所有需要用到的显示对象都需要从外部传进来，使用的时候需要在自己写的lua逻辑中自行创建(New)和销毁(Destroy)
_G.MultiHP = class(UGUIObject)

function MultiHP:ctor()
	self.itemObjectLength        = 0
	self.itemObjectArray         = nil --血条模版，里面存放的是单个血条的UGUIObject, 采用数组存储，直接按下标取就可以
	self.itemCount               = 1
	self.itemValue               = 0
	self.minValue                = 0
	self.maxValue                = 0
	self.value                   = 0
	self.currTweenValue          = 0
	self.currValueRange          = 0
	self.itemCountTextField      = nil
	self.onTweenCompleteCallback = nil
	self.lastTime                = 0
end

function MultiHP:SetItemObjectArray(array)
	if not array then return end
	if #array == 0 then return end
	self.itemObjectArray  = array
	self.itemObjectLength = #array
end

function MultiHP:SetItemCountTextField(textField)
	if not textField then return end
	self.itemCountTextField = textField
end

function MultiHP:SetItemCount(value)
	self.itemCount = math.max(1, value)
	self.itemValue = self.maxValue / self.itemCount
end

function MultiHP:SetMin(value)
	self.minValue = value
end

function MultiHP:SetMax(value)
	self.maxValue       = value
	self.itemValue      = self.maxValue / self.itemCount
	self.currValueRange = self.maxValue * 0.008
end

function MultiHP:SetValue(value, isTween)
	if not value then return end
	self.value = Mathf.Clamp(value, self.minValue, self.maxValue)
	if not isTween then
		self:_UpdateView(self.value)
		self.currTweenValue = self.value
	else
		--self.currValueRange = (self.currTweenValue - self.value) * 0.01
		--self.currValueRange = self.value * 0.001
		self.lastTime = GetCurTime()
		self:RunUpdate()
	end
end

function MultiHP:_GetCurrItemRate(currValue)
	local valueRate = currValue / self.maxValue
	local itemRate  = self.itemCount * valueRate
	return itemRate
end

function MultiHP:_GetItemObjectCurrIndexAndNextIndex(itemRate)
	local itemIndex        = math.ceil(itemRate)

	local currItemObjIndex = (self.itemObjectLength - (itemIndex % self.itemObjectLength)) + 1
	if currItemObjIndex > self.itemObjectLength then currItemObjIndex = 1 end

	local nextItemObjIndex = -1
	nextItemObjIndex       = currItemObjIndex + 1
	if nextItemObjIndex > self.itemObjectLength then nextItemObjIndex = 1 end

	if currItemObjIndex == nextItemObjIndex then
		log("MultiHP 计算血条错误")
	end
	return currItemObjIndex, nextItemObjIndex
end

function MultiHP:_UpdateView(value)
	local itemRate                           = self:_GetCurrItemRate(value)
	local itemIndex                          = math.ceil(itemRate)
	local currItemObjIndex, nextItemObjIndex = self:_GetItemObjectCurrIndexAndNextIndex(itemIndex)
	--log(string.format("当前血量：%s，总血量：%s，总条数：%s，当前条：%s，下一条：%s，当前条进度：%s",
	--		value, self.maxValue, self.itemCount, currItemObjIndex, nextItemObjIndex, 1 - (math.ceil(itemRate) - itemRate)))
	if value <= self.itemValue then
		--最后一条的展示，把next设置为-1
		nextItemObjIndex = -1
	end
	if not self.itemObjectArray then return end
	for i, v in ipairs(self.itemObjectArray) do
		if i == currItemObjIndex or i == nextItemObjIndex then
			v:SetVisible(true)
		else
			v:SetVisible(false)
		end
	end
	if currItemObjIndex > 0 and currItemObjIndex <= self.itemObjectLength then
		local currItemObj = self.itemObjectArray[currItemObjIndex]
		if currItemObj then
			currItemObj:SetAsLastSibling()
			currItemObj:SetProgress(1 - (itemIndex - itemRate))
		end
	end
	if nextItemObjIndex > 0 and nextItemObjIndex <= self.itemObjectLength then
		local nextItemObj = self.itemObjectArray[nextItemObjIndex]
		if nextItemObj then
			nextItemObj:SetAsFirstSibling()
			nextItemObj:SetProgress(1)
		end
	end
	if self.itemCountTextField then
		self.itemCountTextField:SetText(string.format("x %s", itemIndex))
	end
end
local UPDATE_INTERVAL = 0.033
function MultiHP:Update()
	if GetCurTime() - self.lastTime < UPDATE_INTERVAL then
		return
	end
	local range   = self.currValueRange * math.floor((GetCurTime() - self.lastTime) / UPDATE_INTERVAL)
	self.lastTime = GetCurTime()
	if self.currTweenValue > (self.value + range) then
		self.currTweenValue = self.currTweenValue - range
		self:_UpdateView(self.currTweenValue)
	else
		self.currTweenValue = self.value
		self:StopUpdate()
		self:_UpdateView(self.currTweenValue)
		if self.onTweenCompleteCallback then
			self.onTweenCompleteCallback()
			self.onTweenCompleteCallback = nil
		end
	end
end

function MultiHP:SetTweenComplete(func)
	self.onTweenCompleteCallback = func
	if self.currTweenValue == 0 then
		if self.onTweenCompleteCallback then
			self.onTweenCompleteCallback()
			self.onTweenCompleteCallback = nil
		end
	end
end

function MultiHP:Destroy()
	self:StopUpdate()
	self.itemObjectArray         = nil
	self.itemCountTextField      = nil
	self.onTweenCompleteCallback = nil
	MultiHP.superclass.Destroy(self)
end