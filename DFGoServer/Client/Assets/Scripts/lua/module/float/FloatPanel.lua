_G.FloatPanel = class(BaseUI)

UIPanelName.FloatPanel = "FloatPanel"

UIManager:RegisterUIClass(UIPanelName.FloatPanel, FloatPanel)

function FloatPanel:ctor()
    self.prefabName = "FloatPanel"
    self.parentNodeName = _G.UILayerConsts.NOTICE

    self.strList = {}
    self.lastTime = 0
end

function FloatPanel:OnLoaded()
    -- self.center           = self.transform:Find("center")
    self.centerTemplateGO = self.transform:Find("template").gameObject
end

function FloatPanel:OnShow(args)
    FloatPanel.superclass.OnShow(self, args)
end

function FloatPanel:IsNeverDelete()
    return true
end

function FloatPanel:IsLoadAsync()
    return false
end

function FloatPanel:ShowCenter(text)
    local go = newObject(self.centerTemplateGO)
    go.transform:SetParent(self.transform)
    go:SetActive(true)
    go.transform.localPosition = Vector3.zero
    go.transform.localRotation = Quaternion.identity
    go.transform.localScale = Vector3.one

    local seq = DOTween.Sequence()
    seq:Insert(
        0.8,
        go.transform:DOLocalMoveY(80, 0.5):OnComplete(
            function()
                destroy(go)
            end
        )
    )
    seq:Play()

    local textField = go.transform:Find("textField"):GetComponent(typeof(TMPro.TextMeshProUGUI))
    textField.text = text
end

-- 显示多重提示
function FloatPanel:ShowCenterToSequence(text)
    table.insert(self.strList, text)

    if not self:IsUpdate() then
        self:RunUpdate()
    end
end

function FloatPanel:ShowSequenceText()
    local str = table.remove(self.strList, 1)
    if not str then
        -- 如果队列中没有数据,就先停止update
        self:StopUpdate()
        return false
    end

    local go = newObject(self.centerTemplateGO)
    if not go then
        return false
    end

    go.transform:SetParent(self.transform)
    go:SetActive(true)
    go.transform.localPosition = Vector3.zero
    go.transform.localRotation = Quaternion.identity
    go.transform.localScale = Vector3.one

    local textField = go.transform:Find("textField"):GetComponent(typeof(TMPro.TextMeshProUGUI))
    textField.text = str

    local canvasGroup = go:GetComponent("CanvasGroup")
    canvasGroup.alpha = 0

    local seq = DOTween.Sequence()
    seq:Append(canvasGroup:DOFade(1, 0.3))
    seq:Append(go.transform:DOLocalMoveY(100, 1.2))
    seq:Append(canvasGroup:DOFade(0, 0.3))
    seq:OnComplete(
        function()
            destroy(go)
        end
    )
    seq:Play()

    return true
end

--------------------------------------------------------------------
function FloatPanel:Update()
    if GetCurTime() - self.lastTime > 0.4 then
        if self:ShowSequenceText() then
            self.lastTime = GetCurTime()
        end
    end
end
