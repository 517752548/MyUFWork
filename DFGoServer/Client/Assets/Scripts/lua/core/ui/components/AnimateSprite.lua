---@class AnimateSprite
_G.AnimateSprite = class(UGUIObject)

function AnimateSprite:ctor(transform)
	self.animateSprite = nil
	self.atlasPath     = nil
end

function AnimateSprite:_InitAnimateSpriteComponent()
	if not self.transform then return end
	if not self.animateSprite then
		self.animateSprite = self.transform:GetComponent(typeof(Gear.AnimateSprite))
	end
end

---@return nil @设置是否自动设置宽高，设置为true的话将自动根据第一帧的Sprite的宽高来设置播放的宽高，设置为false将根据RectTransform的SizeDelta来设置，也就是编辑器的width和height，默认值为true
---@param boolean @是否自动设置宽高
function AnimateSprite:SetAutoSize(value)
	self:_InitAnimateSpriteComponent()
	if not self.animateSprite then return end
	self.animateSprite.autoSize = value
end

---@return nil @设置显示大小
---@param number width @宽度
---@param number height @高度
function AnimateSprite:SetSizeDelta(width, height)
	if not width or not height then return end
	if width <= 0 then return end
	if height <= 0 then return end
	self:SetAutoSize(false)
	AnimateSprite.superclass.SetSizeDelta(self, width, height)
end

function AnimateSprite:SetFrameRate(value)
	self:_InitAnimateSpriteComponent()
	if not self.animateSprite then return end
	self.animateSprite.frameRate = value
end

function AnimateSprite:SetInterval(value)
	self:_InitAnimateSpriteComponent()
	if not self.animateSprite then return end
	self.animateSprite.interval = value
end

local BENCH_WIDTH  = 80
local BENCH_HEIGHT = 80
function AnimateSprite:LoadAndPlay(atlasPath, isLoop, widthWithBench, heightWithBench)
	self:_InitAnimateSpriteComponent()
	if not self.animateSprite then return end
	if not self.atlasPath or self.atlasPath ~= atlasPath then
		AtlasManager:LoadAtlasAsync(atlasPath, function(atlasInfo)
			if not self.animateSprite then return end
			if tolua.isnull(self.animateSprite) then return end
			self.atlasPath               = atlasPath
			self.animateSprite.atlasInfo = atlasInfo
			--等比缩小
			if widthWithBench and heightWithBench and widthWithBench > 0 and heightWithBench > 0 then
				local width  = widthWithBench / BENCH_WIDTH * atlasInfo:GetSprites()[0].rect.width
				local height = heightWithBench / BENCH_HEIGHT * atlasInfo:GetSprites()[0].rect.height
				self:SetSizeDelta(width, height)
			end
			self:Play(isLoop)
		end)
	else
		self:Play(isLoop)
	end
end

function AnimateSprite:Play(isLoop)
	self:_InitAnimateSpriteComponent()
	if not self.animateSprite then return end
	if isLoop == nil then isLoop = true end
	self.animateSprite.loop = isLoop
	self.animateSprite:Play()
end

function AnimateSprite:Stop()
	self:_InitAnimateSpriteComponent()
	if not self.animateSprite then return end
	self.animateSprite:Stop()
end

function AnimateSprite:Destroy()
	self:Stop()
	self.animateSprite = nil
	self.atlasPath     = nil
	AnimateSprite.superclass.Destroy(self)
end
