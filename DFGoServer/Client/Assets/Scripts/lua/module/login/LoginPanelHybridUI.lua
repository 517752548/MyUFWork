--Created by HybridUI V3.0
_G.LoginPanelHybridUI = class(BaseUI)

UIPanelName.LoginPanel = "LoginPanel"

function LoginPanelHybridUI:ctor()
	self.prefabName = 'LoginPanel'
	self.parentNodeName = _G.UILayerConsts.CENTER
end

function LoginPanelHybridUI:OnLoaded()
	LoginPanelHybridUI.superclass.OnLoaded(self)
	self.bg = UGUIObject.New(self.transform:Find('bg'))
	self.btnEnter = Button.New(self.transform:Find('btnEnter'))
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
	self.btnEnter:Destroy()
	self.bg:Destroy()
	self.btnEnter = nil
	self.bg = nil
end