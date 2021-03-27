_G.BaseUI = class()

--[[参数,UI名字,继承的UI类]]
function BaseUI:ctor()
	self.uiname                      = "BaseUI"
	self.facade                      = GameApp.facade

	self.prefabName                  = ""
	self.prefabIsLoad                = false
	self.go                          = nil
	self.transform                   = nil
	self.view                        = nil
	self.args                        = nil
	self.parentNodeName              = nil -- 父节点名称
	self.parentView                  = nil
	self.subUIList                   = {}

	self.orderIdx                    = nil    -- 如果有值,则使用此值作为当前层级,否则动态设置

	self.notificationList            = {}
	self.updateKey                   = nil

	self.isShow                      = false -- 是否显示
	self.goCanShow                   = false -- gameObject是否需要显示

	self.funcId                      = nil
	self.redPointList                = nil
	self.ownMaskList                 = nil
	self.drawModelSceneList          = nil -- BaseUI提供多个drawModel的支持
	self.rootAnim                    = nil
	self._onAsyncLoadAndShowComplete = nil
	self.AddChild                    = function(self, name, childClass, parentNodeName)
		if not self.childList then
			self.childList = {}
		end
		local vo          = {}
		vo.name           = name
		vo.childClass     = childClass
		vo.parentNodeName = parentNodeName
		table.insert(self.childList, vo)
	end
end

function BaseUI:GetTransform()
	return self.transform
end

function BaseUI:SetActive(value)
	if self.go and not tolua.isnull(self.go) then
		self.go:SetActive(value)
	end
end

function BaseUI:GetSizeDelta()
	if self.transform then
		return self.transform.sizeDelta
	end
	return Vector2.zero
end

function BaseUI:GetRect()
	if self.transform then
		return self.transform.rect
	end
end

function BaseUI:GetPivot()
	if self.transform then
		return self.transform.pivot
	end
end

function BaseUI:SetWorldPos(pos)
	if self.transform then
		self.transform.position = pos or Vector3.zero
	end
end

---@return Vector3 @获取世界坐标
function BaseUI:GetWorldPos()
	if not self.transform then
		return Vector3.zero
	end
	return self.transform.position
end

-- 设置位置
function BaseUI:SetPos(pos)
	if self.transform then
		self.transform.localPosition = pos or Vector3.zero
	end
end

function BaseUI:GetPos()
	if self.transform then
		return self.transform.localPosition
	end
	return Vector3.zero
end

-- 设置位置(相对于锚点的位置)
function BaseUI:SetAnchoredPosition(pos)
	if self.transform then
		self.transform.anchoredPosition = pos or Vector2.zero
	end
end

-- 设置位置(相对于锚点的位置)
function BaseUI:GetAnchoredPosition()
	if self.transform then
		return self.transform.anchoredPosition
	end
	return Vector2.zero
end

function BaseUI:SetOffsetMin(a, b)
	if self.transform then
		self.transform.offsetMin = Vector2.New(a, b)
	end
end

function BaseUI:SetOffsetMax(a, b)
	if self.transform then
		self.transform.offsetMax = Vector2.New(a, b)
	end
end

function BaseUI:SetSizeDelta(width, height)
	if self.transform then
		self.transform.sizeDelta = Vector2.New(width, height)
	end
end

-- 强制立即重建布局
function BaseUI:ForceRebuildLayoutImmediate()
	if not self.transform then
		return
	end
	LayoutRebuilder.ForceRebuildLayoutImmediate(self.transform)
end

function BaseUI:GetSortingOrder()
	if not self:GetTransform() then return 0 end
	if tolua.isnull(self.transform) then return 0 end
	local canvas = self.go:GetComponent(typeof(UnityEngine.Canvas))
	return canvas.sortingOrder or 0
end

function BaseUI:OnAsyncLoadAndShowComplete(func)
	self._onAsyncLoadAndShowComplete = func
end

