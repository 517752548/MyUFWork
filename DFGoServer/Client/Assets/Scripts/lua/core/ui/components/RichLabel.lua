---@class RichLabel
---@field richLabel UnityEngine.UI.Text
_G.RichLabel = class(Text)

function RichLabel:ctor(transform)
    self.richLabel = nil
    self.onHrefCallBack = nil

	if self.textField then
		self.textField.raycastTarget = true
	end

    self._InitRichLabelComponent = function()
        if not self.transform then
            return
        end
        if not self.richLabel then
            self.richLabel = self.transform:GetComponent("RichLabel")
            if self.richLabel then
                self.richLabel.OnHrefClick:AddListener(
                    function(str)
                        if self.onHrefCallBack then
                            self.onHrefCallBack(str)
                        end
                    end
                )
            end
		end
    end

	self:_InitRichLabelComponent()	
end

function RichLabel:SetHrefCallBack( func )
	self.onHrefCallBack = func
end

function RichLabel:SetText(value)
    if not value then
        return
    end
    self:_InitRichLabelComponent()
    if not self.richLabel then
        return
    end
    if self._textStr == value then
        return
    end
    self.richLabel.text = value
    self._textStr = value
end

function RichLabel:GetText()
    self:_InitRichLabelComponent()
    if not self.richLabel then
        return ""
    end
    return self.richLabel.text
end

function RichLabel:GetPreferredSize(width)
	self:_InitRichLabelComponent()

	if not self.richLabel then
		return 0, 0
	end

	local w = self.richLabel:GetPreferredWidth("")
	local h = self.richLabel:GetPreferredHeight("", width)

    return w, h
end

function RichLabel:CalcPreferredHeight( str, width )
	self:_InitRichLabelComponent()
	if not self.richLabel then
		return 0
	end

	return self.richLabel:GetPreferredHeight( str, width )
end

function RichLabel:Destroy()
	if self.richLabel then
		self.richLabel.OnHrefClick:RemoveAllListeners()
	end
    self.richLabel = nil
    RichLabel.superclass.Destroy(self)
end
