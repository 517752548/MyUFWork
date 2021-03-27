---@class Dragger @用来管理一组拖拽行为的操作。这个类并不会跟随HybridUI来自动生成出来，这是一个纯操作代理类，所有需要用到的显示对象都需要从外部传进来，使用的时候需要在自己写的lua逻辑中自行创建(New)和销毁(Destroy)
---@field dragItems table<UGUIObject> @参与拖拽的items
---@field dragImage UGUIObject @显示拖拽图标的UGUIObject
_G.Dragger = class(UGUIObject)

function Dragger:ctor()
	self.dragItems       = {}
	self.dragImage       = nil
	self._uiCamera       = nil
	self._startDrag      = false
	self._srcObject      = nil
	self._onDragBegin    = nil
	self._onDragging     = nil
	self._onDragEnd      = nil
	self._onDragCancel   = nil
	self.last_position   = Vector2.zero
	self.curr_position   = Vector2.zero
	self._lastDragObject = nil
end

function Dragger:AddDragItem(item)
	if not item then return end
	for i, v in pairs(self.dragItems) do
		if v == item then
			return
		end
	end
	table.insert(self.dragItems, item)
end

function Dragger:SetDragImage(value)
	self.dragImage = value
end

function Dragger:GetAllDragItems()
	return self.dragItems
end

function Dragger:OnDragBegin(callback)
	self._onDragBegin = callback
end

function Dragger:OnDragging(callback)
	self._onDragging = callback
end

function Dragger:OnDragEnd(callback)
	self._onDragEnd = callback
end

function Dragger:OnDragCancel(callback)
	self._onDragCancel = callback
end

function Dragger:GetLastDragObject()
	return self._lastDragObject
end

function Dragger:ClearLastDragObject()
	self._lastDragObject = nil
end

function Dragger:Init()
	self._uiCamera = UIManager:GetUIRoot():GetStageCamera()
	if self.dragImage then
		self.dragImage:SetVisible(false)
	end
end

local temp_anchored_pos_3d = Vector3.zero
function Dragger:Update()
	if not self._uiCamera then return end
	local dragBegin
	local dragging
	local dragEnd
	self.last_position.x = self.curr_position.x
	self.last_position.y = self.curr_position.y
	if IsWindowsPlayer or IsRunInEditor then
		--windows以及编辑器
		dragBegin          = Input.GetMouseButtonDown(0)
		dragging           = Input.GetMouseButton(0)
		dragEnd            = Input.GetMouseButtonUp(0)
		self.curr_position = Input.mousePosition
	else
		--移动设备上
		if Input.touchCount == 1 then
			local touch1       = Input.GetTouch(0)
			dragBegin          = touch1.phase == TouchPhase.Stationary or touch1.phase == TouchPhase.Began
			dragging           = touch1.phase == TouchPhase.Moved
			dragEnd            = touch1.phase == TouchPhase.Ended or touch1.phase == TouchPhase.Canceled
			self.curr_position = touch1 and touch1.position
		end
	end
	--开始拖拽检测
	if not self._startDrag and (dragBegin or dragging) then
		if self.last_position and self.curr_position and not CheckVector2Equals(self.last_position, self.curr_position) then
			--位置有偏差
			for i, src in ipairs(self.dragItems) do
				if src:GetVisible() then
					local isBeginDown = RectTransformUtility.RectangleContainsScreenPoint(src:GetTransform(), self.curr_position, self._uiCamera)
					if isBeginDown then
						if src:GetDraggable() then
							self._startDrag = true
							self._srcObject = src
							local pos       = self._uiCamera:ScreenToWorldPoint(self.curr_position)
							if self.dragImage then
								self.dragImage:SetVisible(true)
								self.dragImage:SetSprite(src:GetDragingSprite())

								self.dragImage:SetWorldPos(pos)
								local ap               = self.dragImage:GetAnchoredPosition()
								temp_anchored_pos_3d.x = ap.x
								temp_anchored_pos_3d.y = ap.y
								self.dragImage:SetAnchoredPosition3D(temp_anchored_pos_3d)
							end
							self._lastDragObject = self._srcObject
							self:_ExecOnDragBegin(self._srcObject, pos)
						end
						self._startDelayTime = GetCurTime()
						break
					end
				end
			end
		end
	end
	--拖拽中
	if self._startDrag and self._srcObject and dragging then
		local pos = self._uiCamera:ScreenToWorldPoint(self.curr_position)
		if self.dragImage then
			self.dragImage:SetWorldPos(pos)
			local ap               = self.dragImage:GetAnchoredPosition()
			temp_anchored_pos_3d.x = ap.x
			temp_anchored_pos_3d.y = ap.y
			self.dragImage:SetAnchoredPosition3D(temp_anchored_pos_3d)
		end
		self:_ExecOnDragging(self._srcObject, pos)
	end
	--取消拖拽
	if self._startDrag and self._srcObject and dragEnd and self.curr_position then
		self._startDrag = false
		if self.dragImage then
			self.dragImage:ClearSprite()
			self.dragImage:SetVisible(false)
		end
		local hasEnd = false
		for i, dest in ipairs(self.dragItems) do
			local isEndUp = RectTransformUtility.RectangleContainsScreenPoint(dest:GetTransform(), self.curr_position, self._uiCamera)
			if isEndUp then
				self:_ExecOnDragEnd(self._srcObject, dest)
				hasEnd = true
				break
			end
		end
		if not hasEnd then
			self:_ExecOnDragCancel(self._srcObject)
		end
		self._srcObject = nil
	end
end

function Dragger:_ExecOnDragBegin(srcObject, worldPos)
	if not srcObject then return end
	if self._onDragBegin then
		self._onDragBegin(srcObject, worldPos)
	end
end

function Dragger:_ExecOnDragging(srcObject, worldPos)
	if not srcObject then return end
	if self._onDragging then
		self._onDragging(srcObject, worldPos)
	end
end

function Dragger:_ExecOnDragEnd(srcObject, destObject)
	if not srcObject then return end
	if not destObject then return end
	if self._onDragEnd then
		self._onDragEnd(srcObject, destObject)
	end
end
function Dragger:_ExecOnDragCancel(srcObject)
	if self._onDragCancel then
		self._onDragCancel(srcObject)
	end
end
function Dragger:RemoveAllDragItem()
	self.dragItems = {}
end

function Dragger:Destroy()
	self.dragItems       = nil
	self.dragImage       = nil
	self._uiCamera       = nil
	self._startDrag      = false
	self._srcObject      = nil
	self._onDragBegin    = nil
	self._onDragging     = nil
	self._onDragEnd      = nil
	self._onDragCancel   = nil
	self.last_position   = nil
	self.curr_position   = nil
	self._lastDragObject = nil
	Dragger.superclass.Destroy(self)
end