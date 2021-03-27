local MemMonitor = {}

_G.ShowMemory    = function(monitorName, step, barrier, barrierInfo)
	barrier                 = barrier or 1 --超过barrier时,打印警告
	barrierInfo             = barrierInfo or ""

	local monitor           = MemMonitor[monitorName] or {}

	local lastTotalMem      = step and monitor.totalMem or Profiler.GetTotalAllocatedMemory()
	local lastMonoMem       = step and monitor.monoMem or Profiler.GetMonoUsedSize()
	local lastClock         = step and monitor.clock or os.clock()

	local nowTotalMem       = Profiler.GetTotalAllocatedMemory()
	local nowMonoMem        = Profiler.GetMonoUsedSize()
	local nowClock          = os.clock()

	local resultTotal       = nowTotalMem - lastTotalMem
	local resultMono        = nowMonoMem - lastMonoMem
	local resultClock       = nowClock - lastClock

	monitor.totalMem        = nowTotalMem
	monitor.monoMem         = nowMonoMem
	monitor.clock           = nowClock
	MemMonitor[monitorName] = monitor
	if step then
		monitor.totalMem  = monitor.totalMem and monitor.totalMem + resultTotal or 0 --总内存消耗
		monitor.totalMono = monitor.totalMono and monitor.totalMono + resultMono or 0 --总mono消耗
		monitor.totalCpu  = monitor.totalCpu and monitor.totalCpu + resultClock or 0 --总cpu消耗
		monitor.callCount = monitor.callCount and monitor.callCount + 1 or 0 --调用次数

		local size        = resultTotal / 1000
		if size < barrier then
			log(string.format("[%s][%s] [%0dKB] %s", monitorName, step, size, barrierInfo))
		else
			logError(string.format("[%s][%s] [%0dKB] %s", monitorName, step, size, barrierInfo))
		end
	end
end

_G.trace         = function(e)
	if type(e) == "table" then
		log(tostringex(e))
	else
		log(tostring(e))
	end
end

_G.tostringex    = function(v, len)
	if len == nil then
		len = 0
	end
	local pre = string.rep("\t", len)
	local ret = ""
	if type(v) == "table" then
		if len > 5 then
			return "\t{ ... }"
		end
		local t    = ""
		local keys = {}
		for k, v1 in pairs(v) do
			table.insert(keys, k)
		end
		for k, v1 in pairs(keys) do
			k  = v1
			v1 = v[k]
			t  = t .. "\n\t" .. pre .. tostring(k) .. ":"
			t  = t .. tostringex(v1, len + 1)
		end
		if t == "" then
			ret = ret .. pre .. "{ }\t(" .. tostring(v) .. ")"
		else
			if len > 0 then
				ret = ret .. "\t(" .. tostring(v) .. ")\n"
			end
			ret = ret .. pre .. "{" .. t .. "\n" .. pre .. "}"
		end
	else
		ret = ret .. pre .. tostring(v) .. "\t(" .. type(v) .. ")"
	end
	return ret
end

_G.split         = function(s, delim)
	return s:split(delim)
end

_G.strtrim       = function(s)
	return (string.gsub(s, "^%s*(.-)%s*$", "%1"))
end

_G.getTableLen   = function(input)
	local ret = 0
	for i, v in pairs(input) do
		ret = ret + 1
	end
	return ret
end
--保留小数点后num位
_G.floorEx       = function(value, num)
	num = num or 0
	return math.floor(value * (10 ^ num)) * (1 / 10 ^ num)
end
_G.formatTime    = function(s)
	if s > 86400 then
		local day = math.floor(s / 86400)
		-- local hour=math.floor((s%86400)/3600)
		return string.format(_T "%s天", day)
	elseif s > 3600 then
		local hour = math.floor(s / 3600)
		-- local minute=math.floor((s%3600)/60)
		return string.format(_T "%s小时", hour)
	elseif s > 60 then
		local minute = math.floor(s / 60)
		return string.format(_T "%s分钟", minute)
	else
		local second = math.floor(s)
		return string.format(_T "%s秒", second)
	end
end

