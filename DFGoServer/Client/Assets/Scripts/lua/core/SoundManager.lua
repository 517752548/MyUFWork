---@class SoundManager @声音播放管理类
_G.SoundManager          = {}

SoundManager.sfxPlayList = {}
function SoundManager:Init()
	self.currBackSfxPlayerFile     = nil
	self.currbackSfxPlayerABPath   = nil
	self.backSfxPlayer             = _G.GameManager:AddComponent(typeof(AudioSource))    --背景音播放器
	self.backSfxPlayer.playOnAwake = false
	self:SetMusicVolume(BasicSettingsConfig.musicVolume)
	TimerManager:AddTimer(function()
		self:Update()
	end, 0, 0)
end

function SoundManager:Update()
	for i, v in pairs(self.sfxPlayList) do
		v:Update()
	end
end

function SoundManager:SetMusicVolume(value)
	if self.backSfxPlayer then
		value                     = Mathf.Clamp01(value)
		self.backSfxPlayer.volume = value
	end
end

function SoundManager:SetSFXVolume(value)
	for i, v in pairs(self.sfxPlayList) do
		if v then
			v:SetAudioSourceVolume(value)
		end
	end
end

function SoundManager:GetSFXPlayer(soundFile)
	local sp = nil
	--先根据已经有的player中是否有符合直接使用条件的
	if soundFile and soundFile ~= '' then
		for i, v in pairs(self.sfxPlayList) do
			if v:Exclusive(soundFile) then
				sp = v
				break
			end
		end
	end
	if not sp then
		for i, v in pairs(self.sfxPlayList) do
			if v:Reusable() then
				sp = v
				break
			end
		end
	end
	if not sp then
		local source = _G.GameManager:AddComponent(typeof(AudioSource))
		sp           = SoundPlayer.New()
		sp:SetAudioSource(source)
		sp:SetAudioSourceVolume(BasicSettingsConfig.sfxVolume)
		table.insert(self.sfxPlayList, sp)
	end
	return sp
end

--播放背景音
function SoundManager:PlayBackSFX(soundID)
	do return end
	local sfxCfg = t_music[soundID]
	if not sfxCfg then
		logError("not sfxCfg by" .. soundID)
		return nil
	end

	local loopType             = sfxCfg.loop == 1
	self.currBackSfxPlayerFile = sfxCfg.sound_file
	local abPath               = ResUtil:GetAudioBGMPath(sfxCfg.sound_file)
	ResManager:LoadAudioClipAsync(abPath, function(audioclip)
		if self.currBackSfxPlayerFile == sfxCfg.sound_file then
			self.backSfxPlayer.clip = audioclip
			self.backSfxPlayer.loop = loopType
			self.backSfxPlayer:Play()
			self.currbackSfxPlayerABPath = abPath
			self.currBackSfxPlayerFile   = nil
		end
	end)
end

--停止播放背景音乐
function SoundManager:StopBackSFX()
	if self.currbackSfxPlayerABPath then
		ResManager:UnloadAssetBundle(self.currbackSfxPlayerABPath)
		self.currbackSfxPlayerABPath = nil
	end
	self.currBackSfxPlayerFile = nil
	if self.backSfxPlayer then
		self.backSfxPlayer:Stop()
		self.backSfxPlayer.clip = nil
	end
end

---@return SoundPlayer @当recyclable（可回收）为false的时候，才会返回这个SoundPlayer
---@param soundID number @音效配表ID
---@param interruptable boolean @是否可以打断，如果有下一个音效要播放，那么可以打断的会中断去提供使用，默认值true,这个值被手动设置为false了，在播放完成后会自动变为true，意思就是这个音效总是能完整的播放完一边而不被打断,即使是你手动调用Stop()方法也不行
---@param recyclable boolean @是否会重复利用，设置为false的情况下，SoundManger不会再次利用这个，可以在自己的代码处存放这个实例 重复播放。默认值true
---@param globalExclusive boolean @是否是全局专属，为true的时候等于是全局缓存了一个要播放的声音，以后其他地方再次播放这个声音的时候会打断他然后播放,默认值为true
function SoundManager:PlaySFX(soundID, interruptable, recyclable, globalExclusive)
	do return end
	if interruptable == nil then interruptable = true end
	if recyclable == nil then recyclable = true end
	globalExclusive = globalExclusive or false
	if not soundID then
		return
	end
	local sfxCfg = t_music[soundID]
	if not sfxCfg then
		--logError("not sfxCfg by " .. soundID)
		return
	end
	local loopType = sfxCfg.loop == 1
	local sp       = self:GetSFXPlayer(sfxCfg.sound_file)
	sp:SetSoundID(soundID)
	sp:InitAndPlay(sfxCfg.sound_file, loopType, interruptable, recyclable, globalExclusive)
	if not recyclable then
		--不可回收的，需要开发者保存Player的情况下才返回
		return sp
	end
