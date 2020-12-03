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
    public class FairyGUIUpdateContextClipInfoWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(FairyGUI.UpdateContext.ClipInfo);
			Utils.BeginObjectRegister(type, L, translator, 0, 15, 7, 7);
			
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "__clone__", __clone__);
            			
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getrect", _g_get_rect);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getclipBox", _g_get_clipBox);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getsoft", _g_get_soft);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getsoftness", _g_get_softness);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getclipId", _g_get_clipId);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getstencil", _g_get_stencil);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getreversedMask", _g_get_reversedMask);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setrect", _s_set_rect);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setclipBox", _s_set_clipBox);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setsoft", _s_set_soft);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setsoftness", _s_set_softness);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setclipId", _s_set_clipId);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setstencil", _s_set_stencil);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setreversedMask", _s_set_reversedMask);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "rect", _g_get_rect);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "clipBox", _g_get_clipBox);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "soft", _g_get_soft);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "softness", _g_get_softness);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "clipId", _g_get_clipId);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "stencil", _g_get_stencil);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "reversedMask", _g_get_reversedMask);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "rect", _s_set_rect);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "clipBox", _s_set_clipBox);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "soft", _s_set_soft);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "softness", _s_set_softness);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "clipId", _s_set_clipId);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "stencil", _s_set_stencil);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "reversedMask", _s_set_reversedMask);
            
			
			
			
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
				FairyGUI.UpdateContext.ClipInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
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
				    translator.Push(L, default(FairyGUI.UpdateContext.ClipInfo));
			        return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to FairyGUI.UpdateContext.ClipInfo constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_rect(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.UpdateContext.ClipInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.Push(L, gen_to_be_invoked.rect);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_clipBox(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.UpdateContext.ClipInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.PushUnityEngineVector4(L, gen_to_be_invoked.clipBox);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_soft(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.UpdateContext.ClipInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.soft);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_softness(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.UpdateContext.ClipInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.PushUnityEngineVector4(L, gen_to_be_invoked.softness);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_clipId(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.UpdateContext.ClipInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.xlua_pushuint(L, gen_to_be_invoked.clipId);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_stencil(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.UpdateContext.ClipInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.stencil);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_reversedMask(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.UpdateContext.ClipInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.reversedMask);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_rect(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.UpdateContext.ClipInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                UnityEngine.Rect gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.rect = gen_value;
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_clipBox(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.UpdateContext.ClipInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                UnityEngine.Vector4 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.clipBox = gen_value;
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_soft(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.UpdateContext.ClipInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                gen_to_be_invoked.soft = LuaAPI.lua_toboolean(L, 2);
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_softness(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.UpdateContext.ClipInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                UnityEngine.Vector4 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.softness = gen_value;
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_clipId(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.UpdateContext.ClipInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                gen_to_be_invoked.clipId = LuaAPI.xlua_touint(L, 2);
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_stencil(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.UpdateContext.ClipInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                gen_to_be_invoked.stencil = LuaAPI.lua_toboolean(L, 2);
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_reversedMask(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.UpdateContext.ClipInfo gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                gen_to_be_invoked.reversedMask = LuaAPI.lua_toboolean(L, 2);
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
