--Created by HybridUI V3.0
_G.ADPanelHybridUI = class(BaseUI)

UIPanelName.ADPanel = "ADPanel"

function ADPanelHybridUI:ctor()
	self.prefabName = 'ADPanel'
	self.parentNodeName = _G.UILayerConsts.CENTER
end

function ADPanelHybridUI:OnLoaded()
	ADPanelHybridUI.superclass.OnLoaded(self)
	self.Content = UGUIObject.New(self.transform:Find('Content'))
	self.Content.tittleBG = UGUIObject.New(self.transform:Find('Content/tittleBG'))
	self.Content.tittleBG.Text = Text.New(self.transform:Find('Content/tittleBG/Text'))
	self.Content.Des = Text.New(self.transform:Find('Content/Des'))
	self.Content.AD = UGUIObject.New(self.transform:Find('Content/AD'))
	self.Content.AD.Text = Text.New(self.transform:Find('Content/AD/Text'))
	self.Content.closeBtn = UGUIObject.New(self.transform:Find('Content/closeBtn'))
end

function ADPanelHybridUI:IsLoadAsync()
	return true
end

function ADPanelHybridUI:IsNeverDelete()
	return true
end

function ADPanelHybridUI:IsImmediatelyDelete()
	return true
end

function ADPanelHybridUI:IsTween()
	return false
end

function ADPanelHybridUI:IsFullScreen()
	return false
end

function ADPanelHybridUI:IsScreenBlur()
	return false
end

function ADPanelHybridUI:IsPlaySound()
	return true
end

function ADPanelHybridUI:Destroy()
	ADPanelHybridUI.superclass.Destroy(self)
	self.Content.closeBtn:Destroy()
	self.Content.AD.Text:Destroy()
	self.Content.AD:Destroy()
	self.Content.Des:Destroy()
	self.Content.tittleBG.Text:Destroy()
	self.Content.tittleBG:Destroy()
	self.Content:Destroy()
	self.Content.closeBtn = nil
	self.Content.AD.Text = nil
	self.Content.AD = nil
	self.Content.Des = nil
	self.Content.tittleBG.Text = nil
	self.Content.tittleBG = nil
	self.Content = nil
end