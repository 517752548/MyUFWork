---@class ScrollFlowList
---@field calcItemWidthCallback function @计算每个Item宽度的回调函数，开发者自己在外部实现，该函数的参数是需要计算宽度的对应data。通过SetCalcItemWidthFunc方法设置
---@field calcItemHeightCallback function @计算每个Item高度的回调函数，开发者自己在外部实现，该函数的参数是需要计算高度的对应data。通过SetCalcItemHeightFunc方法设置
_G.ScrollFlowList = class(ScrollLoopList)

function ScrollFlowList:ctor()
	self.useDefaultItemSize     = false
	self.calcItemWidthCallback  = nil
	self.calcItemHeightCallback = nil
end

---@param value number @设置每列数量 对于这个列表列数只能为1，所以重写了这里也是为了当设置大于1的时候强制改成1
function ScrollFlowList:SetColCount(value)
	value = Mathf.Clamp01(value)
	ScrollFlowList.superclass.SetColCount(self, value)
end

---@param value number @设置每行数量 对于这个列表行数只能为1，所以重写了这里也是为了当设置大于1的时候强制改成1
function ScrollFlowList:SetRowCount(value)
	value = Mathf.Clamp01(value)
	ScrollFlowList.superclass.SetRowCount(self, value)
end

---@param func function @设置计算item宽度的回调函数
function ScrollFlowList:SetCalcItemWidthFunc(func)
	self.calcItemWidthCallback = func
end

---@param func function @设置计算item高度的回调函数
function ScrollFlowList:SetCalcItemHeightFunc(func)
	self.calcItemHeightCallback = func
end

function ScrollFlowList:GetItemWidth(index)
	if not self.dataList then return 0 end
	if not self.calcItemWidthCallback then return 0 end
	local data = self.dataList[index]
	if not data then return 0 end
	return self.calcItemWidthCallback(data)
end

function ScrollFlowList:GetItemHeight(index)
	if not self.dataList then return 0 end
	if not self.calcItemHeightCallback then return 0 end
	local data = self.dataList[index]
	if not data then return 0 end
	return self.calcItemHeightCallback(data)
end

function ScrollFlowList:_SetItemRectTransform(transform)
	transform.anchorMax = Vector2.New(0, 1)
	transform.anchorMin = Vector2.New(0, 1)
	transform.pivot     = Vector2.New(0, 1)
end

function ScrollFlowList:_CalcEachItemPos()
	if not self.dataList then return end
	self.itemPosArray = {}
	local dataLength  = #self.dataList
	local x, y
	x                 = 0
	y                 = 0
	x                 = self.padding.left
	y                 = self.padding.top
	local itemWidth   = 0
	local itemHeight  = 0
	for i, v in pairs(self.dataList) do
		self.itemPosArray[i] = { x = x, y = y * -1 }
		itemWidth            = self:GetItemWidth(i)
		itemHeight           = self:GetItemHeight(i)
		if self.constraint == UnityEngine.UI.GridLayoutGroup.Constraint.FixedColumnCount then
			y = y + itemHeight + (i < dataLength and self.spacing.y or 0)
		elseif self.constraint == UnityEngine.UI.GridLayoutGroup.Constraint.FixedRowCount then
			x = x + itemWidth + (i < dataLength and self.spacing.x or 0)
		end
	end
	local width  = x + self.padding.right
	local height = y + self.padding.bottom
	--因为只能是单行或者单列模式 所以这里判断计算下content的宽和高，在单列模式下 宽度固定， 在单行模式下 高度固定
	if self.constraint == UnityEngine.UI.GridLayoutGroup.Constraint.FixedColumnCount then
		width = self.padding.left + itemWidth + self.padding.right
	elseif self.constraint == UnityEngine.UI.GridLayoutGroup.Constraint.FixedRowCount then
		height = self.padding.top + itemHeight + self.padding.bottom
	end
	self.contentTSF.sizeDelta = Vector2.New(width, height)
end

function ScrollFlowList:_CalcContentTotalSize()
	--这里的计算合并到_CalcEachItemPos()方法里了
end

function ScrollFlowList:Destroy()
	self.calcItemWidthCallback  = nil
	self.calcItemHeightCallback = nil
	ScrollFlowList.superclass.Destroy(self)
end