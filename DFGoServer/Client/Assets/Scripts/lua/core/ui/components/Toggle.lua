---@class Toggle
---@field toggle UnityEngine.UI.Toggle
_G.Toggle = class(Button)

function Toggle:ctor(transform)
	self.toggle                 = nil
	self._toggleIndex           = 0
	self.onValueChangedCallBack = nil
	self.isOn                   = false
	self.lastIsOn               = false
	self.codeTriggerFlag        = false

end

function Toggle:_InitToggleComponent()
	if not self.toggle then
		self.toggle = self:GetComponent(UnityEngine.UI.Toggle)
		if self.toggle then
			self.toggle.group = nil --这里把Unity编辑器中挂上的group解除，不需要
			self.toggle.onValueChanged:RemoveAllListeners()
			self.toggle.onValueChanged:AddListener(function(isOn)
				self.isOn = isOn
				self:_ExecCallBacks()
			end)
		end
	end
end

function Toggle:_ExecCallBacks()
	if self.onValueChangedCallBack then
		if self.isOn and not self.codeTriggerFlag and self.isPlaySfx then
			if self.sfxID then
				SoundManager:PlaySFXExclusive(self.sfxID)
			else
				SoundManager:PlaySFXExclusive(2006)
			end
		end
		if not self.codeTriggerFlag then
			--GuideScriptManager:HideFrame() --TODO GUIDE 这里只要点击任何按钮就把引导框给删除
		end
		self.onValueChangedCallBack(self:GetIsOn())
		self.codeTriggerFlag = false
	end
end

function Toggle:SetIsOn(value)
	self.codeTriggerFlag = true
	self:_InitToggleComponent()
	if not self.toggle then return end
	--这里为了保证，设置了一个相同的值以后，也能保证调用回调
	if self.isOn == value then
		self:_ExecCallBacks()
	end
	self.isOn            = value
	self.toggle.isOn     = value
	--如果没有进入到_ExecCallBacks中的话，会导致声音放不出来了  那需要把codeTriggerFlag给强制设置为false
	self.codeTriggerFlag = false
end

function Toggle:GetIsOn()
	return self.isOn
end

function Toggle:SetLastIsOn(value)
	self.lastIsOn = value
end

function Toggle:GetLastIsOn()
	return self.lastIsOn
end

function Toggle:SetIndex(value)
	Toggle.superclass.SetIndex(self, value)
	self._toggleIndex = value
end

function Toggle:GetIndex()
	return self._toggleIndex
end

function Toggle:SetInteractable(value)
	self:_InitToggleComponent()
	if not self.toggle then return end
	self.toggle.interactable = value
end

function Toggle:HasUGUIToggleGroup()
	self:_InitToggleComponent()
	if not self.toggle then return end
	return self.toggle.group and true or false
end

function Toggle:OnValueChanged(func)
	self:_InitToggleComponent()
	self.onValueChangedCallBack = func
end

function Toggle:Destroy()
	if self.toggle then
		self.toggle.onValueChanged:RemoveAllListeners()
	end
	self.toggle                 = nil
	self.onValueChangedCallBack = nil
	self.isOn                   = false
	self.lastIsOn               = false
	self.codeTriggerFlag        = false
	Toggle.superclass.Destroy(self)
end