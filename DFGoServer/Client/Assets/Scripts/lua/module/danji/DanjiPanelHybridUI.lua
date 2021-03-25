--Created by HybridUI V3.0
_G.DanjiPanelHybridUI = class(BaseUI)

UIPanelName.DanjiPanel = "DanjiPanel"

function DanjiPanelHybridUI:ctor()
	self.prefabName = 'DanjiPanel'
	self.parentNodeName = _G.UILayerConsts.CENTER
end

function DanjiPanelHybridUI:OnLoaded()
	DanjiPanelHybridUI.superclass.OnLoaded(self)
	self.bg = UGUIObject.New(self.transform:Find('bg'))
	self.ScrollView = ScrollList.New(self.transform:Find('ScrollView'))
	self.back = Button.New(self.transform:Find('back'))
end

function DanjiPanelHybridUI:IsLoadAsync()
	return true
end

function DanjiPanelHybridUI:IsNeverDelete()
	return false
end

function DanjiPanelHybridUI:IsImmediatelyDelete()
	return true
end

function DanjiPanelHybridUI:IsTween()
	return false
end

function DanjiPanelHybridUI:IsFullScreen()
	return false
end

function DanjiPanelHybridUI:IsScreenBlur()
	return false
end

function DanjiPanelHybridUI:IsPlaySound()
	return true
end

function DanjiPanelHybridUI:Destroy()
	DanjiPanelHybridUI.superclass.Destroy(self)
	self.back:Destroy()
	self.ScrollView:Destroy()
	self.bg:Destroy()
	self.back = nil
	self.ScrollView = nil
	self.bg = nil
end