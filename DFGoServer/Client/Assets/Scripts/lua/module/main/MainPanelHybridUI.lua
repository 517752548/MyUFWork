--Created by HybridUI V3.0
_G.MainPanelHybridUI = class(BaseUI)

UIPanelName.MainPanel = "MainPanel"

function MainPanelHybridUI:ctor()
	self.prefabName = 'MainPanel'
	self.parentNodeName = _G.UILayerConsts.HOME
end

function MainPanelHybridUI:OnLoaded()
	MainPanelHybridUI.superclass.OnLoaded(self)
	self.bg = UGUIObject.New(self.transform:Find('bg'))
	self.Content = UGUIObject.New(self.transform:Find('Content'))
	self.Content.Top = UGUIObject.New(self.transform:Find('Content/Top'))
	self.Content.Top.Text = Text.New(self.transform:Find('Content/Top/Text'))
	self.Content.Middle = UGUIObject.New(self.transform:Find('Content/Middle'))
	self.Content.Bottom = UGUIObject.New(self.transform:Find('Content/Bottom'))
	self.Content.Bottom.content = UGUIObject.New(self.transform:Find('Content/Bottom/content'))
	self.Content.Bottom.content.btn1 = UGUIObject.New(self.transform:Find('Content/Bottom/content/btn1'))
	self.Content.Bottom.content.btn1.btn1 = UGUIObject.New(self.transform:Find('Content/Bottom/content/btn1/btn1'))
	self.Content.Bottom.content.btn2 = UGUIObject.New(self.transform:Find('Content/Bottom/content/btn2'))
	self.Content.Bottom.content.btn2.btn2 = UGUIObject.New(self.transform:Find('Content/Bottom/content/btn2/btn2'))
	self.Content.Bottom.content.btn3 = UGUIObject.New(self.transform:Find('Content/Bottom/content/btn3'))
	self.Content.Bottom.content.btn3.btn3 = UGUIObject.New(self.transform:Find('Content/Bottom/content/btn3/btn3'))
	self.Content.Bottom.content.btn4 = UGUIObject.New(self.transform:Find('Content/Bottom/content/btn4'))
	self.Content.Bottom.content.btn4.btn4 = UGUIObject.New(self.transform:Find('Content/Bottom/content/btn4/btn4'))
end

function MainPanelHybridUI:IsLoadAsync()
	return true
end

function MainPanelHybridUI:IsNeverDelete()
	return false
end

function MainPanelHybridUI:IsImmediatelyDelete()
	return true
end

function MainPanelHybridUI:IsTween()
	return false
end

function MainPanelHybridUI:IsFullScreen()
	return true
end

function MainPanelHybridUI:IsScreenBlur()
	return false
end

function MainPanelHybridUI:IsPlaySound()
	return true
end

function MainPanelHybridUI:Destroy()
	MainPanelHybridUI.superclass.Destroy(self)
	self.Content.Bottom.content.btn4.btn4:Destroy()
	self.Content.Bottom.content.btn4:Destroy()
	self.Content.Bottom.content.btn3.btn3:Destroy()
	self.Content.Bottom.content.btn3:Destroy()
	self.Content.Bottom.content.btn2.btn2:Destroy()
	self.Content.Bottom.content.btn2:Destroy()
	self.Content.Bottom.content.btn1.btn1:Destroy()
	self.Content.Bottom.content.btn1:Destroy()
	self.Content.Bottom.content:Destroy()
	self.Content.Bottom:Destroy()
	self.Content.Middle:Destroy()
	self.Content.Top.Text:Destroy()
	self.Content.Top:Destroy()
	self.Content:Destroy()
	self.bg:Destroy()
	self.Content.Bottom.content.btn4.btn4 = nil
	self.Content.Bottom.content.btn4 = nil
	self.Content.Bottom.content.btn3.btn3 = nil
	self.Content.Bottom.content.btn3 = nil
	self.Content.Bottom.content.btn2.btn2 = nil
	self.Content.Bottom.content.btn2 = nil
	self.Content.Bottom.content.btn1.btn1 = nil
	self.Content.Bottom.content.btn1 = nil
	self.Content.Bottom.content = nil
	self.Content.Bottom = nil
	self.Content.Middle = nil
	self.Content.Top.Text = nil
	self.Content.Top = nil
	self.Content = nil
	self.bg = nil
end