--
-- 版权所有: 北京燧木科技有限公司
-- Author: wangningdong
-- Date: 2020-6-8 21:24:12
-- 动态层级VO
--

_G.DynamicHierarchyVO = class()

function DynamicHierarchyVO:ctor()
	self.depth = 1              -- 层级
	self.isLastDepth = false    -- 是否是最底层

	self.id = 0                 -- id 唯一标识
	self.idx = 0                -- 当前层级中的索引
	self.name = ""              -- 名称

	self.isShowTips = false     -- 是否显示小红点

	self.parent = nil           -- 父节点

	self.childList = {}         -- 子列表
end

--- 层级
function DynamicHierarchyVO:SetDepth(depth)
	self.depth = depth
end

function DynamicHierarchyVO:GetDepth()
	return self.depth
end

--- 最底层状态
function DynamicHierarchyVO:SetLastDepth(val)
	self.isLastDepth = val
end

function DynamicHierarchyVO:IsLastDepth()
	return self.isLastDepth
end

--- id 唯一标识
function DynamicHierarchyVO:SetId(id)
	self.id = id
end

function DynamicHierarchyVO:GetId()
	return self.id
end

--- 当前层级中的索引
function DynamicHierarchyVO:SetIdx(val)
	self.idx = val
end

function DynamicHierarchyVO:GetIdx()
	return self.idx
end

--- 当前层级中的索引
function DynamicHierarchyVO:SetName(val)
	self.name = val
end

function DynamicHierarchyVO:GetName()
	return self.name
end

--- 当前层级中的索引
function DynamicHierarchyVO:ShowTips(isShow)
	self.isShowTips = isShow
end

function DynamicHierarchyVO:IsShowTips()
	return self.isShowTips
end

function DynamicHierarchyVO:SetParent(val)
	self.parent = val
end

function DynamicHierarchyVO:GetParent()
	return self.parent
end

function DynamicHierarchyVO:SetChildList(list)
	self.childList = list
end

function DynamicHierarchyVO:AddChild(vo)
	table.insert(self.childList, vo)
end

function DynamicHierarchyVO:GetChildList()
	return self.childList
end

function DynamicHierarchyVO:HasChild()
	return #self.childList > 0
end
