UIManager                             = {}

UIManager.uiClassTab                  = {}

UIManager.layers                      = {}
UIManager.allUI                       = {}

UIManager.destoryList                 = {}

UIManager.mutexUI                     = {}
UIManager.ignoreRef                   = {}

UIManager.snapshotLayersVisible       = {}

UIManager.uiRoot                      = nil
UIManager._fullSizeDelta              = Vector2.zero
UIManager._uiReferenceResolution      = Vector2.zero
UIManager._uiCanvasFullSize           = Vector2.zero
UIManager._uiCanvasSafeSize           = Vector2.zero
UIManager._halfFullSizeDelta          = Vector2.zero
UIManager._screenRatio                = Vector2.zero
local LAYER_POS_THOUSAND              = Vector2.New(5000, 5000)
local LAYER_POS_ZERO                  = Vector2.zero
UIManager.isOnDestroyAllUIImmediately = false
function UIManager:Init()
	local go = GameObject.Find("UIRoot")
	if not go then
		logError("没有找到 UIRoot ")
	end

	local uiRoot = go:GetComponent(typeof(UIRoot))
	UIManager:SetUIRoot(uiRoot)

	self:InitScreenSize()

	self:CreateLayer(UILayerConsts.BUBBLE, 0)
	self:CreateLayer(UILayerConsts.TITLE, 1)
	self:CreateLayer(UILayerConsts.SKIPFONT, 2)
	self:CreateLayer(UILayerConsts.TOUCH, 3)
	self:CreateLayer(UILayerConsts.BOTTOM, 4)
	self:CreateLayer(UILayerConsts.HOME, 5)
	self:CreateLayer(UILayerConsts.CENTER_LOW2, 6)
	self:CreateLayer(UILayerConsts.CENTER_LOW1, 7)
	self:CreateLayer(UILayerConsts.CENTER, 8)
	self:CreateLayer(UILayerConsts.CENTER_HIGH1, 9)
	self:CreateLayer(UILayerConsts.CENTER_HIGH2, 10)
	self:CreateLayer(UILayerConsts.NPCTALK, 11)
	self:CreateLayer(UILayerConsts.TOP, 12)
	self:CreateLayer(UILayerConsts.STORY, 13)
	self:CreateLayer(UILayerConsts.NOTICE, 14)
	self:CreateLayer(UILayerConsts.LOADING, 15)

	-- 自动清理
	TimerManager:AddTimer(
			function()
				self:CheckDestoryUI()
			end,
			1,
			0
	)

end

function UIManager:InitScreenSize()
	if not self.uiRoot then return end
	--C#的UIRoot接口赋值给lua层，避免每次从Lua调用c#次数太多
	self._fullSizeDelta         = self.uiRoot:GetScreenFullSizeDelta()
	self._uiReferenceResolution = self.uiRoot:GetUIReferenceResolution()
	self._uiCanvasFullSize      = self.uiRoot:GetCanvasFullSize()
	self._uiCanvasSafeSize      = self.uiRoot:GetCanvasSafeSize()
	--self._uiCanvasSafeSize.x = self._uiCanvasSafeSize.x * 0.9 --TODO 测试用 模拟左右两侧安全区

	self._halfFullSizeDelta.x   = self._fullSizeDelta.x / 2
	self._halfFullSizeDelta.y   = self._fullSizeDelta.y / 2

	self._screenRatio.x         = self._fullSizeDelta.x / UnityEngine.Screen.width
	self._screenRatio.y         = self._fullSizeDelta.y / UnityEngine.Screen.height
end

function UIManager:GetScreenFullSizeDelta()
	return self._fullSizeDelta
end

function UIManager:GetUIReferenceResolution()
	return self._uiReferenceResolution
end

function UIManager:GetCanvasFullSize()
	return self._uiCanvasFullSize
end

function UIManager:GetCanvasSafeSize()
	return self._uiCanvasSafeSize
end

function UIManager:GetScreenHalfFullSizeDelta()
	return self._halfFullSizeDelta
end

function UIManager:GetScreenRatio()
	return self._screenRatio
end

function UIManager:ChangeScreenResolution(limitWidth)
	if not self.uiRoot then return end
	limitWidth = limitWidth or 0
	self.uiRoot:UpdateScreenSize(limitWidth, function()
		self:InitScreenSize()
	end)
end

