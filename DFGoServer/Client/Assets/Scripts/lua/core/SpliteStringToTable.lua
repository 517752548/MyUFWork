_G.wuhunActionMap = {}
_G.GetWuHunAnimaTable = function(action, nameString)
    action = string.lower(action)
    if not wuhunActionMap[action .. nameString] then
        local file = string.gsub(action, "zhujue", nameString)
        local filetable = split(file, "|")
        wuhunActionMap[action .. nameString] = filetable[1]
    end
    return wuhunActionMap[action .. nameString]
end

_G.horseActionMap = {}
_G.GetHorseAnimaTable = function(action, a, b)
    action = string.lower(action)
    if not horseActionMap[action .. a .. b] then
        local file = string.gsub(action, a, b)
            file = string.gsub(file, "zhandoubenpao", "putongbenpao")
            file = string.gsub(file, "zhandoudaiji", "putongdaiji")
        horseActionMap[action .. a .. b] = file
    end
    return horseActionMap[action .. a .. b]
end

_G.mechActionMap = {}
_G.GetMechAnimaTable = function(action, a, b)
    action = string.lower(action)
    if not mechActionMap[action .. a .. b] then
        local file = string.gsub(action, a, b)
	    mechActionMap[action .. a .. b] = file
    end
    return mechActionMap[action .. a .. b]
end

_G.bathingActionMap = {}
_G.GetBathingAnimaTable = function(action, string1, string2, isBathing)
    action = string.lower(action)
    if not bathingActionMap[action .. string1 .. string2] then
        local file = string.gsub(action, string1, string2)
        local filetable = GetVerticalTable(file)
        bathingActionMap[action .. string1 .. string2] = filetable[1]
    end
    return bathingActionMap[action .. string1 .. string2]
end

_G.poundTable = {}
_G.GetPoundTable = function(string)
    if not string or #string == 0 then
        return
    end
    if not poundTable[string] then
        poundTable[string] = split(string, "#")
    end
    return poundTable[string]
end

_G.verticalTable = {}
_G.GetVerticalTable = function(string)
    if not verticalTable[string] then
        verticalTable[string] = split(string, "|")
    end
    return verticalTable[string]
end

_G.colonTable = {}
_G.GetColonTable = function(string)
    if not colonTable[string] then
        colonTable[string] = split(string, ":")
    end
    return colonTable[string]
end

_G.commaTable = {}
_G.GetCommaTable = function(string)
    if not commaTable[string] then
        commaTable[string] = split(string, ",")
    end
    return commaTable[string]
end

_G.slantedTable = {}
_G.GetSlantedTable = function(string)
    if not slantedTable[string] then
        slantedTable[string] = split(string, "/")
    end
    return slantedTable[string]
end

_G.poundCommaTable = {}
_G.GetPoundCommaTable = function(string)
    if not string or #string == 0 then
        return
	end
	
	if not poundCommaTable[string] then
		local dataList = {}
		local strTab = string:split("#")
		for i, str in ipairs(strTab) do
			table.insert(dataList, str:split(","))
		end

		poundCommaTable[string] = dataList
	end
	
    return poundCommaTable[string]
end