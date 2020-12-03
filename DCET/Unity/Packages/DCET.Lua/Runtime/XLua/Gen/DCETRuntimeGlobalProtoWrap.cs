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
    public class DCETRuntimeGlobalProtoWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(DCETRuntime.GlobalProto);
			Utils.BeginObjectRegister(type, L, translator, 0, 5, 2, 2);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetUrl", _m_GetUrl);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getAssetBundleServerUrl", _g_get_AssetBundleServerUrl);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getAddress", _g_get_Address);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setAssetBundleServerUrl", _s_set_AssetBundleServerUrl);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setAddress", _s_set_Address);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "AssetBundleServerUrl", _g_get_AssetBundleServerUrl);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Address", _g_get_Address);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "AssetBundleServerUrl", _s_set_AssetBundleServerUrl);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Address", _s_set_Address);
            
			
			
			
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
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					DCETRuntime.GlobalProto gen_ret = new DCETRuntime.GlobalProto();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to DCETRuntime.GlobalProto constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetUrl(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DCETRuntime.GlobalProto gen_to_be_invoked = (DCETRuntime.GlobalProto)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        string gen_ret = gen_to_be_invoked.GetUrl(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AssetBundleServerUrl(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.GlobalProto gen_to_be_invoked = (DCETRuntime.GlobalProto)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.AssetBundleServerUrl);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Address(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.GlobalProto gen_to_be_invoked = (DCETRuntime.GlobalProto)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.Address);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AssetBundleServerUrl(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.GlobalProto gen_to_be_invoked = (DCETRuntime.GlobalProto)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.AssetBundleServerUrl = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Address(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.GlobalProto gen_to_be_invoked = (DCETRuntime.GlobalProto)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Address = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
