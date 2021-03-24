---@class ScrollList
---@field scrollRect UnityEngine.UI.ScrollRect
---@field contentTSF UnityEngine.Transform @内容容器的Transform
---@field isUseRenderPrefab boolean @是否使用外部的RenderPrefab
---@field renderPrefabName string @RenderPrefab的名字
---@field renderClass table @要进行迭代创建的renderClass
---@field renderList table @显示的格子集合
---@field toggleGroup ToggleGroup @所有格子的ToggleGroup用来处理单选问题
---@field useDefaultItemSize boolean @是否使用统一（默认的）item宽高，默认值true
---@field itemDefaultWidth number @item的统一宽度 通过SetItemDefaultWidth方法来设置，不设置会自动计算最大宽度
---@field itemDefaultHeight number @item的统一高度 通过SetItemDefaultHeight方法来设置，不设置会自动计算最大高度
_G.ScrollList = class(UGUIObject)

function ScrollList:ctor(transform)
	self.scrollRect              = nil
	self.scrollRectTransform     = nil
	self.contentTSF              = nil
	self.isUseRenderPrefab       = false
	self.renderPrefabName        = "template"
	self.renderPrefabABPath      = nil
	self.renderClass             = nil
	self.renderList              = {}
	self.recycledTSF             = nil
	---@field table<string, UnityEngine.GameObject> @存放回收的GameObjectArray
	self.recycledGameObjectArray = nil
	---@field table<table, UGUIObject> @存放renderClass实例的数组
	self.recycledRenderArray     = nil
	self.TEMPLATEGameObject      = nil
	self.toggleGroup             = ToggleGroup.New()
	self.useDefaultItemSize      = true
	self.itemDefaultWidth        = 0
	self.itemDefaultHeight       = 0
	self.constraint              = nil
	self.colCount                = nil
	self.rowCount                = nil
	self.padding                 = nil
	self.spacing                 = nil
	self.onSelectedCallBack      = nil
	self.onValueChangedCallBack  = nil
	self.onClickItemCallBack     = nil
	self.onTouchDownCallBack     = nil
	self.onTouchUpCallBack       = nil
	self.onAllOffCallBack        = nil
	self.useUGUIOriginalLayout   = false
	self.parentRenderList        = {}
	self.onSetDataAsyncComplete  = nil
	self.isSetDataAsyncComplete  = false
	self.waitScrollIndex         = -1
	self.waitSelectIndex         = -1
	self.contentHorizontalLayout = nil
	self.contentVerticalLayout   = nil
	self.contentSizeFitter       = nil
end

function ScrollList:_InitScrollRectComponent()
	if not self.transform then return end
	if not self.scrollRect then
		self.scrollRect = self.transform:GetComponent("ScrollRect")
	end
	if self.scrollRect and not self.scrollRectTransform then
		self.scrollRectTransform = self.scrollRect:GetComponent(typeof(UnityEngine.RectTransform))
	end
	if self.scrollRect and self.scrollRect.content and not self.contentTSF then
		self.contentTSF = self.scrollRect.content
	end
	if self.contentTSF then
		if not self.recycledTSF then
			self.recycledTSF = self.contentTSF
		end
		if not self.contentHorizontalLayout then
			self.contentHorizontalLayout = self.contentTSF:GetComponent(typeof(UnityEngine.UI.HorizontalLayoutGroup))
		end
		if not self.contentVerticalLayout then
			self.contentVerticalLayout = self.contentTSF:GetComponent(typeof(UnityEngine.UI.VerticalLayoutGroup))
		end
		if not self.contentSizeFitter then
			self.contentSizeFitter = self.contentTSF:GetComponent(typeof(UnityEngine.UI.ContentSizeFitter))
		end
	end
	if not self.recycledGameObjectArray then
		self.recycledGameObjectArray = {}
	end
	if not self.recycledRenderArray then
		self.recycledRenderArray = {}
	end
end

function ScrollList:_InitLayoutComponent()
	if not self.contentTSF then return end
	if not self.padding then
		self.padding = RectOffset.New(0, 0, 0, 0)
	end
	if not self.spacing then
		self.spacing = Vector2.New(0, 0)
	end
end

function ScrollList:GetScrollRect()
	return self.scrollRect
end

