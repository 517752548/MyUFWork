---@class PfxManager @特效播放管理类，要播放一个特效的话，通过这里的方法播放
_G.PfxManager      = {}
PfxManager.allList = {}

function PfxManager:Init()
	TimerManager:AddTimer(function()
		self:Update()
	end, 0, 0)
end

function PfxManager:Update()
	for i, v in pairs(self.allList) do
		if v then
			v:Update()
		end
	end
end

---@param pfxData PfxData
---@return boolean
function PfxManager:HasPfx(pfxData)
	for i, v in pairs(self.allList) do
		if v and v == pfxData then
			return true
		end
	end
end
function PfxManager:AddPfx(pfxData)
	if not self:HasPfx(pfxData) then
		table.insert(self.allList, pfxData)
	end
end

function PfxManager:DeletePfx(pfxData)
	for i, v in pairs(self.allList) do
		if v and v == pfxData then
			--在这里 删除一个特效，为了保证遍历顺序问题，只是把它的引用清除了，等切换场景调用ClearAllPfx的时候会统一清除
			self.allList[i] = nil
			return
		end
	end
end
--除UI特效外 都自动释放
function PfxManager:ClearAllPfx()
	for i, v in pairs(self.allList) do
		if v and not v.isOnUI then
			self:StopPfx(v, false, true)
			self.allList[i] = nil
		end
	end
end

function PfxManager:StopAllFromGameObject(transform)
	if not transform then return end
	for i, v in pairs(self.allList) do
		if v.syncTransform == transform
				or v.moveToTransform == transform
		then
			self:StopPfx(v, v.releaseToPool, true)
		end
	end
end

function PfxManager:StopFromScene(name, releaseToPool)
	for i, v in pairs(self.allList) do
		if v and v.pfxName == name and v.isOnScene then
			self:StopPfx(v, releaseToPool, true)
			break
		end
	end
end

function PfxManager:StopFromGameObject(name, transform, releaseToPool)
	if not transform then return end
	for i, v in pairs(self.allList) do
		if v and v.pfxName == name and v.isInGameObject and v.syncTransform and v.syncTransform == transform then
			self:StopPfx(v, releaseToPool, true)
			break
		end
	end
end

--内部调用
function PfxManager:StopPfx(pd, releaseToPool, autoDestroy)
	if pd then
		pd:Stop(releaseToPool, autoDestroy)
	end
end

---@param configId int @ResPfxConfig中的一个配置ID
---@param position Vector3 @场景中播放的位置Vector3
---@param rotation Quaternion @场景中播放的位置Quaternion
function PfxManager:PlayOnScenePositionByConfig(configId, position, rotation)
	local cfg = ResPfxConfig[configId]
	if not cfg then return end
	return PfxManager:PlayOnScenePosition(
			cfg.pfxName,
			cfg.pfxName,
			position,
			rotation,
			cfg.once,
			cfg.releaseToPool,
			cfg.offsetPosition,
			cfg.offsetRotation,
			cfg.scale
	)
end

--播放一个特效在场景中，位置在position
function PfxManager:PlayOnScenePosition(pfxName, name, position, rotation, once, releaseToPool, offsetPosition, offsetRotation, scale)
	once                        = once or false
	releaseToPool               = releaseToPool or false
	rotation                    = rotation or Quaternion.identity

	local onPfxViewLoadComplete = function(pfxData)
		local pfxTransform    = pfxData:GetView():GetTransform()
		pfxTransform.position = position
		pfxTransform.rotation = rotation
		if offsetPosition then
			pfxTransform.position = pfxTransform.position + offsetPosition
		end
		if offsetRotation then
			pfxTransform:Rotate(offsetRotation, Space.World)
		end
		if scale then
			pfxTransform.localScale = scale
		else
			pfxTransform.localScale = Vector3.one
		end
	end
	local pfxData               = PfxData.New()
	pfxData.pfxName             = name
	pfxData.isOnScene           = true
	pfxData.syncPosition        = false
	pfxData.syncRotation        = false
	pfxData.syncTransform       = nil
	pfxData.offsetPosition      = offsetPosition
	pfxData.offsetRotation      = offsetRotation
	pfxData.isPlayOnce          = once
	pfxData.releaseToPool       = releaseToPool
	pfxData.autoDestroy         = once -- 只是播放一次的必然销毁
	self:AddPfx(pfxData)
	pfxData:LoadAndPlay(ResUtil:GetEffectPath(pfxName), onPfxViewLoadComplete)
	return pfxData
end

---@param configId int @ResPfxConfig中的一个配置ID
---@param transform Transform @场景中播放的位置transfrom
function PfxManager:PlayOnSceneByConfig(configId, transform)
	local cfg = ResPfxConfig[configId]
	if not cfg then return end
	return PfxManager:PlayOnScene(
			cfg.pfxName,
			cfg.pfxName,
			transform,
			cfg.once,
			cfg.releaseToPool,
			cfg.syncPosition,
			cfg.syncRotation,
			cfg.offsetPosition,
			cfg.offsetRotation,
			cfg.scale
	)
