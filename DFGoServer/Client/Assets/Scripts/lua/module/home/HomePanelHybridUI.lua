--Created by HybridUI V3.0
_G.HomePanelHybridUI = class(BaseUI)

UIPanelName.HomePanel = "HomePanel"

function HomePanelHybridUI:ctor()
	self.prefabName = 'HomePanel'
	self.parentNodeName = _G.UILayerConsts.CENTER
end

function HomePanelHybridUI:OnLoaded()
	HomePanelHybridUI.superclass.OnLoaded(self)
	self.bg = UGUIObject.New(self.transform:Find('bg'))
	self.btnEnter = Button.New(self.transform:Find('btnEnter'))
end

function HomePanelHybridUI:IsLoadAsync()
	return true
end

function HomePanelHybridUI:IsNeverDelete()
	return false
end

function HomePanelHybridUI:IsImmediatelyDelete()
	return true
end

function HomePanelHybridUI:IsTween()
	return false
end

function HomePanelHybridUI:IsFullScreen()
	return false
end

function HomePanelHybridUI:IsScreenBlur()
	return false
end

function HomePanelHybridUI:IsPlaySound()
	return true
end

function HomePanelHybridUI:Destroy()
	HomePanelHybridUI.superclass.Destroy(self)
	self.btnEnter:Destroy()
	self.bg:Destroy()
	self.btnEnter = nil
	self.bg = nil
end