--Created by HybridUI V3.0
_G.Main2PanelHybridUI = class(BaseUI)

UIPanelName.Main2Panel = "Main2Panel"

function Main2PanelHybridUI:ctor()
	self.prefabName = 'Main2Panel'
	self.parentNodeName = _G.UILayerConsts.CENTER
end

function Main2PanelHybridUI:OnLoaded()
	Main2PanelHybridUI.superclass.OnLoaded(self)
	self.bg = UGUIObject.New(self.transform:Find('bg'))
	self.Content = UGUIObject.New(self.transform:Find('Content'))
	self.Content.Top = UGUIObject.New(self.transform:Find('Content/Top'))
	self.Content.Middle = UGUIObject.New(self.transform:Find('Content/Middle'))
	self.Content.Bottom = UGUIObject.New(self.transform:Find('Content/Bottom'))
end

function Main2PanelHybridUI:IsLoadAsync()
	return true
end

function Main2PanelHybridUI:IsNeverDelete()
	return false
end

function Main2PanelHybridUI:IsImmediatelyDelete()
	return true
end

function Main2PanelHybridUI:IsTween()
	return false
end

function Main2PanelHybridUI:IsFullScreen()
	return false
end

function Main2PanelHybridUI:IsScreenBlur()
	return false
end

function Main2PanelHybridUI:IsPlaySound()
	return true
end

function Main2PanelHybridUI:Destroy()
	Main2PanelHybridUI.superclass.Destroy(self)
	self.Content.Bottom:Destroy()
	self.Content.Middle:Destroy()
	self.Content.Top:Destroy()
	self.Content:Destroy()
	self.bg:Destroy()
	self.Content.Bottom = nil
	self.Content.Middle = nil
	self.Content.Top = nil
	self.Content = nil
	self.bg = nil
end