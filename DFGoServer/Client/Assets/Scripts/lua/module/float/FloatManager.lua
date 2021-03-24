_G.FloatManager                 = {}

--是否正在显示全服公告
FloatManager.isShowAllServerAnn = false
--是否正在显示公告
FloatManager.isShowAnn          = false
FloatManager.isShowGMAnn        = false
--全服公告列表
FloatManager.allServerAnnList   = {}
--公告列表
FloatManager.annList            = {}
--GM公告列表
FloatManager.gmAnnList          = {}

--屏幕中间漂浮
function FloatManager:AddCenter(text)
	local floatPanel = UIManager:GetUI(UIPanelName.FloatPanel)
	if not floatPanel then return end
	floatPanel:ShowCenterToSequence(text)
end

--屏幕中间漂浮 失败带声音
function FloatManager:AddError(text)
	local f = '<color="#FF0000">%s</color>'
	self:AddCenter(string.format(f, text))
	SoundManager:PlaySFXExclusive(2021)
end

--屏幕中间漂浮 成功带声音
function FloatManager:AddSucceed(text)
	self:AddCenter(text)
	SoundManager:PlaySFXExclusive(4000)
end

--屏幕中间漂浮文字(加入到队列中)
function FloatManager:AddCenterToSequence(text)
	local floatPanel = UIManager:GetUI(UIPanelName.FloatPanel)
	if not floatPanel then return end
	floatPanel:ShowCenterToSequence(text)
end

--显示中下方活动内公告
function FloatManager:AddActivity(text)
	--UIFloat:ShowActivity(text)
end

--屏幕中间漂浮
function FloatManager:AddTransformFloat(text, transform)
	local floatPanel = UIManager:GetUI("FloatTransformPanel")
	if not floatPanel then return end
	floatPanel:ShowTransformToSequence(text, transform)
end

--------------------------------------客户端直接发SysNotice----------------------------------------
function FloatManager:AddSysNotice(id, param)
	local cfg = t_sysnotice[id]
	if not cfg then
		FloatManager:AddError(_T "错误的提示编号," .. id)
		return
	end

	if not param then param = "" end
	if cfg.channel > 0 then
		ChatController:AddSysNotice(cfg.channel, id, param, cfg.sound == 1)
	end

	--if cfg.float ~= 0 then
	--	local sysNoticeStr = NoticeUtil:GetSysNoticeStr(id,param)
	--	if sysNoticeStr and sysNoticeStr~="" then
	--		if cfg.float == 1 then
	--			self:AddCenter(sysNoticeStr)
	--		elseif cfg.float == 2 then
	--			self:AddNormal(sysNoticeStr)
	--		elseif cfg.float == 3 then
	--			self:AddSkill(sysNoticeStr)
	--		end
	--	end
	--end
end
---------------------------------------玩家信息处理---------------------------------------------
--显示玩家信息类漂浮文字
function FloatManager:AddUserInfo(text)
	--UIFloatBottom:ShowUserInfo(text)
	--ChatController:AddUserInfo(text)
end

--玩家属性变化
function FloatManager:OnPlayerAttrChange(type, value, oldValue)
	value    = toint(value, 0.5)
	oldValue = toint(oldValue, 0.5)
	if value == oldValue then return end
	if type == enAttrType.eaBindGold or type == enAttrType.eaUnBindGold then
		if value > oldValue then
			self:AddUserInfo(string.format(_T "您获得了<color='#f7cc21'>银两 </color>+%s", getNumShow(value - oldValue)))
		else
			self:AddUserInfo(string.format(_T "您消耗了<color='#f7cc21'>银两 </color>-%s", getNumShow(oldValue - value)))
		end
	elseif type == enAttrType.eaExp then
		if value > oldValue then
			self:AddUserInfo(string.format(_T "您获得了<color='#26e208'>经验 </color>+%s", getNumShow(value - oldValue)))
		end
	elseif type == enAttrType.eaBindMoney then
		if value > oldValue then
			self:AddUserInfo(string.format(_T "你获得了<color='#f7cc21'>绑元 </color>+%s", getNumShow(value - oldValue)))
		else
			self:AddUserInfo(string.format(_T "您消耗了<color='#f7cc21'>绑元 </color>-%s", getNumShow(oldValue - value)))
		end
	elseif type == enAttrType.eaUnBindMoney then
		if value > oldValue then
			self:AddUserInfo(string.format(_T "你获得了<color='#f7cc21'>元宝 </color>+%s", getNumShow(value - oldValue)))
		else
			self:AddUserInfo(string.format(_T "您消耗了<color='#f7cc21'>元宝 </color>-%s", getNumShow(oldValue - value)))
		end
	end
end

--物品获得失去提示
function FloatManager:OnPlayerItemAddReduce(type, itemId, num)
	local cfg = t_item[itemId] or t_equip[itemId]
	if not cfg then return end
	local str = ""
	if type == 1 then
		local name = "<color='" .. BagConsts:GetItemQualityColor(cfg.quality) .. "'>" .. cfg.name .. "</color>"
		str        = string.format(_T "你获得了「%s」x%s", name, num)
	else
		local name = "<color='" .. BagConsts:GetItemQualityColor(cfg.quality) .. "'>" .. cfg.name .. "</color>"
		str        = string.format(_T "您消耗了「%s」x%s", name, num)
	end
	self:AddUserInfo(str)
end

--消耗经验提示
function FloatManager:OnExpReduce(num)
	self:AddUserInfo(string.format(_T "您消耗了<color='#26e208'>经验 </color>-%s", getNumShow(num)))
end

----------------------------------------公告处理---------------------------------------------------
--显示全服公告
function FloatManager:AddAllServerAnn(text)
	UIManager:OpenUI("ServerAnnouncePanel", text)
end

--显示公告
function FloatManager:AddAnn(text)
	UIManager:OpenUI("AnnouncePanel", text)
end