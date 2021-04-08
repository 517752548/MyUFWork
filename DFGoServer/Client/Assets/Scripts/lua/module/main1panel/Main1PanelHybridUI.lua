--Created by HybridUI V3.0
_G.Main1PanelHybridUI = class(BaseUI)

UIPanelName.Main1Panel = "Main1Panel"

function Main1PanelHybridUI:ctor()
	self.prefabName = 'Main1Panel'
	self.parentNodeName = _G.UILayerConsts.CENTER
end

function Main1PanelHybridUI:OnLoaded()
	Main1PanelHybridUI.superclass.OnLoaded(self)
	self.Content = UGUIObject.New(self.transform:Find('Content'))
	self.Content.Top = UGUIObject.New(self.transform:Find('Content/Top'))
	self.Content.Middle = UGUIObject.New(self.transform:Find('Content/Middle'))
	self.Content.Middle.Email = Button.New(self.transform:Find('Content/Middle/Email'))
	self.Content.Middle.Sign = Button.New(self.transform:Find('Content/Middle/Sign'))
	self.Content.Middle.ADReward = Button.New(self.transform:Find('Content/Middle/ADReward'))
	self.Content.Middle.Bag = Button.New(self.transform:Find('Content/Middle/Bag'))
	self.Content.Bottom = UGUIObject.New(self.transform:Find('Content/Bottom'))
end

function Main1PanelHybridUI:IsLoadAsync()
	return true
end

function Main1PanelHybridUI:IsNeverDelete()
	return false
end

function Main1PanelHybridUI:IsImmediatelyDelete()
	return true
end

function Main1PanelHybridUI:IsTween()
	return false
end

function Main1PanelHybridUI:IsFullScreen()
	return false
end

function Main1PanelHybridUI:IsScreenBlur()
	return false
end

function Main1PanelHybridUI:IsPlaySound()
	return true
end

function Main1PanelHybridUI:Destroy()
	Main1PanelHybridUI.superclass.Destroy(self)
	self.Content.Bottom:Destroy()
	self.Content.Middle.Bag:Destroy()
	self.Content.Middle.ADReward:Destroy()
	self.Content.Middle.Sign:Destroy()
	self.Content.Middle.Email:Destroy()
	self.Content.Middle:Destroy()
	self.Content.Top:Destroy()
	self.Content:Destroy()
	self.Content.Bottom = nil
	self.Content.Middle.Bag = nil
	self.Content.Middle.ADReward = nil
	self.Content.Middle.Sign = nil
	self.Content.Middle.Email = nil
	self.Content.Middle = nil
	self.Content.Top = nil
	self.Content = nil
end