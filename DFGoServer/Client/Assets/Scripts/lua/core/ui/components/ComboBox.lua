---@class ComboBox @使用Button和ScrollList组合而成的下拉框组件
_G.ComboBox = class(UGUIObject)

function ComboBox:ctor(transform)
	self.ugui_combobox_button = nil
	self.scrollList           = nil
	self.onSelectedCallBack   = nil
	self.onListVisibleChange  = nil
	self.maskAlpha            = 0   --打开下拉框之后，后面蒙板的alpha透明度
end

function ComboBox:_InitComboBoxButtonComponent()
	if not self.transform then return end
	if not self.ugui_combobox_button then
		local button = self.transform:GetComponentInChildren(typeof(UnityEngine.UI.Button))
		if button then
			self.ugui_combobox_button = Button.New(button.transform)
			self.ugui_combobox_button:SetSfxID(2024)
			self.ugui_combobox_button:OnClick(function()
				self:_OnButtonClick()
			end)
		end
	end
end

function ComboBox:_InitScrollListComponent()
	if not self.transform then return end
	if not self.scrollList then
		local scrollList = self.transform:GetComponentInChildren(typeof(UnityEngine.UI.ScrollRect))
		if scrollList then
			self.scrollList = ScrollList.New(scrollList.transform)
			self.scrollList:SetHorizontal(false)
			self.scrollList:SetVertical(true)
			self.scrollList:SetColCount(1)
			self.scrollList:SetSpacing(0, 0)
			self.scrollList:SetRenderClass(_ComboBoxItemRender)
			self.scrollList:OnSelectedItem(function(render)
				self:_OnSelectedItem(render)
			end)
			self:_SetScrollListVisible(false)
		end
	end
end

function ComboBox:_SetScrollListVisible(visible)
	if not self.scrollList then return end
	self.scrollList:SetVisible(visible)
	if visible then
		self:ShowMask(function()
			self.scrollList:SetVisible(false)
			if self.onListVisibleChange then
				self.onListVisibleChange(false)
			end
		end, self.maskAlpha)
	else
		self:HideMask()
	end
	if self.onListVisibleChange then
		self.onListVisibleChange(visible)
	end
end

function ComboBox:_OnButtonClick()
	if not self.scrollList then return end
	local isShow = not self.scrollList:GetVisible()
	self:_SetScrollListVisible(isShow)
end

function ComboBox:_OnSelectedItem(render)
	self:SetText(render.data.text)
	self:_SetScrollListVisible(false)
	if self.onSelectedCallBack then
		self.onSelectedCallBack(render)
	end
end

function ComboBox:OnSelectedItem(func)
	self.onSelectedCallBack = func
end

function ComboBox:OnListVisibleChange(func)
	self.onListVisibleChange = func
end

function ComboBox:SetText(value)
	self:_InitComboBoxButtonComponent()
	if not self.ugui_combobox_button then return end
	self.ugui_combobox_button:SetText(value)
end
function ComboBox:SetDataProvider(dataList)
	self:_InitComboBoxButtonComponent()
	self:_InitScrollListComponent()
	if not self.scrollList then return end
	self.scrollList:SetDataProvider(dataList)
end

function ComboBox:GetRendererByIndex(index)
	self:_InitScrollListComponent()
	if not self.scrollList then return end
	return self.scrollList:GetRendererByIndex(index)
end

function ComboBox:SelectByIndex(index)
	self:_InitScrollListComponent()
	if not self.scrollList then return end
	self.scrollList:SelectByIndex(index)
end

function ComboBox:GetLastSelectedIndex()
	self:_InitScrollListComponent()
	if not self.scrollList then return end
	return self.scrollList:GetLastSelectedIndex()
end

function ComboBox:SetMaskAlpha(value)
	self.maskAlpha = value
end

---@param _class table @要进行迭代创建的renderClass 如果不赋值这个，会默认使用下面_ComboBoxItemRender
function ComboBox:SetRenderClass(_class)
	self:_InitScrollListComponent()
	if not self.scrollList then return end
	self.scrollList:SetRenderClass(_class)
end

---@param x number @格子之间的横向间隔
---@param y number @格子之间的纵向间隔
function ComboBox:SetSpacing(x, y)
	self:_InitScrollListComponent()
	if not self.scrollList then return end
	self.scrollList:SetSpacing(x, y)
end

function ComboBox:AllowRepeatSelected(value)
	self:_InitScrollListComponent()
	if not self.scrollList then return end
	self.scrollList:AllowRepeatSelected(value)
end

function ComboBox:OnListItemValueChanged(func)
	self:_InitScrollListComponent()
	if not self.scrollList then return end
	self.scrollList:OnItemValueChanged(func)
end

function ComboBox:Destroy()
	if self.ugui_combobox_button then
		self.ugui_combobox_button:Destroy()
	end
	if self.scrollList then
		self.scrollList:Destroy()
	end
	self.ugui_combobox_button = nil
	self.scrollList           = nil
	self.onSelectedCallBack   = nil
	ComboBox.superclass.Destroy(self)
end

---@class _ComboBoxItemRender @提供给ComboBox使用的内部类,作为默认的ComboBox下拉列表的Render使用
_G._ComboBoxItemRender = class(Toggle)

function _ComboBoxItemRender:OnLoaded()
end

function _ComboBoxItemRender:SetData(data)
	_ComboBoxItemRender.superclass.SetData(self, data)
	self:SetText(data.text)
end