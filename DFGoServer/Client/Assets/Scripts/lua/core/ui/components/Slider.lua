---@class Slider
---@field slider UnityEngine.UI.Slider
---@field minValue number
---@field maxValue number
_G.Slider = class(UGUIObject)

function Slider:ctor(transform)
	self.slider                 = nil
	self.minValue               = 0
	self.maxValue               = 1
	self.onValueChangedCallBack = nil
end

function Slider:_InitSliderComponent()
	if not self.transform then return end
	if not self.slider then
		self.slider = self.transform:GetComponent("Slider")
		self.slider.onValueChanged:RemoveAllListeners()
		self.slider.onValueChanged:AddListener(function()
			if self.onValueChangedCallBack then
				self.onValueChangedCallBack(self:GetValue())
			end
		end)
	end
end

function Slider:SetMin(value)
	self.minValue = value
end

function Slider:SetMax(value)
	self.maxValue = value
end

function Slider:SetWholeNumbers(value)
	self:_InitSliderComponent()
	if not self.slider then return end
	self.slider.wholeNumbers = value
end

function Slider:GetValue()
	self:_InitSliderComponent()
	if not self.slider then return 0 end
	return self.slider.value
end

function Slider:SetValue(value)
	self:_InitSliderComponent()
	if not self.slider then return end
	value = Mathf.Clamp(value, self.minValue, self.maxValue)
	if self.slider.minValue ~= self.minValue then
		self.slider.minValue = self.minValue
	end
	if self.slider.maxValue ~= self.maxValue then
		self.slider.maxValue = self.maxValue
	end
	--在UnityEngine.UI.Slider里，如果设置的value和原有的相同，是不会触发回调的，所以这里自己处理了一下，使得即便数值一样，也触发回调，因为第一次设置的时候默认值是0，再设置了0就不会触发回调了
	if self.slider.value == value then
		if self.onValueChangedCallBack then
			self.onValueChangedCallBack(self:GetValue())
		end
	else
		self.slider.value = value
	end
end

function Slider:GetProgress()
	return self:GetValue() / self.maxValue
end

function Slider:SetProgress(percent)
	percent = Mathf.Clamp01(percent)
	self:SetValue(percent * self.maxValue)
end

function Slider:OnValueChanged(func)
	self:_InitSliderComponent()
	if not self.slider then return end
	self.onValueChangedCallBack = func
end

function Slider:Destroy()
	if self.slider then
		self.slider.onValueChanged:RemoveAllListeners()
	end
	self.slider                 = nil
	self.onValueChangedCallBack = nil
	Slider.superclass.Destroy(self)
end