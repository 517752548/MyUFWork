_G.ScnManager              = {}

ScnManager.curSceneName    = ""
ScnManager.sceneLoader     = nil
ScnManager.curScene        = nil
ScnManager.assetBundlePath = nil
ScnManager.isLoading       = false
function ScnManager:LoadSceneAsync(name, loadedCallBack)
	if not name or name == '' then
		return
	end
	local load_new_scene_func = function()
		if self.sceneLoader then
			self.sceneLoader:Dispose()
			self.sceneLoader = nil
		end
		if not self.sceneLoader then
			self.sceneLoader = GSceneLoader.New()
		end
		self.sceneLoader.SceneName      = name
		self.sceneLoader.OnLoadProgress = function(loader)
			log("ScnManager progress:" .. loader.Progress)
			local loadingPanel = UIManager:GetUI(UIPanelName.LoadingPanel)
			if loadingPanel then
				loadingPanel:SetProgress(loader.Progress)
			end
		end

		self.sceneLoader.OnLoadComplete = function()
			SettingsManager:ApplyAUPConfig(AUPNormalConfig)
			UnityEngine.Application.backgroundLoadingPriority = UnityEngine.ThreadPriority.Normal
			Util.ClearMemory()
			self.curSceneName = name
			self.curScene     = SceneManager.GetSceneByName(name)
			log('ScnManager loaded complete:' .. self.curSceneName)
			if loadedCallBack then
				loadedCallBack()
				loadedCallBack = nil
			end
			ScnManager.isLoading = false
			self.sceneLoader     = nil
		end
		TimerManager:AddTimer(function()
			self.sceneLoader:Load()
		end, 0.001, 1)
		SettingsManager:ApplyAUPConfig(AUPLoadingConfig)
		UnityEngine.Application.backgroundLoadingPriority = UnityEngine.ThreadPriority.High
	end

	--if self.curSceneName and self.curSceneName ~= "" then
	--    self:UnloadSceneAsync(self.curSceneName, function()
	--        load_new_scene_func()
	--    end)
	--else
	--if self.assetBundlePath then
	--	ResManager:UnloadAssetBundle(self.assetBundlePath)
	--	self.assetBundlePath = nil
	--end
	--显示加载界面
	UIManager:OpenUI(UIPanelName.LoadingPanel)
	if name == self.curSceneName then
		if loadedCallBack then
			loadedCallBack()
			loadedCallBack = nil
		end
		return
	end
	ScnManager.isLoading = true
	if IsRunInEditor then
		load_new_scene_func()
	else
		local abPath = "Scenes/" .. name .. ".unity"
		ResManager:LoadAssetBundleAsync(ResManager:GetAssetBundleNameByAssetPath(abPath), function(obj)
			self.assetBundlePath = abPath
			load_new_scene_func()
		end)
	end
	--end
end

function ScnManager:UnloadSceneAsync(sceneName, unloadedCallBack)
	SceneManager.sceneUnloaded = SceneManager.sceneUnloaded + function()
		if unloadedCallBack then
			unloadedCallBack()
			unloadedCallBack           = nil
			SceneManager.sceneUnloaded = nil
		end
	end
	SceneManager.UnloadSceneAsync(sceneName)
end
