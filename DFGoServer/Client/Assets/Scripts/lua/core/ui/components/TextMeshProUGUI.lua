---@class TextMeshProUGUI
---@field textField UnityEngine.UI.TextMeshProUGUI
_G.TextMeshProUGUI = class(UGUIObject)

function TextMeshProUGUI:ctor(transform)
	self.textField               = nil
	self.textColor               = nil
	self.oldTextColor            = nil
	self.textGradient            = nil
	self._InitTextFieldComponent = function()
		if not self.transform then return end
		if not self.textField then
			self.textField = self.transform:GetComponent(typeof(TMPro.TextMeshProUGUI))
			if self.textField then
				self.textField.raycastTarget = false
				self.textColor               = self.textField.color
				local uiLocalization         = self.transform:GetComponent(typeof(UILocalizationComponent))
				if uiLocalization then
					local defLocalText  = _T(uiLocalization.key)
					self.textField.text = defLocalText
					self._textStr       = defLocalText
				end
			end
		end
	end
	self._textStr                = nil
	self._enabled                = true
	self:_InitTextFieldComponent()
end

function TextMeshProUGUI:GetTextField()
	self:_InitTextFieldComponent()
	return self.textField
end

function TextMeshProUGUI:SetText(value)
	if not value then return end
	self:_InitTextFieldComponent()
	if not self.textField then return end
	if self._textStr == value then return end
	self.textField.text = value
	self._textStr       = value
end

function TextMeshProUGUI:GetText()
	self:_InitTextFieldComponent()
	if not self.textField then return "" end
	return self.textField.text
end

function TextMeshProUGUI:GetPreferredSize()
	self:_InitTextFieldComponent()
	if not self.textField then
		return 0, 0
	end
	LayoutRebuilder.ForceRebuildLayoutImmediate(self.transform)
	return self.textField.preferredWidth, self.textField.preferredHeight
end

function TextMeshProUGUI:SetTextColor(color)
	self:_InitTextFieldComponent()
	if not self.textField then return end
	if type(color) == 'string' then
		local bin_color      = htmlStringToColor(color)
		self.textField.color = bin_color
		self.textColor       = bin_color
	else
		self.textField.color = color
		self.textColor       = color
	end
end

--@RefType 设置图片的透明度(0-1)
function TextMeshProUGUI:SetAlpha(num)
	self:_InitTextFieldComponent()
	if not self.textField then return end
	local color          = self.textField.color
	color.a              = num
	self.textField.color = color
end

function TextMeshProUGUI:SetFontSize(value)
	self:_InitTextFieldComponent()
	if not self.textField then return end
	self.textField.fontSize = value
end

-- 对齐方式
function TextMeshProUGUI:SetAlignment(value)
	self:_InitTextFieldComponent()
	if not self.textField then return end
	self.textField.alignment = value
end

function TextMeshProUGUI:SetEnabled(value)
	self:_InitTextFieldComponent()
	if not self.textField then return end
	if self._enabled ~= value then
		if value then
			if self.oldTextColor then
				self:SetTextColor(self.oldTextColor)
			else
				self:SetTextColor(self.textColor)
			end
		else
			self.oldTextColor = self.textField.color
			self:SetTextColor('#575757')
		end
		self._enabled = value
	end
end

-- 渐变
function TextMeshProUGUI:_InitTextGradientComponent()
	if not self.transform then
		return
	end
	if not self.textGradient then
		self.textGradient = self.transform:GetComponent("UICustomTextGradient")
	end
end

function TextMeshProUGUI:SetGradientColor(topColor, bottomColor)
	if not topColor or not bottomColor then
		return
	end
	self:_InitTextGradientComponent()
	if not self.textGradient then
		return
	end

	if type(topColor) == "string" then
		local top_color            = htmlStringToColor(topColor)
		self.textGradient.topColor = top_color
	else
		self.textGradient.topColor = topColor
	end

	if type(bottomColor) == "string" then
		local bottom_color            = htmlStringToColor(bottomColor)
		self.textGradient.bottomColor = bottom_color
	else
		self.textGradient.bottomColor = bottomColor
	end
end

function TextMeshProUGUI:SetGradientEnable(value)
	self:_InitTextGradientComponent()
	if not self.textGradient then
		return
	end

	self.textGradient.enabled = value
end

-- 轮廓 外发光
function TextMeshProUGUI:_InitOutlineComponent()
	if not self.transform then
		return
	end
	if not self.outline then
		self.outline = self.transform:GetComponent(typeof(UnityEngine.UI.Outline))
	end
end

function Text:SetOutlineEnable(value)
	self:_InitOutlineComponent()
	if not self.outline then
		return
	end

	self.outline.enabled = value
end

function TextMeshProUGUI:SetOutlineColor(color)
	self:_InitOutlineComponent()
	if not self.outline then
		return
	end
	if type(color) == "string" then
		self.outline.effectColor = htmlStringToColor(color)
	else
		self.outline.effectColor = color
	end
end

function TextMeshProUGUI:SetResizeTextForBestFit(value)
	self:_InitTextFieldComponent()
	if not self.textField then
		return
	end
	self.textField.resizeTextForBestFit = value
end

function TextMeshProUGUI:Destroy()
	self.textField    = nil
	self.textColor    = nil
	self.oldTextColor = nil
	self.textGradient = nil
	self._textStr     = nil
	self._enabled     = true
	Text.superclass.Destroy(self)
end