function BaseUI:Create()
	local abPath         = ResUtil:GetUIPath(self.prefabName)

	local loadedCallBack = function(objs)
		if not self:GoCanShow() then
			--TODO 处理资源的Unload
			return
		end
		local go = GameObject.Instantiate(objs)
		if not go then
			logError("create [" .. self.uiname .. "] GameObject failed")
			return
		end

		self.view = GLuaComponent.Add(go, View)
		if self.view then
			self.view:SetAssetBundleName(self.prefabName)
			self.view:SetAssetBundlePath(abPath)
		end

		self.go        = go
		self.transform = go.transform

		-- 设置父节点
		self:SetParent()

		-- 初始化控件
		self:OnLoaded()

		if self:GoCanShow() then
			self:LoadShow()
		else
			self:SetShowState(false)
		end
	end

	self:CreateChild()
	if self:IsLoadAsync() then
		ResManager:LoadPrefabAsync(abPath, loadedCallBack)
	else
		local uiObj = ResManager:LoadPrefab(abPath)
		loadedCallBack(uiObj)
	end
	self.prefabIsLoad = true
end

function BaseUI:CreateChild()
	if not self.childList then
		return
	end

	for i, info in ipairs(self.childList) do
		local cls = info.childClass
		if not cls then
			logError(" 对象的类型错误, 无法创建子界面 ---uiName---- " .. info.name .. " classType " .. tostring(cls))
			return
		end

		local uiView = cls.New()
		if not uiView then
			logError(" 创建子对象失败 -- uiName --- " .. info.name)
			return
		end

		uiView.uiname             = uiView.CLASSNAME
		uiView.parentNodeName     = info.parentNodeName

		uiView.parentView         = self

		self.subUIList[info.name] = uiView
	end
end

---@return boolean @是否收到父面板影响而自动关闭
function BaseUI:AutoHideByParentChild()
	return true
end

-- 显示子ui界面
function BaseUI:ShowChild(childName, unshowOther, ...)
	local args   = { ... }
	local uiView = self.subUIList[childName]
	if not uiView then return end

	if uiView:IsShow() then
		uiView:OnShow(args)
		uiView:OnFullShow()
		return
	end

	uiView:Show(args)

	if unshowOther == nil then
		unshowOther = true
	end

	if unshowOther then
		for name, child in pairs(self.subUIList) do
			if name ~= childName and child:AutoHideByParentChild() then
				child:Hide()
			end
		end
	end
end

-- 隐藏子ui界面
function BaseUI:HideChild(uiName)
	local uiView = self.subUIList[uiName]
	if uiView and uiView:IsShow() then
		uiView:Hide()
	end
end

function BaseUI:GetChild(uiName)
	return self.subUIList[uiName]
end

function BaseUI:ShowRedPoint(index, RedPointParentTSF, ...)
	if not index then
		return
	end

	RedPointManager:ShowRedPoint(index, RedPointParentTSF, ...)

	if not self.redPointList then
		self.redPointList = {}
	end

	local args = { ... }
	if not self.redPointList[index] then
		self.redPointList[index] = {}
		if args and args[1] and args[1].render then
			table.insert(self.redPointList[index], args[1].render:GetIndex())
		end
	else
		if args and args[1] and args[1].render then
			table.insert(self.redPointList[index], args[1].render:GetIndex())
		end
	end

end

function BaseUI:HideRedPoint()
	if self.redPointList then
		for type, data in pairs(self.redPointList) do
			if not next(data) then
				RedPointManager:CancelShowRedPoint(type)
			else
				for _, index in ipairs(data) do
					RedPointManager:CancelShowRedPoint(type, index)
				end
			end
		end
	end
	self.redPointList = nil
end

