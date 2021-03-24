---@class ToggleGroup
---@field children table @table<Toggle>
_G.ToggleGroup = class(UGUIObject)

function ToggleGroup:ctor(transform)
	self.internalMode               = false --内部模式，打开了这个，所有回调都不会触发，只是为了初始化ToggleGroup使用
	self.children                   = nil
	self.onSelectedCallBack         = nil
	self.lastSelectedIndex          = 0
	self.currSelectedIndex          = 0
	self.allowAllOff                = false
	self.allowRepeatSelected        = false
	self.allowMultiSelected         = false
	self.onAllOffCallBack           = nil
	self.onItemValueChangedCallback = nil
end

function ToggleGroup:SetInternalMode(value)
	self.internalMode = value
end

---@param value boolean @是否允许所有的toggle都为不选中,true可以在toggle为选中状态的情况下将其变为不选中，false整个ToggleGroup中必须有一个toggle为选中，默认值false
function ToggleGroup:AllowAllOff(value)
	self.allowAllOff = value
end

---@param value boolean @是否允许重复选中同一个toggle，true可以重复触发OnSelectedItem，false只有当toggle的状态从false变为true的时候触发一次OnSelectedItem，默认值false
function ToggleGroup:AllowRepeatSelected(value)
	self.allowRepeatSelected = value
end

---@param value boolean @是否允许多选，true多选，false单选，默认值为false
function ToggleGroup:AllowMultiSelected(value)
	self.allowMultiSelected = value
end

function ToggleGroup:AddToggle(toggle, insertHead, notCalcIndex)
	if not toggle:GetComponent(UnityEngine.UI.Toggle) then
		return
	end
	if not self.children then
		self.children = {}
	end
	if insertHead then
		table.insert(self.children, 1, toggle)
	else
		table.insert(self.children, toggle)
	end
	toggle:SetIsOn(false)
	if not notCalcIndex then
		self:_CalcAllToggleIndex()
	end
	toggle:OnValueChanged(function(isOn)
		if self.internalMode then return end
		--这个函数必然会调用一下
		if self.onItemValueChangedCallback then
			self.onItemValueChangedCallback(toggle)
		end
		if self.allowMultiSelected then
			if self.onSelectedCallBack then
				self.onSelectedCallBack(toggle)
			end
			--记录一下作为上一次的点击状态,在OnSelectedCallBack之后
			toggle:SetLastIsOn(isOn)
		else
			if isOn then
				self:_SelectOne(toggle, false)
				if self.allowRepeatSelected or self.currSelectedIndex ~= toggle:GetIndex() then
					self.lastSelectedIndex = self.currSelectedIndex
					self.currSelectedIndex = toggle:GetIndex()
					if self.onSelectedCallBack then
						self.onSelectedCallBack(toggle)
					end
					--记录一下作为上一次的点击状态,在OnSelectedCallBack之后
					toggle:SetLastIsOn(isOn)
				end
			else
				local hasOn = false
				--不能全部不选择
				for i, v in pairs(self.children) do
					if v:GetIsOn() then
						hasOn = true
					end
				end
				if not self.allowAllOff then
					if not hasOn then
						toggle:SetLastIsOn(true)
						toggle:SetIsOn(true)
					end
				else
					if not hasOn then
						self.currSelectedIndex = 0
						if self.onAllOffCallBack then
							self.onAllOffCallBack()
						end
					end
				end
				toggle:SetLastIsOn(false)
			end
		end
	end)
end

function ToggleGroup:_CalcAllToggleIndex()
	for i, toggle in pairs(self.children) do
		if toggle then
			toggle:SetIndex(i)
		end
	end
end

function ToggleGroup:GetAllToggle()
	return self.children
end

function ToggleGroup:GetToggle(index)
	if not self.children then return end
	if index > #self.children then return end
	if index < 1 then return end
	return self.children[index]
end

function ToggleGroup:RemoveToggle(toggle)
	if not self.children then return end
	for i, v in pairs(self.children) do
		if v == toggle then
			table.remove(self.children, i)
			return
		end
	end
end

function ToggleGroup:RemoveAllToggle()
	self.children     = nil
	self.internalMode = false
	self:ClearSelectedIndex()
end

function ToggleGroup:_SelectOne(toggle, force)
	if not self.children then return end
	for i, v in pairs(self.children) do
		local isOn = v:GetIsOn()
		if v == toggle then
			if force or isOn ~= true then
				v:SetIsOn(true)
			end
			break
		end
	end
	if not self.allowMultiSelected then
		for i, v in pairs(self.children) do
			if v ~= toggle then
				local isOn = v:GetIsOn()
				if isOn ~= false then
					if not v:HasUGUIToggleGroup() then
						v:SetIsOn(false)
					end
				end
			end
		end
	end
end

function ToggleGroup:SelectByToggle(toggle)
	self.currSelectedIndex = 0
	self:_SelectOne(toggle, true)
end

function ToggleGroup:SelectByIndex(index)
	if not self.children then return end
	self:SelectByToggle(self.children[index])
end

function ToggleGroup:GetSelectedToggle()
	if not self.children then
		return
	end
	
	for i, v in pairs(self.children) do
		if v then
			if v:GetIsOn() then
				return v
			end
		end
	end
end

function ToggleGroup:GetSelectedIndex()
	return self.currSelectedIndex
end

function ToggleGroup:GetLastSelectedIndex()
	return self.lastSelectedIndex
end

---@param func function @当选择了某一个toggle时候触发，只会在切换为选中的情况下触发一次，如果AllowRepeatSelected(true)那么已经选中的toggle再次点击，就可以重复触发这个回调，如果AllowRepeatSelected(false)那么只有toggle从false变为true的时候才会触发一次这个回调
function ToggleGroup:OnSelectedItem(func)
	self.onSelectedCallBack = func
end
---@param func function @当某一个toggle状态产生改变的时候回触发这个回调，注意，只要是状态做了切换就必然会调用这个，比如有Toggle A,B,C，AllowMultiSelected(false)。当选中A以后，会触发三次这个回调，因为会自动将B,C设置为设置为不选中
function ToggleGroup:OnItemValueChanged(func)
	self.onItemValueChangedCallback = func
end

---@return nil @清空所有的选择
function ToggleGroup:ClearAllSelected()
	--if not self.allowAllOff then return end
	if not self.children then return end
	for i, v in pairs(self.children) do
		v:SetIsOn(false)
	end
	self.currSelectedIndex = 0
end

function ToggleGroup:ClearSelectedIndex()
	self.currSelectedIndex = 0
end
---@param func function @当所有toggle都变为未选中状态的时候，触发这个回调 前提是AllowAllOff(true)
function ToggleGroup:OnAllOff(func)
	self.onAllOffCallBack = func
end

function ToggleGroup:Destroy()
	self:RemoveAllToggle()
	self.internalMode       = false
	self.children           = nil
	self.onSelectedCallBack = nil
	self.onAllOffCallBack   = nil
	ToggleGroup.superclass.Destroy(self)
end