_G.OnLinePanel = class(OnLinePanelHybridUI)

UIManager:RegisterUIClass(UIPanelName.OnLinePanel,OnLinePanel)


--这个用来介绍一些版本内容之类的


function OnLinePanel:OnLoaded()
    OnLinePanel.superclass.OnLoaded(self)
    self:SetView()
    self.back:OnClick(function() 
        UIManager:OpenUI(UIPanelName.LoginPanel)
        self:Hide()
    end)
end

function OnLinePanel:SetView()
    self.ScrollView:SetHorizontal(false)
    self.ScrollView:SetVertical(true)
    self.ScrollView:SetColCount(1)
    self.ScrollView:SetSpacing(0, 20)
    self.ScrollView:SetRenderClass(OnlineListItem)
    self.ScrollView:SetDataProvider(t_serverlist)
end 