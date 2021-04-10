_G.InvitePanel = class(InvitePanelHybridUI)
UIManager:RegisterUIClass(UIPanelName.InvitePanel,InvitePanel)

function InvitePanel:OnLoaded()
    InvitePanel.superclass.OnLoaded(self)
    self.Content.closeBtn:OnClick(function() 
        self:Hide()
    end)
end

function InvitePanel:OnShow(args)
    self:ShowMask(self,self:GetTransform(),nil,nil,false)
end 
