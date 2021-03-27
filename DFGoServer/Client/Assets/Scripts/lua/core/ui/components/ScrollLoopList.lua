---@class ScrollLoopList
---@field scrollRect UnityEngine.UI.ScrollRect
---@field scrollRectTransform UnityEngine.RectTransform @ScrollRect的Transform
---@field contentTSF UnityEngine.Transform @内容容器的Transform
---@field firstPadderTSF UnityEngine.RectTransform @头部占位的Transform
---@field endPadderTSF UnityEngine.RectTransform @尾部占位的Transform
---@field colCount number @显示的列数，如果设置了这个就表示竖排的方式，确定了列数
---@field rowCount number @显示的行数，如果设置了这个就表示横排的方式，确定了行数
---@field padding UnityEngine.Rect @描述内容显示位置的left,right,top,bottom的空余量，默认为0
---@field spacing UnityEngine.Vector2 @描述每个Item之间的间距 x为横向间距 y为竖向间距
---@field dataList table<any> @要显示的数据
---@field startIndex number @当前显示的dataList的起点索引
---@field endIndex number @当前显示的dataList的终点索引
---@field useDefaultItemSize boolean @是否使用统一（默认的）item宽高，默认值true
---@field itemDefaultWidth number @item的统一宽度 通过SetItemDefaultWidth方法来设置，不设置会自动计算最大宽度
---@field itemDefaultHeight number @item的统一高度 通过SetItemDefaultHeight方法来设置，不设置会自动计算最大高度
---@field itemPosArray table @预先生成的所有格子的位置{x=x, y=y}
---@field recycledTSF UnityEngine.Transform @回收节点的Transform
---@field recycledGameObjectArray table<UnityEngine.GameObject> @存放回收的GameObject数组
---@field recycledRenderArray table @存放回收的Render实例数组
---@field TEMPLATEGameObject UnityEngine.GameObject @用于生成的模版GameObject
---@field constraint UnityEngine.UI.GridLayoutGroup.Constraint @布局方式，用这个来做判断使用
---@field allRenderDict table @存放ItemRender，key为item的索引和dataList对应，value为Render的实例，注意！如果当前不显示的格子，从这里获取的为nil
---@field isUseRenderPrefab boolean @是否使用外部的RenderPrefab
---@field renderPrefabName string @RenderPrefab的名字
---@field renderClass table @要进行迭代创建的renderClass
---@field toggleGroup ToggleGroup @所有格子的ToggleGroup用来处理单选问题
---@field onSelectedCallBack function @当选择时候的回调函数，参考ToggleGroup中的用法
---@field onValueChangedCallBack function @当toggleGroup发生变化的回调函数，参考ToggleGroup中的用法
---@field onClickItemCallBack function @当点击时候的回调函数，参考ToggleGroup中的用法
---@field onAllOffCallBack function @当触发所有item都没选择的时候的回调函数，参考FriendPanel好友系统中的用法
---@field pagination Pagination @分页组件，用于使用ScrollLoopList组件进行分页请求的时候内部逻辑使用
---@field curPage number @当前页数
---@field prevPage number @上一页页数
---@field nextPage number @下一页页数
---@field onPrevPageChange function @当变更到上一页的回调，一般需要开发者自己在这个回调中请求上一页的数据
---@field onNextPageChange function @当变更到下一页的回调，一般需要开发者自己在这个回调中请求下一页的数据
_G.ScrollLoopList = class(UGUIObject)

function ScrollLoopList:ctor(transform)
	self.scrollRect              = nil
	self.scrollRectTransform     = nil
	self.contentTSF              = nil
	self.firstPadderTSF          = nil
	self.endPadderTSF            = nil
	self.colCount                = nil
	self.rowCount                = nil
	self.padding                 = nil
	self.spacing                 = nil
	self.dataList                = nil
	self.startIndex              = 0
	self.endIndex                = 0
	self.useDefaultItemSize      = true
	self.itemDefaultWidth        = 0
	self.itemDefaultHeight       = 0
	self.itemPosArray            = nil
	self.recycledTSF             = nil
	self.recycledGameObjectArray = nil
	self.recycledRenderArray     = nil
	self.TEMPLATEGameObject      = nil
	self.constraint              = nil
	self.allRenderDict           = nil --按照MAP的方式存放当前显示的itemRender，这个map的key为dataList中的index，value为renderclass的实例，如果没有的地方就用nil存储
	self.isUseRenderPrefab       = false
	self.renderPrefabName        = nil
	self.renderPrefabABPath      = nil
	self.renderClass             = nil
	self.toggleGroup             = ToggleGroup.New()
	self.onSelectedCallBack      = nil
	self.onValueChangedCallBack  = nil
	self.onClickItemCallBack     = nil
	self.onTouchDownCallBack     = nil
	self.onTouchUpCallBack       = nil
	self.onAllOffCallBack        = nil
	self.pagination              = nil
	self.curPage                 = 1
	self.prevPage                = 1
	self.nextPage                = 1
	self.onPrevPageChange        = nil
	self.onNextPageChange        = nil
	self.isSetDataAsyncComplete  = false
	self.waitScrollIndex         = -1
	self.waitSelectIndex         = -1
