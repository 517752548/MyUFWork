_G.OnlineListItem = class(OnlineListItemHybridUI)

function OnlineListItem:SetData(data)
    self.text1:SetText(data.id)
    self.text2:SetText(data.Size)
    self.text3:SetText(data.PeiZhi)
end 