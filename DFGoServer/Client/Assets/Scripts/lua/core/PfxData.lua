---@class PfxData
_G.PfxData = class()

function PfxData:ctor()
	self.pfxView              = nil
	self.pfxName              = ""
	self.isOnScene            = false
	self.isInGameObject       = false
	self.isOnUI               = false
	self.isOnUIDrawModel      = false
	self.syncPosition         = false
	self.syncRotation         = false
	self.syncTransform        = nil
	self.offsetPosition       = nil
	self.offsetRotation       = nil
	self.isPlayOnce           = false
	self.totalTime            = 0
	self.curTime              = 0
	self.moveType             = 0
	self.moveToTransform      = nil
	self.moveToPosition       = nil
	self.moveTime             = 0
	self.moveStartTime        = 0
	self.bezier               = nil
	self.startPos             = nil
	self.releaseToPool        = false
	self.autoDestroy          = false
	self.isStop               = false
	self.visible              = true
	self.onPlayComplete       = nil
	self.onLoadComplete       = nil
	self.visibleDelayTimerKey = nil
end

function PfxData:GetView()
	return self.pfxView
end

function PfxData:GetTransform()
	if self:GetView() then
		return self:GetView():GetTransform()
	end
end

function PfxData:OnLoadComplete(func)
	self.onLoadComplete = func
	return self
end

function PfxData:SetPos(pos)
	local transform = self:GetTransform()
	if not transform then return end
	if tolua.isnull(transform) then return end
	transform.position = pos
end

function PfxData:SetVisible(value, delay)
	TimerManager:RemoveTimer(self.visibleDelayTimerKey)
	if delay and delay > 0 then
		self.visibleDelayTimerKey = TimerManager:AddTimer(function()
			self.visible = value
			if self:GetView() then
				self:GetView():SetVisible(value)
			end
		end, delay, 1)
	else
		if self:GetView() then
			self:GetView():SetVisible(value)
		end
	end
end

function PfxData:SetScale(value)
	if self:GetView() then
		self:GetView():SetScale(value)
	end
end

function PfxData:SetScaleUseVector3(value)
	if self:GetView() then
		self:GetView():SetScaleUseVector3(value)
	end
end

function PfxData:SetSortingOrder(value)
	if self:GetView() then
		self:GetView():SetSortingOrder(value)
	end
end

function PfxData:OnPlayComplete(func)
	self.onPlayComplete = func
	return self
end

function PfxData:LoadAndPlay(loadPfxPath, onComplete)
	self.isStop       = false
	local initPfxView = function(pfxView)
		self.pfxView = pfxView
		if self.isOnUI then
			setLayerAndChildren(pfxView:GetTransform(), LayerMask.NameToLayer(LayerConsts.LAYER_NAME_UI))
		elseif self.isOnUIDrawModel then
			setLayerAndChildren(pfxView:GetTransform(), LayerMask.NameToLayer(LayerConsts.LAYER_NAME_UIDRAWMODEL))
		else
			setLayerAndChildren(pfxView:GetTransform(), LayerMask.NameToLayer(LayerConsts.LAYER_NAME_PFX))
		end
		pfxView:UpdateShadowsQuality()
		pfxView:SetAssetBundlePath(loadPfxPath)
		pfxView.go.name = self.pfxName
		if self.isStop then
			self:Stop(self.releaseToPool, self.autoDestroy)
			return
		end
		onComplete(self)
		TimerManager:AddTimer(function()
			if self.onLoadComplete then
				self.onLoadComplete()
				self.onLoadComplete = nil
			end
		end, 0.001, 1)
		self:Play()
	end

	local poolGO      = ObjPoolManager:Get(loadPfxPath)
	if poolGO then
		local luaObj  = poolGO:GetComponent("GLuaComponent")
		local pfxView = luaObj.table
		initPfxView(pfxView)
	else
		ResManager:LoadPrefabAsync(loadPfxPath, function(prefab)
			local go      = newObject(prefab)
			local pfxView = GLuaComponent.Add(go, PfxView)
			initPfxView(pfxView)
		end)
	end
end

function PfxData:Play()
	if not self:GetView() then return end
	self.totalTime = self:GetTotalTime() * 1.1
	self.curTime   = 0
	if self.moveTime > 0 then
		self.startPos      = self:GetView():GetTransform().position
		self.moveStartTime = Time.time
	end

	self:GetView():Play()
end

function PfxData:GetTotalTime()
	if self:GetView() then
		return self:GetView():GetTotalTime()
	end
	return 0
end

