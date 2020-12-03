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
    public class DCETRuntimePrefabLightmapDataMeshRendererLightmapDataWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(DCETRuntime.PrefabLightmapData.MeshRendererLightmapData);
			Utils.BeginObjectRegister(type, L, translator, 0, 11, 5, 5);
			
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "__clone__", __clone__);
            			
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getrenderer", _g_get_renderer);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getlightmapIndex", _g_get_lightmapIndex);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getlightmapOffsetScale", _g_get_lightmapOffsetScale);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getrealtimeLightmapIndex", _g_get_realtimeLightmapIndex);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getrealtimeLightmapScaleOffset", _g_get_realtimeLightmapScaleOffset);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setrenderer", _s_set_renderer);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setlightmapIndex", _s_set_lightmapIndex);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setlightmapOffsetScale", _s_set_lightmapOffsetScale);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setrealtimeLightmapIndex", _s_set_realtimeLightmapIndex);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setrealtimeLightmapScaleOffset", _s_set_realtimeLightmapScaleOffset);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "renderer", _g_get_renderer);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "lightmapIndex", _g_get_lightmapIndex);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "lightmapOffsetScale", _g_get_lightmapOffsetScale);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "realtimeLightmapIndex", _g_get_realtimeLightmapIndex);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "realtimeLightmapScaleOffset", _g_get_realtimeLightmapScaleOffset);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "renderer", _s_set_renderer);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "lightmapIndex", _s_set_lightmapIndex);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "lightmapOffsetScale", _s_set_lightmapOffsetScale);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "realtimeLightmapIndex", _s_set_realtimeLightmapIndex);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "realtimeLightmapScaleOffset", _s_set_realtimeLightmapScaleOffset);
            
			
			
			
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
				DCETRuntime.PrefabLightmapData.MeshRendererLightmapData gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
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
				    translator.Push(L, default(DCETRuntime.PrefabLightmapData.MeshRendererLightmapData));
			        return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to DCETRuntime.PrefabLightmapData.MeshRendererLightmapData constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_renderer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.PrefabLightmapData.MeshRendererLightmapData gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.Push(L, gen_to_be_invoked.renderer);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_lightmapIndex(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.PrefabLightmapData.MeshRendererLightmapData gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.lightmapIndex);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_lightmapOffsetScale(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.PrefabLightmapData.MeshRendererLightmapData gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.PushUnityEngineVector4(L, gen_to_be_invoked.lightmapOffsetScale);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_realtimeLightmapIndex(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.PrefabLightmapData.MeshRendererLightmapData gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.realtimeLightmapIndex);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_realtimeLightmapScaleOffset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.PrefabLightmapData.MeshRendererLightmapData gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.PushUnityEngineVector4(L, gen_to_be_invoked.realtimeLightmapScaleOffset);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_renderer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.PrefabLightmapData.MeshRendererLightmapData gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                gen_to_be_invoked.renderer = (UnityEngine.MeshRenderer)translator.GetObject(L, 2, typeof(UnityEngine.MeshRenderer));
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_lightmapIndex(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.PrefabLightmapData.MeshRendererLightmapData gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                gen_to_be_invoked.lightmapIndex = LuaAPI.xlua_tointeger(L, 2);
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_lightmapOffsetScale(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.PrefabLightmapData.MeshRendererLightmapData gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                UnityEngine.Vector4 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.lightmapOffsetScale = gen_value;
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_realtimeLightmapIndex(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.PrefabLightmapData.MeshRendererLightmapData gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                gen_to_be_invoked.realtimeLightmapIndex = LuaAPI.xlua_tointeger(L, 2);
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_realtimeLightmapScaleOffset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.PrefabLightmapData.MeshRendererLightmapData gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                UnityEngine.Vector4 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.realtimeLightmapScaleOffset = gen_value;
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
