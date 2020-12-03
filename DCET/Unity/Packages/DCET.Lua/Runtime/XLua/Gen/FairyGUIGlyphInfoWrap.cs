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
    public class FairyGUIGlyphInfoWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(FairyGUI.GlyphInfo);
			Utils.BeginObjectRegister(type, L, translator, 0, 19, 9, 9);
			
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "__clone__", __clone__);
            			
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getvertMin", _g_get_vertMin);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getvertMax", _g_get_vertMax);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getuvBottomLeft", _g_get_uvBottomLeft);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getuvTopLeft", _g_get_uvTopLeft);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getuvTopRight", _g_get_uvTopRight);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getuvBottomRight", _g_get_uvBottomRight);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getwidth", _g_get_width);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getheight", _g_get_height);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getchannel", _g_get_channel);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setvertMin", _s_set_vertMin);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setvertMax", _s_set_vertMax);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setuvBottomLeft", _s_set_uvBottomLeft);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setuvTopLeft", _s_set_uvTopLeft);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setuvTopRight", _s_set_uvTopRight);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setuvBottomRight", _s_set_uvBottomRight);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setwidth", _s_set_width);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setheight", _s_set_height);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setchannel", _s_set_channel);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "vertMin", _g_get_vertMin);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "vertMax", _g_get_vertMax);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "uvBottomLeft", _g_get_uvBottomLeft);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "uvTopLeft", _g_get_uvTopLeft);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "uvTopRight", _g_get_uvTopRight);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "uvBottomRight", _g_get_uvBottomRight);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "width", _g_get_width);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "height", _g_get_height);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "channel", _g_get_channel);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "vertMin", _s_set_vertMin);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "vertMax", _s_set_vertMax);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "uvBottomLeft", _s_set_uvBottomLeft);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "uvTopLeft", _s_set_uvTopLeft);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "uvTopRight", _s_set_uvTopRight);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "uvBottomRight", _s_set_uvBottomRight);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "width", _s_set_width);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "height", _s_set_height);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "channel", _s_set_channel);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int __clone__(RealStatePtr L)
		{
			try
			{
				ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				FairyGUI.GlyphInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
				translator.Push(L, gen_to_be_invoked);
				return 1;
			}
			catch (System.Exception e)
			{
				return LuaAPI.luaL_error(L, "c# exception in StructClone:" + e);
			}
		}
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				
				if (LuaAPI.lua_gettop(L) == 1)
				{
				    translator.Push(L, default(FairyGUI.GlyphInfo));
			        return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to FairyGUI.GlyphInfo constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_vertMin(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.GlyphInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.PushUnityEngineVector2(L, gen_to_be_invoked.vertMin);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_vertMax(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.GlyphInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.PushUnityEngineVector2(L, gen_to_be_invoked.vertMax);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_uvBottomLeft(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.GlyphInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.PushUnityEngineVector2(L, gen_to_be_invoked.uvBottomLeft);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_uvTopLeft(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.GlyphInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.PushUnityEngineVector2(L, gen_to_be_invoked.uvTopLeft);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_uvTopRight(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.GlyphInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.PushUnityEngineVector2(L, gen_to_be_invoked.uvTopRight);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_uvBottomRight(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.GlyphInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.PushUnityEngineVector2(L, gen_to_be_invoked.uvBottomRight);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_width(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.GlyphInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.width);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_height(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.GlyphInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.height);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_channel(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.GlyphInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.channel);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_vertMin(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.GlyphInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                UnityEngine.Vector2 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.vertMin = gen_value;
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_vertMax(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.GlyphInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                UnityEngine.Vector2 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.vertMax = gen_value;
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_uvBottomLeft(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.GlyphInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                UnityEngine.Vector2 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.uvBottomLeft = gen_value;
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_uvTopLeft(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.GlyphInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                UnityEngine.Vector2 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.uvTopLeft = gen_value;
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_uvTopRight(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.GlyphInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                UnityEngine.Vector2 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.uvTopRight = gen_value;
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_uvBottomRight(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.GlyphInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                UnityEngine.Vector2 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.uvBottomRight = gen_value;
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_width(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.GlyphInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                gen_to_be_invoked.width = (float)LuaAPI.lua_tonumber(L, 2);
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_height(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.GlyphInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                gen_to_be_invoked.height = (float)LuaAPI.lua_tonumber(L, 2);
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_channel(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.GlyphInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                gen_to_be_invoked.channel = LuaAPI.xlua_tointeger(L, 2);
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