end

function SoundManager:PlaySFXExclusive(soundID)
	self:PlaySFX(soundID, true, false, true)
end

function SoundManager:StopAllSFX()
	for i, v in pairs(self.sfxPlayList) do
		if v then
			v:Stop()
		end
	end
end

function SoundManager:StopSFX(soundID)
	for i, v in pairs(self.sfxPlayList) do
		if v and v:GetSoundID() == soundID then
			v:Stop()
			break
		end
	end
end

---@class SoundPlayer @单个声音播放器
_G.SoundPlayer = class()

function SoundPlayer:ctor()
	self.assetBundlePath = nil
	self.soundID         = nil
	self.soundFile       = ""
	self.audioSource     = nil
	self.interruptable   = false
	self.startTime       = 0
	self.duration        = 0
	self.isPlaying       = false
	self.isStop          = false
	self.isLoop          = false
	self.recyclable      = true
	self.globalExclusive = false
end

function SoundPlayer:SetSoundID(value)
	self.soundID = value
end

function SoundPlayer:GetSoundID()
	return self.soundID
end

function SoundPlayer:GetSoundFile()
	return self.soundFile
end

function SoundPlayer:SetAudioSource(source)
	source.playOnAwake = false
	self.audioSource   = source
end

function SoundPlayer:SetAudioSourceVolume(value)
	if self.audioSource then
		value                   = Mathf.Clamp01(value)
		self.audioSource.volume = value
	end
end

--专属使用的，会根据soundFile的值来判断，直接播放的时候会拿来使用，全局专属播放某一个声音使用
function SoundPlayer:Exclusive(soundFile)
	return self.soundFile == soundFile and not self.recyclable and self.globalExclusive
end

--可否重复利用，当这个播放器播放完成后，拿来给其他声音使用
function SoundPlayer:Reusable()
	return self.isStop and self.interruptable and self.recyclable
end

function SoundPlayer:InitAndPlay(soundFile, loop, interruptable, recyclable, globalExclusive)
	if not self.audioSource then return end
	self.isStop    = false
	self.isPlaying = false
	local play_one = function()
		self.soundFile        = soundFile
		self.audioSource.loop = loop
		self.interruptable    = interruptable
		self.duration         = self.audioSource.clip.length
		self.isLoop           = loop
		self.recyclable       = recyclable
		self.globalExclusive  = globalExclusive
		self:Play()
	end
	if self.soundFile ~= soundFile then
		if self.assetBundlePath then
			ResManager:UnloadAssetBundle(self.assetBundlePath)
			self.assetBundlePath = nil
		end
		local abPath = ResUtil:GetAudioSFXPath(soundFile)
		ResManager:LoadAudioClipAsync(abPath, function(audioclip)
			if self.isStop then return end
			self.assetBundlePath  = abPath
			self.audioSource.clip = audioclip
			play_one()
		end)
	else
		play_one()
	end
end

function SoundPlayer:Play()
	if not self.interruptable and self.isPlaying then
		return
	end
	self.isPlaying = true
	self.isStop    = false
	self.startTime = GetCurTime()
	self.audioSource:PlayScheduled(0)
end

function SoundPlayer:Update()
	if self.isStop then return end
	if not self.isPlaying then return end
	if not self.isLoop and (GetCurTime() - self.startTime) >= self.duration then
		self.interruptable = true
		self:Stop()
	end
end

function SoundPlayer:Stop(isFade)
	self.isPlaying = false
	self.isStop    = true
	if isFade then
		DOTween.To(function(x)
			if self.audioSource then
				self:SetAudioSourceVolume(x)
			end
		end, self.audioSource.volume, 0, 0.5)
	else
		if self.audioSource then
			self.audioSource:Stop()
		end
	end
end

function SoundPlayer:Destroy()
	self:Stop()
	self.interruptable = true
	self.recyclable    = true
end