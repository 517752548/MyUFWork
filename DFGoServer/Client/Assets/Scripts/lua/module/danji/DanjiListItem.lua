_G.DanjiListItem = class(DanjiListItemHybridUI)

function DanjiListItem:OnLoaded()
    DanjiListItem.superclass.OnLoaded(self)
    
end 

function DanjiListItem:SetData(data)
    self.name:SetText(data.id)
    self.text2:SetText(data.Name)
    self.test3:SetText(data.Func)
end 