---@class Pagination @可用于翻页，或者带有加号减号的数字输入框
_G.Pagination = class(UGUIObject)

function Pagination:ctor(transform)
	self.btnMinimum         = nil
	self.btnMaximum         = nil
	self.btnPlus            = nil
	self.btnMinus           = nil
	self.btnNum             = nil
	self.minimumValue       = 0
	self.maximumValue       = 9999
	self.currValue          = nil
	self.stepValue          = 1
	self._onValueChangeBack = nil
	self._allEnabled        = true
end

function Pagination:SetMinimumButton(button)
	if not button then return end
	self.btnMinimum = button
	self.btnMinimum:SetSfxID(2031)
	self.btnMinimum:OnClick(function()
		self:OnBtnMinimumClick()
	end)
end

function Pagination:SetMaximumButton(button)
	if not button then return end
	self.btnMaximum = button
	self.btnMaximum:SetSfxID(2031)
	self.btnMaximum:OnClick(function()
		self:OnBtnMaximumClick()
	end)
end

function Pagination:SetPlusButton(button)
	if not button then return end
	self.btnPlus = button
	self.btnPlus:SetSfxID(2031)
	self.btnPlus:OnClick(function()
		self:OnBtnPlusClick()
	end)
end

function Pagination:SetMinusButton(button)
	if not button then return end
	self.btnMinus = button
	self.btnMinus:SetSfxID(2031)
	self.btnMinus:OnClick(function()
		self:OnBtnMinusClick()
	end)
end

---@param Button @设置要显示数字的可点击的button
function Pagination:SetNumberButton(button)
	if not button then return end
	self.btnNum = button
	self:SetNumKeyBoardEnabled(true)
end

function Pagination:SetNumKeyBoardEnabled(value)
	if value then
		if not self.btnNum then return end
		self.btnNum:OnClick(function()
			NumKeyboardUtil:ShowKeyBoard(self.maximumValue, function(num)
				self:SetValue(num)
			end)
		end)
	else
		if not self.btnNum then return end
		self.btnNum:OnClick(nil)
	end
end
---@return nil @设置最小值，注意一定要在SetValue前赋值使用
function Pagination:SetMinimumValue(value)
	if not value then
		return
	end
	self.minimumValue = math.min(value, self.maximumValue)
	self:SetValue(self.minimumValue, true)
end

---@return nil @设置最大值，注意一定要在SetValue前赋值使用
function Pagination:SetMaximumValue(value)
	if not value then
		return
	end
	self.maximumValue = value
end

function Pagination:SetStepValue(value)
	if not value then
		return
	end
	self.stepValue = value
end

function Pagination:OnBtnMinimumClick()
	self:SetValue(self.minimumValue)
end
function Pagination:OnBtnMaximumClick()
	self:SetValue(self.maximumValue)
end
function Pagination:OnBtnPlusClick()
	self:SetValue(self:GetNextValue())
end
function Pagination:OnBtnMinusClick()
	self:SetValue(self:GetPrevValue())
end

function Pagination:SetValue(value, notTriggerCallback)
	if not value then
		return
	end
	self.currValue = Mathf.Clamp(value, self.minimumValue, self.maximumValue)
	if self.btnNum then
		self.btnNum:SetText(self.currValue)
	end
	self:UpdateButtonsEnabled()
	if not notTriggerCallback and self._onValueChangeBack then
		self._onValueChangeBack(self.currValue)
	end
end

function Pagination:OnValueChange(func)
	self._onValueChangeBack = func
end

function Pagination:GetValue()
	if self.btnNum then
		return toint(self.btnNum:GetText())
	end
	return self.currValue or 0
end

---@return number,number @获得当前页数
function Pagination:GetPage()
	return math.ceil(self.currValue / self.stepValue)
end

function Pagination:GetNextValue()
	return Mathf.Clamp(self.currValue + self.stepValue, self.minimumValue, self.maximumValue)
end

function Pagination:GetPrevValue()
	return Mathf.Clamp(self.currValue - self.stepValue, self.minimumValue, self.maximumValue)
end

function Pagination:UpdateButtonsEnabled()
	if not self._allEnabled then return end
	if self.btnMinus then
		self.btnMinus:SetEnabled(self.currValue > self.minimumValue)
	end
	if self.btnPlus then
		self.btnPlus:SetEnabled(self.currValue < self.maximumValue)
	end
end

function Pagination:SetEnabled(value)
	self._allEnabled = value
	if self.btnMinus then
		if self.btnMinus:GetEnabled() then
			self.btnMinus:SetEnabled(value)
		end
	end
	if self.btnPlus then
		if self.btnPlus:GetEnabled() then
			self.btnPlus:SetEnabled(value)
		end
	end
	if self.btnMinimum then
		self.btnMinimum:SetEnabled(value)
	end
	if self.btnMaximum then
		self.btnMaximum:SetEnabled(value)
	end
	if self.btnNum then
		self.btnNum:SetEnabled(value)
	end
end

function Pagination:Destroy()
	--因为这个组件是属于组合包装的模式。所以在Destroy的时候只需要将引用清空即可，各自的组件会在其他地方自行Destroy。这里不再调用
	self.btnMinimum         = nil
	self.btnMaximum         = nil
	self.btnPlus            = nil
	self.btnMinus           = nil
	self.btnNum             = nil
	self.minimumValue       = 1
	self.maximumValue       = 9999
	self.currValue          = nil
	self.stepValue          = 1
	self._onValueChangeBack = nil
	Pagination.superclass.Destroy(self)
end