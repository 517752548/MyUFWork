---@class Button
---@field textField UnityEngine.UI.Text
_G.Button = class(UGUIObject)

function Button:ctor(transform)
	self.textField                     = nil
	self.sfxID                         = nil
	self.isPlaySfx                     = true
	self._InitButtonTextFieldComponent = function()
		if not self.transform then return end
		if not self.textField then
			local text = self.transform:GetComponentInChildren(typeof(UnityEngine.UI.Text))
			if text then
				self.textField = Text.New(text.transform)
			else
				--没有普通的Text的时候找TMP
				text           = self.transform:GetComponentInChildren(typeof(TMPro.TextMeshProUGUI))
				if text then
					self.textField = TextMeshProUGUI.New(text.transform)
				end
			end
		end
	end
	self:_InitButtonTextFieldComponent()
end

function Button:GetTextField()
	self:_InitButtonTextFieldComponent()
	if not self.textField then return end
	return self.textField:GetTextField()
end

function Button:SetText(value)
	if not value then return end
	self:_InitButtonTextFieldComponent()
	if not self.textField then return end
	self.textField:SetText(value)
end

function Button:GetText()
	self:_InitButtonTextFieldComponent()
	if not self.textField then return "" end
	return self.textField:GetText()
end

function Button:SetTextColor(color)
	self:_InitButtonTextFieldComponent()
	if not self.textField then return end
	self.textField:SetTextColor(color)
end

function Button:SetEnabled(value, isGray)
	Button.superclass.SetEnabled(self, value, isGray)
	self:_InitButtonTextFieldComponent()
	if not self.textField then return end
	self.textField:SetEnabled(value)
end

function Button:Destroy()
	if self.textField then
		self.textField:Destroy()
	end
	self.textField = nil
	self.sfxID     = nil
	self.isPlaySfx = true
	Button.superclass.Destroy(self)
end

-- 设置音效
function Button:SetSfxID(id)
	self.sfxID = id
end

function Button:IsPlaySfx(val)
	self.isPlaySfx = val
end

-- 播放音效
function Button:PlaySFX()
	if not self.isPlaySfx then return end
	if self.sfxID then
		SoundManager:PlaySFX(self.sfxID)
	else
		SoundManager:PlaySFXExclusive(2020)
	end
end



