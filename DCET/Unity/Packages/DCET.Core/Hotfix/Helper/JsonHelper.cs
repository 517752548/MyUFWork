namespace DCET
{
	public static class JsonHelper
	{
		static JsonHelper()
		{
#if __CSharpLua__
		/*
		[[
			local rapidJson = require 'rapidjson'
			local rapidJsonDecode = rapidJson.decode

			local function fromJsonTable(t, T)
			  for k, v in pairs(t) do
				if v == rapidJson.null then
				  t[k] = nil
				elseif type(v) == "table" then
				  if #v > 0 then  -- is list
					fromJsonTable(v, System.List(System.Object))
				  else
					fromJsonTable(v, System.Object)
				  end
				end
			  end
			  setmetatable(t, T)
			end

			RapidjsonHelper =
			{
				ToJson = rapidJson.encode,

				FromJson = function (json, T)
					if T == nil then throw(ArgumentNullException("type")) end
					if getmetatable(T) == System.Type then
						T = T[1]
					end
					local t = rapidJsonDecode(json)
					fromJsonTable(t, T)
					return t
				end
			}
		]]
		*/
#endif
		}

		public static string ToJson(object obj)
		{
#if __CSharpLua__
			string t = null;
		/*
		[[
			t = RapidjsonHelper.ToJson(obj)
		]]
		*/
			return t;
#else
			return DCETRuntime.MongoHelper.ToJson(obj);
#endif
		}

		public static T FromJson<T>(string str)
		{
#if __CSharpLua__
			T t = default(T);
		/*
		[[
			t = RapidjsonHelper.FromJson(str, T)
		]]
		*/
			return t;	
#else
			return DCETRuntime.MongoHelper.FromJson<T>(str);
#endif
		}
	}
}