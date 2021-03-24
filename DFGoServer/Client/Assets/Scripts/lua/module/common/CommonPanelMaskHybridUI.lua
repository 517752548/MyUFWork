--Created by HybridUI V3.0
_G.CommonPanelMaskHybridUI = class(BaseUI)

UIPanelName.CommonPanelMask = "CommonPanelMask"

function CommonPanelMaskHybridUI:ctor()
	self.prefabName = 'CommonPanelMask'
	self.parentNodeName = _G.UILayerConsts.CENTER
end

function CommonPanelMaskHybridUI:OnLoaded()
	CommonPanelMaskHybridUI.superclass.OnLoaded(self)
	self.bg = Button.New(self.transform:Find('bg'))
	self.bgImage = Button.New(self.transform:Find('bgImage'))
end

function CommonPanelMaskHybridUI:IsLoadAsync()
	return true
end

function CommonPanelMaskHybridUI:IsNeverDelete()
	return false
end

function CommonPanelMaskHybridUI:IsImmediatelyDelete()
	return true
end

function CommonPanelMaskHybridUI:IsTween()
	return false
end

function CommonPanelMaskHybridUI:IsFullScreen()
	return false
end

function CommonPanelMaskHybridUI:IsScreenBlur()
	return false
end

function CommonPanelMaskHybridUI:IsPlaySound()
	return false
end

function CommonPanelMaskHybridUI:Destroy()
	CommonPanelMaskHybridUI.superclass.Destroy(self)
	self.bgImage:Destroy()
	self.bg:Destroy()
	self.bgImage = nil
	self.bg = nil
end