---@param ui BaseUI @要显示背后蒙板的UI
---@param relToTransform UnityEngine.Transform @依托的transform
---@param onCloseCallBack fun @点击后的回调，前提是isAllowClick为true
---@param alpha number @背后黑色蒙板的alpha，默认值为0.8
---@param isAllowClick boolean @蒙板是否可点击，默认为值true，点击后会触发onCloseCallBack
function BaseUI:ShowMask(ui, relToTransform, onCloseCallBack, alpha, isAllowClick)
	local mask = self:GetMask(relToTransform)
	if mask then
		mask.args   = { ui, relToTransform, onCloseCallBack, alpha, isAllowClick }
		mask.fromUI = ui
		mask:UpdateView(onCloseCallBack, alpha, isAllowClick)
		return
	end

	if not self.ownMaskList then
		self.ownMaskList = {}
	end
	local mask = UIManager:OpenMultipleUI(UIPanelName.CommonPanelMask, ui, relToTransform, onCloseCallBack, alpha, isAllowClick)
	table.insert(self.ownMaskList, { mask = mask, relTo = relToTransform })
end

function BaseUI:HideMask(relToTransform)
	if not self.ownMaskList then return end
	for i = #self.ownMaskList, 1, -1 do
		if self.ownMaskList[i].relTo == relToTransform then
			self.ownMaskList[i].mask:Hide()
			table.remove(self.ownMaskList, i)
			return
		end
	end
end

function BaseUI:HasMask(relToTransform)
	if not self.ownMaskList then return end
	for i, v in pairs(self.ownMaskList) do
		if v.relTo == relToTransform then
			return true
		end
	end
	return false
end

function BaseUI:GetMask(relToTransform)
	if not self.ownMaskList then return end
	for i, v in pairs(self.ownMaskList) do
		if v.relTo == relToTransform then
			return v.mask
		end
	end
end

---@param targetRawImage UGUIObject @HybridUI生成的那个节点
---@param char Character @要显示的Model的Character
---@param charType CharType @要显示的Model的Character的类型 在global.lua的_G.CharType中定义
---@param modelID number @模型的ID 对应不用的模型表ID 要根据不同系统传入
---@param enabledRotate boolean @是否允许控制旋转，默认为true
---@param clearOld boolean @是否清除上一次的,在面板中同时只有一个Model需要Draw的时候使用true，如果有多个需要使用false，然后自行维护 默认值true
---@param callFunc function @完全加载完成的回调
---@param useOwnerLight boolean @使用自身光源
function BaseUI:DrawModel(targetRawImage, char, charType, modelID, enabledRotate, clearOld, onDrawComplete, useOwnerLight, drawCFGName)
	if useOwnerLight == nil then useOwnerLight = true end
	if enabledRotate == nil then
		enabledRotate = true
	end
	local keyName = targetRawImage:GetDrawModelKey()
	if clearOld == nil then clearOld = true end
	if clearOld then
		self:ClearDrawModel(keyName)
	end
	return DrawModelManager:CreateDraw(keyName, useOwnerLight, function(dms)
		if not self:IsShow() then
			self:ClearAllDrawModel()
			return
		end

		if not targetRawImage then return end
		if not self.drawModelSceneList then
			self.drawModelSceneList = {}
		end
		self.drawModelSceneList[keyName] = dms
		--添加转动组件
		local imageFreeRotate
		if enabledRotate then
			imageFreeRotate = targetRawImage:GetComponent(ImageFreeRotate)
			if not imageFreeRotate then
				imageFreeRotate = targetRawImage:AddComponent(ImageFreeRotate)
			end
			if imageFreeRotate and char and char:GetAvatar() and char:GetAvatar():GetGameObject() and dms then
				imageFreeRotate.targetGo = char:GetAvatar():GetGameObject()
				imageFreeRotate.camera   = dms.camera
			end
		end
		DrawModelManager:LoadDrawCFG(drawCFGName or self.prefabName, charType, modelID, function(panelCFG, cfg)
			if not self:IsShow() then
				self:ClearAllDrawModel()
				return
			end
			local rawImage = targetRawImage:GetComponent(UnityEngine.UI.RawImage)
			if tolua.isnull(rawImage) then
				self:ClearAllDrawModel()
				return
			end
			rawImage.raycastTarget = enabledRotate
			dms:Draw(rawImage, char, panelCFG, cfg)

			if onDrawComplete then
				onDrawComplete(imageFreeRotate)
			end
		end)
	end)
