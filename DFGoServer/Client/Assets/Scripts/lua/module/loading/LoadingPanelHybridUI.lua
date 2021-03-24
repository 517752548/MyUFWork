--Created by HybridUI V3.0
_G.LoadingPanelHybridUI = class(BaseUI)

UIPanelName.LoadingPanel = "LoadingPanel"

function LoadingPanelHybridUI:ctor()
	self.prefabName = 'LoadingPanel'
	self.parentNodeName = _G.UILayerConsts.CENTER
end

function LoadingPanelHybridUI:OnLoaded()
	LoadingPanelHybridUI.superclass.OnLoaded(self)
	self.bg = UGUIObject.New(self.transform:Find('bg'))
	self.progressBar = ProgressBar.New(self.transform:Find('progressBar'))
end

function LoadingPanelHybridUI:IsLoadAsync()
	return true
end

function LoadingPanelHybridUI:IsNeverDelete()
	return false
end

function LoadingPanelHybridUI:IsImmediatelyDelete()
	return true
end

function LoadingPanelHybridUI:IsTween()
	return false
end

function LoadingPanelHybridUI:IsFullScreen()
	return false
end

function LoadingPanelHybridUI:IsScreenBlur()
	return false
end

function LoadingPanelHybridUI:IsPlaySound()
	return false
end

function LoadingPanelHybridUI:Destroy()
	LoadingPanelHybridUI.superclass.Destroy(self)
	self.progressBar:Destroy()
	self.bg:Destroy()
	self.progressBar = nil
	self.bg = nil
end