function TestMain(applicationKernel)
	GameApp.testMode = true
	local testScene  = applicationKernel.testScene
	local mapCFG     = nil
	for i, v in pairs(t_map) do
		if v.sceneFile == testScene then
			mapCFG = v
			break ;
		end
	end
	if not mapCFG then return end
	local birthPos
	table.foreach(MapPoint[mapCFG.id].birth, function(i, v)
		if v.id  == 1 then
			birthPos = v
		end
	end)
	if not birthPos then return end
	SceneController.currMapId = mapCFG.id
	ScnManager:LoadSceneAsync(testScene, function()
		UIManager:HideUI(UIPanelName.LoadingPanel)
		local queue = FunctionQueue.New()
		queue:Add(function()
			SceneController:InitMainCamera()
			queue:ExecuteNext()
		end)
		queue:Add(function()
			local info                  = {}
			info.guid                   = "0"
			info.roleName               = "测试主角"
			info.prof                   = 1
			info.speed                  = 5
			info.dir                    = 0
			info.posX                   = birthPos.x
			info.posZ                   = birthPos.y
			info.level                  = 1
			MainPlayerModel.sMeShowInfo = info
			MainPlayerController:InitMainPlayer(info, function()
				queue:ExecuteNext()
			end)
		end)
		queue:Add(function()
			SceneController:UpdateMainCamera()
			queue:ExecuteNext()
		end)
		queue:Execute()

	end)

end