_G.DanjiPanel = class(DanjiPanelHybridUI)

UIManager:RegisterUIClass(UIPanelName.DanjiPanel,DanjiPanel)
--这个用来介绍毕业设计和服务器价格之类的

function DanjiPanel:OnLoaded()
    DanjiPanel.superclass.OnLoaded(self)
    self:SetView()
    self.back:OnClick(function()
        UIManager:OpenUI(UIPanelName.LoginPanel)
        self:Hide()
    end)
end 

function DanjiPanel:SetView()
    self.ScrollView:SetHorizontal(false)
    self.ScrollView:SetVertical(true)
    self.ScrollView:SetColCount(1)
    self.ScrollView:SetSpacing(0, 20)
    self.ScrollView:SetRenderClass(DanjiListItem)
    self.ScrollView:SetDataProvider(t_banbenlist)
end 