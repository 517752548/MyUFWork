---@class UGUIObject
---@field transform UnityEngine.Transform
---@field go UnityEngine.GameObject
---@field image UnityEngine.UI.Image
---@field button UnityEngine.UI.Button
---@field selectable UnityEngine.UI.Selectable
_G.UGUIObject = class(BaseObject)

function UGUIObject:ctor(transform)
	self.transform                = transform
	self.go                       = transform and transform.gameObject or nil
	self.drawModelKey             = nil
	self.image                    = nil
	self.imageABPathHistoryArray  = {}
	self.currAssetPath            = nil
	self.childrenImages           = nil
	self.ugui_button              = nil
	self.selectable               = nil --button的基类，控制是否可以交互(点击)
	self.data                     = nil
	self.index                    = nil
	self._scrollList              = nil --当组件在ScrollList内的时候，这个会是ScrollList或者ScrollLoopList
	self._isGray                  = nil
	self.onClickCallBack          = nil
	self.ugui_mask                = nil
	self.cacheComponentsMap       = nil
	self.canvasGroup              = nil
	self.cacheUGUIObjectChildren  = nil
	self.longButton               = nil
	self.touchDownCallback        = nil
	self.touchUpCallback          = nil
	self.touchExitCallback        = nil
	self.sfxID                    = nil -- 音效id
	self.redPointList             = nil
	self.anchoredPosCircleTween   = nil
	self.internalGameObjectPath   = nil
	self.internalGameObject       = nil
	self.isDestroyed              = false
	self._InitButtonComponent     = function()
		if not self.transform then return end
		if not self.ugui_button then
			self.ugui_button = self.transform:GetComponent(typeof(UnityEngine.UI.Button))
			if self.ugui_button then
				self.ugui_button.onClick:AddListener(function()
					self:PlaySFX()
					--GuideScriptManager:HideFrame() --TODO GUIDE 这里只要点击任何按钮就把引导框给删除
					if self.onClickCallBack then
						self.onClickCallBack()
					end
				end)
			end
		end
	end

	self._InitSelectableComponent = function()
		if not self.transform then return end
		if not self.selectable then
			self.selectable = self.transform:GetComponent(typeof(UnityEngine.UI.Selectable))
			if self.selectable then
				self.selectable.navigation = ins_ButtonNavigationNone
			end
		end
	end

	self._InitImageComponent      = function()
		if not self.transform then return end
		if not self.image then
			self.image = self.transform:GetComponent(typeof(UnityEngine.UI.Image))
			if self.image then
				self.image.useSpriteMesh = true
				local toggle
				local button
				local parent             = self.transform.parent
				if parent then
					toggle = parent:GetComponent(typeof(UnityEngine.UI.Toggle))
					button = parent:GetComponent(typeof(UnityEngine.UI.Button))
				end
				if self.ugui_button or self.selectable or toggle or button then
					self.image.raycastTarget = true
				else
					self.image.raycastTarget = false
				end
			end
		end
		if not self.childrenImages then
			self.childrenImages = self.transform:GetComponentsInChildren(typeof(UnityEngine.UI.Image))
			if self.childrenImages then
				local len = self.childrenImages.Length
				for i = 0, len - 1 do
					self.childrenImages[i].useSpriteMesh = true
				end
			end
		end
	end
	self:_InitButtonComponent()
	self:_InitSelectableComponent()
	self:_InitImageComponent()
end

function UGUIObject:OnLoaded()

end

function UGUIObject:SetGameObject(gameObject)
	self.go        = gameObject
	self.transform = self.go.transform
end

function UGUIObject:SetTransform(transform)
	self.transform = transform
	self.go        = transform and transform.gameObject or nil
end

function UGUIObject:SetDrawModelKey(value)
	self.drawModelKey = value
end

function UGUIObject:GetDrawModelKey()
	return self.drawModelKey or self:GetGameObjectName()
end

function UGUIObject:GetGameObjectName()
	return self.go and self.go.name or ""