end

--播放一个特效在场景中，位置和transform一致
function PfxManager:PlayOnScene(pfxName, name, transform, once, releaseToPool, syncPosition, syncRotation, offsetPosition, offsetRotation, scale, extParams)
	once                        = once or false
	syncPosition                = syncPosition or false
	syncRotation                = syncRotation or false
	releaseToPool               = releaseToPool or false

	local onPfxViewLoadComplete = function(pfxData)
		if tolua.isnull(transform) then
			pfxData:AutoStop()
			return
		end
		local pfxTransform    = pfxData:GetView():GetTransform()
		pfxTransform.position = transform.position
		pfxTransform.rotation = transform.rotation
		if offsetPosition then
			pfxTransform.position = pfxTransform.position + offsetPosition
		end
		if offsetRotation then
			pfxTransform:Rotate(offsetRotation, Space.World)
		end
		if scale then
			pfxTransform.localScale = scale
		else
			pfxTransform.localScale = Vector3.one
		end
	end
	local pfxData               = PfxData.New()
	pfxData.pfxName             = name
	pfxData.isOnScene           = true
	pfxData.syncPosition        = syncPosition
	pfxData.syncRotation        = syncRotation
	pfxData.syncTransform       = transform
	pfxData.offsetPosition      = offsetPosition
	pfxData.offsetRotation      = offsetRotation
	pfxData.isPlayOnce          = once
	pfxData.releaseToPool       = releaseToPool
	pfxData.autoDestroy         = once -- 只是播放一次的必然销毁
	self:AppendPfxDataExtParams(pfxData, extParams)
	self:AddPfx(pfxData)
	pfxData:LoadAndPlay(ResUtil:GetEffectPath(pfxName), onPfxViewLoadComplete)
	return pfxData
end

---@return PfxData @播放一个特效，将这个特效放到场景中，但是会每帧同步位置和朝向与目标同步，这样看起来是在某个节点上播放的
---@param pfxName string
---@param name string
---@param transform UnityEngine.Transform
---@param once boolean
---@param releaseToPool boolean
---@param offsetPosition Vector3 @位置偏移量
---@param offsetRotation Vector3 @旋转偏移量
---@param scale Vector3 @缩放值
---@param extParams table<string, any> @额外参数
function PfxManager:PlayInGameObject(pfxName, name, transform, once, releaseToPool, offsetPosition, offsetRotation, scale, extParams)
	once                        = once or false
	releaseToPool               = releaseToPool or false
	local onPfxViewLoadComplete = function(pfxData)
		if tolua.isnull(transform) then return end
		local pfxTransform    = pfxData:GetView():GetTransform()
		pfxTransform.position = transform.position
		pfxTransform.rotation = transform.rotation
		if offsetPosition then
			pfxTransform.position = pfxTransform.position + offsetPosition
		end
		if offsetRotation then
			pfxTransform:Rotate(offsetRotation, Space.World)
		end
		if scale then
			pfxTransform.localScale = scale
		else
			pfxTransform.localScale = Vector3.one
		end
	end
	local pfxData               = PfxData.New()
	pfxData.pfxName             = name
	pfxData.isInGameObject      = true
	pfxData.syncPosition        = true
	pfxData.syncRotation        = true
	pfxData.syncTransform       = transform
	pfxData.offsetPosition      = offsetPosition
	pfxData.offsetRotation      = offsetRotation
	pfxData.isPlayOnce          = once
	pfxData.releaseToPool       = releaseToPool
	pfxData.autoDestroy         = once -- 只是播放一次的必然销毁
	self:AppendPfxDataExtParams(pfxData, extParams)
	self:AddPfx(pfxData)
	pfxData:LoadAndPlay(ResUtil:GetEffectPath(pfxName), onPfxViewLoadComplete)
	return pfxData
end

---@return PfxData @播放一个特效，将这个特效放到对应的GameObject节点下
---@param pfxName string
---@param name string
---@param transform UnityEngine.Transform
---@param once boolean
---@param releaseToPool boolean
---@param scale Vector3 @缩放值
---@param extParams table<string, any> @额外参数
function PfxManager:PlayInsideGameObject(pfxName, name, transform, once, releaseToPool, scale, extParams)
	once                        = once or false
	releaseToPool               = releaseToPool or false
	local onPfxViewLoadComplete = function(pfxData)
		if tolua.isnull(transform) then return end
		local pfxTransform = pfxData:GetView():GetTransform()
		pfxTransform:SetParent(transform)
		pfxTransform.localPosition = Vector3.zero
		pfxTransform.localRotation = Quaternion.identity
		if scale then
			pfxTransform.localScale = scale
		else
			pfxTransform.localScale = Vector3.one
		end
	end
	local pfxData               = PfxData.New()
	pfxData.pfxName             = name
	pfxData.isInGameObject      = true
	pfxData.isPlayOnce          = once
	pfxData.releaseToPool       = releaseToPool
	pfxData.autoDestroy         = once -- 只是播放一次的必然销毁
	self:AppendPfxDataExtParams(pfxData, extParams)
	self:AddPfx(pfxData)
	pfxData:LoadAndPlay(ResUtil:GetEffectPath(pfxName), onPfxViewLoadComplete)
	return pfxData
