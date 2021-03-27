_G.NumberImage = class(ScrollList)

function NumberImage:ctor()
	self.urlPrefix = nil
	self.valueStr  = nil
end

function NumberImage:SetURLPrefix(prefix)
	self.urlPrefix = prefix
	self:UseUGUIOriginalLayout(true)
	self:SetHorizontal(false)
	self:SetVertical(false)
	self:SetRowCount(1)
	self:SetRenderClass(NumberImageItemRender)
end

function NumberImage:SetValue(value)
	if not self.urlPrefix then return end
	self.valueStr = tostring(value)
	if not self.valueStr then return end
	local dataList = {}
	local len      = string.len(self.valueStr)
	for i = 1, len do
        local s = string.sub(self.valueStr, i, i)
        s = ( s == '.' ) and 'dian' or s
		table.insert(dataList, { url = self.urlPrefix .. s .. ".png" })
	end
	self:SetDataProvider(dataList)
end

function NumberImage:Destroy()
	self.urlPrefix = nil
	self.valueStr  = nil
	NumberImage.superclass.Destroy(self)
end

_G.NumberImageItemRender = class(UGUIObject)

function NumberImageItemRender:SetData(data)
	NumberImageItemRender.superclass.SetData(self, data)
	self:LoadSprite(data.url)
end
