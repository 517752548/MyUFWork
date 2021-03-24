_G.BaseCommand = class(BaseObject)

function BaseCommand:ctor()
	self._onCommandCompleteCallback = nil
end

function BaseCommand:Execute()

end

function BaseCommand:InvokeComplete()
	if self._onCommandCompleteCallback then
		self._onCommandCompleteCallback(self)
	end
end
function BaseCommand:OnCommandComplete(callback)
	self._onCommandCompleteCallback = callback
end

function BaseCommand:Destroy()
	self._onCommandCompleteCallback = nil
	BaseCommand.superclass.Destroy(self)
end