end

function UGUIObject:SetGameObjectName(value)
	if not value or value == "" then return end
	if self.go then
		self.go.name = value
	end
end

function UGUIObject:GetGameObject()
	return self.go
end

function UGUIObject:GetTransform()
	return self.transform
end

-- 设置父节点
function UGUIObject:SetParent(node)
	if not node or not self.transform then
		return
	end
	self.transform:SetParent(node, false)
end

function UGUIObject:GetParent()
	if not self.transform then
		return
	end
	return self.transform.parent
end

function UGUIObject:SetLocalEulerAngles(x, y, z)
	self.transform.localRotation = Quaternion.Euler(x, y, z)
end

-- 设置位置
function UGUIObject:SetPos(pos)
	if self.transform then
		self.transform.localPosition = pos or Vector3.zero
	end
end

-- 获取本地位置
function UGUIObject:GetPos()
	if not self.transform then
		return
	end
	return self.transform.localPosition
end

function UGUIObject:SetWorldPos(pos)
	if self.transform then
		self.transform.position = pos or Vector3.zero
	end
end

---@return Vector3 @获取世界坐标
function UGUIObject:GetWorldPos()
	if not self.transform then
		return
	end
	return self.transform.position
end

---@return Vector3 @获取当中心点为正中心的时候的世界坐标
function UGUIObject:GetWorldPosByPivotCenter()
	local rect  = self:GetRect()
	local pivot = self:GetPivot()
	if not rect or not pivot then return end
	local vec3 = self:GetWorldPos():Clone()
	vec3.x     = vec3.x + (0.5 - pivot.x)
	vec3.y     = vec3.y + (0.5 - pivot.y)
	return vec3
end

function UGUIObject:GetPivot()
	if not self.transform then
		return
	end
	return self.transform.pivot
end

function UGUIObject:GetAnchoredPosition3D()
	if self.transform then
		return self.transform.anchoredPosition3D
	end
	return Vector3.zero
end

-- 设置位置(相对于锚点的位置)
function UGUIObject:SetAnchoredPosition3D(pos)
	if self.transform then
		self.transform.anchoredPosition3D = pos or Vector3.zero
	end
end

-- 获取位置(相对于锚点的位置)
function UGUIObject:GetAnchoredPosition()
	if self.transform then
		return self.transform.anchoredPosition
	end
	return Vector2.zero
end

-- 设置位置(相对于锚点的位置)
function UGUIObject:SetAnchoredPosition(pos)
	if self.transform then
		self.transform.anchoredPosition = pos or Vector2.zero
	end
end

---@return nil @设置位置，在圆周上
function UGUIObject:SetAnchoredPositionOnCircle(centerPos, radius, angle)
	if not self.transform then return end
	local x                         = centerPos.x + (radius * math.cos(angle * math.pi / 180))
	local y                         = centerPos.y + (radius * math.sin(angle * math.pi / 180))
	self.transform.anchoredPosition = Vector2.New(x, y)
end

---@return nil @设置位置，在圆周上,缓动执行
function UGUIObject:DOAnchoredPositionOnCircle(centerPos, radius, srcAngle, destAngle, duration, ease)
	if not self.transform then return end
	if self.anchoredPosCircleTween then
		DOTween.Kill(self.anchoredPosCircleTween)
		self.anchoredPosCircleTween = nil
	end
	self:SetAnchoredPositionOnCircle(centerPos, radius, srcAngle)
	if srcAngle == destAngle then return end
	ease                        = ease or Ease.Linear
	self.anchoredPosCircleTween = DOTween.To(
			DG.Tweening.Core.DOGetter_int(
					function()
						return srcAngle
					end
			),
			DG.Tweening.Core.DOSetter_int(
					function(x)
						if not self.transform then return end
						if tolua.isnull(self.transform) then return end
						self:SetAnchoredPositionOnCircle(centerPos, radius, x)
					end
			)
	, destAngle, duration
	)                                    :SetEase(ease)
