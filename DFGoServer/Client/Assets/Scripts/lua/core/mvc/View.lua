---@class View
_G.View = class(BaseObject)

function View:ctor()
	self.className                    = "View"
	self.facade                       = GameApp.facade
	self.notificationList             = {}
	self.go                           = nil
	self.transform                    = nil
	self.assetBundleName              = "" --prefabName
	self.assetBundlePath              = "" --XXX/XXX/{prefabName}.prefab
	self.cacheChildrenDict            = {}
	---@type table<Type, Array> @KEY是类型， VALUE是一个c#数组，因为会有多个
	self.cacheComponentsInChildrenMap = nil
	self.cachePos                     = nil
	self.cacheVisible                 = true
	self.isDestroyed                  = false
	self.imageABPathHistoryArray      = {}
	self.parentTransform              = nil
end

function View:SetGameObject(go)
	self.go        = go
	self.transform = go.transform
end

function View:GetGameObject()
	return self.go
end

function View:SetParent(parentTransform)
	self.parentTransform = parentTransform
	if not tolua.isnull(self:GetTransform()) then
		self:GetTransform().parent = parentTransform
	end
end

function View:SetPos(pos)
	self.transform.position = pos
end

function View:SetLocalPos(pos)
	self.transform.localPosition = pos or Vector3.zero
end

function View:GetPos()
	return self.transform.position
end

function View:SetScale(value, isTween, easeType)
	if isTween then
		easeType = easeType or DOTween.defaultEaseType
		self.transform:DOScale(Vector3.one * value, 0.3):SetEase(easeType)
	else
		self.transform.localScale = Vector3.one * value
	end
end

function View:SetActive(value)
	if self.go then
		self.go:SetActive(value)
	end
end
--依托于数据层那里的使用，请不要单独调用这个
function View:SetVisible(value)
	self.cacheVisible = value
end

function View:GetVisible()
	return self.cacheVisible
end

function View:SetAssetBundleName(value)
	self.assetBundleName = value
end

function View:SetAssetBundlePath(value)
	self.assetBundlePath = value
end

function View:GetTransform()
	return self.transform
end

---@return Array<UnityEngine.Component> @components array
---@param t UnityEngine.XXX @获取的组件类型也就是UnityEngine namespace和类名
---@param includeInactive boolean @是否包含未激活的，这个和unity中的api一样。默认值为true
function View:GetComponentsInChildrenProxy(t, includeInactive)
	if includeInactive == nil then includeInactive = true end
	if not self.transform then return end
	if not self.cacheComponentsInChildrenMap then
		self.cacheComponentsInChildrenMap = {}
	end
	if self.cacheComponentsInChildrenMap[t] then
		return self.cacheComponentsInChildrenMap[t]
	end
	local components
	components = self.transform:GetComponentsInChildren(typeof(t), includeInactive)
	if components then
		self.cacheComponentsInChildrenMap[t] = components
	end
	return components
end

--调用的时机和MonoBehavior中的Awake一样
function View:Awake()
end

--调用的时机和MonoBehavior中的Start一样
function View:Start()
end

--调用的时机和MonoBehavior中的OnDisable一样
function View:OnDisable()
end

---@return UnityEngine.Transform @查找到的Transform，与Unity API中的一样
---@param name string @查找的名字，如果isRecursive为true，那么传入的就是一个节点名，会递归向下查找，如果isRecursive为false，那么传入的是一个路径（与Unity API一样）
---@param isRecursive boolean @是否递归查找 默认false
---@param ignoreCache boolean @是否忽略之前的缓存重新获取 默认false
function View:Find(childName, isRecursive, ignoreCache)
	if not childName or childName == "" then
		return self.transform
	end
	local result
	if not ignoreCache then
		result = self.cacheChildrenDict[childName]
		if result then
			return result
		end
	end
	if not self.transform then return end
	if isRecursive then
		result = findDeep(self.transform, childName)
	else
		result = self.transform:Find(childName)
	end
	if result then
		self.cacheChildrenDict[childName] = result
	end
	return result
end