function UIManager:CreateLayer(layerName, idx)
	if self.layers[layerName] then
		return
	end

	local go = GameObject.New(layerName)
	if not go then
		return
	end

	local transform = go:AddComponent(typeof(UnityEngine.RectTransform))

	transform:SetParent(self.uiRoot:GetStage(), false)
	transform.localScale    = Vector3.one
	transform.localPosition = Vector3.zero
	local layerSizeDelta
	if layerName == UILayerConsts.BUBBLE or
			layerName == UILayerConsts.TITLE or
			layerName == UILayerConsts.SKIPFONT or
			layerName == UILayerConsts.LOADING then
		layerSizeDelta = self:GetCanvasFullSize()
	else
		layerSizeDelta = self:GetCanvasSafeSize()
	end
	transform.sizeDelta    = layerSizeDelta

	local layer            = {}
	layer.name             = layerName
	layer.beginOrder       = idx * 1000
	layer.addIndex         = 0
	layer.visible          = true
	layer.go               = go
	layer.transform        = transform

	self.layers[layerName] = layer
end

--@desc 添加ui到层
--@ui: ui对象,
--@layerName: 层级名称
function UIManager:AddToLayer(ui, layerName)
	if not ui then
		logError("---AddToLayer--数据错误,ui对象为空------")
		return
	end

	layerName   = layerName or ui.parentNodeName
	local layer = self.layers[layerName]
	if not layer then
		logError("-----层级名称错误,没有需要的层级------" .. layerName)
		return
	end

	ui.transform:SetParent(layer.transform, false)

	if not ui.orderIdx then
		layer.addIndex = layer.addIndex + 10
		ui.orderIdx    = layer.addIndex
	end

	setOrder(ui.transform, layer.beginOrder + ui.orderIdx)

	setRenderOrderWithParent(ui.transform)
end

--@desc 添加ui到层
--@ui: ui对象,
--@layerName: 层级名称
function UIManager:RemoveFromLayer(ui, layerName)
	if not ui then
		logError("---RemoveFromLayer--数据错误,ui对象为空------")
		return
	end

	layerName   = layerName or ui.parentNodeName
	local layer = self.layers[layerName]
	if not layer then
		logError("---RemoveFromLayer--层级名称错误,没有当前层级------" .. layerName)
		return
	end

	-- 层级减一
	if ui.orderIdx == layer.addIndex then
		layer.addIndex = layer.addIndex - 10
	end
end

function UIManager:GetLayer(layerName)
	return self.layers[layerName]
end

function UIManager:GetLayerSortingOrder(layerName)
	local layer = self.layers[layerName]
	return layer and layer.beginOrder or 0
end

function UIManager:SetUIRoot(uiRoot)
	self.uiRoot = uiRoot
end

function UIManager:GetUIRoot()
	return self.uiRoot
end

-- 创建ui界面 统一接口
--@name 要创建的ui名称
--@arg 附加参数 外包传入数据
function UIManager:CreateUI(uiName, args, isMultiple)
	-- log(" ************* 开始 创建 对象 *************  "..uiName)
	if not uiName then
		return
	end

	local cls = self.uiClassTab[uiName]
	if not cls then
		logError(" 对象的类型错误, 无法创建 ---uiName---- " .. uiName .. " classType " .. tostring(cls))
		return
	end

	local uiView = cls.New()
	if not uiView then
		logError(" 创建对象失败 -- uiName --- " .. uiName)
		return
	end

	-- 判断是否可以显示
	if not uiView:IsCanShow(args) then
		uiView = nil
		return
	end

	uiView.uiname = uiName
	if isMultiple then
		local name = ""
		repeat
			name = string.format("%s%d", uiView.uiname, math.random(1, 10000))
		until (UIManager:GetUI(name) == nil)

		uiView.uiname = name
	end

	self:AddUI(uiView)

	uiView:Show(args)
	return uiView
end

-- 注册所有创建出来的ui
function UIManager:AddUI(uiView)
	if self.allUI[uiView.uiname] then
		logError(" 已存在此界面 无法注册 界面名: " .. uiView.uiname)
	end
	self.allUI[uiView.uiname] = uiView
end

function UIManager:GetUI(name)
	local ui = self.allUI[name]
	return ui
end

function UIManager:GetUIIncludeSubUI(name)
	local ui = self.allUI[name]
	if not ui then
		for i, v in pairs(self.allUI) do
			ui = self:_GetSubUI(v, name)
			if ui then
				break
			end
		end
	end
	return ui
end

function UIManager:_GetSubUI(subUI, name)
	for i, v in pairs(subUI.subUIList) do
		if v.uiname == name then
			return v
		end
	end
	local ui
	for i, v in pairs(subUI.subUIList) do
		ui = self:_GetSubUI(v, name)
		if ui then
			break
		end
	end
	return ui
