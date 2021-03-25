--Created by HybridUI V3.0
_G.OnLinePanelHybridUI = class(BaseUI)

UIPanelName.OnLinePanel = "OnLinePanel"

function OnLinePanelHybridUI:ctor()
	self.prefabName = 'OnLinePanel'
	self.parentNodeName = _G.UILayerConsts.CENTER
end

function OnLinePanelHybridUI:OnLoaded()
	OnLinePanelHybridUI.superclass.OnLoaded(self)
	self.bg = UGUIObject.New(self.transform:Find('bg'))
	self.ScrollView = ScrollList.New(self.transform:Find('ScrollView'))
	self.back = Button.New(self.transform:Find('back'))
end

function OnLinePanelHybridUI:IsLoadAsync()
	return true
end

function OnLinePanelHybridUI:IsNeverDelete()
	return false
end

function OnLinePanelHybridUI:IsImmediatelyDelete()
	return true
end

function OnLinePanelHybridUI:IsTween()
	return false
end

function OnLinePanelHybridUI:IsFullScreen()
	return false
end

function OnLinePanelHybridUI:IsScreenBlur()
	return false
end

function OnLinePanelHybridUI:IsPlaySound()
	return true
end

function OnLinePanelHybridUI:Destroy()
	OnLinePanelHybridUI.superclass.Destroy(self)
	self.back:Destroy()
	self.ScrollView:Destroy()
	self.bg:Destroy()
	self.back = nil
	self.ScrollView = nil
	self.bg = nil
end