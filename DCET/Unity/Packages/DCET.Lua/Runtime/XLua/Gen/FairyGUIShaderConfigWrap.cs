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
    public class FairyGUIShaderConfigWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(FairyGUI.ShaderConfig);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
            			
						
            
			
						
			
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 24, 6, 5);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "GetShader", _m_GetShader_xlua_st_);
            
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "getpropertyIDs", _g_get_propertyIDs);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getGet", _g_get_Get);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getimageShader", _g_get_imageShader);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "gettextShader", _g_get_textShader);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "gettextBrighterShader", _g_get_textBrighterShader);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getbmFontShader", _g_get_bmFontShader);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "setGet", _s_set_Get);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setimageShader", _s_set_imageShader);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "settextShader", _s_set_textShader);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "settextBrighterShader", _s_set_textBrighterShader);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setbmFontShader", _s_set_bmFontShader);
            
			
			
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "propertyIDs", _g_get_propertyIDs);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "Get", _g_get_Get);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "imageShader", _g_get_imageShader);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "textShader", _g_get_textShader);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "textBrighterShader", _g_get_textBrighterShader);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "bmFontShader", _g_get_bmFontShader);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "Get", _s_set_Get);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "imageShader", _s_set_imageShader);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "textShader", _s_set_textShader);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "textBrighterShader", _s_set_textBrighterShader);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "bmFontShader", _s_set_bmFontShader);
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					FairyGUI.ShaderConfig gen_ret = new FairyGUI.ShaderConfig();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to FairyGUI.ShaderConfig constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetShader_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _name = LuaAPI.lua_tostring(L, 1);
                    
                        UnityEngine.Shader gen_ret = FairyGUI.ShaderConfig.GetShader( 
                        _name );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_propertyIDs(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, FairyGUI.ShaderConfig.propertyIDs);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Get(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, FairyGUI.ShaderConfig.Get);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_imageShader(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, FairyGUI.ShaderConfig.imageShader);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_textShader(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, FairyGUI.ShaderConfig.textShader);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_textBrighterShader(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, FairyGUI.ShaderConfig.textBrighterShader);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_bmFontShader(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, FairyGUI.ShaderConfig.bmFontShader);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Get(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    FairyGUI.ShaderConfig.Get = translator.GetDelegate<FairyGUI.ShaderConfig.GetFunction>(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_imageShader(RealStatePtr L)
        {
		    try {
                
			    FairyGUI.ShaderConfig.imageShader = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_textShader(RealStatePtr L)
        {
		    try {
                
			    FairyGUI.ShaderConfig.textShader = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_textBrighterShader(RealStatePtr L)
        {
		    try {
                
			    FairyGUI.ShaderConfig.textBrighterShader = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_bmFontShader(RealStatePtr L)
        {
		    try {
                
			    FairyGUI.ShaderConfig.bmFontShader = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