end

--播放一个特效 移动到某一个gameobject的位置上
function PfxManager:PlayTweenToGameObject(pfxName, name, startPos, moveToTransform, time, moveType, releaseToPool, offsetPosition, offsetRotation, scale)
	moveType                    = moveType or AnimationEventsUtil.FLY_TO_TARGET_TYPE_LINEAR
	local onPfxViewLoadComplete = function(pfxData)
		if tolua.isnull(moveToTransform) then
			pfxData:AutoStop()
			return
		end
		local pfxTransform = pfxData:GetView():GetTransform()
		if tolua.isnull(pfxTransform) then return end
		pfxTransform.position = startPos
		if offsetPosition then
			pfxTransform.position = pfxTransform.position + offsetPosition
		end
		if offsetRotation then
			pfxTransform:Rotate(offsetRotation, Space.World)
		end
		if scale then
			pfxTransform.localScale = scale
		else
			pfxTransform.localScale = Vector3.one
		end
	end
	local pfxData               = PfxData.New()
	pfxData.pfxName             = name
	pfxData.isOnScene           = true
	pfxData.moveType            = moveType
	pfxData.moveTime            = time
	pfxData.moveToTransform     = moveToTransform
	pfxData.releaseToPool       = releaseToPool
	pfxData.autoDestroy         = true
	self:AddPfx(pfxData)
	pfxData:LoadAndPlay(ResUtil:GetEffectPath(pfxName), onPfxViewLoadComplete)
	return pfxData
end

--播放一个特效 移动到某一个position上
function PfxManager:PlayTweenToPos(pfxName, name, startPos, moveToPosition, time, moveType, releaseToPool, offsetPosition, offsetRotation, scale)
	moveType                    = moveType or AnimationEventsUtil.FLY_TO_TARGET_TYPE_LINEAR
	local onPfxViewLoadComplete = function(pfxData)
		local pfxTransform = pfxData:GetView():GetTransform()
		if tolua.isnull(pfxTransform) then return end
		pfxTransform.position = startPos
		if offsetPosition then
			pfxTransform.position = pfxTransform.position + offsetPosition
		end
		if offsetRotation then
			pfxTransform:Rotate(offsetRotation, Space.World)
		end
		if scale then
			pfxTransform.localScale = scale
		else
			pfxTransform.localScale = Vector3.one
		end
	end
	local pfxData               = PfxData.New()
	pfxData.pfxName             = name
	pfxData.isOnScene           = true
	pfxData.moveType            = moveType
	pfxData.moveTime            = time
	pfxData.moveToPosition      = moveToPosition
	pfxData.releaseToPool       = releaseToPool
	pfxData.autoDestroy         = true
	self:AddPfx(pfxData)
	pfxData:LoadAndPlay(ResUtil:GetEffectPath(pfxName), onPfxViewLoadComplete)
	return pfxData
end

function PfxManager:PlayOnUI(pfxName, name, transform, once, releaseToPool, autoDestroy, scale, sortingOrder)
	once                        = once or false
	releaseToPool               = releaseToPool or false
	autoDestroy                 = autoDestroy or false
	scale                       = scale or Vector3.one
	local onPfxViewLoadComplete = function(pfxData)
		if tolua.isnull(transform) then
			pfxData:AutoStop()
			return
		end
		local pfxTransform = pfxData:GetView():GetTransform()
		if tolua.isnull(pfxTransform) then return end
		pfxTransform:SetParent(transform)
		setRenderOrderWithParent(pfxTransform)
		pfxTransform.localPosition = Vector3.zero
		pfxTransform.localRotation = Quaternion.identity
		pfxTransform.localScale    = scale
		if sortingOrder then
			pfxData:SetSortingOrder(sortingOrder)
		end
	end
	local pfxData               = PfxData.New()
	pfxData.pfxName             = name
	pfxData.isOnUI              = true
	pfxData.isPlayOnce          = once
	pfxData.releaseToPool       = releaseToPool
	pfxData.autoDestroy         = autoDestroy
	self:AddPfx(pfxData)
	pfxName = "UI/" .. pfxName
	pfxData:LoadAndPlay(ResUtil:GetEffectPath(pfxName), onPfxViewLoadComplete)
	return pfxData
end

function PfxManager:AppendPfxDataExtParams(pfxData, extParams)
	if extParams then
		if extParams.isOnUIDrawModel ~= nil then
			pfxData.isOnUIDrawModel = extParams.isOnUIDrawModel
		end
	end
end