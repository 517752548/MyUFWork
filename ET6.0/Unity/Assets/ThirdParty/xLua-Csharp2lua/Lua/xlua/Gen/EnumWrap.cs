#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    
    public class SystemNetSocketsAddressFamilyWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(System.Net.Sockets.AddressFamily), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(System.Net.Sockets.AddressFamily), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(System.Net.Sockets.AddressFamily), L, null, 32, 0, 0);

            Utils.RegisterEnumType(L, typeof(System.Net.Sockets.AddressFamily));

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(System.Net.Sockets.AddressFamily), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushSystemNetSocketsAddressFamily(L, (System.Net.Sockets.AddressFamily)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

                try
				{
                    translator.TranslateToEnumToTop(L, typeof(System.Net.Sockets.AddressFamily), 1);
				}
				catch (System.Exception e)
				{
					return LuaAPI.luaL_error(L, "cast to " + typeof(System.Net.Sockets.AddressFamily) + " exception:" + e);
				}

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for System.Net.Sockets.AddressFamily! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class SystemNetSocketsSocketTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(System.Net.Sockets.SocketType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(System.Net.Sockets.SocketType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(System.Net.Sockets.SocketType), L, null, 7, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Stream", System.Net.Sockets.SocketType.Stream);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Dgram", System.Net.Sockets.SocketType.Dgram);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Raw", System.Net.Sockets.SocketType.Raw);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Rdm", System.Net.Sockets.SocketType.Rdm);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Seqpacket", System.Net.Sockets.SocketType.Seqpacket);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Unknown", System.Net.Sockets.SocketType.Unknown);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(System.Net.Sockets.SocketType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushSystemNetSocketsSocketType(L, (System.Net.Sockets.SocketType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Stream"))
                {
                    translator.PushSystemNetSocketsSocketType(L, System.Net.Sockets.SocketType.Stream);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Dgram"))
                {
                    translator.PushSystemNetSocketsSocketType(L, System.Net.Sockets.SocketType.Dgram);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Raw"))
                {
                    translator.PushSystemNetSocketsSocketType(L, System.Net.Sockets.SocketType.Raw);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Rdm"))
                {
                    translator.PushSystemNetSocketsSocketType(L, System.Net.Sockets.SocketType.Rdm);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Seqpacket"))
                {
                    translator.PushSystemNetSocketsSocketType(L, System.Net.Sockets.SocketType.Seqpacket);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Unknown"))
                {
                    translator.PushSystemNetSocketsSocketType(L, System.Net.Sockets.SocketType.Unknown);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for System.Net.Sockets.SocketType!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for System.Net.Sockets.SocketType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
    public class SystemNetSocketsProtocolTypeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(System.Net.Sockets.ProtocolType), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(System.Net.Sockets.ProtocolType), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(System.Net.Sockets.ProtocolType), L, null, 26, 0, 0);

            Utils.RegisterEnumType(L, typeof(System.Net.Sockets.ProtocolType));

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(System.Net.Sockets.ProtocolType), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushSystemNetSocketsProtocolType(L, (System.Net.Sockets.ProtocolType)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

                try
				{
                    translator.TranslateToEnumToTop(L, typeof(System.Net.Sockets.ProtocolType), 1);
				}
				catch (System.Exception e)
				{
					return LuaAPI.luaL_error(L, "cast to " + typeof(System.Net.Sockets.ProtocolType) + " exception:" + e);
				}

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for System.Net.Sockets.ProtocolType! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
}