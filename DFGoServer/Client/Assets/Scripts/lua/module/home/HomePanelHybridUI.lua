--Created by HybridUI V3.0
_G.HomePanelHybridUI = class(BaseUI)

UIPanelName.HomePanel = "HomePanel"

function HomePanelHybridUI:ctor()
	self.prefabName = 'HomePanel'
	self.parentNodeName = _G.UILayerConsts.HOME
end

function HomePanelHybridUI:OnLoaded()
	HomePanelHybridUI.superclass.OnLoaded(self)
	self.Content = UGUIObject.New(self.transform:Find('Content'))
	self.Content.Top = UGUIObject.New(self.transform:Find('Content/Top'))
	self.Content.Middle = UGUIObject.New(self.transform:Find('Content/Middle'))
	self.Content.Middle.Email = Button.New(self.transform:Find('Content/Middle/Email'))
	self.Content.Middle.Sign = Button.New(self.transform:Find('Content/Middle/Sign'))
	self.Content.Middle.ADReward = Button.New(self.transform:Find('Content/Middle/ADReward'))
	self.Content.Middle.Bag = Button.New(self.transform:Find('Content/Middle/Bag'))
	self.Content.Middle.Purchase = Button.New(self.transform:Find('Content/Middle/Purchase'))
	self.Content.Middle.Coin = UGUIObject.New(self.transform:Find('Content/Middle/Coin'))
	self.Content.Middle.Coin.Text = Text.New(self.transform:Find('Content/Middle/Coin/Text'))
	self.Content.Middle.Coin.number = Text.New(self.transform:Find('Content/Middle/Coin/number'))
	self.Content.Bottom = UGUIObject.New(self.transform:Find('Content/Bottom'))
end

function HomePanelHybridUI:IsLoadAsync()
	return true
end

function HomePanelHybridUI:IsNeverDelete()
	return false
end

function HomePanelHybridUI:IsImmediatelyDelete()
	return true
end

function HomePanelHybridUI:IsTween()
	return false
end

function HomePanelHybridUI:IsFullScreen()
	return false
end

function HomePanelHybridUI:IsScreenBlur()
	return false
end

function HomePanelHybridUI:IsPlaySound()
	return true
end

function HomePanelHybridUI:Destroy()
	HomePanelHybridUI.superclass.Destroy(self)
	self.Content.Bottom:Destroy()
	self.Content.Middle.Coin.number:Destroy()
	self.Content.Middle.Coin.Text:Destroy()
	self.Content.Middle.Coin:Destroy()
	self.Content.Middle.Purchase:Destroy()
	self.Content.Middle.Bag:Destroy()
	self.Content.Middle.ADReward:Destroy()
	self.Content.Middle.Sign:Destroy()
	self.Content.Middle.Email:Destroy()
	self.Content.Middle:Destroy()
	self.Content.Top:Destroy()
	self.Content:Destroy()
	self.Content.Bottom = nil
	self.Content.Middle.Coin.number = nil
	self.Content.Middle.Coin.Text = nil
	self.Content.Middle.Coin = nil
	self.Content.Middle.Purchase = nil
	self.Content.Middle.Bag = nil
	self.Content.Middle.ADReward = nil
	self.Content.Middle.Sign = nil
	self.Content.Middle.Email = nil
	self.Content.Middle = nil
	self.Content.Top = nil
	self.Content = nil
end