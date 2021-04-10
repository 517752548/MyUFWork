_G.BagPanel = class(BagPanelHybridUI)

UIManager:RegisterUIClass(UIPanelName.BagPanel,BagPanel)

function BagPanel:OnLoaded()
    BagPanel.superclass.OnLoaded(self)
    self.Content.closeBtn:OnClick(function()
        self:Hide()
    end)
end

function BagPanel:OnShow(args)
    self:ShowMask(self,self:GetTransform(),nil,nil,false)
end 