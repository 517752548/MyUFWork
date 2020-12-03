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
    public class DCETRuntimePrefabLightmapDataWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(DCETRuntime.PrefabLightmapData);
			Utils.BeginObjectRegister(type, L, translator, 0, 7, 2, 2);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Clear", _m_Clear);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Save", _m_Save);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Set", _m_Set);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getrendererLightmapDatas", _g_get_rendererLightmapDatas);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getterrainLightmapDatas", _g_get_terrainLightmapDatas);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setrendererLightmapDatas", _s_set_rendererLightmapDatas);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setterrainLightmapDatas", _s_set_terrainLightmapDatas);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "rendererLightmapDatas", _g_get_rendererLightmapDatas);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "terrainLightmapDatas", _g_get_terrainLightmapDatas);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "rendererLightmapDatas", _s_set_rendererLightmapDatas);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "terrainLightmapDatas", _s_set_terrainLightmapDatas);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "Init", _m_Init_xlua_st_);
            
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					DCETRuntime.PrefabLightmapData gen_ret = new DCETRuntime.PrefabLightmapData();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to DCETRuntime.PrefabLightmapData constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clear(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DCETRuntime.PrefabLightmapData gen_to_be_invoked = (DCETRuntime.PrefabLightmapData)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Clear(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Save(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DCETRuntime.PrefabLightmapData gen_to_be_invoked = (DCETRuntime.PrefabLightmapData)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Save(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Set(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DCETRuntime.PrefabLightmapData gen_to_be_invoked = (DCETRuntime.PrefabLightmapData)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Set(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Init_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object __object = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    
                    DCETRuntime.PrefabLightmapData.Init( 
                        __object );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_rendererLightmapDatas(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.PrefabLightmapData gen_to_be_invoked = (DCETRuntime.PrefabLightmapData)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.rendererLightmapDatas);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_terrainLightmapDatas(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.PrefabLightmapData gen_to_be_invoked = (DCETRuntime.PrefabLightmapData)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.terrainLightmapDatas);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_rendererLightmapDatas(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.PrefabLightmapData gen_to_be_invoked = (DCETRuntime.PrefabLightmapData)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.rendererLightmapDatas = (System.Collections.Generic.List<DCETRuntime.PrefabLightmapData.MeshRendererLightmapData>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<DCETRuntime.PrefabLightmapData.MeshRendererLightmapData>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_terrainLightmapDatas(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.PrefabLightmapData gen_to_be_invoked = (DCETRuntime.PrefabLightmapData)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.terrainLightmapDatas = (System.Collections.Generic.List<DCETRuntime.PrefabLightmapData.TerrainLightmapData>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<DCETRuntime.PrefabLightmapData.TerrainLightmapData>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