function PfxData:Update()
	if self.isStop then return end
	if not self:GetView() then return end
	local transform = self:GetView():GetTransform()
	if tolua.isnull(transform) then return end
	local deltaTime = Time.deltaTime
	if self.isPlayOnce then
		if self.curTime > self.totalTime then
			self:Stop(self.releaseToPool, self.autoDestroy)
			return
		end
	end
	self.curTime = self.curTime + deltaTime
	if self.syncPosition then
		if not tolua.isnull(self.syncTransform) and self.syncTransform.position and self.syncTransform.position ~= nil then
			transform.position = self.syncTransform.position
			if self.offsetPosition then
				transform.position = transform.position + self.offsetPosition
			end
		else
			self:Stop(self.releaseToPool, true)
			return
		end
	end
	if self.syncRotation then
		if not tolua.isnull(self.syncTransform) and self.syncTransform and self.syncTransform.rotation ~= nil then
			transform.rotation = self.syncTransform.rotation
			if self.offsetRotation then
				transform:Rotate(self.offsetRotation, Space.World)
			end
		else
			self:Stop(self.releaseToPool, true)
			return
		end
	end
	if ((self.moveToTransform and not tolua.isnull(self.moveToTransform)) or self.moveToPosition) and self.moveTime > 0 then
		local targetPos = self.moveToTransform and self.moveToTransform.position or self.moveToPosition
		if self.moveType == AnimationEventsUtil.FLY_TO_TARGET_TYPE_LINEAR then
			--直线运动
			local t = Mathf.Clamp01((Time.time - self.moveStartTime) / self.moveTime)
			if t >= 1 and self.curTime > self.totalTime then
				self:Stop(self.releaseToPool, self.autoDestroy)
				return
			end
			transform.position = Vector3.Lerp(self.startPos, targetPos, t)
		elseif self.moveType == AnimationEventsUtil.FLY_TO_TARGET_TYPE_ROCKET then
			--导弹抛物线
			self:_updateRocketBezier(transform, targetPos)
		end
	end
end

function PfxData:_updateRocketBezier(transform, targetPos)
	if not targetPos then return end
	if tolua.isnull(targetPos) then return end
	local t = Mathf.Clamp01((Time.time - self.moveStartTime) / self.moveTime)
	if t >= 1 and self.curTime > self.totalTime then
		self:Stop(self.releaseToPool, self.autoDestroy)
		return
	end
	if not self.bezier then
		self.bezier = Bezier.New(self.startPos, Vector3.New(self.startPos.x, self.startPos.y + 3, self.startPos.z), Vector3.New(targetPos.x, targetPos.y + 1, targetPos.z), targetPos)
	end
	--让抛物线跟踪最终目标点
	self.bezier:SetEndPos(targetPos)
	transform.position = self.bezier:GetPointAtTime(t)
end

function PfxData:Stop(releaseToPool, autoDestroy)
	self.isStop = true
	if self.onPlayComplete then
		self.onPlayComplete()
		self.onPlayComplete = nil
	end
	if self:GetView() then
		self:GetView():Stop()
	end
	TimerManager:RemoveTimer(self.visibleDelayTimerKey)
	self.visibleDelayTimerKey = nil
	if autoDestroy then
		PfxManager:DeletePfx(self)
		if releaseToPool then
			if self:GetView() then
				self:GetView():ReleaseToPool()
			end
		else
			if self:GetView() then
				destroy(self:GetView():GetGameObject())
			end
		end
		self:Destroy()
	end
end

function PfxData:AutoStop()
	self:Stop(self.releaseToPool, self.autoDestroy)
end

function PfxData:Destroy()
	self.pfxView         = nil
	self.pfxName         = nil
	self.isOnScene       = false
	self.isInGameObject  = false
	self.isOnUI          = false
	self.isOnUIDrawModel = false
	self.syncPosition    = false
	self.syncRotation    = false
	self.syncTransform   = nil
	self.offsetPosition  = nil
	self.offsetRotation  = nil
	self.isPlayOnce      = false
	self.totalTime       = 0
	self.curTime         = 0
	self.moveType        = 0
	self.moveToTransform = nil
	self.moveToPosition  = nil
	self.moveTime        = 0
	self.moveStartTime   = 0
	if self.bezier then
		self.bezier:Destroy()
	end
	self.bezier         = nil
	self.startPos       = nil
	self.releaseToPool  = false
	self.autoDestroy    = false
	self.visible        = false
	self.onPlayComplete = nil
	self.onLoadComplete = nil
	TimerManager:RemoveTimer(self.visibleDelayTimerKey)
	self.visibleDelayTimerKey = nil
end
