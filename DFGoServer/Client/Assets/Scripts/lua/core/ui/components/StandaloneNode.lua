---@class StandaloneNode @这是通过HybridUI来生成的一个Frame的基类，他继承于UGUIObject，因为本质上他就是一个GameObject，但作为一个类似‘面板’的组件，这里赋予了它与StandaloneNode一致性的逻辑操作，比如Show和Hide，以及OnShow和OnHide
_G.StandaloneNode = class(UGUIObject)

function StandaloneNode:ctor(transform)
	self.onHideCallBack   = nil
	self.notificationList = {}
	self.facade           = GameApp.facade
end

function StandaloneNode:Show()
	self:SetVisible(true)
	self:OnShow()
	if self:IsTween() then
		self:DoShowTween()
	end
end

-- 执行打开缓动(此函数可被子类重新覆盖)
function StandaloneNode:DoShowTween()
	if not self.transform then return end
	if self.tweener then return end
	self.transform:DOKill()
	self.transform.localScale = Vector3.New(0.2, 0.2, 0.2)
	self.tweener              = self.transform:DOScale(Vector3.one, 0.3):SetEase(Ease.OutBack)
	self.tweener:OnComplete(
			function()
				self.tweener = nil
				self:DoShow()
			end
	)
end

function StandaloneNode:Hide()
	self:RemoveAllNotification()
	self:OnHide()
	self:HideMask()
	self:SetVisible(false)
	if self.onHideCallBack then
		self.onHideCallBack()
	end
end

function StandaloneNode:IsShow()
	return self:GetVisible()
end

function StandaloneNode:OnShow()

end

function StandaloneNode:OnHide()

end

function StandaloneNode:OnHideCallBack(func)
	self.onHideCallBack = func
end

function StandaloneNode:Destroy()
	self.onHideCallBack = nil
	self:RemoveAllNotification()
	self.notificationList = nil
	self.facade           = nil
	StandaloneNode.superclass.Destroy(self)
end

function StandaloneNode:IsTween()
	return false
end

--------------------notice消息注册------------------------------------
-- notice消息注册
function StandaloneNode:RegisterNotification()
	-- 子类实现
end

function StandaloneNode:AddNotification(name, obj, func)
	local result = self.facade:AddNotification(name, obj, func)
	if result then
		table.insert(self.notificationList, { name = name, obj = obj, func = func })
	end
end

function StandaloneNode:RemoveNotification(name, obj, func)
	local result = self.facade:RemoveNotification(name, obj, func)
	if result then
		for i = #self.notificationList, 1, -1 do
			local vo = self.notificationList[i]
			if vo.name == name and vo.obj == obj and vo.func == func then
				table.remove(self.notificationList, i)
				break
			end
		end
	end
end

function StandaloneNode:SendNotification(name, body)
	self.facade:SendNotification(name, body)
end

function StandaloneNode:RemoveAllNotification()
	for i = #self.notificationList, 1, -1 do
		local vo = self.notificationList[i]
		self:RemoveNotification(vo.name, vo.obj, vo.func)
	end
end
