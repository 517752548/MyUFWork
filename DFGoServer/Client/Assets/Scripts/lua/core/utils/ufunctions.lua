--查找对象--
function find(str)
	return GameObject.Find(str)
end

--返回gameobject
function findChild(transform, str)
	return Util.Child(transform, str)
end

--返回的是transform
function findDeep(transform, str)
	return Util.FindChildDeep(transform, str)
end

function setChildrenActive(transform, active, ignoreTSF)
	Util.SetChildrenActive(transform, active, ignoreTSF)
end

--设置层级，包括子对象
function setLayerAndChildren(transform, layerIndex)
	Util.SetLayerAndChildren(transform, layerIndex)
end

--设置render组件的渲染层级
function setRenderOrder(transform, orderIdx)
	Util.SetRenderOrder(transform, orderIdx)
end

function setRenderOrderWithParent(tsf)
	Util.SetRenderOrderWithParent(tsf)
end

--获取父级的order
function getParentOrder(transform)
	return Util.GetParentOrder(transform)
end

--设置order
function setOrder(transform, order)
	Util.SetOrder(transform, order)
end



--共享骨骼，跟网上最常见的那个函数一样，这里就是为了调用C#
function shareSkeletonInstance(targetSkin, tempSkin, targetGameObject)
	Util.ShareSkeletonInstance(targetSkin, tempSkin, targetGameObject)
end
--获取一个UI对象的实际尺寸，如果是深度查找，那么就找出最大的实际尺寸 返回一个Vector2
function getRectTransformPreferredSize(rect, isDeep)
	return Util.GetRectTransformPreferredSize(rect, isDeep)
end

function getPlayableOutputsDict(director)
	return Util.GetPlayableOutputsDict(director)
end

function getUIDrawModelDataByCharTypeAndModelID(cfg, charType, modelID)
	return Util.GetUIDrawModelData(cfg, charType, modelID)
end

function checkTouchPositionOnGameObject(position, gameObject)
	return Util.CheckTouchOnGameObject(position, gameObject)
end

function setCameraDepthTextureMode(camera, mode)
	Util.EnableCameraDepthTextureMode(camera, mode)
end

function destroy(obj)
	if not obj then
		return
	end
	if tolua.isnull(obj) then
		return
	end

	GameObject.Destroy(obj)
end

function newObject(prefab)
	return GameObject.Instantiate(prefab)
end

function htmlStringToColor(colorstr)
	local result, bin_color = ColorUtility.TryParseHtmlString(colorstr, nil)
	if result then
		return bin_color
	end
	return Color.white
end

function colorToHtmlString(color)
	return Util.ColorToHtmlString(color)
end

function getColorIntensity(color)
	local maxColor = color.maxColorComponent
	if maxColor == 0 or maxColor <= 1 and maxColor > 1.0 / 255.0 then
		return 0
	else
		return math.log(255.0 / 191.0 * maxColor) / math.log(2.0)
	end
end

function setColorIntensity(color, intensity)
	local exp = 2 ^ intensity
	color.r   = color.r * exp
	color.g   = color.g * exp
	color.b   = color.b * exp
end

function getAnimationState(animation, name)
	return Util.GetAnimationState(animation, name)
end