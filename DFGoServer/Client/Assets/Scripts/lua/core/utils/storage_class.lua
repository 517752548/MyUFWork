_G.STORAGE_RAW_TABLE_DEFINE          = "rawtable"
_G.STORAGE_RAW_VERSION_DEFINE        = "rawversion"
_G.STORAGE_RAW_LASTVERSION_ENDFIX    = "_LASTVERSION"
_G.STORAGE_RAW_VERSION_ENDFIX        = "_VERSION"
_G.STORAGE_RAW_VERSION_CALLER_DEFINE = "callrawversion"

function storage_class()
	local class_type = {}
	class_type.ctor  = false
	class_type.New   = function(...)
		local obj = {}
		setmetatable(obj, {
			__newindex = function(table, key, value)
				if not rawget(table, STORAGE_RAW_TABLE_DEFINE) then
					rawset(table, STORAGE_RAW_TABLE_DEFINE, {})
				end
				if not rawget(table, STORAGE_RAW_VERSION_DEFINE) then
					rawset(table, STORAGE_RAW_VERSION_DEFINE, {})
				end
				local _rawtab     = rawget(table, STORAGE_RAW_TABLE_DEFINE)
				local _rawversion = rawget(table, STORAGE_RAW_VERSION_DEFINE)
				--记录版本信息
				local key_lastver = STORAGE_RAW_LASTVERSION_ENDFIX
				if not _rawversion[key] then
					_rawversion[key] = {}
				end
				if not _rawversion[key][key_lastver] then
					_rawversion[key][key_lastver] = 0
				end
				local key_ver = STORAGE_RAW_VERSION_ENDFIX
				if not _rawversion[key][key_ver] then
					_rawversion[key][key_ver] = 0
				end
				if IsInitializeStorage and _rawtab[key] ~= value then
					_rawversion[key][key_ver] = _rawversion[key][key_ver] + 1
				end
				_rawtab[key] = value
			end,
			__index    = function(table, key)
				if key == STORAGE_RAW_VERSION_CALLER_DEFINE then
					return rawget(table, STORAGE_RAW_VERSION_DEFINE)
				end
				local _rawtab = rawget(table, STORAGE_RAW_TABLE_DEFINE)
				if not _rawtab then return nil end
				return _rawtab[key]
			end,
			__pairs    = function(table)
				local _rawtab = rawget(table, STORAGE_RAW_TABLE_DEFINE)
				return function(_, key)
					if _rawtab then
						local nextKey, nextValue = next(_rawtab, key)
						return nextKey, nextValue
					end
				end
			end,
		})
		do
			local create
			create = function(c, ...)
				if c.ctor then
					c.ctor(obj, ...)
				end
			end
			create(class_type, ...)
		end
		return obj
	end
	return class_type
end