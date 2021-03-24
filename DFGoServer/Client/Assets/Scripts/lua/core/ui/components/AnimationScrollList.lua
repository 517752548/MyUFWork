-- Create by:侯旭东
-- Date:     2019/12/25 21:21
-- Copyright 2019 - 2020 All Rights Reserved 

---@class AnimationScrollList
_G.AnimationScrollList = class()

function AnimationScrollList:ctor(scrollView)
	self.scrollView       = scrollView
	self.template         = nil
	self.renderPrefabName = nil
	self.renderList       = nil
	self.seq              = nil
	self.childComponents  = nil
	self.InitPos          = nil
	self.horizontal       = false
	self.vertical         = false
	self.width            = nil
	self.height           = nil
	self.templateWidth    = nil
	self.templateHeight   = nil
	self.padding          = nil
	self.spacing          = nil
	self.movingNum        = nil
end

function AnimationScrollList:_Init()
	if not self.scrollView then
		return
	end
	if not self.renderList then
		self.renderList  = self.scrollView:GetRenderers()
		local scrollRect = self.scrollView:GetScrollRect()
		self.horizontal  = scrollRect.horizontal
		self.vertical    = scrollRect.vertical
	end
	if not self.width or not self.height then
		local rect  = self.scrollView:GetRect()
		self.width  = rect.width
		self.height = rect.height
	end
	if not self.padding then
		self.padding = self.scrollView.padding
	end
	if not self.spacing then
		self.spacing = self.scrollView.spacing
	end
	self.scrollView:SetHorizontal(false)
	self.scrollView:SetVertical(false)
	if not self.childComponents then
		self.childComponents       = {}
		local InitTemplateInfoFunc = function()
			local rect          = self.template:GetRect()
			self.templateWidth  = rect.width
			self.templateHeight = rect.height
		end
		if not self.template then
			self.template = self.scrollView:FindChildObject('Viewport/Content/template')
			if self.template then
				if not self.templateWidth or not self.templateHeight then
					InitTemplateInfoFunc()
				end
			else
				local abPath  = ResUtil:GetUIPath(self.renderPrefabName)
				local uiObj   = ResManager:LoadPrefab(abPath)
				self.template = UGUIObject.New(uiObj.transform)
				InitTemplateInfoFunc()
			end
		end
		local childComponents = self.template.transform:GetComponentsInChildren(typeof(UnityEngine.Transform), true)
		if childComponents then
			local psLen = childComponents.Length
			for i = 0, psLen - 1 do
				local childComponentsName = childComponents[i].gameObject.name
				if childComponentsName ~= "template" then
					table.insert(self.childComponents, childComponentsName)
				end
			end
			self.InitPos = {}
			for _, name in ipairs(self.childComponents) do
				local Tsf = self.template:FindChildObject(name)
				if Tsf then
					self.InitPos[name] = Tsf:GetPos()
				end
			end
		end
	end
	self.movingNum = math.ceil((self.height - self.padding.top) / (self.spacing.y + self.templateHeight))
	self.movingNum = math.min(self.movingNum, #self.renderList)
	if self.seq then
		self.seq:Kill()
		self.seq = nil
	end
	self:DOKill()
end

function AnimationScrollList:DOKill()
	if not self.childComponents then return end
	for _, render in ipairs(self.renderList) do
		for _, name in ipairs(self.childComponents) do
			if render[name] then
				render[name].transform:DOKill()
			end
		end
	end
end

---TweenBottom_To_Top
---@param callBack table
function AnimationScrollList:TweenBottom_To_Top(callBack)
	self:_Init()
	self.seq    = DOTween.Sequence()
	local DIF_Y = self.height + self.templateHeight / 2 + 10
	for i, render in ipairs(self.renderList) do
		if i <= self.movingNum then
			for _, name in ipairs(self.childComponents) do
				local Tsf = render[name]
				if Tsf and self.InitPos[name] then
					Tsf:SetPos(Vector3.New(Tsf:GetPos().x, self.InitPos[name].y - DIF_Y, Tsf:GetPos().z))
					self.seq:Insert(i * 0.1, Tsf:GetTransform():DOLocalMoveY(Tsf:GetPos().y + DIF_Y, 0.3))
				end
			end
		end
	end
	self:OnComplete(callBack)
end

---TweenTop_To_Bottom
---@param callBack table
function AnimationScrollList:TweenTop_To_Bottom(callBack)
	self:_Init()
	self.seq    = DOTween.Sequence()
	local DIF_Y = self.height + self.templateHeight / 2 + 10
	for i, render in ipairs(self.renderList) do
		if i <= self.movingNum then
			for _, name in ipairs(self.childComponents) do
				local Tsf = render[name]
				if Tsf and self.InitPos[name] then
					Tsf:SetPos(Vector3.New(Tsf:GetPos().x, self.InitPos[name].y + DIF_Y, Tsf:GetPos().z))
					self.seq:Insert(i * 0.1, Tsf:GetTransform():DOLocalMoveY(Tsf:GetPos().y - DIF_Y, 0.3))
				end
			end
		end
	end
	self:OnComplete(callBack)
end

---TweenLeft_To_Right
---@param callBack table
function AnimationScrollList:TweenLeft_To_Right(callBack, singleTime)
	if not singleTime then
		singleTime = 0.3
	end
	self:_Init()
	self.seq    = DOTween.Sequence()
	local DIF_X = self.width + self.templateWidth / 2 + 10
	for i, render in ipairs(self.renderList) do
		if i <= self.movingNum then
			for _, name in ipairs(self.childComponents) do
				local Tsf = render[name]
				if Tsf and self.InitPos[name] then
					Tsf:SetPos(Vector3.New(self.InitPos[name].x - DIF_X, Tsf:GetPos().y, Tsf:GetPos().z))
					self.seq:Insert(i * 0.08, Tsf:GetTransform():DOLocalMoveX(Tsf:GetPos().x + DIF_X, singleTime))
				end
			end
		end
	end
	self:OnComplete(callBack)
end

---TweenRight_To_Left
---@param callBack table
function AnimationScrollList:TweenRight_To_Left(callBack)
	self:_Init()
	self.seq    = DOTween.Sequence()
	local DIF_X = self.width + self.templateWidth / 2 + 10
	for i, render in ipairs(self.renderList) do
		if i <= self.movingNum then
			for _, name in ipairs(self.childComponents) do
				local Tsf = render[name]
				if Tsf and self.InitPos[name] then
					Tsf:SetPos(Vector3.New(self.InitPos[name].x + DIF_X, Tsf:GetPos().y, Tsf:GetPos().z))
					self.seq:Insert(i * 0.1, Tsf:GetTransform():DOLocalMoveX(Tsf:GetPos().x - DIF_X, 0.3))
				end
			end
		end
	end
	self:OnComplete(callBack)
end

---TweenLocalLeft_To_Right 从当前位置移动
---@param callBack table
function AnimationScrollList:TweenLocalLeft_To_Right(callBack)
	self:_Init()
	self.seq    = DOTween.Sequence()
	local DIF_X = self.width + self.templateWidth / 2 + 10
	for i, render in ipairs(self.renderList) do
		if i <= self.movingNum then
			for _, name in ipairs(self.childComponents) do
				local Tsf = render[name]
				if Tsf and self.InitPos[name] then
					Tsf:SetPos(Vector3.New(self.InitPos[name].x, Tsf:GetPos().y, Tsf:GetPos().z))
					self.seq:Insert(i * 0.1, Tsf:GetTransform():DOLocalMoveX(Tsf:GetPos().x + DIF_X, 0.3))
				end
			end
		end
	end
	self:OnComplete(callBack)
end

function AnimationScrollList:OnComplete(callBack)
	if not self.seq then return end
	self.seq:OnComplete(function()
		if callBack then
			callBack()
		else
			self.scrollView:SetHorizontal(self.horizontal)
			self.scrollView:SetVertical(self.vertical)
		end
		self.seq = nil
	end)
end

function AnimationScrollList:Destroy()
	if self.seq then
		self.seq:Kill()
		self.seq = nil
	end
	self:DOKill()
	self.scrollView      = nil
	self.template        = nil
	self.renderList      = nil
	self.childComponents = nil
	self.InitPos         = nil
	self.horizontal      = nil
	self.vertical        = nil
	self.width           = nil
	self.height          = nil
	self.templateWidth   = nil
	self.templateHeight  = nil
	self.padding         = nil
	self.spacing         = nil
	self.movingNum       = nil
end