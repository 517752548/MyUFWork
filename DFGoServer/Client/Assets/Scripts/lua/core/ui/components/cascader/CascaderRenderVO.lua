--[[
    级联菜单渲染数据
    author:wangningdong
    time:2019-01-29 14:18:20
]]

_G.CascaderRenderVO = class()

function CascaderRenderVO:ctor()
	
	self.tid = nil		-- 索引id
	self.itemid = nil	-- 道具id
	self.id = nil		-- id
	self.layer = nil	-- 层级
	self.name = nil		-- 名称
	
	self.isShowTips = false -- 是否显示小红点

	self.data = {}		-- 数据

	self.parent = nil 		-- 父节点
	self.childList = {}		-- 子列表
end

function CascaderRenderVO:SetTid( tid )
	self.tid = tid
end

function CascaderRenderVO:GetTid()
	return self.tid
end

function CascaderRenderVO:SetItemId( itemId )
	self.itemid = itemId
end

function CascaderRenderVO:GetItemId()
	return self.itemid
end

function CascaderRenderVO:SetId( id )
	self.id = id
end

function CascaderRenderVO:GetId()
	return self.id
end

function CascaderRenderVO:SetLayer( layer )
	self.layer = layer
end

function CascaderRenderVO:SetName( name )
	self.name = name
end

function CascaderRenderVO:ShowTips( isShow )
	self.isShowTips = isShow
end

function CascaderRenderVO:IsShowTips()
	return self.isShowTips
end


-- function CascaderRenderVO:SetData( val )
-- 	self.data = val
-- end

function CascaderRenderVO:AddData( val )
	table.insert(self.data, val)
end

function CascaderRenderVO:SetParent( parent )
	self.parent = parent
end

function CascaderRenderVO:SetChildList( list )
	self.childList = list
end

function CascaderRenderVO:GetChildList()
	return self.childList
end