end

function UGUIObject:SetAnchorMin(value)
	if self.transform then
		self.transform.anchorMin = value
	end
end

function UGUIObject:SetAnchorMax(value)
	if self.transform then
		self.transform.anchorMax = value
	end
end

-- 设置本地缩放
function UGUIObject:SetLocalScale(val)
	if self.transform then
		self.transform.localScale = val or Vector3.one
	end
end

-- 设置本地旋转
function UGUIObject:SetLocalRotation(val)
	if self.transform then
		self.transform.localRotation = val or Quaternion.identity
	end
end

-- 将位置从局部空间转换为世界空间
function UGUIObject:TransformPoint(localPos)
	if self.transform then
		return self.transform:TransformPoint(localPos or Vector3.zero)
	end
end

-- 将位置从世界空间转换为局部空间
function UGUIObject:InverseTransformPoint(worldPos)
	if self.transform then
		return self.transform:InverseTransformPoint(worldPos or Vector3.zero)
	end
end

--------------------------------------------------
-- 设置同级索引
function UGUIObject:SetSiblingIndex(index)
	if self.transform then
		self.transform:SetSiblingIndex(index)
	end
end

-- 获得同级索引
function UGUIObject:GetSiblingIndex()
	if self.transform then
		return self.transform:GetSiblingIndex()
	end
end

-- 移动到开头
function UGUIObject:SetAsFirstSibling()
	if self.transform then
		self.transform:SetAsFirstSibling()
	end
end

-- 移动到末尾
function UGUIObject:SetAsLastSibling()
	if self.transform then
		self.transform:SetAsLastSibling()
	end
end
--------------------------------------------------

function UGUIObject:GetRect()
	if self.transform then
		return self.transform.rect
	end
	return nil
end

function UGUIObject:GetSizeDelta()
	if self.transform then
		return self.transform.sizeDelta
	end
	return Vector2.zero
end

function UGUIObject:SetSizeDelta(width, height)
	if self.transform then
		self.transform.sizeDelta = Vector2.New(width, height)
	end
end

function UGUIObject:SetOffsetMin(a, b)
	if self.transform then
		self.transform.offsetMin = Vector2.New(a, b)
	end
end

function UGUIObject:SetOffsetMax(a, b)
	if self.transform then
		self.transform.offsetMax = Vector2.New(a, b)
	end
end

-- 强制立即重建布局
function UGUIObject:ForceRebuildLayoutImmediate()
	if not self.transform then
		return
	end
	LayoutRebuilder.ForceRebuildLayoutImmediate(self.transform)
end

function UGUIObject:GetComponent(t)
	if not self.transform then return end
	if tolua.isnull(self.transform) then return end
	if not self.cacheComponentsMap then
		self.cacheComponentsMap = {}
	end
	if self.cacheComponentsMap[t] then
		return self.cacheComponentsMap[t]
	end
	local component
	if type(t) == 'string' then
		component = self.transform:GetComponent(t)
	else
		component = self.transform:GetComponent(typeof(t))
	end
	if component then
		self.cacheComponentsMap[t] = component
	end
	return component
end

---@return UnityEngine.Component @添加一个Unity的Component到节点上，如果有直接返回，没有的话就先添加再返回，这个是有缓存机制
function UGUIObject:AddComponent(t)
	if tolua.isnull(self.transform) then return end
	if tolua.isnull(self.go) then return end
	local component
	component = self:GetComponent(t)
	if component then
		return component
	end
	if type(t) == 'string' then
		component = self.go:AddComponent(t)
	else
		component = self.go:AddComponent(typeof(t))
	end
	if component then
		if not self.cacheComponentsMap then
			self.cacheComponentsMap = {}
		end
		self.cacheComponentsMap[t] = component
	end
	return component
end

function UGUIObject:RemoveComponent(t)
	if tolua.isnull(self.transform) then return end
	if tolua.isnull(self.go) then return end
	local component = self:GetComponent(t)
	if component then
		destroy(component)
	end
	if self.cacheComponentsMap then
		self.cacheComponentsMap[t] = nil
	end
