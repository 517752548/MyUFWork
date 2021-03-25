--Created by HybridUI V3.0
_G.DanjiListItemHybridUI = class(UGUIObject)

function DanjiListItemHybridUI:OnLoaded()
	DanjiListItemHybridUI.superclass.OnLoaded(self)
	self.name = Text.New(self.transform:Find('name'))
	self.text2 = Text.New(self.transform:Find('text2'))
	self.test3 = Text.New(self.transform:Find('test3'))
end

function DanjiListItemHybridUI:Destroy()
	self.test3:Destroy()
	self.text2:Destroy()
	self.name:Destroy()
	self.test3 = nil
	self.text2 = nil
	self.name = nil
	DanjiListItemHybridUI.superclass.Destroy(self)
end