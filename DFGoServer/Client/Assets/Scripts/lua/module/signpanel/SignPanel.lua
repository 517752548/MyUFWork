_G.SignPanel = class(SignPanelHybridUI)

UIManager:RegisterUIClass(UIPanelName.SignPanel,SignPanel)

function SignPanel:OnLoaded()
    SignPanel.superclass.OnLoaded(self)
    self.Content.closeBtn:OnClick(function()
        self:Hide()
    end)
end

function SignPanel:OnShow(args)
    self:ShowMask(self,self:GetTransform(),nil,nil,false)
end 