function View:SetChildTransformVisible(childName, value, isRecursive, ignoreCache)
	local childTSF = self:Find(childName, isRecursive, ignoreCache)
	if childTSF then
		childTSF.gameObject:SetActive(value)
	end
end

--调用的时机和MonoBehavior中的OnDestroy一样
function View:OnDestroy()
	self.isDestroyed = true
	self:StopUpdate()
	self:StopLateUpdate()
	self:RemoveAllNotification()
	if self.assetBundlePath and self.assetBundlePath ~= "" then
		ResManager:UnloadAssetBundle(self.assetBundlePath)
		self.assetBundlePath = nil
	else
		log("[Attention! not Real Error] " .. self.go.name .. " View.assetBundlePath is null")
	end
	self.assetBundleName  = nil
	self.facade           = nil
	self.notificationList = nil
	self.go               = nil
	if self.transform then
		self.transform:DOKill()
	end
	self.transform                    = nil
	self.cacheChildrenDict            = nil
	self.cacheComponentsInChildrenMap = nil
	self.cachePos                     = nil
	self:UnloadImageHistoryABPath()
	self.imageABPathHistoryArray = nil
	self.parentTransform         = nil
end

function View:ReleaseToPool()
	if self.isDestroyed then return end
	self:StopUpdate()
	self:StopLateUpdate()
	self:RemoveAllNotification()
	PfxManager:StopAllFromGameObject(self.transform)
	self:SetVisible(false)
	ObjPoolManager:Release(self.assetBundlePath, self.go)
end

function View:UnloadImageHistoryABPath()
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

function View:PushABPathToImageHistory(abPath)
	if not self.imageABPathHistoryArray then return end
	table.insert(self.imageABPathHistoryArray, abPath)
end

function View:ClearSprite(spriteRenderer)
	if not spriteRenderer then return end
	spriteRenderer.sprite = nil
end

function View:SetSprite(spriteRenderer, sprite)
	if not spriteRenderer then return end
	spriteRenderer.sprite = sprite
end

function View:_LoadSpriteInternal(spriteRenderer, assetPath, onComplete, isAsync)
	if not assetPath or assetPath == "" then
		self:ClearSprite(spriteRenderer)
		return
	end
	self:PushABPathToImageHistory(assetPath)
	local isTexture = ResUtil:IsPuzzleTextureAssetPath(assetPath)
	local result, atlasPath, spriteName
	if isTexture then
		result, atlasPath, spriteName = ResUtil:SplitPuzzleTextureAssetPath(assetPath)
	end
	if isAsync then
		if isTexture then
			if result then
				ResManager:LoadSpriteInAtlasAsync(assetPath, atlasPath, spriteName, function(sprite)
					if tolua.isnull(self.go) then return end
					if tolua.isnull(sprite) or not sprite then return end
					if onComplete then
						onComplete(sprite)
					end
				end)
			end
		else
			ResManager:LoadSpriteAsync(assetPath, function(sprite)
				if tolua.isnull(self.go) then return end
				if tolua.isnull(sprite) or not sprite then return end
				if onComplete then
					onComplete(sprite)
				end
			end)
		end
	else
		if isTexture then
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

function View:LoadSprite(spriteRenderer, assetPath, onComplete, isAsync)
	if isAsync == nil then isAsync = false end
	self:_LoadSpriteInternal(spriteRenderer, assetPath, function(sprite)
		self:SetSprite(spriteRenderer, sprite)
		if onComplete then
			onComplete()
		end
	end, isAsync, onComplete)
end

function View:AddNotification(name, obj, func)
	local result = self.facade:AddNotification(name, obj, func)
	if result then
		table.insert(self.notificationList, { name = name, obj = obj, func = func })
	end
end

function View:RemoveNotification(name, obj, func)
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

function View:SendNotification(name, body)
	self.facade:SendNotification(name, body)
end

function View:RemoveAllNotification()
	for i = #self.notificationList, 1, -1 do
		local vo = self.notificationList[i]
		self:RemoveNotification(vo.name, vo.obj, vo.func)
	end
end
