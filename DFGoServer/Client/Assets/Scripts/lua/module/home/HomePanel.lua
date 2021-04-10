_G.HomePanel = class(HomePanelHybridUI)

UIManager:RegisterUIClass(UIPanelName.HomePanel,HomePanel)

function HomePanel:OnLoaded()
    HomePanel.superclass.OnLoaded(self)
    self.Content.Middle.Email:OnClick(function() 
        UIManager:OpenUI(UIPanelName.InvitePanel)
    end)

    self.Content.Middle.Sign:OnClick(function()
        UIManager:OpenUI(UIPanelName.SignPanel)
    end)

    self.Content.Middle.ADReward:OnClick(function()
        UIManager:OpenUI(UIPanelName.ADPanel)
    end)

    self.Content.Middle.Bag:OnClick(function()
        UIManager:OpenUI(UIPanelName.BagPanel)
    end)

    self.Content.Middle.Purchase:OnClick(function()
        UIManager:OpenUI(UIPanelName.PurchasePanel)
    end)
end 