_G.loginServerTime = 0
_G.readTime = 0
_G.intervalTime = 0
_G.serverSTime = 0
_G.mergeSTime = 0
_G.TIME_ZONE = 8 * 60 * 60
_G.dwCurTime = nil;
_G.ONE_MINUTE = 60
_G.ONE_HOUR = 60 * 60
_G.ONE_DAY = 24 * 60 * 60

--获取运行过的时间(ms)
_G.GetCurTime = function()
	return Time.time
end

--获取服务器时间(UTC)
_G.GetServerTime = function()
    return intervalTime + os.time()
end

-- --获取本地时间 弃用
-- _G.GetLocalTime = function()
-- 	local serverTime = _G.intervalTime + os.time() + TIME_ZONE
-- 	return serverTime
-- end

-- 设置服务器时间(UTC)
_G.SetServerTime = function(serverTime)
    loginServerTime = serverTime
    readTime = os.time()
    intervalTime = loginServerTime - readTime
end

--开服时间
_G.SetServerSTime = function(time)
	serverSTime = time
end

--合服时间
_G.SetMergeSTime = function(time)
	mergeSTime = time
end

--获取当天的秒数
_G.GetSecOfDay = function()
	return os.time() % ONE_DAY
end

--获得当前的小时数
_G.GetCurrHour = function()
	return math.floor((GetServerTime() % ONE_DAY) / ONE_HOUR)
end

--获得当前的分钟数
_G.GetCurrMinute = function()
	return math.floor((GetServerTime() % ONE_HOUR) / ONE_MINUTE)
end

--获取当天的秒数
_G.GetServerSecOfDay = function()
	return GetServerTime() % ONE_DAY
end

--@return year(4位)，month(1-12)，day (1--31)，hour (0-23)， min (0-59)，sec (0-61)，wday (星期几， 星期天为1)， yday (年内天数)和isdst (是否为日光节约时间true/false)的带键名的表
_G.GetDateByTime = function()
    return os.date("*t", GetServerTime())
end

_G.GetZeroTime = function(sec)
	sec = sec + TIME_ZONE
	sec = sec - sec % ONE_DAY 
	return sec - TIME_ZONE
end

_G.GetTimeByDate = function(year, month, day, hour, min, sec)
	return os.time({year=year, month=month, day=day, hour=hour, min=min, sec=sec})
end

--获取当天已用时的秒数
_G.GetDayTime = function()
	local sec = GetServerTime() + TIME_ZONE
	return sec % ONE_DAY
end
