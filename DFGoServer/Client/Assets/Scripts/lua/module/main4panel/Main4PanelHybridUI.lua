--Created by HybridUI V3.0
_G.Main4PanelHybridUI = class(BaseUI)

UIPanelName.Main4Panel = "Main4Panel"

function Main4PanelHybridUI:ctor()
	self.prefabName = 'Main4Panel'
	self.parentNodeName = _G.UILayerConsts.CENTER
end

function Main4PanelHybridUI:OnLoaded()
	Main4PanelHybridUI.superclass.OnLoaded(self)
	self.bg = UGUIObject.New(self.transform:Find('bg'))
	self.Content = UGUIObject.New(self.transform:Find('Content'))
	self.Content.Top = UGUIObject.New(self.transform:Find('Content/Top'))
	self.Content.Middle = UGUIObject.New(self.transform:Find('Content/Middle'))
	self.Content.Middle.Login = UGUIObject.New(self.transform:Find('Content/Middle/Login'))
	self.Content.Middle.Login.Button = Button.New(self.transform:Find('Content/Middle/Login/Button'))
	self.Content.Middle.OnLineTime = Text.New(self.transform:Find('Content/Middle/OnLineTime'))
	self.Content.Middle.CRCount = Text.New(self.transform:Find('Content/Middle/CRCount'))
	self.Content.Middle.QDCount = Text.New(self.transform:Find('Content/Middle/QDCount'))
	self.Content.Bottom = UGUIObject.New(self.transform:Find('Content/Bottom'))
end

function Main4PanelHybridUI:IsLoadAsync()
	return true
end

function Main4PanelHybridUI:IsNeverDelete()
	return false
end

function Main4PanelHybridUI:IsImmediatelyDelete()
	return true
end

function Main4PanelHybridUI:IsTween()
	return false
end

function Main4PanelHybridUI:IsFullScreen()
	return false
end

function Main4PanelHybridUI:IsScreenBlur()
	return false
end

function Main4PanelHybridUI:IsPlaySound()
	return true
end

function Main4PanelHybridUI:Destroy()
	Main4PanelHybridUI.superclass.Destroy(self)
	self.Content.Bottom:Destroy()
	self.Content.Middle.QDCount:Destroy()
	self.Content.Middle.CRCount:Destroy()
	self.Content.Middle.OnLineTime:Destroy()
	self.Content.Middle.Login.Button:Destroy()
	self.Content.Middle.Login:Destroy()
	self.Content.Middle:Destroy()
	self.Content.Top:Destroy()
	self.Content:Destroy()
	self.bg:Destroy()
	self.Content.Bottom = nil
	self.Content.Middle.QDCount = nil
	self.Content.Middle.CRCount = nil
	self.Content.Middle.OnLineTime = nil
	self.Content.Middle.Login.Button = nil
	self.Content.Middle.Login = nil
	self.Content.Middle = nil
	self.Content.Top = nil
	self.Content = nil
	self.bg = nil
end