end

function UGUIObject:_InitLongButtonComponent()
	if not self.longButton then
		self.longButton = self:GetComponent("LongClickButton")
		if not self.longButton then
			self.longButton = self:GetComponent("LongClickToggle")
		end
		if self.longButton then
			self.longButton.OnLongClickDown:AddListener(
					function()
						self:PlaySFX()
						if self.touchDownCallback then
							self.touchDownCallback()
						end
					end
			)
			self.longButton.OnLongClickUp:AddListener(
					function(time)
						if self.touchUpCallback then
							self.touchUpCallback(time)
						end
					end
			)
			self.longButton.OnLongClickExit:AddListener(
					function()
						if self.touchExitCallback then
							self.touchExitCallback()
						end
					end
			)
		end
	end
end

-- function UGUIObject:_InitSelectableComponent()
-- 	if not self.selectable then
-- 		self.selectable = self:GetComponent(UnityEngine.UI.Selectable)
-- 	end
-- end

function UGUIObject:SetVisible(value)
	if not tolua.isnull(self.go) then
		self.go:SetActive(value)
	end
end

function UGUIObject:GetVisible()
	if tolua.isnull(self.go) then return false end
	return self.go.activeSelf
end

function UGUIObject:SetEnabled(value, isGray)
	isGray = isGray == nil and true or isGray
	if isGray then
		self:SetGray(not value)
	end
	self:SetInteractable(value)
end

function UGUIObject:GetEnabled()
	self:_InitSelectableComponent()
	if not self.selectable then return end
	return self.selectable.interactable
end

function UGUIObject:SetInteractable(value)
	self:_InitSelectableComponent()
	if not self.selectable then return end
	self.selectable.interactable = value
end

function UGUIObject:SetGray(value)
	if self._isGray == value then return end
	self._isGray = value
	self:_InitImageComponent()
	local setMat = function(mat)
		if self.image then
			self.image.material = mat
		end
		if self.childrenImages then
			local len = self.childrenImages.Length
			for i = 0, len - 1 do
				self.childrenImages[i].material = mat
			end
		end
	end
	if not self.image and not self.childrenImages then return end
	local abPath = ResUtil:GetUIDefaultGrayMaterial()
	if value then
		local mat = ResManager:LoadMaterial(abPath)
		setMat(mat)
	else
		setMat(nil)
	end
end

function UGUIObject:_InitCanvasGroupComponent()
	if not self.canvasGroup then
		self.canvasGroup = self:AddComponent(UnityEngine.CanvasGroup)
	end
end

function UGUIObject:GetCanvasGroup()
	self:_InitCanvasGroupComponent()
	return self.canvasGroup
end

function UGUIObject:SetSortingOrder(value)
	if not self:GetTransform() then return end
	if tolua.isnull(self.transform) then return end
	self:AddComponent(UnityEngine.Canvas)
	setOrder(self:GetTransform(), value)
end

function UGUIObject:GetSortingOrder()
	if not self:GetTransform() then return 0 end
	if tolua.isnull(self.transform) then return 0 end
	local canvas = self:AddComponent(UnityEngine.Canvas)
	return canvas.sortingOrder or 0
end

--@desc 获取子控件
--@path: 路径
--@return 子控件
function UGUIObject:FindChild(path, isRecursive)
	if isRecursive then
		return findDeep(self.transform, path)
	else
		return self.transform:Find(path)
	end
end

