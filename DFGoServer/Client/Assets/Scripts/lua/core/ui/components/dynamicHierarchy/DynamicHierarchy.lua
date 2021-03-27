--
-- 版权所有: 北京燧木科技有限公司
-- Author: wangningdong
-- Date: 2020-6-8 21:24:12
-- 动态层级
-- 动态层级需要使用原生ScrollView
-- 有多少depth层 需要预先创建多少个template, 命名template1, template2, template3 ...
-- 有多少depth层 需要创建对应的层级挂点(除首层外), 命名 node2, node3 ...
-- 列表元素类 必须继承自 DynamicHierarchyToggle
-- 列表默认无任何选中

_G.DynamicHierarchy = class()

function DynamicHierarchy:ctor()
	self.list = nil -- ScrollList

	self.dataList = nil -- 数据

	self._togCallBack = nil -- 点击回调

	------------------------------
	self.templateTab = {} -- 模板缓存

	self._renderClass = DynamicHierarchyToggle -- 渲染类

	------------------------------
	self.depthNode = {} -- 层级挂点(首层不需要)

	------------------------------
	self.firstGroup = nil -- 首层toggle组
	self.otherGroup = {} -- 其它toggle组

	self.firstLastIdx = 0 -- 首层上次选择
	self.otherLastIdx = {} -- 其它层上次选择
end

--@desc 初始化动态层级
--@scrollView: ScrollList 组件实例
--@renderClass: 渲染类 必须继承自 DynamicHierarchyToggle
--@togCall: 选中回调
function DynamicHierarchy:Init(scrollView, renderClass, togCall)
	self.list = scrollView
	self._renderClass = renderClass or DynamicHierarchyToggle
	self._togCallBack = togCall
end

-- 设置toggle渲染类
function DynamicHierarchy:SetRenderClass(class)
	self._renderClass = class or DynamicHierarchyToggle
end

-- 设置点击回调
function DynamicHierarchy:SetToggleCall(func)
	self._togCallBack = func
end

-------------------------------------------------------------------------------
-- 首层点击
function DynamicHierarchy:_TogFirstValueChanged(toggle)
	if toggle:GetIsOn() then
		toggle:Open()

		local data = toggle:GetData()
		if data.childList then
			self:Clean()
			self:CreateNodeNext(data.childList, toggle:GetIndex())
		end

		if self._togCallBack then
			self._togCallBack(toggle)
		end

		self.firstLastIdx = toggle:GetIndex()
	else
		toggle:Close()

		if self.firstLastIdx == toggle:GetIndex() then
			self.firstLastIdx = 0
			self:Clean()
		end
	end
end

-- 其它层点击
function DynamicHierarchy:_TogValueChanged(toggle)
	local data = toggle:GetData()

	if toggle:GetIsOn() then
		toggle:Open()

		if data.childList then
			self:ClearOtherSelected(data:GetDepth())
			self:CreateNodeNext(data.childList, toggle:GetIndex())
		end

		if self._togCallBack then
			self._togCallBack(toggle)
		end

		self.otherLastIdx[data:GetDepth()] = toggle:GetIndex()
	else
		toggle:Close()

		if self.otherLastIdx[data:GetDepth()] == toggle:GetIndex() then
			self.otherLastIdx[data:GetDepth()] = 0
			self:ClearOtherSelected(data:GetDepth())
		end
	end
end

-------------------------------------------------------------------------------
-- 设置数据 需要传入的数据格式 { ... DynamicHierarchyVO ...  }
function DynamicHierarchy:SetDataProvider(dataList)
	self.dataList = dataList

	self:CreateNodeFirst(dataList)
end

-- 创建首层节点
function DynamicHierarchy:CreateNodeFirst(dataList)
	self.firstGroup = ToggleGroup.New()
	self.firstGroup:AllowAllOff(true)
	self.firstGroup:AllowRepeatSelected(true)
	self.firstGroup:OnItemValueChanged(
		function(toggle)
			self:_TogFirstValueChanged(toggle)
		end
	)

	for i, vo in ipairs(dataList) do
		local template = self.templateTab[vo:GetDepth()]
		if not template then
			self.templateTab[vo:GetDepth()] = UGUIObject.New(self.list.contentTSF:Find("template" .. vo:GetDepth()))
			template = self.templateTab[vo:GetDepth()]
			template:SetVisible(false)
		end

		local node = GameObject.Instantiate(template:GetGameObject())
		if node then
			node = self._renderClass.New(node.transform)
			node:OnLoaded()
			node:SetParent(self.list.contentTSF)
			node:SetVisible(true)
			node:SetSiblingIndex(i - 1)
			node:SetData(vo)
			self.firstGroup:AddToggle(node)
		end
	end
end

