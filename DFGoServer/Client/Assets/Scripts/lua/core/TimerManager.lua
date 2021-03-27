---@class TimerManager
_G.TimerManager                = {}
TimerManager.list              = {}
TimerManager.lateList          = {}
TimerManager.timeScaleDelayKey = nil
function TimerManager:Init()
	if not self.handle then
		self.handle = UpdateBeat:CreateListener(self.Update, self)
	end
	UpdateBeat:AddListener(self.handle)
	if not self.lateHandle then
		self.lateHandle = LateUpdateBeat:CreateListener(self.LateUpdate, self)
	end
	LateUpdateBeat:AddListener(self.lateHandle)
end

function TimerManager:CreateTimerVO(callBack, delay, repeatCount, completeCallBack, canScale, list)
	local key     = tostring(callBack)
	local timerVO = self:_GetTimerVO(key, list)
	if timerVO then
		logWarning("重复添加Timer")
		return
	end

	local vo            = {}
	vo.key              = key
	vo.timerCallBack    = callBack
	vo.completeCallBack = completeCallBack
	vo.delay            = delay
	vo.repeatCount      = repeatCount
	vo.currCount        = 0
	vo.canScale         = canScale
	vo.timeStamp        = canScale and Time.time or Time.unscaledTime
	vo.removed          = false
	table.insert(list, vo)
	return key
end

---@type fun() @添加一个timer 这个timer是会被scaleTime影响的
function TimerManager:AddScaleTimer(callBack, delay, repeatCount, completeCallBack)
	repeatCount = repeatCount or 0
	if delay <= 0 and repeatCount == 1 then
		--延迟为0，并且只有1次执行的次数的话，直接执行回调
		callBack(1)
		return
	end
	return self:CreateTimerVO(callBack, delay, repeatCount, completeCallBack, true, self.list)
end

---@type fun() @添加一个timer 这个timer是不会被scaleTime影响的
---@return string @添加一个timer，返回这个timer的key(string类型) 当delay=0并且repeatCount=1的时候，表示这个函数是无延迟就调用一次的，那么就无需将这个timer添加到list里了，直接调用return即可
---@param callBack function @timer调用的方法回调
---@param delay number @延迟多少秒调用
---@param repeatCount int @重复次数
---@param completeCallBack function @全部的repeatCount次数执行完毕后调用这个回调
function TimerManager:AddTimer(callBack, delay, repeatCount, completeCallBack)
	repeatCount = repeatCount or 0
	if delay <= 0 and repeatCount == 1 then
		--延迟为0，并且只有1次执行的次数的话，直接执行回调
		callBack(1)
		return
	end
	return self:CreateTimerVO(callBack, delay, repeatCount, completeCallBack, false, self.list)
end

function TimerManager:AddLateTimer(callBack, delay, repeatCount, completeCallBack)
	repeatCount = repeatCount or 0
	if delay <= 0 and repeatCount == 1 then
		--延迟为0，并且只有1次执行的次数的话，直接执行回调
		callBack(1)
		return
	end
	return self:CreateTimerVO(callBack, delay, repeatCount, completeCallBack, false, self.lateList)
end

function TimerManager:RemoveTimer(key)
	self:_RemoveTimerItem(key, self.list)
end

function TimerManager:RemoveLateTimer(key)
	self:_RemoveTimerItem(key, self.lateList)
end

function TimerManager:_RemoveTimerItem(key, list)
	if not key then
		return
	end
	for i, vo in ipairs(list) do
		if vo.key == key then
			vo.key              = nil
			vo.timerCallBack    = nil
			vo.completeCallBack = nil
			vo.removed          = true
			break
		end
	end
end

function TimerManager:_GetTimerVO(key, list)
	for i, v in ipairs(list) do
		if v.key == key then
			return v
		end
	end
end

function TimerManager:Update()
	self:_IterUpdate(self.list)
end

function TimerManager:LateUpdate()
	self:_IterUpdate(self.lateList)
end

function TimerManager:_IterUpdate(list)
	for i, vo in ipairs(list) do
		if not vo.removed then
			local time = vo.canScale and Time.time or Time.unscaledTime
			local diff = time - vo.timeStamp
			if diff >= vo.delay then
				if not vo.removed then
					--计算调用多少次，如果发生卡帧，vo.timeStamp除以vo.delay得出经过几次delay间隔的次数
					local count = vo.delay <= 0 and 1 or math.floor(diff / vo.delay)
					--for i = 1, count do
						vo.currCount = vo.currCount + 1
						if vo.timerCallBack then
							vo.timerCallBack(vo.currCount)
						end

						if vo.repeatCount ~= 0 and vo.currCount >= vo.repeatCount then
							if vo.completeCallBack then
								vo.completeCallBack()
							end
							self:_RemoveTimerItem(vo.key, list)
							--break
						end
					--end
					vo.timeStamp = vo.delay <= 0 and time or (vo.timeStamp + vo.delay * count)
				end
			end
		end
	end
	--删除要清除的timer
	for i = #list, 1, -1 do
		local vo = list[i]
		if vo and vo.removed then
			table.remove(list, i)
		end
	end
end

---@return nil @设置全局的时间缩放
---@param scale number @时间缩放倍数 1为正常速度，如：0.3为将时间变慢为以前的30%  2为两倍以前的时间
---@param restoreDelay number 秒值 经过这个秒延迟后恢复timescale=1, 不传表示无限期时间缩放
function TimerManager:SetTimeScale(scale, restoreDelay)
	Time.timeScale = scale
	if restoreDelay then
		TimerManager:RemoveTimer(self.timeScaleDelayKey)
		self.timeScaleDelayKey = TimerManager:AddTimer(function()
			Time.timeScale = 1
		end, restoreDelay, 1)
	end
end

function TimerManager:CancelTimeScale()
	Time.timeScale = 1
end