--@desc 获取子控件对象
--@path: 路径
--@classType 子控件对象类型
---@return UGUIObject @子控件对象
function UGUIObject:FindChildObject(path, classType, isRecursive)
	if not self.cacheUGUIObjectChildren then
		self.cacheUGUIObjectChildren = {}
	end
	if self.cacheUGUIObjectChildren[path] then
		return self.cacheUGUIObjectChildren[path]
	end

	if not self.transform or tolua.isnull(self.transform) then
		return
	end
	local tsf
	if isRecursive then
		tsf = findDeep(self.transform, path)
	else
		tsf = self.transform:Find(path)
	end
	if tsf then
		classType                          = classType or UGUIObject
		local uguiObj                      = classType.New(tsf)
		self.cacheUGUIObjectChildren[path] = uguiObj
		return uguiObj
	end
end

function UGUIObject:SetOverrideSprite(sprite)
	self:_InitImageComponent()
	if not self.image then return end
	if self.image.color:Equals(Color.clear) then
		self.image.color = Color.white
	end
	self.image.overrideSprite = sprite
end

function UGUIObject:SetSprite(sprite)
	self:_InitImageComponent()
	if not self.image then return end
	if self.image.color:Equals(Color.clear) then
		self.image.color = Color.white
	end
	self.image.sprite = sprite
end

function UGUIObject:GetSprite()
	self:_InitImageComponent()
	if not self.image then return end
	return self.image.sprite
end

function UGUIObject:ClearSprite()
	if not self.image then return end
	if tolua.isnull(self.image) then return end
	self.image.color   = Color.clear
	self.image.sprite  = nil
	self.currAssetPath = nil
end

function UGUIObject:UnloadImageHistoryABPath()
	if not self.imageABPathHistoryArray then return end
	local len = #self.imageABPathHistoryArray
	for i = len, 1, -1 do
		local abPath = self.imageABPathHistoryArray[i]
		if abPath then
			ResManager:UnloadAssetBundle(abPath)
		end
		table.remove(self.imageABPathHistoryArray, i)
	end
end

function UGUIObject:PushABPathToImageHistory(abPath)
	if not self.imageABPathHistoryArray then return end
	table.insert(self.imageABPathHistoryArray, abPath)
end

function UGUIObject:_LoadSpriteInternal(assetPath, onComplete, isAsync)
	if not assetPath or assetPath == "" then
		self:ClearSprite()
		self:UnloadImageHistoryABPath()
		return
	end
	self.currAssetPath = assetPath
	self:PushABPathToImageHistory(assetPath)
	local isUITexture = ResUtil:IsUITextureAssetPath(assetPath)
	local result, atlasPath, spriteName
	if isUITexture then
		result, atlasPath, spriteName = ResUtil:SplitUITextureAssetPath(assetPath)
	end
	if isAsync then
		if isUITexture then
			if result then
				ResManager:LoadSpriteInAtlasAsync(assetPath, atlasPath, spriteName, function(sprite)
					if self.currAssetPath == assetPath then
						if tolua.isnull(self.go) then return end
						if tolua.isnull(sprite) or not sprite then return end
						if tolua.isnull(self.image) or not self.image then return end
						if onComplete then
							onComplete(sprite)
						end
					end
				end)
			end
		else
			ResManager:LoadSpriteAsync(assetPath, function(sprite)
				if self.currAssetPath == assetPath then
					if tolua.isnull(self.go) then return end
					if tolua.isnull(sprite) or not sprite then return end
					if tolua.isnull(self.image) or not self.image then return end
					if onComplete then
						onComplete(sprite)
					end
				end
			end)
		end
	else
		if isUITexture then
			if result then
				local sprite = ResManager:LoadSpriteInAtlas(assetPath, atlasPath, spriteName)
				if onComplete then
					onComplete(sprite)
				end
			end
		else
			local sprite = ResManager:LoadSprite(assetPath)
			if onComplete then
				onComplete(sprite)
			end
		end
	end
end

function UGUIObject:LoadSprite(assetPath, width, height, onComplete, isAsync)
	if isAsync == nil then isAsync = true end
	self:_InitImageComponent()
	if not self.image then return end
	if self.currAssetPath == assetPath then
		if onComplete then
			onComplete()
		end
		return
	end
	self:_LoadSpriteInternal(assetPath, function(sprite)
		self:SetSprite(sprite)
		if width and height then
			self:SetSizeDelta(width, height)
		else
			self.image:SetNativeSize()
		end
		if onComplete then
			onComplete()
		end
	end, isAsync, onComplete)