end

function BaseUI:GetDrawModelScene(key)
	if not key then return end
	if not self.drawModelSceneList then return end
	return self.drawModelSceneList[key]
end

function BaseUI:ClearDrawModel(key)
	if not key then return end
	if not self.drawModelSceneList then return end
	local dms = self.drawModelSceneList[key]
	if dms then
		dms:Clear()
		self.drawModelSceneList[key] = nil
	end
end

function BaseUI:ClearAllDrawModel()
	if not self.drawModelSceneList then return end
	for key, dms in pairs(self.drawModelSceneList) do
		if dms then
			dms:Clear()
			self.drawModelSceneList[key] = nil
		end
	end
	self.drawModelSceneList = nil
end

-- 设置父窗口
function BaseUI:SetParent()
	if not self.parentNodeName then
		logError(" 没有父窗口 无法挂载 ----- my name is : " .. self.uiname .. " parentNodeName " .. self.parentNodeName)
		return
	end

	local layer = UIManager:GetLayer(self.parentNodeName)
	if layer then
		UIManager:AddToLayer(self)

		return
	end

	local node = self.parentView.transform:Find(self.parentNodeName)
	if not node then
		logError(" 获取挂点失败 -----  parentNodeName is " .. self.parentNodeName .. " 在界面中 " .. self.uiname)
		return
	end

	self.transform:SetParent(node, false)
	self.transform.localPosition = Vector3.zero
	self.transform.localRotation = Quaternion.identity
	self.transform.localScale    = Vector3.one
end


--是否可以显示
function BaseUI:IsCanShow(args)
	if self.funcId and t_funcOpen[self.funcId] then
		--判断功能id是否存在
		return FuncManager:GetFuncIsOpen(self.funcId)
	end
	return true
end

-- 初始化控件
function BaseUI:OnLoaded()
	-- logError(" 请在子类重写此函数 OnLoaded() ")
end

function BaseUI:Show(args)

	-- 已经显示
	if self:IsShow() then
		return
	end

	-- 设置显示
	self:SetGoCanShow(true)

	self.args = args

	-- 没有界面
	if not self.go then
		if not self.prefabIsLoad then
			self:Create()
		end
		return
	else
		self:LoadShow()
	end
end

function BaseUI:LoadShow()
	if not self.view then
		return
	end
	--关闭互斥的界面
	UIManager:CheckMutexGroup(self)

	self:SetShowState(true)

	self:OnShow(self.args)
	self:SendNotification(NotifyConsts.OnUIShow, { panelName = self.uiname })
	-- 注册消息
	self:RegisterNotification()

	--打开面板的模糊
	if not self:HasParentView() then
		UIManager:AddShowView(self)
	end

	if self:IsTween() then
		self:BeforeTween()
		self:DoShowTween()
	else
		self:DoShow()
	end

end

function BaseUI:DoShow()
	if not self:GoCanShow() then
		return
	end
	--打开面板的模糊
	if not self:HasParentView() then
		if self:IsScreenBlur() then
			SceneController:SetHUDEnabled(false)
			UIManager:HideLayerBeyond(self.parentNodeName, UILayerConsts.TOP, UILayerConsts.NOTICE, UILayerConsts.STORY)
		end
		if self:IsFullScreen() or self:IsScreenBlur() then
			self:ShowMask(self, self:GetTransform(), nil, 0, false)
		end
		UIManager:UpdateSceneCameraEnable()
	end
	-- 播放打开界面声音
	if not self:HasParentView() and self:IsPlaySound() then
		if self:GetOpenMusicID() then
			SoundManager:PlaySFXExclusive(self:GetOpenMusicID())
		else
			SoundManager:PlaySFXExclusive(2004)
		end
	end

	self:OnFullShow()
	self:SendNotification(NotifyConsts.OnUIFullShow, { panelName = self.uiname })
	if self._onAsyncLoadAndShowComplete then
		self._onAsyncLoadAndShowComplete()
		self._onAsyncLoadAndShowComplete = nil
	end