--转换数字为中文字符串
_G.formatNum     = function(num)
	if type(num) ~= 'number' then
		return num
	end
	if num >= 10 ^ 8 then
		local integer  = math.floor(num / (10 ^ 8))
		local decimals = num % (10 ^ 8) / (10 ^ 7)
		if decimals >= 1 then
			decimals = string.sub(decimals, 1, 1)
			return integer .. "." .. decimals .. _T "亿"
		end
		return integer .. _T "亿"
	elseif num >= 10 ^ 4 then
		num = math.floor(num / (10 ^ 4))
		return num .. _T "万"
	end
	return num
end

_G.GetTextByNum  = function(num)
	num       = tonumber(num)
	local cfg = t_numconst[num]
	if cfg then
		return cfg.val
	end
	return ""
end

_G.GetWeek       = function(num)
	if num == 0 or num == "0" then
		return _T "周日"
	elseif num == 1 or num == "1" then
		return _T "周一"
	elseif num == 2 or num == "2" then
		return _T "周二"
	elseif num == 3 or num == "3" then
		return _T "周三"
	elseif num == 4 or num == "4" then
		return _T "周四"
	elseif num == 5 or num == "5" then
		return _T "周五"
	elseif num == 6 or num == "6" then
		return _T "周六"
	else
		return ""
	end
end

table.empty      = {}

table.tostring   = function(t)
	local mark   = {}
	local assign = {}
	local ser_table
	if type(t) ~= "table" then
		return "{}"
	end
	ser_table = function(tbl, parent)
		mark[tbl] = parent
		local tmp = {}
		for k, v in pairs(tbl) do
			local key = type(k) == "number" and "[" .. k .. "]" or "[" .. string.format("%q", k) .. "]"
			if type(v) == "table" then
				local dotkey = parent .. key
				if mark[v] then
					table.insert(assign, dotkey .. "=" .. mark[v])
				else
					table.insert(tmp, key .. "=" .. ser_table(v, dotkey))
				end
			elseif type(v) == "string" then
				table.insert(tmp, key .. "=" .. string.format("%q", v))
			elseif type(v) == "number" or type(v) == "boolean" then
				table.insert(tmp, key .. "=" .. tostring(v))
			end
		end
		return "{" .. table.concat(tmp, ",") .. "}"
	end
	if #assign > 0 then
		Log(debug.traceback())
	end
	return ser_table(t, "ret") .. table.concat(assign, " ")
end

local function deep_copy(orig)
	local copy
	if type(orig) == "table" then
		copy = {}
		for orig_key, orig_value in next, orig, nil do
			copy[deep_copy(orig_key)] = deep_copy(orig_value)
		end
		setmetatable(copy, deep_copy(getmetatable(orig)))
	else
		copy = orig
	end
	return copy
end

table.clone         = function(object)
	local lookup_table = {}
	local function _copy(object)
		if type(object) ~= "table" then
			return object
		elseif lookup_table[object] then
			return lookup_table[object]
		end
		local newObject      = {}
		lookup_table[object] = newObject
		for key, value in pairs(object) do
			newObject[_copy(key)] = _copy(value)
		end
		return setmetatable(newObject, getmetatable(object))
	end
	return _copy(object)
end

table.tostringPrint = function(t, depth, d)
	local mark   = {}
	local assign = {}
	local ser_table
	if type(t) ~= "table" then
		return "{}"
	end
	ser_table = function(tbl, parent, depth, d)
		depth     = depth or 3
		d         = d or 1

		mark[tbl] = parent
		local tmp = {}
		for k, v in pairs(tbl) do
			local key = type(k) == "number" and "[" .. k .. "]" or "[" .. string.format("%q", k) .. "]"
			if type(v) == "table" and depth > 0 then
				local dotkey = parent .. key
				if mark[v] then
					table.insert(assign, dotkey .. "=" .. mark[v])
				else
					table.insert(tmp, key .. "=" .. ser_table(v, dotkey, depth - 1, d + 1))
				end
			elseif type(v) == "string" then
				table.insert(tmp, key .. "=" .. string.format("%q", v))
			elseif type(v) == "number" or type(v) == "boolean" then
				table.insert(tmp, key .. "=" .. tostring(v))
			end
		end
		return "{\n" .. string.rep(" ", d * 4) .. table.concat(tmp, ",\n" .. string.rep(" ", d * 4)) .. "\n}"
	end
	if #assign > 0 then
		Log(debug.traceback())
	end
	return ser_table(t, "ret") .. table.concat(assign, " ")
