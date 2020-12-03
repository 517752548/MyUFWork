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
    public class PathfindingRVORVOObstacleWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.RVO.RVOObstacle);
			Utils.BeginObjectRegister(type, L, translator, 0, 10, 2, 2);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnDrawGizmos", _m_OnDrawGizmos);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnDrawGizmosSelected", _m_OnDrawGizmosSelected);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnDisable", _m_OnDisable);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnEnable", _m_OnEnable);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Start", _m_Start);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Update", _m_Update);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getobstacleMode", _g_get_obstacleMode);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getlayer", _g_get_layer);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setobstacleMode", _s_set_obstacleMode);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setlayer", _s_set_layer);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "obstacleMode", _g_get_obstacleMode);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "layer", _g_get_layer);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "obstacleMode", _s_set_obstacleMode);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "layer", _s_set_layer);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "Pathfinding.RVO.RVOObstacle does not have a constructor!");
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnDrawGizmos(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RVO.RVOObstacle gen_to_be_invoked = (Pathfinding.RVO.RVOObstacle)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                    gen_to_be_invoked.OnDrawGizmos(  );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool _selected = LuaAPI.lua_toboolean(L, 2);
                    
                    gen_to_be_invoked.OnDrawGizmos( 
                        _selected );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.RVO.RVOObstacle.OnDrawGizmos!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnDrawGizmosSelected(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RVO.RVOObstacle gen_to_be_invoked = (Pathfinding.RVO.RVOObstacle)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnDrawGizmosSelected(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnDisable(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RVO.RVOObstacle gen_to_be_invoked = (Pathfinding.RVO.RVOObstacle)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnDisable(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnEnable(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RVO.RVOObstacle gen_to_be_invoked = (Pathfinding.RVO.RVOObstacle)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnEnable(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Start(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RVO.RVOObstacle gen_to_be_invoked = (Pathfinding.RVO.RVOObstacle)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Start(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Update(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RVO.RVOObstacle gen_to_be_invoked = (Pathfinding.RVO.RVOObstacle)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Update(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_obstacleMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOObstacle gen_to_be_invoked = (Pathfinding.RVO.RVOObstacle)translator.FastGetCSObj(L, 1);
                translator.PushPathfindingRVORVOObstacleObstacleVertexWinding(L, gen_to_be_invoked.obstacleMode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_layer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOObstacle gen_to_be_invoked = (Pathfinding.RVO.RVOObstacle)translator.FastGetCSObj(L, 1);
                translator.PushPathfindingRVORVOLayer(L, gen_to_be_invoked.layer);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_obstacleMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOObstacle gen_to_be_invoked = (Pathfinding.RVO.RVOObstacle)translator.FastGetCSObj(L, 1);
                Pathfinding.RVO.RVOObstacle.ObstacleVertexWinding gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.obstacleMode = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_layer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RVO.RVOObstacle gen_to_be_invoked = (Pathfinding.RVO.RVOObstacle)translator.FastGetCSObj(L, 1);
                Pathfinding.RVO.RVOLayer gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.layer = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
