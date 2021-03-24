---@class PfxView:View
_G.PfxView        = class(View)

local VISIBLE_POS = Vector3.New(9999, 9999, 9999)
function PfxView:ctor()
	self.effectDepth = nil
end

function PfxView:UpdateShadowsQuality()
	self:EnableCastShadows(false)
	self:EnableReceiveShadows(false)
	local psList = self:GetComponentsInChildrenProxy(ParticleSystem, true)
	if psList then
		local psLen = psList.Length
		if psLen > 0 then
			for i = 0, psLen - 1 do
				local ps  = psList[i]
				local psr = ps:GetComponent(typeof(UnityEngine.ParticleSystemRenderer))
				if psr then
					psr.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off
					psr.receiveShadows    = false
				end
			end
		end
	end
end

function PfxView:EnableCastShadows(value)
	local components = self:GetComponentsInChildrenProxy(UnityEngine.Renderer, true)
	for i = 0, components.Length - 1 do
		local rc = components[i]
		if value then
			rc.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On
		else
			rc.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off
		end
	end
end

function PfxView:EnableReceiveShadows(value)
	local components = self:GetComponentsInChildrenProxy(UnityEngine.Renderer, true)
	for i = 0, components.Length - 1 do
		local rc          = components[i]
		rc.receiveShadows = value
	end
end

function PfxView:EnableTrailRenderer(value)
	local components = self:GetComponentsInChildrenProxy(UnityEngine.TrailRenderer, true)
	for i = 0, components.Length - 1 do
		local rc   = components[i]
		rc.enabled = value
	end
end

function PfxView:GetTotalTime()
	if not self.go then return 0 end
	local maxTime = 0
	local cplList = self:GetComponentsInChildrenProxy(CustomParticalLength, true)
	if cplList then
		local cplLen = cplList.Length
		if cplLen > 0 then
			for i = 0, cplLen - 1 do
				local cpl = cplList[i]
				maxTime  = math.max(maxTime, cpl.Length)
			end
			return maxTime
		end
	end
	local psList  = self:GetComponentsInChildrenProxy(ParticleSystem, true)
	if psList then
		local psLen = psList.Length
		if psLen > 0 then
			for i = 0, psLen - 1 do
				local ps = psList[i]
				maxTime  = math.max(maxTime, math.max(ps.main.startDelay.constant + ps.main.duration, ps.main.startDelay.constant + ps.main.startLifetime.constant))
			end
		end
	end
	return maxTime
end

function PfxView:SetScale(value)
	if tolua.isnull(self.transform) then return end
	self.transform.localScale = Vector3.one * value
end

function PfxView:SetScaleUseVector3(value)
	if tolua.isnull(self.transform) then return end
	self.transform.localScale = value
end

function PfxView:Play()
	if not self.go then return end
	self:SetVisible(false)
	self:SetVisible(true)
	local psList = self:GetComponentsInChildrenProxy(ParticleSystem, true)
	if psList then
		local psLen = psList.Length
		if psLen > 0 then
			for i = 0, psLen - 1 do
				psList[i]:Play()
			end
		end
	end
end

function PfxView:Stop()
	if not self.go then return end
	local psList = self:GetComponentsInChildrenProxy(ParticleSystem, true)
	if psList then
		local psLen = psList.Length
		if psLen > 0 then
			for i = 0, psLen - 1 do
				psList[i]:Stop()
			end
		end
	end
	self:SetVisible(false)
end

function PfxView:SetVisible(value)
	self:SetActive(value)
end

function PfxView:SetSortingOrder(value)
	--添加动画组件
	self.effectDepth = self.go:GetComponent(typeof(UGUIEffectDepth))
	if not self.effectDepth then
		self.effectDepth = self.go:AddComponent(typeof(UGUIEffectDepth))
	end
	self.effectDepth.SortingOrder = value
end
