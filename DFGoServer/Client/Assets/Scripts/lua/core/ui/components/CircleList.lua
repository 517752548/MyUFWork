---@class CircleList
_G.CircleList = class(UGUIObject)

function CircleList:ctor(transform)
	self._circleList = nil
	self.itemList = {}

	self._InitCircleListComponent = function()
		if not self.transform then return end
		if not self._circleList then
			self._circleList = self.transform:GetComponent("CircleList")
			if self._circleList then
				self._circleList.OnClick:AddListener(function()
					self:PlaySFX()
					if self.onClickCallBack then
						self.onClickCallBack()
					end
				end)
			end
		end
	end

	self:_InitCircleListComponent()
end

function CircleList:OnClick(func)
	self:_InitCircleListComponent()
	self.onClickCallBack = func
end

function CircleList:IsAutoMove(isAuto)
	self:_InitCircleListComponent()
	if not self._circleList then
		return
	end
	self._circleList.IsAutoMove = isAuto
end

-- 添加
function CircleList:AddItem( item )
	self:_InitCircleListComponent()
	if not self._circleList then
		return
	end
	self._circleList:AddItem( item:GetTransform() )
	table.insert( self.itemList, item )
end

-- 批量添加
function CircleList:BatchAddItem( itemTab )
	self:_InitCircleListComponent()
	if not self._circleList then
		return
	end

	local list = {}
	for i, v in ipairs(itemTab) do
		table.insert( self.itemList, v )
		table.insert( list, v:GetTransform() )
	end
	self._circleList:BatchAddItem( list )
end

-- 插入
--@idx: 插入的位置 下标从1开始
function CircleList:InsertItem( idx, item )
	self:_InitCircleListComponent()
	if not self._circleList then
		return
	end

	table.insert( self.itemList, idx, item )

	idx = idx - 1
	idx = idx < 0 and 0 or idx

	self._circleList:InsertItem( idx, item )
end

-- 移除
function CircleList:RemoveItem(idx)
	if not self._circleList then
		return
	end
	
	local item = self.itemList[idx]
	if item then
		item:Destroy()
	end

	idx = idx or 1
	idx = idx - 1
	idx = idx < 0 and 0 or idx
	self._circleList:RemoveItem( idx )
end

-- 移除所有
function CircleList:RemoveAll()
	if not self._circleList then
		return
	end

	self._circleList:RemoveAll()
	for i, item in pairs(self.itemList) do
		item:Destroy()
	end
	self.itemList = {}
end

function CircleList:Destroy()
	if not self._circleList then
		return
	end

	self:RemoveAll()

	self._circleList.OnClick:RemoveAllListeners()

	self._circleList = nil

	CircleList.superclass.Destroy(self)
end