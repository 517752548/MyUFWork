_G.Notification = class()

function Notification:ctor()
    self.listenMap = {}
end

function Notification:Add(name, obj, func)
    if not self.listenMap[name] then
        self.listenMap[name] = {}
    end
    for k, vo in pairs(self.listenMap[name]) do
        if vo.obj == obj and vo.func == func then
            logWarning('不能重复注册通知' .. name)
            return
        end
	end
	local vo = {obj = obj, func = func}
	table.insert(self.listenMap[name], vo)
	return true
end

function Notification:Remove(name, obj, func)
	if not self.listenMap[name] then
		--logWarning('无法找到要移除的通知' .. name)
		return
	end
	for i=#self.listenMap[name], 1, -1 do
		local vo = self.listenMap[name][i]
		if vo.obj==obj and vo.func==func then
			table.remove(self.listenMap[name], i)
			return true
		end
	end
	--logWarning('无法找到要移除的通知的对应方法' .. name)
end

function Notification:SendNotification(name, body)
	if not self.listenMap[name] then
		--logWarning('无法找到要派发的通知的注册' .. name);
		return;
	end
	for k,vo in pairs(self.listenMap[name]) do
		if vo and vo.func and vo.obj then
			vo.func(vo.obj, body)
		end
	end
end
