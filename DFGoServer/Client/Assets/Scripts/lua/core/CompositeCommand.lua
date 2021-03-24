_G.CompositeCommand = class(BaseCommand)

function CompositeCommand:ctor()
	self._onCommandItemCompleteCallback = nil
	self._commands                      = {}
	self._executingCommands             = {}
	self._currentCommand                = nil
	self._isExecuting                   = false
	self._totalCount                    = 0
end

function CompositeCommand:IsExecuting()
	return self._isExecuting
end

function CompositeCommand:GetTotalCount()
	return self._totalCount
end

function CompositeCommand:GetLeftCount()
	return #self._commands
end

function CompositeCommand:AddCommand(command)
	if not self._commands then
		self._commands = {}
	end
	table.insert(self._commands, command)
end

function CompositeCommand:Execute()
	if self._isExecuting then
		return
	end
	if not self._executingCommands then
		self._executingCommands = {}
	end
	self._totalCount = #self._commands

	if self._commands and #self._commands > 0 then
		self._isExecuting = true
		self:ExecuteNextCommand()
	else
		self._isExecuting = false
		self:InvokeComplete()
	end
end

function CompositeCommand:ExecuteNextCommand()
	if #self._commands > 0 then
		local command = table.remove(self._commands, 1)
		if command then
			self:ExecuteCommandItem(command)
		end
	else
		self._isExecuting = false
		self:InvokeComplete()
	end
end

function CompositeCommand:ExecuteCommandItem(command)
	self._currentCommand = command
	table.insert(self._executingCommands, command)
	self:AddCallbackToCommand(command)
	command:Execute()
end

function CompositeCommand:AddCallbackToCommand(command)
	command:OnCommandComplete(function()
		self:OnExecutingCommandItemComplete()
	end)
end

function CompositeCommand:RemoveCallbackFromCommand(command)
	command:OnCommandComplete(nil)
end

function CompositeCommand:OnExecutingCommandItemComplete(command)
	self:RemoveCallbackFromCommand(command)
	for i = #self._executingCommands, 1, -1 do
		if self._executingCommands[i] == command then
			table.remove(self._executingCommands, i)
		end
	end
	if self._onCommandItemCompleteCallback then
		self._onCommandItemCompleteCallback(command)
	end
	self:ExecuteNextCommand()
end

function CompositeCommand:Destroy()
	self._onCommandItemCompleteCallback = nil
	if self._commands then
		for i, v in ipairs(self._commands) do
			v:Destroy()
		end
	end
	self._commands          = nil
	self._executingCommands = nil
	self._currentCommand    = nil
	CompositeCommand.superclass.Destroy(self)
end