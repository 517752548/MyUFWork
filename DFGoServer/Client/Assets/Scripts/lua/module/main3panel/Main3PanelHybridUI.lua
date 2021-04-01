--Created by HybridUI V3.0
_G.Main3PanelHybridUI = class(BaseUI)

UIPanelName.Main3Panel = "Main3Panel"

function Main3PanelHybridUI:ctor()
	self.prefabName = 'Main3Panel'
	self.parentNodeName = _G.UILayerConsts.CENTER
end

function Main3PanelHybridUI:OnLoaded()
	Main3PanelHybridUI.superclass.OnLoaded(self)
	self.bg = UGUIObject.New(self.transform:Find('bg'))
	self.Content = UGUIObject.New(self.transform:Find('Content'))
	self.Content.Top = UGUIObject.New(self.transform:Find('Content/Top'))
	self.Content.Middle = UGUIObject.New(self.transform:Find('Content/Middle'))
	self.Content.Middle.AccountType = Text.New(self.transform:Find('Content/Middle/AccountType'))
	self.Content.Middle.ADCount = Text.New(self.transform:Find('Content/Middle/ADCount'))
	self.Content.Middle.PayCount = Text.New(self.transform:Find('Content/Middle/PayCount'))
	self.Content.Middle.MyInviteCode = Text.New(self.transform:Find('Content/Middle/MyInviteCode'))
	self.Content.Middle.ChildAccount = Text.New(self.transform:Find('Content/Middle/ChildAccount'))
	self.Content.Middle.ChildMoney = Text.New(self.transform:Find('Content/Middle/ChildMoney'))
	self.Content.Middle.LoginDay = Text.New(self.transform:Find('Content/Middle/LoginDay'))
	self.Content.Bottom = UGUIObject.New(self.transform:Find('Content/Bottom'))
end

function Main3PanelHybridUI:IsLoadAsync()
	return true
end

function Main3PanelHybridUI:IsNeverDelete()
	return false
end

function Main3PanelHybridUI:IsImmediatelyDelete()
	return true
end

function Main3PanelHybridUI:IsTween()
	return false
end

function Main3PanelHybridUI:IsFullScreen()
	return false
end

function Main3PanelHybridUI:IsScreenBlur()
	return false
end

function Main3PanelHybridUI:IsPlaySound()
	return true
end

function Main3PanelHybridUI:Destroy()
	Main3PanelHybridUI.superclass.Destroy(self)
	self.Content.Bottom:Destroy()
	self.Content.Middle.LoginDay:Destroy()
	self.Content.Middle.ChildMoney:Destroy()
	self.Content.Middle.ChildAccount:Destroy()
	self.Content.Middle.MyInviteCode:Destroy()
	self.Content.Middle.PayCount:Destroy()
	self.Content.Middle.ADCount:Destroy()
	self.Content.Middle.AccountType:Destroy()
	self.Content.Middle:Destroy()
	self.Content.Top:Destroy()
	self.Content:Destroy()
	self.bg:Destroy()
	self.Content.Bottom = nil
	self.Content.Middle.LoginDay = nil
	self.Content.Middle.ChildMoney = nil
	self.Content.Middle.ChildAccount = nil
	self.Content.Middle.MyInviteCode = nil
	self.Content.Middle.PayCount = nil
	self.Content.Middle.ADCount = nil
	self.Content.Middle.AccountType = nil
	self.Content.Middle = nil
	self.Content.Top = nil
	self.Content = nil
	self.bg = nil
end