end

table.print         = function(tab)
	log(table.tostringPrint(tab))
end

table.concatArray   = function(...)
	local result = {}
	for _, array in ipairs { ... } do
		for i, v in ipairs(array) do
			table.insert(result, v)
		end
	end
	return result
end

table.shuffle       = function(tab)
	local cloneTab = table.clone(tab)
	local result   = {}
	local len      = #tab
	for i = 1, len do
		table.insert(result, table.remove(cloneTab, math.random(#cloneTab)))
	end
	return result
end

table.length        = function(tab)
	local count = 0
	for i, v in pairs(tab) do
		count = count + 1
	end
	return count
end

--返回字符串长度 一个中文字符长度为2
string.getLen       = function(str)
	local i              = 1
	local characterCount = 0
	local strLen         = str:len()
	while i <= strLen do
		local a = string.byte(str, i, i)
		if type(a) == "number" then
			if a >= 128 then
				i              = i + 3
				characterCount = characterCount + 2
			else
				i              = i + 1
				characterCount = characterCount + 1
			end
		end
	end
	return characterCount
end

string.utf8len      = function(input)
	local len  = string.len(input)
	local left = len
	local cnt  = 0
	local arr  = { 0, 0xc0, 0xe0, 0xf0, 0xf8, 0xfc }
	while left ~= 0 do
		local tmp = string.byte(input, -left)
		local i   = #arr
		while arr[i] do
			if tmp >= arr[i] then
				left = left - i
				break
			end
			i = i - 1
		end
		cnt = cnt + 1
	end
	return cnt
end

function string:split(delimiter)
	local result               = {}
	local from                 = 1
	local delim_from, delim_to = string.find(self, delimiter, from)
	while delim_from do
		table.insert(result, string.sub(self, from, delim_from - 1))
		from                 = delim_to + 1
		delim_from, delim_to = string.find(self, delimiter, from)
	end
	table.insert(result, string.sub(self, from))
	return result
end

string.leftpad    = function(str, len, char)
	if char == nil then
		char = " "
	end
	return string.rep(char, len - #str) .. str
end

--字符串切割，参数： 源字符串，切割符
--返回：切割后的表
string.strTotable = function(szFullString, szSeparator)
	local nFindStartIndex = 1
	local nSplitIndex     = 1
	local nSplitArray     = {}
	while true do
		local nFindLastIndex = string.find(szFullString, szSeparator, nFindStartIndex)
		if not nFindLastIndex then
			nSplitArray[nSplitIndex] = string.sub(szFullString, nFindStartIndex, string.len(szFullString))
			break
		end
		nSplitArray[nSplitIndex] = string.sub(szFullString, nFindStartIndex, nFindLastIndex - 1)
		nFindStartIndex          = nFindLastIndex + string.len(szSeparator)
		nSplitIndex              = nSplitIndex + 1
	end
	return nSplitArray
end

function LuaTableToString(obj)
	local getIndent, quoteStr, wrapKey, wrapVal, dumpObj
	getIndent = function(level)
		return string.rep("\t", level)
	end
	quoteStr  = function(str)
		return '"' .. string.gsub(str, '"', '\\"') .. '"'
	end
	wrapKey   = function(val)
		if type(val) == "number" then
			return "[" .. val .. "]"
		elseif type(val) == "string" then
			return val
		else
			return "[" .. tostring(val) .. "]"
		end
	end
	wrapVal   = function(val, level, color)
		if type(val) == "table" then
			return dumpObj(val, level)
		elseif type(val) == "number" then
			if color then
				return string.format("%#x", val)
			end
			return val
		elseif type(val) == "string" then
			return quoteStr(val)
		else
			return tostring(val)
		end
	end
	dumpObj   = function(obj, level)
		if type(obj) ~= "table" then
			return wrapVal(obj)
		end
		level               = level + 1
		local tokens        = {}
		tokens[#tokens + 1] = "{"
		for k, v in pairs(obj) do
			tokens[#tokens + 1] = getIndent(level) .. wrapKey(k) .. " = " .. wrapVal(v, level, k == "color") .. ","
		end
		tokens[#tokens + 1] = getIndent(level - 1) .. "}"
		return table.concat(tokens, "\n")
	end

	return dumpObj(obj, 0)
end

function getFileName(str)
	local idx = str:match(".+()%.%w+$")
	if idx then
		return str:sub(1, idx - 1)
	else
		return str
	end
end

function getExtension(str)
	return str:match(".+%.(%w+)$")
end

_G.toint                 = function(value)
	return math.floor(tonumber(value) or 0)
end

_G.toint32               = function(value)
	return Util.Int(value)
end
---@return number
---@param value 要转化为float的数字或字符
---@param f 保留的小数点位数 不传参就表示原数返回  传入0表示不保留小数点后的浮点数
_G.tofloat               = function(value, f)
	value = tonumber(value)
	if not f or f < 0 then
		return value
	end
	return math.floor(value * (10 ^ f)) / (10 ^ f)
end

_G.convert_to_int_ipairs = function(list)
	if not list then return end
	for i, v in ipairs(list) do
		list[i] = toint(v)
	end
end

--扩展math函数，增加四舍五入方法
math.round               = function(decimal)
	if decimal % 1 >= 0.5 then
		decimal = math.ceil(decimal)
	else
		decimal = math.floor(decimal)
	end
	return decimal
end

function GetSceneHeight(pos)
	local oldPosY           = pos.y
	pos.y                   = 200
	local rayResult, rayHit = Physics.Raycast(pos, Vector3.down, nil, Mathf.Infinity, NavRaycastLayerMask)
	pos.y                   = oldPosY
	if rayResult then
		local navResult, navHit = NavMesh.SamplePosition(rayHit.point, nil, 1, NavMesh.AllAreas)
		if navResult then
			return navHit.position.y
		end
	end
	return oldPosY
end

function CheckPoint(pos)
	local oldPosY           = pos.y
	pos.y                   = 200
	local rayResult, rayHit = Physics.Raycast(pos, Vector3.down, nil, Mathf.Infinity, NavRaycastLayerMask)
	pos.y                   = oldPosY
	if rayResult then
		local navResult, navHit = NavMesh.SamplePosition(rayHit.point, nil, 1, NavMesh.AllAreas)
		if navResult then
			return true, navHit.position
		end
	end
end

function ConvertNavMeshPathToTable(...)
	local paths  = { ... }
	local result = {}
	for _, path in ipairs(paths) do
		if not path then
			return
		end
		for i = 0, path.corners.Length - 1 do
			local corners = path.corners[i]
			local pos     = corners:Clone()
			table.insert(result, pos)
		end
	end
	return result
end

function ScreenPosToScreenCanvasPosXY(screenPos)
	local widthRate  = UIManager:GetCanvasFullSize().x / UnityEngine.Screen.width
	local heightRate = UIManager:GetCanvasFullSize().y / UnityEngine.Screen.height
	return ((screenPos.x * widthRate) - (UIManager:GetCanvasFullSize().x * 0.5)), ((screenPos.y * heightRate) - (UIManager:GetCanvasFullSize().y * 0.5))
end

function ScreenPosToScreenMeshPosXY(screenPos)
	local x, y = ScreenPosToScreenCanvasPosXY(screenPos)
	return x * 0.01, y * 0.01
end

function GetDistanceTwoPoint(pos1, pos2)
	return math.sqrt((pos1.x - pos2.x) ^ 2 + (pos1.z - pos2.z) ^ 2)
end

function GetDistanceTwoPointNoSqrt(pos1, pos2)
	return (pos1.x - pos2.x) ^ 2 + (pos1.z - pos2.z) ^ 2
end
function Get2DDistanceTwoPoint(pos1, pos2)
	return math.sqrt((pos1.x - pos2.x) ^ 2 + (pos1.y - pos2.y) ^ 2)
end
function Get2DDistanceTwoPointNoSqrt(pos1, pos2)
	return (pos1.x - pos2.x) ^ 2 + (pos1.y - pos2.y) ^ 2
end

function GetDirTwoPoint(a, b)
	local x          = b.x - a.x
	local z          = b.z - a.z
	x                = tofloat(x, 3)
	z                = tofloat(z, 3)
	local deltaAngle = 0
	if x == 0 and z == 0 then
		return 0
	elseif x > 0 and z > 0 then
		deltaAngle = 0
	elseif x > 0 and z == 0 then
		return 90
	elseif x > 0 and z < 0 then
		deltaAngle = 180
	elseif x == 0 and z < 0 then
		return 180
	elseif x < 0 and z < 0 then
		deltaAngle = -180
	elseif x < 0 and z == 0 then
		return -90
	elseif x < 0 and z > 0 then
		deltaAngle = 0
	end
	local dir = Mathf.Atan(x / z) * Mathf.Rad2Deg + deltaAngle
	return dir
end

function GetPointGapRangeFromMainPlayerPos(to, range)
	local player = MainPlayerController:GetPlayer()
	if not player then
		return to
	end
	local playerPos = player:GetPos():Clone()
	if not playerPos then
		return to
	end
	playerPos.y = 0
	local dis   = GetDistanceTwoPoint(playerPos, to)
	local pos   = playerPos + (((to - playerPos):SetNormalize()) * (dis - range))
	while not CheckPoint(pos) do
		if range < 0.1 then
			pos = to
			break
		end
		range = range / 2
		return GetPointGapRangeFromMainPlayerPos(to, range)
	end
	return pos
end

function GetPointGapRange(from, to, range)
	local dis = GetDistanceTwoPoint(from, to)
	return from + (to - from):SetNormalize() * (dis - range)
end

function GetPointStepToPoint(from, to, step)
	return from + (to - from):SetNormalize() * step
end

function GetPosByDis(pos, dir, dis)
	local r   = Quaternion.Euler(0, dir, 0)
	local pos = pos + (r * Vector3.forward) * dis
	return pos
end

local spriteDefVec = Vector2.New(0.5, 0.5)
function Texture2DToSprite(texture)
	if not texture then
		return nil
	end
	return Sprite.Create(texture, Rect.New(0, 0, texture.width, texture.height), spriteDefVec)
end

function CheckVector2Equals(va, vb, threshold)
	if not va then
		return
	end
	if not vb then
		return
	end
	if not threshold then
		threshold = 0
	end
	return math.abs(va.x - vb.x) <= threshold and math.abs(va.y - vb.y) <= threshold
end

function CheckVector3Equals(va, vb, threshold)
	if not va then
		return
	end
	if not vb then
		return
	end
	if not threshold then
		threshold = 0
	end
	return math.abs(va.x - vb.x) <= threshold and math.abs(va.y - vb.y) <= threshold and
			math.abs(va.z - vb.z) <= threshold
end

function CheckVector3Equals_for_path(va, vb, threshold)
	if not va then
		return
	end
	if not vb then
		return
	end
	if not threshold then
		threshold = 0
	end
	return math.abs(va.x - vb.x) <= threshold and
			math.abs(va.z - vb.z) <= threshold
end
--将角度变为最近的一个正数角度
function FixedEulerAngle(a)
	local r = ((a % 360) + 360) % 360
	return r
end

function ClampAngle(angle, min, max)
	if angle < 90 or angle > 270 then
		if angle > 180 then
			angle = angle - 360
		end
		if max > 180 then
			max = max - 360
		end
		if min > 180 then
			min = min - 360
		end
	end
	angle = Mathf.Clamp(angle, min, max)
	if angle < 0 then
		angle = angle + 360
	end
	return angle
end

local timeOut = {};
---如果不行返回下次可以的时间
---@param timerName string @判断的Key，与SetTimeOut的timerName一致
---@param interval number @检查间隔的时长  秒为单位
function IsTimeOut(timerName, interval)
	if timeOut[timerName] then
		if GetCurTime() > timeOut[timerName] + interval then
			SetTimeOut(timerName)
			return true
		end
	else
		SetTimeOut(timerName)
		return true
	end
	return false, timeOut[timerName] + interval;
end

---@return nil @直接设置时间
---@param timerName string @唯一的key值，用来区分TimeOut
function SetTimeOut(timerName)
	timeOut[timerName] = GetCurTime();
end

-----------------------------------这里是回调函数的封装以及操作，主要用于给Character的自动寻路处理使用--------------
---@return CallBackVO @返回一个回调VO
function GetCallBackVO(caller, func, param)
	local vo  = {}
	vo.caller = caller
	vo.func   = func
	vo.param  = param
	return vo
end
---@return object @通过回调VO 调用一个回调函数，参数采用这个VO内的参数
function InvokeCallBackVO(vo)
	if not vo or not vo.caller or not vo.func then
		return
	end
	local result = nil
	if vo.param then
		if type(vo.param) == "table" then
			result = vo.func(vo.caller, table.unpack(vo.param))
		else
			result = vo.func(vo.caller)
		end
	else
		result = vo.func(vo.caller)
	end
	return result
end
---@return object @通过回调VO 调用一个回调函数,参数采用传进来的参数
function ExecCallBackVO(vo, ...)
	if not vo or not vo.caller or not vo.func then
		return
	end
	local result = nil
	local param  = { ... }
	if param and #param > 0 then
		result = vo.func(vo.caller, table.unpack(param))
	else
		result = vo.func(vo.caller)
	end
	return result
end
---销毁一个回调VO
function DestroyCallBackVO(vo)
	if not vo then
		return
	end
	vo.caller = nil
	vo.func   = nil
	vo.param  = nil
end
----------------------------------时间相关-----------------------------------------------------
--将一天中的时间字符串转换成秒 (时：分：秒)
_G.CTimeFormat = {}
_G.SECOND      = 1
_G.S2M         = 60
_G.MINUTE      = S2M * SECOND
_G.M2H         = 60
_G.HOUR        = M2H * MINUTE
_G.H2D         = 24
_G.DAY         = H2D * HOUR

function CTimeFormat:daystr2sec(str)
	local t   = split(str, ":");
	local sec = 0;
	sec       = sec + tonumber(t[1]) * 3600;
	sec       = sec + tonumber(t[2]) * 60;
	if t[3] then
		sec = sec + tonumber(t[3]);
	end
	return sec;
end

function CTimeFormat:sec1format(secs)
	local sec = math.floor(secs % 60)
	local min = math.floor(secs / 60)
	if min < 10 then
		min = '0' .. min
	end
	if sec < 10 then
		sec = '0' .. sec
	end
	return min .. ':' .. sec
end

--获得格式化的 时：分：秒
function CTimeFormat:sec2format(secs)
	local sec  = math.floor(secs % 60)
	local min  = math.floor(secs / 60) % 60
	local hour = math.floor(secs / 3600) % 24
	return hour, min, sec
end

function CTimeFormat:sec3format(secs)
	local sec  = math.floor(secs % 60)
	local min  = math.floor(secs / 60) % 60
	local hour = math.floor(secs / 3600) % 24
	if hour < 10 then
		hour = '0' .. hour
	end
	if min < 10 then
		min = '0' .. min
	end
	if sec < 10 then
		sec = '0' .. sec
	end
	return hour .. ':' .. min .. ':' .. sec
end

function CTimeFormat:sec4format(secs)
	local sec  = math.floor(secs % 60)
	local min  = math.floor(secs / 60) % 60
	local hour = math.floor(secs / 3600) % 24
	local day  = math.floor(secs / (3600 * 24))
	if hour < 10 then
		hour = '0' .. hour
	end
	if min < 10 then
		min = '0' .. min
	end
	if sec < 10 then
		sec = '0' .. sec
	end
	return day, hour, min, sec
end

function CTimeFormat:sec5format(secs)
	local sec  = math.floor(secs % 60)
	local min  = math.floor(secs / 60) % 60
	local hour = math.floor(secs / 3600) % 24
	local day  = math.floor(secs / (3600 * 24))
	return day, hour, min, sec
end

function CTimeFormat:sec6format(secs)
	local sec  = math.floor(secs % 60)
	local min  = math.floor(secs / 60) % 60
	local hour = math.floor(secs / 3600) % 24
	local day  = math.floor(secs / (3600 * 24))
	if day >= 1 then
		hour = hour + 24 * day
	end
	if hour < 10 then
		hour = '0' .. hour
	end
	if min < 10 then
		min = '0' .. min
	end
	if sec < 10 then
		sec = '0' .. sec
	end
	return hour, min, sec
end

--@desc 时间转换
--@return xx:xx:xx 时分秒
function CTimeFormat:sec7format(secs)
	local sec  = math.floor(secs % 60)
	local min  = math.floor(secs / 60) % 60
	local hour = math.floor(secs / 3600)
	-- if hour < 10 then
	-- 	hour = '0' .. hour
	-- end
	-- if min < 10 then
	-- 	min = '0' .. min
	-- end
	-- if sec < 10 then
	-- 	sec = '0' .. sec
	-- end

	return string.format("%02d:%02d:%02d", hour, min, sec)
end

function CTimeFormat:sec8format(sec)
	local y, m, d, h, min, sec = CTimeFormat:todate(sec, true, false)
	if h < 10 then
		h = '0' .. h
	end
	if min < 10 then
		min = '0' .. min
	end
	if sec < 10 then
		sec = '0' .. sec
	end
	return y .. '-' .. m .. '-' .. d .. ' _' .. h .. '-' .. min .. '-' .. sec
end
--获得格式化的 X小时X分X秒
function CTimeFormat:sec2formatChinese(secs)
	local sec  = math.floor(secs % 60)
	local min  = math.floor(secs / 60) % 60
	local hour = math.floor(secs / 3600) % 24
	return string.format("%s%s%s", hour > 0 and hour .. _T "小时" or "", min > 0 and min .. _T "分" or "", sec > 0 and sec .. _T "秒" or "")
end
--蔡勒（Zeller）公式
_G.CalcWeek = function(sec)
	local y, m, d = CTimeFormat:todate(sec, true, false)
	local century = tonumber(string.sub(y, 1, 2))
	local year    = tonumber(string.sub(y, -2))
	m             = m >= 3 and m or m + 12
	local week    = year + math.floor(year / 4) + math.floor(century / 4) - 2 * century + math.floor(26 * (m + 1) / 10) + d - 1
	week          = week % 7
	return week
end

-- quick为true则代表时间加速
local function today(sec, quick)
	local day, hour, minute, second
	day      = quick and toint(sec / DAY) or toint(sec / 24 / 60 / 60)
	local ds = quick and day * DAY or day * 24 * 60 * 60
	hour     = quick and toint((sec - ds) / HOUR) or toint((sec - ds) / 60 / 60)
	local hs = quick and hour * HOUR or hour * 60 * 60
	minute   = quick and toint((sec - ds - hs) / MINUTE) or toint((sec - ds - hs) / 60)
	local ms = quick and minute * MINUTE or minute * 60
	second   = sec - ds - hs - ms
	return day, hour, minute, second
end

local function leapyear(year)
	local f1, f2, f3
	f1 = ((year % 4) == 0)
	f2 = ((year % 100) == 0)
	f3 = ((year % 400) == 0)
	if (f1 and not f2) or (f2 and f3) then
		return true
	else
		return false
	end
end

local function month2day(year, month, day)
	local md = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 }
	if leapyear(year) then
		md[3] = md[3] + 1
	end
	local d = 0
	for i = 1, month do
		d = d + md[i]
	end
	return d + day
end

local function toyear(startyear, day)
	local y = startyear
	local d = day
	while true do
		if leapyear(y) then
			if d <= 366 then
				break
			end
			d = d - 366
			y = y + 1
		else
			if d <= 365 then
				break
			end
			d = d - 365
			y = y + 1
		end
	end
	return y, d
end

local function day2month(year, day)
	local md = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 }
	if leapyear(year) then
		md[2] = md[2] + 1
	end
	local m, d = 1, 0
	while true do
		if day <= md[m] then
			d = day
			break
		end
		day = day - md[m]
		m   = m + 1
	end
	return m, d
end

-- quick为true则代表时间加速
local function diffdate(startdate, sec, quick)
	local d, h, m, s = today(sec, quick)
	local year, month, day, hour, minute, second
	local carry      = 0
	second           = startdate.second + s
	if second >= (quick and S2M or 60) then
		carry  = 1
		second = second - (quick and S2M or 60)
	end
	minute = startdate.minute + carry + m
	if minute >= (quick and M2H or 60) then
		carry  = 1
		minute = minute - (quick and M2H or 60)
	else
		carry = 0
	end
	hour = startdate.hour + carry + h
	if hour >= (quick and H2D or 24) then
		carry = 1
		hour  = hour - (quick and H2D or 24)
	else
		carry = 0
	end
	day        = month2day(startdate.year, startdate.month, startdate.day) + carry + d
	year, day  = toyear(startdate.year, day)
	month, day = day2month(year, day)
	return year, month, day, hour, minute, second
end

-- 832
function CTimeFormat:todate(sec, fmt, quick)
	--时区问题，直接加8小时
	sec             = sec + 8 * 3600;
	local startdate = { year = 1970, month = 1, day = 1, hour = 0, minute = 0, second = 0 }
	if type(fmt) == 'boolean' and fmt == true then
		return diffdate(startdate, sec, quick)
	elseif type(fmt) == 'string' then
		return string.format(fmt, diffdate(startdate, sec, quick))
	end
	return string.format('%04d-%02d-%02d    %02d:%02d:%02d', diffdate(startdate, sec, quick))
end

function CTimeFormat:GetSecAsFormat(sec)
	local y, m, d, h, min, sec = CTimeFormat:todate(sec, true, false)
	if h < 10 then
		h = '0' .. h
	end
	if min < 10 then
		min = '0' .. min
	end
	if sec < 10 then
		sec = '0' .. sec
	end
	return y .. '-' .. m .. '-' .. d .. ' ' .. h .. ':' .. min .. ':' .. sec
end

function hack()
	package.loaded['core/utils/debug'] = nil
	require 'core/utils/debug'
end

------------------------------------------------------------------------------------------------

function CheckWords(content)
	if not IsCheckWords then
		return true
	end
	--for i, v in ipairs(_G.Words) do
	--	if v ~= "" and string.find(content, v) then
	--		return false
	--	end
	--end
	return true
end

---SplitTableToString 将Table拆分成字符串
---@param list table
function SplitTableToString(list)
	if not list then
		return
	end
	if type(list) ~= 'table' then
		return
	end
	local result = {}
	local str
	for i, v in ipairs(list) do
		str = v.id
		if v.num then
			str = str .. "," .. v.num
		end
		if v.flag then
			str = str .. "," .. v.flag
		end
		table.insert(result, str)
	end
	return table.concat(result, "#")
end

---转换等级，变为觉醒的样式
_G._L = function(level)
	if not level then
		return ""
	end
	local len       = #t_juexing
	local lastIndex = 0
	for i = 1, len do
		if level < t_juexing[i].lv_min then
			break
		end
		lastIndex = i
	end
	if lastIndex > 0 then
		local cfg = t_juexing[lastIndex]
		return cfg.id .. _T "觉" .. (level - cfg.lv_min + 1), cfg.id
	end
	return level
end

function Multiply(p1, p2, p)
	return ((p1.x - p.x) * (p2.z - p.z) - (p2.x - p.x) * (p1.z - p.z))
end

function IsContain(p1, p2, p3, p4, p)
	if (Multiply(p, p1, p2) * Multiply(p, p4, p3) <= 0
			and Multiply(p, p4, p1) * Multiply(p, p3, p2) <= 0) then
		return true
	end
	return false
end

function GetPositionInfo(positionID)
	local cfg = t_position[tonumber(positionID)]
	if not cfg then return end
	local p = split(cfg.pos, ",")
	if not p then return end
	if #p <= 0 then return end
	return tonumber(p[1]), tonumber(p[2]), tonumber(p[3])
end

function GetPointInCircle(angle, radius, center)
	local x = center.x + radius * math.cos(angle * math.pi / 180)
	local z = center.z + radius * math.sin(angle * math.pi / 180)
	return x, z
end