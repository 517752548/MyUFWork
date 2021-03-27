_G.UIUtil = {}

function UIUtil:FixFullScreenUITransform(uguiObject)
	if not uguiObject then return end
	local rectTransform     = uguiObject:GetTransform()
	local lrSideGap         = UIManager:GetCanvasFullSize().x - UIManager:GetCanvasSafeSize().x
	rectTransform.offsetMin = Vector2.New(lrSideGap * -1, rectTransform.offsetMin.y)
	rectTransform.offsetMax = Vector2.New(lrSideGap, rectTransform.offsetMax.y)
end
-----------------------------------------------------依次紧密布局 BEGIN---------------------------------------------------
---@return nil @纵向依次布局列表里的UGUIObject
---@param items table<UGUIObject> @要布局的内容，依次存放，会检测GetVisible如果为false不参与布局
---@param startX number @起始坐标x值
---@param gap number @间隔，计算每一个item的宽度后再额外加的间隔值
function UIUtil:BoxLayoutHorizontal(items, startPosX, gap)
	local w = startPosX
	for i, item in ipairs(items) do
		if item:GetVisible() then
			item:ForceRebuildLayoutImmediate()
			local pivot = item:GetPivot()
			local width = item:GetRect().width
			if w ~= startPosX then
				w = w + (pivot.x * width)
			end
			local anchoredPos = item:GetAnchoredPosition()
			item:SetAnchoredPosition(Vector2.New(w, anchoredPos.y))
			w = w + ((1 - pivot.x) * width)
			w = w + gap
		end
	end
end

---@return nil @纵向依次布局列表里的UGUIObject
---@param items table<UGUIObject> @要布局的内容，依次存放，会检测GetVisible如果为false不参与布局
---@param startY number @起始坐标y值
---@param gap number @间隔，计算每一个item的高度后再额外加的间隔值
function UIUtil:BoxLayoutVertical(items, startPosY, gap)
	local h = startPosY
	for i, item in ipairs(items) do
		if item:GetVisible() then
			local pivot  = item:GetPivot()
			local height = item:GetRect().height
			if h ~= startPosY then
				h = h - ((1 - pivot.y) * height)
			end
			local anchoredPos = item:GetAnchoredPosition()
			item:SetAnchoredPosition(Vector2.New(anchoredPos.x, h))
			h = h - (height * pivot.y)
			h = h - gap
		end
	end
end

--@desc 横向居中依次靠上布局排列
--@items table 要布局的内容，依次存放，会检测GetVisible如果为false不参与布局
--@gap number 间隔，计算每一个item的宽度后再额外加的间隔值
--@offsetX number x坐标偏移
--@offsetY number y坐标偏移
function UIUtil:BoxLayoutCenterHorizontalTop(items, gap, offsetX, offsetY)
	offsetX        = offsetX or 0
	offsetY        = offsetY or 0

	local allWidth = 0
	local maxTopY  = 0
	local temp     = {}

	for i, item in ipairs(items) do
		if item:GetVisible() then
			local rect  = item:GetRect()
			allWidth    = allWidth + rect.width

			local pivot = item:GetPivot()
			local topY  = (1 - pivot.y) * rect.height
			if maxTopY < topY then
				maxTopY = topY
			end

			table.insert(temp, item)
		end
	end

	local posX = -(allWidth + #temp * gap) / 2

	for i, item in ipairs(temp) do
		local rect   = item:GetRect()
		local pivot  = item:GetPivot()
		local startX = posX + pivot.x * rect.width

		local topY   = (1 - pivot.y) * rect.height
		local startY = maxTopY - topY

		item:SetAnchoredPosition(Vector2.New(startX + offsetX, startY + offsetY))

		posX = posX + rect.width + gap
	end
end
-----------------------------------------------------依次紧密布局 END---------------------------------------------------
--------------------------------------------------------固定大小布局 BEGIN---------------------------------------------------
function UIUtil:MatrixLayout(items, col, colWidth, rowHeight, offsetX, offsetY)
	offsetX = offsetX or 0
	offsetY = offsetY or 0
	local x = 0
	local y = 0
	for i = 1, #items do
		local item = items[i]
		x          = math.floor(offsetX + colWidth * ((i - 1) % col))
		y          = math.floor(offsetY - rowHeight * math.floor((i - 1) / col))
		local go = item:GetGameObject()
		go.transform.anchorMax        = Vector2.New(0.5, 0.5)
		go.transform.anchorMin        = Vector2.New(0.5, 0.5)
		go.transform.pivot            = Vector2.New(0.5, 0.5)
		item:SetAnchoredPosition(Vector2.New(x, y))
	end
end
--制定一个坐标为起始点，横向布局
function UIUtil:HLayout(items, colWidth, offsetX, offsetY)
	UIUtil:MatrixLayout(items, #items, colWidth, 0, offsetX, offsetY)
end
--制定一个坐标为起始点，纵向布局
function UIUtil:VLayout(items, rowHeight, offsetX, offsetY)
	UIUtil:MatrixLayout(items, 1, 0, rowHeight, offsetX, offsetY)
end

--指定一个坐标为中心点，横向布局
function UIUtil:HCenterLayout(count, items, colWidth, x, y)
	local offsetX = x - (count * colWidth / 2) + (colWidth / 2)
	local offsetY = y
	UIUtil:HLayout(items, colWidth, offsetX, offsetY)
end
--指定一个坐标为中心点，纵向布局
function UIUtil:VCenterLayout(count, items, rowHeight, x, y)
	local offsetX = x
	local offsetY = y - (count * rowHeight / 2)
	UIUtil:VLayout(items, rowHeight, offsetX, offsetY)
end

function UIUtil:MatrixCenterLayout(items, col, colWidth, rowHeight, x, y)
	local offsetX = x - (math.min(#items, col) * colWidth / 2)
	local offsetY = y + (math.floor(#items / col) * rowHeight / 2)
	UIUtil:MatrixLayout(items, col, colWidth, rowHeight, offsetX, offsetY)
end

--------------------------------------------------------固定大小布局 END---------------------------------------------------

function UIUtil:SetGray(tsf, value)
	local image          = tsf:GetComponent(typeof(UnityEngine.UI.Image))
	local childrenImages = tsf:GetComponentsInChildren(typeof(UnityEngine.UI.Image))
	local setMat         = function(mat)
		if image then
			image.material = mat
		end
		if childrenImages then
			local len = childrenImages.Length
			for i = 0, len - 1 do
				childrenImages[i].material = mat
			end
		end
	end
	if not image and not childrenImages then return end
	local abPath = ResUtil:GetUIDefaultGrayMaterial()
	if value then
		local mat = ResManager:LoadMaterial(abPath)
		setMat(mat)
	else
		setMat(nil)
	end
end