end

function BaseUI:GetSiblingIndex()
	if self.transform then
		return self.transform:GetSiblingIndex()
	end
	return 0
end

function BaseUI:SetSiblingIndex(index)
	if self.transform then
		self.transform:SetSiblingIndex(index)
	end
end

function BaseUI:SetAsLastSibling()
	if self.transform then
		self.transform:SetAsLastSibling()
	end
end

function BaseUI:SetAsFirstSibling()
	if self.transform then
		self.transform:SetAsFirstSibling()
	end
end

function BaseUI:OnShow(args)

end

function BaseUI:BeforeTween()

end

-- 界面已经打开了
function BaseUI:OnFullShow()

end

-- 执行打开缓动(此函数可被子类重新覆盖)
function BaseUI:DoShowTween()
	if not self.transform then return end
	self.transform:DOKill()
	self.transform.localScale = Vector3.New(0.2, 0.2, 0.2)
	self.transform:DOScale(Vector3.one, 0.3):SetEase(Ease.OutBack):OnComplete(
			function()
				self:DoShow()
			end
	)
end
-----------------------------------------------------------------------
function BaseUI:Hide()
	if self:GoCanShow() == false then
		return
	end

	if self:IsPlaySound() then
		if self:GetCloseMusicID() then
			SoundManager:PlaySFXExclusive(self:GetCloseMusicID())
		else
			SoundManager:PlaySFXExclusive(2005)
		end
	end
	self:SetGoCanShow(false)
	self:DoHide()
end

function BaseUI:DoHide()
	self:RemoveAllNotification()
	self:StopUpdate()


	--关闭所有使用ShowMask方法显示的mask
	if self.ownMaskList then
		for i, v in pairs(self.ownMaskList) do
			self:HideMask(v.relTo)
		end
		self.ownMaskList = nil
	end
	--清空下所有的DrawModelScene
	self:ClearAllDrawModel()
	--清除红点
	self:HideRedPoint()
	self:StopAnimtion()
	self:OnHide()
	self.args                        = nil
	self._onAsyncLoadAndShowComplete = nil
	-- 关闭缓动
	if self.transform then
		self.transform:DOKill()
	end

	for subUiName, subView in pairs(self.subUIList) do
		subView:Hide()
	end
	self.prefabIsLoad = false
	if not self.parentView then
		UIManager:OnUIHide(self)
	else
		self:SetShowState(false)
	end
	--关闭面板的模糊
	if self:IsScreenBlur() then
		SceneController:SetHUDEnabled(true)
		UIManager:ShowLayerBeyond()
	end
	if not self:HasParentView() then
		UIManager:UpdateSceneCameraEnable()
	end
	self:SendNotification(NotifyConsts.OnUIHide, { panelName = self.uiname })
end

function BaseUI:OnHide()

end

-- 销毁
function BaseUI:OnDestroy()

end

--这个Destroy是用于HybridUI自动生成的代码调用的。开发中写的面板逻辑类不用重写这个方法，如果处理面板销毁的时候的清理，请重写OnDestroy方法，并且要在最后调用父类
function BaseUI:Destroy()
	self:StopUpdate()

	for subUiName, subView in pairs(self.subUIList) do
		if subView.go and not tolua.isnull(subView.go) then
			subView:Destroy()
		end
	end

	self:OnDestroy() --调用逻辑面板类中手写的销毁内容

	if not self.parentView then
		UIManager:RemoveFromLayer(self)
	end
	destroy(self.go)
	self.go         = nil
	self.transform  = nil
	self.view       = nil
	self.parentView = nil
	self.rootAnim   = nil
end

function BaseUI:HasParentView()
	return self.parentView
end

