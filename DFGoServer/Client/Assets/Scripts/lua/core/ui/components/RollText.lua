_G.RollText = class(Text)

function RollText:ctor(transform)
	self.rollText                = nil
	self._InitTextFieldComponent = function()
		if not self.transform then return end
		if not self.textField then
			self.textField = self.transform:GetComponentInChildren(typeof(UnityEngine.UI.Text))
			if self.textField then
				self.textField.raycastTarget = false
				self.textColor               = self.textField.color
			end
			if not self.rollText then
				self.rollText = self.transform:GetComponent("RollText")
			end
		end
	end
	self:_InitTextFieldComponent()
	self.isDefaultPlay = true
	self.isPlayIng     = false
end

function RollText:SetIsDefaultPlayTween(isPlay)
	self.isDefaultPlay = isPlay
end

function RollText:SetText(value)
	if self._textStr == value then return end
	self:StopPlayTween()
	RollText.superclass.SetText(self, value)
	if self.isDefaultPlay then
		self:_PlayTween()
	end
end

---_PlayTween private Func
function RollText:_PlayTween()
	if not self.rollText then return end
	if self.isPlayIng then return end
	self.rollText:PlayTween()
	self.isPlayIng = true
end

function RollText:StopPlayTween()
	if not self.rollText then return end
	self.rollText:StopPlayTween()
	self.isPlayIng = false
	self._textStr  = nil
end

function RollText:Destroy()
	self:StopPlayTween()
	self.rollText  = nil
	self.isPlayIng = nil
	RollText.superclass.Destroy(self)
end