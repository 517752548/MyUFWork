---@class LinkImageText
---@field LinkImageText UnityEngine.UI.Text

_G.LinkImageText = class(Text)

function LinkImageText:ctor(transform)
    self.linkImageText = nil
    self.onHrefCallBack = nil

	if self.textField then
		self.textField.raycastTarget = true
	end

    self._InitLinkImageTextComponent = function()
        if not self.transform then
            return
        end
        if not self.linkImageText then
            self.linkImageText = self.transform:GetComponent("LinkImageText")
            if self.linkImageText then
                self.linkImageText.OnHrefClick:AddListener(
                    function(str)
                        if self.onHrefCallBack then
                            self.onHrefCallBack(str)
                        end
                    end
                )
            end
		end
    end

	self:_InitLinkImageTextComponent()
end

function LinkImageText:SetHrefCallBack( func )
	self.onHrefCallBack = func
end

function LinkImageText:SetText(value)
    if not value then
        return
    end
    self:_InitLinkImageTextComponent()
    if not self.linkImageText then
        return
    end
    if self._textStr == value then
        return
    end
    self.linkImageText.text = value
    self._textStr = value
end

function LinkImageText:GetText()
    self:_InitLinkImageTextComponent()
    if not self.linkImageText then
        return ""
    end
    return self.linkImageText.text
end

function LinkImageText:GetPreferredSize(width)
	self:_InitLinkImageTextComponent()
	if not self.linkImageText then
		return 0, 0
	end

	local w = self.linkImageText:GetPreferredWidth("")
	local h = self.linkImageText:GetPreferredHeight("", width)
    return w, h
end

function LinkImageText:CalcPreferredHeight( str, width )
	self:_InitLinkImageTextComponent()
	if not self.linkImageText then
		return 0
	end

	return self.linkImageText:GetPreferredHeight( str, width )
end

function LinkImageText:Destroy()
	if self.linkImageText then
		self.linkImageText.OnHrefClick:RemoveAllListeners()
	end
    self.linkImageText = nil
    LinkImageText.superclass.Destroy(self)
end