end

function UGUIObject:LoadSpriteOriginalSize(assetPath, onComplete, isAsync)
	if isAsync == nil then isAsync = true end
	self:_InitImageComponent()
	if not self.image then return end
	if self.currAssetPath == assetPath then
		if onComplete then
			onComplete()
		end
		return
	end
	self:_LoadSpriteInternal(assetPath, function(sprite)
		self:SetSprite(sprite)
		if onComplete then
			onComplete()
		end
	end, isAsync, onComplete)
end

function UGUIObject:LoadSpriteWithBorder(assetPath, width, height, onComplete, isAsync, borderRect)
	if isAsync == nil then isAsync = true end
	self:_InitImageComponent()
	if not self.image then return end
	if not assetPath or assetPath == "" then
		self:ClearSprite()
		self:UnloadImageHistoryABPath()
		return
	end
	if self.currAssetPath == assetPath then return end
	self.currAssetPath = assetPath
	self:PushABPathToImageHistory(assetPath)
	if isAsync then
		ResManager:LoadSpriteAsyncWithBorder(assetPath, borderRect, function(sprite)
			if self.currAssetPath == assetPath then
				if tolua.isnull(self.go) then return end
				if tolua.isnull(sprite) or not sprite then return end
				if tolua.isnull(self.image) or not self.image then return end
				self.image.type = UnityEngine.UI.Image.Type.Sliced
				self:SetSprite(sprite)
				if width and height then
					self:SetSizeDelta(width, height)
				else
					self.image:SetNativeSize()
				end
				if onComplete then
					onComplete()
				end
			end
		end)
	else
		local sprite    = ResManager:LoadSpriteWithBorder(assetPath, borderRect)
		self.image.type = UnityEngine.UI.Image.Type.Sliced
		self:SetSprite(sprite)
		if width and height then
			self:SetSizeDelta(width, height)
		else
			self.image:SetNativeSize()
		end
		if onComplete then
			onComplete()
		end
	end
end

function UGUIObject:SetFillAmount(num)
	self:_InitImageComponent()
	if not self.image then return end
	self.image.fillAmount = num
end

function UGUIObject:GetFillAmount(isEndNow)
	self:_InitImageComponent()
	if not self.image then return end
	if isEndNow then
		self.image:DOComplete()
	end
	return self.image.fillAmount
end

function UGUIObject:DOFillAmount(num, time, func)
	self:_InitImageComponent()
	if not self.image then return end

	self:KillImgTween()
	self.image:DOFillAmount(num, time):OnComplete(func)
end

function UGUIObject:KillImgTween()
	if not self.image then return end
	self.image:DOKill()
end

--@RefType 设置图片的透明度(0-1)
function UGUIObject:SetAlpha(num)
	self:_InitImageComponent()
	if not self.image then return end
	local color      = self.image.color
	color.a          = num
	self.image.color = color
end

function UGUIObject:SetColor(color)
	self:_InitImageComponent()
	if not self.image then return end
	if type(color) == 'string' then
		local bin_color  = htmlStringToColor(color)
		self.image.color = bin_color
	else
		self.image.color = color
	end
end

function UGUIObject:GetColor()
	self:_InitImageComponent()
	if not self.image then return end
	return self.image.color
end

function UGUIObject:GetImage()
	self:_InitImageComponent()
	return self.image
end

function UGUIObject:SetImageEnabled(value)
	self:_InitImageComponent()
	if not self.image then return end
	self.image.enabled = value
end

function UGUIObject:SetFade(alpha)
	local canvasGroup = self:GetCanvasGroup()
	if not canvasGroup then return end
	alpha = Mathf.Clamp01(alpha)
	canvasGroup:DOKill()
	canvasGroup.alpha = alpha
end

