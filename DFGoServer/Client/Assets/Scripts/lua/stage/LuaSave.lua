_G.LuaSave = {}

function LuaSave:SetInt(key, intvalue)
    PlayerPrefs:SetInt(key, intvalue)
end

function LuaSave:GetInt(key, default)
    return PlayerPrefs:GetInt(key, default)
end

function LuaSave:SetString(key, strvalue)
    PlayerPrefs:SetString(key, strvalue)
end

function LuaSave:GetString(key, default)
    return PlayerPrefs:GetString(key, default)
end

function LuaSave:SetTable(key, tb)
    PlayerPrefs:SetString(key, JSON.encode(tb))
end

function LuaSave:GetTable(key)
    local str = PlayerPrefs:GetString(key, "")
    if str == "" then
        return {}
    end
    return JSON.decode(str)
end