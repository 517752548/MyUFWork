_G.CommonPanelMask = class(CommonPanelMaskHybridUI)

UIManager:RegisterUIClass(UIPanelName.CommonPanelMask, CommonPanelMask)

function CommonPanelMask:ctor()
	self.fromUI          = nil
	self.relToTransform  = nil
	self.onCloseCallBack = nil
	self.alpha           = nil
    self.isAllowClick    = true
    self.uiCamera = UIManager:GetUIRoot():GetStageCamera()
end

function CommonPanelMask:OnLoaded()
	CommonPanelMask.superclass.OnLoaded(self)
	UIUtil:FixFullScreenUITransform(self.bg)
	UIUtil:FixFullScreenUITransform(self.bgImage)
	self.bg:IsPlaySfx(false)
	self.bgImage:IsPlaySfx(false)
end

function CommonPanelMask:SetAllowClick(value)
	self.isAllowClick = value
end

function CommonPanelMask:OnShow(args)
	self.fromUI         = args[1]
	self.relToTransform = args[2]

	if self.relToTransform then
		self.transform:SetParent(self.relToTransform.parent)

		local targetCav = self.relToTransform:GetComponent(typeof(UnityEngine.Canvas))
		if targetCav then
			local idx = getParentOrder(self.relToTransform)
			setOrder(self.transform, idx - 1)
		else
			local canvas = self.go:GetComponent(typeof(UnityEngine.Canvas))
			if canvas then
				canvas.overrideSorting = false
			end
		end

        self.transform:SetSiblingIndex(self.relToTransform:GetSiblingIndex())
        
        local layer = UIManager:CalcCurrLayer(self.relToTransform)        
        if layer then
            self:SetWorldPos(layer.transform.position)
        end
    end

	self:SetSizeDelta(UIManager:GetCanvasFullSize().x, UIManager:GetCanvasFullSize().y)
    self:UpdateView(args[3], args[4], args[5])
end

function CommonPanelMask:UpdateView(onCloseCallBack, alpha, isAllowClick)
	if not self:IsShow() then return end
	if not self.bg then return end
	if not self.bgImage then return end
	self.onCloseCallBack = onCloseCallBack
	self.alpha           = alpha or 0.8
	if isAllowClick == nil then
		isAllowClick = true
	end
	self.isAllowClick = isAllowClick
	--if self:IsShow() then
	if self.alpha > 0 then
		self.bgImage:OnClick(function()
			self:OnBgClick()
		end)
		self.bg:SetVisible(false)
		self.bgImage:SetVisible(true)
		self.bgImage:SetAlpha(self.alpha)
	else
		self.bg:OnClick(function()
			self:OnBgClick()
		end)
		self.bg:SetVisible(true)
		self.bgImage:SetVisible(false)
	end
	--end
end

function CommonPanelMask:OnBgClick()
	if not self:IsShow() then return end
	if not tolua.isnull(self.relToTransform) then
		if not self.isAllowClick then
			local name       = string.sub(self.relToTransform.name, 1, -8)
			local parentView = UIManager:GetUI(name)
			if parentView and parentView.GetMaskArgs then
				local maskArgs = parentView:GetMaskArgs()
				if maskArgs and maskArgs[5] then
					self.onCloseCallBack = maskArgs[3]
				else
					return
				end
			else
				return
			end
		end
		if self.fromUI then
			self.fromUI:HideMask(self.relToTransform)
		end
	end
	if self.onCloseCallBack then
		self.onCloseCallBack()
		self.onCloseCallBack = nil
		self.relToTransform  = nil
	end
end