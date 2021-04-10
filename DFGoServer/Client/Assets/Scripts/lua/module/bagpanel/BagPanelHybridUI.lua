--Created by HybridUI V3.0
_G.BagPanelHybridUI = class(BaseUI)

UIPanelName.BagPanel = "BagPanel"

function BagPanelHybridUI:ctor()
	self.prefabName = 'BagPanel'
	self.parentNodeName = _G.UILayerConsts.CENTER
end

function BagPanelHybridUI:OnLoaded()
	BagPanelHybridUI.superclass.OnLoaded(self)
	self.Content = UGUIObject.New(self.transform:Find('Content'))
	self.Content.tittleBG = UGUIObject.New(self.transform:Find('Content/tittleBG'))
	self.Content.tittleBG.Text = Text.New(self.transform:Find('Content/tittleBG/Text'))
	self.Content.closeBtn = UGUIObject.New(self.transform:Find('Content/closeBtn'))
	self.Content.ScrollView = ScrollFlowList.New(self.transform:Find('Content/ScrollView'))
end

function BagPanelHybridUI:IsLoadAsync()
	return true
end

function BagPanelHybridUI:IsNeverDelete()
	return true
end

function BagPanelHybridUI:IsImmediatelyDelete()
	return true
end

function BagPanelHybridUI:IsTween()
	return true
end

function BagPanelHybridUI:IsFullScreen()
	return false
end

function BagPanelHybridUI:IsScreenBlur()
	return false
end

function BagPanelHybridUI:IsPlaySound()
	return true
end

function BagPanelHybridUI:Destroy()
	BagPanelHybridUI.superclass.Destroy(self)
	self.Content.ScrollView:Destroy()
	self.Content.closeBtn:Destroy()
	self.Content.tittleBG.Text:Destroy()
	self.Content.tittleBG:Destroy()
	self.Content:Destroy()
	self.Content.ScrollView = nil
	self.Content.closeBtn = nil
	self.Content.tittleBG.Text = nil
	self.Content.tittleBG = nil
	self.Content = nil
end