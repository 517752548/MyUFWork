--Created by HybridUI V3.0
_G.LoginPanelHybridUI = class(BaseUI)

UIPanelName.LoginPanel = "LoginPanel"

function LoginPanelHybridUI:ctor()
	self.prefabName = 'LoginPanel'
	self.parentNodeName = _G.UILayerConsts.HOME
end

function LoginPanelHybridUI:OnLoaded()
	LoginPanelHybridUI.superclass.OnLoaded(self)
	self.bg = UGUIObject.New(self.transform:Find('bg'))
	self.DanjiBtn = Button.New(self.transform:Find('DanjiBtn'))
	self.Text = Text.New(self.transform:Find('Text'))
	self.OnLineBtn = Button.New(self.transform:Find('OnLineBtn'))
	self.MainBtn = Button.New(self.transform:Find('MainBtn'))
end

function LoginPanelHybridUI:IsLoadAsync()
	return true
end

function LoginPanelHybridUI:IsNeverDelete()
	return false
end

function LoginPanelHybridUI:IsImmediatelyDelete()
	return true
end

function LoginPanelHybridUI:IsTween()
	return false
end

function LoginPanelHybridUI:IsFullScreen()
	return false
end

function LoginPanelHybridUI:IsScreenBlur()
	return false
end

function LoginPanelHybridUI:IsPlaySound()
	return false
end

function LoginPanelHybridUI:Destroy()
	LoginPanelHybridUI.superclass.Destroy(self)
	self.MainBtn:Destroy()
	self.OnLineBtn:Destroy()
	self.Text:Destroy()
	self.DanjiBtn:Destroy()
	self.bg:Destroy()
	self.MainBtn = nil
	self.OnLineBtn = nil
	self.Text = nil
	self.DanjiBtn = nil
	self.bg = nil
end