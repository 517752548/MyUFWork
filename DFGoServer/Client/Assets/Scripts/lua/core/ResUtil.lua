_G.ResUtil = {}

function ResUtil:IsUITextureAssetPath(assetPath)
	return string.find(assetPath, "UI/Texture")
end

function ResUtil:IsPuzzleTextureAssetPath(assetPath)
	return string.find(assetPath, "Puzzle/Texture")
end

function ResUtil:SplitUITextureAssetPath(assetPath)
	local paths      = split(assetPath, "/")
	local atlasPath  = ""
	local spriteName = ""
	if #paths > 1 then
		for i = 1, #paths - 1 do
			if i == 1 then
				atlasPath = atlasPath .. string.lower(paths[i])
			else
				atlasPath = atlasPath .. "_" .. string.lower(paths[i])
			end
		end
		spriteName = paths[#paths]
		return true, atlasPath, spriteName
	end
	return false, nil, nil
end

function ResUtil:SplitPuzzleTextureAssetPath(assetPath)
	local paths      = split(assetPath, "/")
	local atlasPath  = ""
	local spriteName = ""
	if #paths > 1 then
		for i = 1, #paths - 1 do
			if i == 1 then
				atlasPath = atlasPath .. string.lower(paths[i])
			else
				atlasPath = atlasPath .. "_" .. string.lower(paths[i])
			end
		end
		spriteName = paths[#paths]
		return true, atlasPath, spriteName
	end
	return false, nil, nil
end

function ResUtil:GetAudioSFXPath(name)
	return "Audio/sfx/" .. name
end

function ResUtil:GetAudioBGMPath(name)
	return "Audio/bgm/" .. name
end

function ResUtil:GetUIPath(name)
	return "UI/" .. name .. ".prefab"
end

function ResUtil:GetFontContentPath()
	return "Font/deffont.TTF"
end

function ResUtil:GetUIDefaultGrayMaterial()
	return "UI/UIMaterial/UIDefaultGray.mat"
end
--------------------------------------------------------
function ResUtil:GetEffectPath(name)
	return "FX/" .. name .. ".prefab"
end

function ResUtil:GetBuffEffectPath(name)
	return "BUFF/" .. name
end

function ResUtil:GetPuzzleTexturePath(name)
	return "Puzzle/Texture/" .. name .. ".png"
end

function ResUtil:GetPuzzlePrefabPath(name)
	return "Puzzle/" .. name .. ".prefab"
end

function ResUtil:GetBlockBrokenFX()
	return "FX_Block_Broken"
end