function UGUIObject:DOFade(alpha, duration)
	local canvasGroup = self:GetCanvasGroup()
	if not canvasGroup then return end
	alpha = Mathf.Clamp01(alpha)
	canvasGroup:DOKill()
	return canvasGroup:DOFade(alpha, duration)
end

function UGUIObject:OnClick(func)
	self:_InitButtonComponent()
	self.onClickCallBack = func

end

function UGUIObject:SetTouchDelay(value)
	self:_InitLongButtonComponent()
	if self.longButton then
		self.longButton.Delay = value
	end
end

function UGUIObject:OnTouchDown(func)
	self:_InitLongButtonComponent()
	self.touchDownCallback = func
end

function UGUIObject:OnTouchUp(func)
	self:_InitLongButtonComponent()
	self.touchUpCallback = func
end

function UGUIObject:OnTouchExit(func)
	self:_InitLongButtonComponent()
	self.touchExitCallback = func
end

function UGUIObject:SetData(data)
	self.data = data
end

function UGUIObject:GetData()
	return self.data
end

function UGUIObject:SetIndex(index)
	self.index = index
end

function UGUIObject:GetIndex()
	return self.index
end

function UGUIObject:SetRendererList(list)
	self._scrollList = list
end

function UGUIObject:GetRendererList()
	return self._scrollList
end

function UGUIObject:SetParentRendererList(list)
	self._parentRenderList = list
end

function UGUIObject:GetParentRendererList()
	return self._parentRenderList
end

function UGUIObject:ShowMask(onCloseCallBack, alpha, isAllowClick)
	if self:HasMask() then
		return
	end
	local mask     = UIManager:OpenMultipleUI(UIPanelName.CommonPanelMask, self, self:GetTransform(), onCloseCallBack, alpha, isAllowClick)
	self.ugui_mask = mask
end

function UGUIObject:HideMask()
	if not self.ugui_mask then return end
	self.ugui_mask:Hide()
	self.ugui_mask = nil
end

function UGUIObject:HasMask()
	return self.ugui_mask
end

function UGUIObject:ShowRedPoint(index, RedPointParentTSF, ...)
	if not index then
		return
	end

	RedPointManager:ShowRedPoint(index, RedPointParentTSF, ...)
	if not self.redPointList then
		self.redPointList = {}
	end
	if not self.redPointList[index] then
		self.redPointList[index] = {}
	end
	local args = { ... }
	if args and args[1] and args[1].render then
		table.insert(self.redPointList[index], args[1].render:GetIndex())
	end
end

function UGUIObject:DestroyRedPoint()
	if self.redPointList then
		for type, list in pairs(self.redPointList) do
			for i, index in ipairs(list) do
				RedPointManager:CancelShowRedPoint(type, index)
			end
		end
	end
	self.redPointList = nil
end

function UGUIObject:ClearGameObject()
	self.go = nil
end

function UGUIObject:ClearTransform()
	self.transform = nil
end

function UGUIObject:OnClear()

end

-- 设置音效
function UGUIObject:SetSfxID(id)
	self.sfxID = id
end

-- 播放音效
function UGUIObject:PlaySFX()
	if self.sfxID then
		SoundManager:PlaySFX(self.sfxID)
	end
end

function UGUIObject:AddPfxClipComponent(pfxNode)
	if not self:GetRendererList() then
		return
	end
	if not pfxNode then
		return
	end
	self:AddPfxClipComponentByTSF(pfxNode, self:GetRendererList().scrollRectTransform)
end

function UGUIObject:AddPfxClipComponentByTSF(pfxNode, tsf)
	if not pfxNode then
		return
	end
	local ec = pfxNode:GetComponent(UGUIPfxClip)
	if not ec then
		ec = pfxNode:AddComponent(UGUIPfxClip)
	end
	if ec then
		if tsf then
			ec:Init(tsf, UIManager:GetScreenFullSizeDelta().x / UIManager:GetCanvasFullSize().x, UIManager:GetScreenFullSizeDelta().y / UIManager:GetCanvasFullSize().y)
		else
			ec:Init(nil, 1, 1)
		end
	end
