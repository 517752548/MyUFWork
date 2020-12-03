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
    public class PathfindingRecastTileUpdateHandlerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.RecastTileUpdateHandler);
			Utils.BeginObjectRegister(type, L, translator, 0, 5, 1, 1);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetGraph", _m_SetGraph);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ScheduleUpdate", _m_ScheduleUpdate);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateDirtyTiles", _m_UpdateDirtyTiles);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmaxThrottlingDelay", _g_get_maxThrottlingDelay);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmaxThrottlingDelay", _s_set_maxThrottlingDelay);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "maxThrottlingDelay", _g_get_maxThrottlingDelay);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "maxThrottlingDelay", _s_set_maxThrottlingDelay);
            
			
			
			
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
					
					Pathfinding.RecastTileUpdateHandler gen_ret = new Pathfinding.RecastTileUpdateHandler();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.RecastTileUpdateHandler constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetGraph(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RecastTileUpdateHandler gen_to_be_invoked = (Pathfinding.RecastTileUpdateHandler)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.RecastGraph _graph = (PF.RecastGraph)translator.GetObject(L, 2, typeof(PF.RecastGraph));
                    
                    gen_to_be_invoked.SetGraph( 
                        _graph );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ScheduleUpdate(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RecastTileUpdateHandler gen_to_be_invoked = (Pathfinding.RecastTileUpdateHandler)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Bounds _bounds;translator.Get(L, 2, out _bounds);
                    
                    gen_to_be_invoked.ScheduleUpdate( 
                        _bounds );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateDirtyTiles(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RecastTileUpdateHandler gen_to_be_invoked = (Pathfinding.RecastTileUpdateHandler)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.UpdateDirtyTiles(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_maxThrottlingDelay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RecastTileUpdateHandler gen_to_be_invoked = (Pathfinding.RecastTileUpdateHandler)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.maxThrottlingDelay);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_maxThrottlingDelay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RecastTileUpdateHandler gen_to_be_invoked = (Pathfinding.RecastTileUpdateHandler)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.maxThrottlingDelay = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