-- 获取同级界面
function BaseUI:GetBrotherView(name)
	if not self.parentView then
		return
	end

	return self.parentView:GetChild(name)
end

--界面互斥组,相同组的只能同时有一个界面存在,大于0表示是互斥组
function BaseUI:GetMutexGroup()
	if self.funcId and t_funcOpen[self.funcId] then
		return t_funcOpen[self.funcId].uiMutexGroup
	end
	return 0
end

--获取主窗口
function BaseUI:GetMainView()
	local view = self
	while view:HasParentView() do
		view = view:HasParentView()
	end

	return view
end

--关闭顶层窗口
function BaseUI:HideMainView()
	local view = self:GetMainView()
	view:Hide()
end

-------------------------------------------------------
---设置显示状态
function BaseUI:SetShowState(val)
	self.isShow = val
	self:SetActive(val)
end

---显示
function BaseUI:IsShow()
	--将自身的显示标记以及层级的显示混合来说
	if UIManager:HasLayer(self.parentNodeName) then
		return self.isShow and UIManager:GetLayerVisible(self.parentNodeName)
	else
		return self.isShow
	end
end

function BaseUI:GetVisible()
	return self:IsShow()
end

function BaseUI:IsLoadAsync()
	return true
end

--- 设置gameObject是否可以显示
function BaseUI:SetGoCanShow(val)
	self.goCanShow = val
end

--- 设置特定音效
function BaseUI:GetOpenMusicID()
	return nil
end

--- 设置特定音效
function BaseUI:GetCloseMusicID()
	return nil
end

--- gameObject是否需要显示
function BaseUI:GoCanShow()
	return self.goCanShow
end

--从不销毁界面
function BaseUI:IsNeverDelete()
	return false
end

--是否立即销毁
function BaseUI:IsImmediatelyDelete()
	return true
end

--是否使用缓动打开,关闭
function BaseUI:IsTween()
	return false
end

--是否播放开启音效
function BaseUI:IsPlaySound()
	return false
end

function BaseUI:IsFullScreen()
	return false
end

function BaseUI:IsScreenBlur()
	return false
end

-------------------Update-------------------------------------
function BaseUI:RunUpdate(delay)
	delay = delay or 0

	TimerManager:RemoveTimer(self.updateKey)
	self.updateKey = TimerManager:AddTimer(function()
		self:Update()
	end, delay, 0)
end

function BaseUI:StopUpdate()
	TimerManager:RemoveTimer(self.updateKey)
	self.updateKey = nil
end

function BaseUI:IsUpdate()
	return self.updateKey ~= nil
end

function BaseUI:Update()

end

function BaseUI:GetAnimation()
	if not self.go then
		return
	end

	if not self.rootAnim then
		self.rootAnim = self.go:GetComponent(typeof(UnityEngine.Animation))
	end

	return self.rootAnim
end

function BaseUI:StopAnimtion()
	if self.rootAnim then
		self.rootAnim:Stop()
	end
end

--------------------notice消息注册------------------------------------
-- notice消息注册
function BaseUI:RegisterNotification()
	-- 子类实现
end

function BaseUI:AddNotification(name, obj, func)
	local result = self.facade:AddNotification(name, obj, func)
	if result then
		table.insert(self.notificationList, { name = name, obj = obj, func = func })
	end
end

function BaseUI:RemoveNotification(name, obj, func)
	local result = self.facade:RemoveNotification(name, obj, func)
	if result then
		for i = #self.notificationList, 1, -1 do
			local vo = self.notificationList[i]
			if vo.name == name and vo.obj == obj and vo.func == func then
				table.remove(self.notificationList, i)
				break
			end
		end
	end
end

function BaseUI:SendNotification(name, body)
	self.facade:SendNotification(name, body)
end

function BaseUI:RemoveAllNotification()
	for i = #self.notificationList, 1, -1 do
		local vo = self.notificationList[i]
		self:RemoveNotification(vo.name, vo.obj, vo.func)
	end
end
