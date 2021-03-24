_G.UILayerConsts = {
	BUBBLE   		= "Bubble", 		-- 冒泡层(与 TITLE 层 同级 )
	TITLE    		= "Title", 			-- title层
	SKIPFONT 		= "SkipFont", 		-- 伤害冒字
	TOUCH    		= "Touch", 			-- 触摸
	BOTTOM   		= "Bottom", 		-- 底层
	HOME     		= "Home", 			-- 主界面
	CENTER_LOW2   	= "Center_Low2", 	-- 中间层_低2
	CENTER_LOW1   	= "Center_Low1", 	-- 中间层_低1
	CENTER   		= "Center", 		-- 中间层
	CENTER_HIGH1   	= "Center_High1",	-- 中间层_高1
	CENTER_HIGH2	= "Center_High2", 	-- 中间层_高2
	NPCTALK  		= "NpcTalk", 		-- npc对话层(仅npc对话时使用  (与 TOP 层 同级 ) )
	TOP      		= "Top", 			-- 顶层
	STORY    		= "Story", 			-- 剧情
	NOTICE   		= "Notice", 		-- 消息用的层级
	LOADING  		= "Loading", 		-- loading层
}

setmetatable(UILayerConsts, { __index = function(t, k) logError("[" .. k .. "] layer not exist") end })