---@param value UnityEngine.Transform @指定一个容器作为内容容器(contentTSF)
function ScrollList:SetContainer(value)
	if not value then return end
	self.contentTSF = value
end

---@param value UnityEngine.UI.ScrollRect.MovementType @设置列表的滑动方式
function ScrollList:SetMovementType(value)
	self:_InitScrollRectComponent()
	if not self.scrollRect then return end
	self.scrollRect.movementType = value
end

---@param value boolean @设置滚动区域是否可以横向滚动
function ScrollList:SetHorizontal(value)
	self:_InitScrollRectComponent()
	if not self.scrollRect then return end
	self.scrollRect.horizontal = value
end

---@param value boolean @设置滚动区域是否可以纵向滚动
function ScrollList:SetVertical(value)
	self:_InitScrollRectComponent()
	if not self.scrollRect then return end
	self.scrollRect.vertical = value
end

---@param value number @设置横向滚动位置，只有当SetHorizontal(true)的时候才可以使用 取值范围[0,1]
function ScrollList:SetHorizontalScrollPosition(value)
	self:_InitScrollRectComponent()
	if not self.scrollRect then return end
	if not self.scrollRect.horizontal then return end
	value                                        = Mathf.Clamp01(value)
	self.scrollRect.horizontalNormalizedPosition = value
end

---@param value number @设置纵向滚动位置，SetVertical(true)的时候才可以使用 取值范围[0,1]
function ScrollList:SetVerticalScrollPosition(value)
	self:_InitScrollRectComponent()
	if not self.scrollRect then return end
	if not self.scrollRect.vertical then return end
	value                                      = Mathf.Clamp01(value)
	self.scrollRect.verticalNormalizedPosition = value
end

--@value: 移动的值
--@time: 持续时间
function ScrollList:DOHorizontalNormalizedPos(value, time)
	self:_InitScrollRectComponent()
	if not self.scrollRect then return end
	if not self.scrollRect.vertical then return end
	value = Mathf.Clamp01(value)
	self.scrollRect:DOKill()
	self.scrollRect:DOHorizontalNormalizedPos(value, time)
end

--@value: 移动的值
--@time: 持续时间
function ScrollList:DOVerticalNormalizedPos(value, time)
	self:_InitScrollRectComponent()
	if not self.scrollRect then return end
	if not self.scrollRect.vertical then return end
	value = Mathf.Clamp01(value)
	self.scrollRect:DOKill()
	self.scrollRect:DOVerticalNormalizedPos(value, time)
end

--@vec2: Vector2类型
--@time: 持续时间
function ScrollList:DONormalizedPos(vec2, time)
	self:_InitScrollRectComponent()
	if not self.scrollRect then return end
	if not self.scrollRect.vertical then return end
	vec2 = Mathf.Clamp01(vec2)
	self.scrollRect:DOKill()
	self.scrollRect:DONormalizedPos(vec2, time)
end

