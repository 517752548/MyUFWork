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
    public class PathfindingRecastTileUpdateWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.RecastTileUpdate);
			Utils.BeginObjectRegister(type, L, translator, 0, 1, 0, 0);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ScheduleUpdate", _m_ScheduleUpdate);
						
            
			
						
			
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 4, 0, 0);
			
            
			
			
			Utils.RegisterFunc(L, Utils.CLS_IDX, "addOnNeedUpdates", _e_add_OnNeedUpdates);
			
			Utils.RegisterFunc(L, Utils.CLS_IDX, "removeOnNeedUpdates", _e_remove_OnNeedUpdates);
			
			Utils.RegisterFunc(L, Utils.CLS_IDX, "OnNeedUpdates", _e_OnNeedUpdates);
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					Pathfinding.RecastTileUpdate gen_ret = new Pathfinding.RecastTileUpdate();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.RecastTileUpdate constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ScheduleUpdate(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RecastTileUpdate gen_to_be_invoked = (Pathfinding.RecastTileUpdate)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.ScheduleUpdate(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		

		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_OnNeedUpdates(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
                System.Action<UnityEngine.Bounds> gen_delegate = translator.GetDelegate<System.Action<UnityEngine.Bounds>>(L, 2);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#2 need System.Action<UnityEngine.Bounds>!");
                }
                
				
				if (gen_param_count == 2 && LuaAPI.xlua_is_eq_str(L, 1, "+")) {
					Pathfinding.RecastTileUpdate.OnNeedUpdates += gen_delegate;
					return 0;
				} 
				
				
				if (gen_param_count == 2 && LuaAPI.xlua_is_eq_str(L, 1, "-")) {
					Pathfinding.RecastTileUpdate.OnNeedUpdates -= gen_delegate;
					return 0;
				} 
				
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.RecastTileUpdate.OnNeedUpdates!");
        }
        
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_add_OnNeedUpdates(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
                System.Action<UnityEngine.Bounds> gen_delegate = translator.GetDelegate<System.Action<UnityEngine.Bounds>>(L, 1);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#1 need System.Action<UnityEngine.Bounds>!");
                }
                
				if (gen_param_count == 1) {
					Pathfinding.RecastTileUpdate.OnNeedUpdates += gen_delegate;
					return 0;
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.RecastTileUpdate.OnNeedUpdates!");
        }
        
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_remove_OnNeedUpdates(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
                System.Action<UnityEngine.Bounds> gen_delegate = translator.GetDelegate<System.Action<UnityEngine.Bounds>>(L, 1);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#1 need System.Action<UnityEngine.Bounds>!");
                }
                
				if (gen_param_count == 1) {
					Pathfinding.RecastTileUpdate.OnNeedUpdates -= gen_delegate;
					return 0;
				}
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.RecastTileUpdate.OnNeedUpdates!");
        }
        
    }
}
