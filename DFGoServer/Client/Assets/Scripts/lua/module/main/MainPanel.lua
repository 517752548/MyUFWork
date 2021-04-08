_G.MainPanel = class(MainPanelHybridUI)

UIManager:RegisterUIClass(UIPanelName.MainPanel,MainPanel)

function MainPanel:OnLoaded()
    MainPanel.superclass.OnLoaded(self)
end 

function MainPanel:OnShow(args)
    self.Content.Bottom.content.btn1:OnClick(function()
        self:ClickBottom(1)
    end)
    self.Content.Bottom.content.btn2:OnClick(function()
        self:ClickBottom(2)
    end)
    self.Content.Bottom.content.btn3:OnClick(function()
        self:ClickBottom(3)
    end)
    self.Content.Bottom.content.btn4:OnClick(function()
        self:ClickBottom(4)
    end)
    self:ClickBottom(1)
end 


function MainPanel:ClickBottom(id)
    for i = 1, 4 do
        if id == i then
            UIManager:OpenUI(UIPanelName["Main" .. tostring(i) .. "Panel"])
            --self.Content.Bottom.content["btn" .. tostring(i)]["btn" .. tostring(i)]:SetVisible(true)
        else
            UIManager:HideUI(UIPanelName["Main" .. tostring(i) .. "Panel"])
            --self.Content.Bottom.content["btn" .. tostring(i)]["btn" .. tostring(i)]:SetVisible(false) 
        end
    end
    TDGA.Report("ClickBottom",{ ["clickBottom"] = id })
end 