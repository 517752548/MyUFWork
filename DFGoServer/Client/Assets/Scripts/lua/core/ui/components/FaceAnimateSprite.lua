---@class FaceAnimateSprite
_G.FaceAnimateSprite = class(AnimateSprite)

function FaceAnimateSprite:ctor(transform)
	self.animateSprite = nil
end

function FaceAnimateSprite:_InitFaceAnimateSpriteComponent()
	if not self.transform then return end
	if not self.animateSprite then
		self.animateSprite = self.transform:GetComponent(typeof(Gear.FaceAnimateSprite))
	end
end

function FaceAnimateSprite:LoadAndPlay(atlasPath, isLoop, widthWithBench, heightWithBench)
	self:_InitFaceAnimateSpriteComponent()
	if not self.animateSprite then return end
	if not self.atlasPath or self.atlasPath ~= atlasPath then
		AtlasManager:LoadAtlasAsync(atlasPath, function(atlasInfo)
			if not self.animateSprite then return end
			if tolua.isnull(self.animateSprite) then return end
			self.atlasPath               = atlasPath
			self.animateSprite.atlasInfo = atlasInfo
			if not self.animateSprite.frameData then
				local fd = ResManager:LoadScriptableObject(AnimateFrameData.SCRIPTABLE_PATH)
				if fd then
					self.animateSprite.frameData = fd
				end
			end
			self:Play(isLoop)
		end)
	else
		self:Play(isLoop)
	end
end

function FaceAnimateSprite:Play(isLoop)
	self:_InitFaceAnimateSpriteComponent()
	if not self.animateSprite then return end
	if isLoop == nil then isLoop = true end
	self.animateSprite.loop = isLoop
	self.animateSprite:Play()
end

function FaceAnimateSprite:Stop()
	self:_InitFaceAnimateSpriteComponent()
	if not self.animateSprite then return end
	self.animateSprite:Stop()
end

function FaceAnimateSprite:Destroy()
	self:Stop()
	self.animateSprite = nil
	self.atlasPath     = nil
	FaceAnimateSprite.superclass.Destroy(self)
end
