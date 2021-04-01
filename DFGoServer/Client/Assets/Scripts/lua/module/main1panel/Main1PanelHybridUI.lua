--Created by HybridUI V3.0
_G.Main1PanelHybridUI = class(BaseUI)

UIPanelName.Main1Panel = "Main1Panel"

function Main1PanelHybridUI:ctor()
	self.prefabName = 'Main1Panel'
	self.parentNodeName = _G.UILayerConsts.CENTER
end

function Main1PanelHybridUI:OnLoaded()
	Main1PanelHybridUI.superclass.OnLoaded(self)
	self.bg = UGUIObject.New(self.transform:Find('bg'))
	self.Content = UGUIObject.New(self.transform:Find('Content'))
	self.Content.Top = UGUIObject.New(self.transform:Find('Content/Top'))
	self.Content.Middle = UGUIObject.New(self.transform:Find('Content/Middle'))
	self.Content.Middle.Email = UGUIObject.New(self.transform:Find('Content/Middle/Email'))
	self.Content.Middle.Email.Text = Text.New(self.transform:Find('Content/Middle/Email/Text'))
	self.Content.Middle.Sign = UGUIObject.New(self.transform:Find('Content/Middle/Sign'))
	self.Content.Middle.Sign.Text = Text.New(self.transform:Find('Content/Middle/Sign/Text'))
	self.Content.Middle.ADReward = UGUIObject.New(self.transform:Find('Content/Middle/ADReward'))
	self.Content.Middle.ADReward.Text = Text.New(self.transform:Find('Content/Middle/ADReward/Text'))
	self.Content.Middle.Bag = UGUIObject.New(self.transform:Find('Content/Middle/Bag'))
	self.Content.Middle.Bag.Text = Text.New(self.transform:Find('Content/Middle/Bag/Text'))
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
	self.Content.Middle.Bag.Text:Destroy()
	self.Content.Middle.Bag:Destroy()
	self.Content.Middle.ADReward.Text:Destroy()
	self.Content.Middle.ADReward:Destroy()
	self.Content.Middle.Sign.Text:Destroy()
	self.Content.Middle.Sign:Destroy()
	self.Content.Middle.Email.Text:Destroy()
	self.Content.Middle.Email:Destroy()
	self.Content.Middle:Destroy()
	self.Content.Top:Destroy()
	self.Content:Destroy()
	self.bg:Destroy()
	self.Content.Bottom = nil
	self.Content.Middle.Bag.Text = nil
	self.Content.Middle.Bag = nil
	self.Content.Middle.ADReward.Text = nil
	self.Content.Middle.ADReward = nil
	self.Content.Middle.Sign.Text = nil
	self.Content.Middle.Sign = nil
	self.Content.Middle.Email.Text = nil
	self.Content.Middle.Email = nil
	self.Content.Middle = nil
	self.Content.Top = nil
	self.Content = nil
	self.bg = nil
end