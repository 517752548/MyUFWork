_G.Bezier = class()

function Bezier:ctor(v0, v1, v2, v3)
	self.p0    = v0
	self.p1    = v1
	self.p2    = v2
	self.p3    = v3
	self.ti    = 0
	self.b0    = Vector3.zero
	self.b1    = Vector3.zero
	self.b2    = Vector3.zero
	self.b3    = Vector3.zero
	self.ax    = 0
	self.ay    = 0
	self.az    = 0
	self.bx    = 0
	self.by    = 0
	self.bz    = 0
	self.cx    = 0
	self.cy    = 0
	self.cz    = 0
	self.value = Vector3.zero
end

function Bezier:SetEndPos(endPos)
	self.p3:Set(endPos.x, endPos.y, endPos.z)
end

function Bezier:GetPointAtTime(t)
	self:CheckConstant()
	local t2 = t * t
	local t3 = t * t * t
	local x  = self.ax * t3 + self.bx * t2 + self.cx * t + self.p0.x
	local y  = self.ay * t3 + self.by * t2 + self.cy * t + self.p0.y
	local z  = self.az * t3 + self.bz * t2 + self.cz * t + self.p0.z
	self.value:Set(x, y, z)
	return self.value
end

function Bezier:SetConstant()
	self.cx = 3 * (self.p1.x - self.p0.x)
	self.bx = 3 * (self.p2.x - self.p1.x) - self.cx
	self.ax = self.p3.x - self.p0.x - self.cx - self.bx

	self.cy = 3 * (self.p1.y - self.p0.y)
	self.by = 3 * (self.p2.y - self.p1.y) - self.cy
	self.ay = self.p3.y - self.p0.y - self.cy - self.by

	self.cz = 3 * (self.p1.z - self.p0.z)
	self.bz = 3 * (self.p2.z - self.p1.z) - self.cz
	self.az = self.p3.z - self.p0.z - self.cz - self.bz
end

function Bezier:CheckConstant()
	if (not self.p0:Equals(self.b0))
			or (not self.p1:Equals(self.b1))
			or (not self.p2:Equals(self.b2))
			or (not self.p3:Equals(self.b3))
	then
		self:SetConstant()
		self.b0:Set(self.p0.x, self.p0.y, self.p0.z)
		self.b1:Set(self.p1.x, self.p1.y, self.p1.z)
		self.b2:Set(self.p2.x, self.p2.y, self.p2.z)
		self.b3:Set(self.p3.x, self.p3.y, self.p3.z)
	end
end

function Bezier:Destroy()
	self.p0    = nil
	self.p1    = nil
	self.p2    = nil
	self.p3    = nil
	self.ti    = 0
	self.b0    = nil
	self.b1    = nil
	self.b2    = nil
	self.b3    = nil
	self.ax    = 0
	self.ay    = 0
	self.az    = 0
	self.bx    = 0
	self.by    = 0
	self.bz    = 0
	self.cx    = 0
	self.cy    = 0
	self.cz    = 0
	self.value = nil
end