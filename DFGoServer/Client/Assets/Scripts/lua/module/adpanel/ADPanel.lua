_G.ADPanel = class(ADPanelHybridUI)

UIManager:RegisterUIClass(UIPanelName.ADPanel,ADPanel)

function ADPanel:OnLoaded()
    ADPanel.superclass.OnLoaded(self)
    self.Content.closeBtn:OnClick(function()
        self:Hide()
    end)
end

function ADPanel:OnShow(args)
    self:ShowMask(self,self:GetTransform(),nil,nil,false)
end 
