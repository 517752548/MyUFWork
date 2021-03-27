---@class InputField
---@field private inputField Unityengine.UI.InputField
---@field private placeholder Text
_G.InputField = class(UGUIObject)

function InputField:ctor(transform)
	self.inputField             = nil
	self.placeholder            = nil
	self.onValueChangedCallBack = nil
	self.onEndEditCallBack      = nil
	self.onSubmitCallBack       = nil
	self.wasFocused             = false
end

function InputField:_InitInputFieldComponent()
	if not self.transform then return end
	if not self.inputField then
		self.inputField = self.transform:GetComponent(typeof(UnityEngine.UI.InputField))
		self.inputField.onValueChanged:RemoveAllListeners()
		self.inputField.onValueChanged:AddListener(function(str)
			if self.onValueChangedCallBack then
				self.onValueChangedCallBack(str)
			end
		end)
		self.inputField.onEndEdit:RemoveAllListeners()
		self.inputField.onEndEdit:AddListener(function(str)
			if self.onEndEditCallBack then
				self.onEndEditCallBack(str)
			end
		end)
		self:RunUpdate()
	end
	if self.inputField and self.inputField.placeholder and not self.placeholder then
		self.placeholder = Text.New(self.inputField.placeholder.transform)
	end
end

function InputField:Update()
	if not self.inputField then return end
	if tolua.isnull(self.inputField) then return end
	if self.wasFocused and self.onSubmitCallBack then
		if IsRunInEditor or IsWindowsPlayer then
			if Input.GetKeyDown(KeyCode.Return) or Input.GetKeyDown(KeyCode.KeypadEnter) then
				if self.onSubmitCallBack then
					self.onSubmitCallBack()
				end
			end
		--elseif IsIPhonePlayer or IsAndroidPlayer then
		--	if self.inputField.touchScreenKeyboard and self.inputField.touchScreenKeyboard.status == UnityEngine.TouchScreenKeyboard.Status.Done then
		--		if self.onSubmitCallBack then
		--			self.onSubmitCallBack()
		--		end
		--	end
		end
	end
	self.wasFocused = self.inputField.isFocused
end

---@param value number
function InputField:SetCharacterLimit(value)
	if not value then return end
	if value < 0 then return end
	self:_InitInputFieldComponent()
	if not self.inputField then return end
	self.inputField.characterLimit = value
end

---@param value UnityEngine.UI.InputField.CharacterValidation @可输入的字符类型 请直接传入UGUI中的InputField可接受的类型
function InputField:SetCharacterValidation(value)
	if not value then return end
	self:_InitInputFieldComponent()
	if not self.inputField then return end
	self.inputField.characterValidation = value
end

--[[
SetContentType可以直接复制下面的可接受参数
UnityEngine.UI.InputField.ContentType.Standard          允许所有
UnityEngine.UI.InputField.ContentType.Autocorrected     自动修正的
UnityEngine.UI.InputField.ContentType.IntegerNumber     数字-整数
UnityEngine.UI.InputField.ContentType.DecimalNumber     数字-小数
UnityEngine.UI.InputField.ContentType.Alphanumeric      所有英文字母和数字
UnityEngine.UI.InputField.ContentType.Name              名字类型
UnityEngine.UI.InputField.ContentType.EmailAddress      Email类型
UnityEngine.UI.InputField.ContentType.Password          密码类型
UnityEngine.UI.InputField.ContentType.Pin               Pin类型
UnityEngine.UI.InputField.ContentType.Custom            用户自定义设置的类型
]]
---@param value UnityEngine.UI.InputField.ContentType @内容的类型，根据UGUI API的解释，这个值的设置会直接影响CharacterValidation(可输入字符类型)、KeyBoardType(移动设备的显示键盘类型)
function InputField:SetContentType(value)
	if not value then return end
	self:_InitInputFieldComponent()
	if not self.inputField then return end
	self.inputField.contentType = value
end

function InputField:SetText(value)
	if not value then return end
	self:_InitInputFieldComponent()
	if not self.inputField then return end
	self.inputField.text = value
end

function InputField:GetText()
	self:_InitInputFieldComponent()
	if not self.inputField then return "" end
	return self.inputField.text
end

function InputField:SetPlaceholderText(value)
	if not value then return end
	self:_InitInputFieldComponent()
	if not self.placeholder then return end
	self.placeholder:SetText(value)
end

function InputField:GetPlaceholderText()
	self:_InitInputFieldComponent()
	if not self.placeholder then return "" end
	return self.placeholder:GetText()
end

function InputField:OnValueChanged(func)
	self:_InitInputFieldComponent()
	self.onValueChangedCallBack = func
end

function InputField:OnEndEdit(func)
	self:_InitInputFieldComponent()
	self.onEndEditCallBack = func
end

function InputField:OnSubmit(func)
	self:_InitInputFieldComponent()
	self.onSubmitCallBack = func
end

function InputField:Destroy()
	self:StopUpdate()
	if self.inputField then
		self.inputField.onValueChanged:RemoveAllListeners()
		self.inputField.onEndEdit:RemoveAllListeners()
		self.inputField.onValidateInput = nil
	end
	self.inputField = nil
	if self.placeholder then
		self.placeholder:Destroy()
	end
	self.placeholder            = nil
	self.onValueChangedCallBack = nil
	self.onEndEditCallBack      = nil
	self.onSubmitCallBack       = nil
	self.wasFocused             = false
	InputField.superclass.Destroy(self)
end