end

function UGUIObject:RemovePfxClipComponent(pfxNode)
	if not pfxNode then
		return
	end
	pfxNode:RemoveComponent(UGUIPfxClip)
end
---------------拖拽相关开始-------------------------

---@return boolean @返回是否可以拖拽，当这个组件加入Dragger中并且这个方法返回true 才可以拖拽
function UGUIObject:GetDraggable()
	return true
end

---@return UnityEngine.Sprite @返回拖拽中显示的Sprite
function UGUIObject:GetDragingSprite()
	--override
end
---------------拖拽相关结束-------------------------

function UGUIObject:UnloadGameObject()
	if self.internalGameObjectPath then
		ObjPoolManager:Release(self.internalGameObjectPath, self.internalGameObject)
		self.internalGameObjectPath = nil
		self.internalGameObject     = nil
	end
end

function UGUIObject:LoadGameObject(name, onComplete, isAsync)
	self:UnloadGameObject()
	local abPath                = ResUtil:GetUIPath(name)
	self.internalGameObjectPath = abPath
	local poolGO                = ObjPoolManager:Get(abPath)
	local onLoadComplete        = function(gameObject)
		self.internalGameObject = gameObject
		gameObject.name         = name
		local tsf               = gameObject.transform
		tsf:SetParent(self.transform)
		tsf.localPosition = Vector3.zero
		tsf.localRotation = Quaternion.identity
		tsf.localScale    = Vector3.one
		if onComplete then
			onComplete(gameObject)
		end
	end
	if poolGO then
		onLoadComplete(poolGO)
	else
		if isAsync then
			ResManager:LoadPrefabAsync(abPath, function(gameObject)
				if not gameObject then
					logError("UGUIObject加载Prefab发生错误:" .. abPath)
					return
				end
				local asyncGO = newObject(gameObject)
				onLoadComplete(asyncGO)
			end)
		else
			local go    = ResManager:LoadPrefab(abPath)
			local newGO = newObject(go)
			onLoadComplete(newGO)
		end
	end
end
function UGUIObject:IsDestroyed()
	return self.isDestroyed
end

function UGUIObject:Destroy()
	self:KillImgTween()
	self:ClearSprite()
	if self.image and not tolua.isnull(self.image) then
		self.image.sprite = nil
	end
	self.image = nil
	self:UnloadImageHistoryABPath()
	self.imageABPathHistoryArray = nil
	self.currAssetPath           = nil
	self.childrenImages          = nil
	self.selectable              = nil
	if self.ugui_button then
		self.ugui_button.onClick:RemoveAllListeners()
	end
	self.ugui_button     = nil
	self.data            = nil
	self.index           = nil
	self._scrollList     = nil
	self._isGray         = false
	self.onClickCallBack = nil
	self:HideMask()
	self.cacheComponentsMap = nil
	self.canvasGroup        = nil
	self:DestroyRedPoint()
	if self.cacheUGUIObjectChildren then
		for i, v in pairs(self.cacheUGUIObjectChildren) do
			v:Destroy()
		end
		self.cacheUGUIObjectChildren = nil
	end
	if self.longButton then
		self.longButton.OnLongClickDown:RemoveAllListeners()
		self.longButton.OnLongClickUp:RemoveAllListeners()
		self.longButton.OnLongClickExit:RemoveAllListeners()
	end
	self.longButton        = nil
	self.touchDownCallback = nil
	self.touchUpCallback   = nil
	self.touchExitCallback = nil
	self.sfxID             = nil
	self.drawModelKey      = nil
	if self.anchoredPosCircleTween then
		DOTween.Kill(self.anchoredPosCircleTween)
		self.anchoredPosCircleTween = nil
	end
	self:UnloadGameObject()
	self.isDestroyed = true
	UGUIObject.superclass.Destroy(self)
end
