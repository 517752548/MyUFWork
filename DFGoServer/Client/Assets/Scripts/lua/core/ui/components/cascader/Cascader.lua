--[[
    级联菜单
    author:wangningdong
    time:2019-01-29 14:18:20
]]

_G.Cascader = class()

function Cascader:ctor()
	self.data = nil
	self.ScrollTab = {}

	self.callBack = nil
	self.fristCall = nil
end

function Cascader:SetFristCallBack( func )
	self.fristCall = func
end

function Cascader:SetCallBack( func )
	self.callBack = func
end

function Cascader:Push( scrollList )
	table.insert( self.ScrollTab, scrollList)
end

function Cascader:GetData()
	return self.data
end

function Cascader:SetData( data )
	self.data = data
	self:Register()
	self:ShowRootInfo()
end

function Cascader:Register()
    for i, scroll in ipairs(self.ScrollTab) do
		scroll:AllowRepeatSelected( true )
        scroll:OnSelectedItem(
			function(toggle)
				self:OnSelectedCall(i, toggle)
            end
        )
    end
end

function Cascader:OnSelectedCall(i, toggle)
	if not toggle then
		return
	end

	local _cascaderRenderVo = toggle:GetData()
	if self.fristCall and i == 1 then
		self.fristCall( _cascaderRenderVo:GetTid(), toggle:GetIndex() )
	end

	local childList = _cascaderRenderVo.childList
	if childList and #childList > 0 then
		self:ShowNextInfo(i, childList)

		--隐藏下下一个开始的所有菜单
		for idx, scroll in ipairs( self.ScrollTab ) do
			if idx >= i + 2 then
				-- scroll:ClearAllSelected()
				scroll:SetVisible(false)
			end
		end
	else
		if _cascaderRenderVo.data then
			if self.callBack then
				self.callBack( _cascaderRenderVo.data )
			end
			
			-- 隐藏其它		
			for idx, scroll in ipairs( self.ScrollTab ) do
				if idx > 1 then
					self:ShowToLeftAction(scroll)
					-- scroll:SetVisible(false)
					-- scroll:ClearAllSelected()
				end
			end
		end
	end
end

function Cascader:ShowRootInfo()
	if self.data == nil or #self.data == 0 then
		return
	end

	self:ShowNextInfo(0, self.data)
end

function Cascader:ShowNextInfo(i, data)
	local scroll = self.ScrollTab[i+1]
	if scroll then		
		local tsf = scroll.transform
		if tsf then
			tsf:DOKill()
			tsf.localScale = Vector3.New(0, 1, 1)
			LayoutRebuilder.ForceRebuildLayoutImmediate(tsf)
		end		
		
		scroll:SetVisible(true)
		scroll:SetDataProvider(data)
		self:ShowToRightAction(scroll)
	end
end


-- 刷新小红点
function Cascader:RefreshRedPoint()
	if not self.data then
		return
	end

	HeChengUtil:UpdateRedPointState(self.data)

	local scroll = self.ScrollTab[1]
	if scroll then
		scroll:SetDataProvider(self.data)
	end
end


function Cascader:Destroy()
	self.data = nil
	self.callBack = nil
	self.fristCall = nil

	-- for i, scroll in ipairs(self.ScrollTab) do
	-- 	scroll:Destroy()
	-- end
	self.ScrollTab = {}
end

-------------------------------------------------------
function Cascader:ShowToLeftAction( scroll )
	if not scroll then
		return
	end

	local tsf = scroll.transform
	if not tsf then
		scroll:SetVisible(false)
		return
	end

	tsf:DOKill()
	tsf:DOScaleX(0, 0.3):SetEase(Ease.OutQuad):OnComplete(function()
		-- scroll:ClearAllSelected()
		scroll:SetVisible(false)
	end)
end

function Cascader:ShowToRightAction( scroll )
	if not scroll then
		return
	end

	local tsf = scroll.transform
	tsf:DOKill()
	tsf:DOScaleX(1, 0.3):SetEase(Ease.OutQuad)
end