end

-- 保存打开的界面
function UIManager:AddShowView(uiView)
	-- 从待删除列表移除
	for i, vo in ipairs(self.destoryList) do
		if vo.uiname == uiView.uiname then
			table.remove(self.destoryList, i)
			break
		end
	end
end

-- 关闭时从打开列表中移除
function UIManager:OnUIHide(uiView)
	-- 如果不销毁 那就隐藏
	if uiView:IsNeverDelete() and not self.isOnDestroyAllUIImmediately then
		uiView:SetShowState(false)
		return
	end

	if uiView:IsImmediatelyDelete() or self.isOnDestroyAllUIImmediately then
		if uiView.view then
			uiView:Destroy()
			destroy(uiView.go)
		end
		self.allUI[uiView.uiname] = nil
	else
		uiView:SetShowState(false)
		local hasOld = false
		for i, v in ipairs(self.destoryList) do
			if v and v.uiname == uiView.uiname then
				hasOld = true
				break
			end
		end
		if not hasOld then
			table.insert(self.destoryList, { uiname = uiView.uiname, time = GetCurTime() })
		end
	end
end

-- 销毁
function UIManager:CheckDestoryUI()
	local now = GetCurTime()
	local len = #self.destoryList
	for i = len, 1, -1 do
		local vo = self.destoryList[i]
		if now - vo.time > 30 then
			local ui = self.allUI[vo.uiname]
			if ui then
				if ui.view then
					ui:Destroy()
					destroy(ui.go)
				end
				ui                    = nil
				self.allUI[vo.uiname] = nil
				table.remove(self.destoryList, i)
			end
		end
	end
end

function UIManager:DestroyAllUIImmediately()
	self.isOnDestroyAllUIImmediately = true
	for i, ui in pairs(self.allUI) do
		ui:Hide()
	end
	self.isOnDestroyAllUIImmediately = false
end

function UIManager:HideAllPanel()
	--根据面板是全屏，并且是打开后背景虚化来判断是否关闭
	for i, ui in pairs(self.allUI) do
		if ui:IsShow() then
			if not ui:HasParentView() then
				if ui:IsFullScreen() or ui:IsScreenBlur() then
					ui:Hide()
				end
			end
		end
	end
end

-- 是否还有其它全面面板打开
function UIManager:HasOtherFullScenePanelOpened(currUI)
	for i, ui in pairs(self.allUI) do
		if not ui:HasParentView() and (not currUI or currUI.uiname ~= ui.uiname) then
			if ui:IsFullScreen() or ui:IsScreenBlur() then
				if ui:IsShow() then
					return true
				end
			end
		end
	end
end

--关闭互斥的界面
function UIManager:CheckMutexGroup(view)
	-- local mutexGroup = view:GetMutexGroup()
	-- if mutexGroup <= 0 then
	-- 	return
	-- end
	-- local view = view:GetMainView()
	-- local mutexView=self.mutexUI[mutexGroup]
	-- if mutexView and mutexView ~= view and mutexView:IsShow() then
	-- 	mutexView:Hide()
	-- end
	-- self.mutexUI[mutexGroup]=view
end

function UIManager:UpdateSceneCameraEnable()
	local hasFullScreen = self:_HasFullScreenUIOnShowList()
	local hasScreenBlur = self:_HasScreenBlurUIOnShowList()
	if SceneController:GetMainCamera() then
		SceneController:GetMainCamera():SetEnabled(not hasFullScreen)
		SceneController:GetMainCamera():SetEnabledTouchRotate(not hasScreenBlur and not hasFullScreen)
		SceneController:GetMainCamera():EnabledGaussianBlur(hasScreenBlur)
	end
end

function UIManager:_HasFullScreenUIOnShowList()
	for i, ui in pairs(self.allUI) do
		if ui:IsShow() and ui:IsFullScreen() and not ui:HasParentView() then
			return true
		end
	end
	return false
end

function UIManager:_HasScreenBlurUIOnShowList()
	for i, ui in pairs(self.allUI) do
		if ui:IsShow() and ui:IsScreenBlur() and not ui:HasParentView() then
			return true
		end
	end
	return false
end

-----------------------------------------------
-- 注册ui 统一接口
--@param uiName 要创建的ui名称
--@param classType ui对应的table
function UIManager:RegisterUIClass(uiName, classType)
	classType.CLASSNAME     = uiName
	self.uiClassTab[uiName] = classType
end