end

function ScrollLoopList:_InitScrollRectComponent()
	if not self.transform then return end
	if not self.scrollRect then
		self.scrollRect = self.transform:GetComponent(typeof(UnityEngine.UI.ScrollRect))
	end
	if self.scrollRect and not self.scrollRectTransform then
		self.scrollRectTransform = self.scrollRect:GetComponent(typeof(UnityEngine.RectTransform))
	end
	if self.scrollRect and self.scrollRect.content and not self.contentTSF then
		self.contentTSF           = self.scrollRect.content
		self.contentTSF.anchorMax = Vector2.New(0, 1)
		self.contentTSF.anchorMin = Vector2.New(0, 1)
		self.contentTSF.pivot     = Vector2.New(0, 1)
	end
	if self.scrollRectTransform then
		if not self.recycledTSF then
			self.recycledTSF = self.scrollRectTransform:Find('RecycledItems'):GetComponent(typeof(UnityEngine.RectTransform))
			self.recycledTSF.gameObject:SetActive(false)
		end
	end
	if not self.recycledGameObjectArray then
		self.recycledGameObjectArray = {}
	end
	if not self.recycledRenderArray then
		self.recycledRenderArray = {}
	end
	if not self.allRenderDict then
		self.allRenderDict = {}
	end
end

function ScrollLoopList:_InitLayoutComponent()
	if not self.contentTSF then return end
	if not self.firstPadderTSF then
		self.firstPadderTSF           = self.contentTSF:Find("FirstPadder"):GetComponent(typeof(UnityEngine.RectTransform))
		self.firstPadderTSF.anchorMax = Vector2.New(0, 1)
		self.firstPadderTSF.anchorMin = Vector2.New(0, 1)
		self.firstPadderTSF.pivot     = Vector2.New(0, 1)
	end
	if not self.endPadderTSF then
		self.endPadderTSF           = self.contentTSF:Find("EndPadder"):GetComponent(typeof(UnityEngine.RectTransform))
		self.endPadderTSF.anchorMax = Vector2.New(0, 1)
		self.endPadderTSF.anchorMin = Vector2.New(0, 1)
		self.endPadderTSF.pivot     = Vector2.New(0, 1)
	end
	if not self.padding then
		self.padding = RectOffset.New(0, 0, 0, 0)
	end
	if not self.spacing then
		self.spacing = Vector2.New(0, 0)
	end
end

function ScrollLoopList:GetScrollRect()
	return self.scrollRect
end

function ScrollLoopList:_InitPagination()
	if not self.pagination then
		self.pagination = Pagination.New()
	end
end
---@param value number @列表内容的最大数量，注意！不是最大页数，当设置了这个值以后，组件会认为开启了翻页模式
function ScrollLoopList:SetMaximum(value)
	self:_InitPagination()
	if not self.pagination then return end
	self.pagination:SetMaximumValue(value)
end
---@param value number @列表内容的最小数量，当设置了这个值以后，组件会认为开启了翻页模式
function ScrollLoopList:SetMinimum(value)
	self:_InitPagination()
	if not self.pagination then return end
	self.pagination:SetMinimumValue(value)
end
---@param value number @列表每页的内容数量，当设置了这个值以后，组件会认为开启了翻页模式
function ScrollLoopList:SetPageStep(value)
	self:_InitPagination()
	if not self.pagination then return end
	self.pagination:SetStepValue(value)
end

---@param value UnityEngine.Transform @指定一个容器作为内容容器(contentTSF)
function ScrollLoopList:SetContainer(value)
	if not value then return end
	self.contentTSF = value
end

---@param value UnityEngine.UI.ScrollRect.MovementType @设置列表的滑动方式
function ScrollLoopList:SetMovementType(value)
	self:_InitScrollRectComponent()
	if not self.scrollRect then return end
	self.scrollRect.movementType = value
end

---@param value boolean @设置滚动区域是否可以横向滚动
function ScrollLoopList:SetHorizontal(value)
	self:_InitScrollRectComponent()
	if not self.scrollRect then return end
	self.scrollRect.horizontal = value
end

---@param value boolean @设置滚动区域是否可以纵向滚动
function ScrollLoopList:SetVertical(value)
	self:_InitScrollRectComponent()
	if not self.scrollRect then return end
	self.scrollRect.vertical = value
end

---@param value number @设置横向滚动位置，只有当SetHorizontal(true)的时候才可以使用 取值范围[0,1]
function ScrollLoopList:SetHorizontalScrollPosition(value, ignoreReload)
	self:_InitScrollRectComponent()
	if not self.scrollRect then return end
	if not self.scrollRect.horizontal then return end
	if not self.contentTSF then return end
	value                            = Mathf.Clamp01(value)
	self.contentTSF.anchoredPosition = Vector2.New(-((self.contentTSF.sizeDelta.x - self.scrollRectTransform.sizeDelta.x) * value), 0)
	LayoutRebuilder.ForceRebuildLayoutImmediate(self.contentTSF)
	if not ignoreReload then
		self:_ReloadItems()
	end