-- 创建下一层节点
function DynamicHierarchy:CreateNodeNext(dataList, parentIdx)
	local firstVo = nil

	-- 创建节点
	for i, vo in ipairs(dataList) do
		if not firstVo then
			firstVo = vo
		end

		-- 判断有没有当前层级组
		local togGroup = self.otherGroup[vo:GetDepth()]
		if not togGroup then
			-- 创建当前层级组
			togGroup = ToggleGroup.New()
			togGroup:OnItemValueChanged(
				function(toggle)
					self:_TogValueChanged(toggle)
				end
			)

			if not vo:IsLastDepth() then
				togGroup:AllowAllOff(true)
				togGroup:AllowRepeatSelected(true)
			end

			self.otherGroup[vo:GetDepth()] = togGroup
		end

		-- 从当前层级组中取出toggle
		local node = togGroup:GetToggle(i)
		if not node then
			-- 创建新的toggle
			local template = self.templateTab[vo:GetDepth()]
			if not template then
				self.templateTab[vo:GetDepth()] = UGUIObject.New(self.list.contentTSF:Find("template" .. vo:GetDepth()))
				template = self.templateTab[vo:GetDepth()]
				template:SetVisible(false)
			end

			node = GameObject.Instantiate(template:GetGameObject())
			if node then
				node = self._renderClass.New(node.transform)
				node:OnLoaded()

				-- 放入对应的层级挂点
				local parentNode = self:GetDepthNodeName(vo:GetDepth())
				if parentNode then
					node:SetParent(parentNode:GetTransform())
				else
					node:SetParent(self.list.contentTSF)
				end

				togGroup:AddToggle(node)
			end
		end

		-- 设置数据
		if node then
			node:SetVisible(true)
			node:SetData(vo)
		end
	end

	-- 将当前层级挂点设置到对应的层级  并设置位置
	if firstVo then
		local parentVO = firstVo:GetParent()
		if parentVO then

			local myNode = self:GetDepthNodeName(firstVo:GetDepth())
			if myNode then

				local parentNode = self:GetDepthNodeName(parentVO:GetDepth())
				if parentNode then
					myNode:SetParent(parentNode:GetTransform())
				else
					myNode:SetParent(self.list.contentTSF)
				end

				myNode:SetSiblingIndex(parentIdx)
			end
		end
	end
end

-- 获取层级挂点
function DynamicHierarchy:GetDepthNodeName(depth)
	if depth == 1 then
		return
	end

	if not self.depthNode[depth] then
		local tsf = self.list.contentTSF:Find("node" .. depth)
		if not tsf or tolua.isnull(tsf) then
			return
		end
		self.depthNode[depth] = UGUIObject.New(tsf)
	end

	return self.depthNode[depth]
end

-- 设置默认选中项
function DynamicHierarchy:SelectedById(id)
	if not id then
		return
	end

	local idxTab = {}

	local function findIdx(vo)
		if not vo then
			return false
		end

		if vo.childList and #vo.childList > 0 then
			for i, v in ipairs(vo.childList) do
				if findIdx(v) then
					table.insert(idxTab, {depth = v:GetDepth(), idx = i})
					return true
				end
			end

			return false
		else
			return vo:GetId() == id
		end
	end

	for i, vo in ipairs(self.dataList or {}) do
		if findIdx(vo) then
			table.insert(idxTab, {depth = vo:GetDepth(), idx = i})
		end
	end

	local firstInfo = table.remove(idxTab)
	if not firstInfo or firstInfo.depth ~= 1 then
		return
	end

	self.firstGroup:SelectByIndex(firstInfo.idx)

	for i = 1, #idxTab do
		local info = table.remove(idxTab)
		if info then
			local togGroup = self.otherGroup[info.depth]
			if togGroup then
				togGroup:SelectByIndex(info.idx)
			end
		end
	end
end

-- 清理层级
function DynamicHierarchy:ClearOtherSelected(depth)
	depth = depth or 1
	for k, togGroup in pairs(self.otherGroup) do
		if k > depth then
			togGroup.internalMode = true
			togGroup:ClearAllSelected()
			togGroup.internalMode = false

			local childList = togGroup:GetAllToggle()
			for i, tog in ipairs(childList) do
				tog:SetVisible(false)
			end
		end
	end
end

function DynamicHierarchy:GetDataList()
	return self.dataList
end

function DynamicHierarchy:Refresh()
	for k, togGroup in pairs(self.otherGroup) do
		local list = togGroup:GetAllToggle()
		for k, tog in pairs(list) do
			tog:Refresh()
		end
	end

	local list = self.firstGroup:GetAllToggle()
	for k, tog in pairs(list) do
		tog:Refresh()
	end
end

-- 清理
function DynamicHierarchy:Clean()
	for k, node in pairs(self.depthNode) do
		node:SetAsLastSibling()
	end

	self:ClearOtherSelected()
end

-- 销毁
function DynamicHierarchy:Destroy()
	for k, togGroup in pairs(self.otherGroup) do
		local list = togGroup:GetAllToggle()
		for k, tog in pairs(list) do
			tog:Destroy()
		end
		togGroup:Destroy()
	end

	self.otherGroup = nil

	local list = self.firstGroup:GetAllToggle()
	for k, tog in pairs(list) do
		tog:Destroy()
	end
	self.firstGroup:Destroy()
	self.firstGroup = nil

	self.firstLastIdx = nil -- 首层上次选择
	self.otherLastIdx = nil -- 其它层上次选择

	self.dataList = nil

	for k, obj in pairs(self.templateTab) do
		obj:Destroy()
	end
	self.templateTab = nil

	for k, obj in pairs(self.depthNode) do
		obj:Destroy()
	end
	self.depthNode = nil

	self._togCallBack = nil -- 点击回调
end