function ScrollList:GetItemPos(index)
	if not self.isSetDataAsyncComplete then
		self.waitScrollIndex = index
	end
	if not self.itemPosArray then return end
	index     = Mathf.Clamp(index, 1, #self.itemPosArray)
	local pos = self.itemPosArray[index]
	return pos
end

function ScrollList:SetScrollBegin()
	self:SetScrollIndex(1)
end

function ScrollList:SetScrollEnd()
	if not self.itemPosArray then return end
	self:SetScrollIndex(#self.itemPosArray)
end

---@param index number @设置内容滚动到index位置，取值范围是[1, #dataList]
function ScrollList:SetScrollIndex(index)
	if not self.isSetDataAsyncComplete then
		self.waitScrollIndex = index
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
end

function ScrollList:GetScrollIndexPos(index)
	if not self.isSetDataAsyncComplete then
		self.waitScrollIndex = index
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
		x = Mathf.Clamp(x, 0, (self.contentTSF.sizeDelta.x - self.scrollRectTransform.sizeDelta.x))
		return Vector2.New(-(x), 0)
	elseif self.scrollRect.vertical then
		y = Mathf.Clamp(y, 0, (self.contentTSF.sizeDelta.y - self.scrollRectTransform.sizeDelta.y))
		return Vector2.New(0, y)
	end
end

---@param value number @设置每列数量
function ScrollList:SetColCount(value)
	self.constraint = UnityEngine.UI.GridLayoutGroup.Constraint.FixedColumnCount
	self.colCount   = value
end

---@param value number @设置每行数量
function ScrollList:SetRowCount(value)
	self.constraint = UnityEngine.UI.GridLayoutGroup.Constraint.FixedRowCount
	self.rowCount   = value
end

---@param left number @容器左边距
---@param right number @容器右边距
---@param top number @容器上边距
---@param bottom number @容器下边距
function ScrollList:SetPadding(left, right, top, bottom)
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
function ScrollList:SetSpacing(x, y)
	self:_InitLayoutComponent()
	if self.spacing then
		self.spacing.x = x
		self.spacing.y = y
	end
end

function ScrollList:SetItemDefaultWidth(value)
	self.itemDefaultWidth = value
end

function ScrollList:GetItemWidth(index)
	if self.useDefaultItemSize then
		return self.itemDefaultWidth
	end
end

function ScrollList:SetItemDefaultHeight(value)
	self.itemDefaultHeight = value
end

function ScrollList:GetItemHeight(index)
	if self.useDefaultItemSize then
		return self.itemDefaultHeight
	end
end

---@return nil @设置为true不使用ScrollList的布局方式，采用unity中UGUI组件的布局比如（H/V LayoutGroup） 默认值false
function ScrollList:UseUGUIOriginalLayout(value)
	self.useUGUIOriginalLayout = value
end

---@return nil @调用这个函数并且设置了prefabName表示要使用一个外部的prefab进行迭代显示,如果从来不调用，则表示使用内部的template。如果设置nil，表示使用的renderPrefab和renderClass都从RenderVO中指定
function ScrollList:UseRenderPrefab(prefabName)
	self.isUseRenderPrefab = true
	self.renderPrefabName  = prefabName
end

---@param _class table @要进行迭代创建的renderClass
function ScrollList:SetRenderClass(_class)
	self.renderClass = _class
end

---@param dataList table @根据dataList中的renderVO来进行显示，这里会根据之前设置的renderClass来依次生成显示控制类，如果之前设置过renderPrefabName，那么会先加载然后复制出GameObject赋值过去，如果之前没有设置过，那么会找到content下的名为template的节点进行复制
function ScrollList:SetDataProvider(dataList)
	if not dataList or #dataList == 0 then
		self:Clean()
		return
	end
	if not self.renderClass then
		--如果没有指定统一的renderClass，那么需要把现有的都放入对象池回收
		self:Clean()
	end
	self:_InitScrollRectComponent()
	self:_InitLayoutComponent()
	self.toggleGroup:RemoveAllToggle()
	self.toggleGroup:OnSelectedItem(function(toggle)
		if self.onSelectedCallBack then
			self.onSelectedCallBack(toggle)
		end
	end)

	self.toggleGroup:OnAllOff(self.onAllOffCallBack)
	self.isSetDataAsyncComplete = false
	self.waitScrollIndex        = -1
	self.waitSelectIndex        = -1
	local loadedCallBack        = function(gameObject)
		if self:IsDestroyed() then
			return
		end
		---@type UnityEngine.GameObject
		self.TEMPLATEGameObject = gameObject
		if self.TEMPLATEGameObject then
			self.TEMPLATEGameObject:SetActive(true)
			self.toggleGroup:SetInternalMode(true)
			local template_sizeDelta = getRectTransformPreferredSize(self.TEMPLATEGameObject.transform, true)
			if self.useDefaultItemSize then
				if self.itemDefaultWidth == 0 then
					self.itemDefaultWidth = template_sizeDelta.x
				end
				if self.itemDefaultHeight == 0 then
					self.itemDefaultHeight = template_sizeDelta.y
				end
			end
		end
		for index, data in ipairs(dataList) do
			local render
			if index <= #self.renderList then
				render = self.renderList[index]
			else
				local newGO = self:_GetItemGameObject(index, data)
				render      = self:_GetItemRender(newGO, data)
				table.insert(self.renderList, render)
			end

			render:SetParent(self.contentTSF)
			render:SetVisible(true)
			render:SetRendererList(self)
			render:SetParentRendererList(self.parentRenderList)
			render:SetIndex(index)
			self.toggleGroup:AddToggle(render)
			render:SetData(data)
			if not self.renderClass then
				render:SetAsLastSibling()
			end
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
		for i = #self.renderList, #dataList + 1, -1 do
			local render = self.renderList[i]
			self:_RecycledItemGameObject(render:GetGameObject(), render.data.renderPrefabName or self.renderPrefabName)
			self.toggleGroup:RemoveToggle(render)
			self:_RecycledItemRender(render, render.data.renderClass or self.renderClass)
			table.remove(self.renderList, i)
		end
		if self.TEMPLATEGameObject then
			self.TEMPLATEGameObject:SetActive(false)
		end
		self:_CalcContentTotalSize()
		self:_CalcEachItemPos()
		self.toggleGroup:OnItemValueChanged(function(toggle)
			if self.onValueChangedCallBack then
				self.onValueChangedCallBack(toggle)
			end
		end)
		self.toggleGroup:SetInternalMode(false)
		self.isSetDataAsyncComplete = true
		if self.waitScrollIndex >= 0 then
			self:SetScrollIndex(self.waitScrollIndex)
			self.waitScrollIndex = -1
		end
		if self.waitSelectIndex >= 0 then
			self:SelectByIndex(self.waitSelectIndex)
			self.waitSelectIndex = -1
		end
		self:RefreshUGUIOriginalLayout()
		if self.onSetDataAsyncComplete then
			self.onSetDataAsyncComplete()
			self.onSetDataAsyncComplete = nil
		end
	end

	if self.isUseRenderPrefab then
		if self.renderPrefabName then
			if self.TEMPLATEGameObject then
				loadedCallBack(self.TEMPLATEGameObject)
			else
				local abPath            = ResUtil:GetUIPath(self.renderPrefabName)
				self.renderPrefabABPath = abPath
				ResManager:LoadPrefabAsync(abPath, loadedCallBack)
			end
		else
			loadedCallBack()
		end
	else
		local tempNode = findChild(self.contentTSF, 'template') or findChild(self.contentTSF, 'Template')
		if tempNode then
			loadedCallBack(tempNode)
		end
	end
end

local VECTOR2_ZERO = Vector2.zero
function ScrollList:_RecycledItemGameObject(gameObject, renderPrefabName)
	if not self.recycledTSF then return end
	if not gameObject then return end
	gameObject.transform:SetParent(self.recycledTSF, false)
	gameObject.transform.anchoredPosition = VECTOR2_ZERO
	gameObject:SetActive(false)
	if not self.recycledGameObjectArray[renderPrefabName] then
		self.recycledGameObjectArray[renderPrefabName] = {}
	end
	table.insert(self.recycledGameObjectArray[renderPrefabName], gameObject)
end

function ScrollList:_RecycledItemRender(render, renderClass)
	render:OnClick(nil)
	render:OnClear()
	render:ClearGameObject()
	render:ClearTransform()
	if self.toggleGroup then
		self.toggleGroup:RemoveToggle(render)
	end
	if not self.recycledRenderArray[renderClass] then
		self.recycledRenderArray[renderClass] = {}
	end
	table.insert(self.recycledRenderArray[renderClass], render)
end

function ScrollList:_GetItemGameObject(i, data)
	local go
	local prefabName = self.renderPrefabName or data.renderPrefabName
	local array      = self.recycledGameObjectArray[prefabName]
	if array and #array > 0 then
		go = table.remove(array, #array)
		if go then
			go:SetActive(true)
			return go
		end
	else
		if self.TEMPLATEGameObject then
			local go = newObject(self.TEMPLATEGameObject)
			return go
		else
			local abPath = ResUtil:GetUIPath(prefabName)
			local uiObj  = ResManager:LoadPrefab(abPath)
			if uiObj then
				local go   = newObject(uiObj)
				local view = GLuaComponent.Add(go, View)
				if view then
					view:SetAssetBundleName(prefabName)
					view:SetAssetBundlePath(abPath)
				end
				return go
			end
		end
	end
end

function ScrollList:_GetItemRender(go, data)
	local render
	local renderClass = self.renderClass or data.renderClass
	local array       = self.recycledRenderArray[renderClass]
	if array and #array > 0 then
		render = table.remove(array, #array)
		render:SetGameObject(go)
	else
		if renderClass then
			render = renderClass.New(go.transform)
		end
		if render then
			render:OnLoaded()
		end
	end
	return render
end

function ScrollList:_CalcEachItemPos()
	if not self.renderList then return end
	if self.useUGUIOriginalLayout then return end
	self.itemPosArray = {}
	local x, y
	for i, v in pairs(self.renderList) do
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
		y                             = y * -1
		self.itemPosArray[i]          = { x = x, y = y }
		local go                      = v:GetGameObject()
		go.transform.anchorMax        = Vector2.New(0, 1)
		go.transform.anchorMin        = Vector2.New(0, 1)
		go.transform.pivot            = Vector2.New(0.5, 0.5)
		go.transform.anchoredPosition = Vector2.New(x, y)
		go.transform.sizeDelta        = Vector2.New(self:GetItemWidth(i), self:GetItemHeight(i))
	end
end

function ScrollList:_CalcContentTotalSize()
	if not self.contentTSF then return end
	if self.useUGUIOriginalLayout then return end
	local dataLength = #self.renderList
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

---@return nil @对于ScrollList来说调动Clean方法就是为了清空列表的显示，如果是将列表重新SetDataProvider之前，请不要调用这个Clean因为会破坏render的复用。
function ScrollList:Clean()
	self:_InitScrollRectComponent()
	self:_InitLayoutComponent()
	local tempNode = findChild(self.contentTSF, 'template') or findChild(self.contentTSF, 'Template')
	if tempNode then
		tempNode:SetActive(false)
	end
	if not self.renderList then return end
	for i = #self.renderList, 1, -1 do
		local render = self.renderList[i]
		self:_RecycledItemGameObject(render:GetGameObject(), render.data.renderPrefabName or self.renderPrefabName)
		self.toggleGroup:RemoveToggle(render)
		self:_RecycledItemRender(render, render.data.renderClass or self.renderClass)
		table.remove(self.renderList, i)
	end
	self.toggleGroup:RemoveAllToggle()
	if not self.useUGUIOriginalLayout then
		self.contentTSF.sizeDelta = Vector2.zero
	end
	return true
end

function ScrollList:RefreshUGUIOriginalLayout()
	if not self.useUGUIOriginalLayout then return end
	if self.contentHorizontalLayout then
		self.contentHorizontalLayout:SetLayoutHorizontal()
		self.contentHorizontalLayout:CalculateLayoutInputHorizontal()
	end
	if self.contentVerticalLayout then
		self.contentVerticalLayout:SetLayoutVertical()
		self.contentVerticalLayout:CalculateLayoutInputVertical()
	end
	if self.contentSizeFitter then
		self.contentSizeFitter:SetLayoutHorizontal()
		self.contentSizeFitter:SetLayoutVertical()
	end
end

function ScrollList:GetRenderers()
	return self.renderList
end

function ScrollList:GetRendererCount()
	return self.renderList and #self.renderList or 0
end

function ScrollList:GetRendererByIndex(index)
	return self.renderList[index]
end

function ScrollList:SelectByIndex(index)
	if not self.isSetDataAsyncComplete then
		self.waitSelectIndex = index
		return
	end
	if self.itemPosArray then
		index = Mathf.Clamp(index, 1, #self.itemPosArray)
	end
	if not self.toggleGroup then return end
	self.toggleGroup:SelectByIndex(index)
end

function ScrollList:GetSelectedIndex()
	if not self.toggleGroup then return end
	return self.toggleGroup:GetSelectedIndex()
end

function ScrollList:GetLastSelectedIndex()
	if not self.toggleGroup then return end
	return self.toggleGroup:GetLastSelectedIndex()
end

function ScrollList:GetContentTSF()
	return self.contentTSF
end

function ScrollList:AutoSizeWithContent()
	if not self.contentTSF then return end
	self:SetSizeDelta(self.contentTSF.sizeDelta.x, self.contentTSF.sizeDelta.y)
end

---@return nil @是否允许 整个ToggleGroup中没有一项是选中的
---@param value boolean @true允许，false不允许，默认值false
function ScrollList:AllowAllOff(value)
	if not self.toggleGroup then return end
	self.toggleGroup:AllowAllOff(value)
end

---@return nil @是否允许重复点击同一个
---@param value boolean @true允许重复点击某一个， false不允许，默认值为false
function ScrollList:AllowRepeatSelected(value)
	if not self.toggleGroup then return end
	self.toggleGroup:AllowRepeatSelected(value)
end

---@return nil @是否允许将所有格子放入一个ToggleGroup中
---@param value boolean @true允许， false不允许，默认值为true
function ScrollList:AllowMultiSelected(value)
	if not self.toggleGroup then return end
	self.toggleGroup:AllowMultiSelected(value)
end

function ScrollList:ClearAllSelected()
	if not self.toggleGroup then return end
	self.toggleGroup:ClearAllSelected()
end

---@param func fun @注册一个回调函数，当列表内的renderer是可以选择的，并且选择改变了，那么会调用这个回调，并且参数会返回选择的render
function ScrollList:OnSelectedItem(func)
	if not self.toggleGroup then return end
	self.onSelectedCallBack = func
end

function ScrollList:OnItemValueChanged(func)
	if not self.toggleGroup then return end
	self.onValueChangedCallBack = func
end

function ScrollList:OnAllOff(func)
	if not self.toggleGroup then return end
	self.onAllOffCallBack = func
end

---@param func fun @注册一个回调函数，当点击了某一个renderer，那么会调用这个回调，并且参数会返回选择的render
function ScrollList:OnClickItem(func)
	self.onClickItemCallBack = func
end

function ScrollList:OnSetDataAsyncComplete(func)
	self.onSetDataAsyncComplete = func
end

function ScrollList:OnTouchDown(func)
	self.onTouchDownCallBack = func
end

function ScrollList:OnTouchUp(func)
	self.onTouchUpCallBack = func
end

function ScrollList:SetParentRendererList(list)
	self.parentRenderList = list
end

---@param render table @移除一个渲染，通过render来指定
function ScrollList:RemoveRender(render)
	for i, v in pairs(self.renderList) do
		if v == render then
			render:OnClear()
			destroy(render:GetGameObject())
			self.toggleGroup:RemoveToggle(render)
			table.remove(self.renderList, i)
			self:_CalcContentTotalSize()
			self:_CalcEachItemPos()
			break
		end
	end
end

function ScrollList:Destroy()
	if self.scrollRect then
		self.scrollRect:DOKill()
	end

	if self.recycledRenderArray then
		for i = #self.recycledRenderArray, 1, -1 do
			local array = self.recycledRenderArray[i]
			for j = #array, 1, -1 do
				array[j]:Destroy()
				table.remove(array, j)
			end
			self.recycledRenderArray[i] = nil
		end
	end
	self.recycledRenderArray = nil
	if self.recycledGameObjectArray then
		for i, v in pairs(self.recycledGameObjectArray) do
			for index_go, go in pairs(v) do
				destroy(go)
			end
			v = nil
		end
	end
	self.recycledGameObjectArray = nil
	self.scrollRect              = nil
	self.scrollRectTransform     = nil
	self.contentTSF              = nil
	self.recycledTSF             = nil
	self.renderPrefabName        = nil
	if self.renderPrefabABPath then
		ResManager:UnloadAssetBundle(self.renderPrefabABPath)
		self.renderPrefabABPath = nil
	end
	self.renderClass = nil
	for i = #self.renderList, 1, -1 do
		self.renderList[i]:Destroy()
		destroy(self.renderList[i].go)
		table.remove(self.renderList, i)
	end
	self.renderList         = nil
	self.TEMPLATEGameObject = nil
	if self.toggleGroup then
		self.toggleGroup:Destroy()
	end
	self.toggleGroup             = nil
	self.constraint              = nil
	self.padding                 = nil
	self.spacing                 = nil
	self.onSelectedCallBack      = nil
	self.onValueChangedCallBack  = nil
	self.onClickItemCallBack     = nil
	self.onTouchDownCallBack     = nil
	self.onTouchUpCallBack       = nil
	self.onAllOffCallBack        = nil
	self.onSetDataAsyncComplete  = nil
	self.isSetDataAsyncComplete  = false
	self.waitScrollIndex         = -1
	self.waitSelectIndex         = -1
	self.contentHorizontalLayout = nil
	self.contentVerticalLayout   = nil
	self.contentSizeFitter       = nil
	ScrollList.superclass.Destroy(self)
end