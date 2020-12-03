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
    public class FairyGUINMaterialWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(FairyGUI.NMaterial);
			Utils.BeginObjectRegister(type, L, translator, 0, 12, 6, 6);
			
            			
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getframeId", _g_get_frameId);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getclipId", _g_get_clipId);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getstencilSet", _g_get_stencilSet);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getblendMode", _g_get_blendMode);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getcombined", _g_get_combined);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmaterial", _g_get_material);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setframeId", _s_set_frameId);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setclipId", _s_set_clipId);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setstencilSet", _s_set_stencilSet);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setblendMode", _s_set_blendMode);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setcombined", _s_set_combined);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmaterial", _s_set_material);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "frameId", _g_get_frameId);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "clipId", _g_get_clipId);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "stencilSet", _g_get_stencilSet);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "blendMode", _g_get_blendMode);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "combined", _g_get_combined);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "material", _g_get_material);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "frameId", _s_set_frameId);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "clipId", _s_set_clipId);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "stencilSet", _s_set_stencilSet);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "blendMode", _s_set_blendMode);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "combined", _s_set_combined);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "material", _s_set_material);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<UnityEngine.Shader>(L, 2))
				{
					UnityEngine.Shader _shader = (UnityEngine.Shader)translator.GetObject(L, 2, typeof(UnityEngine.Shader));
					
					FairyGUI.NMaterial gen_ret = new FairyGUI.NMaterial(_shader);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to FairyGUI.NMaterial constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_frameId(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NMaterial gen_to_be_invoked = (FairyGUI.NMaterial)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, gen_to_be_invoked.frameId);
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
			
                FairyGUI.NMaterial gen_to_be_invoked = (FairyGUI.NMaterial)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, gen_to_be_invoked.clipId);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_stencilSet(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NMaterial gen_to_be_invoked = (FairyGUI.NMaterial)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.stencilSet);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_blendMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NMaterial gen_to_be_invoked = (FairyGUI.NMaterial)translator.FastGetCSObj(L, 1);
                translator.PushFairyGUIBlendMode(L, gen_to_be_invoked.blendMode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_combined(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NMaterial gen_to_be_invoked = (FairyGUI.NMaterial)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.combined);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_material(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NMaterial gen_to_be_invoked = (FairyGUI.NMaterial)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.material);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_frameId(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NMaterial gen_to_be_invoked = (FairyGUI.NMaterial)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.frameId = LuaAPI.xlua_touint(L, 2);
            
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
			
                FairyGUI.NMaterial gen_to_be_invoked = (FairyGUI.NMaterial)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.clipId = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_stencilSet(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NMaterial gen_to_be_invoked = (FairyGUI.NMaterial)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.stencilSet = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_blendMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NMaterial gen_to_be_invoked = (FairyGUI.NMaterial)translator.FastGetCSObj(L, 1);
                FairyGUI.BlendMode gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.blendMode = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_combined(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NMaterial gen_to_be_invoked = (FairyGUI.NMaterial)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.combined = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_material(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.NMaterial gen_to_be_invoked = (FairyGUI.NMaterial)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.material = (UnityEngine.Material)translator.GetObject(L, 2, typeof(UnityEngine.Material));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