-- 显示ui界面
function UIManager:OpenUI(uiName, ...)
	local args   = { ... }
	local uiView = self:GetUI(uiName)
	--log("ui opened <<<<<<<<<<--------->>>>>>>>>> " ..uiName);
	if uiView and uiView:IsCanShow(args) then
		if not uiView:GoCanShow() then
			uiView:Show(args)
		elseif uiView:IsShow() then
			-- log("---xxxxxxxxxxxxxxxxxxxxxxxxxxxx---OpenUI------OnShow--------",uiName)
			uiView:OnShow(args)
		end
		return uiView
	end

	return self:CreateUI(uiName, args)
end

-- 隐藏ui界面
function UIManager:HideUI(uiName)
	local uiView = self:GetUI(uiName)
	if uiView then
		uiView:Hide()
	end
end
-- 显示UI界面，可以同时打开多个同一个面板
function UIManager:OpenMultipleUI(uiName, ...)
	local args = { ... }
	return self:CreateUI(uiName, args, true)
end
--隐藏UI界面，只能传递引用来查找隐藏，为了配合OpenMultipleUI来使用
function UIManager:HideMultipleUI(ui)
	for i, v in pairs(self.allUI) do
		if v == ui then
			v:Hide()
		end
	end
end

-- 是否显示
--@desc 界面是否显示
--@uiName 窗口名称
--@return true or false
function UIManager:IsShowView(uiName)
	local View = self:GetUI(uiName)
	if View then
		return View:IsShow()
	end
	return false
end

function UIManager:SnapshotAllLayerVisible()
	for i, layer in pairs(self.layers) do
		UIManager.snapshotLayersVisible[i] = layer.visible
	end
end

function UIManager:RecoverAllLayerVisibleFromSnapshot()
	for i, v in pairs(UIManager.snapshotLayersVisible) do
		if self.layers[i] then
			UIManager:_SetLayerVisible(self.layers[i].name, v)
		end
	end
	UIManager.snapshotLayersVisible = {}
	UIManager:UpdateSceneCameraEnable()
end
--@desc 除某层之外的所有层隐藏
--@RefType layer名称
function UIManager:HideLayerBeyond(...)
	local arg = { ... }
	for i, layer in pairs(self.layers) do
		local needHide = true
		for i, name in pairs(arg) do
			if layer.name == name then
				needHide = false
				break
			end
		end
		UIManager:_SetLayerVisible(layer.name, not needHide)
	end
	UIManager:UpdateSceneCameraEnable()
end

function UIManager:ShowLayerByName(...)
	local arg = { ... }
	for i, layer in pairs(self.layers) do
		for i, name in pairs(arg) do
			if layer.name == name then
				UIManager:_SetLayerVisible(layer.name, true)
			end
		end

	end
	UIManager:UpdateSceneCameraEnable()
end

function UIManager:HideLayerByName(...)
	local arg = { ... }
	for i, layer in pairs(self.layers) do
		for i, name in pairs(arg) do
			if layer.name == name then
				UIManager:_SetLayerVisible(layer.name, false)
			end
		end

	end
	UIManager:UpdateSceneCameraEnable()
end

--@desc 显示层级，除去参数中的不显示
--@RefType layer名称
function UIManager:ShowLayerBeyond(...)
	local arg = { ... }
	for i, layer in pairs(self.layers) do
		local needShow = true
		for i, name in pairs(arg) do
			if layer.name == name then
				needShow = false
				break
			end
		end
		UIManager:_SetLayerVisible(layer.name, needShow)
	end
end

function UIManager:HasLayer(layerName)
	for i, layer in pairs(self.layers) do
		if layer.name == layerName then
			return true
		end
	end
end

function UIManager:GetLayerVisible(layerName)
	for i, layer in pairs(self.layers) do
		if layer.name == layerName then
			return layer.visible
		end
	end
end

function UIManager:_SetLayerVisible(layerName, value)
	local layer = self.layers[layerName]
	if not layerName then return end
	layer.visible = value
	if value then
		layer.transform.anchoredPosition = LAYER_POS_ZERO
	else
		layer.transform.anchoredPosition = LAYER_POS_THOUSAND
	end
end

--@desc 获取当前transform所在的layer
function UIManager:CalcCurrLayer(tsf)
	if not tsf or tolua.isnull(tsf) then
		return
	end

	local parent = nil
	local layer  = nil

	local num    = 0
	while true do
		tsf = tsf.parent
		if not tsf or tolua.isnull(tsf) then
			return
		end

		layer = UIManager:GetLayer(tsf.name)
		if layer then
			return layer
		end

		num = num + 1
		if num > 50 then
			return
		end
	end
end