end

---@param value number @设置纵向滚动位置，SetVertical(true)的时候才可以使用 取值范围[0,1]
function ScrollLoopList:SetVerticalScrollPosition(value, ignoreReload)
	self:_InitScrollRectComponent()
	if not self.scrollRect then return end
	if not self.scrollRect.vertical then return end
	if not self.contentTSF then return end
	value                            = Mathf.Clamp01(value)
	self.contentTSF.anchoredPosition = Vector2.New(0, (self.contentTSF.sizeDelta.y - self.scrollRectTransform.sizeDelta.y) * value)
	LayoutRebuilder.ForceRebuildLayoutImmediate(self.contentTSF)
	if not ignoreReload then
		self:_ReloadItems()
	end
end

---@param index number @设置内容滚动到index位置，取值范围是[1, #dataList]
function ScrollLoopList:SetScrollIndex(index, ignoreReload)
	if not self.isSetDataAsyncComplete then
		self.waitScrollIndex             = index
		self.waitScrollIndexIgnoreReload = ignoreReload
		return
	end
	if not self.itemPosArray then return end
	index     = Mathf.Clamp(index, 1, #self.itemPosArray)
	local pos = self.itemPosArray[index]
	if not pos then return end
	local x = pos.x - self:GetItemWidth(index) * 0.5
	local y = -pos.y - self:GetItemHeight(index) * 0.5
	self:_InitScrollRectComponent()
	if not self.scrollRect then return end
	if not self.contentTSF then return end
	if self.scrollRect.horizontal then
		x                                = Mathf.Clamp(x, 0, (self.contentTSF.sizeDelta.x - self.scrollRectTransform.sizeDelta.x))
		self.contentTSF.anchoredPosition = Vector2.New(-(x), 0)
	elseif self.scrollRect.vertical then
		y                                = Mathf.Clamp(y, 0, (self.contentTSF.sizeDelta.y - self.scrollRectTransform.sizeDelta.y))
		self.contentTSF.anchoredPosition = Vector2.New(0, y)
	end
	LayoutRebuilder.ForceRebuildLayoutImmediate(self.contentTSF)
	if not ignoreReload then
		self:_ReloadItems()
	end
end

---@param value number @设置每列数量
function ScrollLoopList:SetColCount(value)
	self.constraint = UnityEngine.UI.GridLayoutGroup.Constraint.FixedColumnCount
	self.colCount   = value
end

---@param value number @设置每行数量
function ScrollLoopList:SetRowCount(value)
	self.constraint = UnityEngine.UI.GridLayoutGroup.Constraint.FixedRowCount
	self.rowCount   = value
end

---@param left number @容器左边距
---@param right number @容器右边距
---@param top number @容器上边距
---@param bottom number @容器下边距
function ScrollLoopList:SetPadding(left, right, top, bottom)
	self:_InitLayoutComponent()
	if self.padding then
		self.padding.left   = left
		self.padding.right  = right
		self.padding.top    = top
		self.padding.bottom = bottom
	end
end

---@param x number @格子之间的横向间隔
---@param y number @格子之间的纵向间隔
function ScrollLoopList:SetSpacing(x, y)
	self:_InitLayoutComponent()
	if self.spacing then
		self.spacing.x = x
		self.spacing.y = y
	end
end

function ScrollLoopList:SetItemDefaultWidth(value)
	self.itemDefaultWidth = value
end

function ScrollLoopList:GetItemWidth(index)
	if self.useDefaultItemSize then
		return self.itemDefaultWidth
	end
end

function ScrollLoopList:SetItemDefaultHeight(value)
	self.itemDefaultHeight = value
end

function ScrollLoopList:GetItemHeight(index)
	if self.useDefaultItemSize then
		return self.itemDefaultHeight
	end
end

---@return nil @调用这个函数并且设置了prefabName表示要使用一个外部的prefab进行迭代显示,如果从来不调用，则表示使用内部的template
---@param prefabName string @外部的每一个项的prefab名字，会根据这个名字加载对应的prefab
function ScrollLoopList:UseRenderPrefab(prefabName)
	self.isUseRenderPrefab = true
	self.renderPrefabName  = prefabName
end

---@param _class table @要进行迭代创建的renderClass
function ScrollLoopList:SetRenderClass(_class)
	self.renderClass = _class
end

---@param dataList table @根据dataList中的renderVO来进行显示，这里会根据之前设置的renderClass来依次生成显示控制类，如果之前设置过renderPrefabName，那么会先加载然后复制出GameObject赋值过去，如果之前没有设置过，那么会找到content下的名为template的节点进行复制
function ScrollLoopList:SetDataProvider(dataList)
	if not dataList or #dataList == 0 then
		self.dataList = nil
		self:Clean()
		return
	end
	self:_InitScrollRectComponent()
	self:_InitLayoutComponent()
	self:RunLateUpdate()
	self.dataList                    = dataList
	self.isSetDataAsyncComplete      = false
	self.waitScrollIndex             = -1
	self.waitSelectIndex             = -1
	self.waitScrollIndexIgnoreReload = false
	local loadedCallBack             = function(gameObject)
		if self:IsDestroyed() then
			return
		end
		self.TEMPLATEGameObject  = gameObject
		local template_sizeDelta = getRectTransformPreferredSize(self.TEMPLATEGameObject.transform, true)
		if self.useDefaultItemSize then
			if self.itemDefaultWidth == 0 then
				self.itemDefaultWidth = template_sizeDelta.x
			end
			if self.itemDefaultHeight == 0 then
				self.itemDefaultHeight = template_sizeDelta.y
			end
		end
		self:_CalcEachItemPos()
		self:_CalcContentTotalSize()
		self:_ReloadItems()
		self.isSetDataAsyncComplete = true
		if self.waitScrollIndex >= 0 then
			self:SetScrollIndex(self.waitScrollIndex, self.waitScrollIndexIgnoreReload)
			self.waitScrollIndex = -1
		end
		if self.waitSelectIndex >= 0 then
			self:SelectByIndex(self.waitSelectIndex)
			self.waitSelectIndex = -1
		end
	end

	if self.TEMPLATEGameObject then
		loadedCallBack(self.TEMPLATEGameObject)
	else
		if self.isUseRenderPrefab then
			local prefabName        = self.renderPrefabName
			local abPath            = ResUtil:GetUIPath(prefabName)
			self.renderPrefabABPath = abPath
			ResManager:LoadPrefabAsync(abPath, loadedCallBack)
		else
			local tempNode = findChild(self.contentTSF, 'template') or findChild(self.contentTSF, 'Template')
			if tempNode then
				loadedCallBack(tempNode)
			end
		end
	end
end

function ScrollLoopList:SetDataList(dataList)
	if not dataList or type(dataList) ~= 'table' then return end
	self.dataList = dataList
end

-- 获取列表数据
function ScrollLoopList:GetDataList()
	return self.dataList
end

function ScrollLoopList:LateUpdate()
	if not self.scrollRect then return end
	if tolua.isnull(self.scrollRect) then return end
	if self.scrollRect.horizontal and self.scrollRect.velocity.x ~= 0 then
		self:_LoadItems()
	end
	if self.scrollRect.vertical and self.scrollRect.velocity.y ~= 0 then
		self:_LoadItems()
	end
end

function ScrollLoopList:_ReloadItems()
	if self.allRenderDict then
		for i, v in pairs(self.allRenderDict) do
			local removeRender = self.allRenderDict[i]
			if removeRender then
				self.allRenderDict[i] = nil
				self:_RecycledItemGameObject(removeRender:GetGameObject())
				self:_RecycledItemRender(removeRender) --Reload的时候不需要将render回收进行OnClear() 所以注释这里
			end
		end
	end
	self.toggleGroup:RemoveAllToggle()
	self.toggleGroup:ClearSelectedIndex()
	local oldStartIndex = self.startIndex
	local oldEndIndex   = self.endIndex
	self:_CalcIndexRange(oldStartIndex, oldEndIndex)
	local isPrev = false
	local isNext = false
	if oldStartIndex > self.startIndex then
		isPrev = true
	end
	if oldEndIndex < self.endIndex then
		isNext = true
	end
	self:_LoadItemsByRange(self.startIndex, self.endIndex)
	self:_CalcPadder()
	self:_CalcPageInfo(isPrev, isNext)
end

function ScrollLoopList:_CalcIndexRange(oldStartIndex, oldEndIndex)
	if not self.scrollRect then return end
	if not self.contentTSF then return end
	if not self.itemPosArray then return end
	if #self.itemPosArray <= 0 then return end
	local contentPos = self.scrollRect.horizontal and (-self.contentTSF.anchoredPosition.x) - self:GetItemWidth(oldStartIndex) or (-self.contentTSF.anchoredPosition.y) + self:GetItemHeight(oldStartIndex)
	self.startIndex  = self:_GetDataIndexAtContentPos(contentPos)
	contentPos       = self.scrollRect.horizontal and (-self.contentTSF.anchoredPosition.x) + self.scrollRectTransform.rect.width + self:GetItemWidth(oldEndIndex) or (-self.contentTSF.anchoredPosition.y) - self.scrollRectTransform.rect.height - self:GetItemHeight(oldEndIndex)
	self.endIndex    = self:_GetDataIndexAtContentPos(contentPos)
end

function ScrollLoopList:_LoadItems(isBySetDataProvider)
	local oldStartIndex = self.startIndex
	local oldEndIndex   = self.endIndex
	self:_CalcIndexRange(oldStartIndex, oldEndIndex)
	if isBySetDataProvider and oldStartIndex == self.startIndex and oldEndIndex == self.endIndex then
		self:_SetDataByRange(self.startIndex, self.endIndex)
		return
	end
	local isPrev = false
	local isNext = false
	if oldStartIndex > self.startIndex then
		isPrev = true
		--头部有新增
		self:_LoadItemsByRange(self.startIndex, oldStartIndex - 1, true)
	end
	if oldStartIndex < self.startIndex then
		--头部有减少
		self:_RemoveItemsByRange(oldStartIndex, self.startIndex - 1)
	end
	if oldEndIndex < self.endIndex then
		isNext = true
		--尾部有新增
		self:_LoadItemsByRange(oldEndIndex + 1, self.endIndex, false)
	end
	if oldEndIndex > self.endIndex then
		--尾部有减少
		self:_RemoveItemsByRange(self.endIndex + 1, oldEndIndex)
	end
	self:_CalcPadder()
	self:_CalcPageInfo(isPrev, isNext)
end

function ScrollLoopList:_CalcPageInfo(isPrev, isNext)
	--计算翻页问题
	if self.pagination then
		if isNext then
			self.pagination:SetValue(self.endIndex)
			local nextValue = self.pagination:GetNextValue()
			self.pagination:SetValue(nextValue)
			local nextPage = self.pagination:GetPage()
			if nextPage > self.curPage and self.nextPage ~= nextPage then
				self.nextPage = nextPage
				if self.onNextPageChange then
					self.onNextPageChange(self.nextPage)
				end
			end
		end

		if isPrev then
			self.pagination:SetValue(self.startIndex)
			local prevValue = self.pagination:GetPrevValue()
			self.pagination:SetValue(prevValue)
			local prevPage = self.pagination:GetPage()
			if prevPage < self.curPage and self.prevPage ~= prevPage then
				self.prevPage = prevPage
				if self.onPrevPageChange then
					self.onPrevPageChange(self.prevPage)
				end
			end
		end

		self.pagination:SetValue(self.startIndex)
		self.curPage = self.pagination:GetPage()
	end
end

function ScrollLoopList:_SetDataByRange(startIndex, endIndex)
	for i = startIndex, endIndex do
		local data   = self.dataList[i]
		local render = self.allRenderDict[i]
		if render then
			render:SetIndex(i)
			render:SetData(data)
		end
	end
end

function ScrollLoopList:_SetItemRectTransform(transform)
	transform.anchorMax = Vector2.New(0, 1)
	transform.anchorMin = Vector2.New(0, 1)
	transform.pivot     = Vector2.New(0.5, 0.5)
end

function ScrollLoopList:_LoadItemsByRange(startIndex, endIndex, insertHead)
	if startIndex < 1 then return end
	if endIndex < 1 then return end
	if not self.TEMPLATEGameObject then return end
	if not self.dataList then return end
	if #self.dataList <= 0 then return end
	if not self.itemPosArray then return end
	if #self.itemPosArray <= 0 then return end
	--生成对应的格子
	self.TEMPLATEGameObject:SetActive(true)
	self.toggleGroup:SetInternalMode(true)
	--按照截取的数据加载显示对应的Item
	for i = startIndex, endIndex do
		local data = self.dataList[i]
		---@type UnityEngine.GameObject
		local go   = self:_GetItemGameObject() --这里通过对象池的模式加载
		self:_SetItemRectTransform(go.transform)
		go.name                       = "index" .. i
		go.transform.anchoredPosition = Vector2.New(self.itemPosArray[i].x, self.itemPosArray[i].y)
		go.transform.sizeDelta        = Vector2.New(self:GetItemWidth(i), self:GetItemHeight(i))
		local render
		--[[
			注意！这里很巧合，很神奇，如果回收池里有以前的GameObject和Render，那么直接取出一个GameObject通过SetGameObject给Render就能使用，而且这个Render里以前保存的组件都是对应的这个GameObject
			这是因为在_RemoveItemsByRange的时候，是同时成对回收的GameObject和Render，那么取出的时候自然也是成对取出，所以不用考虑GameObject和Render不对应的问题。假如取出的时候一个从第一个取，一个从最后取，就出现问题了
			在一开始第一次创建的时候回收池是空的，创建自然也是成对创建。
		]]
		render                        = self:_GetItemRender(go)
		if render then
			render:SetParent(self.contentTSF)
			render:SetVisible(true)
			render:SetRendererList(self)
			render:SetIndex(i)
			self.toggleGroup:AddToggle(render, insertHead, true)
			self.allRenderDict[i] = render
			render:SetData(data)
			render:OnClick(function()
				if self.onClickItemCallBack then
					self.onClickItemCallBack(render)
				end
			end)

			if render.OnTouchDown then
				render:OnTouchDown(function()
					if self.onTouchDownCallBack then
						self.onTouchDownCallBack(render)
					end
				end)
			end

			if render.OnTouchUp then
				render:OnTouchUp(function(time)
					if self.onTouchUpCallBack then
						self.onTouchUpCallBack(render, time)
					end
				end)
			end
		end
	end
	self.TEMPLATEGameObject:SetActive(false)
	self.toggleGroup:ClearSelectedIndex()
	self.toggleGroup:SetInternalMode(false)
end

function ScrollLoopList:_RemoveItemsByRange(startIndex, endIndex)
	if startIndex < 1 then return end
	if endIndex < 1 then return end
	for i = startIndex, endIndex do
		local removeRender = self.allRenderDict[i]
		if removeRender then
			self.allRenderDict[i] = nil
			self:_RecycledItemGameObject(removeRender:GetGameObject())
			self:_RecycledItemRender(removeRender)
		end
	end
	self.toggleGroup:ClearSelectedIndex()
end

function ScrollLoopList:_RefreshItemsPos()
	local startIndex = self.startIndex
	local endIndex   = self.endIndex
	for i = startIndex, endIndex do
		local render = self.allRenderDict[i]
		if render then
			local go                      = render:GetGameObject()
			go.transform.anchoredPosition = Vector2.New(self.itemPosArray[i].x, self.itemPosArray[i].y)
		end
	end
end

local VECTOR2_ZERO = Vector2.zero
function ScrollLoopList:_RecycledItemGameObject(gameObject)
	if not self.recycledTSF then return end
	if not gameObject then return end
	gameObject.transform:SetParent(self.recycledTSF, false)
	gameObject.transform.anchoredPosition = VECTOR2_ZERO
	table.insert(self.recycledGameObjectArray, gameObject)
end

function ScrollLoopList:_RecycledItemRender(render)
	render:OnClear()
	render:ClearGameObject()
	render:ClearTransform()
	if self.toggleGroup then
		self.toggleGroup:RemoveToggle(render)
	end
	table.insert(self.recycledRenderArray, render)
end

function ScrollLoopList:_GetItemGameObject(i)
	if self.recycledGameObjectArray and #self.recycledGameObjectArray > 0 then
		return table.remove(self.recycledGameObjectArray, #self.recycledGameObjectArray)
	else
		local go = newObject(self.TEMPLATEGameObject)
		return go
	end
end

function ScrollLoopList:_GetItemRender(go)
	local render
	if self.recycledRenderArray and #self.recycledRenderArray > 0 then
		render = table.remove(self.recycledRenderArray, #self.recycledRenderArray)
		render:SetGameObject(go)
	else
		render = self.renderClass.New(go.transform)
		render:OnLoaded()
	end
	return render
end

function ScrollLoopList:_CalcEachItemPos()
	if not self.dataList then return end
	self.itemPosArray = {}
	local x, y
	for i, v in pairs(self.dataList) do
		x = 0
		y = 0
		x = self.padding.left + (self:GetItemWidth(i) * 0.5)
		y = self.padding.top + (self:GetItemHeight(i) * 0.5)
		if self.constraint == UnityEngine.UI.GridLayoutGroup.Constraint.FixedColumnCount then
			x = x + ((i - 1) % self.colCount) * (self:GetItemWidth(i) + self.spacing.x)
			y = y + math.floor((i - 1) / self.colCount) * (self:GetItemHeight(i) + self.spacing.y)
		elseif self.constraint == UnityEngine.UI.GridLayoutGroup.Constraint.FixedRowCount then
			x = x + math.floor((i - 1) / self.rowCount) * (self:GetItemWidth(i) + self.spacing.x)
			y = y + ((i - 1) % self.rowCount) * (self:GetItemHeight(i) + self.spacing.y)
		end
		self.itemPosArray[i] = { x = x, y = y * -1 }
	end
end

function ScrollLoopList:_CalcContentTotalSize()
	if not self.dataList then return end
	local dataLength = #self.dataList
	local width
	local height
	if self.constraint == UnityEngine.UI.GridLayoutGroup.Constraint.FixedColumnCount then
		width  = (self.itemDefaultWidth * self.colCount) + (self.spacing.x * (self.colCount - 1))
		height = (self.itemDefaultHeight * math.ceil(dataLength / self.colCount)) + (self.spacing.y * (math.ceil(dataLength / self.colCount) - 1))
	elseif self.constraint == UnityEngine.UI.GridLayoutGroup.Constraint.FixedRowCount then
		width  = (self.itemDefaultWidth * math.ceil(dataLength / self.rowCount)) + (self.spacing.x * (math.ceil(dataLength / self.rowCount) - 1))
		height = (self.itemDefaultHeight * self.rowCount) + (self.spacing.y * (self.rowCount - 1))
	end
	width                     = width + self.padding.left + self.padding.right
	height                    = height + self.padding.top + self.padding.bottom
	self.contentTSF.sizeDelta = Vector2.New(width, height)
end

function ScrollLoopList:_GetDataIndexAtContentPos(pos)
	return self:_FindDataIndexByBinary(pos, 1, #self.itemPosArray)
end

--二分查找法 查找索引范围内的格子位
function ScrollLoopList:_FindDataIndexByBinary(pos, startIndex, endIndex)
	if startIndex >= endIndex then
		return startIndex
	end
	local middleIndex = math.floor((startIndex + endIndex) / 2)
	local n
	local result
	if self.scrollRect.horizontal then
		n      = self.itemPosArray[middleIndex].x
		result = n >= pos
	elseif self.scrollRect.vertical then
		n      = self.itemPosArray[middleIndex].y
		result = n <= pos
	end
	if result then
		return self:_FindDataIndexByBinary(pos, startIndex, middleIndex)
	else
		return self:_FindDataIndexByBinary(pos, middleIndex + 1, endIndex)
	end
end

function ScrollLoopList:_CalcPadder()
	if not self.itemPosArray then return end
	local startIndex    = Mathf.Clamp(self.startIndex, 1, #self.itemPosArray)
	local endIndex      = Mathf.Clamp(self.endIndex, 1, #self.itemPosArray)
	local startIndexPos = self.itemPosArray[startIndex]
	local endIndexPos   = self.itemPosArray[endIndex]
	if not startIndexPos or not endIndexPos then return end
	if not self.firstPadderTSF then return end
	if not self.endPadderTSF then return end
	if self.scrollRect.horizontal then
		self.firstPadderTSF.anchoredPosition = VECTOR2_ZERO
		self.firstPadderTSF.sizeDelta        = Vector2.New(startIndexPos.x - (self:GetItemWidth(startIndex) * 0.5), self.contentTSF.sizeDelta.y)
		self.endPadderTSF.anchoredPosition   = Vector2.New(endIndexPos.x + (self:GetItemWidth(endIndex) * 0.5), 0)
		self.endPadderTSF.sizeDelta          = Vector2.New(self.contentTSF.sizeDelta.x - self.endPadderTSF.anchoredPosition.x, self.contentTSF.sizeDelta.y)
	elseif self.scrollRect.vertical then
		self.firstPadderTSF.anchoredPosition = VECTOR2_ZERO
		self.firstPadderTSF.sizeDelta        = Vector2.New(self.contentTSF.sizeDelta.x, math.abs(startIndexPos.y) - (self:GetItemHeight(startIndex) * 0.5))
		self.endPadderTSF.anchoredPosition   = Vector2.New(0, endIndexPos.y - (self:GetItemHeight(endIndex) * 0.5))
		self.endPadderTSF.sizeDelta          = Vector2.New(self.contentTSF.sizeDelta.x, self.contentTSF.sizeDelta.y - math.abs(self.endPadderTSF.anchoredPosition.y))
	end
end

function ScrollLoopList:RefreshContentSize()
	self:_CalcEachItemPos()
	self:_CalcContentTotalSize()
	self:_RefreshItemsPos()
	self:_CalcPadder()
	--self:_LoadItems(true)
end

function ScrollLoopList:RefreshView()
	self:_ReloadItems()
end

---@return nil @对于ScrollLoopList来说调动Clean方法就是为了当前的缓存的数据以及显示，一般用于多个分类列表共用一个ScrollLoopList，比如背包或排行榜，dataList发生了根本的改变，那么在调用SetDataProvider之前重新调用下Clean
function ScrollLoopList:Clean()
	self:_InitScrollRectComponent()
	self:_InitLayoutComponent()
	self:StopLateUpdate()
	local tempNode = findChild(self.contentTSF, 'template') or findChild(self.contentTSF, 'Template')
	if tempNode then
		tempNode:SetActive(false)
	end
	self:_RemoveItemsByRange(self.startIndex, self.endIndex)
	--if self.allRenderDict then
	--	for i, v in pairs(self.allRenderDict) do
	--		destroy(v:GetGameObject())
	--		self.allRenderDict[i] = nil
	--	end
	--end
	--self.allRenderDict = nil
	--if self.recycledGameObjectArray then
	--	for i, v in pairs(self.recycledGameObjectArray) do
	--		destroy(v)
	--	end
	--end
	--self.recycledGameObjectArray = nil
	self.startIndex = 0
	self.endIndex   = 0
	--if self.recycledRenderArray then
	--	for i = #self.recycledRenderArray, 1, -1 do
	--		self.recycledRenderArray[i]:Destroy()
	--		table.remove(self.recycledRenderArray, i)
	--	end
	--end
	--self.recycledRenderArray = nil
	self.toggleGroup:RemoveAllToggle()
	self:SetHorizontalScrollPosition(0, true)
	self:SetVerticalScrollPosition(0, true)
	self.scrollRect.velocity = VECTOR2_ZERO
	if self.pagination then
		self.pagination:SetValue(self.pagination.minimumValue)
		self.prevPage = 1
		self.nextPage = 1
	end
	return true
end

function ScrollLoopList:GetRenderers()
	return self.allRenderDict
end

function ScrollLoopList:GetRendererByIndex(index)
	return self.allRenderDict[index]
end

function ScrollLoopList:SelectByIndex(index)
	if not self.isSetDataAsyncComplete then
		self.waitSelectIndex = index
		return
	end
	if not self.toggleGroup then return end
	for i, v in pairs(self.toggleGroup:GetAllToggle()) do
		if v.index == index then
			self.toggleGroup:SelectByToggle(v)
		end
	end
end

function ScrollLoopList:GetSelectedIndex()
	if not self.toggleGroup then return 0 end
	local toggle = self.toggleGroup:GetSelectedToggle()
	if toggle then
		local toggleSelectedIndex = toggle:GetIndex()
		return toggleSelectedIndex
	end
	return 0
end

---@return nil @是否允许 整个ToggleGroup中没有一项是选中的
---@param value boolean @true允许，false不允许，默认值falset
function ScrollLoopList:AllowAllOff(value)
	if not self.toggleGroup then return end
	self.toggleGroup:AllowAllOff(value)
end

---@return nil @是否允许重复点击同一个
---@param value boolean @true允许重复点击某一个， false不允许，默认值为false
function ScrollLoopList:AllowRepeatSelected(value)
	if not self.toggleGroup then return end
	self.toggleGroup:AllowRepeatSelected(value)
end

---@return nil @是否允许将所有格子放入一个ToggleGroup中
---@param value boolean @true允许， false不允许，默认值为true
function ScrollLoopList:AllowMultiSelected(value)
	if not self.toggleGroup then return end
	self.toggleGroup:AllowMultiSelected(value)
end

function ScrollLoopList:ClearAllSelected()
	if not self.toggleGroup then return end
	self.toggleGroup:ClearAllSelected()
end

---@param func fun @注册一个回调函数，当列表内的renderer是可以选择的，并且选择改变了，那么会调用这个回调，并且参数会返回选择的render
function ScrollLoopList:OnSelectedItem(func)
	if not self.toggleGroup then return end
	self.onSelectedCallBack = func
	self.toggleGroup:OnSelectedItem(function(toggle)
		if self.onSelectedCallBack then
			self.onSelectedCallBack(toggle)
		end
	end)
end

function ScrollLoopList:OnItemValueChanged(func)
	if not self.toggleGroup then return end
	self.onValueChangedCallBack = func
	self.toggleGroup:OnItemValueChanged(function(toggle)
		if self.onValueChangedCallBack then
			self.onValueChangedCallBack(toggle)
		end
	end)
end

function ScrollLoopList:OnAllOff(func)
	if not self.toggleGroup then return end
	self.onAllOffCallBack = func
	self.toggleGroup:OnAllOff(self.onAllOffCallBack)
end

---@param func fun @注册一个回调函数，当点击了某一个renderer，那么会调用这个回调，并且参数会返回选择的render
function ScrollLoopList:OnClickItem(func)
	self.onClickItemCallBack = func
end

function ScrollLoopList:OnTouchDown(func)
	self.onTouchDownCallBack = func
end

function ScrollLoopList:OnTouchUp(func)
	self.onTouchUpCallBack = func
end

function ScrollLoopList:OnPrevPageChange(func)
	self.onPrevPageChange = func
end

function ScrollLoopList:OnNextPageChange(func)
	self.onNextPageChange = func
end

---@param render table @移除一个渲染，通过render来指定
function ScrollLoopList:RemoveRender(render)
	for i, v in pairs(self.allRenderDict) do
		if v == render then
			local removeRender = self.allRenderDict[i]
			if removeRender then
				self.allRenderDict[i] = nil
				self:_RecycledItemGameObject(removeRender:GetGameObject())
				self:_RecycledItemRender(removeRender)
				self.toggleGroup:RemoveToggle(removeRender)
			end
			break
		end
	end
end

function ScrollLoopList:Destroy()
	self:StopLateUpdate()
	if self.allRenderDict then
		for i, v in pairs(self.allRenderDict) do
			destroy(v:GetGameObject())
			v:Destroy()
			self.allRenderDict[i] = nil
		end
	end
	self.allRenderDict = nil
	if self.recycledRenderArray then
		for i = #self.recycledRenderArray, 1, -1 do
			self.recycledRenderArray[i]:Destroy()
			table.remove(self.recycledRenderArray, i)
		end
	end
	self.recycledRenderArray = nil
	if self.recycledGameObjectArray then
		for i, v in pairs(self.recycledGameObjectArray) do
			destroy(v)
		end
	end
	self.recycledGameObjectArray = nil
	self.scrollRect              = nil
	self.scrollRectTransform     = nil
	self.contentTSF              = nil
	self.firstPadderTSF          = nil
	self.endPadderTSF            = nil
	self.padding                 = nil
	self.spacing                 = nil
	self.itemPosArray            = nil
	self.recycledTSF             = nil
	self.constraint              = nil
	self.renderPrefabName        = nil
	if self.renderPrefabABPath then
		ResManager:UnloadAssetBundle(self.renderPrefabABPath)
		self.renderPrefabABPath = nil
	end
	self.renderClass        = nil
	self.TEMPLATEGameObject = nil
	if self.toggleGroup then
		self.toggleGroup:Destroy()
	end
	self.toggleGroup            = nil
	self.onSelectedCallBack     = nil
	self.onValueChangedCallBack = nil
	self.onClickItemCallBack    = nil
	self.onTouchDownCallBack    = nil
	self.onTouchUpCallBack      = nil
	self.onAllOffCallBack       = nil
	self.onPrevPageChange       = nil
	self.onNextPageChange       = nil
	if self.pagination then
		self.pagination:Destroy()
		self.pagination = nil
	end
	self.isSetDataAsyncComplete = false
	self.waitScrollIndex        = -1
	self.waitSelectIndex        = -1
	ScrollLoopList.superclass.Destroy(self)
end