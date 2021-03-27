_G.MsgManager        = {}
MsgManager.listenMap = {}
function MsgManager.OnResponse(msgId, byteArray)
	if not MsgMap[msgId] then
		logError("找不到对应的消息解析类 MsgId=" .. msgId)
		return
	end
	if not MsgManager.listenMap[msgId] then
		logWarning("找不到消息协议处理回调 MsgId=" .. msgId)
		return
	end

	local msgCls = _G.MsgMap[msgId]
	local msg    = msgCls:new()
	msg:ParseData(byteArray)
	if (msgId < MsgType.SC_SCENE_ENTER_GAME or msgId > MsgType.SC_OBJ_ATTR_INFO) and
			(msgId ~= MsgType.SC_SCENE_MONSTER_MOVE_TO_NOTIFY) and
			(msgId ~= MsgType.WC_HeartBeat) then
		--log("Receive Msg : " .. msg.msgId)
	end
	for k, v in pairs(MsgManager.listenMap[msgId]) do
		if not v.func then
			logWarning("没有发现回调函数:" .. msgId)
			return
		end
		v.func(v.obj, msg)
	end
end

function MsgManager:Send(msg)
	local byteArray = GByteArray.New()
	msg:encode(byteArray)
	NetManager:Send(msg.msgId, byteArray)
	if msg.msgId ~= MsgType.CW_HeartBeat then
		--log("Send Msg : " .. msg.msgId)
	end
	msg = nil
end

function MsgManager:Add(msgId, obj, func)
	if not msgId then
		logError("注册了一个不存在的消息:", debug.traceback());
		return ;
	end
	if not self.listenMap[msgId] then
		self.listenMap[msgId] = {}
	end
	for k, vo in pairs(self.listenMap[msgId]) do
		if vo.obj == obj and vo.func == func then
			logWarning('不能重复注册消息:' .. msgId)
			return
		end
	end
	local vo = { obj = obj, func = func }
	table.insert(self.listenMap[msgId], vo)
	return true
end

function MsgManager:Remove(msgId, obj, func)
	if not self.listenMap[msgId] then
		logWarning('无法找到要移除的消息' .. msgId)
		return
	end
	for i = #self.listenMap[msgId], 1, -1 do
		local vo = self.listenMap[msgId][i]
		if vo.obj == obj and vo.func == func then
			table.remove(self.listenMap[msgId], i)
			return true
		end
	end
	logWarning('无法找到要移除的消息的对应方法' .. msgId)
end
