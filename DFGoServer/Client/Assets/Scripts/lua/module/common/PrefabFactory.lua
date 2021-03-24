---@class PrefabFactory
_G.PrefabFactory = {}

function PrefabFactory:LoadGameObject(abPath, onComplete, isAsync)
	local poolGO = ObjPoolManager:Get(abPath)
	if poolGO then
		if onComplete then
			onComplete(poolGO)
		end
	else
		if isAsync then
			ResManager:LoadPrefabAsync(abPath, function(gameObject)
				if not gameObject then
					logError("PuzzleCellAvatar加载Prefab发生错误:" .. abPath)
					return
				end
				local asyncGO = newObject(gameObject)
				if onComplete then
					onComplete(asyncGO)
				end
			end)
		else
			local go    = ResManager:LoadPrefab(abPath)
			local newGO = newObject(go)
			if onComplete then
				onComplete(newGO)
			end
		end
	end
end

function PrefabFactory:UnloadGameObject(abPath, gameObject, isToPool)
	if isToPool then
		ObjPoolManager:Release(abPath, gameObject)
	else
		destroy(gameObjectF)
	end
end