require 'core/Include'
require 'config/Include'
require 'bootstrap/GameApp'
require 'stage/Include'
require 'sdk/Include'
require 'module/Include'

_G.GameManager       = nil
_G.applicationKernel = nil
_G.Publisher         = nil
function GameMain()
	if IsRunInEditor then
		package.cpath = package.cpath .. ';C:/Users/Admin/AppData/Roaming/JetBrains/Rider2020.2/plugins/intellij-emmylua/classes/debugger/emmy/windows/x64/?.dll'
		local dbg = require('emmy_core')
		dbg.tcpListen('localhost', 9967)


		require 'bootstrap/Config'
	elseif IsReleaseWindows then
		require 'bootstrap/ConfigWindows'
	elseif IsReleaseAndroid then
		require 'bootstrap/ConfigAndroid'
	elseif IsReleaseIOS then
		require 'bootstrap/ConfigIOS'
	end

	if not _G.IsShowLog then
		_G.print      = function() end
		_G.log        = function() end
		_G.logWarning = function() end
		_G.logError   = function() end
	end
	_G.GameManager       = find("GameManager")
	_G.applicationKernel = _G.GameManager:GetComponent("ApplicationKernel")

	math.randomseed(os.time())
	GameApp:StartUp()
	--如果启动的场景是动画事件编辑器场景，那么不执行，这个场景是作为编辑器使用的，因为要调用到游戏中lua的代码，但不执行游戏
	if SceneManager.GetActiveScene().name == "AnimationEventEditorScene" or
			SceneManager.GetActiveScene().name == "NPCDialogViewEditor" or
			SceneManager.GetActiveScene().name == "UIDrawModelEditor" or
			SceneManager.GetActiveScene().name == "SkipMotionCurveEditor" then
		return
	end

	OnEnterGame()
end

function OnEnterGame()
	GameApp:RegisterController()

	if _G.applicationKernel.testScene ~= "" then
		require 'bootstrap/TestMain'
		TestMain(_G.applicationKernel)
		return
	end
	PreloadAssets()
	LoginController:InitLogin()
end

---@return nil @预加载一些常用的东西，避免出现同步和异步同时加载，unity引擎报出Same loaded xxxx的异常
function PreloadAssets()
	ResManager:LoadAsset("UI/UIAnimation/Button.controller")
	ResManager:LoadAsset("UI/UIMaterial/UIDefaultGray.mat")
	ResManager:LoadAsset("UI/UIMaterial/UIRenderTexture.mat")
	ResManager:LoadAsset("Font/deffont.TTF")
end

