_G.LoadingPanel = class(LoadingPanelHybridUI)

UIManager:RegisterUIClass(UIPanelName.LoadingPanel, LoadingPanel)

function LoadingPanel:ctor()
end

function LoadingPanel:OnLoaded()
	LoadingPanel.superclass.OnLoaded(self)

end

function LoadingPanel:OnShow(arg)
	self:SetProgress(0)
end

function LoadingPanel:SetProgress(value)
	if not self:IsShow() then return end
	if not self.progressBar then return end
	self.progressBar:SetProgress(value)
end