---@class ProgressBar
---@field image UnityEngine.UI.Image
---@field textField UnityEngine.UI.Text
---@field OnValueChangedFunc function
---@field minValue number
---@field maxValue number
_G.ProgressBar = class(UGUIObject)

function ProgressBar:ctor(transform)
	self.image              = nil
	self.followImage        = nil
	self.textField          = nil
	self.onValueChangedFunc = nil
	self.minValue           = 0
	self.maxValue           = 1
	self.DIFValue           = 0   ----左右像素差
end

function ProgressBar:_InitProgressImageComponent()
	if not self.transform then
		return
	end
	if not self.image then
		local progressTSF = self.transform:Find("progress")
		if tolua.isnull(progressTSF) then return end
		self.image = progressTSF:GetComponent("Image")
	end
end

function ProgressBar:_InitTextFieldComponent()
	if not self.transform then
		return
	end
	if not self.textField then
		self.textField = self.transform:GetComponentInChildren(typeof(UnityEngine.UI.Text))
	end
end

function ProgressBar:_InitFollowImageComponent()
	self:_InitProgressImageComponent()
	if not self.image then
		return
	end
	if not self.followImage then
		self.followImage = self.image.transform:Find("Follow")
	end
end

function ProgressBar:SetMin(value)
	self.minValue = value
end

function ProgressBar:SetMax(value)
	self.maxValue = value
end

function ProgressBar:SetText(value)
	if not value then
		return
	end
	self:_InitTextFieldComponent()
	if not self.textField then
		return
	end
	self.textField.text = value
end

function ProgressBar:SetDIFValue(value)
	self.DIFValue = value
end

function ProgressBar:SetFollowImgPos(value)
	if not value then
		return
	end
	self:_InitFollowImageComponent()
	if not self.followImage then
		return
	end
	local barWidth = self.transform.rect.width
	if self.maxValue == 0 then return end
	local per  = value / self.maxValue
	local half = barWidth / 2
	local posX = -half + per * barWidth
	if posX <= -half + self.DIFValue then
		posX = -half + self.DIFValue
	elseif posX >= half - self.DIFValue then
		posX = half - self.DIFValue
	end
	self.followImage.transform.localPosition = Vector3.New(posX, 0, 0)
end

function ProgressBar:GetValue()
	return self:GetProgress() * self.maxValue
end

function ProgressBar:SetValue(value, time, isFilp, easeType)
	if not value then
		return
	end
	self:_InitProgressImageComponent()
	if not self.image then
		return
	end
	value = Mathf.Clamp(value, self.minValue, self.maxValue)
	self:SetProgress(value / self.maxValue, time, isFilp, easeType)
end

function ProgressBar:GetProgress()
	self:_InitProgressImageComponent()
	if not self.image then
		return 0
	end
	return self.image.fillAmount
end

function ProgressBar:SetProgress(percent, time, isFilp, easeType)
	self:_InitProgressImageComponent()
	if not self.image then
		return
	end
	self.image:DOKill()
	isFilp  = isFilp or false
	time    = time or 0
	percent = Mathf.Clamp01(percent)
	if time > 0 then
		if isFilp then
			--处理下是否翻转（先缓动到满，然后再从0开始）
			self.image:DOFillAmount(1, time):OnComplete(function()
				self.image.fillAmount = 0
				self.image:DOFillAmount(percent, time):OnUpdate(function()
					self:_ExecValueChangedCallBack()
				end):SetUpdate(UpdateType.Normal):SetEase(easeType)
			end):OnUpdate(function()
				self:_ExecValueChangedCallBack()
			end):SetUpdate(UpdateType.Normal)
		else
			self.image:DOFillAmount(percent, time):OnUpdate(function()
				self:_ExecValueChangedCallBack()
			end):SetUpdate(UpdateType.Normal):SetEase(easeType)
		end
	else
		self.image.fillAmount = percent
		self:_ExecValueChangedCallBack()
	end
end

function ProgressBar:OnValueChanged(func)
	self.onValueChangedFunc = func
end

function ProgressBar:_ExecValueChangedCallBack()
	if self.onValueChangedFunc then
		self:onValueChangedFunc()
	end
end

function ProgressBar:Destroy()
	if self.image then
		self.image:DOKill()
	end
	self.image              = nil
	self.textField          = nil
	self.followImage        = nil
	self.onValueChangedFunc = nil
	ProgressBar.superclass.Destroy(self)
end