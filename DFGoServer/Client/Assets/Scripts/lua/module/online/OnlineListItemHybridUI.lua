--Created by HybridUI V3.0
_G.OnlineListItemHybridUI = class(UGUIObject)

function OnlineListItemHybridUI:OnLoaded()
	OnlineListItemHybridUI.superclass.OnLoaded(self)
	self.text1 = Text.New(self.transform:Find('text1'))
	self.text2 = Text.New(self.transform:Find('text2'))
	self.text3 = Text.New(self.transform:Find('text3'))
end

function OnlineListItemHybridUI:Destroy()
	self.text3:Destroy()
	self.text2:Destroy()
	self.text1:Destroy()
	self.text3 = nil
	self.text2 = nil
	self.text1 = nil
	OnlineListItemHybridUI.superclass.Destroy(self)
end