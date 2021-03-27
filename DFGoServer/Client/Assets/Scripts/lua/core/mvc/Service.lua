_G.Service = class(BaseObject)

function Service:ctor()
	self.facade = nil
end

--subclass override
function Service:Create()
	--注册对应的消息
end

--subclass override 当新玩家进入游戏的时候
function Service:OnCreateStorage()

end

--subclass override
function Service:SyncStorageToModel() end
--subclass override
function Service:OnEnterGame() end

function Service:SendNotification(name, body)
	self.facade:SendNotification(name, body)
end