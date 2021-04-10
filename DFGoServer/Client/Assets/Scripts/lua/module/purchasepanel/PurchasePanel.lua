_G.PurchasePanel = class(PurchasePanelHybridUI)

UIManager:RegisterUIClass(UIPanelName.PurchasePanel,PurchasePanel)

function PurchasePanel:OnLoaded()
    PurchasePanel.superclass.OnLoaded(self)
    self.Content.closeBtn:OnClick(function()
        self:Hide()
    end)
end

function PurchasePanel:OnShow(args)
    self:ShowMask(self,self:GetTransform(),nil,nil,false)
end 