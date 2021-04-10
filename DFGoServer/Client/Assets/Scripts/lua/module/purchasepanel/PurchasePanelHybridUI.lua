--Created by HybridUI V3.0
_G.PurchasePanelHybridUI = class(BaseUI)

UIPanelName.PurchasePanel = "PurchasePanel"

function PurchasePanelHybridUI:ctor()
	self.prefabName = 'PurchasePanel'
	self.parentNodeName = _G.UILayerConsts.CENTER
end

function PurchasePanelHybridUI:OnLoaded()
	PurchasePanelHybridUI.superclass.OnLoaded(self)
	self.Content = UGUIObject.New(self.transform:Find('Content'))
	self.Content.tittleBG = UGUIObject.New(self.transform:Find('Content/tittleBG'))
	self.Content.tittleBG.Text = Text.New(self.transform:Find('Content/tittleBG/Text'))
	self.Content.closeBtn = Button.New(self.transform:Find('Content/closeBtn'))
	self.Content.ScrollView = ScrollFlowList.New(self.transform:Find('Content/ScrollView'))
	self.Content.Buttons = UGUIObject.New(self.transform:Find('Content/Buttons'))
	self.Content.Buttons.Weapon = Button.New(self.transform:Find('Content/Buttons/Weapon'))
	self.Content.Buttons.Cloth = Button.New(self.transform:Find('Content/Buttons/Cloth'))
	self.Content.Buttons.Cailiao = Button.New(self.transform:Find('Content/Buttons/Cailiao'))
	self.Content.Buttons.Xiaohaopin = Button.New(self.transform:Find('Content/Buttons/Xiaohaopin'))
	self.Content.Buttons.Jingsu = Button.New(self.transform:Find('Content/Buttons/Jingsu'))
end

function PurchasePanelHybridUI:IsLoadAsync()
	return true
end

function PurchasePanelHybridUI:IsNeverDelete()
	return true
end

function PurchasePanelHybridUI:IsImmediatelyDelete()
	return true
end

function PurchasePanelHybridUI:IsTween()
	return true
end

function PurchasePanelHybridUI:IsFullScreen()
	return false
end

function PurchasePanelHybridUI:IsScreenBlur()
	return false
end

function PurchasePanelHybridUI:IsPlaySound()
	return true
end

function PurchasePanelHybridUI:Destroy()
	PurchasePanelHybridUI.superclass.Destroy(self)
	self.Content.Buttons.Jingsu:Destroy()
	self.Content.Buttons.Xiaohaopin:Destroy()
	self.Content.Buttons.Cailiao:Destroy()
	self.Content.Buttons.Cloth:Destroy()
	self.Content.Buttons.Weapon:Destroy()
	self.Content.Buttons:Destroy()
	self.Content.ScrollView:Destroy()
	self.Content.closeBtn:Destroy()
	self.Content.tittleBG.Text:Destroy()
	self.Content.tittleBG:Destroy()
	self.Content:Destroy()
	self.Content.Buttons.Jingsu = nil
	self.Content.Buttons.Xiaohaopin = nil
	self.Content.Buttons.Cailiao = nil
	self.Content.Buttons.Cloth = nil
	self.Content.Buttons.Weapon = nil
	self.Content.Buttons = nil
	self.Content.ScrollView = nil
	self.Content.closeBtn = nil
	self.Content.tittleBG.Text = nil
	self.Content.tittleBG = nil
	self.Content = nil
end